﻿/*
 * 日 期：2017.11.28
 * 描 述：部门管理	
 */
var selectedRow;
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            // 查询
            $('#btn_Search').on('click', function () {
                var keyword = $('#txt_Keyword').val();
                page.search({ keyword: keyword });
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
                    title: '添加角色',
                    url: top.$.rootUrl + '/SystemModule/Role/Form',
                    width: 500,
                    height: 360,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('F_RoleId');
                selectedRow = $('#girdtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑角色',
                        url: top.$.rootUrl + '/SystemModule/Role/Form',
                        width: 500,
                        height: 360,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('F_RoleId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/SystemModule/Role/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 添加角色成员
            $('#lr_memberadd').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('F_RoleId');
                var loginInfo = learun.clientdata.get(['userinfo']);
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '添加角色成员',
                        url: top.$.rootUrl + '/AuthorizeModule/UserRelation/SelectForm?objectId=' + keyValue + '&companyId=' + loginInfo.F_CompanyId + '&departmentId=' + loginInfo.F_DepartmentId + '&category=1',
                        width: 800,
                        height: 520,
                        callBack: function (id) {
                            return top[id].acceptClick();
                        }
                    });
                }
            });
            // 查看成员
            $('#lr_memberlook').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('F_RoleId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '查看角色成员',
                        url: top.$.rootUrl + '/AuthorizeModule/UserRelation/LookForm?objectId=' + keyValue,
                        width: 800,
                        height: 520,
                        btn: null
                    });
                }
            });
            // 功能授权
            $('#lr_authorize').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('F_RoleId');
                selectedRow = $('#girdtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'authorizeForm',
                        title: '功能授权 - ' + selectedRow.F_FullName,
                        url: top.$.rootUrl + '/AuthorizeModule/Authorize/Form?objectId=' + keyValue + '&objectType=1',
                        width: 550,
                        height: 690,
                        btn: null
                    });
                }
            });

            // 设置Ip过滤
            $('#lr_ipfilter').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('F_RoleId');
                selectedRow = $('#girdtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'filterIPIndex',
                        title: 'TCP/IP 地址访问限制 - ' + selectedRow.F_FullName,
                        url: top.$.rootUrl + '/SystemModule/FilterIP/Index?objectId=' + keyValue + '&objectType=Role',
                        width: 600,
                        height: 400,
                        btn: null,
                        callBack: function (id) { }
                    });
                }
            });
            // 设置时间段过滤
            $('#lr_timefilter').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('F_RoleId');
                selectedRow = $('#girdtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'filterTimeForm',
                        title: '时段访问过滤 - ' + selectedRow.F_FullName,
                        url: top.$.rootUrl + '/SystemModule/FilterTime/Form?objectId=' + keyValue + '&objectType=Role',
                        width: 610,
                        height: 470,
                        callBack: function (id) {
                            return top[id].acceptClick();
                        }
                    });
                }
            });
        },
        initGird: function () {
            $('#girdtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/SystemModule/Role/GetPageList',
                headData: [
                    { label: '角色编号', name: 'F_EnCode', width: 100, align: 'left' },
                    { label: '角色名称', name: 'F_FullName', width: 200, align: 'left' },
                    {
                        label: '创建时间', name: 'F_CreateDate', width: 130, align: 'center'
                    },
                    {
                        label: '创建人', name: 'F_CreateUserName', width: 130, align: 'center'
                    },
                    {
                        label: "有效", name: "F_EnabledMark", width: 50, align: "center",
                        formatter: function (cellvalue) {
                            return cellvalue == 1 ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
                        }
                    },
                    { label: "角色描述", name: "F_Description", index: "F_Description", width: 300, align: "left" }
                ],
                isPage: true,
                reloadSelected: true,
                mainId: 'F_RoleId'
            });

            page.search();
        },
        search: function (param) {
            param = param || {};
            $('#girdtable').jfGridSet('reload', { param: param });
        }
    };

    refreshGirdData = function () {
        page.search();
    };

    page.init();
}


