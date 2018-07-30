/*
 * 日 期：2017.11.16
 * 描 述：时间轴方法（降序）
 */
$.fn.lrtimeline = function (op) {
    var dfop = {
        nodelist: [

        ]
    };
    $.extend(dfop, op || {});
    var $self = $(this);
    if ($self.length == 0) {
        return $self;
    }
    dfop.id = $self.attr('id');
    if (!dfop.id) {
        return false;
    }
    $self.addClass('ll-timeline');
    var $wrap = $('<div class="ll-timeline-allwrap"></div>');
    var $ul = $('<ul></ul>');

    // 开始节点
    var $begin = $('<li class="ll-timeline-header"><div>当前</div></li>')
    $ul.append($begin);

    // 中间节点
    var $li = $('<li class="ll-timeline-item" ><div class="ll-timeline-wrap ll-timeline-current" ></div></li>');
    var $itemwrap = $li.find('.ll-timeline-wrap');
    var $itemcontent = $('<div class="ll-timeline-content"><span class="arrow"></span></div>');
    $itemcontent.append('<div class="ll--timeline-title">普通节点审核</div>');
    $itemcontent.append('<div class="ll--timeline-body"><span>审核人</span>正在处理中!</div>')
    $itemwrap.append('<span class="ll-timeline-date">2017-08-28 16:18:33</span>');
    $itemwrap.append($itemcontent);
    $ul.append($li);
    // 结束节点
    $ul.append('<li class="ll-timeline-ender"><div>发起</div></li>');
    
    $wrap.html($ul);
    $self.html($wrap);

};