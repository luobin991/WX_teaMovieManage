


-- 开启定时器
show VARIABLES like 'event%';
set global event_scheduler = 1; 


/*
	俱乐部消耗详情
	每天凌晨02:00执行
*/
drop event if exists ReportTable_Clud_daysum_diamond;
DELIMITER ;;
create  event ReportTable_Clud_daysum_diamond
  on schedule every 1 day starts
    date_add(concat(current_date(),' 02:00:00'), interval 0 second)		-- 每天凌晨02:00开始执行
  on completion preserve enable																				-- 是创建此事件即开始自动执行
	-- comment '俱乐部消耗详情、每天凌晨02:00执行'
do
begin
	call Pro_AddClud_daysum_diamond();
end
;;
DELIMITER ;