/*
 * 日 期：2017.11.16
 * 描 述：tab窗口操作方法
 */
(function ($, luoluo) {
    "use strict";
    //初始化菜单和tab页的属性Id
    var iframeIdList = {};

    luoluo.frameTab = {
        iframeId: '',
        init: function () {
            luoluo.frameTab.bind();
        },
        bind: function () {
            $(".ll-frame-tabs-wrap").mCustomScrollbar({ // 优化滚动条
                axis: "x",
                theme: "minimal-dark"
            });
           
        },
        setCurrentIframeId: function (iframeId) {
            luoluo.iframeId = iframeId;
        },
        open: function (module, notAllowClosed) {
            var $tabsUl = $('#lr_frame_tabs_ul');
            var $frameMain = $('#lr_frame_main');

            if (iframeIdList[module.F_ModuleId] == undefined || iframeIdList[module.F_ModuleId] == null) {
                // 隐藏之前的tab和窗口
                if (luoluo.frameTab.iframeId != '') {
                    $tabsUl.find('#lr_tab_' + luoluo.frameTab.iframeId).removeClass('active');
                    $frameMain.find('#lr_iframe_' + luoluo.frameTab.iframeId).removeClass('active');
                    iframeIdList[luoluo.frameTab.iframeId] = 0;
                }
                luoluo.frameTab.iframeId = module.F_ModuleId;
                iframeIdList[luoluo.frameTab.iframeId] = 1;
                // 打开一个功能模块tab_iframe页面
                var $tabItem = $('<li class="ll-frame-tabItem active" id="lr_tab_' + module.F_ModuleId + '" ><span><i class="' + module.F_Icon + '"></i>&nbsp;' + module.F_FullName + '</span></li>');
                if (!notAllowClosed) {
                    $tabItem.append('<span class="reomve" title="关闭窗口"></span>');
                }
                var $iframe = $('<iframe class="ll-frame-iframe active" id="lr_iframe_' + module.F_ModuleId + '" frameborder="0" src="' + $.rootUrl + module.F_UrlAddress + '"></iframe>');
                $tabsUl.append($tabItem);
                $frameMain.append($iframe);

                $(".ll-frame-tabs-wrap").mCustomScrollbar("update");
                $(".ll-frame-tabs-wrap").mCustomScrollbar("scrollTo", $tabItem);

                //绑定一个点击事件
                $tabItem.on('click', function () {
                    var id = $(this).attr('id').replace('lr_tab_', '');
                    luoluo.frameTab.focus(id);
                });
                $tabItem.find('.reomve').on('click', function () {
                    var id = $(this).parent().attr('id').replace('lr_tab_', '');
                    luoluo.frameTab.close(id);
                    return false;
                });

                if (!!luoluo.frameTab.opencallback) {
                    luoluo.frameTab.opencallback();
                }
                if (!notAllowClosed) {
                    $.ajax({
                        url: top.$.rootUrl + "/Home/VisitModule",
                        data: { moduleName: module.F_FullName, moduleUrl: module.F_UrlAddress },
                        type: "post",
                        dataType: "text"
                    });
                }
            }
            else {
                luoluo.frameTab.focus(module.F_ModuleId);
            }
        },
        focus: function (moduleId) {
            if (iframeIdList[moduleId] == 0) {
                // 定位焦点tab页
                $('#lr_tab_' + luoluo.frameTab.iframeId).removeClass('active');
                $('#lr_iframe_' + luoluo.frameTab.iframeId).removeClass('active');
                iframeIdList[luoluo.frameTab.iframeId] = 0;

                $('#lr_tab_' + moduleId).addClass('active');
                $('#lr_iframe_' + moduleId).addClass('active');
                luoluo.frameTab.iframeId = moduleId;
                iframeIdList[moduleId] = 1;

                $(".ll-frame-tabs-wrap").mCustomScrollbar("scrollTo", $('#lr_tab_' + moduleId));

                if (!!luoluo.frameTab.opencallback) {
                    luoluo.frameTab.opencallback();
                }
            }
        },
        leaveFocus: function () {
            $('#lr_tab_' + luoluo.frameTab.iframeId).removeClass('active');
            $('#lr_iframe_' + luoluo.frameTab.iframeId).removeClass('active');
            iframeIdList[luoluo.frameTab.iframeId] = 0;
            luoluo.frameTab.iframeId = '';
        },
        close: function (moduleId) {
            delete iframeIdList[moduleId];

            var $this = $('#lr_tab_' + moduleId);
            var $prev = $this.prev();// 获取它的上一个节点数据;
            if ($prev.length < 1) {
                $prev = $this.next();
            }
            $this.remove();
            $('#lr_iframe_' + moduleId).remove();
            if (moduleId == luoluo.frameTab.iframeId && $prev.length > 0) {
                var prevId = $prev.attr('id').replace('lr_tab_', '');

                $prev.addClass('active');
                $('#lr_iframe_' + prevId).addClass('active');
                luoluo.frameTab.iframeId = prevId;
                iframeIdList[prevId] = 1;

                $('.ll-frame-tabs').css('width', '10000px');
                $(".ll-frame-tabs-wrap").mCustomScrollbar("update");
                $('.ll-frame-tabs').css('width', '100%');
                $(".ll-frame-tabs-wrap").mCustomScrollbar("scrollTo", $prev);
            }
            else {
                if ($prev.length < 1) {
                    luoluo.frameTab.iframeId = "";
                }
                $('.ll-frame-tabs').css('width', '10000px');
                $(".ll-frame-tabs-wrap").mCustomScrollbar("update");
                $('.ll-frame-tabs').css('width', '100%');
            }

            if (!!luoluo.frameTab.closecallback) {
                luoluo.frameTab.closecallback();
            }
        }
        // 获取当前窗口
        , currentIframe: function () {
            var ifameId = 'lr_iframe_' + luoluo.frameTab.iframeId;
            if (top.frames[ifameId].contentWindow != undefined) {
                return top.frames[ifameId].contentWindow;
            }
            else {
                return top.frames[ifameId];
            }
        }

        , opencallback: false
        , closecallback: false
    };

    luoluo.frameTab.init();
})(window.jQuery, top.luoluo);
