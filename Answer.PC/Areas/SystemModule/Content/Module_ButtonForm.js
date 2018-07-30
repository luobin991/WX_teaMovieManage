/*
 * 日 期：2017.11.24
 * 描 述：功能按钮模块	
 */
var parentId = request('parentId');

var buttonlist = top.layer_form.buttonlist;
var currentBtnRow = top.layer_form.currentBtnRow;
var acceptClick;
var bootstrap = function ($, luoluo) {
    "use strict";

    var page = {
        init: function () {
            page.bind();
            page.initData();
        },
        bind: function () {
            // 上级
            var buttonTree = $.lltree.treeTotree(buttonlist, 'ModuleButtonId', 'FullName', 'EnCode', false, 'jfGrid_ChildRows');
            $('#ParentId').llselect({
                data: buttonTree,
                type: 'tree'
            }).llselectSet(parentId);
        },
        initData: function () {
            if (!!currentBtnRow) {
                $('#form').llSetFormData(currentBtnRow);
            }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('#form').llValidform()) {
            return false;
        }
        var data = $('#form').llGetFormData();
        if (data["ParentId"] == '' || data["ParentId"] == '&nbsp;') {
            data["ParentId"] = '0';
        }
        else if (data["ParentId"] == data['ModuleButtonId']) {
            luoluo.alert.error('上一级不能是自己本身');
            return false;
        }
        if (!!callBack) {
            callBack(data);
        }
        return true;
    };

    page.init();
}