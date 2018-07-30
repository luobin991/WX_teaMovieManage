/*
 * 日 期：2017.11.16
 * 描 述：表单数据验证完整性
 */
(function ($, luoluo) {
    "use strict";
    
    $.lrValidformMessage = function ($this, errormsg) {
        /*错误处理*/
        $this.addClass('ll-field-error');
        $this.parent().append('<div class="ll-field-error-info" title="' + errormsg + '！"><i class="fa fa-info-circle"></i></div>');
        var validatemsg = $this.parent().find('.form-item-title').text() + ' ' + errormsg;
        luoluo.alert.error('表单信息输入有误,请检查！</br>' + validatemsg);
        if ($this.attr('type') == 'llselect') {
            $this.on('change', function () {
                removeErrorMessage($(this));
            });
        }
        else if ($this.attr('type') == 'formselect') {
            $this.on('change', function () {
                removeErrorMessage($(this));
            });
        }
        else if ($this.hasClass('ll-input-wdatepicker')) {
            $this.on('change', function () {
                var $input = $(this);
                if ($input.val()) {
                    removeErrorMessage($input);
                }
            });
        }
        else {
            $this.on('input propertychange', function () {
                var $input = $(this);
                if ($input.val()) {
                    removeErrorMessage($input);
                }
            });
        }
    };

    $.fn.lrRemoveValidMessage = function () {
        removeErrorMessage($(this));
    }

    $.fn.llValidform = function () {
        var validateflag = true;
        var validHelper = luoluo.validator;
        $(this).find("[isvalid=yes]").each(function () {
            var $this = $(this);

            if ($this.parent().find('.ll-field-error-info').length > 0) {
                validateflag = false;
                return true;
            }

            var checkexpession = $(this).attr("checkexpession");
            var checkfn = validHelper['is' + checkexpession];
            if (!checkexpession || !checkfn) { return false; }
            var errormsg = $(this).attr("errormsg") || "";
            var value;
            var type = $this.attr('type');
            if (type == 'llselect') {
                value = $this.llselectGet();
            }
            else if (type == 'formselect') {
                value = $this.lrformselectGet();
            }
            else {
                value = $this.val();
            }
            var r = { code: true, msg: '' };
            if (checkexpession == 'LenNum' || checkexpession == 'LenNumOrNull' || checkexpession == 'LenStr' || checkexpession == 'LenStrOrNull') {
                var len = $this.attr("length");
                r = checkfn(value, len);
            } else {
                r = checkfn(value);
            }
            if (!r.code) {
                validateflag = false;
                $.lrValidformMessage($this, errormsg + r.msg);
            }
        });
        return validateflag;
    }

    function removeErrorMessage($obj) {
        $obj.removeClass('ll-field-error');
        $obj.parent().find('.ll-field-error-info').remove();
    }

})(window.jQuery, top.luoluo);
