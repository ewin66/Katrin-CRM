using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Katrin.AppFramework.WinForms.Workspaces;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms;

namespace Katrin.Win.LeadModule
{
    /// <summary>
    /// LeadModule Form
    /// author:hecq
    /// date:2012-10-29
    /// </summary>
    public partial class LeadForm : DevExpress.XtraEditors.XtraForm,IModuleForm
    {
        #region Fields
        private List<IView> _Views = new List<IView>();
       


        #endregion
        public LeadForm()
        {
            InitializeComponent();
        }


        #region private method

        //refresh ribbon for view
        private void LoadRibbon(IView view)
        {
            string ribbonPath = "/Lead/List/Ribbon";// = view.RibbonPath
            RibbonManager.AddItemsToMenu(this.ribbonMain, this,ribbonPath);
        }


        #endregion

        #region Events
        private void docViewManager_ActivePanelChanged(object sender, DevExpress.XtraBars.Docking.ActivePanelChangedEventArgs e)
        {
            IView view = e.Panel as IView;
            this.LoadRibbon(view);
        }

        #endregion
        #region IModuleForm
        public AppFramework.WinForms.MVC.IView ActiveView
        {
            get { return this.docViewManager.ActivePanel as IView; }
        }

        public string ModuleName
        {
            get { return LeadConfig.MODULE_NAME; }
        }

        public void LoadView()
        {
             
        }

        public List<AppFramework.WinForms.MVC.IView> Views
        {
            get { return _Views; }
        }
        #endregion
    }
}
