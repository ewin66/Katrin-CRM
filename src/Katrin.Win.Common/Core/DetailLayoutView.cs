using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Katrin.Win.Infrastructure.Services;
using DevExpress.Utils.Serializing;
using DevExpress.XtraEditors;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using DevExpress.XtraBars.Ribbon;
using Microsoft.Practices.ObjectBuilder;

namespace Katrin.Win.Common.Core
{
    public partial class DetailLayoutView : DevExpress.XtraEditors.XtraUserControl, ISmartPartInfoProvider, IUserDataPersister
    {
        private DetailLayoutViewPresenter _presenter;

        public DetailLayoutView()
        {
            InitializeComponent();
            this.ribbonWindowSmartPartInfo.Ribbon = this.ribbon;
            this.ribbonWindowSmartPartInfo.StatusBar = this.ribbonStatusBar;
        }

        public string EntityName
        {
            get;
            set;
        }

        /// <summary>
        /// Sets the presenter.
        /// </summary>
        /// <value>The presenter.</value>
        [CreateNew]
        public DetailLayoutViewPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        [ServiceDependency(Required = true)]
        public UserDataPersistenceService UserDataPersistenceService { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _presenter.OnViewReady();
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            _presenter.OnParentChanged();
        }

        public RibbonControl Ribbon
        {
            get { return this.ribbon; }
        }

        public RibbonStatusBar StatusBar
        {
            get { return this.ribbonStatusBar; }
        }

        public object ContentWorkspace
        {
            get { return this.detailContentTabWorkspace; }
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            //// Implement ISmartPartInfoProvider in the containing smart part. Required in order for contained smart part infos to work.
            //Microsoft.Practices.CompositeUI.SmartParts.ISmartPartInfoProvider ensureProvider = this;
            //return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
            ribbon.RibbonStyle = RibbonControlStyle.Office2010;
            if (EntityName != "")
            {
                string detailFormat = Properties.Resources.ResourceManager.GetString("EntityDetailsCaptionFormat");
                string entityCaption = Properties.Resources.ResourceManager.GetString(EntityName);
                ribbon.ApplicationCaption = "Katrin";
                ribbon.ApplicationDocumentCaption = string.Format(detailFormat,entityCaption);
            }
            ribbonWindowSmartPartInfo.Icon = Properties.Resources.ri_Katrin;
            UserDataPersistenceService.LoadUserData(this);
            return this.ribbonWindowSmartPartInfo;
        }

        public void SaveUserData(State state)
        {
            if (ParentForm != null) state["Bounds"] = ParentForm.Bounds;
        }


        public void LoadUserData(State state)
        {
            var bounds = state["Bounds"];
            if(bounds!=null)
            {
                ribbonWindowSmartPartInfo.StartPosition = FormStartPosition.Manual;
                ribbonWindowSmartPartInfo.Location = ((Rectangle) bounds).Location;
                ribbonWindowSmartPartInfo.Size = ((Rectangle) bounds).Size;
            }
        }
    }
}
