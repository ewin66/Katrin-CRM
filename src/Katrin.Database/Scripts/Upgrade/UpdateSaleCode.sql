update Opportunity set SalesStageCode = 
case when SalesStageCode >=9 then SalesStageCode-2
when SalesStageCode in(7,8) then SalesStageCode-3
when SalesStageCode in(4,5,6) then 3
when SalesStageCode in(2,3) then SalesStageCode-1 end