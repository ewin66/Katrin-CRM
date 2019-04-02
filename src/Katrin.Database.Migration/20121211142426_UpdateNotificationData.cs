using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121211142426)]
    public class _20121211142426_UpdateNotificationData : Migration
    {
        public override void Up()
        {
            string sql = @"delete from NotificationRecipient where NotificationId in
            (select NotificationId from notification where objecttype='Note' and NotificationUrl is  null)
            delete from notification where objecttype='Note' and NotificationUrl is  null
            update notification set objecttype='Note-'+substring(NotificationUrl,0,len(NotificationUrl)-36)
             where objecttype='Note' and NotificationUrl is not null";
            Execute.Sql(sql);
            sql = @" delete from audit where CreatedOn is null
             update audit set CreatedOn = a.CreatedOn from(
             select TrasactionId,min(CreatedOn) CreatedOn from audit group by TrasactionId
             ) a where audit.TrasactionId=a.TrasactionId";
            Execute.Sql(sql);
        }
        public override void Down()
        {
            
        }
    }
}
