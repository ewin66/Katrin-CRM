using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121011092038)]
    public class _20121011092038_InitPrivilegeEntityTable : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "BF0A618D-9F2F-4EDD-9DC3-00D29FBFEB4A", PrivilegeId = "ECA8B59B-D981-44C0-BE8A-B28625CAB2B7", EntityName = "Invoice" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "23CAABF0-275F-41C1-A384-048199C20303", PrivilegeId = "BBF3E024-D8A8-4749-A02B-927B2B502D98", EntityName = "Invoice" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "BFCDA593-06CE-43DE-9541-06AA4859B932", PrivilegeId = "190233F6-3FDA-469E-A62E-46126B198F59", EntityName = "Role" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "E007B43F-4643-4D2C-81CF-0AF3EBBC6521", PrivilegeId = "D5BAAE45-0925-403E-A8F3-008567D650CF", EntityName = "SystemSetting" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "30E3702F-0BDD-4046-AD39-0F2DE0CD02A9", PrivilegeId = "03BCD26F-47DE-4E8D-A117-F116F6112D21", EntityName = "Opportunity" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "EBD6F159-2E9A-420C-BE72-26591B9C9833", PrivilegeId = "5035AEFF-42D7-4780-ABE5-E8727709ED1F", EntityName = "Account" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "2D83B599-4FFC-475E-B92F-298FBF2D79BE", PrivilegeId = "21345443-08EF-4DFD-B3A2-9D7616D3FB2B", EntityName = "Quote" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "75FE5174-C05A-414B-9E29-2F58FCBF5738", PrivilegeId = "08F4F0FA-F398-43CE-83D8-8F5AD3E41A6A", EntityName = "ProjectWeekReport" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "6EDEF664-D853-49D8-835C-307BFBC974A2", PrivilegeId = "0693D9E9-4819-4C02-81AA-474534A1E5BD", EntityName = "Attendance" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "2C04793E-AD45-4D08-848F-3EF0932A6563", PrivilegeId = "780B6EFD-D56C-49F3-9A10-AC68E6ADDECE", EntityName = "Product" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "3B821D76-0D49-4825-8C8A-42EFBF45F4CA", PrivilegeId = "CC3D9E8F-A4ED-43F5-A19A-F368CB055AC2", EntityName = "Invoice" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "9F31BB30-31D3-4974-A3AA-437D8AAC0423", PrivilegeId = "3C5877FD-AE82-4024-B527-A70A06B7CC5A", EntityName = "ProjectTask" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "1A1CAFCD-6C09-4B8D-85E0-4A5662A02386", PrivilegeId = "41F6C5F2-2FFC-4961-855F-2146BB4025E4", EntityName = "Contract" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "77310260-0F06-4A44-A5B4-50A4B6C37087", PrivilegeId = "AC406C12-87D4-4363-A4BF-6B9B0816AA10", EntityName = "Product" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "E4E174FB-BD25-4199-AC21-5156D20679BD", PrivilegeId = "670A7FA4-5272-4B3D-A1B3-57F44C5FAA16", EntityName = "Quote" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "2DECE88F-628F-4632-9F0E-51CEC66CEDBD", PrivilegeId = "A6536FE5-69EC-45DC-AC45-62C1C036502A", EntityName = "User" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "260D9C5D-929A-48CB-8980-594B93E71CD1", PrivilegeId = "C0A80709-6AB1-40A0-811C-00CFBF145A31", EntityName = "Opportunity" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "3342C994-893E-4077-A5EA-5BDBF193C833", PrivilegeId = "2C7024E5-209F-4C1C-9A7F-99C191826F7E", EntityName = "Product" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "8DECBE34-7A4D-4FE7-9626-5FCC822DDE29", PrivilegeId = "E0B1CC69-2262-4C74-AD9F-67D6DA8F8373", EntityName = "Role" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "3E587304-42DC-40F3-A3AB-6371B87CEBE2", PrivilegeId = "A334A454-C565-4C9E-8199-41D238647C24", EntityName = "User" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "3D3445BB-B437-4160-87B5-67132193F5CA", PrivilegeId = "44D7D0F9-ADD4-46B1-A6D1-B5D6DBB0B774", EntityName = "Contract" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "B6B85B14-A2FE-462D-94D1-673876A836DC", PrivilegeId = "BE2C0145-DBC6-470A-ABA3-FCDC974D4C47", EntityName = "Account" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "561CF529-DCC7-48D8-AB3E-68136A32119B", PrivilegeId = "7A18056C-F0EF-4E48-AA3B-0D0FC0210872", EntityName = "Role" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "926434C5-7465-44C4-B008-681FE822BC19", PrivilegeId = "630A6A9D-8245-4DFB-9107-53C5926E0274", EntityName = "Project" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "C2D07672-D730-4320-A1F4-722744DF048A", PrivilegeId = "091FA426-84C1-48F1-9EA1-3C8F49E0F52C", EntityName = "Product" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "D93C6468-F902-4BCF-A64F-723B98BCF32E", PrivilegeId = "D72DC9BF-C28B-42E0-94E8-A4C475FE3AF6", EntityName = "Contact" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "277B9489-9ACF-4AED-832A-765CA5210339", PrivilegeId = "0BB2457D-A99D-413C-B97B-D3384346CB9D", EntityName = "SystemSetting" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "192C0D98-1E3A-4861-B666-766E04B4CAA2", PrivilegeId = "F4F77A0C-C1AB-48F2-BC6F-71C44C8883B8", EntityName = "SystemSetting" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "6D9D5D36-626D-460A-91B5-812E7FDDAEB4", PrivilegeId = "8E62226A-9312-46A2-BEA4-38CF5A5E191D", EntityName = "ProjectTask" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "4334AFF3-C862-4D70-A1CE-833CA5BBEB01", PrivilegeId = "8560E798-FBD2-4730-ACD9-7BF055A54F99", EntityName = "ProjectWeekReport" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "5571EE4C-AD23-4C8E-8D98-838D24CEC186", PrivilegeId = "0EE446C0-B1C9-4647-85CD-11F84D141027", EntityName = "User" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "F1FF1292-FC71-4C3F-BCFB-83A3B70788EB", PrivilegeId = "DC0530D1-B243-4132-B2C9-E43C22DF7C63", EntityName = "Attendance" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "CA11658D-7472-4ED3-86B3-89A8DAE2E4EC", PrivilegeId = "8CC18391-ECD6-49F3-833D-F310D21B4C0B", EntityName = "Contact" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "79DA0E1C-5B07-4773-8B1F-89EF6098951A", PrivilegeId = "DAAC849A-BBAC-4691-9D09-B6A3D06B646F", EntityName = "ProjectTask" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "EC553522-0DD7-49DA-A3B2-8A4D902FDB9B", PrivilegeId = "48B5E49F-EDA1-4EB7-8939-0B2379228BE3", EntityName = "ProjectReport" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "9E5E5465-DD4F-423A-BB5C-90A7B9EEF028", PrivilegeId = "C206B2D4-3C2F-4B18-987B-46A617A83EFF", EntityName = "Role" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "021F8219-2824-4FC2-8EF2-93FEEE8B231A", PrivilegeId = "B625EE77-967E-4B03-B000-5281DBFDF046", EntityName = "Quote" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "1CC968BA-AA5D-4BD4-9F31-981FBA2B4977", PrivilegeId = "220E53D3-1021-47D0-AE4F-2790F7E70A7C", EntityName = "Contact" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "D9D87B2F-29B6-430E-83B3-9DB0DE6B7F11", PrivilegeId = "D14BAAC5-4EF0-4426-A4C3-EAECA2787608", EntityName = "Project" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "F636AA6C-FBE8-40A0-8C28-9E88A2B8AA32", PrivilegeId = "82489399-3CD7-4BD0-81FA-593AA93D535B", EntityName = "Attendance" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "187BD52D-3C49-4CDB-8DA9-A17DBCF645B1", PrivilegeId = "D823AE79-7133-4866-B33A-9C9B5FA14B4B", EntityName = "User" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "1967430E-BFA5-442E-929F-A1D058E87FA1", PrivilegeId = "0579F3EF-E30F-471E-96AB-4B22369FF3C3", EntityName = "Contract" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "0C0794AE-6AEA-4986-9E5B-A4FE25CCC4CD", PrivilegeId = "BEFD89FC-4846-4E50-84AF-FB5D8C247C2B", EntityName = "Lead" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "D23ED7EF-2B8D-4816-9D33-A722C624E287", PrivilegeId = "ACCE0683-875A-461F-952F-5A0981B27390", EntityName = "ProjectWeekReport" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "72C19F40-27F3-456B-8C65-A964BF23416D", PrivilegeId = "A6F6CF43-6AE2-4D38-8BD1-CAC0EF59C45A", EntityName = "Contact" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "0BE475FE-AB66-40C9-AF3C-AEA33DF21CE5", PrivilegeId = "B9E7EBBE-55DE-420E-9F8D-DACB21C8E83C", EntityName = "Project" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "BC73230F-4566-4755-9231-AEA4D2628E22", PrivilegeId = "558F2DA7-53FE-4A02-AB32-904B70D9EED8", EntityName = "Opportunity" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "1455D337-EF6D-402A-9939-B20A979F37F0", PrivilegeId = "C1553B08-9B98-4D15-9186-E763CBC454BB", EntityName = "Quote" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "30760FE9-BEA3-4975-B0F9-B296B9F0AD49", PrivilegeId = "4DA4F08F-5462-4409-98EB-93E9ABA3D12A", EntityName = "Lead" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "A1CAB148-2449-4231-B14F-B8AC1A0EB4D0", PrivilegeId = "644D9EAE-9E51-43C2-B58E-87BE549694F3", EntityName = "Opportunity" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "AD12EA0B-A712-44DE-AED0-BC5CC070D9B5", PrivilegeId = "069AD551-94E6-4AA9-8AA5-B4928EF29966", EntityName = "Account" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "D6FA0FE0-34F9-4F1D-A99A-BDB83A9E2350", PrivilegeId = "03297383-838D-4FD9-9C73-6247AE41515D", EntityName = "ProjectTask" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "0D61F982-BF62-4DD9-9C48-D2FBBC826EC7", PrivilegeId = "D6D33C72-1DD3-4585-B74D-304E956A246E", EntityName = "Account" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "28F23AAA-2016-47D3-BCEC-D4A45427FDB8", PrivilegeId = "24E81AC1-8CA8-4236-B22A-235DCB182A91", EntityName = "Project" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "47B562E8-31DD-4DBB-BAFB-DC9066F3D1C8", PrivilegeId = "5BDF4D52-909D-4FC9-A8BF-DE5ADFECE791", EntityName = "OpportunityReport" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "5E9D0550-BCC7-4DF1-9D74-DF0C2F9F2E3C", PrivilegeId = "5FAA5884-2439-4043-87E5-AD73C9669794", EntityName = "ProjectWeekReport" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "2DD9856A-0122-417A-A633-DFEC121FA07F", PrivilegeId = "67FBD60D-FB42-4265-A6F9-084EF7074821", EntityName = "Lead" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "8E3F5BE3-A142-4047-84F1-E23B668ADBD0", PrivilegeId = "650C485A-FAA6-49B0-AA9B-7AAD9FE869AC", EntityName = "Invoice" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "A50635F6-8E06-4D8C-AFAA-E5EF07FF3BD9", PrivilegeId = "7AD862E1-66DF-4D51-B28E-42B2286743EA", EntityName = "SystemSetting" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "C6676302-0E3C-4C3A-BA9F-EE9AAC77D1AC", PrivilegeId = "F8679DEE-2B38-44C0-913B-331F91DFFAAC", EntityName = "Contract" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "DA401E07-5BE4-44EF-99C6-F4A01DA7EBEB", PrivilegeId = "D36A0EAF-C912-4F6D-8E24-608934AE1F52", EntityName = "Lead" });
            Insert.IntoTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "47200794-B149-433A-8F1D-FF491C410890", PrivilegeId = "3A28E31A-CF9A-42F2-8286-3799761D7BCD", EntityName = "Attendance" });
        }
        public override void Down()
        {
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "BF0A618D-9F2F-4EDD-9DC3-00D29FBFEB4A" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "23CAABF0-275F-41C1-A384-048199C20303" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "BFCDA593-06CE-43DE-9541-06AA4859B932" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "E007B43F-4643-4D2C-81CF-0AF3EBBC6521" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "30E3702F-0BDD-4046-AD39-0F2DE0CD02A9" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "EBD6F159-2E9A-420C-BE72-26591B9C9833" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "2D83B599-4FFC-475E-B92F-298FBF2D79BE" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "75FE5174-C05A-414B-9E29-2F58FCBF5738" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "6EDEF664-D853-49D8-835C-307BFBC974A2" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "2C04793E-AD45-4D08-848F-3EF0932A6563" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "3B821D76-0D49-4825-8C8A-42EFBF45F4CA" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "9F31BB30-31D3-4974-A3AA-437D8AAC0423" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "1A1CAFCD-6C09-4B8D-85E0-4A5662A02386" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "77310260-0F06-4A44-A5B4-50A4B6C37087" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "E4E174FB-BD25-4199-AC21-5156D20679BD" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "2DECE88F-628F-4632-9F0E-51CEC66CEDBD" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "260D9C5D-929A-48CB-8980-594B93E71CD1" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "3342C994-893E-4077-A5EA-5BDBF193C833" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "8DECBE34-7A4D-4FE7-9626-5FCC822DDE29" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "3E587304-42DC-40F3-A3AB-6371B87CEBE2" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "3D3445BB-B437-4160-87B5-67132193F5CA" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "B6B85B14-A2FE-462D-94D1-673876A836DC" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "561CF529-DCC7-48D8-AB3E-68136A32119B" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "926434C5-7465-44C4-B008-681FE822BC19" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "C2D07672-D730-4320-A1F4-722744DF048A" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "D93C6468-F902-4BCF-A64F-723B98BCF32E" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "277B9489-9ACF-4AED-832A-765CA5210339" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "192C0D98-1E3A-4861-B666-766E04B4CAA2" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "6D9D5D36-626D-460A-91B5-812E7FDDAEB4" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "4334AFF3-C862-4D70-A1CE-833CA5BBEB01" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "5571EE4C-AD23-4C8E-8D98-838D24CEC186" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "F1FF1292-FC71-4C3F-BCFB-83A3B70788EB" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "CA11658D-7472-4ED3-86B3-89A8DAE2E4EC" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "79DA0E1C-5B07-4773-8B1F-89EF6098951A" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "EC553522-0DD7-49DA-A3B2-8A4D902FDB9B" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "9E5E5465-DD4F-423A-BB5C-90A7B9EEF028" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "021F8219-2824-4FC2-8EF2-93FEEE8B231A" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "1CC968BA-AA5D-4BD4-9F31-981FBA2B4977" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "D9D87B2F-29B6-430E-83B3-9DB0DE6B7F11" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "F636AA6C-FBE8-40A0-8C28-9E88A2B8AA32" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "187BD52D-3C49-4CDB-8DA9-A17DBCF645B1" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "1967430E-BFA5-442E-929F-A1D058E87FA1" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "0C0794AE-6AEA-4986-9E5B-A4FE25CCC4CD" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "D23ED7EF-2B8D-4816-9D33-A722C624E287" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "72C19F40-27F3-456B-8C65-A964BF23416D" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "0BE475FE-AB66-40C9-AF3C-AEA33DF21CE5" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "BC73230F-4566-4755-9231-AEA4D2628E22" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "1455D337-EF6D-402A-9939-B20A979F37F0" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "30760FE9-BEA3-4975-B0F9-B296B9F0AD49" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "A1CAB148-2449-4231-B14F-B8AC1A0EB4D0" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "AD12EA0B-A712-44DE-AED0-BC5CC070D9B5" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "D6FA0FE0-34F9-4F1D-A99A-BDB83A9E2350" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "0D61F982-BF62-4DD9-9C48-D2FBBC826EC7" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "28F23AAA-2016-47D3-BCEC-D4A45427FDB8" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "47B562E8-31DD-4DBB-BAFB-DC9066F3D1C8" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "5E9D0550-BCC7-4DF1-9D74-DF0C2F9F2E3C" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "2DD9856A-0122-417A-A633-DFEC121FA07F" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "8E3F5BE3-A142-4047-84F1-E23B668ADBD0" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "A50635F6-8E06-4D8C-AFAA-E5EF07FF3BD9" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "C6676302-0E3C-4C3A-BA9F-EE9AAC77D1AC" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "DA401E07-5BE4-44EF-99C6-F4A01DA7EBEB" });
            Delete.FromTable("PrivilegeEntity").Row(new { PrivilegeEntityId = "47200794-B149-433A-8F1D-FF491C410890" });
        }
    }
}
