using System;
using DevExpress.XtraEditors;

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Collections;
using Katrin.AppFramework.MetadataServiceReference;

using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.WinForms.Views;

using ICSharpCode.Core;
using Katrin.Win.DetailViewModule;

namespace Katrin.Win.OpportunityModule
{
    public partial class OpportunityDetailView : DetailViewModule.DetailView, IOpportunityDetailView
    {


        public OpportunityDetailView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        public override void InitEditors(Entity entity)
        {
          
            base.InitEditors(entity);
           
            CustomerIdSearchLookUpEdit.Bind(entity);
            CustomerIdSearchLookUpEdit.AddDetailButton("Account");
            OriginatingLeadIdSearchLookUpEdit.Bind(entity);
            OriginatingLeadIdSearchLookUpEdit.Bind(entity);
            
            OriginatingLeadIdSearchLookUpEdit.AddDetailButton("Lead");           
           OwnerIdSearchLookUpEdit.AddDetailButton("User");
           OwnerIdSearchLookUpEdit.InitEdit("User", "Department", false);
            TransacitionCurrencyIdLookUpEdit.BindLookupList(entity, true);
            DepartmentLookUpEdit.BindLookupList(entity,true);

            PriorityCodeLookUpEdit.BindPickList(entity);
            OpportunityRatingCodeLookUpEdit.BindPickList(entity);
            SalesStageCodeLookUpEdit.BindPickList(entity);
            StatusCodeLookUpEdit.BindPickList(entity);
            OpportunityTypeCodeLookUpEdit.BindPickList(entity);
            projectTypeCodeLookUpEdit.BindPickList(entity);
            technologyCodeLookUpEdit.BindComboBoxList(entity, "TechnologyCode");
            technicianIdSearchLookUpEdit.Bind(entity);
            technicianIdSearchLookUpEdit.AddDetailButton("User");
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

                string caption = ResourceService.GetString("RecommendWarning");
                string text = ResourceService.GetString("Katrin");

                DialogResult dialogResult = XtraMessageBox.Show(this,
                    caption,
                   text,
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
                string caption = ResourceService.GetString("RecommendWarning");
                string text = ResourceService.GetString("Katrin");
                SalesStageCodeLookUpEdit.EditValue = SalesStageCodeLookUpEdit.OldEditValue;
                XtraMessageBox.Show(this,caption,
                   text,
                    MessageBoxButtons.OK,
                   MessageBoxIcon.Information,
                   MessageBoxDefaultButton.Button1);
            }
          
            
        }
    }
}
