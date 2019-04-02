using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Katrin.Win.Common.Controls;



using System.Collections;

using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.MetadataServiceReference;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.Extensions;
using Katrin.Win.NoteModule.Note;
using Katrin.AppFramework.WinForms;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Workspaces;

namespace Katrin.Win.InvoiceModule
{
    public partial class InvoiceDetailView : DetailView, IInvoiceDetailView
    {

        public event EventHandler OnStatusCodeChanged;
  
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
            contractGridLookUpEdit.Properties.BindDataAsync("Contract", "ContractId", selectedContracts);
            contractGridLookUpEdit.Properties.View.OptionsSelection.MultiSelect = true;
        }

        public override void InitEditors(Entity entity)
        {
            base.InitEditors(entity);
            BillingCustomerIdSearchLookUpEdit.Bind(entity);
            StatusCodeLookUpEdit.BindPickList(entity);

            TransactionCurrencyIdLookUpEdit.BindLookupList(entity, false);
            OwnerIdLookUpEdit.InitEdit("User", "Department", false);
        }

        public override void InitValidation()
        {           
          
            SetValidationRule(NameTextEdit, ValidationRules.IsNotBlankRule(ItemForName.Text));           
            SetValidationRule(InvoiceNumberTextEdit, ValidationRules.IsNotBlankRule(ItemForInvoiceNumber.Text));
            SetValidationRule(OwnerIdLookUpEdit, ValidationRules.IsNotBlankRule(ItemForOwnerId.Text));
            SetValidationRule(OwnerIdLookUpEdit, ValidationRules.IsGuidNotBlankRule(ItemForOwnerId.Text));
            SetValidationRule(DateDeliveredTextEdit, ValidationRules.IsGuidNotBlankRule(ItemForDateDelivered.Text));
        }

        private void StatusCodeLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if(!StatusCodeLookUpEdit.OldEditValue.Equals(6))
                if (StatusCodeLookUpEdit.ItemIndex == 5)
                {
                    EventHandler handler = OnStatusCodeChanged;
                    if (handler == null) return;
                    handler(null, null);
                }
        }

    }
}
