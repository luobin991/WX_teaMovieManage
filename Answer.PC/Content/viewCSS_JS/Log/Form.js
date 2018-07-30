/*
 * 日 期：2017.12.11
 * 描 述：清空日志管理	
 */
var categoryId = request('categoryId');
var acceptClick;
var bootstrap = function ($, luoluo) {
    "use strict";

    var page = {
        init: function () {
            $('#keepTime').llselect({maxHeight:75,placeholder:false}).llselectSet(7);
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('#form').llValidform()) {
            return false;
        }
        var postData = $('#form').llGetFormData();
        postData['categoryId'] = categoryId;
        $.llSaveForm(top.$.rootUrl + '/Log/SaveRemoveLog', postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}