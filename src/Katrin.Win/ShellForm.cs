using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Katrin.Win.Common.Constants;
using Katrin.Win.Infrastructure;
using Katrin.Win.Infrastructure.Services;
using Katrin.Win.Properties;
using DevExpress.XtraBars;
using CABDevExpress.Workspaces;
using DevExpress.XtraSplashScreen;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Services;
using Microsoft.Practices.CompositeUI.Utility;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.EventBroker;
using DevExpress.XtraBars.Ribbon;

namespace Katrin.Win
{
    public partial class ShellForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly UserDataPersistenceService _persistenceService = new UserDataPersistenceService("Shell");
        private readonly UserDataPersistenceService _ribbonPersistenceService = new UserDataPersistenceService("RibbonCheck");
        public ShellForm()
        {
            InitializeComponent();
            ribbon.ApplicationCaption = "Katrin";
            Icon = Resources.ri_Katrin;
        }

        public DeckWorkspace ContentWorkspace
        {
            get { return contextWorkspace; }
        }

        public XtraNavBarWorkspace NavBarWorkspace
        {
            get { return navBarWorkspace; }
        }

        [EventSubscription(EventTopicNames.CaptionUpdate, ThreadOption.UserInterface)]
        public void StatusUpdateHandler(object sender, EventArgs<string> e)
        {
            ribbon.ApplicationDocumentCaption = e.Data;
        }

        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);
            if (e.AffectedProperty == "Bounds")
                Loaded();
        }

        protected override void OnClosed(EventArgs e)
        {
            _persistenceService["SplitterPosition"] = splitContainerControl1.SplitterPosition;
            _ribbonPersistenceService["Check"] = ribbon.SelectedPage.PageIndex;
            _ribbonPersistenceService["Exspan"] = ribbon.Minimized;
            _persistenceService.Save();
            _ribbonPersistenceService.Save();
            base.OnClosed(e);
        }

        bool _isLoaded = false;
        private void Loaded()
        {
            if (_isLoaded) return;
            _isLoaded = true;
            var position = _persistenceService["SplitterPosition"];
            if (position != null)
                splitContainerControl1.SplitterPosition = (int) position;
            var check = _ribbonPersistenceService["Check"];
            if (check != null && (int)check < ribbon.Pages.Count)
                ribbon.SelectedPage = ribbon.Pages[(int)check];
            var exspan = _ribbonPersistenceService["Exspan"];
            if (exspan != null)
                ribbon.Minimized = (bool)exspan;
        }
    }
}
