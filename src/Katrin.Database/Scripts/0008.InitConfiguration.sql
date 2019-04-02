DELETE FROM SystemSetting

INSERT INTO [dbo].SystemSetting
           ([SystemSettingId]
           ,[Name]
           ,[Value])
     VALUES
           (NEWID()
		    ,'FullName'
           ,'<FirstName> <LastName>')
GO


UPDATE Lead
SET	FullName = ISNULL(FirstName,'') + ' '+ LastName

UPDATE Contact
SET	FullName = ISNULL(FirstName,'') + ' '+ LastName