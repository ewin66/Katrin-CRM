using System;
using System.Linq;
using Katrin.Win.Infrastructure;
using System.Collections.Generic;
using System.Collections;
using Katrin.Win.Common;
using Katrin.Win.MainModule.Constants;
using Microsoft.Practices.CompositeUI;
using Katrin.Win.Common.MetadataServiceReference;
using Microsoft.Practices.CompositeUI.Commands;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.Controls;
using Microsoft.Practices.CompositeUI.EventBroker;
using Outlook = NetOffice.OutlookApi;
using NetOffice.OutlookApi.Enums;
namespace Katrin.Win.MainModule.Views.Lead
{
    public class LeadDetailPresenter : EntityDetailPresenter<ILeadDetailView>
    {

        public LeadDetailPresenter()
        {
            EntityName = "Lead";
        }

        protected override void OnViewSet()
        {
            base.OnViewSet();
            RegisterCommand(ExtensionSiteNames.DetailAddGroup, "SendEmail", "SendEmail", "", "SendEmail");
        }

        [CommandHandler("SendEmail")]
        public void OnSetOpportunitySuccess(object sender, EventArgs e)
        {
            LateBindingApi.Core.Factory.Initialize();
            Outlook.Application outlookApplication = new Outlook.Application();
            Outlook.MailItem KatrinEmal = outlookApplication.CreateItem(OlItemType.olMailItem) as Outlook.MailItem;
            string emailTo = DynamicEntity.EmailAddress;
            if (!string.IsNullOrEmpty(emailTo))
                KatrinEmal.Recipients.Add(emailTo);
            KatrinEmal.Importance = OlImportance.olImportanceNormal;
            KatrinEmal.Display();
        }

        private void RegisterCommand(string groupName, string commandName, string imageName, string overlay, string caption)
        {
            var localizedCaption = GetLocalizedCaption(caption);
            var buttonItem = new BarButtonItemEx(imageName, overlay) { Caption = localizedCaption };
            if (WorkItem.Commands[commandName] != null)
            {
                WorkItem.Commands[commandName].AddInvoker(buttonItem, "ItemClick");
            }
            buttonItem.Name = commandName;
            WorkItem.UIExtensionSites[groupName].Add(buttonItem);
        }

        [EventSubscription(EventTopicNames.RefreshCommandStatus, Thread = ThreadOption.UserInterface)]
        public void OnRefreshCommandStatus(object sender, EventArgs e)
        {
            var status = WorkingMode != EntityDetailWorkingMode.Add ? CommandStatus.Enabled : CommandStatus.Disabled;
            WorkItem.Commands["SendEmail"].Status = status;
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            string firstName = DynamicEntity.FirstName;
            string lastName = DynamicEntity.LastName;
            DynamicEntity.FullName = firstName + " " + lastName;
        }
    }
}
