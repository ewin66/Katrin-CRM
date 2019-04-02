using System;
using System.Linq;
using System.Windows.Forms;
using Katrin.Win.Infrastructure;
using Katrin.Win.Common.Constants;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.SmartParts;

namespace Katrin.Win.Common.Core
{
    public class DetailLayoutViewPresenter : Presenter<DetailLayoutView>
    {
        protected override void OnViewSet()
        {
            base.OnViewSet();
            WorkItem.UIExtensionSites.RegisterSite(ExtensionSiteNames.DetailRibbon, View.Ribbon);
            WorkItem.UIExtensionSites.RegisterSite(ExtensionSiteNames.DetailStatusBar, View.StatusBar);

            WorkItem.Items.Add(View.ContentWorkspace, WorkspaceNames.DetailContentWorkspace);
        }

        [CommandHandler("Close")]
        public void Close(object sender, EventArgs e)
        {
            CloseView();
        }

        public void OnParentChanged()
        {
            if (View.ParentForm != null)
            {
                View.ParentForm.FormClosed -= OnFormClosed;
                View.ParentForm.FormClosed += OnFormClosed;
            }
        }


        void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            var parentForm = sender as Form;
            if (parentForm != null)
                parentForm.FormClosed -= OnFormClosed;
            if (WorkItem.Status != WorkItemStatus.Terminated)
                WorkItem.Terminate();
        }
    }
}
