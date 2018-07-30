/*
 * 日 期：2017.04.05
 * 描 述：功能模块	
 */
var objectId = request('objectId');
var objectType = request('objectType');

var bootstrap = function ($, luoluo) {
    "use strict";

    var selectData;

    var treeData;
    var checkModuleIds = [];
    var checkButtonIds = [];

    function setTreeData() {
        if (!!selectData) {
            $('#step-1').lltreeSet('setCheck', selectData.modules);
            $('#step-2').lltreeSet('setCheck', selectData.buttons);
            $('#step-3').lltreeSet('setCheck', selectData.columns);
        }
        else {
            setTimeout(setTreeData,100);
        }
    }

    var page = {
        init: function () {
            page.bind();
            page.initData();
        },
        /*绑定事件和初始化控件*/
        bind: function () {
            luoluo.httpAsyncGet(top.$.rootUrl + '/SystemModule/Module/GetCheckTree', function (res) {
                if (res.code == 200) {
                    
                    treeData = res.data;
                    setTimeout(function () {
                        $('#step-1').lltree({
                            data: treeData.moduleList
                        });
                    }, 10);
                    setTimeout(function () {
                        $('#step-2').lltree({
                            data: treeData.buttonList
                        });
                    }, 30);
                    setTimeout(function () {
                        $('#step-3').lltree({
                            data: treeData.columnList
                        });
                        if (!!objectId) {
                            setTreeData();
                        }
                    }, 50);
                }
            });
            // 加载导向
            $('#wizard').wizard().on('change', function (e, data) {
                var $finish = $("#btn_finish");
                var $next = $("#btn_next");
                if (data.direction == "next") {
                    if (data.step == 1) {
                        checkModuleIds = $('#step-1').lltreeSet('getCheckNodeIds');
                        $('#step-2 .ll-tree-root [id$="_luo_moduleId"]').parent().hide();
                        $('#step-3 .ll-tree-root [id$="_luo_moduleId"]').parent().hide();
                        $.each(checkModuleIds, function (id, item) {
                            $('#step-2_' + item.replace(/-/g, '_') + '_luo_moduleId').parent().show();
                            $('#step-3_' + item.replace(/-/g, '_') + '_luo_moduleId').parent().show();
                        });
                    } else if (data.step == 2) {
                        checkButtonIds = $('#step-2').lltreeSet('getCheckNodeIds');
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
            // 保存数据按钮
            $("#btn_finish").on('click', page.save);
        },
        /*初始化数据*/
        initData: function () {
            if (!!objectId) {
                $.llSetForm(top.$.rootUrl + '/AuthorizeModule/Authorize/GetFormData?objectId=' + objectId, function (data) {//
                    selectData = data;
                });
            }
        },
        /*保存数据*/
        save: function () {
            var buttonList = [],columnList=[];
            var checkColumnIds = $('#step-3').lltreeSet('getCheckNodeIds');
            $.each(checkButtonIds, function (id, item) {
                if (item.indexOf('_luo_moduleId') == -1)
                {
                    buttonList.push(item);
                }
            });
            $.each(checkColumnIds, function (id, item) {
                if (item.indexOf('_luo_moduleId') == -1) {
                    columnList.push(item);
                }
            });


            var postData = {
                objectId: objectId,
                objectType: objectType,
                strModuleId: String(checkModuleIds),
                strModuleButtonId: String(buttonList),
                strModuleColumnId: String(columnList)
            };

            $.llSaveForm(top.$.rootUrl + '/AuthorizeModule/Authorize/SaveForm', postData, function (res) { });
        }
    };

    page.init();
}