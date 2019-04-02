using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121217090426)]
    public class _20121217090426_UpdateSubscription : Migration
    {
        public override void Up()
        {
            string sql = @"update Subscription set UserId = a.UserId from [User] a 
            where a.FullName = N'??' and Subscription.UserId is null";
            Execute.Sql(sql);
        }
        public override void Down()
        {

        }
    }
}
