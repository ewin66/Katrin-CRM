BEGIN TRANSACTION

------如果以code关键字结束一般都是optionset
UPDATE Metadata_Attribute SET OptionSetId = NULL WHERE PhysicalName LIKE '%Code'


delete from Metadata_LocalizedLabel where LocalizedLabelId in(
select distinct  a.LocalizedLabelId from Metadata_LocalizedLabel a  inner join Metadata_AttributePicklistValue b
on a.ObjectId = b.AttributePicklistValueId)--删除optionset的具体值

DELETE FROM Metadata_AttributePicklistValueMap
DELETE FROM Metadata_AttributePicklistValue
DELETE FROM Metadata_OptionSet

---------------------初始化optionSet数据
DECLARE @optionsetId nvarchar(100)


-----------------account_accountcategorycode 帐户类型
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) 
VALUES(@optionsetId,'account_accountcategorycode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A1', 1, 0, @optionsetId)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A2', 2, 1, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A1', N'DisplayName', N'Preferred Customer')

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A2', N'DisplayName', N'Standard')

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A1', N'DisplayName', N'优惠客户')

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A2', N'DisplayName', N'标准客户')

UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'AccountCategoryCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Account')

----------------------------lead_leadsourcecode-----------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'lead_leadsourcecode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A3', 1, 0, @optionsetId)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A4', 2, 1, @optionsetId)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A5', 3, 2, @optionsetId)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A6', 4, 3, @optionsetId)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A7', 5, 4, @optionsetId)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A8', 6, 5, @optionsetId)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A9', 7, 6, @optionsetId)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434B1', 8, 7, @optionsetId)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434B2', 9, 8, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A3', N'DisplayName', N'Web Site')

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A4', N'DisplayName', N'Head Office')

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A5', N'DisplayName', N'Existing Customer')

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A6', N'DisplayName', N'Cold Call')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A7', N'DisplayName', N'Partner')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A8', N'DisplayName', N'Self Generated')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A9', N'DisplayName', N'Employee')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434B1', N'DisplayName', N'Email')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434B2', N'DisplayName', N'Other')

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A3', N'DisplayName', N'官网网址')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A4', N'DisplayName', N'总部')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A5', N'DisplayName', N'现有客户')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A6', N'DisplayName', N'陌生电话')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A7', N'DisplayName', N'合作伙伴 ')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A8', N'DisplayName', N'自生')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434A9', N'DisplayName', N'员工')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434B1', N'DisplayName', N'邮件')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434B2', N'DisplayName', N'其他')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'LeadSourceCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Lead')

------------------------------------------lead_CountryCode----------------------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'lead_CountryCode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
VALUES (N'F5D40712-256C-405A-9CE2-0968068FDAD1', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
VALUES (N'F5D40712-256C-405A-9CE2-0968068FDAD2', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
VALUES (N'F5D40712-256C-405A-9CE2-0968068FDAD3', 3, 2, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
VALUES (N'F5D40712-256C-405A-9CE2-0968068FDAD4', 4, 3, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
VALUES (N'F5D40712-256C-405A-9CE2-0968068FDAD5', 5, 4, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
VALUES (N'F5D40712-256C-405A-9CE2-0968068FDAD6', 6, 5, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
VALUES (N'F5D40712-256C-405A-9CE2-0968068FDAD7', 7, 6, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
VALUES (N'F5D40712-256C-405A-9CE2-0968068FDAD8', 8, 7, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
VALUES (N'F5D40712-256C-405A-9CE2-0968068FDAD9', 9, 8, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'F5D40712-256C-405A-9CE2-0968068FDAD1', N'DisplayName', N'USA')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'F5D40712-256C-405A-9CE2-0968068FDAD2', N'DisplayName', N'England')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'F5D40712-256C-405A-9CE2-0968068FDAD3', N'DisplayName', N'Canada')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'F5D40712-256C-405A-9CE2-0968068FDAD4', N'DisplayName', N'Australia')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'F5D40712-256C-405A-9CE2-0968068FDAD5', N'DisplayName', N'Germany')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'F5D40712-256C-405A-9CE2-0968068FDAD6', N'DisplayName', N'Switzerland')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'F5D40712-256C-405A-9CE2-0968068FDAD7', N'DisplayName', N'Norway')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'F5D40712-256C-405A-9CE2-0968068FDAD8', N'DisplayName', N'Denmark')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'F5D40712-256C-405A-9CE2-0968068FDAD9', N'DisplayName', N'OtherCountry')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'F5D40712-256C-405A-9CE2-0968068FDAD1', N'DisplayName', N'美国')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'F5D40712-256C-405A-9CE2-0968068FDAD2', N'DisplayName', N'英国')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'F5D40712-256C-405A-9CE2-0968068FDAD3', N'DisplayName', N'加拿大')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'F5D40712-256C-405A-9CE2-0968068FDAD4', N'DisplayName', N'澳大利亚')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'F5D40712-256C-405A-9CE2-0968068FDAD5', N'DisplayName', N'德国')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'F5D40712-256C-405A-9CE2-0968068FDAD6', N'DisplayName', N'瑞士')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'F5D40712-256C-405A-9CE2-0968068FDAD7', N'DisplayName', N'挪威')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'F5D40712-256C-405A-9CE2-0968068FDAD8', N'DisplayName', N'丹麦')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'F5D40712-256C-405A-9CE2-0968068FDAD9', N'DisplayName', N'其它国家') 
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'CountryCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Lead')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'CountryCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Account')

------------------------------------------------------account_accountclassificationcode--------------------------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'account_accountclassificationcode',1)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434B4', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434B4', N'DisplayName', N'Default Value')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434B4', N'DisplayName', N'默认值')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'AccountClassificationCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Account')


------------------------------------------------account_accountratingcode---------------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'account_accountratingcode',1)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-D8603C7434B0', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-D8603C7434B1', 2, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-D8603C7434B2', 3, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-D8603C7434B0', N'DisplayName', N'Gold')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-D8603C7434B1', N'DisplayName', N'Silver')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-D8603C7434B2', N'DisplayName', N'Copper')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-D8603C7434B0', N'DisplayName', N'蓝星')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-D8603C7434B1', N'DisplayName', N'绿星')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-D8603C7434B2', N'DisplayName', N'黄星')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'AccountRatingCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Account')


