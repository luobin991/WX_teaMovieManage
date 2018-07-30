/*
 * 日 期：2017.11.16
 * 描 述：表单处理方法
 */
(function ($, luoluo) {
    "use strict";

    /*获取和设置表单数据*/
    $.fn.llGetFormData = function (keyValue) {// 获取表单数据
        var resdata = {};
        $(this).find('input,select,textarea,.ll-select,.ll-formselect,.lrUploader-wrap,.ll-radio,.ll-checkbox').each(function (r) {
            var id = $(this).attr('id');
            if (!!id) {
                var type = $(this).attr('type');
                switch (type) {
                    case "radio":
                        if ($("#" + id).is(":checked")) {
                            var _name = $("#" + id).attr('name');
                            resdata[_name] = $("#" + id).val();
                        }
                        break;
                    case "checkbox":
                        if ($("#" + id).is(":checked")) {
                            resdata[id] = 1;
                        } else {
                            resdata[id] = 0;
                        }
                        break;
                    case "llselect":
                        resdata[id] = $(this).llselectGet();
                        break;
                    case "formselect":
                        resdata[id] = $(this).lrformselectGet();
                        break;
                    case "ll-Uploader":
                        resdata[id] = $(this).lrUploaderGet();
                        break;
                    case "ll-radio":
                        resdata[id] = $(this).find('input:checked').val();
                        break;
                    default:
                        var value = $("#" + id).val();
                        resdata[id] = $.trim(value);
                        break;
                }
                if (resdata[id] == '&nbsp;' && !keyValue) {
                    resdata[id] = '';
                }
            }
        });
        return resdata;
    };
    $.fn.llSetFormData = function (data) {// 设置表单数据
        for (var id in data) {
            var value = data[id];
            var $obj = $('#' + id);
            if ($obj.length == 0 && value != null) {
                $obj = $('[name="' + id + '"][value="' + value + '"]');
                if ($obj.length > 0) {
                    if (!$obj.is(":checked")) {
                        $obj.trigger('click');
                    }
                }
            }
            else {
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
                    case "ll-radio":
                        if (!$obj.find('input[value="' + value + '"]').is(":checked")) {
                            $obj.find('input[value="' + value + '"]').trigger('click');
                        }
                        break;
                    default:
                        $obj.val(value);
                        break;
                }
            }
        }
    };

    /*表单数据操作*/
    $.llSetForm = function (url, callback) {
        luoluo.loading(true, '正在获取数据');
        luoluo.httpAsyncGet(url, function (res) {
            luoluo.loading(false);
            if (res.code == luoluo.httpCode.success) {
                callback(res.data);
            }
            else {
                luoluo.layerClose(window.name);
                luoluo.alert.error('表单数据获取失败,请重新获取！');
                luoluo.httpErrorLog(res.info);
            }
        });
    };
    $.llSaveForm = function (url, param, callback, isNotClosed) {
        param['__RequestVerificationToken'] = $.lrToken;
        luoluo.loading(true, '正在保存数据');
        luoluo.httpAsyncPost(url, param, function (res) {
            luoluo.loading(false);
            if (res.code == luoluo.httpCode.success) {
                if (!!callback) {
                    callback(res);
                }
                luoluo.alert.success(res.info);
                if (!isNotClosed) {
                    luoluo.layerClose(window.name);
                }
            }
            else {
                luoluo.alert.error(res.info);
                luoluo.httpErrorLog(res.info);
            }
        });
    };
    $.lrPostForm = function (url, param) {
        param['__RequestVerificationToken'] = $.lrToken;
        luoluo.loading(true, '正在提交数据');
        luoluo.httpAsyncPost(url, param, function (res) {
            luoluo.loading(false);
            if (res.code == luoluo.httpCode.success) {
                luoluo.alert.success(res.info);
            }
            else {
                luoluo.alert.error(res.info);
                luoluo.httpErrorLog(res.info);
            }
        });
    };

    /*tab页切换*/
    $.fn.lrFormTab = function () {
        var $this = $(this);
        $this.parent().css({ 'padding-top': '44px' });
        $this.mCustomScrollbar({
            axis: "x",
            theme: "minimal-dark"
        });
        $this.delegate('li', 'click', { $ul: $this }, function (e) {
            var $li = $(this);
            if (!$li.hasClass('active')) {
                var $parent = $li.parent();
                var $content = e.data.$ul.next();

                var id = $li.find('a').attr('data-value');
                $parent.find('li.active').removeClass('active');
                $li.addClass('active');
                $content.find('.tab-pane.active').removeClass('active');
                $content.find('#' + id).addClass('active');
            }
        });
    }
    $.fn.lrFormTabEx = function (callback) {
        var $this = $(this);
        $this.delegate('li', 'click', { $ul: $this }, function (e) {
            var $li = $(this);
            if (!$li.hasClass('active')) {
                var $parent = $li.parent();
                var $content = e.data.$ul.next();

                var id = $li.find('a').attr('data-value');
                $parent.find('li.active').removeClass('active');
                $li.addClass('active');
                $content.find('.tab-pane.active').removeClass('active');
                $content.find('#' + id).addClass('active');

                if (!!callback) {
                    callback(id);
                }
            }
        });
    }
    
    /*检测字段是否重复*/
    $.lrExistField = function (keyValue, controlId, url, param) {
        var $control = $("#" + controlId);
        if (!$control.val()) {
            return false;
        }
        var data = {
            keyValue: keyValue
        };
        data[controlId] = $control.val();
        $.extend(data, param);
        luoluo.httpAsync('GET', url, data, function (data) {
            if (data == false) {
                $.lrValidformMessage($control, '已存在,请重新输入');
            }
        });
    };

    /*固定下拉框的一些封装：数据字典，组织机构，省市区级联*/
    // 数据字典下拉框
    $.fn.lrDataItemSelect = function (op) {
        // op:code 码,parentId 父级id,maxHeight 200,allowSearch， childId 级联下级框id
        var dfop = {
            // 字段
            value: "F_ItemValue",
            text: "F_ItemName",
            title: "F_ItemName",
            // 展开最大高度
            maxHeight: 200,
            // 是否允许搜索
            allowSearch: false,
            // 访问数据接口地址
            url: top.$.rootUrl + '/LR_SystemModule/DataItem/GetDetailListByParentId',
            // 访问数据接口参数
            param: { itemCode: '', parentId: '0' },
            // 级联下级框
        }
        op = op || {};
        if (!op.code) {
            return false;
        }
        dfop.param.itemCode = op.code;
        dfop.param.parentId = op.parentId || '0';
        dfop.maxHeight = op.maxHeight || 200;
        dfop.allowSearch = op.allowSearch;

        if (!!op.childId) {
            $('#' + op.childId).llselect({
                // 字段
                value: "F_ItemValue",
                text: "F_ItemName",
                title: "F_ItemName",
                // 展开最大高度
                maxHeight: dfop.maxHeight,
                // 是否允许搜索
                allowSearch: dfop.allowSearch,
            });
            dfop.select = function (item) {
                if (!item) {
                    $('#' + op.childId).lrselectRefresh({
                        url: '',
                        data: []
                    });
                }
                else {
                    $('#' + op.childId).lrselectRefresh({
                        url: top.$.rootUrl + '/LR_SystemModule/DataItem/GetDetailListByParentId',
                        param: { itemCode: op.code, parentId: item.F_ItemDetailId },
                    });
                }
            };
        }
        return $(this).llselect(dfop);
    };
    // 公司信息下拉框
    $.fn.lrCompanySelect = function (op) {
        // op:parentId 父级id,maxHeight 200,
        var dfop = {
            type: 'tree',
            // 展开最大高度
            maxHeight: 200,
            // 是否允许搜索
            allowSearch: true,
            // 访问数据接口地址
            url: top.$.rootUrl + '/LR_OrganizationModule/Company/GetTree',
            // 访问数据接口参数
            param: {parentId: '0' },
        }
        op = op || {};
        dfop.param.parentId = op.parentId || '0';
        dfop.maxHeight = op.maxHeight || 200;

        return $(this).llselect(dfop);
    };
    // 部门信息下拉框
    $.fn.lrDepartmentSelect = function (op) {
        // op:parentId 父级id,maxHeight 200,
        var dfop = {
            type: 'tree',
            // 展开最大高度
            maxHeight: 200,
            // 是否允许搜索
            allowSearch: true,
            // 访问数据接口地址
            url: top.$.rootUrl + '/LR_OrganizationModule/Department/GetTree',
            // 访问数据接口参数
            param: { companyId: '', parentId: '' },
        }
        op = op || {};
        dfop.param.companyId = op.companyId;
        dfop.param.parentId = op.parentId;
        dfop.maxHeight = op.maxHeight || 200;

        return $(this).llselect(dfop);
    };
    // 人员下拉框
    $.fn.lrUserSelect = function (type) {//0单选1多选
        if (type == 0) {
            $(this).lrformselect({
                layerUrl: top.$.rootUrl + '/LR_OrganizationModule/User/SelectOnlyForm',
                layerUrlW: 400,
                layerUrlH: 300,
                dataUrl: top.$.rootUrl + '/LR_OrganizationModule/User/GetListByUserIds'
            });
        }
        else {
            $(this).lrformselect({
                layerUrl: top.$.rootUrl + '/LR_OrganizationModule/User/SelectForm',
                layerUrlW: 800,
                layerUrlH: 520,
                dataUrl: top.$.rootUrl + '/LR_OrganizationModule/User/GetListByUserIds'
            });
        }
    }

    // 省市区级联
    $.fn.lrAreaSelect = function (op) {
        // op:parentId 父级id,maxHeight 200,
        var dfop = {
            // 字段
            value: "F_AreaCode",
            text: "F_AreaName",
            title: "F_AreaName",
            // 展开最大高度
            maxHeight: 200,
            // 是否允许搜索
            allowSearch: true,
            // 访问数据接口地址
            url: top.$.rootUrl + '/LR_SystemModule/Area/Getlist',
            // 访问数据接口参数
            param: { parentId: ''},
        }
        op = op || {};
        if (!!op.parentId) {
            dfop.param.parentId = op.parentId;
        }
        dfop.maxHeight = op.maxHeight || 200;
        var _obj = [], i = 0;
        var $this = $(this);
        $(this).find('div').each(function () {
            var $div = $('<div></div>');
            var $obj = $(this);
            dfop.placeholder = $obj.attr('placeholder');
            $div.addClass($obj.attr('class'));
            $obj.removeAttr('class');
            $obj.removeAttr('placeholder');
            $div.append($obj);
            $this.append($div);
            if (i == 0) {
                $obj.llselect(dfop);
            }
            else {
                dfop.url = "";
                dfop.parentId = "";
                $obj.llselect(dfop);
                _obj[i - 1].on('change', function () {
                    var _value = $(this).llselectGet();
                    if (_value == "") {
                        $obj.lrselectRefresh({
                            url: '',
                            param: { parentId: _value },
                            data:[]
                        });
                    }
                    else {
                        $obj.lrselectRefresh({
                            url: top.$.rootUrl + '/LR_SystemModule/Area/Getlist',
                            param: { parentId: _value },
                        });
                    }
                  
                });
            }
            i++;
            _obj.push($obj);
        });
    };
    // 数据库选择
    $.fn.lrDbSelect = function (op) {
        // op:maxHeight 200,
        var dfop = {
            type: 'tree',
            // 展开最大高度
            maxHeight: 200,
            // 是否允许搜索
            allowSearch: true,
            // 访问数据接口地址
            url: top.$.rootUrl + '/LR_SystemModule/DatabaseLink/GetTreeList'
        }
        op = op || {};
        dfop.maxHeight = op.maxHeight || 200;

        return $(this).llselect(dfop);
    }


    // 获取某些固定数据
    // 数据字典数据
    $.lrGetDataItem = function (code, callback) {
        luoluo.httpAsyncGet(top.$.rootUrl + '/LR_SystemModule/DataItem/GetDetailList?itemCode=' + code, function (res) {
            if (res.code == luoluo.httpCode.success) {
                callback(res.data);
            }
            else {
                luoluo.alert.error('数据字典数据获取失败,请重新获取！');
                luoluo.httpErrorLog(res.info);
            }
        });
    }
    // 获取数据源数据
    $.lrGetDataSource = function (code, callback) {
        luoluo.httpAsyncGet(top.$.rootUrl + '/LR_SystemModule/DataSource/GetDataTable?code=' + code, function (res) {
            if (res.code == luoluo.httpCode.success) {
                callback(res.data);
            }
            else {
                luoluo.alert.error('数据源数据获取失败,请重新获取！');
                luoluo.httpErrorLog(res.info);
            }
        });
    }

    // 动态获取和设置radio，checkbox
    $.fn.lrRadioCheckbox = function (op) {
        var dfop = {
            type: 'radio',        // checkbox
            dataType: 'dataItem', // 默认是数据字典 dataSource（数据源）
            code: '',
            text: 'F_ItemName',
            value: 'F_ItemValue'
        };
        $.extend(dfop, op || {});
        var $this = $(this);
        $this.addClass(dfop.type);
        $this.addClass('ll-' + dfop.type);
        $this.attr('type', 'll-' + dfop.type);
        var thisId = $this.attr('id');

       
        if (dfop.dataType == 'dataItem') {
            $.lrGetDataItem(dfop.code, function (data) {
                $.each(data, function (id, item) {
                    var $point = $('<label><input name="' + thisId + '" value="' + item[dfop.value] + '"' + '" type="' + dfop.type + '">' + item[dfop.text] + '</label>');
                    $this.append($point);
                });
                $this.find('input').eq(0).trigger('click');
            });
        }
        else {
            $.lrGetDataSource(dfop.code, function (data) {
                $.each(data, function (id, item) {
                    var $point = $('<label><input name="' + thisId + '" value="' + item[dfop.value] + '"' + '" type="' + dfop.type + '">' + item[dfop.text] + '</label>');
                    $this.append($point);
                });
                $this.find('input').eq(0).trigger('click');
            });
        }
    }
    // 多条件查询框
    $.fn.lrMultipleQuery = function (search,height ,width ) {
        var $this = $(this);
        var contentHtml = $this.html();
        $this.addClass('ll-query-wrap');
        

        var _html = '';
        _html += '<div class="ll-query-btn"><i class="fa fa-search"></i>&nbsp;多条件查询</div>';
        _html += '<div class="ll-query-content">';
        //_html += '<div class="ll-query-formcontent">';
        _html += contentHtml;
        //_html += '</div>';
        _html += '<div class="ll-query-arrow"><div class="ll-query-inside"></div></div>';
        _html += '<div class="ll-query-content-bottom">';
        _html += '<a id="lr_btn_queryReset" class="btn btn-default">&nbsp;重&nbsp;&nbsp;置</a>';
        _html += '<a id="lr_btn_querySearch" class="btn btn-primary">&nbsp;查&nbsp;&nbsp;询</a>';
        _html += '</div>';
        _html += '</div>';
        $this.html(_html);
        $this.find('.ll-query-formcontent').show();

        $this.find('.ll-query-content').css({ 'width': width || 400, 'height': height || 300 });

        $this.find('.ll-query-btn').on('click', function () {
            var $content = $this.find('.ll-query-content');
            if ($content.hasClass('active')) {
                $content.removeClass('active');
            }
            else {
                $content.addClass('active');
            }
        });

        $this.find('#lr_btn_querySearch').on('click', function () {
            var $content = $this.find('.ll-query-content');
            var query = $content.llGetFormData();
            $content.removeClass('active');
            search(query);
        });

        $this.find('#lr_btn_queryReset').on('click', function () {
            var $content = $this.find('.ll-query-content');
            var query = $content.llGetFormData();
            for (var id in query) {
                query[id] = "";
            }
            $content.llSetFormData(query);
        });

        $(document).click(function (e) {
            var et = e.target || e.srcElement;
            var $et = $(et);
            if (!$et.hasClass('ll-query-wrap') && $et.parents('.ll-query-wrap').length <= 0) {

                $('.ll-query-content').removeClass('active');
            }
        });
    }

})(jQuery, top.luoluo);
