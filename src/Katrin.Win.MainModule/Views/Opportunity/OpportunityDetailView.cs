using System;
using DevExpress.XtraEditors;
using Microsoft.Practices.ObjectBuilder;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.MetadataServiceReference;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Collections;
using Katrin.Win.MainModule.Views.Account;
using Katrin.Win.MainModule.Views.Lead;
using Katrin.Win.MainModule.Views.User;
using Katrin.Win.Common.Controls;
namespace Katrin.Win.MainModule.Views.Opportunity
{
    public partial class OpportunityDetailView : AbstractDetailView, IOpportunityDetailView
    {
        private OpportunityDetailPresenter _presenter;
        /// <summary>
        /// Sets the presenter. The dependency injection system will automatically
        /// create a new presenter for you.
        /// </summary>
        [CreateNew]
        public OpportunityDetailPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        public OpportunityDetailView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _presenter.OnViewReady();
        }

        public override void InitEditors(Entity entity)
        {
            base.InitEditors(entity);
            string defaultLayoutPath = "Katrin.Win.MainModule.DefaultLayout";
            CustomerIdSearchLookUpEdit.Bind(entity);
            CustomerIdSearchLookUpEdit.AddDetailButton<AccountDetailView>(OpenDetail, "Account");
            OriginatingLeadIdSearchLookUpEdit.Bind(entity);
            //OriginatingLeadIdSearchLookUpEdit.BindSeverMode(entity);
            OriginatingLeadIdSearchLookUpEdit.AddDetailButton<LeadDetailView>(OpenDetail,"Lead");
            //OwnerIdSearchLookUpEdit.Bind(entity);
            OwnerIdSearchLookUpEdit.AddDetailButton<UserDetailView>(OpenDetail,"User");
            OwnerIdSearchLookUpEdit.InitEdit("User", "Department", false);
            TransacitionCurrencyIdLookUpEdit.BindLookupList(entity, true);
            DepartmentLookUpEdit.BindLookupList(entity,true);

            PriorityCodeLookUpEdit.BindPickList(entity);
            OpportunityRatingCodeLookUpEdit.BindPickList(entity);
            SalesStageCodeLookUpEdit.BindPickList(entity);
            StatusCodeLookUpEdit.BindPickList(entity);
            OpportunityTypeCodeLookUpEdit.BindPickList(entity);
            projectTypeCodeLookUpEdit.BindPickList(entity);
            technologyCodeLookUpEdit.BindPickList(entity);
            technicianIdSearchLookUpEdit.Bind(entity);
            technicianIdSearchLookUpEdit.AddDetailButton<UserDetailView>(OpenDetail, "User");
        }

        public override bool ValidateData()
        {
            return base.ValidateData() && ValidateDataRecommend();
        }

        private bool ValidateDataRecommend()
        {
            var result = ValidationProviderRecommend.Validate();
            var invalidControls = ValidationProviderRecommend.GetInvalidControls();
            var firstInvalideControl = invalidControls.FirstOrDefault();
            if (firstInvalideControl != null)
            {
                var layoutItem = EntityDataLayoutControl.GetItemByControl(firstInvalideControl);
                if (layoutItem != null && layoutItem.Parent.ParentTabbedGroup != null)
                {
                    layoutItem.Parent.ParentTabbedGroup.SelectedTabPage = layoutItem.Parent;
                }
            }
            if (!result)
            {
                DialogResult dialogResult = XtraMessageBox.Show(this,Properties.Resources.RecommendWarning,
                    Properties.Resources.Katrin, 
                    MessageBoxButtons.OKCancel, 
                    MessageBoxIcon.Question, 
                    MessageBoxDefaultButton.Button1);
                if (dialogResult == DialogResult.OK)
                {
                    result = true;
                }
            }
            return result;
        }

        public override void InitValidation()
        {
            SetValidationRule(topicTextEdit, ValidationRules.IsNotBlankRule(ItemForName.Text));
            SetValidationRule(OwnerIdSearchLookUpEdit, ValidationRules.IsNotBlankRule(ItemForOwnerId.Text));
            SetValidationRule(OwnerIdSearchLookUpEdit, ValidationRules.IsGuidNotBlankRule(ItemForOwnerId.Text));
            SetValidationRule(SalesStageCodeLookUpEdit, ValidationRules.IsNotBlankRule(ItemForSalesStageCode.Text));
            SetValidationRuleAligRight(ValidationProviderRecommend,DescriptionTextEdit, ValidationRules.IsBlankWarningRule(""));
            SetValidationRuleAligRight(ValidationProviderRecommend, projectTypeCodeLookUpEdit, ValidationRules.IsBlankWarningRule(""));
            SetValidationRuleAligRight(ValidationProviderRecommend, technologyCodeLookUpEdit, ValidationRules.IsBlankWarningRule(""));
            SetValidationRuleAligRight(ValidationProviderRecommend, technicianIdSearchLookUpEdit, ValidationRules.IsBlankWarningRule(""));
            SetValidationRuleAligRight(ValidationProviderRecommend, latestFeedBackOnDateEdit, ValidationRules.IsBlankWarningRule(""));
            SetValidationRuleAligRight(ValidationProviderRecommend, CustomerIdSearchLookUpEdit, ValidationRules.IsBlankWarningRule(""));
            SetValidationRuleAligRight(ValidationProviderRecommend, OriginatingLeadIdSearchLookUpEdit, ValidationRules.IsBlankWarningRule(""));
            SetValidationRuleAligRight(ValidationProviderRecommend, PriorityCodeLookUpEdit, ValidationRules.IsBlankWarningRule(""));
            SetValidationRuleAligRight(ValidationProviderRecommend, PriorityCodeLookUpEdit, ValidationRules.IsBlankWarningRule(""));
        }

        private void SalesStageCodeLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (SalesStageCodeLookUpEdit.OldEditValue == null) return;
            if (SalesStageCodeLookUpEdit.EditValue == null) return;
            if(SalesStageCodeLookUpEdit.OldEditValue == SalesStageCodeLookUpEdit.EditValue) return;
            if (string.IsNullOrEmpty(SalesStageCodeLookUpEdit.EditValue.ToString())) return;

            int saleSucess = 7;
            int saleFail = 8;
            int oldCode = 0;
            if (!string.IsNullOrEmpty(SalesStageCodeLookUpEdit.OldEditValue.ToString()))
                oldCode = int.Parse(SalesStageCodeLookUpEdit.OldEditValue.ToString());
            int statusCode = int.Parse(SalesStageCodeLookUpEdit.EditValue.ToString());

            if (oldCode != saleSucess && oldCode != saleFail && (statusCode == saleSucess || statusCode == saleFail))
            {
                SalesStageCodeLookUpEdit.EditValue = SalesStageCodeLookUpEdit.OldEditValue;
                XtraMessageBox.Show(this, Properties.Resources.SaleStageChangeTip,
                    Properties.Resources.Katrin,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
            }
          
            
        }
    }
}
