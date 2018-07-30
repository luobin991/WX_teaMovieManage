/*
 * 日 期：2017.11.28
 * 描 述：角色管理	
 */

var acceptClick;
var keyValue = '';
var bootstrap = function ($, learun) {
    "use strict";
    var selectedRow = learun.frameTab.currentIframe().selectedRow;
    var page = {
        init: function () {
            page.initData();
        },
        initData: function () {
            if (!!selectedRow) {
                keyValue = selectedRow.F_RoleId;
                $('#form').lrSetFormData(selectedRow);
            }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('#form').lrValidform()) {
            return false;
        }
        var postData = $('#form').lrGetFormData(keyValue);
        $.lrSaveForm(top.$.rootUrl + '/SystemModule/Role/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}