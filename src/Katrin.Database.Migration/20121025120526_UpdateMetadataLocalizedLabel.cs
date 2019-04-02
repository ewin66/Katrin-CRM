using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121025120526)]
    public class _20121025120526_UpdateMetadataLocalizedLabel : Migration
    {
        public override void Up()
        {
            string sql = @"CREATE PROCEDURE [dbo].[InsertLocalizedLabel] 
	                        @EntityName		 nvarchar(64),
	                        @AttributeName	 nvarchar(50),
	                        @LanguageId int,
	                        @LocalizedLabel nvarchar(MAX)
                        AS
                        BEGIN
	                        DECLARE @ObjectId uniqueidentifier
	
	                        PRINT @EntityName +'***' +@AttributeName
	
	                        SELECT	@ObjectId	= a.AttributeId
	                        FROm	[dbo].[Metadata_Attribute] a
			                        INNER JOIN [dbo].[Metadata_Entity] e
			                        ON	e.EntityId	= a.EntityId
	                        WHERE	e.Name = @EntityName AND a.Name = @AttributeName
		

	                        INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
	                        VALUES (NEWID(), @LanguageId, @ObjectId, N'DisplayName', @LocalizedLabel)
                        END

                        GO

                        BEGIN TRANSACTION


                        --------------------------UpdateProjectTask------------------------------

                        EXEC [dbo].[InsertLocalizedLabel] 'ProjectTask','ProjectModuleId',2052,N'????'
                        EXEC [dbo].[InsertLocalizedLabel] 'ProjectTask','ProjectModuleId',1033,N'Module Name'
                        EXEC [dbo].[InsertLocalizedLabel] 'ProjectTask','TaskNumber',2052,N'????'
                        EXEC [dbo].[InsertLocalizedLabel] 'ProjectTask','TaskNumber',1033,N'Task Number'

                        --------------------------------------ProjectModule
                        EXEC [dbo].[InsertLocalizedLabel] 'ProjectModule','CreatedOn',2052,N'????'
                        EXEC [dbo].[InsertLocalizedLabel] 'ProjectModule','CreatedOn',1033,N'Created On'
                        EXEC [dbo].[InsertLocalizedLabel] 'ProjectModule','CreatedById',2052,N'???'
                        EXEC [dbo].[InsertLocalizedLabel] 'ProjectModule','CreatedById',1033,N'Created By'
                        EXEC [dbo].[InsertLocalizedLabel] 'ProjectModule','ModifiedOn',2052,N'????'
                        EXEC [dbo].[InsertLocalizedLabel] 'ProjectModule','ModifiedOn',1033,N'Created On'
                        EXEC [dbo].[InsertLocalizedLabel] 'ProjectModule','ModifiedById',2052,N'???'
                        EXEC [dbo].[InsertLocalizedLabel] 'ProjectModule','ModifiedById',1033,N'Created By'
                        EXEC [dbo].[InsertLocalizedLabel] 'ProjectModule','ModuleName',2052,N'????'
                        EXEC [dbo].[InsertLocalizedLabel] 'ProjectModule','ModuleName',1033,N'Module Name'
                        EXEC [dbo].[InsertLocalizedLabel] 'ProjectModule','Description',2052,N'??'
                        EXEC [dbo].[InsertLocalizedLabel] 'ProjectModule','Description',1033,N'Description'

                        COMMIT
                        DROP PROCEDURE [dbo].[InsertLocalizedLabel] ";
            Execute.Sql(sql);
        }
        public override void Down()
        {
            string sql = @"DELETE FROM [dbo].[Metadata_LocalizedLabel] WHERE [ObjectId] 
                           IN(SELECT [AttributeId] FROM  [dbo].[Metadata_Attribute] WHERE [EntityId]
                           IN(SELECT [EntityId] FROM [dbo].[Metadata_Entity] WHERE [Name]='ProjectModule'))";
            Execute.Sql(sql);
            sql = @"DELETE FROM [dbo].[Metadata_LocalizedLabel] WHERE [ObjectId] 
                    IN(SELECT [AttributeId] FROM  [dbo].[Metadata_Attribute] WHERE [EntityId]
                    IN(SELECT [EntityId] FROM [dbo].[Metadata_Entity] WHERE [Name]='ProjectTask'))
                    AND [Label] IN(N'????',N'Module Name',N'????',N'Task Number')";
            Execute.Sql(sql);

        }

    }
}
