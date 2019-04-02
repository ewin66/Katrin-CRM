using System;
using System.Collections.Generic;
using System.Linq;
using Katrin.Win.Common.Constants;
using Katrin.Win.Common.Security;
using Katrin.Win.Infrastructure;
using Katrin.Win.Common;
using System.Collections;
using DevExpress.XtraBars.Ribbon;
using Microsoft.Practices.CompositeUI;
using Katrin.Win.Common.Core;
using Microsoft.Practices.CompositeUI.Commands;
using Katrin.Win.Common.MetadataServiceReference;
using System.Windows.Forms;
using Katrin.Win.Common.Controls;
using Microsoft.Practices.CompositeUI.EventBroker;
using EventTopicNames = Katrin.Win.MainModule.Constants.EventTopicNames;

namespace Katrin.Win.MainModule.Views.Opportunity
{
    public enum OpportunityStatus
    {
        InProgress = 1,
        OnHold,
        Won,
        Lost
    }

    public class OpportunityDetailPresenter : EntityDetailPresenter<IOpportunityDetailView>
    {
        const int SaleStageCodeOffSet = 4;

        public OpportunityDetailPresenter()
        {
            EntityName = "Opportunity";
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            if (WorkingMode == EntityDetailWorkingMode.Add)
                DynamicEntity.StatusCode = (int) OpportunityStatus.InProgress;
        }

        protected override void OnSaved()
        {
            //base.OnSaved();
            if (DynamicEntity.OriginatingLeadId == null) return;
            var leadEntity = DynamicDataServiceContext.GetOrNew("Lead", DynamicEntity.OriginatingLeadId);
            leadEntity.StatusCode = 4;
            DynamicDataServiceContext.SaveChanges();
            MetadataProvider.Instance.CreateCommonNotification(DynamicEntity.OpportunityId, EntityName, "Lead");
        }

        [CommandHandler("Won")]
        public void OnSetOpportunitySuccess(object sender, EventArgs e)
        {
            DynamicEntity.ClosedTime = DateTime.Now;
            DynamicEntity.StatusCode = (int) OpportunityStatus.Won;
            DynamicEntity.SalesStageCode = DynamicEntity.StatusCode + SaleStageCodeOffSet;
            DynamicDataServiceContext.SaveChanges();
            OnEntitySaved(new EventArgs<bool>(false));
            WorkItem.Commands["Refresh"].Execute();
        }

        [CommandHandler("Fail")]
        public void OnSetOpportunityFail(object sender, EventArgs e)
        {
            OpportunityLossReason resonForm = new OpportunityLossReason();
            DialogResult result = resonForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                string lossReason = resonForm.LossReasion();
                DynamicEntity.ClosedTime = DateTime.Now;
                DynamicEntity.StatusCode = (int)OpportunityStatus.Lost;
                DynamicEntity.SalesStageCode = DynamicEntity.StatusCode + SaleStageCodeOffSet;
                if (!string.IsNullOrEmpty(lossReason))
                    DynamicEntity.Description += "\r\n" + lossReason;
                DynamicDataServiceContext.SaveChanges();
                OnEntitySaved(new EventArgs<bool>(false));
                WorkItem.Commands["Refresh"].Execute();
            }
        }

        [CommandHandler("Recyle")]
        public void OnSetOpportunityResurrection(object sender, EventArgs e)
        {
            DynamicEntity.ClosedTime = (DateTime?)null;
            DynamicEntity.StatusCode = (int)OpportunityStatus.InProgress;
            DynamicEntity.SalesStageCode = DynamicEntity.StatusCode + SaleStageCodeOffSet;
            DynamicDataServiceContext.SaveChanges();
            OnEntitySaved(new EventArgs<bool>(false));
            WorkItem.Commands["Refresh"].Execute();
        }

        protected override void OnViewSet()
        {
            base.OnViewSet();

            RegisterCommand("DetailGeneralPageGroup", "Won", "SetOpportunitySuccess", "", "SetOpportunitySuccess");
            RegisterCommand("DetailGeneralPageGroup", "Fail", "SetOpportunityFail", "", "SetOpportunityFail");
            RegisterCommand("DetailGeneralPageGroup", "Recyle", "SetOpportunityResurrection", "", "SetOpportunityResurrection");
        }

        [EventSubscription(EventTopicNames.RefreshCommandStatus, Thread = ThreadOption.UserInterface)]
        public void OnRefreshCommandStatus(object sender, EventArgs e)
        {
            var status = (OpportunityStatus) DynamicEntity.StatusCode;
            var canWrite = AuthorizationManager.CheckAccess(EntityName, "Write");

            WorkItem.Commands["Recyle"].Status = canWrite && status == OpportunityStatus.Lost
                                                     ? CommandStatus.Enabled
                                                     : CommandStatus.Unavailable;

            var wonStatus = WorkingMode == EntityDetailWorkingMode.Edit
                            && status == OpportunityStatus.InProgress && canWrite
                                ? CommandStatus.Enabled
                                : CommandStatus.Unavailable;
            WorkItem.Commands["Won"].Status = WorkItem.Commands["Fail"].Status = wonStatus;
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
    }
}
