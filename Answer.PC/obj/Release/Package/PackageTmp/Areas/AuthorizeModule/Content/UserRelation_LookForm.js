/*
 * 日 期：2017.11.30
 * 描 述：成员添加
 */
var objectId = request('objectId');

var bootstrap = function ($, luoluo) {
    "use strict";

    var page = {
        init: function () {
            page.bind();
            page.initData();
        },
        bind: function () {
            // 滚动条
            $('#user_list_warp').mCustomScrollbar({ // 优化滚动条
                theme: "minimal-dark"
            });
        },
        initData: function () {
            $.llSetForm(top.$.rootUrl + '/AuthorizeModule/UserRelation/GetUserIdList?objectId=' + objectId, function (data) {
                if (data.userIds == "") {
                    return false;
                }
                var $warp = $('#user_list');
                var userlistselectedobj = {};
                $.each(data.userInfoList, function (id, item) {
                    userlistselectedobj[item.Id] = item;
                });
                var userList = data.userIds.split(',');
                for (var i = 0, l = userList.length; i < l; i++) {
                    var userId = userList[i];
                    var item = userlistselectedobj[userId];
                    if (!!item) {
                        var imgName = "UserCard02.png";
                        //if (item.F_Gender == 0) {
                        //    imgName = "UserCard01.png";
                        //}
                        var UserType = "超级管理员";
                        if (item.UserType != 1007001) {
                            UserType = "普通管理员";
                        }

                        var _cardbox = "";
                        _cardbox += '<div class="card-box active " data-value="' + item.Id + '" >';
                        _cardbox += '    <div class="card-box-img">';
                        _cardbox += '        <img src="' + top.$.rootUrl + '/Content/images/' + imgName + '" />';
                        _cardbox += '    </div>';
                        _cardbox += '    <div class="card-box-content">';
                        _cardbox += '        <p>用户：' + item.UserName + '</p>';
                        _cardbox += '        <p>姓名：' + item.UserNickName + '</p>';
                        _cardbox += '        <p>类型：' + UserType + '</p>';
                        _cardbox += '    </div>';
                        _cardbox += '</div>';

                        $warp.append(_cardbox);
                    }
                }
            });
        }
    };
    page.init();
}