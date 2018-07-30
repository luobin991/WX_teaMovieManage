$(function () {
    "use strict";

    // 基于准备好的dom，初始化echarts实例
    //var pieChart = echarts.init(document.getElementById('piecontainer'));
    // 指定图表的配置项和数据
    var pieoption = {
        tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b} : {c} ({d}%)"
        },
        legend: {
            bottom: 'bottom',
            data: ['枢纽楼', 'IDC中心', '端局', '模块局', '营业厅', '办公大楼', 'C网基站']
        },
        series: [
            {
                name: '用电占比',
                type: 'pie',
                radius: '75%',
                center: ['50%', '50%'],
                data: [
                    { value: 10, name: '枢纽楼' },
                    { value: 10, name: 'IDC中心' },
                    { value: 10, name: '端局' },
                    { value: 10, name: '模块局' },
                    { value: 10, name: '营业厅' },
                    { value: 10, name: '办公大楼' },
                    { value: 40, name: 'C网基站' }
                ],
                itemStyle: {
                    emphasis: {
                        shadowBlur: 10,
                        shadowOffsetX: 0,
                        shadowColor: 'rgba(0, 0, 0, 0.5)'
                    }
                }
            }
        ]
    };
    // 使用刚指定的配置项和数据显示图表。
    //pieChart.setOption(pieoption);

    // 基于准备好的dom，初始化echarts实例
    var lineChart = echarts.init(document.getElementById('linecontainer'));
    // 指定图表的配置项和数据
    var lineoption = {
        title: { text: '当天在线人数' },
        tooltip: { trigger: 'axis' },
        legend: { data: ['当天人数'] },
        grid: { bottom: '8%', containLabel: true },
        xAxis: {
            type: 'time', splitLine: {
                show: false
            }
        },
        yAxis: {
            type: 'value',
            boundaryGap: [0, '100%'],
            splitLine: {
                show: false
            }
        },
        series: [
            {
                name: '当天人数',
                type: 'line',
                showSymbol: false,
                hoverAnimation: false,
            },
              {
                  name: '当天充值',
                  type: 'scatter',
                  stack: '总量',
                  showSymbol: false,
                  hoverAnimation: false,
                  data: [7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 23.3, 18.3, 13.9, 9.6]
              }
        ]
    };

    var scatterChart = echarts.init(document.getElementById('diamond'));
    var diamond = {
        title: {text: '当天冲钻'},
        tooltip: { trigger: 'axis' },
        legend: { data: ['当天冲钻'] },
        grid: { bottom: '8%', containLabel: true },
        xAxis: {
            type: 'time', splitLine: {
                show: false
            }
        },
        yAxis: {
            type: 'value',
            boundaryGap: [0, '100%'],
            splitLine: {
                show: false
            }
        },
        series: [
            {
                name: '当天冲钻',
                type: 'scatter',
                showSymbol: false,
                hoverAnimation: false,
            },
        ]
    };


    // 使用刚指定的配置项和数据显示图表。
    lineChart.setOption(lineoption);
    scatterChart.setOption(diamond);
    //加载数据
    GetOnlineNumber();
    //定时拉取数据
    setInterval(GetOnlineNumber, 1000 * 60 * 1);  //1000 * 60 * 2

    //请求数据
    function GetOnlineNumber() {
        var OnlineNum = [];
        var diamondNum = []; var sum_diamond = 0;
        //在线人数
        top.luoluo.httpFAsyncGet(top.$.rootUrl + '/DataStatistics/NiuN/OnlineNum', function (res) {
            if (res.code == 200) {
                var list = res.data;
                for (var i = 0; i < list.length; i++) {
                    OnlineNum.push({
                        name: list[i].updateTime,
                        value: [
                            list[i].updateTime,
                            list[i].onlineCount
                        ]
                    });
                }
                return OnlineNum;
            }
        });
        //冲钻
        top.luoluo.httpFAsyncGet(top.$.rootUrl + '/DataStatistics/Diamond/GetDiamondList', function (res) {
            if (res.code == 200) {
                var list = res.data;
                for (var i = 0; i < list.length; i++) {
                    diamondNum.push({
                        name: list[i].updateTime,
                        value: [
                            list[i].updateTime,
                            list[i].changedDiamond
                        ]
                    });
                    sum_diamond = sum_diamond + parseInt(list[i].changedDiamond);
                }
                return diamondNum;
            }
        });
        lineChart.setOption({
            series: [{ data: OnlineNum }]
        });
        scatterChart.setOption({
            series: [{ data: diamondNum }],
            title: [{ text: '当天总冲钻：' + sum_diamond }]
        });
    }

    window.onresize = function (e) {
        //pieChart.resize(e);
        lineChart.resize(e);
        scatterChart.resize(e);
    }

    $(".ll-desktop-panel").mCustomScrollbar({ // 优化滚动条
        theme: "minimal-dark"
    });
});