using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.MetadataServiceReference;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using System.Collections;
using Katrin.Win.Infrastructure.Services;
using Katrin.Win.MainModule.Views.Opportunity;
using Katrin.Win.MainModule.Views.Account;
using Katrin.Win.MainModule.Views.User;
using Katrin.Win.Common.Controls;
namespace Katrin.Win.MainModule.Views.Quote
{
    [SmartPart]
    public partial class QuoteDetailView : AbstractDetailView,IQuoteDetailView
    {
        public event EventHandler NewQuoteLineItem;

        private QuoteDetailPresenter _presenter;
        public event EventHandler QuoteLineItemSelectProductChanged;
        public event EventHandler CalculateTotalAmount;
        public event EventHandler RemoveQuoteLineItem;

        [CreateNew]
        public QuoteDetailPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        public QuoteDetailView()
        {
            InitializeComponent();
            
        }

        public override void SetEditorStatus(bool isReadOnly)
        {
            base.SetEditorStatus(isReadOnly);
            lkpProduct.ReadOnly = isReadOnly;
            seQuantity.ReadOnly = isReadOnly;
            sePrice.ReadOnly = isReadOnly;
        }

        public override void Bind(object entity)
        {
            EntityBindingSource.DataSource = entity;
            customerAddressBindingSource.DataMember = "BillTo_Address";
            quoteLineItemsBindingSource.DataMember = "QuoteLineItems";
            
            ForeceTabGroupInitialize();
            UserDataPersistenceService.LoadUserData(this);
        }

        public override void InitEditors(Entity entity)
        {
            base.InitEditors(entity);
            string defaultLayoutPath = "Katrin.Win.MainModule.DefaultLayout";
            OpportunityIdSearchLookUpEdit.Bind(entity);
            OpportunityIdSearchLookUpEdit.AddDetailButton<OpportunityDetailView>(OpenDetail, "Opportunity");

            CustomerIdSearchLookUpEdit.Bind(entity);
            CustomerIdSearchLookUpEdit.AddDetailButton<AccountDetailView>(OpenDetail, "Account");
            OwnerIdSearchLookUpEdit.InitEdit("User", "Department", false);
            //OwnerIdSearchLookUpEdit.Bind(entity);
            OwnerIdSearchLookUpEdit.AddDetailButton<UserDetailView>(OpenDetail, "User");

            TransactionCurrencyIdLookUpEdit.BindLookupList(entity, true);

            PaymentTermsCodeLookUpEdit.BindPickList(entity);
            StageCodeLookUpEdit.BindPickList(entity);
            StatusCodeLookUpEdit.BindPickList(entity);
        }

        public void PoppulateProducts(IEnumerable products)
        {
            lkpProduct.DisplayMember = "Name";
            lkpProduct.ValueMember = "ProductId";

            lkpProduct.DataSource = products;
            lkpProduct.NullText = string.Empty;
            lkpProduct.Columns.Clear();
            lkpProduct.Columns.Add(new LookUpColumnInfo(lkpProduct.DisplayMember));
            lkpProduct.TextEditStyle = TextEditStyles.DisableTextEditor;
            lkpProduct.ShowHeader = false;
            lkpProduct.ShowFooter = false;
            lkpProduct.AllowNullInput = DefaultBoolean.True;
        }


        public override void InitValidation()
        {
            SetValidationRule(NameTextEdit, ValidationRules.IsNotBlankRule(ItemForName.Text));
            SetValidationRule(CustomerIdSearchLookUpEdit, ValidationRules.IsNotBlankRule(ItemForCustomerId.Text));
            SetValidationRule(OwnerIdSearchLookUpEdit, ValidationRules.IsNotBlankRule(ItemForOwnerId.Text));
            SetValidationRule(StageCodeLookUpEdit, ValidationRules.IsNotBlankRule(ItemForStageCode.Text));
            SetValidationRule(OwnerIdSearchLookUpEdit, ValidationRules.IsGuidNotBlankRule(ItemForOwnerId.Text));
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            //AddNewQuoteLineItem();

            if (NewQuoteLineItem != null)
            {
                NewQuoteLineItem(this, EventArgs.Empty);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (RemoveQuoteLineItem != null)
            {
                RemoveQuoteLineItem(this, EventArgs.Empty);
            }
        }

        public void DeleteSelectedQuoteLineItem()
        {
            quoteLineItemGridView.DeleteSelectedRows();
        }

        private void RaiseCalculateTotalAmount()
        {
            if (CalculateTotalAmount != null)
            {
                CalculateTotalAmount(this, EventArgs.Empty);
            }
        }

        private void AmountEditValueChanged(object sender, EventArgs e)
        {
            RaiseCalculateTotalAmount();
        }

        public void AddNewQuoteLineItem()
        {
            quoteLineItemGridView.AddNewRow();
        }

        private void lkpProduct_EditValueChanged(object sender, EventArgs e)
        {
            quoteLineItemGridView.PostEditor();
            if (QuoteLineItemSelectProductChanged != null)
            {
                QuoteLineItemSelectProductChanged(sender, e);
            }
        }

        public object CurrentQuoteLineItem
        {
            get
            {
                return quoteLineItemGridView.GetFocusedRow();
            }
        }

        private void seQuantity_ValueChanged(object sender, EventArgs e)
        {
            quoteLineItemGridView.PostEditor();
            RaiseCalculateTotalAmount();
        }

        private void sePrice_ValueChanged(object sender, EventArgs e)
        {
            quoteLineItemGridView.PostEditor();
            RaiseCalculateTotalAmount();
        }

    }
}
