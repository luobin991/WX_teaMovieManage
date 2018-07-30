/*
 * 日 期：2017.11.16
 * 描 述：标签管理	
 */
var selectedRow;
var refreshGirdData;
var bootstrap = function ($, luoluo) {
    "use strict";

    var page = {
        init: function () {
            page.initGird();
            page.bind();
            page.search();
        },
        bind: function () {
            // 查询
            $('#btn_Search').on('click', function () {
                var keyword = $('#txt_Keyword').val();
                page.search({
                    keyword: keyword,
                });
            });
            // 刷新
            $('#ll_refresh').on('click', function () {
                location.reload();
            });
        
            //类别明细
            $('#ll_lableDetail').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('id');
                if (luoluo.checkrow(keyValue)) {
                    luoluo.layerForm({
                        id: 'form',
                        title: $('#girdtable').jfGridValue('lableName'),
                        url: top.$.rootUrl + '/configManage/goodslable/DetailIndex?id=' + keyValue,
                        width: 460,
                        height: 620,
                        btn: ["确认"],
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            //增加
            $('#ll_add').on('click', function () {
                    luoluo.layerForm({
                        id: 'form',
                        title: '新增',
                        url: top.$.rootUrl + '/configManage/goodslable/Edit?id=0',
                        width: 450,
                        height: 160,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);

                        }
                    });
            });

            // 修改
            $('#ll_edit').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('id');
                if (luoluo.checkrow(keyValue)) {
                    luoluo.layerForm({
                        id: 'form',
                        title: '修改',
                        url: top.$.rootUrl + '/configManage/goodslable/Edit?id=' + keyValue,
                        width: 450,
                        height: 160,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);

                        }
                    });
                }
            });

            // 删除
            $('#ll_del').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('id');
                if (luoluo.checkrow(keyValue)) {
                    luoluo.layerConfirm('是否要删除【' + $('#girdtable').jfGridValue('lableName') + '】，包括旗下所有标签！', function (res) {
                        if (res) {
                            luoluo.postForm(top.$.rootUrl + '/configManage/goodslable/DelLable', { id: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
        },
        initGird: function () {
            $('#girdtable').llAuthorizeJfGrid({
                url: top.$.rootUrl + '/configManage/goodslable/GetPageList',
                headData: [
                        {
                            label: '类别', name: 'lableName', width: 100, align: 'center', formatter: function (callback) {
                                if (callback == "")
                                    return "";
                                else {
                                    return '<span class="label label-primary">' + callback + '</span>';
                                }
                            }
                        },
                        {
                            label: '标签明细', name: 'lableDetail', width: 300, align: 'center', formatter: function (callback) {
                                
                                if (callback == "" || callback==null)
                                    return '';
                                else
                                {
                                    var array = callback.split(',');
                                    var lables = "";
                                    for (var i = 0; i < array.length; i++) {
                                        lables += '<span class="label label-success">' + array[i] + '</span>   ';
                                    }
                                    return lables;
                                }
                            }
                        },
                        { label: '时间', name: 'createTimeStr', width: 150, align: 'center', sort: true },
                ],
                isPage: true,
                sidx: 'createTime',
                sord: 'desc',
                reloadSelected: false,
                mainId: 'id'
            });
        },
        search: function (param) {
            param = param || {};
            $('#girdtable').jfGridSet('reload', { param: param });
        }
    };

    refreshGirdData = function () {
        var keyword = $('#txt_Keyword').val();
        page.search({
            keyword: keyword,
        });
    };

    page.init();
}


