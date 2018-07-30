/*
 * 日 期：2017.11.23
 * 描 述：账号添加	
 */
var acceptClick;
var keyValue = '';
var bootstrap = function ($, learun) {
    "use strict";
    var selectedRow = learun.frameTab.currentIframe().selectedRow;

    // 保存数据
    acceptClick = function (callBack) {
        if (!$('#form').lrValidform()) {
            return false;
        }
        var postData = $('#form').lrGetFormData(keyValue);
        postData.UserPassWord = $.md5(postData.UserPassWord);

        $.lrSaveForm(top.$.rootUrl + '/SystemModule/SysUser/SaveForm', postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
}