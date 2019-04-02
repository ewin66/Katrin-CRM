using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121128174012)]
    public class _20121128174012_AddReadPrivilegesOfAccount : Migration
    {
        public override void Up()
        {
            string sql = @"DECLARE @RoleId uniqueidentifier
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
                            WHERE	pe.EntityName ='Account' AND p.AccessRight =1
                            
                            SELECT	@RoleId = [RoleId]
                            FROM    [dbo].[Role]
                            WHERE [RoleName] = N'Project Manager'

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
                            WHERE	pe.EntityName ='Account' AND p.AccessRight =1

                            SELECT	@RoleId = [RoleId]
                            FROM    [dbo].[Role]
                            WHERE [RoleName] = N'Technician'

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
                            WHERE	pe.EntityName ='Account' AND p.AccessRight =1";
            Execute.Sql(sql);
        }
        public override void Down()
        {
            string sql = @"DELETE FROM [dbo].[RolePrivilege]
                            WHERE  [PrivilegeId] IN (SELECT	[PrivilegeId]	
                            FROM [dbo].[PrivilegeEntity]
                            WHERE	[EntityName] ='Account') AND [RoleId] IN(SELECT [RoleId]
                            FROM    [dbo].[Role]
                            WHERE [RoleName] IN(N'Department Manager',N'Project Manager',N'Technician'))";
            Execute.Sql(sql);
        }
    }
}
