using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katrin.AppFramework.Metadata;
using Katrin.AppFramework.MetadataServiceReference;
using Katrin.AppFramework.Security;
using ICSharpCode.Core;

namespace Katrin.Win.ConvertModule
{
    public class CovertDoozer : IDoozer
    {

        public bool HandleConditions
        {
            get
            {
                return true;
            }
        }

        public object BuildItem(BuildItemArgs args)
        {
            string entityName = args.Codon.Properties["entityName"];

            string addinFileName = AppDomain.CurrentDomain.BaseDirectory + "AddIns\\" + "Convert.AddIn";
            AddIn addin = AddIn.Load(addinFileName);

            List<Codon> subItems = GetSubItems(entityName,addin, args);
            if (subItems.Count <= 0) return null;

            ICSharpCode.Core.Properties properies = new ICSharpCode.Core.Properties();
            properies.Set<string>("id","CovertGroup");
            properies.Set<string>("type","Group");
            properies.Set<string>("label", "${res:ConvertTitle}");
            properies.Set<string>("OrderNumber","99");
            properies.Set<string>("builderid", "RibbonPageGroupBuilder");
            Codon codon = new Codon(addin, "MenuItem", properies, args.Conditions.ToArray());
            args.SubItemNode.AddCodons(subItems);
            return new MenuItemDescriptor(args.Caller, codon, args.BuildSubItems<object>(), args.Conditions);
        }

        private List<Codon> GetSubItems(string entityName,AddIn addin, BuildItemArgs args)
        {
            List<Codon> codonList = new List<Codon>();
            if (string.IsNullOrEmpty(entityName)) return codonList;
            List<ColumnMapping> mappingList = MetadataRepository.MappingList
                .Where(c => c.SourceEntityName == entityName).ToList();
            var toConverList = mappingList.Select(c => c.TargetEntityName).Distinct();
            if (toConverList.Any())
            {
                foreach (string commandName in toConverList)
                {
                    if (!AuthorizationManager.CheckAccess(commandName, "Write")) continue;
                    ICSharpCode.Core.Properties properies = new ICSharpCode.Core.Properties();
                    properies.Set<string>("id", "Convert" + commandName);
                    properies.Set<string>("type", "Item");
                    properies.Set<string>("label", "${res:" + commandName + "}");
                    properies.Set<string>("imageName", commandName);
                    properies.Set<string>("Parameter", commandName);
                    properies.Set<string>("groupName", "Convert");
                    properies.Set<string>("overlay", "overlay_convert");
                    properies.Set<string>("class", "Katrin.Win.ConvertModule.Commands.CovertCommand");
                    properies.Set<string>("builderid", "BarButtonItemBuilder");
                    if (toConverList.Count() > 1)
                        properies.Set<string>("RibbonStyle", "Small");
                   
                    Codon codon = new Codon(addin, "MenuItem", properies, args.Conditions.ToArray());
                    codonList.Add(codon);
                }
            }
            return codonList;
        }
    }
}
