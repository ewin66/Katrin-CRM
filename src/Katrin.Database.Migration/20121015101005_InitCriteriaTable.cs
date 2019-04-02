using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121015101005)]
    public class _20121015101005_InitCriteriaTable:Migration
    {
        public override void Up()
        {
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "E9C21274-D150-4F63-ACDD-07B2FCBA21ED", Name = "ProjectTask-Owner-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "C6B9438C-AE55-47B1-BDE3-1C0D6D5B47CE", Name = "NOTE-Member-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "B60A3845-AD4B-476E-B656-214A8721BE29", Name = "Contract-Member-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "CF47973C-9BED-449F-8F0E-2D4D6B26BB5A", Name = "ProjectTask-EndDate-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "1CD6159F-9970-4901-92F2-2D5D7891BE42", Name = "ProjectTask-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "E993F1DB-8E5C-4678-AC1E-30420EE3F00B", Name = "NOTE-Member-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "C902BCBC-3FD6-41E2-8A5B-3D2FB007D343", Name = "Technician-Member-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "442171B7-A494-4635-ABE1-40B4C54C2CB2", Name = "Contract-ExpiresOn-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "6D2545B1-8051-4C6B-8C9F-478728E1042A", Name = "LEAD-Member-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "EEBD3399-4EBE-4226-8FD0-52FE998AD497", Name = "Opportunity-LEAD-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "F3A37163-BC68-478E-B286-53C6D688D638", Name = "NOTE-Contract-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "6AE70226-8AC7-4362-89E6-570EB261F1F2", Name = "NOTE-Member-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "46F4D060-7793-4222-B78D-67F558411C9B", Name = "NOTE-Opportunity-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "C7645994-E0A6-4FB4-A081-6D899C679A70", Name = "Opportunity-Update-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "EE237D96-6A55-4673-BD68-791899382190", Name = "LEAD-Member-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "56A16CF7-3AEA-4873-AB84-B17AD7610469", Name = "Technician-Member-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "4FE04CCA-EABC-42FD-9F66-B203633DBF89", Name = "Contract-Member-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "1009944B-63E7-4BA9-A7B0-B5A1381CA35B", Name = "NOTE-LEAD-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "02F2A407-9F53-46C0-A5C2-C6BFB08E4FF8", Name = "Opportunity-Member-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "2B000F01-2A0B-4B19-AFCC-D218A6FCD434", Name = "NOTE-Quote-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "984C86BA-3609-4D4D-922C-D35B756F2E1D", Name = "Quote-Member-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "AE59976D-C2B1-4727-96E5-EED09153A4A2", Name = "Opportunity-Member-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "E80FFCB3-3092-49CE-AC80-F68F1B6DA468", Name = "LEAD-Member-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "8A2F5543-068D-4ECA-B282-F848C9F1888F", Name = "NOTE-Member-Criteria" });
            Insert.IntoTable("Criteria").Row(new { CriteriaId = "2688B751-CF90-40A2-8531-FCED2DF5F0B1", Name = "Project-Member-Criteria" });
        }
        public override void Down()
        {
            Delete.FromTable("Criteria").Row(new { CriteriaId = "E9C21274-D150-4F63-ACDD-07B2FCBA21ED" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "C6B9438C-AE55-47B1-BDE3-1C0D6D5B47CE" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "B60A3845-AD4B-476E-B656-214A8721BE29" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "CF47973C-9BED-449F-8F0E-2D4D6B26BB5A" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "1CD6159F-9970-4901-92F2-2D5D7891BE42" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "E993F1DB-8E5C-4678-AC1E-30420EE3F00B" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "C902BCBC-3FD6-41E2-8A5B-3D2FB007D343" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "442171B7-A494-4635-ABE1-40B4C54C2CB2" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "6D2545B1-8051-4C6B-8C9F-478728E1042A" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "EEBD3399-4EBE-4226-8FD0-52FE998AD497" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "F3A37163-BC68-478E-B286-53C6D688D638" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "6AE70226-8AC7-4362-89E6-570EB261F1F2" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "46F4D060-7793-4222-B78D-67F558411C9B" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "C7645994-E0A6-4FB4-A081-6D899C679A70" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "EE237D96-6A55-4673-BD68-791899382190" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "56A16CF7-3AEA-4873-AB84-B17AD7610469" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "4FE04CCA-EABC-42FD-9F66-B203633DBF89" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "1009944B-63E7-4BA9-A7B0-B5A1381CA35B" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "02F2A407-9F53-46C0-A5C2-C6BFB08E4FF8" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "2B000F01-2A0B-4B19-AFCC-D218A6FCD434" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "984C86BA-3609-4D4D-922C-D35B756F2E1D" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "AE59976D-C2B1-4727-96E5-EED09153A4A2" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "E80FFCB3-3092-49CE-AC80-F68F1B6DA468" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "8A2F5543-068D-4ECA-B282-F848C9F1888F" });
            Delete.FromTable("Criteria").Row(new { CriteriaId = "2688B751-CF90-40A2-8531-FCED2DF5F0B1" });
        }
    }
}