-------------------------------------account_businesstypecode---------------------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'account_businesstypecode',1)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434B6', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434B6', N'DisplayName', N'Default Value')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434B6', N'DisplayName', N'默认值')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'BusinessTypeCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Account')

---------------------------------account_customersizecode--------------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'account_customersizecode',1)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434B7', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434B7', N'DisplayName', N'Default Value')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434B7', N'DisplayName', N'默认值')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'CustomerSizeCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Account')

---------------------------------------------------account_customertypecode----------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'account_customertypecode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434B8', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434B9', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C1', 3, 2, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C2', 4, 3, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C3', 5, 4, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C4', 6, 5, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C5', 7, 6, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C6', 8, 7, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C7', 9, 8, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C8', 10, 9, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C9', 11, 10, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D1', 12, 11, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434B8', N'DisplayName', N'Competitor')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434B9', N'DisplayName', N'Consultant')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C1', N'DisplayName', N'Customer')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C2', N'DisplayName', N'Investor')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C3', N'DisplayName', N'Partner')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C4', N'DisplayName', N'Influencer')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C5', N'DisplayName', N'Press')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C6', N'DisplayName', N'Prospect')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C7', N'DisplayName', N'Reseller')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C8', N'DisplayName', N'Supplier')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C9', N'DisplayName', N'Vendor')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D1', N'DisplayName', N'Other')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434B8', N'DisplayName', N'竞争对手')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434B9', N'DisplayName', N'顾问')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C1', N'DisplayName', N'顾客')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C2', N'DisplayName', N'投资者')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C3', N'DisplayName', N'合伙人')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C4', N'DisplayName', N'影响者')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C5', N'DisplayName', N'继续者')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C6', N'DisplayName', N'观望者')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C7', N'DisplayName', N'中间商')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C8', N'DisplayName', N'供应商')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434C9', N'DisplayName', N'卖方')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D1', N'DisplayName', N'其他')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'CustomerTypeCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Account')

-----------------------------------------------------------account_industrycode-----------------------------------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'account_industrycode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D2', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D3', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D4', 3, 2, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D5', 4, 3, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D6', 5, 4, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D7', 6, 5, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D8', 7, 6, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D9', 8, 7, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E1', 9, 8, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E2', 10, 9, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E3', 11, 10, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E4', 12, 11, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E5', 13, 12, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E6', 14, 13, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E7', 15, 14, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E8', 16, 15, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E9', 17, 16, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F1', 18, 17, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F2', 19, 18, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F3', 20, 19, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F4', 21, 20, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F5', 22, 21, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F6', 23, 22, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F7', 24, 23, @optionsetId)
--INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F8', 25, 24, @optionsetId)
--INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F9', 26, 25, @optionsetId)
--INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743401', 27, 26, @optionsetId)
--INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743402', 28, 27, @optionsetId)
--INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743403', 29, 28, @optionsetId)
--INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743404', 30, 29, @optionsetId)
--INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743405', 31, 30, @optionsetId)
--INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743406', 32, 31, @optionsetId)
--INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743407', 33, 32, @optionsetId)


INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D2', N'DisplayName', N'Energy')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D3', N'DisplayName', N'Materials')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D4', N'DisplayName', N'Capital Goods')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D5', N'DisplayName', N'Commercial&Professional Services')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D6', N'DisplayName', N'Transportation')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D7', N'DisplayName', N'Automobiles and Components')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D8', N'DisplayName', N'Consumer Durables and Apparel')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D9', N'DisplayName', N'Consumer Services')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E1', N'DisplayName', N'Media')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E2', N'DisplayName', N'Retailing')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E3', N'DisplayName', N'Food&Staples Retailing')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E4', N'DisplayName', N'Food, Beverage&Tobacco')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E5', N'DisplayName', N'Household&Personal Products')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E6', N'DisplayName', N'Health Care Equipment&Services')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E7', N'DisplayName', N'Pharmaceuticals, Biotechnology&Life Sciences')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E8', N'DisplayName', N'Banks')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E9', N'DisplayName', N'Diversified Financials')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F1', N'DisplayName', N'Insurance')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F2', N'DisplayName', N'Real Estate')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F3', N'DisplayName', N'Software&Services')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F4', N'DisplayName', N'Technology Hardware&Equipment')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F5', N'DisplayName', N'Semiconductors&Semiconductor Equipment')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F6', N'DisplayName', N'Telecommunication Services')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F7', N'DisplayName', N'Utilities')

--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F8', N'DisplayName', N'Service Retail')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F9', N'DisplayName', N'SIG Affiliations')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743401', N'DisplayName', N'Social Services')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743402', N'DisplayName', N'Special Outbound Trade Contractors')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743403', N'DisplayName', N'Specialty Realty')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743404', N'DisplayName', N'Transportation')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743405', N'DisplayName', N'Utility Creation and Distribution')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743406', N'DisplayName', N'Vehicle Retail')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743407', N'DisplayName', N'Wholesale')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D2', N'DisplayName', N'能源')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D3', N'DisplayName', N'材料')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D4', N'DisplayName', N'资本货物')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D5', N'DisplayName', N'商业与专业服务')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D6', N'DisplayName', N'交通运输')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D7', N'DisplayName', N'汽车及其零部件')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D8', N'DisplayName', N'耐用消费品和服装')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434D9', N'DisplayName', N'消费者服务')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E1', N'DisplayName', N'媒体')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E2', N'DisplayName', N'零售')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E3', N'DisplayName', N'食品与主要用品零售')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E4', N'DisplayName', N'食品、饮料及烟草制品')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E5', N'DisplayName', N'家居及个人用品')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E6', N'DisplayName', N'卫生保健设备和服务')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E7', N'DisplayName', N'制药、生物技术和生命科学')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E8', N'DisplayName', N'银行')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434E9', N'DisplayName', N'多元化金融')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F1', N'DisplayName', N'保险')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F2', N'DisplayName', N'房地产')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F3', N'DisplayName', N'软件与服务')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F4', N'DisplayName', N'技术硬件及设备')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F5', N'DisplayName', N'半导体和半导体设备')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F6', N'DisplayName', N'电信服务')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F7', N'DisplayName', N'公用事业')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F8', N'DisplayName', N'零售服务业')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C7434F9', N'DisplayName', N'SIG联盟')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743401', N'DisplayName', N'社会公益服务业')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743402', N'DisplayName', N'特定境外贸易承包商')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743403', N'DisplayName', N'专业物业')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743404', N'DisplayName', N'运输业')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743405', N'DisplayName', N'实用创造分配业')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743406', N'DisplayName', N'汽车零售业')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743407', N'DisplayName', N'批发业')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'IndustryCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Account')

