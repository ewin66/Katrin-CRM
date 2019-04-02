using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121010092324)]
    public class _20121010092324_InitMetadataAttributeTypeTable : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000011", Description = "bigint" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000012", Description = "binary" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000013", Description = "bit" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000014", Description = "char" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000015", Description = "datetime" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000016", Description = "decimal" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000017", Description = "float" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000018", Description = "image" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000019", Description = "int" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-11000000001A", Description = "money" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-11000000001B", Description = "nchar" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-11000000001C", Description = "ntext" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-11000000001D", Description = "numeric" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-11000000001E", Description = "nvarchar" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-11000000001F", Description = "real" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000020", Description = "smalldatetime" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000021", Description = "smallint" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000022", Description = "smallmoney" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000023", Description = "sql_variant" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000024", Description = "text" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000025", Description = "timestamp" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000026", Description = "tinyint" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000027", Description = "uniqueidentifier" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000028", Description = "varbinary" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000029", Description = "varchar" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000030", Description = "picklist" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000031", Description = "lookup" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000032", Description = "primarykey" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000033", Description = "virtual" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000034", Description = "customer" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000035", Description = "owner" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000036", Description = "state" });
            Insert.IntoTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000037", Description = "status" });
        }
        public override void Down()
        {
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000011" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000012" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000013" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000014" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000015" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000016" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000017" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000018" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000019" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-11000000001A" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-11000000001B" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-11000000001C" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-11000000001D" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-11000000001E" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-11000000001F" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000020" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000021" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000022" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000023" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000024" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000025" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000026" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000027" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000028" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000029" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000030" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000031" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000032" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000033" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000034" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000035" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000036" });
            Delete.FromTable("Metadata_AttributeType").Row(new { AttributeTypeId = "00000000-0000-0000-00AA-110000000037" });
        }
    }
}
