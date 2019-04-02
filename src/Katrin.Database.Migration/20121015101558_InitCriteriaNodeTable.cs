using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121015101558)]
    public class _20121015101558_InitCriteriaNodeTable : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "38AEDC8B-1C9B-4841-AE1A-051F233599F6", CriteriaId = "C902BCBC-3FD6-41E2-8A5B-3D2FB007D343", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "E4E281D6-CB86-43B6-8B6F-0A744D904497", CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "C64B4FB5-A6C6-4D34-B70C-10E540CED7C4", CriteriaId = "46F4D060-7793-4222-B78D-67F558411C9B", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Group", OperatorType = "And", CompareAttributeId = (Guid?)null, CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "72B0EA94-542C-4A42-8F57-127E0B5EBB06", CriteriaId = "442171B7-A494-4635-ABE1-40B4C54C2CB2", ParentNodeId = "E5A34A8D-6CB5-439D-9F51-BCC5650C5C54", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "CD88A4D6-77D6-4303-B95E-DA78E43A2235", CompareValue = "false" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "C19362FE-017E-4EF9-B512-1FE4DAAB4DAB", CriteriaId = "CF47973C-9BED-449F-8F0E-2D4D6B26BB5A", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Group", OperatorType = "And", CompareAttributeId = (Guid?)null, CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "306132CE-449F-493F-935C-22737D0A9FF1", CriteriaId = "AE59976D-C2B1-4727-96E5-EED09153A4A2", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "E4E281D6-CB86-43B6-8B6F-0A744D904497", CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "DC4768FB-6273-413A-A08A-24B99D477D4F", CriteriaId = "B60A3845-AD4B-476E-B656-214A8721BE29", ParentNodeId = "4C2573EA-56E8-4AE9-8F1A-E955549440DD", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "CD88A4D6-77D6-4303-B95E-DA78E43A2235", CompareValue = "false" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "90B07F67-7434-4815-A2AA-26A0716C70B1", CriteriaId = "2B000F01-2A0B-4B19-AFCC-D218A6FCD434", ParentNodeId = "5F203320-C2D0-4FF4-9E99-BAED58C37E13", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "34C364B0-FEA5-4787-A99A-171B49ABEEA2", CompareValue = "false" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "38CB7BA1-BAB0-4AAC-B7EC-342196F5F17C", CriteriaId = "1009944B-63E7-4BA9-A7B0-B5A1381CA35B", ParentNodeId = "FFB1D5C4-7ACA-447A-B8CC-E7DB31BBA078", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "34C364B0-FEA5-4787-A99A-171B49ABEEA2", CompareValue = "false" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "0D4A34E5-3478-4F1D-B95C-3A94021728D6", CriteriaId = "4FE04CCA-EABC-42FD-9F66-B203633DBF89", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "3750D2A7-CD4D-42D6-9197-7D89FB26E24D", CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "77C2F97F-A8CA-4AE1-9B07-46171F278086", CriteriaId = "C7645994-E0A6-4FB4-A081-6D899C679A70", ParentNodeId = "FBAA733C-A3F9-4939-91B6-E2FC5C51BB69", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "D66AB72E-7AD6-4666-A985-3592F766EFE5", CompareValue = "false" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "EEF82B46-12B8-4E83-8076-50A737D64581", CriteriaId = "E80FFCB3-3092-49CE-AC80-F68F1B6DA468", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "E6B2079F-FCA1-45EB-933D-C189DD5A147E", CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "968E3C1E-DC6B-4C5D-BEB0-61B76700B0D1", CriteriaId = "F3A37163-BC68-478E-B286-53C6D688D638", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Group", OperatorType = "And", CompareAttributeId = (Guid?)null, CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "CDA91E00-16B5-4193-9159-61CE11D73D61", CriteriaId = "1CD6159F-9970-4901-92F2-2D5D7891BE42", ParentNodeId = "241B7752-217D-4542-9CDD-D1E02E4D9C79", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "06104359-D35E-4C37-BCC2-D7C0467C55C0", CompareValue = "false" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "6169188A-073E-42A1-96AA-67460EE8714E", CriteriaId = "CF47973C-9BED-449F-8F0E-2D4D6B26BB5A", ParentNodeId = "C19362FE-017E-4EF9-B512-1FE4DAAB4DAB", Operator = "TimeCompare", OperatorType = "Less", CompareAttributeId = "4881DD70-B063-404E-93F3-3174B31052B3", CompareValue = "3" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "ECDF787C-4E46-4557-A4A9-705CE04317B0", CriteriaId = "EE237D96-6A55-4673-BD68-791899382190", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "E4E281D6-CB86-43B6-8B6F-0A744D904497", CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "CBB2EFBC-0F8F-4F17-9742-710A1ED60483", CriteriaId = "EEBD3399-4EBE-4226-8FD0-52FE998AD497", ParentNodeId = "F8386850-1D82-4338-9DB1-87513359EDA1", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "D66AB72E-7AD6-4666-A985-3592F766EFE5", CompareValue = "false" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "223018D6-E53D-481D-8E12-7528C02AF84F", CriteriaId = "442171B7-A494-4635-ABE1-40B4C54C2CB2", ParentNodeId = "E5A34A8D-6CB5-439D-9F51-BCC5650C5C54", Operator = "TimeCompare", OperatorType = "GreaterOrEqual", CompareAttributeId = "DF575639-CC74-4B9B-9FA5-029C2010E4AA", CompareValue = "0" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "8CC04C7B-20F4-47D5-B464-8091E38CA82F", CriteriaId = "F3A37163-BC68-478E-B286-53C6D688D638", ParentNodeId = "968E3C1E-DC6B-4C5D-BEB0-61B76700B0D1", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "34C364B0-FEA5-4787-A99A-171B49ABEEA2", CompareValue = "false" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "E7CD6506-6511-4D5D-B268-825EDB9E0E4F", CriteriaId = "8A2F5543-068D-4ECA-B282-F848C9F1888F", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "2602C977-69E4-4E87-B9B0-FB4ED12D6404", CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "F8386850-1D82-4338-9DB1-87513359EDA1", CriteriaId = "EEBD3399-4EBE-4226-8FD0-52FE998AD497", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Group", OperatorType = "And", CompareAttributeId = (Guid?)null, CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "BE78DC4B-BF80-4F00-8520-A1FE6F35C962", CriteriaId = "02F2A407-9F53-46C0-A5C2-C6BFB08E4FF8", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "E4E281D6-CB86-43B6-8B6F-0A744D904497", CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "286E3478-EC90-4A00-B611-A8F54BB3FAE2", CriteriaId = "6D2545B1-8051-4C6B-8C9F-478728E1042A", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "E6B2079F-FCA1-45EB-933D-C189DD5A147E", CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "B21CE215-5A0D-420B-8037-AA09316ED382", CriteriaId = "984C86BA-3609-4D4D-922C-D35B756F2E1D", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "FCC649F2-8C51-40CA-B71D-6C1D4ED7ADC8", CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "91FF661C-0A11-4CEC-A1C9-B64E7712973A", CriteriaId = "2688B751-CF90-40A2-8531-FCED2DF5F0B1", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "F514528F-E75E-47CC-A27C-C371A93C20C2", CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "7EDFBDD6-9EC1-44C7-97BA-B7B70D5DB0EB", CriteriaId = "B60A3845-AD4B-476E-B656-214A8721BE29", ParentNodeId = "4C2573EA-56E8-4AE9-8F1A-E955549440DD", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "3750D2A7-CD4D-42D6-9197-7D89FB26E24D", CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "E275BA3B-BA23-48A8-BC09-BADFF9D57923", CriteriaId = "46F4D060-7793-4222-B78D-67F558411C9B", ParentNodeId = "C64B4FB5-A6C6-4D34-B70C-10E540CED7C4", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "34C364B0-FEA5-4787-A99A-171B49ABEEA2", CompareValue = "false" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "5F203320-C2D0-4FF4-9E99-BAED58C37E13", CriteriaId = "2B000F01-2A0B-4B19-AFCC-D218A6FCD434", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Group", OperatorType = "And", CompareAttributeId = (Guid?)null, CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "E5A34A8D-6CB5-439D-9F51-BCC5650C5C54", CriteriaId = "442171B7-A494-4635-ABE1-40B4C54C2CB2", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Group", OperatorType = "And", CompareAttributeId = (Guid?)null, CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "241B7752-217D-4542-9CDD-D1E02E4D9C79", CriteriaId = "1CD6159F-9970-4901-92F2-2D5D7891BE42", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Group", OperatorType = "And", CompareAttributeId = (Guid?)null, CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "B9A05DA3-9950-4800-B0B4-DC8C40B7733D", CriteriaId = "C6B9438C-AE55-47B1-BDE3-1C0D6D5B47CE", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "2602C977-69E4-4E87-B9B0-FB4ED12D6404", CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "E6E22224-F0EE-4443-8046-DD6FEECCBB9A", CriteriaId = "CF47973C-9BED-449F-8F0E-2D4D6B26BB5A", ParentNodeId = "C19362FE-017E-4EF9-B512-1FE4DAAB4DAB", Operator = "TimeCompare", OperatorType = "GreaterOrEqual", CompareAttributeId = "4881DD70-B063-404E-93F3-3174B31052B3", CompareValue = "0" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "F4597BF9-2245-48C3-9D91-E068AE55482C", CriteriaId = "442171B7-A494-4635-ABE1-40B4C54C2CB2", ParentNodeId = "E5A34A8D-6CB5-439D-9F51-BCC5650C5C54", Operator = "TimeCompare", OperatorType = "Less", CompareAttributeId = "DF575639-CC74-4B9B-9FA5-029C2010E4AA", CompareValue = "5" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "381A7C52-11DB-4840-A34F-E1022332C7A4", CriteriaId = "56A16CF7-3AEA-4873-AB84-B17AD7610469", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "E4E281D6-CB86-43B6-8B6F-0A744D904497", CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "FBAA733C-A3F9-4939-91B6-E2FC5C51BB69", CriteriaId = "C7645994-E0A6-4FB4-A081-6D899C679A70", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Group", OperatorType = "And", CompareAttributeId = (Guid?)null, CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "FFB1D5C4-7ACA-447A-B8CC-E7DB31BBA078", CriteriaId = "1009944B-63E7-4BA9-A7B0-B5A1381CA35B", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Group", OperatorType = "And", CompareAttributeId = (Guid?)null, CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "4C2573EA-56E8-4AE9-8F1A-E955549440DD", CriteriaId = "B60A3845-AD4B-476E-B656-214A8721BE29", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Group", OperatorType = "And", CompareAttributeId = (Guid?)null, CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "623ACC0E-3B28-45DC-8E66-ED21A6A301F3", CriteriaId = "6AE70226-8AC7-4362-89E6-570EB261F1F2", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "2602C977-69E4-4E87-B9B0-FB4ED12D6404", CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "0EA6F3A1-9234-4238-BF14-F369D1A9611A", CriteriaId = "E9C21274-D150-4F63-ACDD-07B2FCBA21ED", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "847756A7-EB95-410F-8474-E23F19D1A418", CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "47F0B2F5-B808-40E2-953C-F4A94C482069", CriteriaId = "E993F1DB-8E5C-4678-AC1E-30420EE3F00B", ParentNodeId = "00000000-0000-0000-0000-000000000000", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "2602C977-69E4-4E87-B9B0-FB4ED12D6404", CompareValue = "" });
            Insert.IntoTable("CriteriaNode").Row(new { CriteriaNodeId = "461723D7-B8AC-4B12-B06B-F7344EF35B43", CriteriaId = "CF47973C-9BED-449F-8F0E-2D4D6B26BB5A", ParentNodeId = "C19362FE-017E-4EF9-B512-1FE4DAAB4DAB", Operator = "Binry", OperatorType = "Equal", CompareAttributeId = "06104359-D35E-4C37-BCC2-D7C0467C55C0", CompareValue = "false" });
        }
        public override void Down()
        {
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "38AEDC8B-1C9B-4841-AE1A-051F233599F6" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "C64B4FB5-A6C6-4D34-B70C-10E540CED7C4" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "72B0EA94-542C-4A42-8F57-127E0B5EBB06" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "C19362FE-017E-4EF9-B512-1FE4DAAB4DAB" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "306132CE-449F-493F-935C-22737D0A9FF1" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "DC4768FB-6273-413A-A08A-24B99D477D4F" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "90B07F67-7434-4815-A2AA-26A0716C70B1" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "38CB7BA1-BAB0-4AAC-B7EC-342196F5F17C" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "0D4A34E5-3478-4F1D-B95C-3A94021728D6" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "77C2F97F-A8CA-4AE1-9B07-46171F278086" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "EEF82B46-12B8-4E83-8076-50A737D64581" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "968E3C1E-DC6B-4C5D-BEB0-61B76700B0D1" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "CDA91E00-16B5-4193-9159-61CE11D73D61" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "6169188A-073E-42A1-96AA-67460EE8714E" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "ECDF787C-4E46-4557-A4A9-705CE04317B0" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "CBB2EFBC-0F8F-4F17-9742-710A1ED60483" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "223018D6-E53D-481D-8E12-7528C02AF84F" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "8CC04C7B-20F4-47D5-B464-8091E38CA82F" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "E7CD6506-6511-4D5D-B268-825EDB9E0E4F" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "F8386850-1D82-4338-9DB1-87513359EDA1" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "BE78DC4B-BF80-4F00-8520-A1FE6F35C962" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "286E3478-EC90-4A00-B611-A8F54BB3FAE2" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "B21CE215-5A0D-420B-8037-AA09316ED382" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "91FF661C-0A11-4CEC-A1C9-B64E7712973A" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "7EDFBDD6-9EC1-44C7-97BA-B7B70D5DB0EB" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "E275BA3B-BA23-48A8-BC09-BADFF9D57923" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "5F203320-C2D0-4FF4-9E99-BAED58C37E13" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "E5A34A8D-6CB5-439D-9F51-BCC5650C5C54" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "241B7752-217D-4542-9CDD-D1E02E4D9C79" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "B9A05DA3-9950-4800-B0B4-DC8C40B7733D" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "E6E22224-F0EE-4443-8046-DD6FEECCBB9A" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "F4597BF9-2245-48C3-9D91-E068AE55482C" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "381A7C52-11DB-4840-A34F-E1022332C7A4" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "FBAA733C-A3F9-4939-91B6-E2FC5C51BB69" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "FFB1D5C4-7ACA-447A-B8CC-E7DB31BBA078" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "4C2573EA-56E8-4AE9-8F1A-E955549440DD" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "623ACC0E-3B28-45DC-8E66-ED21A6A301F3" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "0EA6F3A1-9234-4238-BF14-F369D1A9611A" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "47F0B2F5-B808-40E2-953C-F4A94C482069" });
            Delete.FromTable("CriteriaNode").Row(new { CriteriaNodeId = "461723D7-B8AC-4B12-B06B-F7344EF35B43" });
        }
    }
}
