using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using DevExpress.XtraBars.Ribbon;
using System.Windows.Forms;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.Win.OpportunityModule;
using Katrin.Domain.Impl;
using ICSharpCode.Core;
using Katrin.AppFramework.Metadata;
using Katrin.AppFramework;

namespace Katrin.Win.OpportunityModule
{
    public enum OpportunityStatus
    {
        InProgress = 1,
        OnHold,
        Won,
        Lost
    }

    public class OpportunityDetailController : ObjectDetailController
    {
        const int SaleStageCodeOffSet = 4;


        public override string ObjectName
        {
            get
            {
                return OpportunityConfig.MODULE_NAME;
            }
        }

        protected override bool OnSaving()
        {
            if (WorkingMode == EntityDetailWorkingMode.Add)
            {
                var opportunity = (Katrin.Domain.Impl.Opportunity)ObjectEntity;
                opportunity.StatusCode = (int)OpportunityStatus.InProgress;
            }
            return base.OnSaving();
        }

        protected override void OnSaved()
        {
            var opportunity = (Katrin.Domain.Impl.Opportunity)ObjectEntity;
            if (opportunity.OriginatingLeadId == null) return;
            var leadEntity = (Katrin.Domain.Impl.Lead)_objectSpace.GetOrNew("Lead", opportunity.OriginatingLeadId??Guid.Empty,null);
            leadEntity.StatusCode = 4;
            _objectSpace.SaveChanges();
        }

       
        public bool SetOpportunityWon(Opportunity opportunity)
        {
            string confirmWon = ResourceService.GetString("ConfirmWon");
            bool yes = MessageService.AskQuestion(confirmWon);
            if (yes)
            {
                opportunity.ClosedTime = DateTime.Now;
                opportunity.StatusCode = (int)OpportunityStatus.Won;
                opportunity.SalesStageCode = opportunity.StatusCode + SaleStageCodeOffSet;
                this._objectSpace.SaveChanges();    
          
                ObjectSetChangedMessage msg = new ObjectSetChangedMessage();
                msg.ObjectName = this.ObjectName;
                EventAggregationManager.SendMessage(msg);

                UpdateRibbonItemMessage msgRefreshCmd = new UpdateRibbonItemMessage(this.WorkSpaceID,this.ObjectName);
               // msgRefreshCmd.ObjectName = this.ObjectName;
                EventAggregationManager.SendMessage(msgRefreshCmd);

            }
            return true;
        }

        public bool SetOpportunityFail(Opportunity opportunity)
        {
            OpportunityLossReason resonForm = new OpportunityLossReason();
            DialogResult result = resonForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                string lossReason = resonForm.LossReasion;
                opportunity.ClosedTime = DateTime.Now;
                opportunity.StatusCode = (int)OpportunityStatus.Lost;
                opportunity.SalesStageCode = opportunity.StatusCode + SaleStageCodeOffSet;
                if (!string.IsNullOrEmpty(lossReason))
                    opportunity.Description += "\r\n" + lossReason;
                this._objectSpace.SaveChanges();        

                ObjectSetChangedMessage msg = new ObjectSetChangedMessage();
                msg.ObjectName = this.ObjectName;
                EventAggregationManager.SendMessage(msg);

                UpdateRibbonItemMessage msgRefreshCmd = new UpdateRibbonItemMessage(this.WorkSpaceID, this.ObjectName);
               
                EventAggregationManager.SendMessage(msgRefreshCmd);
            }
            return true;
        }

        public bool SetOpportunityRecyle(Opportunity opportunity)
        {
            opportunity.ClosedTime = (DateTime?)null;
            opportunity.StatusCode = (int)OpportunityStatus.InProgress;
            opportunity.SalesStageCode = opportunity.StatusCode + SaleStageCodeOffSet;
            this._objectSpace.SaveChanges();       
            ObjectSetChangedMessage msg = new ObjectSetChangedMessage();
            msg.ObjectName = this.ObjectName;
            EventAggregationManager.SendMessage(msg);

            UpdateRibbonItemMessage msgRefreshCmd = new UpdateRibbonItemMessage(this.WorkSpaceID,this.ObjectName);
            
            EventAggregationManager.SendMessage(msgRefreshCmd);
            return true;
        }
    }
}
