using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121119101241)]
    public class _20121119101241_AddIsDeletedForRole : Migration
    {
        public override void Up()
        {
            Alter.Table("Role").AddColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false);
            string sql = @"DECLARE @EntityId uniqueidentifier
                            SELECT @EntityId = [EntityId]
                            FROM [dbo].[Metadata_Entity]
                            WHERE [Name]='Role'
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
		                            '00000000-0000-0000-00AA-110000000013',
		                            'isdeleted',
		                            'IsDeleted',
		                            0,
		                            @EntityId,
		                            4,
		                            'isdeleted',
		                            0,
		                            'IsDeleted',
		                            0, 
		                            1)";
            Execute.Sql(sql);
        }
        public override void Down()
        {
            Delete.Column("IsDeleted").FromTable("Role");
            string sql = @"DECLARE @EntityId uniqueidentifier
                            SELECT @EntityId = [EntityId]
                            FROM [dbo].[Metadata_Entity]
                            WHERE [Name]='Role'
                            DELETE FROM [dbo].[Metadata_Attribute]
                            WHERE [EntityId]=@EntityId AND PhysicalName='IsDeleted'";
            Execute.Sql(sql);
        }
    }
}
