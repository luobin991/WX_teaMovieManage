/*
 * 日 期：2017.11.24
 * 描 述：功能模块	
 */
var keyValue = request('keyValue');
var moduleId = request('moduleId');

var buttonlist;
var buttonlistArray = [];
var currentBtnRow;
var currentColRow;
var bootstrap = function ($, luoluo) {
    "use strict";
    var page = {
        init: function () {
            page.bind();
            page.initGird();
            page.initData();
        },
        /*绑定事件和初始化控件*/
        bind: function () {
            // 加载导向
            $('#wizard').wizard().on('change', function (e, data) {
                var $finish = $("#btn_finish");
                var $next = $("#btn_next");
                if (data.direction == "next") {
                    if (data.step == 1) {
                        if (!$('#step-1').llValidform()) {
                            return false;
                        }
                    } else if (data.step == 2) {
                        $finish.removeAttr('disabled');
                        $next.attr('disabled', 'disabled');
                    } else {
                        $finish.attr('disabled', 'disabled');
                    }
                } else {
                    $finish.attr('disabled', 'disabled');
                    $next.removeAttr('disabled');
                }
            });
            // 目标
            $('#F_Target').llselect().on('change', function () {
                // 目标改变
                var value = $(this).llselectGet();
                var $next = $("#btn_next");
                var $finish = $("#btn_finish");
                if (value == 'expand') {
                    $next.attr('disabled', 'disabled');
                    $finish.removeAttr('disabled');
                }
                else {
                    $next.removeAttr('disabled');
                    $finish.attr('disabled', 'disabled');
                }
            });
            // 上级
            $('#F_ParentId').llselect({
                url: top.$.rootUrl + '/SystemModule/Module/GetExpendModuleTree',
                type: 'tree',
                maxHeight:180,
                allowSearch: true
            });
            // 选择图标
            $('#selectIcon').on('click', function () {
                luoluo.layerForm({
                    id: 'iconForm',
                    title: '选择图标',
                    url: top.$.rootUrl + '/Utility/Icon',
                    height: 700,
                    width: 1000,
                    btn: null,
                    maxmin: true,
                    end: function () {
                        if (top._learunSelectIcon != '')
                        {
                            $('#F_Icon').val(top._learunSelectIcon);
                        }
                    }
                });
            });
            
            /*按钮功能设置*/
            // 新增
            $('#ll_add_button').on('click', page.newButtonForm);
            // 编辑
            $('#ll_edit_button').on('click', page.editButtonForm);
            // 删除
            $('#ll_delete_button').on('click', page.deleteButton);

            /*视图功能设置*/
            // 新增
            $('#ll_add_view').on('click', page.newViewForm);
            // 编辑
            $('#ll_edit_view').on('click', page.editViewForm);
            // 删除
            $('#ll_delete_view').on('click', page.deleteView);

            // 保存数据按钮
            $("#btn_finish").on('click', page.save);
        },
        newButtonForm: function () {
            var parentId = $('#btns_girdtable').jfGridValue('ModuleButtonId');
            buttonlist = $('#btns_girdtable').jfGridGet('rowdatas');
            currentBtnRow = null;
            luoluo.layerForm({
                id: 'buttonform',
                title: '添加按钮',
                url: top.$.rootUrl + '/SystemModule/Module/ButtonForm?parentId=' + parentId,
                height: 300,
                width: 450,
                callBack: function (id) {
                    return top[id].acceptClick(function (data) {
                        buttonlistArray.push(data);
                        buttonlistArray = buttonlistArray.sort(function (a, b) {
                            return parseInt(a.SortCode) - parseInt(b.SortCode);
                        });
                        $('#btns_girdtable').jfGridSet('refreshdata', { rowdatas: buttonlistArray });
                    });
                }
            });
        },
        editButtonForm: function () {
            currentBtnRow = $('#btns_girdtable').jfGridGet('rowdata');
            buttonlist = $('#btns_girdtable').jfGridGet('rowdatas');
            var _id = currentBtnRow ? currentBtnRow.ModuleButtonId : '';
            if (luoluo.checkrow(_id)) {
                luoluo.layerForm({
                    id: 'buttonform',
                    title: '编辑按钮',
                    url: top.$.rootUrl + '/SystemModule/Module/ButtonForm',
                    height: 300,
                    width: 450,
                    callBack: function (id) {
                        return top[id].acceptClick(function (data) {
                            $.each(buttonlistArray, function (id, item) {
                                if (item.ModuleButtonId == data.ModuleButtonId) {
                                    buttonlistArray[id] = data;
                                    return false;
                                }
                            });
                            buttonlistArray = buttonlistArray.sort(function (a, b) {
                               return parseInt(a.SortCode) - parseInt(b.SortCode);
                            });
                            $('#btns_girdtable').jfGridSet('refreshdata', { rowdatas: buttonlistArray });
                        });
                    }
                });
            }
        },
        deleteButton: function () {
            var row = $('#btns_girdtable').jfGridGet('rowdata');
            var _id = row ? row.ModuleButtonId : '';
            if (luoluo.checkrow(_id)) {
                luoluo.layerConfirm('是否确认删除该按钮', function (res, index) {
                    if (res) {
                        $.each(buttonlistArray, function (id, item) {
                            if (item.ModuleButtonId == row.ModuleButtonId) {
                                buttonlistArray.splice(id, 1);
                                return false;
                            }
                        });
                        $('#btns_girdtable').jfGridSet('refreshdata', { rowdatas: buttonlistArray });
                        top.layer.close(index); //再执行关闭  
                    }
                });
            }
        },

        newViewForm: function () {
            currentColRow = null;
            luoluo.layerForm({
                id: 'viewform',
                title: '添加视图列',
                url: top.$.rootUrl + '/SystemModule/Module/ColumnForm',
                height: 260,
                width: 450,
                callBack: function (id) {
                    return top[id].acceptClick(function (data) {
                        $('#view_girdtable').jfGridSet('addRow', { row: data });
                    });
                }
            });
        },
        editViewForm: function () {
            currentColRow = $('#view_girdtable').jfGridGet('rowdata');
            var _id = currentColRow ? currentColRow.ModuleColumnId : '';
            if (luoluo.checkrow(_id)) {
                luoluo.layerForm({
                    id: 'viewform',
                    title: '编辑视图列',
                    url: top.$.rootUrl + '/SystemModule/Module/ColumnForm',
                    height: 260,
                    width: 450,
                    callBack: function (id) {
                        return top[id].acceptClick(function (data) {
                            $('#view_girdtable').jfGridSet('updateRow', { row: data });
                        });
                    }
                });
            }
        },
        deleteView: function () {
            var row = $('#view_girdtable').jfGridGet('rowdata');
            var _id = row ? row.ModuleColumnId : '';
            if (luoluo.checkrow(_id)) {
                luoluo.layerConfirm('是否确认删除该项！', function (res, index) {
                    if (res) {
                        $('#view_girdtable').jfGridSet('removeRow');
                        top.layer.close(index); //再执行关闭  
                    }
                });
            }
        },
        /*初始化表格*/
        initGird: function () {
            $('#btns_girdtable').jfGrid({
                headData: [
                    { label: "名称", name: "FullName", width: 160, align: "left" },
                    { label: "编号", name: "EnCode", width: 150, align: "left" },
                    { label: "地址", name: "ActionAddress", width: 350, align: "left" }
                ],
                isTree: true,
                mainId: 'ModuleButtonId',
                parentId: 'ParentId'
            });
            $('#view_girdtable').jfGrid({
                headData: [
                    { label: "名称", name: "FullName", width: 160, align: "left" },
                    { label: "编号", name: "EnCode", width: 150, align: "left" },
                    { label: "描述", name: "Description", width: 350, align: "left" }
                ]
            });
        },
        /*初始化数据*/
        initData: function () {
            if (!!keyValue) {
                $.llSetForm(top.$.rootUrl + '/SystemModule/Module/GetFormData?keyValue=' + keyValue, function (data) {//
                    $('#step-1').llSetFormData(data.moduleEntity);
                    buttonlistArray = data.moduleButtons;
                    $('#btns_girdtable').jfGridSet('refreshdata', { rowdatas: data.moduleButtons });
                    $('#view_girdtable').jfGridSet('refreshdata', { rowdatas: data.moduleColumns });
                });
            }
            else if (!!moduleId) {
                $('#F_ParentId').llselectSet(moduleId);
            }
        },
        /*保存数据*/
        save: function () {
            if (!$('#step-1').llValidform()) {
                return false;
            }
            var postData = {};
            var formdata = $('#step-1').llGetFormData(keyValue);
            if (formdata["ParentId"] == '' || formdata["ParentId"] == '&nbsp;') {
                formdata["ParentId"] = '0';
            }
            postData.keyValue = keyValue;
            postData.moduleEntityJson = JSON.stringify(formdata);
            if (formdata.F_Target != 'expand') {
                // 当为窗口和弹层时需要获取按钮和视图设置信息
                var btns = $('#btns_girdtable').jfGridGet('rowdatasByArray');
                var cols = $('#view_girdtable').jfGridGet('rowdatas');
                postData.moduleColumnListJson = JSON.stringify(cols);
                postData.moduleButtonListJson = JSON.stringify(btns);
            }
            
            $.llSaveForm(top.$.rootUrl + '/SystemModule/Module/SaveForm', postData, function (res) {
                // 保存成功后才回调
                luoluo.frameTab.currentIframe().refreshGirdData(formdata);
            });
        }
    };

    page.init();
}