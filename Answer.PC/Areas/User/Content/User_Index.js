/*
 * 日 期：2017.11.16
 * 描 述：人员管理	
 */
var selectedRow;
var refreshGirdData;
var bootstrap = function ($, luoluo) {
    "use strict";
    var companyId = '';
    var departmentId = '';

    var page = {
        init: function () {
            //page.inittree();
            page.initGird();
            page.bind();
            page.search();

        },
        bind: function () {
            // 查询
            $('#btn_Search').on('click', function () {
                var keyword = $('#txt_Keyword').val();
                var sdate = $('#sdate').val();
                var edate = $('#edate').val();
                page.search({
                    keyword: keyword,
                    sdate: sdate,
                    edate: edate,
                });
            });
            // 刷新
            $('#ll_refresh').on('click', function () {
                location.reload();
            });
            //查询战绩
            $('#ll_playlog').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('userId');
                if (luoluo.checkrow(keyValue)) {
                    luoluo.layerForm({
                        id: 'form',
                        title: $('#girdtable').jfGridValue('nickName') + '的战绩',
                        url: top.$.rootUrl + '/DataStatistics/GameLog/Index?id=' + keyValue,
                        width: 1660,
                        height: 850,
                        btn: null
                    });
                }
            });
            //充/扣 钻石
            $('#ll_chargebuckle').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('userId');
                if (luoluo.checkrow(keyValue)) {
                    luoluo.layerForm({
                        id: 'form',
                        title: '冲扣钻石' + '->' + $('#girdtable').jfGridValue('nickName'),
                        url: top.$.rootUrl + '/User/User/CKfangka?id=' + keyValue,
                        width: 450,
                        height: 320,
                        callBack: function (id) {
                            //top.layer.closeAll();//再执行关闭  
                            return top[id].acceptClick(refreshGirdData);

                        }
                    });
                }
            });
            //启用账户
            $('#ll_enabled').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('userId');
                if (luoluo.checkrow(keyValue)) {
                    luoluo.layerConfirm('是否确认要【启用】账号！', function (res) {
                        if (res) {
                            luoluo.postForm(top.$.rootUrl + '/User/User/UpdateState', { keyValue: keyValue, state: 0 }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 冻结
            $('#ll_disabled').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('userId');
                if (luoluo.checkrow(keyValue)) {
                    luoluo.layerConfirm('是否确认要【禁用】账号！', function (res) {
                        if (res) {
                            luoluo.postForm(top.$.rootUrl + '/User/User/UpdateState', { keyValue: keyValue, state: 1 }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });

            // 直升代理
            $('#ll_upagent').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('userId');
                if (luoluo.checkrow(keyValue)) {
                    luoluo.layerConfirm('是否确认要升级【' + $('#girdtable').jfGridValue('nickName') + '】为代理！', function (res) {
                        if (res) {
                            luoluo.postForm(top.$.rootUrl + '/ClubModule/Agent/SetUserforAgent', { userid: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
        },
        initGird: function () {
            $('#girdtable').llAuthorizeJfGrid({
                url: top.$.rootUrl + '/User/User/GetPageList',
                headData: [
                        { label: '玩家称呼', name: 'nickName', width: 100, align: 'center' },
                        { label: '玩家账号', name: 'phoneNum', width: 100, align: 'center' },
                        {
                            label: '绑定的推荐码', name: 'inviteCode', width: 100, align: 'center', formatter: function (callback) {
                                if (callback == 0)
                                    return '';
                                else
                                    return callback;
                            }
                        },
                        //{
                        //    label: '性别', name: 'sex', width: 50, align: 'center', formatter: function (callback) {
                        //        if (callback == 1)
                        //            return "男";
                        //        else
                        //            return "女";
                        //    }
                        //},
                        { label: '注册时间', name: 'registerTime', width: 200, align: 'center', sort: true },
                        { label: '注册IP', name: 'registerIp', width: 150, align: 'center' },
                        { label: '登录时间', name: 'loginTime', width: 200, align: 'center', sort: true },
                        { label: '登录IP', name: 'loginIp', width: 150, align: 'center', formatter: function (callback, value, row) { return value.loginIp; } },
                        { label: '钻石数量', name: 'diamond', width: 100, align: 'right', sort: true },
                        { label: ' 已玩局数', name: 'roundNum', width: 100, align: 'right', sort: true },
                        {
                            label: ' 是否冻结', name: 'isFrozen', width: 100, align: 'center', sort: true, formatter: function (callback) {
                                if (callback == 1)
                                    return '<i class="fa fa-toggle-on"></i>';
                                else
                                    return '<i class="fa fa-toggle-off"></i>';
                            }
                        },
                           {
                               label: ' 是否代理', name: 'isProxy', width: 100, align: 'center', sort: true, formatter: function (callback) {
                                   if (callback == 1)
                                       return '<i class="fa fa-toggle-on"></i>';
                                   else
                                       return '<i class="fa fa-toggle-off"></i>';
                               }
                           },
                       { label: ' 登录的地理位置', name: 'loginAddress', width: 300, align: 'left' }

                ],
                isPage: true,
                sidx: 'loginTime',
                sord: 'desc',
                reloadSelected: false,
                mainId: 'phone_number'
            });
        },
        search: function (param) {
            param = param || {};
            $('#girdtable').jfGridSet('reload', { param: param });
        }
    };

    refreshGirdData = function () {
        var keyword = $('#txt_Keyword').val();
        var sdate = $('#sdate').val();
        var edate = $('#edate').val();
        page.search({
            keyword: keyword,
            sdate: sdate,
            edate: edate,
        });
    };

    page.init();
}


