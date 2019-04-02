using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121120133254)]
    public class _20121120133254_ModifyNotificationConfig : Migration
    {
        public override void Up()
        {

            string sql = @"update NotificationProfile set SubjectTemplateId ='9D1370B4-9396-46FD-8CC6-A774A582B9BB'
            where  NotificationTemplateId='F5B9608E-4E93-4A0D-820A-9D34DB4342A1'";
            Execute.Sql(sql);
            //PROJECT TASK
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "CDA91E00-CCCC-4193-9159-61CE11D73D61", CriteriaId = "1CD6159F-9970-4901-92F2-2D5D7891BE42", ParentNodeId = "241B7752-217D-4542-9CDD-D1E02E4D9C79", Operator = "Binry", OperatorType = "NotEqual", CompareAttributeId = "01D9879C-0E67-499B-856D-6698645AC997", CompareValue = "" });
            //OPP
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "CBB2EFBC-CCC0-4F17-9742-710A1ED60483", CriteriaId = "EEBD3399-4EBE-4226-8FD0-52FE998AD497", ParentNodeId = "F8386850-1D82-4338-9DB1-87513359EDA1", Operator = "Binry", OperatorType = "NotEqual", CompareAttributeId = "7F2DFE63-577F-4D45-BF69-D9706F2A745F", CompareValue = "" });
        }


        public override void Down()
        {
            
        }
    }
}
