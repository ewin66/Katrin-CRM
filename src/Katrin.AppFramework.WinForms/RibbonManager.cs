using Katrin.AppFramework.UIElements;
using DevExpress.XtraBars.Ribbon;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.RibbonBuilder;
using DevExpress.XtraBars;
using Katrin.AppFramework.WinForms.CommandManage;
using System.Diagnostics;

namespace Katrin.AppFramework.WinForms
{
    public class RibbonManager
    {
        public static void AddItemsToMenu(object ribbon,
            object owner,
            string addInTreePath,
            ICommandRegister register)
        {
            //System.Diagnostics.Debug.WriteLine("Ribbon building:" + addInTreePath);
            var adapter = GetUIElementAdapter(ribbon);
            var descriptors = AddInTree.BuildItems<MenuItemDescriptor>(addInTreePath, owner, false);
            BuildParts(adapter, descriptors, addInTreePath, register);
        }

        private static IUIElementAdapter GetUIElementAdapter(object element)
        {
            var factoryCatalog = IoC.Get<IUIElementAdapterFactoryCatalog>();
            IUIElementAdapterFactory factory = factoryCatalog.GetFactory(element);
            IUIElementAdapter adapter = factory.GetAdapter(element);
            return adapter;
        }

        private static void BuildParts(IUIElementAdapter parent,
            IEnumerable<MenuItemDescriptor> descriptors,
            string addInTreePath,
            ICommandRegister register)
        {
            //try
            //{
                descriptors = descriptors.OrderBy(c => c.OrderNumber);
                foreach (MenuItemDescriptor descriptor in descriptors)
                {
                    //System.Diagnostics.Debug.WriteLine(descriptor.Codon.ToString());
                    object uiElement = CreateMenuItemFromDescriptor(descriptor, addInTreePath, register);

                    object uiElementCreated = parent.Add(uiElement);
                    InitializeUIElement(descriptor, uiElementCreated);
                    var children = descriptor.SubItems;
                    if (children != null)
                    {
                        var subDescriptors = children.Cast<MenuItemDescriptor>();
                        if (!subDescriptors.Any()) continue;
                        var uiElementAapter = GetUIElementAdapter(uiElement);
                        BuildParts(uiElementAapter, subDescriptors, addInTreePath + "/" + descriptor.Codon.Id, register);
                    }
                }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        static void InitializeUIElement(MenuItemDescriptor descriptor, object uiElement)
        {
            Codon codon = descriptor.Codon;
            if (codon.Properties.Contains("initializer"))
            {
                var initializerId = codon.Properties["initializer"];
                var initializers = AddInTree.BuildDictionaryItems<IUIElementInitializer>("/Workbench/UIElementInitializers", null, false);
                var initializer = initializers.Where(kvp => kvp.Key == initializerId).Select(kvp => kvp.Value).FirstOrDefault();
                if (initializer != null)
                {
                    initializer.Initialize(uiElement);
                }
            }
        }

        static object CreateMenuItemFromDescriptor(MenuItemDescriptor descriptor, string addinTreePath, ICommandRegister register)
        {
            Codon codon = descriptor.Codon;

            string cmdPath = addinTreePath + "/" + codon.Id;
            string builderid = string.Empty;
            if (codon.Properties.Contains("builderid"))
            {
                builderid = codon.Properties["builderid"];
            }
            else if (codon.Properties.Contains("cmdId"))
            {
                string cmdId = codon.Properties["cmdId"];
                return register.GetBarItem(cmdId);
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
            object obj = builder.Build(codon, descriptor.Caller, descriptor.Conditions); ;
            try
            {
                if (obj is BarButtonItemEx)
                {
                    BarItem cmdBar = obj as BarItem;

                    string formats = "<MenuItem id ={0} checkForViewId =\"\" source =\"Ribbon\" cmdPath =\"{1}\"/>";
                    System.Diagnostics.Debug.WriteLine(string.Format(formats, codon.Id, cmdPath));
                    if (register != null)
                    {
                        //ICommand command = (ICommand)codon.AddIn.CreateObject(codon.Properties["class"]);
                        //command.Owner = register.owner;
                        ICommand command = cmdBar.Tag as ICommand;
                        if (command != null)
                        {
                            if (string.IsNullOrEmpty(codon.Properties["groupName"]))
                            {
                                bool registerSuc = register.RegisterCommand(cmdBar, cmdPath, command, descriptor.Conditions);
                            }
                            else
                            {
                                string groupName = codon.Properties["groupName"];
                                bool registerSuc = register.RegisterCommand(cmdBar, codon.Id, cmdPath, command, groupName);
                            }
                        }
                        //Debug.WriteLine("Register =" + registerSuc.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }

    }
}