-----------------------------------------------------account_ownershipcode-----------------------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'account_ownershipcode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743408', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743409', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743410', 3, 2, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743411', 4, 3, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743408', N'DisplayName', N'Public')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743409', N'DisplayName', N'Private')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743410', N'DisplayName', N'Subsidiary')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743411', N'DisplayName', N'Other')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743408', N'DisplayName', N'公开')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743409', N'DisplayName', N'私有')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743410', N'DisplayName', N'附属')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743411', N'DisplayName', N'其他')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'OwnershipCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Account')

------------------------------------------------------------contact_accountrolecode---------------------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'contact_accountrolecode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743412', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743413', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743414', 3, 2, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743412', N'DisplayName', N'Decision Maker')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743413', N'DisplayName', N'Employee')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743414', N'DisplayName', N'Influencer')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743412', N'DisplayName', N'决策者')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743413', N'DisplayName', N'员工')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743414', N'DisplayName', N'影响者')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'AccountRoleCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Contact')

----------------------------------------------contact_educationcode----------------------------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'contact_educationcode',1)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743415', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743415', N'DisplayName', N'Default Value')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743415', N'DisplayName', N'默认值')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'EducationCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Contact')

--------------------------------------------------------contact_familystatuscode-----------------------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'contact_familystatuscode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743416', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743417', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743418', 3, 2, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743419', 4, 3, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743416', N'DisplayName', N'Single')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743417', N'DisplayName', N'Married')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743418', N'DisplayName', N'Divorced')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743419', N'DisplayName', N'Widowed')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743416', N'DisplayName', N'单身')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743417', N'DisplayName', N'已婚')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743418', N'DisplayName', N'离异')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743419', N'DisplayName', N'丧偶')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'FamilyStatusCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Contact')

-------------------------------------------contact_gendercode---------------------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'contact_gendercode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743420', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743421', 2, 1, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743420', N'DisplayName', N'Male')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743421', N'DisplayName', N'Female')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743420', N'DisplayName', N'男')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743421', N'DisplayName', N'女')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'GenderCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Contact')

------------------------------------------------------contact_haschildrencode---------------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'contact_haschildrencode',1)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743422', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743422', N'DisplayName', N'Default Value')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743422', N'DisplayName', N'默认值')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'HasChildrenCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Contact')

-----------------------------------------------------------opportunity_opportunityratingcode-----------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'opportunity_opportunityratingcode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743423', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743424', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743425', 3, 2, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743423', N'DisplayName', N'Hot')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743424', N'DisplayName', N'Warm')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743425', N'DisplayName', N'Cold')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743423', N'DisplayName', N'大有希望')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743424', N'DisplayName', N'有希望')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743425', N'DisplayName', N'希望渺茫')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'OpportunityRatingCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Opportunity')

-----------------------------------------------------opportunity_opportunitytypecode--------------------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'opportunity_opportunitytypecode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'227430C0-4733-4CB2-B055-34B3E4615F06', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'227430C0-4733-4CB2-B055-34B3E4615F07', 2, 1, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'227430C0-4733-4CB2-B055-34B3E4615F06', N'DisplayName', N'Existing Business')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'227430C0-4733-4CB2-B055-34B3E4615F07', N'DisplayName', N'New Business')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'227430C0-4733-4CB2-B055-34B3E4615F06', N'DisplayName', N'现有业务')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'227430C0-4733-4CB2-B055-34B3E4615F07', N'DisplayName', N'新业务')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'OpportunityTypeCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Opportunity')

----------------------------------------------------opportunity_prioritycode--------------------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'opportunity_prioritycode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743431', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743432', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743433', 3, 2, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743434', 4, 3, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D5E68D-23FF-43BD-AFA1-A8603C743435', 5, 3, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743431', N'DisplayName', N'Very High')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743432', N'DisplayName', N'High')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743433', N'DisplayName', N'Normal')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743434', N'DisplayName', N'Worthy of a Try')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D5E68D-23FF-43BD-AFA1-A8603C743435', N'DisplayName', N'Hopeless')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743431', N'DisplayName', N'非常高')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743432', N'DisplayName', N'高')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743433', N'DisplayName', N'一般')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743434', N'DisplayName', N'值得一试')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D5E68D-23FF-43BD-AFA1-A8603C743435', N'DisplayName', N'没希望')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'PriorityCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Opportunity')

-------------------------------------------------------------opportunity_salesstagecode--------------------------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'opportunity_salesstagecode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'923AFEA4-6ABA-4525-8B6D-B8734C700790', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'923AFEA4-6ABA-4525-8B6D-B8734C700791', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'923AFEA4-6ABA-4525-8B6D-B8734C700792', 3, 2, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'923AFEA4-6ABA-4525-8B6D-B8734C700793', 4, 3, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'923AFEA4-6ABA-4525-8B6D-B8734C700794', 5, 4, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'923AFEA4-6ABA-4525-8B6D-B8734C700795', 6, 5, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'923AFEA4-6ABA-4525-8B6D-B8734C700796', 7, 6, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'923AFEA4-6ABA-4525-8B6D-B8734C700797', 8, 7, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'923AFEA4-6ABA-4525-8B6D-B8734C700790', N'DisplayName', N'Vendor Evaluate')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'923AFEA4-6ABA-4525-8B6D-B8734C700791', N'DisplayName', N'Needs Analysis')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'923AFEA4-6ABA-4525-8B6D-B8734C700792', N'DisplayName', N'Needs Discuss')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'923AFEA4-6ABA-4525-8B6D-B8734C700793', N'DisplayName', N'Proposal/Price Quote')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'923AFEA4-6ABA-4525-8B6D-B8734C700794', N'DisplayName', N'Negotiation/Review')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'923AFEA4-6ABA-4525-8B6D-B8734C700795', N'DisplayName', N'free trial')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'923AFEA4-6ABA-4525-8B6D-B8734C700796', N'DisplayName', N'Closed Won')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'923AFEA4-6ABA-4525-8B6D-B8734C700797', N'DisplayName', N'Closed Lost')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'923AFEA4-6ABA-4525-8B6D-B8734C700790', N'DisplayName', N'供应商评估')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'923AFEA4-6ABA-4525-8B6D-B8734C700791', N'DisplayName', N'需求分析')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'923AFEA4-6ABA-4525-8B6D-B8734C700792', N'DisplayName', N'需求讨论')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'923AFEA4-6ABA-4525-8B6D-B8734C700793', N'DisplayName', N'建议/报价')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'923AFEA4-6ABA-4525-8B6D-B8734C700794', N'DisplayName', N'协商/审核')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'923AFEA4-6ABA-4525-8B6D-B8734C700795', N'DisplayName', N'免费试用')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'923AFEA4-6ABA-4525-8B6D-B8734C700796', N'DisplayName', N'成功结束')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'923AFEA4-6ABA-4525-8B6D-B8734C700797', N'DisplayName', N'失败终止')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'SalesStageCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Opportunity')

