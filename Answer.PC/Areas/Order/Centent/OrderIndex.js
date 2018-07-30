
var selectedRow;
var refreshGirdData;
var bootstrap = function ($, luoluo) {
    "use strict";
    var companyId = '';
    var departmentId = '';

    var page = {
        init: function () {
            //page.inittree();

            page.initGird();

            page.bind();

            page.search();
        },
        bind: function () {
            // 查询
            $('#btn_Search').on('click', function () {
                var Keyword = $('#txt_Keyword').val();
                page.search({
                    Keyword: Keyword,
                });
            });


            // 刷新
            $('#ll_refresh').on('click', function () {
                location.reload();
            });
     

            // 绑定标签
            $('#ll_detail').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('id');
                if (luoluo.checkrow(keyValue)) {
                    luoluo.layerForm({
                        id: 'form',
                        title: '订单明细',
                        url: top.$.rootUrl + '/Order/Order/OrderDetail?id=' + keyValue,
                        width: 650,
                        height: 580,
                        btn: ["确认"],
                    });
                }
            });

        },
        initGird: function () {
            $('#girdtable').llAuthorizeJfGrid({
                url: top.$.rootUrl + '/Order/Order/GetPageList',
                headData: [
                        { label: '订单号', name: 'orderNum', width: 250, align: 'center' },
                        { label: '交易单号', name: 'tradingNum', width: 200, align: 'center' },
                        { label: '商户单号', name: 'merchantCode', width: 200, align: 'center' },
                        { label: '下单时间', name: 'orderTime', width: 150, align: 'center' },
                        { label: '订单数量', name: 'orderNumber', width: 80, align: 'center' },
                        { label: '订单总价', name: 'orderSumPrice', width: 80, align: 'center' },
                        {
                            label: '状态', name: 'orderStatus', width: 100, align: 'center',formatter: function (cellvalue) {
                                if (cellvalue == "待取") {
                                    return '<span class=\"label label-success\" style=\"cursor: pointer;\">' + cellvalue + '</span>';
                                } else {
                                    return '<span class=\"label label-default\" style=\"cursor: pointer;\">' + cellvalue + '</span>';
                                }
                            }
                        },
                        {
                            label: '是否外送', name: 'isOutside', width: 100, align: 'center'  , formatter: function (cellvalue) {
                                if (cellvalue == 0) {
                                    return "不外送"
                                } else {return "外送"}
                            }
                        },
                        { label: '订单用户ID', name: 'orderUser', width: 150, align: 'center' },
                        { label: '订单用户名', name: 'orderUserName', width: 100, align: 'center' },
                        { label: '订单用户电话', name: 'orderUserPhone', width: 200, align: 'center' },
                        { label: '订单用户地址', name: 'orderUserAdder', width: 300, align: 'left' },
                ],
                isPage: true,
                reloadSelected: false,
                mainId: 'Id'
            });
        },
        search: function (param) {
            param = param || {};
            $('#girdtable').jfGridSet('reload', { param: param });
        }
    };

    refreshGirdData = function () {
        var Keyword = $('#txt_Keyword').val();
        page.search({
            Keyword: Keyword,
        });
    };

    page.init();
}


