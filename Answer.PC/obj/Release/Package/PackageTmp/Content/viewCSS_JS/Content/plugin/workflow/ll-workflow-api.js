/*
 * 日 期：2017.11.16
 * 描 述：工作流引擎api操作方法类
 */
(function ($, luoluo) {
    "use strict";

    var api = {
        bootstraper: top.$.workflowapi + '/workflow/bootstraper',
        taskinfo: top.$.workflowapi + '/workflow/taskinfo',
        processinfo: top.$.workflowapi + '/workflow/processinfo',

        create: top.$.workflowapi + '/workflow/create',
        audit: top.$.workflowapi + '/workflow/audit'
    };

    var httpGet = function (url, param, callback, loadmsg) {
        luoluo.loading(true, loadmsg || '正在获取数据');
        luoluo.httpAsync('GET', url, param, function (res) {
            luoluo.loading(false);
            callback(res);
        });
    };
    var httpPost = function (url, param, callback, loadmsg) {
        luoluo.loading(true, loadmsg || '正在获取数据');
        luoluo.httpAsync('Post', url, param, function (data) {
            luoluo.loading(false);
            callback(data);
        });
    };

    // 读取登录秘钥信息
    function getLoginInfo() {
        var req = {
            token: top.$.cookie('ADMS__Token'),
            loginMark: top.$.cookie('ADMS__Mark'),
        };

        return req;
    }

    luoluo.workflowapi = {
        // 流程初始化用于发起:
        // isNew是否是新发起的流程,processId:发起的流程实例主键,schemeCode:发起的流程模板编码
        // callback:回调函数 res：true/false,data:返回的节点数据
        bootstraper: function (op) {
            var dfop = {
                isNew: true,
                processId: '',
                schemeCode: '',
            }
            $.extend(dfop, op);
            var req = getLoginInfo();
            req.data = JSON.stringify({
                isNew: dfop.isNew,
                processId: dfop.processId,
                schemeCode: dfop.schemeCode
            });
            httpPost(api.bootstraper, req, function (res) {
                if (res != null) {
                    if (res.status == 1) {
                        op.callback(true, res.data);
                    }
                    else {
                        luoluo.alert.error(res.desc);
                        op.callback(false);
                    }
                }
                else {
                    luoluo.alert.error('获取流程信息失败!');
                    op.callback(false);
                }
            }, '正在获取流程信息...');
        },
        // 流程实例发起:
        // isNew是否是新发起的流程,processId:发起的流程实例主键,schemeCode:发起的流程模板编码
        // callback:回调函数 res：true/false,data:返回的节点数据
        create: function (op) {
            var dfop = {
                isNew: true,
                processId: '',
                schemeCode: '',
            }
            $.extend(dfop, op);
            var req = getLoginInfo();
            req.data = JSON.stringify({
                isNew: dfop.isNew,
                processId: dfop.processId,
                schemeCode: dfop.schemeCode,
                processName: dfop.processName,
                processLevel: dfop.processLevel,
                description: dfop.description,
                formData: op.formData
            });

            httpPost(api.create, req, function (res) {
                if (res != null) {
                    if (res.status == 1) {
                        op.callback(true);
                    }
                    else {
                        luoluo.alert.error(res.desc);
                        op.callback(false);
                    }
                }
                else {
                    luoluo.alert.error('创建流程失败!');
                    op.callback(false);
                }
            }, '正在创建流程实例...');
        },

        taskinfo: function (op) {
            var dfop = {
                isNew: false,
                processId: '',
                taskId: '',
            }
            $.extend(dfop, op);
            var req = getLoginInfo();
            req.data = JSON.stringify({
                isNew: dfop.isNew,
                processId: dfop.processId,
                taskId: dfop.taskId
            });

            httpPost(api.taskinfo, req, function (res) {
                if (res != null) {
                    if (res.status == 1) {
                        op.callback(true, res.data);
                    }
                    else {
                        luoluo.alert.error(res.desc);
                        op.callback(false);
                    }
                }
                else {
                    luoluo.alert.error('获取流程信息失败!');
                    op.callback(false);
                }
            }, '正在获取流程信息...');
        },
        audit: function (op) {
            var dfop = {
                verifyType: '',
                taskId: '',
            }
            $.extend(dfop, op);
            var req = getLoginInfo();
            req.data = JSON.stringify({
                taskId: dfop.taskId,
                verifyType: dfop.verifyType,
                description: dfop.description,
                auditorId: dfop.auditorId,
                auditorName: dfop.auditorName,
                formData: op.formData
            });
            httpPost(api.audit, req, function (res) {
                if (res != null) {
                    if (res.status == 1) {
                        op.callback(true);
                    }
                    else {
                        luoluo.alert.error(res.desc);
                        op.callback(false);
                    }
                }
                else {
                    luoluo.alert.error('流程审核失败!');
                    op.callback(false);
                }
            }, '正在审核流程实例...');
        },

        processinfo: function (op) {
            var dfop = {
                isNew: false,
                processId: '',
                taskId: '',
            }
            $.extend(dfop, op);
            var req = getLoginInfo();
            req.data = JSON.stringify({
                isNew: false,
                processId: dfop.processId,
                taskId: dfop.taskId
            });

            httpPost(api.processinfo, req, function (res) {
                if (res != null) {
                    if (res.status == 1) {
                        op.callback(true, res.data);
                    }
                    else {
                        luoluo.alert.error(res.desc);
                        op.callback(false);
                    }
                }
                else {
                    luoluo.alert.error('获取流程信息失败!');
                    op.callback(false);
                }
            }, '正在获取流程信息...');
        },
    };

})(jQuery, top.luoluo);