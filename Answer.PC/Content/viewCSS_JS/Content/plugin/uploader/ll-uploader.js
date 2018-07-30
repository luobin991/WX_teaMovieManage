/*
 * 日 期：2017.05.24
 * 描 述：ll-uploader 表单附件选择插件
 */
(function ($, luoluo) {
    "use strict";

    $.lrUploader = {
        init: function ($self) {
            var dfop = $self[0]._lrUploader.dfop;
            $.lrUploader.initRender($self, dfop);
        },
        initRender: function ($self, dfop) {
            $self.attr('type', 'll-Uploader').addClass('lrUploader-wrap');
            var $wrap = $('<div class="lrUploader-input" ></div>');

            var $btnGroup = $('<div class="lrUploader-btn-group"></div>');
            var $uploadBtn = $('<a id="lrUploader_uploadBtn_' + dfop.id + '" class="btn btn-success lrUploader-input-btn">上传</a>');
            var $downBtn = $('<a id="lrUploader_downBtn_' + dfop.id + '" class="btn btn-danger lrUploader-input-btn">下载</a>');

            $self.append($wrap);

            $btnGroup.append($uploadBtn);
            $btnGroup.append($downBtn);
            $self.append($btnGroup);

            $uploadBtn.on('click', $.lrUploader.openUploadForm);
            $downBtn.on('click', $.lrUploader.openDownForm);
           
        },
        openUploadForm: function () {
            var $btn = $(this);
            var $self = $btn.parents('.lrUploader-wrap');
            var dfop = $self[0]._lrUploader.dfop;
            luoluo.layerForm({
                id: dfop.id,
                title: dfop.placeholder,
                url: top.$.rootUrl + '/LR_SystemModule/Annexes/UploadForm?keyVaule=' + dfop.value + "&extensions=" + dfop.extensions,
                width: 600,
                height: 400,
                maxmin: true,
                btn: null,
                end: function () {
                    luoluo.httpAsyncGet(top.$.rootUrl + '/LR_SystemModule/Annexes/GetFileNames?folderId=' + dfop.value, function (res) {
                        if (res.code == luoluo.httpCode.success) {
                            $('#' + dfop.id).find('.lrUploader-input').text(res.info);
                        }
                    });
                }
            });
        },
        openDownForm: function () {
            var $btn = $(this);
            var $self = $btn.parents('.lrUploader-wrap');
            var dfop = $self[0]._lrUploader.dfop;
            luoluo.layerForm({
                id: dfop.id,
                title: dfop.placeholder,
                url: top.$.rootUrl + '/LR_SystemModule/Annexes/DownForm?keyVaule=' + dfop.value,
                width: 600,
                height: 400,
                maxmin: true,
                btn: null
            });
        }
    };

    $.fn.lrUploader = function (op) {
        var $this = $(this);
        if (!!$this[0]._lrUploader) {
            return $this;
        }
        var dfop = {
            placeholder: '上传附件',
            isUpload: true,
            isDown: true,
            extensions: ''
        }

        $.extend(dfop, op || {});
        dfop.id = $this.attr('id');
        dfop.value = luoluo.newGuid();

        $this[0]._lrUploader = { dfop: dfop };
        $.lrUploader.init($this);
    };

    $.fn.lrUploaderSet = function (value) {
        var $self = $(this);
        var dfop = $self[0]._lrUploader.dfop;
        dfop.value = value;
        luoluo.httpAsyncGet(top.$.rootUrl + '/LR_SystemModule/Annexes/GetFileNames?folderId=' + dfop.value, function (res) {
            if (res.code == luoluo.httpCode.success) {
                $('#' + dfop.id).find('.lrUploader-input').text(res.info);
            }
        });
    }

    $.fn.lrUploaderGet = function () {
        var $this = $(this);
        var dfop = $this[0]._lrUploader.dfop;
        return dfop.value;
    }
})(jQuery, top.luoluo);
