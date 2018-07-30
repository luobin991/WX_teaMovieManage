drop procedure if exists Pro_AddClud_daysum_diamond;
DELIMITER ;;
/*
	统计俱乐部钻石消耗
*/
create procedure Pro_AddClud_daysum_diamond()
begin
		declare _baseD bigint default 6;						#房主支付钻石的基数
		declare _AAD bigint default 2;						  #AA支付钻石的基数
		declare _clubId int default 0;
		declare _diamondSum bigint default 0;					#钻石总数

		declare _playSZ bigint default 0;					#牛牛上庄钻石总数
		declare _playGD bigint default 0;					#固定庄家钻石总数
		declare _playZY bigint default 0;					#自由抢庄钻石总数
		declare _playMP bigint default 0;					#明牌抢庄钻石总数
		declare _playTB bigint default 0;					#通比牛牛钻石总数
		declare _playLZ bigint default 0;				  #通比牛牛钻石总数

		declare _play10 bigint default 0;					#10局钻石总数
		declare _play20 bigint default 0;					#20局钻石总数

	 	#创建结束标志变量  
		declare done int default false;

		declare _startDate varchar(50) default CONCAT(DATE_SUB(DATE_SUB(CURDATE(),interval 0 day), interval 1 day),' 00:00:00');	#当前时间前一天 开始
		declare _endDate varchar(50) default CONCAT(DATE_SUB(CURDATE(), interval 1 day),' 23:59:59');		#当前时间前一天 结束

		#创建游标
 		declare cur cursor for SELECT clubId  from t_game_log where clubId > 0  and createTime between _startDate and _endDate  GROUP BY clubId;
	
		#指定游标循环结束时的返回值
		declare continue handler for not found set done = TRUE; 

		#打开游标  
		open cur;  
		#开始循环游标里的数据  
		read_loop:loop 
		#根据游标当前指向的一条数据  
		fetch cur into _clubId;
		if done then  
				leave read_loop;    #跳出游标循环  
		end if;  

				SELECT (count(*)* _baseD) into _diamondSum from t_game_log where clubId = _clubId AND createTime between _startDate and _endDate;
				SELECT (count(*)* _baseD) into _playSZ from t_game_log where clubId = _clubId AND bankerMode =1 AND createTime between _startDate and _endDate;
				SELECT (count(*)* _baseD) into _playGD from t_game_log where clubId = _clubId AND bankerMode =2 AND createTime between _startDate and _endDate;
				SELECT (count(*)* _baseD) into _playZY from t_game_log where clubId = _clubId AND bankerMode =3 AND createTime between _startDate and _endDate;
				SELECT (count(*)* _baseD) into _playMP from t_game_log where clubId = _clubId AND bankerMode =4 AND createTime between _startDate and _endDate;
				SELECT (count(*)* _baseD) into _playTB from t_game_log where clubId = _clubId AND bankerMode =5 AND createTime between _startDate and _endDate;
				SELECT (count(*)* _baseD) into _playLZ from t_game_log where clubId = _clubId AND bankerMode =6 AND createTime between _startDate and _endDate;

				SELECT (count(*)* _baseD) into _play10 from t_game_log where clubId = _clubId AND roundTotal =10 AND createTime between _startDate and _endDate;
				SELECT (count(*)* _baseD) into _play20 from t_game_log where clubId = _clubId AND roundTotal =20 AND createTime between _startDate and _endDate;


				#diamondType钻石类型:1消耗
				#type类别：1个人，2俱乐部
				INSERT INTO sys_daysum_diamond(type,typeId,diamond,diamondType,createTime,playSZ,playGD,playZY,playMP,playTB,playLZ,play10,play20)
				VALUES(1,_clubId,_diamondSum,1,_endDate,_playSZ,_playGD,_playZY,_playMP,_playTB,_playLZ,_play10,_play20);

		#结束游标循环  
		end loop;
		#关闭游标  
		close cur;
end
;;
DELIMITER ;

