/*
 * 日 期：2017.11.24
 * 描 述：功能按钮模块	
 */
var parentId = request('parentId');

var buttonlist = top.layer_form.buttonlist;
var currentBtnRow = top.layer_form.currentBtnRow;
var acceptClick;
var bootstrap = function ($, learun) {
    "use strict";

    var page = {
        init: function () {
            page.bind();
            page.initData();
        },
        bind: function () {
            // 上级
            var buttonTree = $.lrtree.treeTotree(buttonlist, 'ModuleButtonId', 'FullName', 'EnCode', false, 'jfGrid_ChildRows');
            $('#ParentId').lrselect({
                data: buttonTree,
                type: 'tree'
            }).lrselectSet(parentId);
        },
        initData: function () {
            if (!!currentBtnRow) {
                $('#form').lrSetFormData(currentBtnRow);
            }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('#form').lrValidform()) {
            return false;
        }
        var data = $('#form').lrGetFormData();
        if (data["ParentId"] == '' || data["ParentId"] == '&nbsp;') {
            data["ParentId"] = '0';
        }
        else if (data["ParentId"] == data['ModuleButtonId']) {
            learun.alert.error('上一级不能是自己本身');
            return false;
        }
        if (!!callBack) {
            callBack(data);
        }
        return true;
    };

    page.init();
}