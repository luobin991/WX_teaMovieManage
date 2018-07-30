/*
 * 日 期：2017.11.16
 * 描 述：权限验证模块
 */
(function ($, luoluo) {
    "use strict";

    $.fn.llAuthorizeJfGrid = function (op) {
        var _headData = [];
        $.each(op.headData, function (id, item) {
            //表数据列
            if (!!lrMouduleColumnList[item.name.toLowerCase()]) {
                _headData.push(item);
            }
            _headData.push(item);
        });
        op.headData = _headData;
        $('#girdtable').jfGrid(op);
    }

    $(function () {
        var $container = $('[luoluo-authorize="yes"]');
        $container.find('[id]').each(function () {
            var $this = $(this);
            var id = $this.attr('id');
            //按钮控制
            if (!lrMouduleButtonList[id]) {
                $this.remove();
            }
        });
        $container.find('.dropdown-menu').each(function () {
            var $this = $(this);
            if ($this.find('li').length == 0) {
                $this.remove();
            }
        });
        $container.css({ 'display': 'inline-block' });
    });

})(window.jQuery, top.luoluo);
