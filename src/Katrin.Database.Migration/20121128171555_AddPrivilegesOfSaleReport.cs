using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121128171555)]
    public class _20121128171555_AddPrivilegesOfSaleReport : Migration
    {
        public override void Up()
        {
            string sql = @"CREATE PROCEDURE [dbo].[InsertEntityPrivilege]
	                        @EntityName	nvarchar(100),
	                        @Name		 nvarchar(100),
	                        @AccessRight	int
                            AS
                            BEGIN

	                            DECLARE @PrivilegeId uniqueidentifier

	                            SET @PrivilegeId = NEWID()

	                            INSERT INTO [dbo].[Privilege]([PrivilegeId],[Name],[AccessRight]) VALUES(@PrivilegeId,@Name,@AccessRight)

	                            INSERT INTO [dbo].[PrivilegeEntity]
                                       ([PrivilegeEntityId]
                                       ,[PrivilegeId]
                                       ,[EntityName])
                                 VALUES
                                       (NEWID()
                                       ,@PrivilegeId
                                       ,@EntityName)

                            END
                            GO

                            CREATE PROCEDURE [dbo].[InsertPrivileges]
	                            @EntityName	nvarchar(100)
                            AS
                            BEGIN

	                            EXEC [dbo].[InsertEntityPrivilege] @EntityName,'Read',1
                            END
                            GO

                            EXEC [dbo].[InsertPrivileges] 'SaleReport'
                            GO

                            DROP PROCEDURE [dbo].[InsertEntityPrivilege]
                            DROP PROCEDURE [dbo].[InsertPrivileges]

                            DECLARE @RoleId uniqueidentifier
                            
                            SELECT	@RoleId = [RoleId]
                            FROM    [dbo].[Role]
                            WHERE [RoleName] = N'Sales'
                            INSERT INTO [dbo].[RolePrivilege]
                                       ([RolePrivilegeId]
                                       ,[RoleId]
                                       ,[PrivilegeId])
                            SELECT	[RolePrivilegeId]	= NEWID(),
                                    [RoleId]			= @RoleId,
		                            [PrivilegeId]		= p.PrivilegeId
                            FROM	Privilege p
		                            INNER JOIN PrivilegeEntity pe
		                            ON	pe.PrivilegeId	= p.PrivilegeId
                            WHERE	pe.EntityName ='SaleReport' AND p.AccessRight =1
                            
                            SELECT	@RoleId = [RoleId]
                            FROM    [dbo].[Role]
                            WHERE [RoleName] = N'Administrators'
                            INSERT INTO [dbo].[RolePrivilege]
                                       ([RolePrivilegeId]
                                       ,[RoleId]
                                       ,[PrivilegeId])
                            SELECT	[RolePrivilegeId]	= NEWID(),
                                    [RoleId]			= @RoleId,
		                            [PrivilegeId]		= p.PrivilegeId
                            FROM	Privilege p
		                            INNER JOIN PrivilegeEntity pe
		                            ON	pe.PrivilegeId	= p.PrivilegeId
                            WHERE	pe.EntityName ='SaleReport' AND p.AccessRight =1
                            
                            SELECT	@RoleId = [RoleId]
                            FROM    [dbo].[Role]
                            WHERE [RoleName] = N'Department Manager'
                            INSERT INTO [dbo].[RolePrivilege]
                                       ([RolePrivilegeId]
                                       ,[RoleId]
                                       ,[PrivilegeId])
                            SELECT	[RolePrivilegeId]	= NEWID(),
                                    [RoleId]			= @RoleId,
		                            [PrivilegeId]		= p.PrivilegeId
                            FROM	Privilege p
		                            INNER JOIN PrivilegeEntity pe
		                            ON	pe.PrivilegeId	= p.PrivilegeId
                            WHERE	pe.EntityName ='SaleReport' AND p.AccessRight =1";
            Execute.Sql(sql);
        }
        public override void Down()
        {
            string sql = @"DELETE FROM [dbo].[RolePrivilege]
                            WHERE  [PrivilegeId] IN (SELECT	[PrivilegeId]	
                            FROM [dbo].[PrivilegeEntity]
                            WHERE	[EntityName] ='SaleReport')
                            DELETE FROM [dbo].[PrivilegeEntity]
                            WHERE [EntityName] ='SaleReport'
                            DELETE FROM [dbo].[Privilege]
                            WHERE  [PrivilegeId] NOT IN (SELECT [PrivilegeId]
                            FROM [dbo].[PrivilegeEntity])";
            Execute.Sql(sql);
        }
    }
}
