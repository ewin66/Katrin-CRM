using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121206171244)]
    public class _20121206171244_AddRolesInAppointmentModule : Migration
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
	                            EXEC [dbo].[InsertEntityPrivilege] @EntityName,'Create',2
	                            EXEC [dbo].[InsertEntityPrivilege] @EntityName,'Write',4
	                            EXEC [dbo].[InsertEntityPrivilege] @EntityName,'Delete',8
                            END
                            GO

                            EXEC [dbo].[InsertPrivileges] 'Appointment'
                            GO

                            DROP PROCEDURE [dbo].[InsertEntityPrivilege]
                            DROP PROCEDURE [dbo].[InsertPrivileges]

                            INSERT INTO [dbo].[RolePrivilege]
                                       ([RolePrivilegeId]
                                       ,[RoleId]
                                       ,[PrivilegeId])
                            SELECT	[RolePrivilegeId]	= NEWID(),
                                    [RoleId]			= r.RoleId,
		                            [PrivilegeId]		= p.PrivilegeId
                            FROM	Privilege p
		                            INNER JOIN PrivilegeEntity pe
		                            ON	pe.PrivilegeId	= p.PrivilegeId
		                            ,[dbo].[Role] r
                            WHERE	pe.EntityName = 'Appointment'";
            Execute.Sql(sql);
        }

        public override void Down()
        {

        }
    }
}
