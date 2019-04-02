using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katrin.AppFramework.Metadata;
using Katrin.AppFramework.MetadataServiceReference;
using Katrin.AppFramework.Security;
using ICSharpCode.Core;

namespace Katrin.Win.RelatedModule
{
    public class RelatedDoozer : IDoozer
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

            string addinFileName = AppDomain.CurrentDomain.BaseDirectory + "AddIns\\" + "Related.AddIn";
            AddIn addin = AddIn.Load(addinFileName);

            List<Codon> subItems = GetSubItems(entityName,addin, args);
            if (subItems.Count <= 0) return null;

            ICSharpCode.Core.Properties properies = new ICSharpCode.Core.Properties();
            properies.Set<string>("id","RelatedGroup");
            properies.Set<string>("type","Group");
            properies.Set<string>("label", "${res:Related}");
            properies.Set<string>("OrderNumber","98");
            properies.Set<string>("builderid", "RibbonPageGroupBuilder");
            Codon codon = new Codon(addin, "MenuItem", properies, args.Conditions.ToArray());
            args.SubItemNode.AddCodons(subItems);
            return new MenuItemDescriptor(args.Caller, codon, args.BuildSubItems<object>(), args.Conditions);
        }

        private List<Codon> GetSubItems(string entityName,AddIn addin, BuildItemArgs args)
        {
            List<Codon> codonList = new List<Codon>();
            if (string.IsNullOrEmpty(entityName)) return codonList;

            var allRelationshipRoles = MetadataRepository.EntityRelationshipRoles;
            var relationshipRoles = allRelationshipRoles.Where(role => role.Entity.PhysicalName == entityName && role.NavPanelDisplayOption == 1);
            if (relationshipRoles.Any())
            {
                foreach (var relationshipRole in relationshipRoles)
                {
                    
                    var entityRelation = relationshipRole.EntityRelationship;
                    var relatedRole = entityRelation.EntityRelationshipRoles
                        .FirstOrDefault(r => r != relationshipRole
                            && r.RelationshipRoleType != (int)RelationshipRoleType.Relationship);
                    if (relatedRole == null) continue;
                    var commandName = relatedRole.Entity.PhysicalName;
                    if (!AuthorizationManager.CheckAccess(commandName, "Read")) continue;
                    ICSharpCode.Core.Properties properies = new ICSharpCode.Core.Properties();
                    properies.Set<string>("id", commandName);
                    properies.Set<string>("type", "Item");
                    properies.Set<string>("label", "${res:" + commandName + "}");
                    properies.Set<string>("imageName", commandName);
                    properies.Set<string>("overlay", "overlay_search");
                    properies.Set<string>("Parameter", commandName);
                    properies.Set<string>("groupName", "Related");
                    properies.Set<string>("class", "Katrin.Win.RelatedModule.Commands.RelatedCommand");
                    properies.Set<string>("builderid", "BarButtonItemBuilder");
                    if (relationshipRoles.Count() > 1)
                        properies.Set<string>("RibbonStyle", "Small");

                    Codon codon = new Codon(addin, "MenuItem", properies, args.Conditions.ToArray());
                    codonList.Add(codon);
                }
            }
            return codonList;
        }
    }

    public enum RelationshipRoleType
    {
        OneToMany = 0,
        ManyToOne = 1,
        ManyToMany = 2,
        Relationship = 3
    }
}
