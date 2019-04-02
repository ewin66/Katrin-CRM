using DevExpress.XtraGrid.Views.Base;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Katrin.AppFramework.ConfigService
{
    /// <summary>
    /// IConfigService implement..
    /// author:hecq
    /// date:2012-11-6
    /// </summary>
   public class ConfigService:IConfigService
    {

       private const string Size = "_SIZE";
       private const string State = "_STATE";
       private const string Location = "_LOCATION";
       private const string DataLayout = "_DATALAYOUT";       

       #region Private Method
       private FormWindowState MappingState(string stateStr)
       {
           FormWindowState state = FormWindowState.Normal;
           switch (stateStr)
           {
               case "Normal":
                   state = FormWindowState.Normal;
                   break;
               case "Maximized":
                   state = FormWindowState.Maximized;
                   break;
               case "Minimized":
                   state = FormWindowState.Normal;
                   break;
               default:

                   throw new Exception("Unkown WindowsFormState:" + stateStr);
           }

           return state;
       }

       #endregion


       #region IConfigService
       //form
       public void SaveFormLayOut(Form frm, string Key)
        {
            try
            {
                if (frm.WindowState == FormWindowState.Minimized) return;
                PropertyService.Set<Size>(Key + Size, frm.Size);
                PropertyService.Set<string>(Key + State, frm.WindowState.ToString());
                PropertyService.Set<Point>(Key + Location, frm.Location);
            }
            catch (Exception ex)
            {
                MessageService.ShowException(ex);
            }

        }

        public void RestoreFormLayout(string key, Form frm)
        {
            try
            {
                Size size = PropertyService.Get<Size>(key + Size, frm.Size);
                string formWindowState = PropertyService.Get<string>(key + State, frm.WindowState.ToString());
                
                frm.Size = size;
                frm.Location = PropertyService.Get<Point>(key + Location, frm.Location);
                if (frm.Location.X < 0 || frm.Location.Y < 0)
                    frm.Location = new Point(100, 100);
                frm.WindowState = this.MappingState(formWindowState);
            }
            catch (Exception ex)
            {
                MessageService.ShowException(ex);
            }
        }

        //ribbon
        public void SaveRibbonLayOut(DevExpress.XtraBars.Ribbon.RibbonControl ribbon, string key)
        {
            try
            {
                PropertyService.Set<bool>(key, ribbon.Minimized);
            }
            catch (Exception ex)
            {
                MessageService.ShowException(ex);
            }
        }

        public void RestoreRibbonLayOut(DevExpress.XtraBars.Ribbon.RibbonControl ribbon, string key)
        {
            try
            {
                ribbon.Minimized = PropertyService.Get<bool>(key, ribbon.Minimized);
            }
            catch (Exception ex)
            {
                MessageService.ShowException(ex);
            }
        }

        //dockmanager
        public void SaveDockManagerLayout(DevExpress.XtraBars.Docking.DockManager dockControl, string key)
        {
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                dockControl.SaveLayoutToStream(ms);
                StreamReader reader = new StreamReader(ms);
                ms.Position = 0;
                string strlayouts = reader.ReadToEnd();
                PropertyService.Set<string>(key, strlayouts);
            }
            catch (Exception ex)
            {
                MessageService.ShowException(ex);
            }
            
        }

        public void RestoreDockManagerLayout(DevExpress.XtraBars.Docking.DockManager dockControl, string key)
        {
            try
            {
                string layout = PropertyService.Get(key);
                if (layout != string.Empty)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    System.IO.StreamWriter writer = new System.IO.StreamWriter(ms);
                    writer.AutoFlush = true;
                    writer.Write(layout);
                    ms.Position = 0;
                    dockControl.RestoreLayoutFromStream(ms);
                }
            }
            catch (Exception ex)
            {
                MessageService.ShowException(ex);
            }
        }

       //narbar
        public void SaveNavBarLayout(DevExpress.XtraNavBar.NavBarControl navBarControl, string key)
        {
            try
            {
                PropertyService.Set<int>(key, navBarControl.Width);
            }
            catch (Exception ex)
            {
                MessageService.ShowException(ex);
            }
        }

        public void RestoreNavBarLayout(DevExpress.XtraNavBar.NavBarControl navBarControl, string key)
        {
            try
            {
                navBarControl.Width = PropertyService.Get<int>(key, navBarControl.Width);
            }
            catch (Exception ex)
            {
                MessageService.ShowException(ex);
            }
        }

       //DataLayoutControl
        public void SaveDataLayoutControl(DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl, string key)
        {
            try
            {
                key += DataLayout;
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                dataLayoutControl.SaveLayoutToStream(ms);
                StreamReader reader = new StreamReader(ms);
                ms.Position = 0;
                string strlayouts = reader.ReadToEnd();
                PropertyService.Set<string>(key, strlayouts);
            }
            catch (Exception ex)
            {
                MessageService.ShowException(ex);
            }
        }

        public void RestoreDataLayoutControl(DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl, string key)
        {
            try
            {
                key += DataLayout;
                string layout = PropertyService.Get(key);
                if (layout != string.Empty)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    System.IO.StreamWriter writer = new System.IO.StreamWriter(ms);
                    writer.AutoFlush = true;
                    writer.Write(layout);
                    ms.Position = 0;
                    dataLayoutControl.RestoreLayoutFromStream(ms);
                }
            }
            catch (Exception ex)
            {
                MessageService.ShowException(ex);
            }
        }

       //Dev
        public void SaveDevLayout(DevExpress.Utils.Serializing.ISupportXtraSerializer dataLayoutControl, string key)
        {
            try
            {              
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                dataLayoutControl.SaveLayoutToStream(ms);
                StreamReader reader = new StreamReader(ms);
                ms.Position = 0;
                string strlayouts = reader.ReadToEnd();
                PropertyService.Set<string>(key, strlayouts);
            }
            catch (Exception ex)
            {
                MessageService.ShowException(ex);
            }
        }

        public void RestoreDevLayout(DevExpress.Utils.Serializing.ISupportXtraSerializer dataLayoutControl, string key)
        {
            try
            {           
                string layout = PropertyService.Get(key);
                if (layout != string.Empty)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    System.IO.StreamWriter writer = new System.IO.StreamWriter(ms);
                    writer.AutoFlush = true;
                    writer.Write(layout);
                    ms.Position = 0;
                    dataLayoutControl.RestoreLayoutFromStream(ms);
                }
            }
            catch (Exception ex)
            {
                MessageService.ShowException(ex);
            }
        }


       //main filter
        public void SaveMainFilter(string filterName, string key)
        {
            PropertyService.Set<string>(key, filterName);
        }

        public string GetMainFilter(string key,string defaultFilter)
        {
            try
            {
                return PropertyService.Get<string>(key, defaultFilter);
            }
            catch (Exception ex)
            {
                MessageService.ShowException(ex);
                return defaultFilter;
            }
           
        }

    
       //GridView
        public void SaveColumnViewLayout(BaseView gv, string key)
        {
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                gv.SaveLayoutToStream(ms,DevExpress.Utils.OptionsLayoutBase.FullLayout);
                StreamReader reader = new StreamReader(ms);
                ms.Position = 0;
                string strlayouts = reader.ReadToEnd();
                PropertyService.Set<string>(key, strlayouts);
            }
            catch (Exception ex)
            {
                MessageService.ShowException(ex);
            }
        }

        public void RestoreColumnViewLayout(BaseView gv, string key)
        {
            try
            {
                string layout = PropertyService.Get(key);
                if (layout != string.Empty)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    System.IO.StreamWriter writer = new System.IO.StreamWriter(ms);
                    writer.AutoFlush = true;
                    writer.Write(layout);
                    ms.Position = 0;
                    gv.RestoreLayoutFromStream(ms,DevExpress.Utils.OptionsLayoutBase.FullLayout);
                }
            }
            catch (Exception ex)
            {
                MessageService.ShowException(ex);
            }
        }

        public void Set<T>(T tValue, string key)
        {
            PropertyService.Set<T>(key, tValue);
        }

        public T Get<T>(string key, T defaultValue)
        {
          return  PropertyService.Get<T>(key, defaultValue);
        }
       #endregion       
            
    }
}
