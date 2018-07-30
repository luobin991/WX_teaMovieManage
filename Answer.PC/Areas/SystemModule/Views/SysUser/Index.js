/*
 * 日 期：2017.11.16
 * 描 述：每天新增人数在单项产品	
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
                var Keyword = $('#txt_Keyword').val();
                page.search({
                    Keyword: Keyword,
                });
            });


            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                selectedRow = null;
                learun.layerForm({
                    id: 'form',
                    title: '添加账号',
                    url: top.$.rootUrl + '/SystemModule/SysUser/Form?id=0',
                    width: 550,
                    height: 250,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 启用
            $('#lr_enabled').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('Id');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认要【启用】账号！', function (res) {
                        if (res) {
                            learun.postForm(top.$.rootUrl + '/SystemModule/SysUser/UpdateState', { keyValue: keyValue, state: 1008001 }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 禁用
            $('#lr_disabled').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('Id');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认要【禁用】账号！', function (res) {
                        if (res) {
                            learun.postForm(top.$.rootUrl + '/SystemModule/SysUser/UpdateState', { keyValue: keyValue, state: 1008002 }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });

            // 重置密码
            $('#lr_resetpassword').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('Id');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认要【重置密码】！', function (res) {
                        if (res) {
                            learun.postForm(top.$.rootUrl + '/SystemModule/SysUser/ResetPassword', { keyValue: keyValue }, function () {
                            });
                        }
                    });
                }
            });

            // 功能授权
            $('#lr_authorize').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('Id');
                selectedRow = $('#girdtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'authorizeForm',
                        title: '功能授权 - ' + selectedRow.UserNickName,
                        url: top.$.rootUrl + '/AuthorizeModule/Authorize/Form?objectId=' + keyValue + '&objectType=2',
                        width: 550,
                        height: 690,
                        btn: null
                    });
                }
            });

        },
        initGird: function () {
            $('#girdtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/SystemModule/SysUser/GetPageList',
                headData: [
                        { label: '用户名', name: 'UserName', width: 150, align: 'center' },
                        { label: '真实名字', name: 'UserNickName', width: 150, align: 'center' },
                        {
                            label: '管理类型', name: 'UserType', width: 100, align: 'center', formatter: function (cellvalue) {
                                //return learun.formatDate(cellvalue, 'yyyy-MM-dd hh:mm');
                                if (cellvalue == 1007001)
                                    return "超级管理员";
                                else
                                    return "普通管理员";
                            }
                        },
                        { label: '注册IP', name: 'RegistIP', width: 100, align: 'center' },
                        { label: '注册时间', name: 'CreateDate', width: 200, align: 'center' },
                        { label: '最近登录IP', name: 'LoginIP', width: 100, align: 'center' },
                        { label: '最近登录时间', name: 'LoginDate', width: 200, align: 'center' },
                        {
                            label: '状态', name: 'Valid', width: 100, align: 'center',
                            formatter: function (cellvalue) {
                                if (cellvalue == 1008001) {
                                    return '<span class=\"label label-success\" style=\"cursor: pointer;\">正常</span>';
                                } else if (cellvalue == 1008002) {
                                    return '<span class=\"label label-default\" style=\"cursor: pointer;\">禁用</span>';
                                }
                            }
                        }
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


