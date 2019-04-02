using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121017161811)]
    public class _20121017161811_AddProjectManagerRole : Migration
    {
        public override void Up()
        {
            string sql = @"DECLARE @RoleId uniqueidentifier
                            SET	@RoleId = NEWID()
                            INSERT INTO [dbo].[Role]
                                       (RoleId
                                       ,[RoleName])
                            VALUES	(@RoleId
		                               ,'Project Manager')

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
                            WHERE	pe.EntityName IN('ProjectTask') AND p.AccessRight = 8";
            Execute.Sql(sql);
        }
        public override void Down()
        {
            string sql = @"DELETE FROM [dbo].[RolePrivilege]
                            WHERE [RoleId] = (SELECT [RoleId] FROM [dbo].[Role] WHERE [RoleName]='Project Manager')

                            DELETE FROM [dbo].[UserRole]
                            WHERE [RoleId] = (SELECT [RoleId] FROM [dbo].[Role] WHERE [RoleName]='Project Manager')

                            DELETE FROM [dbo].[Role] WHERE [RoleName]='Project Manager'";
            Execute.Sql(sql);
        }
    }
}
