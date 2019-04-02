using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121127095941)]
    public class _20121127095941_AddDateTimeForLead : Migration
    {
        public override void Up()
        {
            Alter.Table("Lead").AddColumn("ClosedOn").AsDateTime().Nullable().WithDefaultValue(DateTime.Now);
            string sql = @"DECLARE @EntityId uniqueidentifier
                            SELECT @EntityId = [EntityId]
                            FROM [dbo].[Metadata_Entity]
                            WHERE [Name]='Lead'
                            INSERT	Metadata_Attribute(
		                            AttributeId,
		                            AttributeTypeId,
		                            Name,
		                            PhysicalName,
		                            IsNullable,
		                            EntityId,
		                            ColumnNumber,
		                            LogicalName,
		                            IsAuditEnabled,
		                            TableColumnName,
		                            IsPKAttribute,
		                            IsCopyEnabled)
                            VALUES(	NEWID(),
		                            '00000000-0000-0000-00AA-110000000015',
		                            'closedon',
		                            'ClosedOn',
		                            1,
		                            @EntityId,
		                            4,
		                            'closedon',
		                            0,
		                            'ClosedOn',
		                            0, 
		                            1)";
            Execute.Sql(sql);
            Alter.Table("Lead").AddColumn("FirstResponsedOn").AsDateTime().Nullable().WithDefaultValue(DateTime.Now);
            sql = @"DECLARE @EntityId uniqueidentifier
                            SELECT @EntityId = [EntityId]
                            FROM [dbo].[Metadata_Entity]
                            WHERE [Name]='Lead'
                            INSERT	Metadata_Attribute(
		                            AttributeId,
		                            AttributeTypeId,
		                            Name,
		                            PhysicalName,
		                            IsNullable,
		                            EntityId,
		                            ColumnNumber,
		                            LogicalName,
		                            IsAuditEnabled,
		                            TableColumnName,
		                            IsPKAttribute,
		                            IsCopyEnabled)
                            VALUES(	NEWID(),
		                            '00000000-0000-0000-00AA-110000000015',
		                            'firstresponsedon',
		                            'FirstResponsedOn',
		                            1,
		                            @EntityId,
		                            4,
		                            'firstresponsedon',
		                            0,
		                            'FirstResponsedOn',
		                            0, 
		                            1)";
            Execute.Sql(sql);
        }
        public override void Down()
        {
            Delete.Column("ClosedOn").FromTable("Lead");
            Delete.Column("FirstResponsedOn").FromTable("Lead");
            string sql = @"DECLARE @EntityId uniqueidentifier
                            SELECT @EntityId = [EntityId]
                            FROM [dbo].[Metadata_Entity]
                            WHERE [Name]='Lead'
                            DELETE FROM [dbo].[Metadata_Attribute]
                            WHERE [EntityId]=@EntityId AND PhysicalName in('IsDeleted','FirstResponsedOn')";
            Execute.Sql(sql);
        }
    }
}
