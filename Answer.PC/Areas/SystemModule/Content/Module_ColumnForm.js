/*
 * 日 期：2017.11.24
 * 描 述：功能视图模块	
 */
var currentColRow = top.layer_form.currentColRow;
var acceptClick;
var bootstrap = function ($, luoluo) {
    "use strict";

    var page = {
        init: function () {
            page.initData();
        },
        initData: function () {
            if (!!currentColRow) {
                $('#form').llSetFormData(currentColRow);
            }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('#form').llValidform()) {
            return false;
        }
        var data = $('#form').llGetFormData();
        data.F_ParentId = '0';
        if (!!callBack) {
            callBack(data);
        }
        return true;
    };
    page.init();
}