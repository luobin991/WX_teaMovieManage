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
        tooltip: {
            trigger: 'axis'
        },
        legend: {
            bottom: 'bottom',
            data: ['当天人数']
        },
        grid: {
            bottom: '8%',
            containLabel: true
        },
        xAxis: {
            type: 'time',
            splitLine: {
                show: false
            }
        },
        //xAxis: {
        //    type: 'time',//category
        //    boundaryGap: false,
        //    data: ['1月', '2月', '3月', '4月', '5月', '6月', '7月', '8月', '9月', '10月', '11月', '12月']
        //},
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
                stack: '用电量',
                showSymbol: false,
                hoverAnimation: false,
                data:[0] // [7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 23.3, 18.3, 13.9, 9.6]
            }
        ]
    };
    // 使用刚指定的配置项和数据显示图表。
    lineChart.setOption(lineoption);
    //加载数据
    GetOnlineNumber();
    //定时拉取数据
    setInterval(GetOnlineNumber, 1000 * 60 * 1);  //1000 * 60 * 2

    //请求数据
    function GetOnlineNumber() {
        var newData = [];
        top.learun.httpFAsyncGet(top.$.rootUrl + '/DataStatistics/NiuN/OnlineNum', function (res) {
            if (res.code == 200) {
                var list = res.data;
                for (var i = 0; i < list.length; i++) {
                    newData.push({
                        name: list[i].updateTime,
                        value: [
                            list[i].updateTime,
                            list[i].onlineCount
                        ]
                    });
                }
                return newData;
            }
        });

        var _data = newData;

        lineChart.setOption({
            series: [{
                data: _data
            }]
        });
    }

    window.onresize = function (e) {
        //pieChart.resize(e);
        lineChart.resize(e);
    }

    $(".lr-desktop-panel").mCustomScrollbar({ // 优化滚动条
        theme: "minimal-dark"
    });
});