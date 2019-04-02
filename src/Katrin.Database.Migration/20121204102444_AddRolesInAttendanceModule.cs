using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121204102444)]
    public class _20121204102444_AddRolesInAttendanceModule : Migration
    {
        public override void Up()
        {
            string sql = @"DECLARE @RoleId uniqueidentifier
                            SET	@RoleId = NEWID()
                            INSERT INTO [dbo].[Role]
                                       (RoleId
                                       ,[RoleName])
                            VALUES	(@RoleId
		                               ,'Attendance Recorder')

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
                            WHERE	pe.EntityName = N'Attendance' AND p.AccessRight =2
                            INSERT INTO [dbo].[UserRole]
                                       ([Id]
                                       ,[UserId]
                                       ,[RoleId])
                            SELECT	NEWID(),
		                            UserId,
		                            @RoleId
                            FROM	[User]
                            WHERE	FullName IN (N'??',N'???',N'???',N'??')
                           
                            SET	@RoleId = NEWID()
                            INSERT INTO [dbo].[Role]
                                       (RoleId
                                       ,[RoleName])
                            VALUES	(@RoleId
		                               ,'Attendance Manager')

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
                            WHERE	pe.EntityName = N'Attendance' AND p.AccessRight In(2,4,8)
                            INSERT INTO [dbo].[UserRole]
                                       ([Id]
                                       ,[UserId]
                                       ,[RoleId])
                            SELECT	NEWID(),
		                            UserId,
		                            @RoleId
                            FROM	[User]
                            WHERE	FullName =N'???'
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
                            WHERE	pe.EntityName ='Attendance' AND p.AccessRight =1
                            
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
                            WHERE	pe.EntityName ='Attendance' AND p.AccessRight =1

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
                            WHERE	pe.EntityName ='Attendance' AND p.AccessRight =1
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
                            WHERE	pe.EntityName ='Attendance' AND p.AccessRight =1";
            Execute.Sql(sql);
        }
        public override void Down()
        {
            string sql = @"DELETE FROM [dbo].[RolePrivilege]
                            WHERE [RoleId] = (SELECT [RoleId] FROM [dbo].[Role] WHERE [RoleName]='Attendance Recorder')

                            DELETE FROM [dbo].[UserRole]
                            WHERE [RoleId] = (SELECT [RoleId] FROM [dbo].[Role] WHERE [RoleName]='Attendance Recorder')

                            DELETE FROM [dbo].[Role] WHERE [RoleName]='Attendance Recorder'
                            
                          DELETE FROM [dbo].[RolePrivilege]
                            WHERE [RoleId] = (SELECT [RoleId] FROM [dbo].[Role] WHERE [RoleName]='Attendance Manager')

                            DELETE FROM [dbo].[UserRole]
                            WHERE [RoleId] = (SELECT [RoleId] FROM [dbo].[Role] WHERE [RoleName]='Attendance Manager')

                            DELETE FROM [dbo].[Role] WHERE [RoleName]='Attendance Manager'
                         
                         DELETE FROM [dbo].[RolePrivilege]
                            WHERE  [PrivilegeId] IN (SELECT	[PrivilegeId]	
                            FROM [dbo].[PrivilegeEntity]
                            WHERE	[EntityName] ='Attendance') AND [RoleId] IN(SELECT [RoleId]
                            FROM    [dbo].[Role]
                            WHERE [RoleName] IN(N'Department Manager',N'Project Manager',N'Technician',N'Sales'))";
            Execute.Sql(sql);
        }
    }
}
