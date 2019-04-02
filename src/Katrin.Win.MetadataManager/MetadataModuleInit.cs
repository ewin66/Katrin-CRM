using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;
using Katrin.Win.Common.Constants;
using Microsoft.Practices.CompositeUI.SmartParts;
using DevExpress.XtraNavBar;
using Katrin.Win.Common.Core;
using Katrin.Win.MetadataManager.Properties;
using System.Drawing;

namespace Katrin.Win.MetadataManager
{
    public class MetadataModuleInit : ModuleInit
    {
        private readonly WorkItem workItem;

        [InjectionConstructor]
        public MetadataModuleInit([ServiceDependency] WorkItem workItem)
        {
            this.workItem = workItem;
        }

        public override void Load()
        {
            AddEntityListNavBarItem<MetadataController>("Entity");
            base.Load();
        }
        private Dictionary<string, List<string>> _moduleGroups = new Dictionary<string, List<string>>();
        private void AddEntityListNavBarItem<T>(string name) where T : WorkItem
        {
            _moduleGroups.Add("Entity", new List<string>(new[]
                                                            {
                                                                "Entity"
                                                            }));
            foreach (var moduleGroup in _moduleGroups)
            {
                var group = new NavBarGroup(GetLocalizedCaption(moduleGroup.Key));
                foreach (var module in moduleGroup.Value)
                {
                    //if (!AuthorizationManager.CheckAccess(module, "Read")) continue;
                    var localizedCaption = GetLocalizedCaption(module);
                    var item = new NavBarItem(localizedCaption);

                    string moduleName = module;
                    item.LinkClicked += (s, e) => ShowEntityList<T>(moduleName);
                    item.Name = module;
                    item.SmallImage = GetBitmapByName(module);
                    group.ItemLinks.Add(item);
                }
                if (group.ItemLinks.Count == 0) continue;

                group.SmallImage = GetBitmapByName(moduleGroup.Key);
                workItem.UIExtensionSites[ExtensionSiteNames.ShellNavBar].Add(group);
            }
        }

        private string GetLocalizedCaption(string name)
        {
            return Resources.ResourceManager.GetString(name);
        }

        private Bitmap GetBitmapByName(string name)
        {
            var icon = (Icon)Resources.ResourceManager.GetObject("ri_" + name.ToLower());
            if (icon == null) return null;
            return icon.ToBitmap();
        }

        private void ShowEntityList<T>(string entityName) where T : WorkItem
        {
            string key = entityName + "List";
            workItem.Services.Get<ISingleWorkItemService>().ShowEntityList<T>(workItem, key);
        }
    }
}
