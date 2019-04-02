using DevExpress.Utils.Serializing;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraDataLayout;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraNavBar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Katrin.AppFramework.ConfigService
{
    /// <summary>
    /// user ui info config
    /// </summary>
    public interface IConfigService
    {
        /// <summary>
        /// Save size
        /// </summary>
        /// <param name="size"></param>
        /// <param name="Key"></param>
        void SaveFormLayOut(Form frm,string Key);

        /// <summary>
        /// Get Config Size?
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        void RestoreFormLayout(string key,Form frm);

        //ribbonControl
        void SaveRibbonLayOut(DevExpress.XtraBars.Ribbon.RibbonControl ribbon, string key);
        void RestoreRibbonLayOut(DevExpress.XtraBars.Ribbon.RibbonControl ribbon, string key);

        //dockmanager
        void SaveDockManagerLayout(DockManager dockControl,string key);
        void RestoreDockManagerLayout(DockManager dockControl,string key);

        //navBar
        void SaveNavBarLayout(NavBarControl navBarControl, string key);
        void RestoreNavBarLayout(NavBarControl navBarControl, string key); 

        //DataLayoutControl
        void SaveDataLayoutControl(DataLayoutControl dataLayoutControl, string key);
        void RestoreDataLayoutControl(DataLayoutControl dataLayoutControl, string key);

        //DevLayout
        void SaveDevLayout(ISupportXtraSerializer dataLayoutControl, string key);
        void RestoreDevLayout(ISupportXtraSerializer dataLayoutControl, string key);

        //GridView LayOut.
        void SaveColumnViewLayout(BaseView gv, string key);
        void RestoreColumnViewLayout(BaseView gv, string key);

        //MainFilter
        void SaveMainFilter(string filterName, string key);
        string GetMainFilter(string key,string defaultFilter);

        //Guid
        void Set<T>(T tValue, string key);
        T Get<T>(string key, T defaultValue);
        
    }

    
}
