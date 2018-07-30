/*
 * 日 期：2017.11.16
 * 描 述：标签明细管理	
 */
var selectedRow;
var refreshGirdData;

var acceptClick;

var pid = request('id');

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
                page.search();
            });
            // 刷新
            $('#ll_refresh').on('click', function () {
                location.reload();
            });
            //增加
            $('#ll_add').on('click', function () {
                    luoluo.layerForm({
                        id: 'form_goodsLableDetail',
                        title: '新增',
                        url: top.$.rootUrl + '/ConfigManage/GoodsLable/EditDetail?pid='+pid+'&id=0',
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
                        id: 'form_goodsLableDetail',
                        title: '修改',
                        url: top.$.rootUrl + '/ConfigManage/GoodsLable/EditDetail?pid=' + pid + '&id=' + keyValue,
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
                    luoluo.layerConfirm('是否要删除【' + $('#girdtable').jfGridValue('lable') + '】！', function (res) {
                        if (res) {
                            luoluo.postForm(top.$.rootUrl + '/configManage/goodslable/DelLableDetail', { id: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
        },
        initGird: function () {
            $('#girdtable').llAuthorizeJfGrid({
                url: top.$.rootUrl + '/configManage/goodslable/GetDetailPageList?pid=' + pid,
                headData: [
                        { label: '类别', name: 'lable', width: 100, align: 'center'},
                        { label: '修改时间', name: 'updateTimeStr', width: 150, align: 'center', sort: false },
                        { label: '创建时间', name: 'createTimeStr', width: 150, align: 'center', sort: false },
                ],
                isPage: true,
                sidx: 'id',
                sord: 'asc',
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
        page.search();
    };

    acceptClick = function (callBack) {
        if (!!callBack) {
            callBack();
        }
        luoluo.layerClose(window.name);
    };
    page.init();


}


