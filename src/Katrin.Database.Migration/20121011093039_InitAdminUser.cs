using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121011093039)]
    public class _20121011093039_InitAdminUser : Migration
    {
        public override void Up()
        {
            const string sql = @"IF NOT EXISTS( SELECT * FROM [dbo].[User] WHERE UserId = '20c163a1-bf24-4282-af2b-728a8b4ad124')
BEGIN
	INSERT INTO [dbo].[User] ([UserId], [UserName], [Password], [PasswordSalt], [FirstName], [MiddleName], [LastName], [FullName], [NickName], [Title], [EmailAddress], [HomePhone], [MobilePhone], [IsDisabled], [CreatedOn], [ModifiedOn], [CreatedById], [ModifiedById], [ParentUserId]) VALUES (N'20c163a1-bf24-4282-af2b-728a8b4ad124', N'admin', N'$2a$04$OqGVn/3HhrDW1DB42TFBLeHWxDDXkcYYtmHHQZhbaiDAZujMILtYq', NULL, N'Administrator', NULL, N'Katrin CRM', N'Administrator Katrin CRM', NULL, NULL, NULL, NULL, NULL, NULL, '20120203 14:28:20.730', '20120203 14:28:20.730', NULL, NULL, NULL)
END
UPDATE [User] SET UserType =0 WHERE UserName = 'admin'";
            Execute.Sql(sql);
        }
        public override void Down()
        {
            Delete.FromTable("User").Row(new { UserId = "20C163A1-BF24-4282-AF2B-728A8B4AD124" });
        }
    }
}
