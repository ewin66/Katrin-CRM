using System;
using System.Linq;
using Katrin.AppFramework.MetadataServiceReference;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.WinForms.Views;
using Katrin.Win.ContractModule.Detail;
using Katrin.AppFramework;
namespace Katrin.Win.ContractModule.Detail
{
    public partial class ContractDetailView : DetailView, IContractDetailView
    {

        public ContractDetailView()
        {
            InitializeComponent();
        }

        public override void InitEditors(Entity entity)
        {
            base.InitEditors(entity);
            OpportunityIdSearchLookUpEdit.Bind(entity);
            OpportunityIdSearchLookUpEdit.AddDetailButton("Opportunity");

            BillingCustomerIdSearchLookUpEdit.Bind(entity);
            BillingCustomerIdSearchLookUpEdit.AddDetailButton("Account");
            OwnerIdSearchLookUpEdit.InitEdit("User", "Department", false);
            OwnerIdSearchLookUpEdit.AddDetailButton("User");

            TransactionCurrencyIdLookUpEdit.BindLookupList(entity,false);

            BillingFrequencyCodeLookUpEdit.BindPickList(entity);
            StatusCodeLookUpEdit.BindPickList(entity);
            DepartmentIdLookUpEdit.BindLookupList(entity, false);
            CustomerSatisfactionLookUpEdit.BindPickList(entity);
            EndTypeLookUpEdit.BindPickList(entity);
        }

        public override void InitValidation()
        {
            SetValidationRule(TitleTextEdit, ValidationRules.IsNotBlankRule(ItemForTitle.Text));
            SetValidationRule(OwnerIdSearchLookUpEdit, ValidationRules.IsGuidNotBlankRule(ItemForOwnerId.Text));
            SetValidationRule(ActiveOnDateEdit, ValidationRules.IsNotBlankRule(ItemForActiveOn.Text));
            SetValidationRule(ExpiresOnDateEdit, ValidationRules.IsNotBlankRule(ItemForExpiresOn.Text));
            SetValidationRule(BillingCustomerIdSearchLookUpEdit, ValidationRules.IsNotBlankRule(ItemForBillingCustomerId.Text));
            SetValidationRule(BillingCustomerIdSearchLookUpEdit, ValidationRules.IsGuidNotBlankRule(ItemForBillingCustomerId.Text));
        }
    }
}
