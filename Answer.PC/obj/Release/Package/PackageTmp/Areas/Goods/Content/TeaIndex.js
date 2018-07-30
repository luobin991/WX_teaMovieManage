/*
 * 日 期：2017.11.16
 * 描 述：TEA管理	
 */
var selectedRow;
var refreshGirdData;
var refreshMenuData;
var bootstrap = function ($, luoluo) {
    "use strict";

    var selectedRowID = '0';
    var page = {
        init: function () {
            page.initLoadMenu();
            page.initGird();
            page.bind();
            page.search();

        },
        bind: function () {
            // 查询
            $('#btn_Search').on('click', function () {
                var keyword = $('#txt_Keyword').val();
                page.search({
                    pid: selectedRowID,
                    keyword: keyword
                });
            });
            // 刷新
            $('#ll_refresh').on('click', function () {
                location.reload();
            });

            //增加系列
            $('#ll_add_menu').on('click', function () {
                luoluo.layerForm({
                    id: 'form',
                    title: '新增系列',
                    url: top.$.rootUrl + '/Goods/Tea/Edit?id=0',
                    width: 450,
                    height: 160,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshMenuData);

                    }
                });
            });

            // 修改系列
            $('#ll_edit_menu').on('click', function () {
                if (luoluo.checkrow(selectedRowID)) {
                    luoluo.layerForm({
                        id: 'form',
                        title: '修改系列',
                        url: top.$.rootUrl + '/Goods/Tea/Edit?id=' + selectedRowID,
                        width: 450,
                        height: 160,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshMenuData);
                        }
                    });
                }
            });

            // 删除系列
            $('#ll_del_menu').on('click', function () {
                if (selectedRowID=='0') {
                    luoluo.alert.warning('请选择下面具体系列！');
                    return false;
                }
                if (luoluo.checkrow(selectedRowID)) {
                    luoluo.layerConfirm('是否要删除【' + $("#lr_left_list>li.active").html() + '】，包括旗下所有子项目！', function (res) {
                        if (res) {
                            luoluo.deleteForm(top.$.rootUrl + '/Goods/Tea/DelTeaMenu', { id: selectedRowID }, function () {
                                refreshMenuData();
                                refreshGirdData();
                            });
                        }
                    });
                }
            });


            //增加
            $('#ll_add').on('click', function () {
                if (selectedRowID == '0') {
                    luoluo.alert.warning('您没有选中任何数据项,请选中后再操作！');
                    return false;
                }
                luoluo.layerForm({
                    id: 'form',
                    title: '新增',
                    url: '/Goods/Tea/EditGoods?id=0&pid=' + selectedRowID,
                    width: 650,
                    height: 580,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });

            // 修改
            $('#ll_edit').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('id');
                if (luoluo.checkrow(keyValue)) {
                    luoluo.layerForm({
                        id: 'form',
                        title: '修改',
                        url: top.$.rootUrl + '/Goods/Tea/EditGoods?id=' + keyValue + '&pid=' + selectedRowID,
                        width: 650,
                        height: 580,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });

            // 删除
            $('#ll_del').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('id');
                if (luoluo.checkrow(keyValue)) {
                    luoluo.layerConfirm('是否要删除【' + $('#girdtable').jfGridValue('GoodsName') + '】', function (res) {
                        if (res) {
                            luoluo.deleteForm(top.$.rootUrl + '/Goods/Tea/DelGoodsTEA', { id: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 启用/有货
            $('#ll_enabled').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('id');
                if (luoluo.checkrow(keyValue)) {
                    luoluo.deleteForm(top.$.rootUrl + '/Goods/Tea/UpdateGoodsStatus', { id: keyValue, status: 1 }, function () {
                        refreshGirdData();
                    });
                }
            });
            // 禁用/售空
            $('#ll_disabled').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('id');
                if (luoluo.checkrow(keyValue)) {
                    luoluo.deleteForm(top.$.rootUrl + '/Goods/Tea/UpdateGoodsStatus', { id: keyValue, status: 0 }, function () {
                        refreshGirdData();
                    });
                }
            });


            // 绑定标签
            $('#ll_lable').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('id');
                if (luoluo.checkrow(keyValue)) {
                    luoluo.layerForm({
                        id: 'form',
                        title: '绑定标签',
                        url: top.$.rootUrl + '/Goods/Tea/BindTea_Lable?fid=' + keyValue,
                        width: 650,
                        height: 580,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });


            
        },
        //左边菜单选项
        initleft: function () {
            $('#lr_left_list li').on('click', function () {
                var $this = $(this);
                var $parent = $this.parent();
                $parent.find('.active').removeClass('active');
                $this.addClass('active');

                selectedRowID = $this.attr('data-value');

                refreshGirdData();

            });
        },
        //加载目录导航
        initLoadMenu: function () {
            luoluo.httpFAsyncGet("/Goods/Tea/GetTeaMenuList", function (data) {
                //<li class="active" data-value="1">name</li>
                var html_li = "";
                var select_Li = "";
                if (data.code == luoluo.httpCode.success) {
                    var list = data.data;

                    html_li += '<li ' + (selectedRowID == "0" ? "class=active" : "") + ' data-value="0"> 全部 </li>';
                    
                    for (var i = 0; i < list.length; i++) {
                        if (selectedRowID == list[i].id)
                            select_Li = 'class="active"';
                        else
                            select_Li = "";
                        html_li += '<li ' + select_Li + '  data-value="' + list[i].id + '">' + list[i].lableName + '</li>';
                    }
                }
                $("#lr_left_list").html(html_li);
                page.initleft();
            });
        },
        initGird: function () {
            $('#girdtable').llAuthorizeJfGrid({
                url: top.$.rootUrl + '/Goods/Tea/GetGoodsPage',
                headData: [
                        {
                            label: '展示图', name: 'imgshow', width: 100, align: 'center', title: "", formatter: function (callback, value, row) {
                                var img = value.img;
                                if (img == "")
                                    return "";
                                else {
                                    return '<img  src="' + img + '"/>';
                                }
                            }
                        },
                        { label: '名称', name: 'GoodsName', width: 100, align: 'left' },
                        { label: '价格', name: 'Price', width: 100, align: 'right', sort: true },
                        {
                            label: '状态', name: 'statusSts', width: 100, align: 'right', formatter: function (callback, value, row) {
                                if (value.status == 1 || value.status == true)
                                    return '<i class="fa fa-toggle-on"></i>';
                                else
                                    return '<i class="fa fa-toggle-off"></i>';
                            }
                        },
                       {
                           label: '标签[可调制]', name: 'lables', width: 200, align: 'center', formatter: function (cellvalue) {

                               return cellvalue;
                           }
                       },
                       { label: ' 修改时间', name: 'updateTimeStr', width: 150, align: 'center' },
                       { label: '简介', name: 'GoodsInfo', width: 500, align: 'left' },
                ],
                isPage: true,
                sidx: 'id',
                sord: 'desc',
                reloadSelected: false,
                mainId: 'id'
            });
        },
        search: function (param) {
            param = param || {};
            $('#girdtable').jfGridSet('reload', { param: param });
        }
    };

    refreshGirdData = function () {
        var keyword = $('#txt_Keyword').val();
        page.search({
            pid: selectedRowID,
            keyword: keyword
        });
    };

    refreshMenuData = function () {
        page.initLoadMenu();
    };

    page.init();
}


