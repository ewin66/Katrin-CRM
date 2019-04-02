using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode;
using ICSharpCode.Core;
using Katrin.AppFramework.WinForms.CommandManage;

namespace Katrin.AppFramework.WinForms.ContextMenu
{
    class MenuCreater
    {
        public PopupMenu CreateMenu(string moduleID,
            string viewID,
            RibbonControl ribbon,
            IBarItemFinder finder)
        {
            PopupMenu popupMenu = new PopupMenu();
            popupMenu.Manager = ribbon.Manager;
            popupMenu.Ribbon = ribbon;     
          
            MenuItemDescriptor menuinfo = this.LoadMenuInfoFromTree(moduleID, viewID);
            if (menuinfo == null)
            {
                return null;
            }

            bool needSplitor = false;
            foreach (MenuItemDescriptor item in menuinfo.SubItems)
            {
               
               // string cmdId = string.Empty;
              
                string cmdType = "normal";
                if (string.IsNullOrEmpty(item.Codon.Properties["cmdId"]))
                {
                    throw new Exception("Context menu config error,not found cmdId:" + item.Codon.Id + " in " + moduleID);
                }
                if (!string.IsNullOrEmpty(item.Codon.Properties["type"]))
                {
                    cmdType = item.Codon.Properties["type"];
                }
                if (cmdType == "normal")
                {
                   
                    this.CreateNormalLink(item, finder, popupMenu,moduleID);
                }
                else if (cmdType == "dynamicGroup")
                {
                    this.CreateDynamicLink(item, finder, popupMenu, ribbon.Manager);
                }
                else
                {
                    throw new Exception("Invalid Command Type:" + cmdType + " in " + moduleID);
                }
               

            }
          
            return popupMenu;
        }
        private BarItemLink CreateDynamicLink(MenuItemDescriptor item,
            IBarItemFinder finder, 
            PopupMenu popupMenu,
            BarManager manager)
        {            
            string cmdId = string.Empty;
            string groupLabel = string.Empty;
            bool beginGroup = false;
            string labelConfig = string.Empty;

            cmdId = item.Codon.Properties["cmdId"];
            if (!string.IsNullOrEmpty(item.Codon.Properties["beginGroup"]))
            {
                beginGroup = bool.Parse(item.Codon.Properties["beginGroup"]);
            }
            if (!string.IsNullOrEmpty(item.Codon.Properties["label"]))
            {
                labelConfig = item.Codon.Properties["label"];
            }

            IUICommand containerCmd = finder.GetDynamicContainer(cmdId);
            BarSubItem groupItem = containerCmd.BarItem as BarSubItem;
            popupMenu.BeforePopup +=popupMenu_BeforePopup;
            if (labelConfig != string.Empty)
            {
                groupLabel = StringParser.Parse(labelConfig);
                groupItem.Caption = groupLabel;
            }

            BarItemLink link = null;
            if (containerCmd.IsRunTimeContainer)
            {
                //runtime menus
                link = popupMenu.ItemLinks.Add(groupItem);
            }
            else
            {
                List<BarItem> barItems = finder.GetDynamicBarItems(cmdId);
                if (barItems.Count > 0)
                {
                    link = popupMenu.ItemLinks.Add(groupItem);
                    link.BeginGroup = beginGroup;
                    foreach (BarItem subItem in barItems)
                    {

                        groupItem.ItemLinks.Add(subItem);
                    }
                }
            }           
            return link;
        }       

        void popupMenu_BeforePopup(object sender, System.ComponentModel.CancelEventArgs e)
        {
            PopupMenu menu = sender as PopupMenu; 
            foreach (BarItemLink lk in menu.ItemLinks)
            {
                if (lk.Item is BarSubItem)
                {
                    lk.Item.PerformClick();
                    System.Diagnostics.Debug.WriteLine(string.Format("you click {0}", lk.Item.Caption));
                }
            }
        }

       
        private BarItemLink CreateNormalLink(MenuItemDescriptor item, 
            IBarItemFinder finder,
            PopupMenu popupMenu,
            string moduleID)
        {
            BarItem barItem = null;
            string cmdId = string.Empty;
            bool beginGroup = false;
            cmdId = item.Codon.Properties["cmdId"];
            if (!string.IsNullOrEmpty(item.Codon.Properties["beginGroup"]))
            {
                beginGroup = bool.Parse(item.Codon.Properties["beginGroup"]);
            }

            barItem = finder.GetBarItem(cmdId);
            if (barItem == null)
            {
                throw new Exception("Context menu invalid:" + cmdId + " in " + moduleID);
            }
            BarItemLink link = popupMenu.ItemLinks.Add(barItem);
            link.BeginGroup = beginGroup;
            return link;
        }

        public MenuItemDescriptor LoadMenuInfoFromTree(string moduleID, string viewID)
        {
            string path = "/" + moduleID +"/ContextMenu";
           bool exist = ICSharpCode.Core.AddInTree.ExistsTreeNode(path);
           if (!exist)
           {
               return null;
           }          
           List<MenuItemDescriptor> descriptors = AddInTree.BuildItems<MenuItemDescriptor>(path, this, false);
           foreach (MenuItemDescriptor item in descriptors)
           {
               Codon codon = item.Codon;
               string strviewid = codon.Properties["viewid"];
               string strmodule = codon.Properties["module"];
               if (strviewid == viewID && strmodule == moduleID)
               {
                   return item;
               }
           }
           return null;
        }
    }
}
