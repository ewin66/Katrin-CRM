using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Katrin.Win.Common.Controls;
using Katrin.Win.Common.Core;
using Microsoft.Practices.ObjectBuilder;
using Katrin.Win.Common.MetadataServiceReference;
using System.Collections;
using Katrin.Win.MainModule.Views.Account;
using Katrin.Win.Common.Controls;
namespace Katrin.Win.MainModule.Views.Invoice
{
    public partial class InvoiceDetailView : AbstractDetailView, IInvoiceDetailView
    {
        private InvoiceDetailPresenter _presenter;

        [CreateNew]
        public InvoiceDetailPresenter Presenter
        {
            set 
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        public InvoiceDetailView()
        {
            InitializeComponent();
        }

        public ArrayList SelectedContracts
        {
            get { return contractGridLookUpEdit.Properties.GridSelection.Selection; }
        }

        public void BindContract(List<Guid> selectedContracts)
        {
            contractGridLookUpEdit.Properties.DisplayMember = "Title";
            contractGridLookUpEdit.Properties.View.OptionsSelection.MultiSelect = true;
            contractGridLookUpEdit.Properties.BindDataAsync("Contract", "ContractId", selectedContracts);
        }

        public override void InitEditors(Entity entity)
        {
            base.InitEditors(entity);
            BillingCustomerIdSearchLookUpEdit.Bind(entity);
            BillingCustomerIdSearchLookUpEdit.AddDetailButton<AccountDetailView>(OpenDetail, "Account");

            TransactionCurrencyIdLookUpEdit.BindLookupList(entity,false);
            OwnerIdLookUpEdit.InitEdit("User", "Department", false);
            //OwnerIdLookUpEdit.BindLookupList(entity,false);
            StatusCodeLookUpEdit.BindPickList(entity);
        }

        public override void InitValidation()
        {
            SetValidationRule(NameTextEdit, ValidationRules.IsNotBlankRule(ItemForName.Text));
            SetValidationRule(InvoiceNumberTextEdit, ValidationRules.IsNotBlankRule(ItemForInvoiceNumber.Text));
            SetValidationRule(OwnerIdLookUpEdit, ValidationRules.IsNotBlankRule(ItemForOwnerId.Text));
            SetValidationRule(OwnerIdLookUpEdit, ValidationRules.IsGuidNotBlankRule(ItemForOwnerId.Text));
            SetValidationRule(DateDeliveredTextEdit, ValidationRules.IsGuidNotBlankRule(ItemForDateDelivered.Text));
        }
    }
}
