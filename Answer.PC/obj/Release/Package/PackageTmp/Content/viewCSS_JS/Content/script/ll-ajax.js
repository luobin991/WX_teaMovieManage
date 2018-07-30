/*
 * 日 期：2017.11.16
 * 描 述：ajax操作方法
 */
(function ($, luoluo) {
    "use strict";
    var httpCode = {
        success: 200,
        fail: 400,
        exception: 500
    };
    var exres = { code: httpCode.exception, info: '通信异常，请联系管理员！' }
    $.extend(luoluo, {
        // http 通信异常的时候调用此方法
        httpErrorLog: function (msg) {
            luoluo.log(msg);
        },
        // http请求返回数据码
        httpCode: httpCode,
        // get请求方法（异步）:url地址,callback回调函数
        httpAsyncGet: function (url, callback) {
            $.ajax({
                url: url,
                type: "GET",
                dataType: "json",
                async: true,
                cache: false,
                success: function (data) {
                    if (data.code == luoluo.httpCode.exception) {
                        luoluo.httpErrorLog(data.info);
                        data.info = '系统异常，请联系管理员！';
                    }
                    callback(data);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    luoluo.httpErrorLog(textStatus);
                    callback(exres);
                },
                beforeSend: function () {
                },
                complete: function () {
                }
            });
        },
        // get请求方法（异步）:url地址,callback回调函数
        httpFAsyncGet: function (url, callback) {
            $.ajax({
                url: url,
                type: "GET",
                dataType: "json",
                async: false,
                cache: false,
                success: function (data) {
                    if (data.code == luoluo.httpCode.exception) {
                        luoluo.httpErrorLog(data.info);
                        data.info = '系统异常，请联系管理员！';
                    }
                    callback(data);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    luoluo.httpErrorLog(textStatus);
                    callback(exres);
                },
                beforeSend: function () {
                },
                complete: function () {
                }
            });
        },
        // get请求方法（同步）:url地址,param参数
        httpGet: function (url, param) {
            var res = {};
            $.ajax({
                url: url,
                data: param,
                type: "GET",
                dataType: "json",
                async: false,
                cache: false,
                success: function (data) {
                    if (data.code == luoluo.httpCode.exception) {
                        luoluo.httpErrorLog(data.info);
                        data.info = '系统异常，请联系管理员！';
                    }
                    res = data;
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    luoluo.httpErrorLog(textStatus);
                },
                beforeSend: function () {
                },
                complete: function () {
                }
            });
            return res;
        },
        // post请求方法（异步）:url地址,param参数,callback回调函数
        httpAsyncPost: function (url, param, callback) {
            $.ajax({
                url: url,
                data: param,
                type: "POST",
                dataType: "json",
                async: true,
                cache: false,
                success: function (data) {
                    if (data.code == luoluo.httpCode.exception) {
                        luoluo.httpErrorLog(data.info);
                        data.info = '系统异常，请联系管理员！';
                    }
                    callback(data);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    luoluo.httpErrorLog(textStatus);
                    callback(exres);
                },
                beforeSend: function () {
                },
                complete: function () {
                }
            });
        },
        // post请求方法（同步步）:url地址,param参数,callback回调函数
        httpPost: function (url, param, callback) {
            $.ajax({
                url: url,
                data: param,
                type: "POST",
                dataType: "json",
                async: false,
                cache: false,
                success: function (data) {
                    if (data.code == luoluo.httpCode.exception) {
                        luoluo.httpErrorLog(data.info);
                        data.info = '系统异常，请联系管理员！';
                    }
                    callback(data);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    luoluo.httpErrorLog(textStatus);
                    callback(exres);
                },
                beforeSend: function () {
                },
                complete: function () {
                }
            });
        },
        // ajax 异步封装
        httpAsync: function (type, url, param, callback) {
            $.ajax({
                url: url,
                data: param,
                type: type,
                dataType: "json",
                async: true,
                cache: false,
                success: function (res) {
                    if (res.code == luoluo.httpCode.success) {
                        callback(res.data);
                    }
                    else {
                        luoluo.httpErrorLog(res.info);
                        callback(null);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    luoluo.httpErrorLog(textStatus);
                    callback(null);
                },
                beforeSend: function () {
                },
                complete: function () {
                }
            });
        },

        deleteForm:function (url, param, callback) {
            luoluo.loading(true, '正在删除数据');
            luoluo.httpAsyncPost(url, param, function (res) {
                luoluo.loading(false);
                if (res.code == luoluo.httpCode.success) {
                    if (!!callback) {
                        callback(res);
                    }
                    luoluo.alert.success(res.info);
                }
                else {
                    luoluo.alert.error(res.info);
                    luoluo.httpErrorLog(res.info);
                }
                layer.close(layer.index);
            });
        },
        postForm:function (url, param, callback) {
            luoluo.loading(true, '正在提交数据');
            luoluo.httpAsyncPost(url, param, function (res) {
                luoluo.loading(false);
                if (res.code == luoluo.httpCode.success) {
                    if (!!callback) {
                        callback(res);
                    }
                    luoluo.alert.success(res.info);
                }
                else {
                    luoluo.alert.error(res.info);
                    luoluo.httpErrorLog(res.info);
                }
                layer.close(layer.index);
            });
        }
    });

})(window.jQuery, top.luoluo);
