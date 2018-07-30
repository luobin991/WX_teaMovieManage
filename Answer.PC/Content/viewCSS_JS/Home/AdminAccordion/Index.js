/*
 * 日 期：2017.11.16
 * 描 述：手风琴风格皮肤	
 */
var bootstrap = function ($, luoluo) {
    "use strict";

    // 菜单操作
    var meuns = {
        init: function () {
            this.load();
            this.bind();
        },
        load: function () {
            var modulesTree = luoluo.clientdata.get(['modulesTree']);
            // 第一级菜单
            var parentId = '0';
            var modules = modulesTree[parentId] || [];
            var $firstmenus = $('<ul class="ll-first-menu-list"></ul>');
            for (var i = 0, l = modules.length; i < l; i++) {
                var item = modules[i];
                if (item.F_IsMenu == 1) {
                    var $firstMenuItem = $('<li></li>');
                    if (!!item.F_Description) {
                        $firstMenuItem.attr('title', item.F_Description);
                    }
                    var menuItemHtml = '<a id="' + item.F_ModuleId + '" href="javascript:void(0);" class="ll-menu-item">';
                    menuItemHtml += '<i class="' + item.F_Icon + ' ll-menu-item-icon"></i>';
                    menuItemHtml += '<span class="ll-menu-item-text">' + item.F_FullName + '</span>';
                    menuItemHtml += '<span class="ll-menu-item-arrow"><i class="fa fa-angle-left"></i></span></a>';
                    $firstMenuItem.append(menuItemHtml);
                    // 第二级菜单
                    var secondModules = modulesTree[item.F_ModuleId] || [];
                    var $secondMenus = $('<ul class="ll-second-menu-list"></ul>');
                    var secondMenuHad = false;
                    for (var j = 0, sl = secondModules.length ; j < sl; j++) {
                        var secondItem = secondModules[j];
                        if (secondItem.F_IsMenu == 1) {
                            secondMenuHad = true;
                            var $secondMenuItem = $('<li></li>');
                            if (!!secondItem.F_Description) {
                                $secondMenuItem.attr('title', secondItem.F_Description);
                            }
                            var secondItemHtml = '<a id="' + secondItem.F_ModuleId + '" href="javascript:void(0);" class="ll-menu-item" >';
                            secondItemHtml += '<i class="' + secondItem.F_Icon + ' ll-menu-item-icon"></i>';
                            secondItemHtml += '<span class="ll-menu-item-text">' + secondItem.F_FullName + '</span>';
                            secondItemHtml += '</a>';

                            $secondMenuItem.append(secondItemHtml);
                            // 第三级菜单
                            var threeModules = modulesTree[secondItem.F_ModuleId] || [];
                            var $threeMenus = $('<ul class="ll-three-menu-list"></ul>');
                            var threeMenuHad = false;
                            for (var m = 0, tl = threeModules.length ; m < tl; m++) {
                                var threeItem = threeModules[m];
                                if (threeItem.F_IsMenu == 1) {
                                    threeMenuHad = true;
                                    var $threeMenuItem = $('<li></li>');
                                    $threeMenuItem.attr('title', threeItem.F_FullName);
                                    var threeItemHtml = '<a id="' + threeItem.F_ModuleId + '" href="javascript:void(0);" class="ll-menu-item" >';
                                    threeItemHtml += '<i class="' + threeItem.F_Icon + ' ll-menu-item-icon"></i>';
                                    threeItemHtml += '<span class="ll-menu-item-text">' + threeItem.F_FullName + '</span>';
                                    threeItemHtml += '</a>';
                                    $threeMenuItem.append(threeItemHtml);
                                    $threeMenus.append($threeMenuItem);
                                }
                            }
                            if (threeMenuHad) {
                                $secondMenuItem.addClass('ll-meun-had');
                                $secondMenuItem.find('a').append('<span class="ll-menu-item-arrow"><i class="fa fa-angle-left"></i></span>');
                                $secondMenuItem.append($threeMenus);
                            }
                            $secondMenus.append($secondMenuItem);
                        }
                    }
                    if (secondMenuHad) {
                        $firstMenuItem.append($secondMenus);
                    }
                    $firstmenus.append($firstMenuItem);
                }
            }
            $('#lr_frame_menu').html($firstmenus);
        },
        bind: function () {
            $("#lr_frame_menu").mCustomScrollbar({ // 优化滚动条
                theme: "minimal-dark"
            });

            $('#lr_frame_menu_btn').on('click', function () {
                var $body = $('body');
                if ($body.hasClass('ll-menu-closed')) {
                    $body.removeClass('ll-menu-closed');
                }
                else {
                    $body.addClass('ll-menu-closed');
                }
            });

            $('#lr_frame_menu a').hover(function () {
                if ($('body').hasClass('ll-menu-closed')) {
                    var id = $(this).attr('id');
                    var text = $('#' + id + '>span').text();
                    layer.tips(text, $(this));
                }
            }, function () {
                if ($('body').hasClass('ll-menu-closed')) {
                    layer.closeAll('tips');
                }
            });

            $('.ll-frame-personCenter .dropdown-toggle').hover(function () {
                if ($('body').hasClass('ll-menu-closed')) {
                    var text = $(this).text();
                    layer.tips(text, $(this));
                }
            }, function () {
                if ($('body').hasClass('ll-menu-closed')) {
                    layer.closeAll('tips');
                }
            });


            // 添加点击事件
            $('#lr_frame_menu a').on('click', function () {
                var $obj = $(this);
                var id = $obj.attr('id');
                var _module = luoluo.clientdata.get(['modulesMap', id]);
                switch (_module.F_Target) {
                    case 'iframe':// 窗口
                        if (luoluo.validator.isNotNull(_module.F_UrlAddress).code) {
                            luoluo.frameTab.open(_module);
                        }
                        else {

                        }
                        break;
                    case 'expand':// 打开子菜单
                        var $ul = $obj.next();
                        if ($ul.is(':visible')) {
                            $ul.slideUp(500, function () {
                                $obj.removeClass('open');
                            });
                        }
                        else {
                            if ($ul.hasClass('ll-second-menu-list')) {
                                $('#lr_frame_menu .ll-second-menu-list').slideUp(300, function () {
                                    $(this).prev().removeClass('open');
                                });
                            }
                            else {
                                $ul.parents('.ll-second-menu-list').find('.ll-three-menu-list').slideUp(300, function () {
                                    $(this).prev().removeClass('open');
                                });
                            }
                            $ul.slideDown(300, function () {
                                $obj.addClass('open');
                            });
                        }
                        break;
                }
            });
        }
    };
    meuns.init();
};