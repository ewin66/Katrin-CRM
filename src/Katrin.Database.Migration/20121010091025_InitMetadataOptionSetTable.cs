using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121010091025)]
    public class _20121010091025_InitMetadataOptionSetTable : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "43D042C4-FDAC-43E5-ABE9-154BC9F17E4E", Name = "account_accountratingcode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "6A4BDF95-43B3-44A8-8645-17218EEC01B4", Name = "contact_haschildrencode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "0483C621-CEFC-4755-9AAD-1C371CA42B0E", Name = "lead_prioritycode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "1EDB59D7-9B32-4385-8043-1C57B3764FF4", Name = "projecttask_prioritycode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "8550744F-B877-40E9-967C-1CF56593FB26", Name = "account_customersizecode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "BC109DB6-1497-4EF0-843E-1E52236720F0", Name = "contact_educationcode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "01FBA8F9-7727-40FA-AEA2-2178D6F05C92", Name = "account_accountclassificationcode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "6B435103-5095-41E9-B62F-22C845074A73", Name = "contact_gendercode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "1C5AD496-CE1A-41A7-9FAE-2C95AB4C7FE1", Name = "contact_statuscode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "1CD613AA-8BA2-44A9-A44E-2DEE50671C03", Name = "project_statuscode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "E1BB9771-8F44-4346-B19D-3CD26B613F6B", Name = "contract_EndTypeCode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "476B631C-2286-4EA8-8371-42DE22E020DB", Name = "opportunity_opportunityratingcode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "26000757-5127-4E86-88C0-4A3BFCAE193A", Name = "attendance_attendanceunitcode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "AAA36789-7CF9-45A5-A355-4ACC21A91BF5", Name = "attendance_attendancetypecode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "4B2D9431-3F88-4880-8633-4DC35982A9E4", Name = "contract_customerSatisfactionCode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "C1C75950-4259-4110-9CAF-50BAF3DD7539", Name = "opportunity_salesstagecode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "AD1C75F0-CDD7-4154-B3F2-55A9FE1FF27D", Name = "account_accountcategorycode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "67DAA13D-85A2-4123-B1BF-672C43836A6A", Name = "invoice_statuscode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "ABFC3B77-17BC-45EF-A07F-6BE15A150385", Name = "quote_paymenttermscode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "1CDE1941-0676-4FDA-809A-6D090879F1D3", Name = "contact_familystatuscode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "2A707965-3185-4529-AB2A-6E0C3490C72D", Name = "account_businesstypecode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "2ED3A5D5-40CE-4348-841C-732FF05160E9", Name = "opportunity_projecttypecode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "F2DF6FA4-494A-4086-AEF3-74D815D9D007", Name = "account_ownershipcode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "AD28E02F-0DB6-4F0D-8F49-8A792B016EB1", Name = "project_probabilitycode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "6E99E674-82E7-4E03-A7DE-8E111238D8BD", Name = "lead_statuscode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "25DAC3D2-3B61-4E11-BC73-8F55C02B06F7", Name = "quote_statuscode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "BD8379B2-0CE7-4EE3-AE58-91E8B1E19A4A", Name = "user_joblevelcode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "C09711FE-F5BA-4C30-BBF5-9796ADE666AB", Name = "projectweekreport_Quality", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "3EC271F9-151A-40C9-9FF7-997C2E850780", Name = "timetracking_typecode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "5B00FE5D-81F2-4211-BE96-9C7A3BF2B097", Name = "opportunity_prioritycode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "53955AC8-8268-49F8-B401-9D1299974D56", Name = "lead_leadsourcecode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "98DA014A-E969-407A-BD4B-A59D3FC96644", Name = "projecttask_statuscode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "DD205413-BBA8-49F6-A7D7-AF26436FBEAA", Name = "lead_CountryCode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "3EBF1E8A-B1AA-421C-96B7-B89EF3D92040", Name = "projectweekreport_progress", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "14A411FA-3B83-4159-9BF0-C34FDECC78B9", Name = "contact_accountrolecode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "C1C7EF85-B911-4BCE-98D6-DFE66AC859BA", Name = "opportunity_opportunitytypecode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "BD0A5BDB-DAFF-4A31-BC1F-E1E7ACDC1608", Name = "contract_statuscode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "CB82BAD0-F0DC-43E5-9BB4-E5455DC9FFE6", Name = "product_statuscode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "49FE89FE-476C-4779-BDC2-E5917A8B6473", Name = "opportunity_technologycode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "78F09B80-9770-44F5-9B5D-F0CE5DA38661", Name = "account_statuscode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "95E8BBEA-4077-4F4E-877F-F263A328E068", Name = "opportunity_statuscode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "A4F40F2B-44D2-40B6-8895-F3DCE9205E78", Name = "account_industrycode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "EB293770-5437-45A3-9FB7-F624F64103D7", Name = "account_customertypecode", IsCustomizable = 1 });
            Insert.IntoTable("Metadata_OptionSet").Row(new { OptionSetId = "D9B876CD-152F-4BC4-BCD6-FA938149A44C", Name = "quote_stagecode", IsCustomizable = 1 });
        }
        public override void Down()
        {
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "43D042C4-FDAC-43E5-ABE9-154BC9F17E4E" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "6A4BDF95-43B3-44A8-8645-17218EEC01B4" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "0483C621-CEFC-4755-9AAD-1C371CA42B0E" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "1EDB59D7-9B32-4385-8043-1C57B3764FF4" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "8550744F-B877-40E9-967C-1CF56593FB26" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "BC109DB6-1497-4EF0-843E-1E52236720F0" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "01FBA8F9-7727-40FA-AEA2-2178D6F05C92" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "6B435103-5095-41E9-B62F-22C845074A73" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "1C5AD496-CE1A-41A7-9FAE-2C95AB4C7FE1" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "1CD613AA-8BA2-44A9-A44E-2DEE50671C03" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "E1BB9771-8F44-4346-B19D-3CD26B613F6B" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "476B631C-2286-4EA8-8371-42DE22E020DB" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "26000757-5127-4E86-88C0-4A3BFCAE193A" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "AAA36789-7CF9-45A5-A355-4ACC21A91BF5" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "4B2D9431-3F88-4880-8633-4DC35982A9E4" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "C1C75950-4259-4110-9CAF-50BAF3DD7539" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "AD1C75F0-CDD7-4154-B3F2-55A9FE1FF27D" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "67DAA13D-85A2-4123-B1BF-672C43836A6A" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "ABFC3B77-17BC-45EF-A07F-6BE15A150385" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "1CDE1941-0676-4FDA-809A-6D090879F1D3" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "2A707965-3185-4529-AB2A-6E0C3490C72D" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "2ED3A5D5-40CE-4348-841C-732FF05160E9" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "F2DF6FA4-494A-4086-AEF3-74D815D9D007" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "AD28E02F-0DB6-4F0D-8F49-8A792B016EB1" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "6E99E674-82E7-4E03-A7DE-8E111238D8BD" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "25DAC3D2-3B61-4E11-BC73-8F55C02B06F7" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "BD8379B2-0CE7-4EE3-AE58-91E8B1E19A4A" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "C09711FE-F5BA-4C30-BBF5-9796ADE666AB" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "3EC271F9-151A-40C9-9FF7-997C2E850780" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "5B00FE5D-81F2-4211-BE96-9C7A3BF2B097" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "53955AC8-8268-49F8-B401-9D1299974D56" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "98DA014A-E969-407A-BD4B-A59D3FC96644" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "DD205413-BBA8-49F6-A7D7-AF26436FBEAA" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "3EBF1E8A-B1AA-421C-96B7-B89EF3D92040" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "14A411FA-3B83-4159-9BF0-C34FDECC78B9" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "C1C7EF85-B911-4BCE-98D6-DFE66AC859BA" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "BD0A5BDB-DAFF-4A31-BC1F-E1E7ACDC1608" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "CB82BAD0-F0DC-43E5-9BB4-E5455DC9FFE6" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "49FE89FE-476C-4779-BDC2-E5917A8B6473" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "78F09B80-9770-44F5-9B5D-F0CE5DA38661" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "95E8BBEA-4077-4F4E-877F-F263A328E068" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "A4F40F2B-44D2-40B6-8895-F3DCE9205E78" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "EB293770-5437-45A3-9FB7-F624F64103D7" });
            Delete.FromTable("Metadata_OptionSet").Row(new { OptionSetId = "D9B876CD-152F-4BC4-BCD6-FA938149A44C" });
        }
    }
}
