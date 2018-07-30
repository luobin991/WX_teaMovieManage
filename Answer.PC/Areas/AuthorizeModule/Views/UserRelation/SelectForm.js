/*
 * 日 期：2017.11.30
 * 描 述：成员添加
 */
var objectId = request('objectId');
var category = request('category');

//var companyId = request('companyId');
//var departmentId = request('departmentId');

var acceptClick;
var bootstrap = function ($, learun) {
    "use strict";


    var userlist = {};
    var userlistselected = [];
    var userlistselectedobj = {};

    // 渲染用户列表
    function renderUserlist(list) {
        
        var $warp = $('<div></div>');
        for (var i = 0, l = list.length; i < l; i++) {
            var item = list[i];
            var active = "";
            //男： UserCard02.png  女：UserCard01.png
            var imgName = "UserCard02.png";
            //if (item.F_Gender == 0) {
            //    imgName = "UserCard01.png";
            //}
            var UserType = "超级管理员";
            if (item.UserType != 1007001) {
                UserType = "普通管理员";
            }

            if (userlistselected.indexOf(item.id) != -1) {
                active = "active";
            }

            var _cardbox = "";
            _cardbox += '<div class="card-box ' + active + '" data-value="' + item.Id + '" >';
            _cardbox += '    <div class="card-box-img">';
            _cardbox += '        <img src="' + top.$.rootUrl + '/Content/images/' + imgName + '" />';
            _cardbox += '    </div>';
            _cardbox += '    <div class="card-box-content">';
            _cardbox += '        <p>用户：' + item.UserName + '</p>';
            _cardbox += '        <p>姓名：' + item.UserNickName + '</p>';
            _cardbox += '        <p>类型：' + UserType + '</p>';
            _cardbox += '    </div>';
            _cardbox += '</div>';            var $cardbox = $(_cardbox);            $cardbox[0].userinfo = item;            $warp.append($cardbox);
            //learun.clientdata.getAsync('department', {
            //    key: 0,
            //    companyId: 0,
            //    callback: function (_data) {
            //        $warp.find('[data-id="' + _data.F_DepartmentId + '"]').text(_data.F_FullName);
            //    }
            //});
        }
        $warp.find('.card-box').on('click', function () {
            var $this = $(this);
            var userid = $this.attr('data-value');
            if ($this.hasClass('active')) {
                $this.removeClass('active');
                removeUser(userid);
                userlistselected.splice(userlistselected.indexOf(userid), 1);
            }
            else {
                $this.addClass('active');
                userlistselectedobj[userid] = $this[0].userinfo;
                userlistselected.push(userid);
                addUser($this[0].userinfo);
            }
        });

        $('#user_list').html($warp);
    };

    function addUser(useritem) {
        var $warp = $('#selected_user_list');
        var _html = '<div class="user-selected-box" data-value="' + useritem.Id + '" >';
        _html += '<p>' + useritem.UserNickName + '</p>';
        _html += '<span class="user-reomve" title="移除选中人员"></span>';
        _html += '</div>';
        $warp.append(_html);
    };
    function removeUser(userid) {
        var $warp = $('#selected_user_list');
        $warp.find('[data-value="' + userid + '"]').remove();
    };

    var page = {
        init: function () {
            page.bind();
            page.initData();
        },
        bind: function () {
            // 部门
            //$('#department_tree').lrtree({
            //    nodeClick: function (item) {
            //        departmentId = item.id;
            //        if (!!userlist[item.id]) {
            //            renderUserlist(userlist[item.id]);
            //        }
            //        else {
            //            learun.httpAsync('GET', top.$.rootUrl + '/LR_OrganizationModule/User/GetList', { companyId: companyId, departmentId: departmentId }, function (data) {
            //                userlist[item.id] = data || [];
            //                renderUserlist(userlist[item.id]);
            //            });
            //        }
            //    }
            //});
            //// 公司
            //$('#company_select').lrCompanySelect().bind('change', function () {
            //    companyId = $(this).lrselectGet();
            //    $('#department_tree').lrtreeSet('refresh', {
            //        url: top.$.rootUrl + '/LR_OrganizationModule/Department/GetTree',
            //        // 访问数据接口参数
            //        param: { companyId: companyId, parentId: '0' },
            //    });
            //});
            // 已选人员按钮
            $('#user_selected_btn').on('click', function () {
                $('#form_warp_right').animate({ right: '0px' }, 500);
            });
            $('#user_selected_btn_close').on('click', function () {
                $('#form_warp_right').animate({ right: '-180px' }, 300);
            });
            // 搜索
            $("#txt_keyword").keydown(function (event) {
                if (event.keyCode == 13) {
                    var keyword = $(this).val();
                    if (keyword != "") {
                        learun.httpAsync('GET', top.$.rootUrl + '/SystemModule/SysUser/GetList', { keyword: keyword }, function (data) {
                            renderUserlist(data || []);
                        });
                    }
                }
            });

            // 选中人员按钮点击事件
            $('#selected_user_list').on('click', function (e) {
                
                var et = e.target || e.srcElement;
                var $et = $(et);
                if ($et.hasClass('user-reomve')) {
                    var userid = $et.parent().attr('data-value');
                    removeUser(userid);
                    userlistselected.splice(userlistselected.indexOf(userid), 1);
                    $('#user_list').find('[data-value="' + userid + '"]').removeClass('active');
                }
            });

            // 滚动条
            $('#user_list_warp').mCustomScrollbar({ // 优化滚动条
                theme: "minimal-dark"
            });
            $('#selected_user_list_warp').mCustomScrollbar({ // 优化滚动条
                theme: "minimal-dark"
            });
        },
        initData: function () {
            //if (!!companyId) {
            //    $('#company_select').lrselectSet(companyId);
            //}
            //if (!!departmentId) {
            //    $('#department_tree').lrtreeSet('setValue', departmentId);
            //}

            $.lrSetForm(top.$.rootUrl + '/AuthorizeModule/UserRelation/GetUserIdList?objectId=' + objectId, function (data) {
                if (data.userIds == "") {
                    return false;
                }
                var $warp = $('#selected_user_list');
                $.each(data.userInfoList, function (id, item) {
                    userlistselectedobj[item.Id] = item;
                });
                var userList = data.userIds.split(',');
                for (var i = 0, l = userList.length; i < l; i++) {
                    var userId = userList[i];
                    var item = userlistselectedobj[userId];

                    if (!!item) {
                        if (userlistselected.indexOf(userId) == -1) {
                            userlistselected.push(userId);
                        }

                        var _html = '<div class="user-selected-box" data-value="' + item.Id + '" >';
                        _html += '<p>' + item.UserNickName + '</p>';
                        _html += '<span class="user-reomve" title="移除选中人员"></span>';
                        _html += '</div>';
                        $warp.append($(_html));
                        $('#user_list').find('[data-value="' + userId + '"]').addClass('active');
                    }
                }
            });

            learun.httpAsync('GET', top.$.rootUrl + '/SystemModule/SysUser/GetList', { keyword: "" }, function (data) {
                renderUserlist(data || []);
            });
        }
    };
    // 保存数据
    acceptClick = function () {
        $.lrSaveForm(top.$.rootUrl + '/AuthorizeModule/UserRelation/SaveForm', { objectId: objectId, category: category, userIds: String(userlistselected) }, function (res) { });
        return true;
    };
    page.init();
}