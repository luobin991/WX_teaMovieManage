﻿/*
 * 日 期：2017.11.16
 * 描 述：learunSelect（普通，多选，树形数据，gird，搜索，输入框选择器）-渲染数据在点击的时候触发，考虑到在一个表单上有超级多的下拉框的绑定情况（这里需要考虑赋值的特殊性）
 */
(function ($, luoluo) {
    "use strict";
    $.llselect = {
        htmlToData: function ($self) {
            var dfop = $self[0]._lrselect.dfop;
            var $ul = $self.find('ul');
            dfop.data = [];
            $ul.find('li').each(function () {
                var $li = $(this);
                var point = { id: $li.attr('data-value'), text: $li.html() }
                dfop.data.push(point);
            });
            $ul.remove();
            $ul = null;
            dfop = null;
        },
        initRender: function (dfop, $self) {
            var $option = $('<div class="ll-select-option" id="learun_select_option_' + dfop.id + '"></div>');

            var $optionContent = $('<div class="ll-select-option-content"></div>');
            var $ul = $('<ul id="learun_select_option_content' + dfop.id + '"></ul>');
            $optionContent.css('max-height', dfop.maxHeight + 'px');
            $option.hide();
            $optionContent.html($ul);
            $option.prepend($optionContent);
            if (dfop.allowSearch) {
                var $search = $('<div class="ll-select-option-search"><input type="text" placeholder="搜索关键字"><span class="input-query" title="查询"><i class="fa fa-search"></i></span></div>');
                $option.append($search);
                $option.css('padding-bottom', '25px');
                $search.on('click', function () { return false; });
                $search.find('input').on("keypress", function (e) {
                    if (event.keyCode == "13") {
                        var $this = $(this);
                        var keyword = $this.val();
                        var $select = $this.parents('.ll-select');
                        var dfop = $select[0]._lrselect.dfop;
                        if (dfop.type == "tree") {
                            var $optionContent = $this.parent().prev();
                            $optionContent.lltreeSet('search', { keyword: keyword });
                        }
                        else if (dfop.type == "default") {
                            if (!!keyword) {
                                var _data = [];
                                for (var i = 0, l = dfop.backdata.length; i < l; i++) {
                                    var _item = dfop.backdata[i];
                                    if (_item[dfop.text].indexOf(keyword) != -1) {
                                        _data.push(_item);
                                    }
                                }
                                dfop.data = _data;
                            }
                            else {
                                dfop.data = dfop.backdata;
                            }
                            $.llselect.render(dfop);
                        }
                        
                    }
                });
            }
            $self.append($option);
            $self.append('<div class="ll-select-placeholder" >==' + dfop.placeholder + '==</div>');
            $self.attr('type', 'llselect').addClass('ll-select');

            if (dfop.type != 'tree') {
                $optionContent.mCustomScrollbar({ // 优化滚动条
                    theme: "minimal-dark"
                });
            }
        },
        render: function (dfop) {
            switch (dfop.type) {
                case 'default':
                    $.llselect.defaultRender(dfop);
                    break;
                case 'tree':
                    $.llselect.treeRender(dfop);
                    break;
                case 'gird':
                    break;
                case 'multiple':
                    break;
                default:
                    break;
            }
            dfop.isrender = true;
            
        },
        defaultRender: function (dfop) {
            var $ul = $('#learun_select_option_content' + dfop.id);
            $ul.html("");
            if (!!dfop.placeholder) {
                $ul.append('<li data-value="-1" class="ll-selectitem-li" >==' + dfop.placeholder + '==</li>');
            }
            for (var i = 0, l = dfop.data.length; i < l; i++) {
                var item = dfop.data[i];
                var $li = $('<li data-value="' + i + '" class="ll-selectitem-li" >' + item[dfop.text] + '</li>');
                $ul.append($li);
            }
        },
        treeRender: function (dfop) {
            var $option = $('#learun_select_option_' + dfop.id);
            $option.find('.ll-select-option-content').remove();
            var $optionContent = $('<div class="ll-select-option-content"></div>');
            $option.prepend($optionContent);
            $optionContent.css('max-height', dfop.maxHeight + 'px');
            dfop.data.unshift({
                "id": "-1",
                "text": '==' + dfop.placeholder + '==',
                "value": "-1",
                "icon": "-1",
                "parentnodes": "0",
                "showcheck": false,
                "isexpand": false,
                "complete": true,
                "hasChildren": false,
                "ChildNodes": []
            });
            $optionContent.lltree({
                data: dfop.data,
                nodeClick: $.llselect.treeNodeClick
            });
        },
        bindEvent: function ($self) {
            $self.unbind('click');
            $self.on('click', $.llselect.click);
            $(document).click(function (e) {
                $('.ll-select-option').slideUp(150);
                $('.ll-select').removeClass('ll-select-focus');
            });
        },
        click: function (e) {
            var $this = $(this);
            if ($this.attr('readonly') == 'readonly' || $this.attr('disabled') == 'disabled') {
                return false;
            }
            var dfop = $this[0]._lrselect.dfop;
            if (!dfop.isload) {
                return false;
            }
            if (!dfop.isrender) {
                $.llselect.render(dfop);
            }
            var $option = $('#learun_select_option_' + dfop.id);
            if ($option.is(":hidden")) {
                $('.ll-select-option').slideUp(150);
                $('.ll-select').removeClass('ll-select-focus');


                $this.addClass('ll-select-focus');
                var width = dfop.width || $this.parent().width();
                $option.css('width', width).show();
                $option.find('.ll-select-option-search').find('input').select();
            } else {
                $option.slideUp(150);
                $this.removeClass('ll-select-focus');
            }
            
            // 选中下拉框的某一项
            var et = e.target || e.srcElement;
            var $et = $(et);
            if ($et.hasClass('ll-selectitem-li')) {
                var _index = $et.attr('data-value');
                if (dfop._index != _index) {
                    var $inputText = $this.find('.ll-select-placeholder');
                    
                    if (_index == -1) {
                        $inputText.css('color', '#999');
                        $inputText.html('==' + dfop.placeholder + '==');
                    }
                    else {
                        $inputText.css('color', '#000');
                        $inputText.html(dfop.data[_index][dfop.text]);
                    }

                    $et.addClass('selected');
                    if (dfop._index != undefined && dfop._index != null) {
                        $option.find('.ll-selectitem-li[data-value="' + dfop._index + '"]').removeClass('selected');
                    }
                    dfop._index = _index;

                    $this.trigger("change");
                    if (!!dfop.select) {
                        dfop.select(dfop.data[_index]);
                    }
                }
            }
            dfop = null;
            e.stopPropagation();
        },
        treeNodeClick:function(item,$item){
            $item.parents('.ll-select-option').slideUp(150);
            var $select = $item.parents('.ll-select');
            var dfop = $select[0]._lrselect.dfop;
            $select.removeClass('ll-select-focus');
            dfop.currtentItem = item;
            var $inputText = $select.find('.ll-select-placeholder');
            $inputText.html(dfop.currtentItem.text);
            if (item.value == '-1') {
                $inputText.css('color', '#999');
            }
            else {
                $inputText.css('color', '#000');
            }
            $select.trigger("change");
            if (!!dfop.select) {
                dfop.select(dfop.currtentItem);
            }
        },
        defaultValue: function ($self) {
            var dfop = $self[0]._lrselect.dfop;
            dfop.currtentItem = null;
            dfop._index = -1;
            var $inputText = $self.find('.ll-select-placeholder');
            $inputText.css('color', '#999');
            $inputText.html('==' + dfop.placeholder + '==');
            $self.trigger("change");
        }
    };


    $.fn.llselect = function (op) {
        var dfop = {
            // 请选择
            placeholder: "请选择",
            // 类型
            type: 'default',// default,tree,gird,multiple
            // 字段
            value: "id",
            text: "text",
            title: "title",
            // 展开最大高度
            maxHeight: 200,
            // 宽度
            width: false,
            // 是否允许搜索
            allowSearch: false,
            // 访问数据接口地址
            url: false,
            data: false,
            // 访问数据接口参数
            param: null,
            // 接口请求的方法
            method: "GET",

            //选择事件
            select: false,
            
            isload: false, // 数据是否加载完成
            isrender: false// 选项是否渲染完成
        };
        $.extend(dfop, op || {});
        var $self = $(this);
        if ($self.length == 0) {
            return $self;
        }

        dfop.id = $self.attr('id');

        if (!dfop.id) {
            return false;
        }
        if (!!$self[0]._lrselect) {
            return $self;
        }

        $self[0]._lrselect = { dfop: dfop };
        // 基础信息渲染
        $.llselect.bindEvent($self);
        
        // 数据获取方式有三种：url,data,html
        // url优先级最高
        if (!!dfop.url) {
            luoluo.httpAsync(dfop.method, dfop.url, dfop.param, function (data) {
                $self[0]._lrselect.dfop.data = data || [];
                $self[0]._lrselect.dfop.backdata = data || [];
                dfop.isload = true;
            });
        }
        else if (!!dfop.data) {
            dfop.isload = true;
            dfop.backdata = dfop.data;
        }
        else {// 最后是html方式获取（只适合数据比较少的情况）
            $.llselect.htmlToData($self);
            dfop.isload = true;
            dfop.backdata = dfop.data;
        }
        $.llselect.initRender(dfop, $self);
        return $self;
        
    };

    $.fn.lrselectRefresh = function (op) {
        var $self = $(this);
        if ($self.length == 0) {
            return $self;
        }
        if (!$self[0]._lrselect) {
            return false;
        }
        var dfop = $self[0]._lrselect.dfop;
        if (!dfop) {
            return false;
        }
        $.extend(dfop, op || {});

        dfop.isload = false;
        dfop.isrender = false;
        if (!!dfop.url) {
            luoluo.httpAsync(dfop.method, dfop.url, dfop.param, function (data) {
                $self[0]._lrselect.dfop.data = data || [];
                $self[0]._lrselect.dfop.backdata = data || [];
                dfop.isload = true;
            });
        }
        else if (!!dfop.data) {
            dfop.isload = true;
            dfop.backdata = dfop.data;
        }
        $.llselect.defaultValue($self);
        if (dfop._setValue != null && dfop._setValue != undefined) {
            $self.llselectSet(dfop._setValue);
        }
    }

    
    $.fn.llselectGet = function () {
        var $this = $(this);
        if ($this.length == 0) {
            return $this;
        }
        var dfop = $this[0]._lrselect.dfop;
        var value = '';
        switch (dfop.type) {
            case 'default':
                if (!!dfop.data[dfop._index]) {
                    value = dfop.data[dfop._index][dfop.value];
                }
                break;
            case 'tree':
                if (!!dfop.currtentItem) {
                    value = dfop.currtentItem[dfop.value];
                }
                break;
            case 'gird':
                break;
            case 'multiple':
                break;
            default:
                break;
        }
        return value;
    };

    $.fn.llselectSet = function (value) {
        // 设置数据的值
        var $this = $(this);
        if ($this.length == 0) {
            return $this;
        }
        if (!value && value != 0 && value != '0') {
            $.llselect.defaultValue($this);
            return $this;
        }
        var dfop = $this[0]._lrselect.dfop;
        dfop._setValue = null;
        if (!dfop) {
            return $this;
        }
        function _fn(dfop) {
            if (dfop.isload == false) {
                setTimeout(function () {
                    _fn(dfop);
                }, 100);
            }
            else if (dfop.isload == true) {
                var _currtentItem;
                switch (dfop.type) {
                    case 'default':
                        for (var i = 0, l = dfop.data.length; i < l; i++) {
                            if (dfop.data[i][dfop.value] == value) {
                                dfop._index = i;
                                _currtentItem = dfop.data[i];
                                break;
                            }
                        }
                        break;
                    case 'tree':
                        _currtentItem = $.lltree.findItem(dfop.data, dfop.value, value);
                        dfop.currtentItem = _currtentItem;
                        break;
                    case 'gird':
                        break;
                    case 'multiple':
                        break;
                    default:
                        break;
                }
                if (!!_currtentItem) {
                    var $inputText = $this.find('.ll-select-placeholder');
                    $inputText.html(_currtentItem[dfop.text]);
                    $inputText.css('color', '#000');
                    $this.trigger("change");
                    if (!!dfop.select) {
                        dfop.select(_currtentItem);
                    }
                }
                else {
                    dfop._setValue = value;
                }
            }
        }
        _fn(dfop);
        return $this;
    };

})(jQuery, top.luoluo);
