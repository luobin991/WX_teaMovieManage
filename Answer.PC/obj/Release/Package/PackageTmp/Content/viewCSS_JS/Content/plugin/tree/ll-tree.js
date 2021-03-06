﻿/*
 * 日 期：2017.11.16
 * 描 述：learunTree	
 */
(function ($, luoluo) {
    "use strict";
    $.lltree = {
        getItem: function (path, dfop) {
            var ap = path.split(".");
            var t = dfop.data;
            for (var i = 0; i < ap.length; i++) {
                if (i == 0) {
                    t = t[ap[i]];
                }
                else {
                    t = t.ChildNodes[ap[i]];
                }
            }
            return t;
        },
        render: function ($self) {
            var dfop = $self[0]._lltree.dfop;
            // 渲染成树
            var $treeRoot = $('<ul class="ll-tree-root" ></ul>');
            var _len = dfop.data.length;
            for (var i = 0; i < _len; i++) {
                var $node = $.lltree.renderNode(dfop.data[i], 0, i, dfop);
                $treeRoot.append($node);
            }
            $self.append($treeRoot);
            $self.mCustomScrollbar({ // 优化滚动条
                theme: "minimal-dark"
            });
            dfop = null;
        },
        renderNode: function (node, deep, path, dfop) {
            node._deep = deep;
            node._path = path;
            // 渲染成单个节点
            var nid = node.id.replace(/[^\w]/gi, "_");
            var title = node.title || node.text;
            var $node = $('<li class="ll-tree-node"></li>');
            var $nodeDiv = $('<div id="' + dfop.id + '_' + nid + '" tpath="' + path + '" title="' + title + '"  dataId="' + dfop.id + '"  class="ll-tree-node-el" ></div>');
            if (node.hasChildren) {
                var c = (node.isexpand || dfop.isAllExpand) ? 'll-tree-node-expanded' : 'll-tree-node-collapsed';
                $nodeDiv.addClass(c);
            }
            else {
                $nodeDiv.addClass('ll-tree-node-leaf');
            }
            // span indent
            var $span = $('<span class="ll-tree-node-indent"></span>');
            if (deep == 1) {
                $span.append('<img class="ll-tree-icon" src="' + dfop.cbiconpath + 's.gif"/>');
            }
            else if (deep > 1) {
                $span.append('<img class="ll-tree-icon" src="' + dfop.cbiconpath + 's.gif"/>');
                for (var j = 1; j < deep; j++) {
                    $span.append('<img class="ll-tree-icon" src="' + dfop.cbiconpath + 's.gif"/>');
                }
            }
            $nodeDiv.append($span);
            // img
            var $img = $('<img class="ll-tree-ec-icon" src="' + dfop.cbiconpath + 's.gif"/>');
            $nodeDiv.append($img);
            // checkbox
            if (node.showcheck) {
                if (node.checkstate == null || node.checkstate == undefined) {
                    node.checkstate = 0;
                }
                var $checkBox = $('<img  id="' + dfop.id + '_' + nid + '_cb" + class="ll-tree-node-cb" src="' + dfop.cbiconpath + dfop.icons[node.checkstate] + '" />');
                $nodeDiv.append($checkBox);
            }
            // 显示的小图标
            if (node.icon != -1) {
                if (!!node.icon) {
                    $nodeDiv.append('<i class="' + node.icon + '"></i>&nbsp;');
                } else if (node.hasChildren) {
                    if (node.isexpand || dfop.isAllExpand) {
                        $nodeDiv.append('<i class="fa fa-folder-open" style="width:15px">&nbsp;</i>');
                    }
                    else {
                        $nodeDiv.append('<i class="fa fa-folder" style="width:15px">&nbsp;</i>');
                    }
                }
                else {
                    $nodeDiv.append('<i class="fa fa-file-o"></i>&nbsp;');
                }
            }
            // a
            var ahtml = '<a class="ll-tree-node-anchor" href="javascript:void(0);">';
            ahtml += '<span data-value="' + node.id + '" class="ll-tree-node-text" >' + node.text + '</span>';
            ahtml += '</a>';
            $nodeDiv.append(ahtml);
            // 节点事件绑定
            $nodeDiv.on('click', $.lltree.nodeClick);

            if (!node.complete) {
                $nodeDiv.append('<div class="ll-tree-loading"><img class="ll-tree-ec-icon" src="' + dfop.cbiconpath + 'loading.gif"/></div>');
            }

            $node.append($nodeDiv);
            if (node.hasChildren) {
                var $treeChildren = $('<ul  class="ll-tree-node-ct" >');
                if (!node.isexpand && !dfop.isAllExpand) {
                    $treeChildren.css('display', 'none');
                }
                if (node.ChildNodes) {
                    var l = node.ChildNodes.length;
                    for (var k = 0; k < l; k++) {
                        node.ChildNodes[k].parent = node;
                        var $childNode = $.lltree.renderNode(node.ChildNodes[k], deep + 1, path + "." + k, dfop);
                        $treeChildren.append($childNode);
                    }
                    $node.append($treeChildren);
                }
            }
            node.render = true;
            dfop = null;
            return $node;
        },
        renderNodeAsync: function ($this, node, dfop) {
            var $treeChildren = $('<ul  class="ll-tree-node-ct" >');
            if (!node.isexpand && !dfop.isAllExpand) {
                $treeChildren.css('display', 'none');
            }
            if (node.ChildNodes) {
                var l = node.ChildNodes.length;
                for (var k = 0; k < l; k++) {
                    node.ChildNodes[k].parent = node;
                    var $childNode = $.lltree.renderNode(node.ChildNodes[k], node._deep + 1, node._path + "." + k, dfop);
                    $treeChildren.append($childNode);
                }
                $this.parent().append($treeChildren);
            }
            return $treeChildren;
        },
        renderToo: function ($self) {
            var dfop = $self[0]._lltree.dfop;
            // 渲染成树
            var $treeRoot = $self.find('.ll-tree-root');
            $treeRoot.html('');
            var _len = dfop.data.length;
            for (var i = 0; i < _len; i++) {
                var $node = $.lltree.renderNode(dfop.data[i], 0, i, dfop);
                $treeRoot.append($node);
            }
            dfop = null;
        },
        nodeClick: function (e) {
            var et = e.target || e.srcElement;
            var $this = $(this);
            var $parent = $('#' + $this.attr('dataId'));
            var dfop = $parent[0]._lltree.dfop;
            if (et.tagName == 'IMG') {
                var $et = $(et);
                var $ul = $this.next('.ll-tree-node-ct');
                if ($et.hasClass("ll-tree-ec-icon")) {
                    if ($this.hasClass('ll-tree-node-expanded')) {
                        $ul.slideUp(200, function () {
                            $this.removeClass('ll-tree-node-expanded');
                            $this.addClass('ll-tree-node-collapsed');
                        });
                    }
                    else if ($this.hasClass('ll-tree-node-collapsed')) {
                        // 展开
                        var path = $this.attr('tpath');
                        var node = $.lltree.getItem(path, dfop);
                        if (!node.complete) {
                            if (!node._loading) {
                                node._loading = true;// 表示正在加载数据
                                $this.find('.ll-tree-loading').show();
                                luoluo.httpAsync('GET', dfop.url, { parentId: node.id }, function (data) {
                                    if (!!data) {
                                        node.ChildNodes = data;
                                        $ul = $.lltree.renderNodeAsync($this, node, dfop);
                                        $ul.slideDown(200, function () {
                                            $this.removeClass('ll-tree-node-collapsed');
                                            $this.addClass('ll-tree-node-expanded');
                                        });
                                        node.complete = true;
                                        $this.find('.ll-tree-loading').hide();
                                    }
                                    node._loading = false;
                                });
                            }
                        }
                        else {
                            $ul.slideDown(200, function () {
                                $this.removeClass('ll-tree-node-collapsed');
                                $this.addClass('ll-tree-node-expanded');
                            });
                        }                       
                    }

                }
                else if ($et.hasClass("ll-tree-node-cb")) {
                    var path = $this.attr('tpath');
                    var node = $.lltree.getItem(path, dfop);
                    if (node.checkstate == 1) {
                        node.checkstate = 0;
                    }
                    else {
                        node.checkstate = 1;
                    }
                    $et.attr('src', dfop.cbiconpath + dfop.icons[node.checkstate]);
                    var r = true;
                    if (!!dfop.nodeCheck) {
                        r = dfop.nodeCheck(node, $this);
                    }

                    if (r) {//判断是否需要选中父子节点
                        $.lltree.checkChild($.lltree.check, node, node.checkstate, dfop);
                        $.lltree.checkParent($.lltree.check, node, node.checkstate, dfop);
                    }
                }
            }
            else {
                var path = $this.attr('tpath');
                var node = $.lltree.getItem(path, dfop);
                dfop.currentItem = node;
                $('#' + dfop.id).find('.ll-tree-selected').removeClass('ll-tree-selected');
                $this.addClass('ll-tree-selected');
                if (!!dfop.nodeClick) {
                    dfop.nodeClick(node, $this);
                }
            }
            return false;
        },
        check: function (item, state, type, dfop) {
            var pstate = item.checkstate;
            if (type == 1) {
                item.checkstate = state;
            }
            else {// go to childnodes
                var cs = item.ChildNodes;
                var l = cs.length;
                var ch = true;
                for (var i = 0; i < l; i++) {
                    cs[i].checkstate = cs[i].checkstate || 0;
                    if ((state == 1 && cs[i].checkstate != 1) || state == 0 && cs[i].checkstate != 0) {
                        ch = false;
                        break;
                    }
                }
                if (ch) {
                    item.checkstate = state;
                }
                else {
                    item.checkstate = 2;
                }
            }
            //change show
            if (item.render && pstate != item.checkstate) {
                var nid = item.id.replace(/[^\w]/gi, "_");
                var et = $("#" + dfop.id + "_" + nid + "_cb");
                if (et.length == 1) {
                    et.attr("src", dfop.cbiconpath + dfop.icons[item.checkstate]);
                }
            }
        },
        checkParent: function (fn, node, state, dfop) {
            var p = node.parent;
            while (p) {
                var r = fn(p, state, 0, dfop);
                if (r === false) {
                    break;
                }
                p = p.parent;
            }
        },
        checkChild: function (fn, node, state, dfop) {
            if (fn(node, state, 1, dfop) != false) {
                if (node.ChildNodes != null && node.ChildNodes.length > 0) {
                    var cs = node.ChildNodes;
                    for (var i = 0, len = cs.length; i < len; i++) {
                        $.lltree.checkChild(fn, cs[i], state, dfop);
                    }
                }
            }
        },
        search: function (keyword, data) {
            var childData = [];
            $.each(data, function (i, row) {
                var item = {};
                for (var ii in row) {
                    if (ii != "ChildNodes") {
                        item[ii] = row[ii];
                    }
                }
                var flag = false;
                if (item.text.indexOf(keyword) != -1) {
                    flag = true;
                }
                if (item.hasChildren) {
                    item.ChildNodes = $.lltree.search(keyword, row.ChildNodes);
                    if (item.ChildNodes.length > 0) {
                        flag = true;
                    }
                    else {
                        item.hasChildren = false;
                    }
                }
                if (flag) {
                    item.isexpand = true;
                    childData.push(item);
                }
            });
            return childData;
        },
        findItem: function (data, id, value) {
            var _item = null;
            _fn(data, id, value);
            function _fn(_cdata, _id, _value) {
                for (var i = 0, l = _cdata.length; i < l; i++) {
                    if (_cdata[i][id] == value) {
                        _item = _cdata[i];
                        return true;
                    }
                    if (_cdata[i].hasChildren && _cdata[i].ChildNodes.length > 0) {
                        if (_fn(_cdata[i].ChildNodes, _id, _value)) {
                            return true;
                        }
                    }
                }
                return false;
            }
            return _item;
        },
        listTotree: function (data, parentId, id, text, value, check) {
            // 只适合小数据计算
            var resdata = [];
            var mapdata = {};
            for (var i = 0, l = data.length; i < l; i++) {
                var item = data[i];
                mapdata[item[parentId]] = mapdata[item[parentId]] || [];
                mapdata[item[parentId]].push(item);
            }
            _fn(resdata, '0');
            function _fn(_data, vparentId) {
                var pdata = mapdata[vparentId] || [];
                for (var j = 0, l = pdata.length; j < l; j++) {
                    var _item = pdata[j];
                    var _point = {
                        id: _item[id],
                        text: _item[text],
                        value: _item[value],
                        showcheck: check,
                        checkstate: false,
                        hasChildren: false,
                        isexpand: false,
                        complete: true,
                        ChildNodes: []
                    };
                    if (_fn(_point.ChildNodes, _item[id])) {
                        _point.hasChildren = true;
                        _point.isexpand = true;
                    }
                    _data.push(_point);
                }
                return _data.length > 0;
            }
            return resdata;
        },
        treeTotree: function (data, id, text, value, check, childId) {
            var resdata = [];
            _fn(resdata, data);
            function _fn(todata,fromdata) {
                for (var i = 0, l = fromdata.length; i < l; i++) {
                    var _item = fromdata[i];
                    var _point = {
                        id: _item[id],
                        text: _item[text],
                        value: _item[value],
                        showcheck: check,
                        checkstate: false,
                        hasChildren: false,
                        isexpand: true,
                        complete: true,
                        ChildNodes: []
                    };
                    if (_item[childId].length > 0) {
                        _point.hasChildren = true;
                        _fn(_point.ChildNodes, _item[childId]);
                    }
                    todata.push(_point);
                }
            }
            return resdata;
        },

        addNode: function ($self, node, Id, index) {// 下一版本完善
            var dfop = $self[0]._lltree.dfop;
            if (!!Id)// 在最顶层
            {
                dfop.data.splice(index, 0, node);
                var $node = $.lltree.renderNode(node, 0, index, dfop);
                if ($self.find('.ll-tree-root>li').length == 0) {
                    $self.find('.ll-tree-root>li').append($node);
                }
                else {
                    $self.find('.ll-tree-root>li').eq(index).before($node);
                }

            }
            else {
                var $parentId = $self.find('#' + dfop.id + '_' + Id);
                var path = $parentId.attr('tpath');
                var $node = $.lltree.renderNode(node, 0, path + '.' + index, dfop);
                if ($parentId.next().children().length == 0) {
                    $parentId.next().children().append($node);
                }
                else {
                    $parentId.next().children().eq(index).before($node);
                }
            }
        },
        setValue: function ($self) {
            var dfop = $self[0]._lltree.dfop;
            if (dfop.data.length == 0) {
                setTimeout(function () {
                    $.lltree.setValue($self);
                }, 100);
            }
            else {
                $self.find('span[data-value="' + dfop._value + '"]').trigger('click');
            }
        }
    };

    $.fn.lltree = function (settings) {
        var dfop = {
            icons: ['checkbox_0.png', 'checkbox_1.png', 'checkbox_2.png'],
            method: "GET",
            url: false,
            param: null,
            /* [{
            id,
            text,
            value,
            showcheck,bool
            checkstate,int
            hasChildren,bool
            isexpand,bool
            complete,bool
            ChildNodes,[]
            }]*/
            data: [],
            isAllExpand: false,
            cbiconpath: '/Content/images/learuntree/',
            // 点击事件（节点信息）,节点$对象
            nodeClick: false,
            // 选中事件（节点信息）,节点$对象
            nodeCheck: false
        };
        $.extend(dfop, settings);
        var $self = $(this);
        dfop.id = $self.attr("id");
        if (dfop.id == null || dfop.id == "") {
            dfop.id = "learuntree" + new Date().getTime();
            $self.attr("id", dfop.id);
        }
        $self.html('');
        $self.addClass("ll-tree");
        $self[0]._lltree = { dfop: dfop };
        $self[0]._lltree.dfop.backupData = dfop.data;
        if (dfop.url) {
            luoluo.httpAsync(dfop.method, dfop.url, dfop.param, function (data) {
                $self[0]._lltree.dfop.data = data || [];
                $self[0]._lltree.dfop.backupData = $self[0]._lltree.dfop.data;
                $.lltree.render($self);
            });
        }
        else {
            $.lltree.render($self);
        }
        // pre load the icons
        if (dfop.showcheck) {
            for (var i = 0; i < 3; i++) {
                var im = new Image();
                im.src = dfop.cbiconpath + dfop.icons[i];
            }
        }
        dfop = null;
        return $self;
    };

    $.fn.lltreeSet = function (name,op) {
        var $self = $(this);
        var dfop = $self[0]._lltree.dfop;
        var getCheck = function (items, buff, fn) {
            for (var i = 0, l = items.length; i < l; i++) {
                if ($self.find('#' + dfop.id + '_' + items[i].id.replace(/-/g, '_')).parent().css('display') != 'none') {
                    (items[i].showcheck == true && (items[i].checkstate == 1 || items[i].checkstate == 2)) && buff.push(fn(items[i]));
                    if (!items[i].showcheck || (items[i].showcheck == true && (items[i].checkstate == 1 || items[i].checkstate == 2))) {
                        if (items[i].ChildNodes != null && items[i].ChildNodes.length > 0) {
                            getCheck(items[i].ChildNodes, buff, fn);
                        }
                    }
                }
            }
        };
        switch (name) {
            case 'allCheck':
                $self.find('.ll-tree-node-cb[src$="checkbox_0.png"]').trigger('click');
                break;
            case 'setCheck':
                var list = op;
                $.each(list, function (id, item) {
                    var $div = $self.find('#' + dfop.id + '_' + item.replace(/-/g, '_'));
                    if ($div.next().length == 0) {
                        $div.find('.ll-tree-node-cb').trigger('click');
                    }
                });
                break;
            case 'setValue':
                dfop._value = op;
                $.lltree.setValue($self);
                break;
            case 'currentItem':
                return dfop.currentItem;
                break;
            case 'getCheckNodes':
                var buff = [];
                getCheck(dfop.data, buff, function (item) {return item; });
                return buff;
                break;
            case 'getCheckNodeIds':
                var buff = [];
                getCheck(dfop.data, buff, function (item) {return item.id; });
                return buff;
                break;
            case 'getCheckNodeIdsByPath':
                var buff = [];
                var pathlist
                getCheck(dfop.data, buff, function (item) { return item.id; });
                return buff;
                break;
            case 'search':
                if (luoluo.validator.isNotNull(op.keyword).code) {
                    dfop._isSearch = true;
                    dfop.data = $.lltree.search(op.keyword, dfop.backupData);
                    $.lltree.renderToo($self);
                }
                else if (dfop._isSearch) {
                    dfop.data = dfop.backupData;
                    $.lltree.renderToo($self);
                    dfop._isSearch = false;
                }
                break;
            case 'refresh':
                $.extend(dfop, op || {});
                if (!!dfop.url) {
                    luoluo.httpAsync(dfop.method, dfop.url, dfop.param, function (data) {
                        $self[0]._lltree.dfop.data = data || [];
                        $self[0]._lltree.dfop.backupData = $self[0]._lltree.dfop.data;
                        $.lltree.renderToo($self);
                        dfop._isSearch = false;
                    });
                }
                else {
                    $self[0]._lltree.dfop.backupData = $self[0]._lltree.dfop.data;
                    $.lltree.renderToo($self);
                    dfop._isSearch = false;
                }
                break;
            case 'addNode':
                
                break;
            case 'updateNode':

                break;
        }
    }

})(jQuery, top.luoluo);
