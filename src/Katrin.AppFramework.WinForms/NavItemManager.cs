using Katrin.AppFramework.UIElements;
using DevExpress.XtraNavBar;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.NavBarBuilder;
using Katrin.AppFramework.WinForms.Doozers;
using Katrin.AppFramework.Security;

namespace Katrin.AppFramework.WinForms
{
    public class NavItemManager
    {
        public static void AddItemsToNavigation(NavBarControl ribbon, object owner, string addInTreePath)
        {
            var adapter = GetUIElementAdapter(ribbon);
            var descriptors = AddInTree.BuildItems<NavItemDescriptor>(addInTreePath, owner, false);
            List<NavItemDescriptor> removerItem = new List<NavItemDescriptor>();
            foreach (var descriptor in descriptors)
            {
                List<object> subRemoverItem = new List<object>();
                foreach (NavItemDescriptor subItem in descriptor.SubItems)
                {
                    if (!AuthorizationManager.CheckAccess(subItem.Codon.Id, "Read"))
                        subRemoverItem.Add(subItem);
                }
                foreach (var item in subRemoverItem)
                    descriptor.SubItems.Remove(item);

                if (descriptor.SubItems.Count <= 0)
                    removerItem.Add(descriptor);
            }
            foreach (var item in removerItem)
                descriptors.Remove(item);       
            BuildParts(adapter, descriptors);
        }

        private static IUIElementAdapter GetUIElementAdapter(object element)
        {
            var factoryCatalog = IoC.Get<IUIElementAdapterFactoryCatalog>();
            IUIElementAdapterFactory factory = factoryCatalog.GetFactory(element);
            IUIElementAdapter adapter = factory.GetAdapter(element);
            return adapter;
        }

        private static void BuildParts(IUIElementAdapter parent, IEnumerable<NavItemDescriptor> descriptors)
        {
            foreach (NavItemDescriptor descriptor in descriptors)
            {
                object uiElement = CreateMenuItemFromDescriptor(descriptor);
                parent.Add(uiElement);
                var children = descriptor.SubItems;
                if (children != null)
                {
                    var subDescriptors = children.Cast<NavItemDescriptor>();
                    if (!subDescriptors.Any()) continue;
                    var uiElementAapter = GetUIElementAdapter(uiElement);
                    BuildParts(uiElementAapter, subDescriptors);
                }
            }
        }

        static object CreateMenuItemFromDescriptor(NavItemDescriptor descriptor)
        {
            Codon codon = descriptor.Codon;
            string builderid = string.Empty;
            if (codon.Properties.Contains("builderid"))
            {
                builderid = codon.Properties["builderid"];
            }
            else
            {
                throw new Exception(string.Format("BuiderID not found:codonid ={0},condonname = {1}", codon.Id, codon.Name));
            }
            if (builderid == string.Empty)
            {
                throw new Exception(string.Format("BuiderID is empty:codonid ={0},condonname = {1}", codon.Id, codon.Name));
            }

            IPartBuilder builder = RibbonBuilderManager.GetBuider(builderid);
            object obj = builder.Build(codon, descriptor.Caller, codon.Conditions);
            if (obj is ModuleNavBarItem)
            {
                ModuleNavBarItem item = obj as ModuleNavBarItem;
                item.ModuleName = codon.Id;
              
            }
            return obj;
        }
    }
}