--------------------------------------------------lead_statuscode-------------------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'lead_statuscode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'F5B9AFE5-E55D-4DFA-B52D-B73631288B40', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'F5B9AFE5-E55D-4DFA-B52D-B73631288B41', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'F5B9AFE5-E55D-4DFA-B52D-B73631288B42', 3, 2, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'F5B9AFE5-E55D-4DFA-B52D-B73631288B43', 4, 3, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'F5B9AFE5-E55D-4DFA-B52D-B73631288B44', 5, 4, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'F5B9AFE5-E55D-4DFA-B52D-B73631288B45', 6, 5, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'F5B9AFE5-E55D-4DFA-B52D-B73631288B40', N'DisplayName', N'New')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'F5B9AFE5-E55D-4DFA-B52D-B73631288B41', N'DisplayName', N'Assigned')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'F5B9AFE5-E55D-4DFA-B52D-B73631288B42', N'DisplayName', N'In Process')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'F5B9AFE5-E55D-4DFA-B52D-B73631288B43', N'DisplayName', N'Converted')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'F5B9AFE5-E55D-4DFA-B52D-B73631288B44', N'DisplayName', N'Recycled')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'F5B9AFE5-E55D-4DFA-B52D-B73631288B45', N'DisplayName', N'Dead')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'F5B9AFE5-E55D-4DFA-B52D-B73631288B40', N'DisplayName', N'全新')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'F5B9AFE5-E55D-4DFA-B52D-B73631288B41', N'DisplayName', N'指派')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'F5B9AFE5-E55D-4DFA-B52D-B73631288B42', N'DisplayName', N'处理中')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'F5B9AFE5-E55D-4DFA-B52D-B73631288B43', N'DisplayName', N'转换')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'F5B9AFE5-E55D-4DFA-B52D-B73631288B44', N'DisplayName', N'再次联系')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'F5B9AFE5-E55D-4DFA-B52D-B73631288B45', N'DisplayName', N'终止')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'StatusCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Lead')

-----------------------------------------------------------account_statuscode--------------------------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'account_statuscode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'49DC7317-6C18-4D2B-94FA-627D6458E3B0', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'49DC7317-6C18-4D2B-94FA-627D6458E3B1', 2, 1, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'49DC7317-6C18-4D2B-94FA-627D6458E3B0', N'DisplayName', N'Active')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'49DC7317-6C18-4D2B-94FA-627D6458E3B1', N'DisplayName', N'Inactive')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'49DC7317-6C18-4D2B-94FA-627D6458E3B0', N'DisplayName', N'有效')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'49DC7317-6C18-4D2B-94FA-627D6458E3B1', N'DisplayName', N'无效')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'StatusCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Account')

------------------------------------------------------contact_statuscode----------------------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'contact_statuscode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56B43E6D-2659-4F12-8538-A34803B342F1', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56B43E6D-2659-4F12-8538-A34803B342F2', 2, 1, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56B43E6D-2659-4F12-8538-A34803B342F1', N'DisplayName', N'Active')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56B43E6D-2659-4F12-8538-A34803B342F2', N'DisplayName', N'Inactive')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56B43E6D-2659-4F12-8538-A34803B342F1', N'DisplayName', N'有效')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56B43E6D-2659-4F12-8538-A34803B342F2', N'DisplayName', N'无效')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'StatusCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Contact')

---------------------------------------------------------opportunity_statuscode---------------------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'opportunity_statuscode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'70FD1ABF-FC70-46DC-861A-A915EFFA1181', 1, 0, @optionsetId)
--INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'70FD1ABF-FC70-46DC-861A-A915EFFA1182', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'70FD1ABF-FC70-46DC-861A-A915EFFA1183', 3, 2, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'70FD1ABF-FC70-46DC-861A-A915EFFA1184', 4, 3, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'70FD1ABF-FC70-46DC-861A-A915EFFA1181', N'DisplayName', N'In Progress')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'70FD1ABF-FC70-46DC-861A-A915EFFA1182', N'DisplayName', N'On Hold')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'70FD1ABF-FC70-46DC-861A-A915EFFA1183', N'DisplayName', N'Won')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'70FD1ABF-FC70-46DC-861A-A915EFFA1184', N'DisplayName', N'Lost')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'70FD1ABF-FC70-46DC-861A-A915EFFA1181', N'DisplayName', N'在进行中')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'70FD1ABF-FC70-46DC-861A-A915EFFA1182', N'DisplayName', N'保留')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'70FD1ABF-FC70-46DC-861A-A915EFFA1183', N'DisplayName', N'成功')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'70FD1ABF-FC70-46DC-861A-A915EFFA1184', N'DisplayName', N'失败')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'StatusCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Opportunity')

