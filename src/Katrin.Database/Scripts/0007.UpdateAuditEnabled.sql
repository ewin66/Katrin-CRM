
update Metadata_Entity set IsAuditEnabled=1 where EntityId in (
select EntityId from dbo.Metadata_Entity where TableName in ('Account','Contract','Contact',
'Invoice','Lead','Opportunity','Quote','QuoteLineItem','User'))

update Metadata_Attribute set IsAuditEnabled=1 where AttributeId 
in(
select AttributeId from dbo.Metadata_Attribute 
where EntityId in (select EntityId from dbo.Metadata_Entity where TableName in ('Account','Contract','Contact',
'Invoice','Lead','Opportunity','Quote','QuoteLineItem','User')))
