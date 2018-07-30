/*
 * 日 期：2017.11.23
 * 描 述：账号添加	
 */
var acceptClick;
var keyValue = '';
var bootstrap = function ($, luoluo) {
    "use strict";
    var selectedRow = luoluo.frameTab.currentIframe().selectedRow;

    // 保存数据
    acceptClick = function (callBack) {
        if (!$('#form').llValidform()) {
            return false;
        }
        var postData = $('#form').llGetFormData(keyValue);
        postData.UserPassWord = $.md5(postData.UserPassWord);

        $.llSaveForm(top.$.rootUrl + '/SystemModule/SysUser/SaveForm', postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
}