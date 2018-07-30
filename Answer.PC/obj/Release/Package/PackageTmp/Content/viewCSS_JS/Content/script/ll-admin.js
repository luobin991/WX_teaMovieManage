/*
 * 日 期：2017.11.16
 * 描 述：admin顶层页面操作方法
 */

var loaddfimg;
(function ($, luoluo) {
    "use strict";
    
    var page = {
        init: function () {
            /*判断当前浏览器是否是IE浏览器*/
            if ($('body').hasClass('IE') || $('body').hasClass('InternetExplorer')) {
                $('#lr_loadbg').append('<img data-img="imgdd" src="' + top.$.rootUrl + '/Content/images/ie-loader.gif" style="position: absolute;top: 0;left: 0;right: 0;bottom: 0;margin: auto;vertical-align: middle;">');
                Pace.stop();
            }
            else {
                Pace.on('done', function () {
                    $('#lr_loadbg').fadeOut();
                    Pace.options.target = '#learunpacenone';
                });
            }

            // 通知栏插件初始化设置
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": true,
                "progressBar": false,
                "positionClass": "toast-bottom-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "3000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            };
            // 打开首页模板
            luoluo.frameTab.open({ F_ModuleId: '0', F_Icon: 'fa fa-desktop', F_FullName: '首页模板', F_UrlAddress: '/Home/AdminDesktopTemp' }, true);
            luoluo.clientdata.init(function () {
                page.userInit();
                // 初始页面特例
                bootstrap($, luoluo);
                //$.imServer.init();
                if ($('body').hasClass('IE') || $('body').hasClass('InternetExplorer')) {
                    $('#lr_loadbg').fadeOut();
                }
            });

            // 加载数据进度
            page.loadbarInit();
            // 全屏按钮
            page.fullScreenInit();
            // 主题选择初始化
            page.uitheme();
           
        },

        // 登录头像和个人设置
        userInit: function () {
            var loginInfo = luoluo.clientdata.get(['userinfo']);
            var headimg;
            if (loginInfo.gender != 0) {
                headimg = top.$.rootUrl + '/Content/images/head/on-boy.jpg';
            }
            else {
                headimg = top.$.rootUrl + '/Content/images/head/on-girl.jpg';
            }
            loaddfimg = function () {
                document.getElementById('userhead').src = headimg;
            }
            var _html = '<div class="ll-frame-personCenter"><a href="javascript:void(0);" class="dropdown-toggle" data-toggle="dropdown">';
            _html += '<img id="userhead" src="' + top.$.rootUrl + loginInfo.headIcon + '" alt="用户头像" onerror="loaddfimg()" >';
            _html += '<span>' + loginInfo.realName + '</span>';
            _html += '</a>';
            _html += '<ul class="dropdown-menu pull-right">';
            _html += '<li><a href="javascript:void(0);" id="lr_userinfo_btn"><i class="fa fa-refresh"></i>修改密码</a></li>';
            _html += '<li class="divider"></li>';
            _html += '<li><a href="javascript:void(0);" id="lr_loginout_btn"><i class="fa fa-power-off"></i>安全退出</a></li>';
            _html += '</ul></div>';
            $('body').append(_html);

            $('#lr_loginout_btn').on('click', page.loginout);
            $('#lr_userinfo_btn').on('click', page.openUserRefresh);
        },
        loginout: function () { // 安全退出
            luoluo.layerConfirm("注：您确定要安全退出本次登录吗？", function (r) {
                if (r) {
                    luoluo.loading(true, '退出系统中...');
                    luoluo.httpAsyncPost($.rootUrl + '/Login/LoginOut', {}, function (data) {
                        window.location.href = $.rootUrl + "/Login/Index";
                    });
                }
            });
        },
        openUserRefresh: function () {
            // 打开个人中心
            luoluo.frameTab.open({ F_ModuleId: '1', F_Icon: 'fa fa-refresh', F_FullName: '修改密码', F_UrlAddress: '/SystemModule/SysUser/PassWordForm' });
        },

        // 全屏按钮
        fullScreenInit: function () {
            var _html = '<div class="lr_frame_fullscreen"><a href="javascript:void(0);" id="lr_fullscreen_btn" title="全屏"><i class="fa fa-arrows-alt"></i></a></div>';
            $('body').append(_html);
            $('#lr_fullscreen_btn').on('click', function () {
                if (!$(this).attr('fullscreen')) {
                    $(this).attr('fullscreen', 'true');
                    page.requestFullScreen();
                } else {
                    $(this).removeAttr('fullscreen');
                    page.exitFullscreen();
                }
            });
        },
        requestFullScreen: function () {
            var de = document.documentElement;
            if (de.requestFullscreen) {
                de.requestFullscreen();
            } else if (de.mozRequestFullScreen) {
                de.mozRequestFullScreen();
            } else if (de.webkitRequestFullScreen) {
                de.webkitRequestFullScreen();
            }
        },
        exitFullscreen: function () {
            var de = document;
            if (de.exitFullscreen) {
                de.exitFullscreen();
            } else if (de.mozCancelFullScreen) {
                de.mozCancelFullScreen();
            } else if (de.webkitCancelFullScreen) {
                de.webkitCancelFullScreen();
            }
        },

        // 加载数据进度
        loadbarInit: function () {
            var _html = '<div class="ll-loading-bar" id="lr_loading_bar" >';
            _html += '<div class="ll-loading-bar-bg"></div>';
            _html += '<div class="ll-loading-bar-message" id="lr_loading_bar_message"></div>';
            _html += '</div>';
            $('body').append(_html);
        },

        // 皮肤主题设置
        uitheme: function () {
            var uitheme = top.$.cookie('L2017_UItheme') || '1';
            var $setting = $('<div class="ll-theme-setting"></div>');
            var $btn = $('<button class="btn btn-default"><i class="fa fa-spin fa-gear"></i></button>');
            var _html = '<div class="panel-heading">界面风格</div>';
            _html += '<div class="panel-body">';
            _html += '<div><label><input type="radio" name="ui_theme" value="1" ' + (uitheme == '1' ? 'checked' : '') + '>经典版</label></div>';
            _html += '<div><label><input type="radio" name="ui_theme" value="2" ' + (uitheme == '2' ? 'checked' : '') + '>风尚版</label></div>';
            _html += '<div><label><input type="radio" name="ui_theme" value="3" ' + (uitheme == '3' ? 'checked' : '') + '>炫动版</label></div>';
            _html += '<div><label><input type="radio" name="ui_theme" value="4" ' + (uitheme == '4' ? 'checked' : '') + '>飞扬版</label></div>';
            _html += '</div>';
            $setting.append($btn);
            $setting.append(_html);
            $('body').append($setting);

            $btn.on('click', function () {
                var $parent = $(this).parent();
                if ($parent.hasClass('opened')) {
                    $parent.removeClass('opened');
                }
                else {
                    $parent.addClass('opened');
                }
            });
            $setting.find('input').click(function () {
                var value = $(this).val();
                top.$.cookie('L2017_UItheme', value, { path: "/" });
                window.location.href = $.rootUrl + '/Home/Index';
            });

        },
    };

    $(function () {
        page.init();
    });
})(window.jQuery, top.luoluo);
