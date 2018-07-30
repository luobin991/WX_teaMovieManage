/*
 * 日 期：2017.11.16
 * 描 述：人员管理	
 */
var selectedRow;
var refreshGirdData;
var bootstrap = function ($, learun) {
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
                var keyword = $('#txt_Keyword').val();
                var sdate = $('#sdate').val();
                var edate = $('#edate').val();
                page.search({
                    keyword: keyword,
                    sdate: sdate,
                    edate: edate,
                });
            });


            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
       
            $('#lr_enabled').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('F_UserId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认要【启用】账号！', function (res) {
                        if (res) {
                            learun.postForm(top.$.rootUrl + '/LR_OrganizationModule/User/UpdateState', { keyValue: keyValue, state: 1 }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 禁用
            $('#lr_disabled').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('F_UserId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认要【禁用】账号！', function (res) {
                        if (res) {
                            learun.postForm(top.$.rootUrl + '/LR_OrganizationModule/User/UpdateState', { keyValue: keyValue, state: 0 }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 重置账号
            $('#lr_resetpassword').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('F_UserId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认要【重置密码】！', function (res) {
                        if (res) {
                            learun.postForm(top.$.rootUrl + '/LR_OrganizationModule/User/ResetPassword', { keyValue: keyValue }, function () {
                            });
                        }
                    });
                }
            });

        },
        initGird: function () {
            $('#girdtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/User/User/GetPageList',
                headData: [
                        { label: '姓名', name: 'nickName', width: 100, align: 'center' },
                        {
                            label: '性别', name: 'sex', width: 50, align: 'center', formatter: function (callback) {
                                if (callback == 1)
                                    return "男";
                                else
                                    return "女";
                            }
                        },
                        { label: '注册时间', name: 'registerTime', width: 200, align: 'center' },
                        { label: '注册IP', name: 'registerIp', width: 200, align: 'center' },
                        { label: '登录时间', name: 'loginTime', width: 200, align: 'center' },
                        { label: '登录IP', name: 'loginIp', width: 200, align: 'center', formatter: function (callback, value, row) { return value.loginIp; } },
                        { label: '钻石数量', name: 'diamond', width: 100, align: 'right' },
                        { label: ' 已玩局数', name: 'roundNum', width: 100, align: 'right' },
                        {
                            label: ' 是否冻结', name: 'isFrozen', width: 100, align: 'center', formatter: function (callback) {
                                if (callback == 1)
                                    return "是";
                                else
                                    return "否";
                            }
                        },
                       { label: ' 登录的地理位置', name: 'loginAddress', width: 300, align: 'left' }

                ],
                isPage: true,
                reloadSelected: false,
                mainId: 'phone_number'
            });
        },
        search: function (param) {
            param = param || {};
            $('#girdtable').jfGridSet('reload', { param: param });
        }
    };

    refreshGirdData = function () {
        var keyword = $('#txt_Keyword').val();
        var sdate = $('#sdate').val();
        var edate = $('#edate').val();
        page.search({
            keyword: keyword,
            sdate: sdate,
            edate: edate,
        });
    };

    page.init();
}


