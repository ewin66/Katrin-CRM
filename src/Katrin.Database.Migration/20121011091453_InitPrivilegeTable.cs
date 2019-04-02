using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121011091453)]
    public class _20121011091453_InitPrivilegeTable : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "D5BAAE45-0925-403E-A8F3-008567D650CF", Name = "Write", AccessRight = 4 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "C0A80709-6AB1-40A0-811C-00CFBF145A31", Name = "Delete", AccessRight = 8 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "67FBD60D-FB42-4265-A6F9-084EF7074821", Name = "Write", AccessRight = 4 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "48B5E49F-EDA1-4EB7-8939-0B2379228BE3", Name = "Read", AccessRight = 1 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "7A18056C-F0EF-4E48-AA3B-0D0FC0210872", Name = "Delete", AccessRight = 8 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "0EE446C0-B1C9-4647-85CD-11F84D141027", Name = "Read", AccessRight = 1 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "41F6C5F2-2FFC-4961-855F-2146BB4025E4", Name = "Create", AccessRight = 2 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "24E81AC1-8CA8-4236-B22A-235DCB182A91", Name = "Delete", AccessRight = 8 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "220E53D3-1021-47D0-AE4F-2790F7E70A7C", Name = "Write", AccessRight = 4 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "D6D33C72-1DD3-4585-B74D-304E956A246E", Name = "Write", AccessRight = 4 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "F8679DEE-2B38-44C0-913B-331F91DFFAAC", Name = "Delete", AccessRight = 8 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "3A28E31A-CF9A-42F2-8286-3799761D7BCD", Name = "Create", AccessRight = 2 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "8E62226A-9312-46A2-BEA4-38CF5A5E191D", Name = "Create", AccessRight = 2 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "091FA426-84C1-48F1-9EA1-3C8F49E0F52C", Name = "Write", AccessRight = 4 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "A334A454-C565-4C9E-8199-41D238647C24", Name = "Delete", AccessRight = 8 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "7AD862E1-66DF-4D51-B28E-42B2286743EA", Name = "Create", AccessRight = 2 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "190233F6-3FDA-469E-A62E-46126B198F59", Name = "Create", AccessRight = 2 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "C206B2D4-3C2F-4B18-987B-46A617A83EFF", Name = "Write", AccessRight = 4 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "0693D9E9-4819-4C02-81AA-474534A1E5BD", Name = "Write", AccessRight = 4 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "0579F3EF-E30F-471E-96AB-4B22369FF3C3", Name = "Read", AccessRight = 1 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "B625EE77-967E-4B03-B000-5281DBFDF046", Name = "Write", AccessRight = 4 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "630A6A9D-8245-4DFB-9107-53C5926E0274", Name = "Create", AccessRight = 2 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "670A7FA4-5272-4B3D-A1B3-57F44C5FAA16", Name = "Read", AccessRight = 1 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "82489399-3CD7-4BD0-81FA-593AA93D535B", Name = "Delete", AccessRight = 8 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "ACCE0683-875A-461F-952F-5A0981B27390", Name = "Read", AccessRight = 1 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "D36A0EAF-C912-4F6D-8E24-608934AE1F52", Name = "Read", AccessRight = 1 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "03297383-838D-4FD9-9C73-6247AE41515D", Name = "Delete", AccessRight = 8 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "A6536FE5-69EC-45DC-AC45-62C1C036502A", Name = "Write", AccessRight = 4 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "E0B1CC69-2262-4C74-AD9F-67D6DA8F8373", Name = "Read", AccessRight = 1 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "AC406C12-87D4-4363-A4BF-6B9B0816AA10", Name = "Delete", AccessRight = 8 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "F4F77A0C-C1AB-48F2-BC6F-71C44C8883B8", Name = "Delete", AccessRight = 8 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "650C485A-FAA6-49B0-AA9B-7AAD9FE869AC", Name = "Read", AccessRight = 1 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "8560E798-FBD2-4730-ACD9-7BF055A54F99", Name = "Delete", AccessRight = 8 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "644D9EAE-9E51-43C2-B58E-87BE549694F3", Name = "Create", AccessRight = 2 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "08F4F0FA-F398-43CE-83D8-8F5AD3E41A6A", Name = "Write", AccessRight = 4 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "558F2DA7-53FE-4A02-AB32-904B70D9EED8", Name = "Read", AccessRight = 1 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "BBF3E024-D8A8-4749-A02B-927B2B502D98", Name = "Create", AccessRight = 2 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "4DA4F08F-5462-4409-98EB-93E9ABA3D12A", Name = "Create", AccessRight = 2 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "2C7024E5-209F-4C1C-9A7F-99C191826F7E", Name = "Create", AccessRight = 2 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "D823AE79-7133-4866-B33A-9C9B5FA14B4B", Name = "Create", AccessRight = 2 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "21345443-08EF-4DFD-B3A2-9D7616D3FB2B", Name = "Create", AccessRight = 2 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "D72DC9BF-C28B-42E0-94E8-A4C475FE3AF6", Name = "Delete", AccessRight = 8 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "3C5877FD-AE82-4024-B527-A70A06B7CC5A", Name = "Write", AccessRight = 4 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "780B6EFD-D56C-49F3-9A10-AC68E6ADDECE", Name = "Read", AccessRight = 1 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "5FAA5884-2439-4043-87E5-AD73C9669794", Name = "Create", AccessRight = 2 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "ECA8B59B-D981-44C0-BE8A-B28625CAB2B7", Name = "Write", AccessRight = 4 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "069AD551-94E6-4AA9-8AA5-B4928EF29966", Name = "Create", AccessRight = 2 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "44D7D0F9-ADD4-46B1-A6D1-B5D6DBB0B774", Name = "Write", AccessRight = 4 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "DAAC849A-BBAC-4691-9D09-B6A3D06B646F", Name = "Read", AccessRight = 1 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "A6F6CF43-6AE2-4D38-8BD1-CAC0EF59C45A", Name = "Create", AccessRight = 2 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "0BB2457D-A99D-413C-B97B-D3384346CB9D", Name = "Read", AccessRight = 1 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "B9E7EBBE-55DE-420E-9F8D-DACB21C8E83C", Name = "Write", AccessRight = 4 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "5BDF4D52-909D-4FC9-A8BF-DE5ADFECE791", Name = "Read", AccessRight = 1 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "DC0530D1-B243-4132-B2C9-E43C22DF7C63", Name = "Read", AccessRight = 1 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "C1553B08-9B98-4D15-9186-E763CBC454BB", Name = "Delete", AccessRight = 8 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "5035AEFF-42D7-4780-ABE5-E8727709ED1F", Name = "Read", AccessRight = 1 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "D14BAAC5-4EF0-4426-A4C3-EAECA2787608", Name = "Read", AccessRight = 1 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "03BCD26F-47DE-4E8D-A117-F116F6112D21", Name = "Write", AccessRight = 4 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "8CC18391-ECD6-49F3-833D-F310D21B4C0B", Name = "Read", AccessRight = 1 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "CC3D9E8F-A4ED-43F5-A19A-F368CB055AC2", Name = "Delete", AccessRight = 8 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "BEFD89FC-4846-4E50-84AF-FB5D8C247C2B", Name = "Delete", AccessRight = 8 });
            Insert.IntoTable("Privilege").Row(new { PrivilegeId = "BE2C0145-DBC6-470A-ABA3-FCDC974D4C47", Name = "Delete", AccessRight = 8 });
        }
        public override void Down()
        {
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "D5BAAE45-0925-403E-A8F3-008567D650CF" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "C0A80709-6AB1-40A0-811C-00CFBF145A31" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "67FBD60D-FB42-4265-A6F9-084EF7074821" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "48B5E49F-EDA1-4EB7-8939-0B2379228BE3" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "7A18056C-F0EF-4E48-AA3B-0D0FC0210872" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "0EE446C0-B1C9-4647-85CD-11F84D141027" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "41F6C5F2-2FFC-4961-855F-2146BB4025E4" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "24E81AC1-8CA8-4236-B22A-235DCB182A91" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "220E53D3-1021-47D0-AE4F-2790F7E70A7C" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "D6D33C72-1DD3-4585-B74D-304E956A246E" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "F8679DEE-2B38-44C0-913B-331F91DFFAAC" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "3A28E31A-CF9A-42F2-8286-3799761D7BCD" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "8E62226A-9312-46A2-BEA4-38CF5A5E191D" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "091FA426-84C1-48F1-9EA1-3C8F49E0F52C" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "A334A454-C565-4C9E-8199-41D238647C24" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "7AD862E1-66DF-4D51-B28E-42B2286743EA" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "190233F6-3FDA-469E-A62E-46126B198F59" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "C206B2D4-3C2F-4B18-987B-46A617A83EFF" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "0693D9E9-4819-4C02-81AA-474534A1E5BD" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "0579F3EF-E30F-471E-96AB-4B22369FF3C3" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "B625EE77-967E-4B03-B000-5281DBFDF046" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "630A6A9D-8245-4DFB-9107-53C5926E0274" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "670A7FA4-5272-4B3D-A1B3-57F44C5FAA16" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "82489399-3CD7-4BD0-81FA-593AA93D535B" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "ACCE0683-875A-461F-952F-5A0981B27390" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "D36A0EAF-C912-4F6D-8E24-608934AE1F52" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "03297383-838D-4FD9-9C73-6247AE41515D" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "A6536FE5-69EC-45DC-AC45-62C1C036502A" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "E0B1CC69-2262-4C74-AD9F-67D6DA8F8373" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "AC406C12-87D4-4363-A4BF-6B9B0816AA10" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "F4F77A0C-C1AB-48F2-BC6F-71C44C8883B8" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "650C485A-FAA6-49B0-AA9B-7AAD9FE869AC" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "8560E798-FBD2-4730-ACD9-7BF055A54F99" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "644D9EAE-9E51-43C2-B58E-87BE549694F3" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "08F4F0FA-F398-43CE-83D8-8F5AD3E41A6A" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "558F2DA7-53FE-4A02-AB32-904B70D9EED8" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "BBF3E024-D8A8-4749-A02B-927B2B502D98" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "4DA4F08F-5462-4409-98EB-93E9ABA3D12A" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "2C7024E5-209F-4C1C-9A7F-99C191826F7E" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "D823AE79-7133-4866-B33A-9C9B5FA14B4B" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "21345443-08EF-4DFD-B3A2-9D7616D3FB2B" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "D72DC9BF-C28B-42E0-94E8-A4C475FE3AF6" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "3C5877FD-AE82-4024-B527-A70A06B7CC5A" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "780B6EFD-D56C-49F3-9A10-AC68E6ADDECE" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "5FAA5884-2439-4043-87E5-AD73C9669794" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "ECA8B59B-D981-44C0-BE8A-B28625CAB2B7" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "069AD551-94E6-4AA9-8AA5-B4928EF29966" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "44D7D0F9-ADD4-46B1-A6D1-B5D6DBB0B774" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "DAAC849A-BBAC-4691-9D09-B6A3D06B646F" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "A6F6CF43-6AE2-4D38-8BD1-CAC0EF59C45A" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "0BB2457D-A99D-413C-B97B-D3384346CB9D" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "B9E7EBBE-55DE-420E-9F8D-DACB21C8E83C" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "5BDF4D52-909D-4FC9-A8BF-DE5ADFECE791" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "DC0530D1-B243-4132-B2C9-E43C22DF7C63" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "C1553B08-9B98-4D15-9186-E763CBC454BB" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "5035AEFF-42D7-4780-ABE5-E8727709ED1F" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "D14BAAC5-4EF0-4426-A4C3-EAECA2787608" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "03BCD26F-47DE-4E8D-A117-F116F6112D21" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "8CC18391-ECD6-49F3-833D-F310D21B4C0B" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "CC3D9E8F-A4ED-43F5-A19A-F368CB055AC2" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "BEFD89FC-4846-4E50-84AF-FB5D8C247C2B" });
            Delete.FromTable("Privilege").Row(new { PrivilegeId = "BE2C0145-DBC6-470A-ABA3-FCDC974D4C47" });
        }
    }
}