-----------------------------------------------------------lead_prioritycode--------------------------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'lead_prioritycode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'701D1ABF-FC70-46DC-861A-A915EFFA1181', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'701D1ABF-FC70-46DC-861A-A915EFFA1182', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'701D1ABF-FC70-46DC-861A-A915EFFA1183', 3, 2, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'701D1ABF-FC70-46DC-861A-A915EFFA1184', 4, 3, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'701D1ABF-FC70-46DC-861A-A915EFFA1185', 5, 3, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'701D1ABF-FC70-46DC-861A-A915EFFA1181', N'DisplayName', N'Very High')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'701D1ABF-FC70-46DC-861A-A915EFFA1182', N'DisplayName', N'High')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'701D1ABF-FC70-46DC-861A-A915EFFA1183', N'DisplayName', N'Normal')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'701D1ABF-FC70-46DC-861A-A915EFFA1184', N'DisplayName', N'Worthy of a Try')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'701D1ABF-FC70-46DC-861A-A915EFFA1185', N'DisplayName', N'Hopeless')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'701D1ABF-FC70-46DC-861A-A915EFFA1181', N'DisplayName', N'非常高')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'701D1ABF-FC70-46DC-861A-A915EFFA1182', N'DisplayName', N'高')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'701D1ABF-FC70-46DC-861A-A915EFFA1183', N'DisplayName', N'一般')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'701D1ABF-FC70-46DC-861A-A915EFFA1184', N'DisplayName', N'值得一试')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'701D1ABF-FC70-46DC-861A-A915EFFA1185', N'DisplayName', N'没希望')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'PriorityCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Lead')

--------------------------------------------------------quote_stagecode-------------------------------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'quote_stagecode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'781D1ABF-FC70-46DC-861A-A915EFFA1181', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'781D1ABF-FC70-46DC-861A-A915EFFA1182', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'781D1ABF-FC70-46DC-861A-A915EFFA1183', 3, 2, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'781D1ABF-FC70-46DC-861A-A915EFFA1184', 4, 3, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'781D1ABF-FC70-46DC-861A-A915EFFA1185', 5, 4, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'781D1ABF-FC70-46DC-861A-A915EFFA1186', 6, 5, @optionsetId)
--INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'722D1CBF-FC70-46DC-861A-A915EFFA1185', 7, 6, @optionsetId)
--INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'732D1CBF-FC70-46DC-861A-A915EFFA1185', 8, 7, @optionsetId)


INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'781D1ABF-FC70-46DC-861A-A915EFFA1181', N'DisplayName', N'Draft')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'781D1ABF-FC70-46DC-861A-A915EFFA1182', N'DisplayName', N'Delivered')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'781D1ABF-FC70-46DC-861A-A915EFFA1183', N'DisplayName', N'Closed Accepted')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'781D1ABF-FC70-46DC-861A-A915EFFA1184', N'DisplayName', N'Re-quote')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'781D1ABF-FC70-46DC-861A-A915EFFA1185', N'DisplayName', N'Closed Dead')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'781D1ABF-FC70-46DC-861A-A915EFFA1186', N'DisplayName', N'Closed Lost')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'781D1ABF-FC70-46DC-861A-A915EFFA1181', N'DisplayName', N'草案')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'781D1ABF-FC70-46DC-861A-A915EFFA1182', N'DisplayName', N'已提交')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'781D1ABF-FC70-46DC-861A-A915EFFA1183', N'DisplayName', N'已接受')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'781D1ABF-FC70-46DC-861A-A915EFFA1184', N'DisplayName', N'重新报价')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'781D1ABF-FC70-46DC-861A-A915EFFA1185', N'DisplayName', N'报价失败')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'781D1ABF-FC70-46DC-861A-A915EFFA1186', N'DisplayName', N'报价流失')

--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'781D1ABF-FC70-46DC-861A-A915EFFA1181', N'DisplayName', N'草案')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'781D1ABF-FC70-46DC-861A-A915EFFA1182', N'DisplayName', N'谈判中')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'781D1ABF-FC70-46DC-861A-A915EFFA1183', N'DisplayName', N'已提交')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'781D1ABF-FC70-46DC-861A-A915EFFA1184', N'DisplayName', N'搁置')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'781D1ABF-FC70-46DC-861A-A915EFFA1185', N'DisplayName', N'已确认')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'791D1ABF-FC70-46DC-861A-A915EFFA1185', N'DisplayName', N'已接受')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'722D1CBF-FC70-46DC-861A-A915EFFA1185', N'DisplayName', N'报价流失')
--INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'732D1CBF-FC70-46DC-861A-A915EFFA1185', N'DisplayName', N'报价失败')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'StageCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Quote')

-----------------------------------------------------quote_statuscode
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'quote_statuscode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'781D1EBF-FC70-46DC-861A-A915EFFA1181', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'781D1EBF-FC70-46DC-861A-A915EFFA1182', 2, 1, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'781D1EBF-FC70-46DC-861A-A915EFFA1181', N'DisplayName', N'Approved')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'781D1EBF-FC70-46DC-861A-A915EFFA1182', N'DisplayName', N'Not Approved')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'781D1EBF-FC70-46DC-861A-A915EFFA1181', N'DisplayName', N'被认可')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'781D1EBF-FC70-46DC-861A-A915EFFA1182', N'DisplayName', N'不被认可')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'StatusCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Quote')

-----------------------------------------------------quote_paymenttermscode
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'quote_paymenttermscode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'781D1EfF-FC70-46DC-861A-A915EFFA1181', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'781D1EfF-FC70-46DC-861A-A915EFFA1182', 2, 1, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'781D1EfF-FC70-46DC-861A-A915EFFA1181', N'DisplayName', N'Net 15')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'781D1EfF-FC70-46DC-861A-A915EFFA1182', N'DisplayName', N'Net 30')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'781D1EfF-FC70-46DC-861A-A915EFFA1181', N'DisplayName', N'见票后15天支付')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'781D1EfF-FC70-46DC-861A-A915EFFA1182', N'DisplayName', N'见票后30天支付')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'PaymentTermsCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Quote')

-----------------------------------------------------------contract_statuscode----------------
SET @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'contract_statuscode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'962E9B66-47DD-4747-A786-A7B163DF2431', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'962E9B66-47DD-4747-A786-A7B163DF2432', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'962E9B66-47DD-4747-A786-A7B163DF2433', 3, 2, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'962E9B66-47DD-4747-A786-A7B163DF2434', 4, 3, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'962E9B66-47DD-4747-A786-A7B163DF2435', 5, 4, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'962E9B66-47DD-4747-A786-A7B163DF2431', N'DisplayName', N'Prepare')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'962E9B66-47DD-4747-A786-A7B163DF2432', N'DisplayName', N'Working')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'962E9B66-47DD-4747-A786-A7B163DF2433', N'DisplayName', N'Finished')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'962E9B66-47DD-4747-A786-A7B163DF2434', N'DisplayName', N'Closed')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'962E9B66-47DD-4747-A786-A7B163DF2435', N'DisplayName', N'Failed')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'962E9B66-47DD-4747-A786-A7B163DF2431', N'DisplayName', N'准备')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'962E9B66-47DD-4747-A786-A7B163DF2432', N'DisplayName', N'工作中')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'962E9B66-47DD-4747-A786-A7B163DF2433', N'DisplayName', N'完成')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'962E9B66-47DD-4747-A786-A7B163DF2434', N'DisplayName', N'关闭')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'962E9B66-47DD-4747-A786-A7B163DF2435', N'DisplayName', N'已失效')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'StatusCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Contract')

