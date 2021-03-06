﻿/*
 * 日 期：2017.11.16
 * 描 述：自定义表单渲染
 */
(function ($, luoluo) {
    "use strict";

    function getFontHtml(verify) {
        var res = "";
        switch (verify) {
            case "NotNull":
            case "Num":
            case "Email":
            case "EnglishStr":
            case "Phone":
            case "Fax":
            case "Mobile":
            case "MobileOrPhone":
            case "Uri":
                res = '<font face="宋体">*</font>';
                break;
        }
        return res;
    }
    function getTdValidatorHtml(verify) {
        var res = "";
        if (verify != "") {
            res = 'isvalid="yes" checkexpession="' + verify + '"';
        }
        return res;

    }

    $.lrCustmerFormRender = function (data) {
        var iLen = data.length;
        var $ul;
        var $container;
        if (iLen > 1) {
            var html = '<div class="ll-form-tabs" id="ll_form_tabs">';
            html += '<ul class="nav nav-tabs"></ul></div>';
            html += '<div class="tab-content ll-tab-content" id="ll_tab_content">';
            html += '</div>';
            $('body').append(html);
            $('#ll_form_tabs').lrFormTab();
            $ul = $('#ll_form_tabs ul');
            $container = $('#ll_tab_content');
        }
        else {
            $container = $('body');
        }

        for (var i = 0; i < iLen; i++) {
            var $content = $('<div class="ll-form-wrap"></div>');
            $container.append($content);
            for (var j = 0, jLen = data[i].componts.length; j < jLen; j++) {
                var compont = data[i].componts[j];
                var $row = $('<div class="col-xs-' + (12 / parseInt(compont.proportion)) + ' ll-form-item" ></div>');
                var $title = $(' <div class="ll-form-item-title">' + compont.title + getFontHtml(compont.verify) + '</div>');
                if (compont.title != '') {
                    $row.append($title);
                }
                $content.append($row);
                var $compont = $.lrFormComponents[compont.type].renderTable(compont, $row);
                if (!!$compont && !!compont.verify && compont.verify != "") {
                    $compont.attr('isvalid', 'yes').attr('checkexpession', compont.verify);
                }
            }


            if (iLen > 1) {// 如果大于一个选项卡，需要添加选项卡，否则不需要
                $ul.append('<li><a data-value="' + data[i].id + '">' + data[i].text + '</a></li>');
                $content.addClass('tab-pane').attr('id', data[i].id);
                if (i == 0) {
                    $ul.find('li').trigger('click');
                }
            }
        }

        $('.ll-form-wrap').mCustomScrollbar({ // 优化滚动条
            theme: "minimal-dark"
        });
    };

    // 验证自定义表单数据
    $.lrValidCustmerform = function () {
        var validateflag = true;
        var validHelper = luoluo.validator;
        $('body').find("[isvalid=yes]").each(function () {
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

    // 获取自定义表单数据
    $.fn.lrGetCustmerformData = function () {
        var resdata = {};
        $(this).find('input,select,textarea,.ll-select,.ll-formselect,.lrUploader-wrap,.jfgrid-layout').each(function (r) {
            debugger
            var $self = $(this);
            var id = $self.attr('id');
            if (!!id) {
                var type = $self.attr('type');
                switch (type) {
                    case "checkbox":
                        if ($("#" + id).is(":checked")) {
                            resdata[id] = 1;
                        } else {
                            resdata[id] = 0;
                        }
                        break;
                    case "llselect":
                        resdata[id] = $self.llselectGet();
                        break;
                    case "formselect":
                        resdata[id] = $self.lrformselectGet();
                        break;
                    case "ll-Uploader":
                        resdata[id] = $self.lrUploaderGet();
                        break;
                    default:
                        if ($self.hasClass('ll-currentInfo')) {
                            resdata[id] = $self[0].lrvalue;
                        }
                        else if ($self.hasClass('jfgrid-layout')) {
                            var _resdata = [];
                            var _resdataTmp = $self.jfGridGet('rowdatas');
                            console.log(_resdataTmp);
                            for (var i = 0, l = _resdataTmp.length; i < l; i++) {
                                _resdata.push(_resdataTmp[i]);
                            }
                            resdata[id] = JSON.stringify(_resdata);
                        }
                        else {
                            var value = $self.val();
                            resdata[id] = $.trim(value);
                        }
                        break;
                }
            }
        });
        return resdata;
    }
    // 设置自定义表单数据
    $.fn.lrSetCustmerformData = function (data) {// 设置表单数据
        for (var id in data) {
            var value = data[id];
            var $obj = $('#' + id.replace('ll', '').replace(/_/g, '-'));
            var type = $obj.attr('type');
            if ($obj.hasClass("ll-input-wdatepicker")) {
                type = "datepicker";
            }
            switch (type) {
                case "checkbox":
                    var isck = 0;
                    if ($obj.is(":checked")) {
                        isck = 1;
                    } else {
                        isck = 0;
                    }
                    if (isck != parseInt(value)) {
                        $obj.trigger('click');
                    }
                    break;
                case "llselect":
                    $obj.llselectSet(value);
                    break;
                case "formselect":
                    $obj.lrformselectSet(value);
                    break;
                case "datepicker":
                    $obj.val(luoluo.formatDate(value, 'yyyy-MM-dd'));
                    break;
                case "ll-Uploader":
                    $obj.lrUploaderSet(value);
                    break;
                default:
                    if ($obj.hasClass('ll-currentInfo-user')) {
                        $obj[0].lrvalue = value;
                        $obj.val('');
                        luoluo.clientdata.getAsync('user', {
                            userId: value,
                            callback: function (item, op) {
                                op.obj.val(item.F_RealName);
                            },
                            obj: $obj
                        });
                    }
                    else {
                        $obj.val(value);
                    }
                    break;
            }
        }
    };

})(jQuery, top.luoluo);
