using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Katrin.Win.Common.Core;
using Microsoft.Practices.ObjectBuilder;
using Katrin.Win.Common.MetadataServiceReference;
using Microsoft.Practices.CompositeUI.SmartParts;
using Katrin.Win.MainModule.Views.Opportunity;
using Katrin.Win.MainModule.Views.Account;
using Katrin.Win.MainModule.Views.User;
using Katrin.Win.Common.Controls;
namespace Katrin.Win.MainModule.Views.Contract
{
    [SmartPart]
    public partial class ContractDetailView : AbstractDetailView, IContractDetailView
    {

        private ContractDetailPresenter _presenter;

        [CreateNew]
        public ContractDetailPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        public ContractDetailView()
        {
            InitializeComponent();
        }

        public override void InitEditors(Entity entity)
        {
            base.InitEditors(entity);
            OpportunityIdSearchLookUpEdit.Bind(entity);
            OpportunityIdSearchLookUpEdit.AddDetailButton<OpportunityDetailView>(OpenDetail, "Opportunity");

            BillingCustomerIdSearchLookUpEdit.Bind(entity);
            BillingCustomerIdSearchLookUpEdit.AddDetailButton<AccountDetailView>(OpenDetail, "Account");
            OwnerIdSearchLookUpEdit.InitEdit("User", "Department", false);
            //OwnerIdSearchLookUpEdit.Bind(entity);
            OwnerIdSearchLookUpEdit.AddDetailButton<UserDetailView>(OpenDetail, "User");

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