-----------------------------------------------------------contract_customerSatisfactionCode----------------
SET @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'contract_customerSatisfactionCode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D24197-CC92-4460-A774-CC6ED4DBEE60', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D24197-CC92-4460-A774-CC6ED4DBEE61', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D24197-CC92-4460-A774-CC6ED4DBEE62', 3, 2, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D24197-CC92-4460-A774-CC6ED4DBEE63', 4, 3, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'C7D24197-CC92-4460-A774-CC6ED4DBEE64', 5, 4, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D24197-CC92-4460-A774-CC6ED4DBEE60', N'DisplayName', N'Very satisfied, highly praised by customers')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D24197-CC92-4460-A774-CC6ED4DBEE61', N'DisplayName', N'Satisfaction with follow-up project')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D24197-CC92-4460-A774-CC6ED4DBEE62', N'DisplayName', N'So-so, completed on schedule')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D24197-CC92-4460-A774-CC6ED4DBEE63', N'DisplayName', N'Not good, customer have complains')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'C7D24197-CC92-4460-A774-CC6ED4DBEE64', N'DisplayName', N'Very bad, the customer refused payment')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D24197-CC92-4460-A774-CC6ED4DBEE60', N'DisplayName', N'非常满意， 客户高度称赞')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D24197-CC92-4460-A774-CC6ED4DBEE61', N'DisplayName', N'满意，有后续项目')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D24197-CC92-4460-A774-CC6ED4DBEE62', N'DisplayName', N'一般，项目按期完成')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D24197-CC92-4460-A774-CC6ED4DBEE63', N'DisplayName', N'较差，客户有较多抱怨')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'C7D24197-CC92-4460-A774-CC6ED4DBEE64', N'DisplayName', N'非常差，客户拒付款')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'CustomerSatisfactionCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Contract')

-----------------------------------------------------------contract_EndTypeCode----------------
SET @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'contract_EndTypeCode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'67D4AE41-C224-4433-9EDB-FB1A167BB781', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'67D4AE41-C224-4433-9EDB-FB1A167BB782', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'67D4AE41-C224-4433-9EDB-FB1A167BB783', 3, 2, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'67D4AE41-C224-4433-9EDB-FB1A167BB781', N'DisplayName', N'Closed on schedule')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'67D4AE41-C224-4433-9EDB-FB1A167BB782', N'DisplayName', N'Taken a long time')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'67D4AE41-C224-4433-9EDB-FB1A167BB783', N'DisplayName', N'Arrears outstanding')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'67D4AE41-C224-4433-9EDB-FB1A167BB781', N'DisplayName', N'按时结项')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'67D4AE41-C224-4433-9EDB-FB1A167BB782', N'DisplayName', N'结项耗时较久')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'67D4AE41-C224-4433-9EDB-FB1A167BB783', N'DisplayName', N'有欠款未付')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'EndTypeCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Contract')

----------------------------------------------invoice_statuscode---------------------
SET @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'invoice_statuscode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'962E9B66-47DD-4747-A786-A7B163DF2441', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'962E9B66-47DD-4747-A786-A7B163DF2442', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'962E9B66-47DD-4747-A786-A7B163DF2443', 3, 2, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'962E9B66-47DD-4747-A786-A7B163DF2444', 4, 3, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'962E9B66-47DD-4747-A786-A7B163DF2445', 5, 4, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'962E9B66-47DD-4747-A786-A7B163DF2441', N'DisplayName', N'Sent')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'962E9B66-47DD-4747-A786-A7B163DF2442', N'DisplayName', N'Paid')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'962E9B66-47DD-4747-A786-A7B163DF2443', N'DisplayName', N'In Arrear')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'962E9B66-47DD-4747-A786-A7B163DF2444', N'DisplayName', N'Bad Debts')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'962E9B66-47DD-4747-A786-A7B163DF2445', N'DisplayName', N'Plan')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'962E9B66-47DD-4747-A786-A7B163DF2441', N'DisplayName', N'已寄送')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'962E9B66-47DD-4747-A786-A7B163DF2442', N'DisplayName', N'已付款')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'962E9B66-47DD-4747-A786-A7B163DF2443', N'DisplayName', N'拖欠尾款')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'962E9B66-47DD-4747-A786-A7B163DF2444', N'DisplayName', N'坏账')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'962E9B66-47DD-4747-A786-A7B163DF2445', N'DisplayName', N'计划')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'StatusCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Invoice')

-----------------------------------------product_statuscode---------------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'product_statuscode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'01A4BEC3-FFA2-4503-8AAB-07A95A32C871', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'01A4BEC3-FFA2-4503-8AAB-07A95A32C872', 2, 1, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'01A4BEC3-FFA2-4503-8AAB-07A95A32C871', N'DisplayName', N'Active')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'01A4BEC3-FFA2-4503-8AAB-07A95A32C872', N'DisplayName', N'Inactive')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'01A4BEC3-FFA2-4503-8AAB-07A95A32C871', N'DisplayName', N'有效')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'01A4BEC3-FFA2-4503-8AAB-07A95A32C872', N'DisplayName', N'无效')

UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'StatusCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Product')


-----------------------------------opportunity_projecttypecode-----------------------
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'opportunity_projecttypecode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'99744921-CA85-4112-B815-F01A306152E5', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'99744921-CA85-4112-B815-F01A306152E6', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'99744921-CA85-4112-B815-F01A306152E7', 3, 2, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'99744921-CA85-4112-B815-F01A306152E8', 4, 3, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'99744921-CA85-4112-B815-F01A306152E5', N'DisplayName', N'Fixed-bid')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'99744921-CA85-4112-B815-F01A306152E6', N'DisplayName', N'T&M')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'99744921-CA85-4112-B815-F01A306152E7', N'DisplayName', N'ODC')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'99744921-CA85-4112-B815-F01A306152E8', N'DisplayName', N'TBD')


UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'ProjectTypeCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Opportunity')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'ProjectTypeCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Project')



set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'opportunity_technologycode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'54D8465B-665E-459A-A8E3-187AE973F4C1', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'54D8465B-665E-459A-A8E3-187AE973F4C2', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'54D8465B-665E-459A-A8E3-187AE973F4C3', 3, 2, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'54D8465B-665E-459A-A8E3-187AE973F4C4', 4, 3, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'54D8465B-665E-459A-A8E3-187AE973F4C5', 5, 4, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'54D8465B-665E-459A-A8E3-187AE973F4C6', 6, 5, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'54D8465B-665E-459A-A8E3-187AE973F4C7', 7, 6, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'54D8465B-665E-459A-A8E3-187AE973F4C8', 8, 7, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'54D8465B-665E-459A-A8E3-187AE973F4C9', 9, 8, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'EED80BD8-8E8D-4DA0-931B-09F97AA2DDBF', 10, 9, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'5C9B5D54-9C4E-48C0-B53C-461198D7000C', 11, 10, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'54D8465B-665E-459A-A8E3-187AE973F4C1', N'DisplayName', N'VB')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'54D8465B-665E-459A-A8E3-187AE973F4C2', N'DisplayName', N'nopCommerce')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'54D8465B-665E-459A-A8E3-187AE973F4C3', N'DisplayName', N'Sitefinity')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'54D8465B-665E-459A-A8E3-187AE973F4C4', N'DisplayName', N'DNN')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'54D8465B-665E-459A-A8E3-187AE973F4C5', N'DisplayName', N'WPF')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'54D8465B-665E-459A-A8E3-187AE973F4C6', N'DisplayName', N'ASP.NET MVC')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'54D8465B-665E-459A-A8E3-187AE973F4C7', N'DisplayName', N'Orchard')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'54D8465B-665E-459A-A8E3-187AE973F4C8', N'DisplayName', N'Silverlight')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'54D8465B-665E-459A-A8E3-187AE973F4C9', N'DisplayName', N'ASP.NET Web Forms')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'EED80BD8-8E8D-4DA0-931B-09F97AA2DDBF', N'DisplayName', N'Windows Forms')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'5C9B5D54-9C4E-48C0-B53C-461198D7000C', N'DisplayName', N'WP7')

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'5C9B5D54-9C4E-48C0-B53C-461198D7000D', 12, 11, @optionsetId)
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'5C9B5D54-9C4E-48C0-B53C-461198D7000D', N'DisplayName', N'Umbraco')
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'5C9B5D54-9C4E-48C0-B53C-461198D7000E', 13, 12, @optionsetId)
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'5C9B5D54-9C4E-48C0-B53C-461198D7000E', N'DisplayName', N'Android')

UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'TechnologyCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Opportunity')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'TechnologyCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Project')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'TechnologyCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Lead')

set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'timetracking_typecode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'55D8465B-665E-459A-A8E3-187AE973F4C1', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'55D8465B-665E-459A-A8E3-187AE973F4C2', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'55D8465B-665E-459A-A8E3-187AE973F4C3', 3, 2, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'55D8465B-665E-459A-A8E3-187AE973F4C1', N'DisplayName', N'Business Communication')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'55D8465B-665E-459A-A8E3-187AE973F4C2', N'DisplayName', N'Technology Investigation')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'55D8465B-665E-459A-A8E3-187AE973F4C3', N'DisplayName', N'Estimation Of Workload')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'55D8465B-665E-459A-A8E3-187AE973F4C1', N'DisplayName', N'商务沟通')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'55D8465B-665E-459A-A8E3-187AE973F4C2', N'DisplayName', N'技术调研')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'55D8465B-665E-459A-A8E3-187AE973F4C3', N'DisplayName', N'工作量评估')

UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'TypeCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='TimeTracking')

----------------------------------------------project_statuscode
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'project_statuscode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'73ECBD18-F6C7-4355-9839-417C98E9C9C0', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'73ECBD18-F6C7-4355-9839-417C98E9C9C1', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'73ECBD18-F6C7-4355-9839-417C98E9C9C2', 3, 2, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'73ECBD18-F6C7-4355-9839-417C98E9C9C0', N'DisplayName', N'Not Started')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'73ECBD18-F6C7-4355-9839-417C98E9C9C1', N'DisplayName', N'In Progress')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'73ECBD18-F6C7-4355-9839-417C98E9C9C2', N'DisplayName', N'Completed')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'73ECBD18-F6C7-4355-9839-417C98E9C9C0', N'DisplayName', N'未开始')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'73ECBD18-F6C7-4355-9839-417C98E9C9C1', N'DisplayName', N'进行中')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'73ECBD18-F6C7-4355-9839-417C98E9C9C2', N'DisplayName', N'已完成')

UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'StatusCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Project')
-------------------------------------------------------project_probability
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'project_probabilitycode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'73ECBD18-F6C7-4355-9839-417C98E9C9D0', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'73ECBD18-F6C7-4355-9839-417C98E9C9D1', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'73ECBD18-F6C7-4355-9839-417C98E9C9D2', 3, 2, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'73ECBD18-F6C7-4355-9839-417C98E9C9D0', N'DisplayName', N'High')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'73ECBD18-F6C7-4355-9839-417C98E9C9D1', N'DisplayName', N'Medium')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'73ECBD18-F6C7-4355-9839-417C98E9C9D2', N'DisplayName', N'Low')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'73ECBD18-F6C7-4355-9839-417C98E9C9D0', N'DisplayName', N'大')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'73ECBD18-F6C7-4355-9839-417C98E9C9D1', N'DisplayName', N'中')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'73ECBD18-F6C7-4355-9839-417C98E9C9D2', N'DisplayName', N'小')

UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'ProbabilityCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Project')
-------------------------------------------------------projecttask_statuscode
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'projecttask_statuscode',1)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-187AE973F4C1', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-187AE973F4C2', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-187AE973F4C3', 3, 2, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-187AE973F4C4', 4, 3, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-187AE973F4C1', N'DisplayName', N'Not Started')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-187AE973F4C2', N'DisplayName', N'In Progress')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-187AE973F4C3', N'DisplayName', N'Completed')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-187AE973F4C4', N'DisplayName', N'Acceptance')

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-187AE973F4C1', N'DisplayName', N'未开始')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-187AE973F4C2', N'DisplayName', N'进行中')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-187AE973F4C3', N'DisplayName', N'已完成')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-187AE973F4C4', N'DisplayName', N'验收')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'StatusCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='ProjectTask')
-------------------------------------------------------projecttask_prioritycode
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'projecttask_prioritycode',1)

INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-187AE973F4D0', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-187AE973F4D1', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-187AE973F4D2', 3, 2, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-187AE973F4D0', N'DisplayName', N'High')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-187AE973F4D1', N'DisplayName', N'Medium')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-187AE973F4D2', N'DisplayName', N'Low')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-187AE973F4D0', N'DisplayName', N'高')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-187AE973F4D1', N'DisplayName', N'中')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-187AE973F4D2', N'DisplayName', N'低')

UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'prioritycode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='ProjectTask')
------------------------------ProjectWeekReport_Progress
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'projectweekreport_progress',1)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-187AE973F5C1', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-187AE973F5C2', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-187AE973F5C3', 3, 2, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-187AE973F5C1', N'DisplayName', N'Normal')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-187AE973F5C2', N'DisplayName', N'Advance')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-187AE973F5C3', N'DisplayName', N'Delayed')

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-187AE973F5C1', N'DisplayName', N'正常')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-187AE973F5C2', N'DisplayName', N'提前')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-187AE973F5C3', N'DisplayName', N'延后')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'CurrentProgressCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='ProjectWeekReport')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'OutlookProgressCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='ProjectWeekReport')

------------------------------ProjectWeekReport_Progress
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'projectweekreport_Quality',1)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-187AE973F6C1', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-187AE973F6C2', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-187AE973F6C3', 3, 2, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-187AE973F6C1', N'DisplayName', N'Normal')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-187AE973F6C2', N'DisplayName', N'Better')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-187AE973F6C3', N'DisplayName', N'Worse')

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-187AE973F6C1', N'DisplayName', N'正常')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-187AE973F6C2', N'DisplayName', N'较好')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-187AE973F6C3', N'DisplayName', N'不好')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'CurrentQualityCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='ProjectWeekReport')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'OutlookQualityCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='ProjectWeekReport')

-------------------------------NOTE
update Metadata_Attribute set LogicalName='MultipleLineText' where AttributeId in(
select AttributeId from Metadata_Attribute a inner join Metadata_Entity b on a.EntityId=b.EntityId
where b.PhysicalName='Note' and a.Name='notetext')

-------------------------------Notification
update Metadata_Attribute set LogicalName='MultipleLineText' where AttributeId in(
select AttributeId from Metadata_Attribute a inner join Metadata_Entity b on a.EntityId=b.EntityId
where b.PhysicalName='Notification' and a.Name='Body')

-------------------------------Attendance_AttendanceTypeCode
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'attendance_attendancetypecode',1)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-287AE973F4C1', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-287AE973F4C2', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-287AE973F4C3', 3, 2, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-287AE973F4C4', 4, 3, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-287AE973F4C5', 5, 4, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-287AE973F4C1', N'DisplayName', N'Come Late')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-287AE973F4C2', N'DisplayName', N'Thing Leave')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-287AE973F4C3', N'DisplayName', N'Sick Leave')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-287AE973F4C4', N'DisplayName', N'Year Leave')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-287AE973F4C5', N'DisplayName', N'Maternity Leave')

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-287AE973F4C1', N'DisplayName', N'迟到')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-287AE973F4C2', N'DisplayName', N'事假')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-287AE973F4C3', N'DisplayName', N'病假')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-287AE973F4C4', N'DisplayName', N'年假')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-287AE973F4C5', N'DisplayName', N'产假')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'AttendanceTypeCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Attendance')

---------------------------Attendance_AttendanceUnitCode
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'attendance_attendanceunitcode',1)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-287AE973F4D1', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-287AE973F4D2', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-287AE973F4D3', 3, 2, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-287AE973F4D1', N'DisplayName', N'Minute')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-287AE973F4D2', N'DisplayName', N'Hour')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-287AE973F4D3', N'DisplayName', N'Day')

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-287AE973F4D1', N'DisplayName', N'分钟')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-287AE973F4D2', N'DisplayName', N'小时')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-287AE973F4D3', N'DisplayName', N'天')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'AttendanceUnitCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='Attendance')

---------------------------User_JobLevelCode
set @optionsetId = NEWID()
INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) VALUES(@optionsetId,'user_joblevelcode',1)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-287AE973F4E1', 1, 0, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-287AE973F4E2', 2, 1, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-287AE973F4E3', 3, 2, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-287AE973F4E4', 4, 3, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-287AE973F4E5', 5, 4, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-287AE973F4E6', 6, 5, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-287AE973F4E7', 7, 6, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-287AE973F4E8', 8, 7, @optionsetId)
INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) VALUES (N'56D8465B-665E-459A-A8E3-287AE973F4E9', 9, 8, @optionsetId)

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-287AE973F4E1', N'DisplayName', N'White Star')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-287AE973F4E2', N'DisplayName', N'Yellow Star')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-287AE973F4E3', N'DisplayName', N'Green Star')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-287AE973F4E4', N'DisplayName', N'Blue Star')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-287AE973F4E5', N'DisplayName', N'Red Star')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-287AE973F4E6', N'DisplayName', N'Orange Star')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-287AE973F4E7', N'DisplayName', N'Purple Star')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-287AE973F4E8', N'DisplayName', N'Cyan Star')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-287AE973F4E9', N'DisplayName', N'Black Star')

INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-287AE973F4E1', N'DisplayName', N'白星')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-287AE973F4E2', N'DisplayName', N'黄星')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-287AE973F4E3', N'DisplayName', N'绿星')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-287AE973F4E4', N'DisplayName', N'蓝星')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-287AE973F4E5', N'DisplayName', N'红星')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-287AE973F4E6', N'DisplayName', N'橙星')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-287AE973F4E7', N'DisplayName', N'紫星')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-287AE973F4E8', N'DisplayName', N'青星')
INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-287AE973F4E9', N'DisplayName', N'黑星')
UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'JobLevelCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='User')

COMMIT