using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121218175415)]
    public class _20121218175415_AddStatusCodeForProjectIteration : Migration
    {
        public override void Up()
        {
            Alter.Table("ProjectIteration").AddColumn("StatusCode").AsInt32().NotNullable().WithDefaultValue(1);
            string sql = @" DECLARE @optionsetId nvarchar(100)
                            -----------------projectiterationk_statuscode ????
                            SET @optionsetId = NEWID()
                            INSERT INTO [dbo].[Metadata_OptionSet] (OptionSetId, Name, IsCustomizable) 
                            VALUES(@optionsetId,'projectiterationk_statuscode',1)

                            INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
                            VALUES (N'56D8465B-665E-459A-A8E3-287AE973F4EA', 1, 0, @optionsetId)

                            INSERT INTO [dbo].[Metadata_AttributePicklistValue] ([AttributePicklistValueId], [Value], [DisplayOrder], [OptionSetId]) 
                            VALUES (N'56D8465B-665E-459A-A8E3-287AE973F4EB', 2, 1, @optionsetId)

                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
                            VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-287AE973F4EA', N'DisplayName', N'Opened')

                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
                            VALUES (NEWID(), 1033, N'56D8465B-665E-459A-A8E3-287AE973F4EB', N'DisplayName', N'Closed')

                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
                            VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-287AE973F4EA', N'DisplayName', N'??')

                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
                            VALUES (NEWID(), 2052, N'56D8465B-665E-459A-A8E3-287AE973F4EB', N'DisplayName', N'??')

                            UPDATE Metadata_Attribute SET OptionSetId = @optionsetId WHERE PhysicalName = 'ProjectIterationStatusCode' And EntityId=(SELECT EntityId FROM Metadata_Entity WHERE Name='ProjectIteration')
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
		                            IsCopyEnabled,
                                    OptionSetId)
                            VALUES(	NEWID(),
		                            '00000000-0000-0000-00AA-110000000030',
		                            'statuscode',
		                            'StatusCode',
		                            1,
		                            '1163B3E2-9293-4185-BAFE-53BDBB20725C',
		                            27,
		                            'statuscode',
		                            0,
		                            'StatusCode',
		                            0, 
		                            1,
                                     @optionsetId)
                           DECLARE @ObjectId   nvarchar(100)
                            SELECT  @ObjectId= [AttributeId]
                            FROM [dbo].[Metadata_Attribute]
                            WHERE [PhysicalName]='StatusCode'
                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
                            VALUES (NEWID(), 2052, @ObjectId, N'DisplayName', N'????')

                            INSERT INTO [dbo].[Metadata_LocalizedLabel] ([LocalizedLabelId], [LanguageId], [ObjectId], [ObjectColumnName], [Label])  
                            VALUES (NEWID(), 1033, @ObjectId, N'DisplayName', N'Status')";
            Execute.Sql(sql);
        }
        public override void Down()
        {
            Delete.Column("StatusCode").FromTable("ProjectIteration");
            string sql = @"DELETE FROM Metadata_Attribute
                            WHERE PhysicalName	= 'StatusCode' AND EntityId=N'1163B3E2-9293-4185-BAFE-53BDBB20725C'
                            DELETE FROM [dbo].[Metadata_LocalizedLabel]
                            WHERE [ObjectId] IN (N'56D8465B-665E-459A-A8E3-287AE973F4EA',N'56D8465B-665E-459A-A8E3-287AE973F4EB')
                            DELETE FROM [dbo].[Metadata_AttributePicklistValue]
                            WHERE [AttributePicklistValueId] IN(N'56D8465B-665E-459A-A8E3-287AE973F4EA',N'56D8465B-665E-459A-A8E3-287AE973F4EB')
                            DELETE FROM [dbo].[Metadata_OptionSet]
                            WHERE Name=N'projectiterationk_statuscode'
                            DELETE FROM [dbo].[Metadata_LocalizedLabel]
                            WHERE [Label] IN(N'????',N'Status')";
            Execute.Sql(sql);
        }
    }
}
