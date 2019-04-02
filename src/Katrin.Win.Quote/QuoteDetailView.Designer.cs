using System;
using Katrin.AppFramework.WinForms.Controls;
using Katrin.Win.Common.Controls;
namespace Katrin.Win.QuoteModule
{
    partial class QuoteDetailView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            GC.Collect();
            //GC.SuppressFinalize(this);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuoteDetailView));
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.quoteLineItemGridControl = new DevExpress.XtraGrid.GridControl();
            this.quoteLineItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quoteLineItemGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkpProduct = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.seQuantity = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sePrice = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colTotalPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AccountTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.BillTo_ContactNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ExchangeRateTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.OpportunityTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.QuoteIdTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.NameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.QuoteNumberTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.TotalAmountTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.TotalDiscountAmountTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.TotalLineItemAmountTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.TotalTaxTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.TransactionCurrencyTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.UserTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.VersionNumberPictureEdit = new DevExpress.XtraEditors.PictureEdit();
            this.StageCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.StatusCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.PaymentTermsCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.TransactionCurrencyIdLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.DescriptionTextEdit = new DevExpress.XtraEditors.MemoEdit();
            this.ExpiresOnTextEdit = new Katrin.AppFramework.WinForms.Controls.DropDownDateEdit();
            this.ItemForOpportunity = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForQuoteId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTransactionCurrency = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForUser = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForVersionNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAccount = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForTransactionCurrencyId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForBillingAddress = new DevExpress.XtraLayout.LayoutControlItem();
            this.BillingAddressNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.customerAddressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ItemForCountry = new DevExpress.XtraLayout.LayoutControlItem();
            this.CountryTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForState = new DevExpress.XtraLayout.LayoutControlItem();
            this.StateTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForPaymentTermsCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForBillTo_ContactName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPostalCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.PostalCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForCity = new DevExpress.XtraLayout.LayoutControlItem();
            this.CityTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForExchangeRate = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.LineItemLayoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ProductLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForNewLineItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForRemoveLine = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ItemForTotalLineItemAmount = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTotalDiscountAmount = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTotalTax = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTotalAmount = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCustomerId = new DevExpress.XtraLayout.LayoutControlItem();
            this.CustomerIdSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.ItemForExpiresOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForStatusCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForStageCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForOpportunityId = new DevExpress.XtraLayout.LayoutControlItem();
            this.OpportunityIdSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.ItemForQuoteNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.managementLayoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForOwnerId = new DevExpress.XtraLayout.LayoutControlItem();
            this.OwnerIdSearchLookUpEdit = new DevExpress.XtraEditors.PopupContainerEdit();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ItemForCreatedOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.ItemForCreateBy = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.ItemForModifiedOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.ItemForModifiedBy = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).BeginInit();
            this.EntityDataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quoteLineItemGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quoteLineItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quoteLineItemGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillTo_ContactNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExchangeRateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpportunityTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuoteIdTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuoteNumberTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalAmountTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDiscountAmountTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalLineItemAmountTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalTaxTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionCurrencyTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VersionNumberPictureEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StageCodeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusCodeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentTermsCodeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionCurrencyIdLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpiresOnTextEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpiresOnTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOpportunity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForQuoteId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTransactionCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForVersionNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTransactionCurrencyId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBillingAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillingAddressNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerAddressBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountryTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPaymentTermsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBillTo_ContactName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPostalCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PostalCodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CityTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForExchangeRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineItemLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductLayoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNewLineItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRemoveLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTotalLineItemAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTotalDiscountAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTotalTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTotalAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCustomerId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerIdSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForExpiresOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStageCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOpportunityId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpportunityIdSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForQuoteNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.managementLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOwnerId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OwnerIdSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreateBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // EntityDataLayoutControl
            // 
            resources.ApplyResources(this.EntityDataLayoutControl, "EntityDataLayoutControl");
            this.EntityDataLayoutControl.Controls.Add(this.textEdit4);
            this.EntityDataLayoutControl.Controls.Add(this.PostalCodeTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit3);
            this.EntityDataLayoutControl.Controls.Add(this.StateTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit2);
            this.EntityDataLayoutControl.Controls.Add(this.CountryTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit1);
            this.EntityDataLayoutControl.Controls.Add(this.CityTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.BillingAddressNameTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.btnNew);
            this.EntityDataLayoutControl.Controls.Add(this.quoteLineItemGridControl);
            this.EntityDataLayoutControl.Controls.Add(this.AccountTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.BillTo_ContactNameTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.btnRemove);
            this.EntityDataLayoutControl.Controls.Add(this.ExchangeRateTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.OpportunityTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.QuoteIdTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.NameTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.QuoteNumberTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.TotalAmountTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.TotalLineItemAmountTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.TotalTaxTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.TransactionCurrencyTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.UserTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.TotalDiscountAmountTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.VersionNumberPictureEdit);
            this.EntityDataLayoutControl.Controls.Add(this.StageCodeLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.StatusCodeLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.PaymentTermsCodeLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.TransactionCurrencyIdLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.DescriptionTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.ExpiresOnTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.CustomerIdSearchLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.OpportunityIdSearchLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.OwnerIdSearchLookUpEdit);
            this.EntityDataLayoutControl.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForOpportunity,
            this.ItemForQuoteId,
            this.ItemForTransactionCurrency,
            this.ItemForUser,
            this.ItemForVersionNumber,
            this.ItemForAccount});
            this.EntityDataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1121, 122, 381, 428);
            // 
            // RootLayoutControlGroup
            // 
            resources.ApplyResources(this.RootLayoutControlGroup, "RootLayoutControlGroup");
            this.RootLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1});
            this.RootLayoutControlGroup.Name = "Root";
            this.RootLayoutControlGroup.OptionsToolTip.ToolTip = resources.GetString("resource.ToolTip");
            this.RootLayoutControlGroup.OptionsToolTip.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("resource.ToolTipIconType")));
            this.RootLayoutControlGroup.OptionsToolTip.ToolTipTitle = resources.GetString("resource.ToolTipTitle");
            this.RootLayoutControlGroup.Size = new System.Drawing.Size(969, 393);
            // 
            // btnRemove
            // 
            resources.ApplyResources(this.btnRemove, "btnRemove");
            this.btnRemove.AutoWidthInLayoutControl = true;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.StyleController = this.EntityDataLayoutControl;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnNew
            // 
            resources.ApplyResources(this.btnNew, "btnNew");
            this.btnNew.Name = "btnNew";
            this.btnNew.StyleController = this.EntityDataLayoutControl;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // quoteLineItemGridControl
            // 
            resources.ApplyResources(this.quoteLineItemGridControl, "quoteLineItemGridControl");
            this.quoteLineItemGridControl.DataSource = this.quoteLineItemsBindingSource;
            this.quoteLineItemGridControl.EmbeddedNavigator.AccessibleDescription = resources.GetString("quoteLineItemGridControl.EmbeddedNavigator.AccessibleDescription");
            this.quoteLineItemGridControl.EmbeddedNavigator.AccessibleName = resources.GetString("quoteLineItemGridControl.EmbeddedNavigator.AccessibleName");
            this.quoteLineItemGridControl.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("quoteLineItemGridControl.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.quoteLineItemGridControl.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("quoteLineItemGridControl.EmbeddedNavigator.Anchor")));
            this.quoteLineItemGridControl.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("quoteLineItemGridControl.EmbeddedNavigator.BackgroundImage")));
            this.quoteLineItemGridControl.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("quoteLineItemGridControl.EmbeddedNavigator.BackgroundImageLayout")));
            this.quoteLineItemGridControl.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("quoteLineItemGridControl.EmbeddedNavigator.ImeMode")));
            this.quoteLineItemGridControl.EmbeddedNavigator.MaximumSize = ((System.Drawing.Size)(resources.GetObject("quoteLineItemGridControl.EmbeddedNavigator.MaximumSize")));
            this.quoteLineItemGridControl.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("quoteLineItemGridControl.EmbeddedNavigator.TextLocation")));
            this.quoteLineItemGridControl.EmbeddedNavigator.ToolTip = resources.GetString("quoteLineItemGridControl.EmbeddedNavigator.ToolTip");
            this.quoteLineItemGridControl.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("quoteLineItemGridControl.EmbeddedNavigator.ToolTipIconType")));
            this.quoteLineItemGridControl.EmbeddedNavigator.ToolTipTitle = resources.GetString("quoteLineItemGridControl.EmbeddedNavigator.ToolTipTitle");
            this.quoteLineItemGridControl.MainView = this.quoteLineItemGridView;
            this.quoteLineItemGridControl.Name = "quoteLineItemGridControl";
            this.quoteLineItemGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lkpProduct,
            this.seQuantity,
            this.sePrice});
            this.quoteLineItemGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.quoteLineItemGridView});
            // 
            // quoteLineItemsBindingSource
            // 
            this.quoteLineItemsBindingSource.DataSource = this.EntityBindingSource;
            // 
            // quoteLineItemGridView
            // 
            resources.ApplyResources(this.quoteLineItemGridView, "quoteLineItemGridView");
            this.quoteLineItemGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProduct,
            this.colQuantity,
            this.colUnitPrice,
            this.colTotalPrice});
            this.quoteLineItemGridView.GridControl = this.quoteLineItemGridControl;
            this.quoteLineItemGridView.Name = "quoteLineItemGridView";
            this.quoteLineItemGridView.OptionsBehavior.CacheValuesOnRowUpdating = DevExpress.Data.CacheRowValuesMode.Disabled;
            this.quoteLineItemGridView.OptionsView.ShowFooter = true;
            this.quoteLineItemGridView.OptionsView.ShowGroupPanel = false;
            this.quoteLineItemGridView.ShownEditor += new System.EventHandler(this.quoteLineItemGridView_ShownEditor);
            // 
            // colProduct
            // 
            resources.ApplyResources(this.colProduct, "colProduct");
            this.colProduct.ColumnEdit = this.lkpProduct;
            this.colProduct.FieldName = "ProductId";
            this.colProduct.Name = "colProduct";
            this.colProduct.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // lkpProduct
            // 
            resources.ApplyResources(this.lkpProduct, "lkpProduct");
            this.lkpProduct.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("lkpProduct.Buttons"))))});
            this.lkpProduct.EditFormat.FormatString = "#####.##";
            this.lkpProduct.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.lkpProduct.Name = "lkpProduct";
            this.lkpProduct.EditValueChanged += new System.EventHandler(this.lkpProduct_EditValueChanged);
            // 
            // colQuantity
            // 
            resources.ApplyResources(this.colQuantity, "colQuantity");
            this.colQuantity.ColumnEdit = this.seQuantity;
            this.colQuantity.DisplayFormat.FormatString = "{0:n0}";
            this.colQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("colQuantity.Summary"))), resources.GetString("colQuantity.Summary1"), resources.GetString("colQuantity.Summary2"))});
            // 
            // seQuantity
            // 
            resources.ApplyResources(this.seQuantity, "seQuantity");
            this.seQuantity.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seQuantity.DisplayFormat.FormatString = "{0:n0}";
            this.seQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seQuantity.EditFormat.FormatString = "{0:n0}";
            this.seQuantity.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seQuantity.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("seQuantity.Mask.AutoComplete")));
            this.seQuantity.Mask.BeepOnError = ((bool)(resources.GetObject("seQuantity.Mask.BeepOnError")));
            this.seQuantity.Mask.EditMask = resources.GetString("seQuantity.Mask.EditMask");
            this.seQuantity.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("seQuantity.Mask.IgnoreMaskBlank")));
            this.seQuantity.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("seQuantity.Mask.MaskType")));
            this.seQuantity.Mask.PlaceHolder = ((char)(resources.GetObject("seQuantity.Mask.PlaceHolder")));
            this.seQuantity.Mask.SaveLiteral = ((bool)(resources.GetObject("seQuantity.Mask.SaveLiteral")));
            this.seQuantity.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("seQuantity.Mask.ShowPlaceHolders")));
            this.seQuantity.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("seQuantity.Mask.UseMaskAsDisplayFormat")));
            this.seQuantity.MaxLength = 5;
            this.seQuantity.MaxValue = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.seQuantity.Name = "seQuantity";
            this.seQuantity.ValueChanged += new System.EventHandler(this.seQuantity_ValueChanged);
            // 
            // colUnitPrice
            // 
            resources.ApplyResources(this.colUnitPrice, "colUnitPrice");
            this.colUnitPrice.ColumnEdit = this.sePrice;
            this.colUnitPrice.DisplayFormat.FormatString = "{0:n2}";
            this.colUnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitPrice.FieldName = "UnitPrice";
            this.colUnitPrice.Name = "colUnitPrice";
            // 
            // sePrice
            // 
            resources.ApplyResources(this.sePrice, "sePrice");
            this.sePrice.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.sePrice.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("sePrice.Mask.AutoComplete")));
            this.sePrice.Mask.BeepOnError = ((bool)(resources.GetObject("sePrice.Mask.BeepOnError")));
            this.sePrice.Mask.EditMask = resources.GetString("sePrice.Mask.EditMask");
            this.sePrice.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("sePrice.Mask.IgnoreMaskBlank")));
            this.sePrice.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("sePrice.Mask.MaskType")));
            this.sePrice.Mask.PlaceHolder = ((char)(resources.GetObject("sePrice.Mask.PlaceHolder")));
            this.sePrice.Mask.SaveLiteral = ((bool)(resources.GetObject("sePrice.Mask.SaveLiteral")));
            this.sePrice.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("sePrice.Mask.ShowPlaceHolders")));
            this.sePrice.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("sePrice.Mask.UseMaskAsDisplayFormat")));
            this.sePrice.Name = "sePrice";
            this.sePrice.ValueChanged += new System.EventHandler(this.sePrice_ValueChanged);
            // 
            // colTotalPrice
            // 
            resources.ApplyResources(this.colTotalPrice, "colTotalPrice");
            this.colTotalPrice.DisplayFormat.FormatString = "{0:n2}";
            this.colTotalPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalPrice.FieldName = "colTotalPrice";
            this.colTotalPrice.Name = "colTotalPrice";
            this.colTotalPrice.OptionsColumn.AllowEdit = false;
            this.colTotalPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("colTotalPrice.Summary"))), resources.GetString("colTotalPrice.Summary1"), resources.GetString("colTotalPrice.Summary2"))});
            this.colTotalPrice.UnboundExpression = "[Quantity] * [UnitPrice]";
            this.colTotalPrice.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            // 
            // AccountTextEdit
            // 
            resources.ApplyResources(this.AccountTextEdit, "AccountTextEdit");
            this.AccountTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Account", true));
            this.AccountTextEdit.Name = "AccountTextEdit";
            this.AccountTextEdit.Properties.AccessibleDescription = resources.GetString("AccountTextEdit.Properties.AccessibleDescription");
            this.AccountTextEdit.Properties.AccessibleName = resources.GetString("AccountTextEdit.Properties.AccessibleName");
            this.AccountTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("AccountTextEdit.Properties.AutoHeight")));
            this.AccountTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("AccountTextEdit.Properties.Mask.AutoComplete")));
            this.AccountTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("AccountTextEdit.Properties.Mask.BeepOnError")));
            this.AccountTextEdit.Properties.Mask.EditMask = resources.GetString("AccountTextEdit.Properties.Mask.EditMask");
            this.AccountTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("AccountTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.AccountTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("AccountTextEdit.Properties.Mask.MaskType")));
            this.AccountTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("AccountTextEdit.Properties.Mask.PlaceHolder")));
            this.AccountTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("AccountTextEdit.Properties.Mask.SaveLiteral")));
            this.AccountTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("AccountTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.AccountTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("AccountTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.AccountTextEdit.Properties.NullValuePrompt = resources.GetString("AccountTextEdit.Properties.NullValuePrompt");
            this.AccountTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("AccountTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.AccountTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // BillTo_ContactNameTextEdit
            // 
            resources.ApplyResources(this.BillTo_ContactNameTextEdit, "BillTo_ContactNameTextEdit");
            this.BillTo_ContactNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "BillTo_ContactName", true));
            this.BillTo_ContactNameTextEdit.Name = "BillTo_ContactNameTextEdit";
            this.BillTo_ContactNameTextEdit.Properties.AccessibleDescription = resources.GetString("BillTo_ContactNameTextEdit.Properties.AccessibleDescription");
            this.BillTo_ContactNameTextEdit.Properties.AccessibleName = resources.GetString("BillTo_ContactNameTextEdit.Properties.AccessibleName");
            this.BillTo_ContactNameTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("BillTo_ContactNameTextEdit.Properties.AutoHeight")));
            this.BillTo_ContactNameTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("BillTo_ContactNameTextEdit.Properties.Mask.AutoComplete")));
            this.BillTo_ContactNameTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("BillTo_ContactNameTextEdit.Properties.Mask.BeepOnError")));
            this.BillTo_ContactNameTextEdit.Properties.Mask.EditMask = resources.GetString("BillTo_ContactNameTextEdit.Properties.Mask.EditMask");
            this.BillTo_ContactNameTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("BillTo_ContactNameTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.BillTo_ContactNameTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("BillTo_ContactNameTextEdit.Properties.Mask.MaskType")));
            this.BillTo_ContactNameTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("BillTo_ContactNameTextEdit.Properties.Mask.PlaceHolder")));
            this.BillTo_ContactNameTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("BillTo_ContactNameTextEdit.Properties.Mask.SaveLiteral")));
            this.BillTo_ContactNameTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("BillTo_ContactNameTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.BillTo_ContactNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("BillTo_ContactNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.BillTo_ContactNameTextEdit.Properties.NullValuePrompt = resources.GetString("BillTo_ContactNameTextEdit.Properties.NullValuePrompt");
            this.BillTo_ContactNameTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("BillTo_ContactNameTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.BillTo_ContactNameTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ExchangeRateTextEdit
            // 
            resources.ApplyResources(this.ExchangeRateTextEdit, "ExchangeRateTextEdit");
            this.ExchangeRateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ExchangeRate", true));
            this.ExchangeRateTextEdit.Name = "ExchangeRateTextEdit";
            this.ExchangeRateTextEdit.Properties.AccessibleDescription = resources.GetString("ExchangeRateTextEdit.Properties.AccessibleDescription");
            this.ExchangeRateTextEdit.Properties.AccessibleName = resources.GetString("ExchangeRateTextEdit.Properties.AccessibleName");
            this.ExchangeRateTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("ExchangeRateTextEdit.Properties.AutoHeight")));
            this.ExchangeRateTextEdit.Properties.DisplayFormat.FormatString = "{0:0.00}";
            this.ExchangeRateTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ExchangeRateTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("ExchangeRateTextEdit.Properties.Mask.AutoComplete")));
            this.ExchangeRateTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("ExchangeRateTextEdit.Properties.Mask.BeepOnError")));
            this.ExchangeRateTextEdit.Properties.Mask.EditMask = resources.GetString("ExchangeRateTextEdit.Properties.Mask.EditMask");
            this.ExchangeRateTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("ExchangeRateTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.ExchangeRateTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("ExchangeRateTextEdit.Properties.Mask.MaskType")));
            this.ExchangeRateTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("ExchangeRateTextEdit.Properties.Mask.PlaceHolder")));
            this.ExchangeRateTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("ExchangeRateTextEdit.Properties.Mask.SaveLiteral")));
            this.ExchangeRateTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("ExchangeRateTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.ExchangeRateTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("ExchangeRateTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.ExchangeRateTextEdit.Properties.MaxLength = 6;
            this.ExchangeRateTextEdit.Properties.NullValuePrompt = resources.GetString("ExchangeRateTextEdit.Properties.NullValuePrompt");
            this.ExchangeRateTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("ExchangeRateTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.ExchangeRateTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // OpportunityTextEdit
            // 
            resources.ApplyResources(this.OpportunityTextEdit, "OpportunityTextEdit");
            this.OpportunityTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Opportunity", true));
            this.OpportunityTextEdit.Name = "OpportunityTextEdit";
            this.OpportunityTextEdit.Properties.AccessibleDescription = resources.GetString("OpportunityTextEdit.Properties.AccessibleDescription");
            this.OpportunityTextEdit.Properties.AccessibleName = resources.GetString("OpportunityTextEdit.Properties.AccessibleName");
            this.OpportunityTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("OpportunityTextEdit.Properties.AutoHeight")));
            this.OpportunityTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("OpportunityTextEdit.Properties.Mask.AutoComplete")));
            this.OpportunityTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("OpportunityTextEdit.Properties.Mask.BeepOnError")));
            this.OpportunityTextEdit.Properties.Mask.EditMask = resources.GetString("OpportunityTextEdit.Properties.Mask.EditMask");
            this.OpportunityTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("OpportunityTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.OpportunityTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("OpportunityTextEdit.Properties.Mask.MaskType")));
            this.OpportunityTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("OpportunityTextEdit.Properties.Mask.PlaceHolder")));
            this.OpportunityTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("OpportunityTextEdit.Properties.Mask.SaveLiteral")));
            this.OpportunityTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("OpportunityTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.OpportunityTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("OpportunityTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.OpportunityTextEdit.Properties.NullValuePrompt = resources.GetString("OpportunityTextEdit.Properties.NullValuePrompt");
            this.OpportunityTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("OpportunityTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.OpportunityTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // QuoteIdTextEdit
            // 
            resources.ApplyResources(this.QuoteIdTextEdit, "QuoteIdTextEdit");
            this.QuoteIdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "QuoteId", true));
            this.QuoteIdTextEdit.Name = "QuoteIdTextEdit";
            this.QuoteIdTextEdit.Properties.AccessibleDescription = resources.GetString("QuoteIdTextEdit.Properties.AccessibleDescription");
            this.QuoteIdTextEdit.Properties.AccessibleName = resources.GetString("QuoteIdTextEdit.Properties.AccessibleName");
            this.QuoteIdTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("QuoteIdTextEdit.Properties.AutoHeight")));
            this.QuoteIdTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("QuoteIdTextEdit.Properties.Mask.AutoComplete")));
            this.QuoteIdTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("QuoteIdTextEdit.Properties.Mask.BeepOnError")));
            this.QuoteIdTextEdit.Properties.Mask.EditMask = resources.GetString("QuoteIdTextEdit.Properties.Mask.EditMask");
            this.QuoteIdTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("QuoteIdTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.QuoteIdTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("QuoteIdTextEdit.Properties.Mask.MaskType")));
            this.QuoteIdTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("QuoteIdTextEdit.Properties.Mask.PlaceHolder")));
            this.QuoteIdTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("QuoteIdTextEdit.Properties.Mask.SaveLiteral")));
            this.QuoteIdTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("QuoteIdTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.QuoteIdTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("QuoteIdTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.QuoteIdTextEdit.Properties.NullValuePrompt = resources.GetString("QuoteIdTextEdit.Properties.NullValuePrompt");
            this.QuoteIdTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("QuoteIdTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.QuoteIdTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // NameTextEdit
            // 
            resources.ApplyResources(this.NameTextEdit, "NameTextEdit");
            this.NameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Name", true));
            this.NameTextEdit.Name = "NameTextEdit";
            this.NameTextEdit.Properties.AccessibleDescription = resources.GetString("NameTextEdit.Properties.AccessibleDescription");
            this.NameTextEdit.Properties.AccessibleName = resources.GetString("NameTextEdit.Properties.AccessibleName");
            this.NameTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("NameTextEdit.Properties.AutoHeight")));
            this.NameTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("NameTextEdit.Properties.Mask.AutoComplete")));
            this.NameTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("NameTextEdit.Properties.Mask.BeepOnError")));
            this.NameTextEdit.Properties.Mask.EditMask = resources.GetString("NameTextEdit.Properties.Mask.EditMask");
            this.NameTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("NameTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.NameTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("NameTextEdit.Properties.Mask.MaskType")));
            this.NameTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("NameTextEdit.Properties.Mask.PlaceHolder")));
            this.NameTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("NameTextEdit.Properties.Mask.SaveLiteral")));
            this.NameTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("NameTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.NameTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("NameTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.NameTextEdit.Properties.NullValuePrompt = resources.GetString("NameTextEdit.Properties.NullValuePrompt");
            this.NameTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("NameTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.NameTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // QuoteNumberTextEdit
            // 
            resources.ApplyResources(this.QuoteNumberTextEdit, "QuoteNumberTextEdit");
            this.QuoteNumberTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "QuoteNumber", true));
            this.QuoteNumberTextEdit.Name = "QuoteNumberTextEdit";
            this.QuoteNumberTextEdit.Properties.AccessibleDescription = resources.GetString("QuoteNumberTextEdit.Properties.AccessibleDescription");
            this.QuoteNumberTextEdit.Properties.AccessibleName = resources.GetString("QuoteNumberTextEdit.Properties.AccessibleName");
            this.QuoteNumberTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("QuoteNumberTextEdit.Properties.AutoHeight")));
            this.QuoteNumberTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("QuoteNumberTextEdit.Properties.Mask.AutoComplete")));
            this.QuoteNumberTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("QuoteNumberTextEdit.Properties.Mask.BeepOnError")));
            this.QuoteNumberTextEdit.Properties.Mask.EditMask = resources.GetString("QuoteNumberTextEdit.Properties.Mask.EditMask");
            this.QuoteNumberTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("QuoteNumberTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.QuoteNumberTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("QuoteNumberTextEdit.Properties.Mask.MaskType")));
            this.QuoteNumberTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("QuoteNumberTextEdit.Properties.Mask.PlaceHolder")));
            this.QuoteNumberTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("QuoteNumberTextEdit.Properties.Mask.SaveLiteral")));
            this.QuoteNumberTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("QuoteNumberTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.QuoteNumberTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("QuoteNumberTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.QuoteNumberTextEdit.Properties.NullValuePrompt = resources.GetString("QuoteNumberTextEdit.Properties.NullValuePrompt");
            this.QuoteNumberTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("QuoteNumberTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.QuoteNumberTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // TotalAmountTextEdit
            // 
            resources.ApplyResources(this.TotalAmountTextEdit, "TotalAmountTextEdit");
            this.TotalAmountTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "TotalAmount", true));
            this.TotalAmountTextEdit.Name = "TotalAmountTextEdit";
            this.TotalAmountTextEdit.Properties.AccessibleDescription = resources.GetString("TotalAmountTextEdit.Properties.AccessibleDescription");
            this.TotalAmountTextEdit.Properties.AccessibleName = resources.GetString("TotalAmountTextEdit.Properties.AccessibleName");
            this.TotalAmountTextEdit.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("TotalAmountTextEdit.Properties.Appearance.BackColor")));
            this.TotalAmountTextEdit.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("TotalAmountTextEdit.Properties.Appearance.GradientMode")));
            this.TotalAmountTextEdit.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("TotalAmountTextEdit.Properties.Appearance.Image")));
            this.TotalAmountTextEdit.Properties.Appearance.Options.UseBackColor = true;
            this.TotalAmountTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("TotalAmountTextEdit.Properties.AutoHeight")));
            this.TotalAmountTextEdit.Properties.DisplayFormat.FormatString = "{0:N2}";
            this.TotalAmountTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TotalAmountTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("TotalAmountTextEdit.Properties.Mask.AutoComplete")));
            this.TotalAmountTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("TotalAmountTextEdit.Properties.Mask.BeepOnError")));
            this.TotalAmountTextEdit.Properties.Mask.EditMask = resources.GetString("TotalAmountTextEdit.Properties.Mask.EditMask");
            this.TotalAmountTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("TotalAmountTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.TotalAmountTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("TotalAmountTextEdit.Properties.Mask.MaskType")));
            this.TotalAmountTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("TotalAmountTextEdit.Properties.Mask.PlaceHolder")));
            this.TotalAmountTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("TotalAmountTextEdit.Properties.Mask.SaveLiteral")));
            this.TotalAmountTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("TotalAmountTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.TotalAmountTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("TotalAmountTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.TotalAmountTextEdit.Properties.NullValuePrompt = resources.GetString("TotalAmountTextEdit.Properties.NullValuePrompt");
            this.TotalAmountTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("TotalAmountTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.TotalAmountTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // TotalDiscountAmountTextEdit
            // 
            resources.ApplyResources(this.TotalDiscountAmountTextEdit, "TotalDiscountAmountTextEdit");
            this.TotalDiscountAmountTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "TotalDiscountAmount", true));
            this.TotalDiscountAmountTextEdit.Name = "TotalDiscountAmountTextEdit";
            this.TotalDiscountAmountTextEdit.Properties.AccessibleDescription = resources.GetString("TotalDiscountAmountTextEdit.Properties.AccessibleDescription");
            this.TotalDiscountAmountTextEdit.Properties.AccessibleName = resources.GetString("TotalDiscountAmountTextEdit.Properties.AccessibleName");
            this.TotalDiscountAmountTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("TotalDiscountAmountTextEdit.Properties.AutoHeight")));
            this.TotalDiscountAmountTextEdit.Properties.DisplayFormat.FormatString = "{0:0.00}";
            this.TotalDiscountAmountTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TotalDiscountAmountTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("TotalDiscountAmountTextEdit.Properties.Mask.AutoComplete")));
            this.TotalDiscountAmountTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("TotalDiscountAmountTextEdit.Properties.Mask.BeepOnError")));
            this.TotalDiscountAmountTextEdit.Properties.Mask.EditMask = resources.GetString("TotalDiscountAmountTextEdit.Properties.Mask.EditMask");
            this.TotalDiscountAmountTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("TotalDiscountAmountTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.TotalDiscountAmountTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("TotalDiscountAmountTextEdit.Properties.Mask.MaskType")));
            this.TotalDiscountAmountTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("TotalDiscountAmountTextEdit.Properties.Mask.PlaceHolder")));
            this.TotalDiscountAmountTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("TotalDiscountAmountTextEdit.Properties.Mask.SaveLiteral")));
            this.TotalDiscountAmountTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("TotalDiscountAmountTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.TotalDiscountAmountTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("TotalDiscountAmountTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.TotalDiscountAmountTextEdit.Properties.MaxLength = 10;
            this.TotalDiscountAmountTextEdit.Properties.NullValuePrompt = resources.GetString("TotalDiscountAmountTextEdit.Properties.NullValuePrompt");
            this.TotalDiscountAmountTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("TotalDiscountAmountTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.TotalDiscountAmountTextEdit.StyleController = this.EntityDataLayoutControl;
            this.TotalDiscountAmountTextEdit.EditValueChanged += new System.EventHandler(this.AmountEditValueChanged);
            // 
            // TotalLineItemAmountTextEdit
            // 
            resources.ApplyResources(this.TotalLineItemAmountTextEdit, "TotalLineItemAmountTextEdit");
            this.TotalLineItemAmountTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "TotalLineItemAmount", true));
            this.TotalLineItemAmountTextEdit.Name = "TotalLineItemAmountTextEdit";
            this.TotalLineItemAmountTextEdit.Properties.AccessibleDescription = resources.GetString("TotalLineItemAmountTextEdit.Properties.AccessibleDescription");
            this.TotalLineItemAmountTextEdit.Properties.AccessibleName = resources.GetString("TotalLineItemAmountTextEdit.Properties.AccessibleName");
            this.TotalLineItemAmountTextEdit.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("TotalLineItemAmountTextEdit.Properties.Appearance.BackColor")));
            this.TotalLineItemAmountTextEdit.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("TotalLineItemAmountTextEdit.Properties.Appearance.GradientMode")));
            this.TotalLineItemAmountTextEdit.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("TotalLineItemAmountTextEdit.Properties.Appearance.Image")));
            this.TotalLineItemAmountTextEdit.Properties.Appearance.Options.UseBackColor = true;
            this.TotalLineItemAmountTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("TotalLineItemAmountTextEdit.Properties.AutoHeight")));
            this.TotalLineItemAmountTextEdit.Properties.DisplayFormat.FormatString = "{0:N2}";
            this.TotalLineItemAmountTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TotalLineItemAmountTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("TotalLineItemAmountTextEdit.Properties.Mask.AutoComplete")));
            this.TotalLineItemAmountTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("TotalLineItemAmountTextEdit.Properties.Mask.BeepOnError")));
            this.TotalLineItemAmountTextEdit.Properties.Mask.EditMask = resources.GetString("TotalLineItemAmountTextEdit.Properties.Mask.EditMask");
            this.TotalLineItemAmountTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("TotalLineItemAmountTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.TotalLineItemAmountTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("TotalLineItemAmountTextEdit.Properties.Mask.MaskType")));
            this.TotalLineItemAmountTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("TotalLineItemAmountTextEdit.Properties.Mask.PlaceHolder")));
            this.TotalLineItemAmountTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("TotalLineItemAmountTextEdit.Properties.Mask.SaveLiteral")));
            this.TotalLineItemAmountTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("TotalLineItemAmountTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.TotalLineItemAmountTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("TotalLineItemAmountTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.TotalLineItemAmountTextEdit.Properties.NullValuePrompt = resources.GetString("TotalLineItemAmountTextEdit.Properties.NullValuePrompt");
            this.TotalLineItemAmountTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("TotalLineItemAmountTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.TotalLineItemAmountTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // TotalTaxTextEdit
            // 
            resources.ApplyResources(this.TotalTaxTextEdit, "TotalTaxTextEdit");
            this.TotalTaxTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "TotalTax", true));
            this.TotalTaxTextEdit.Name = "TotalTaxTextEdit";
            this.TotalTaxTextEdit.Properties.AccessibleDescription = resources.GetString("TotalTaxTextEdit.Properties.AccessibleDescription");
            this.TotalTaxTextEdit.Properties.AccessibleName = resources.GetString("TotalTaxTextEdit.Properties.AccessibleName");
            this.TotalTaxTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("TotalTaxTextEdit.Properties.AutoHeight")));
            this.TotalTaxTextEdit.Properties.DisplayFormat.FormatString = "{0:0.00}";
            this.TotalTaxTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TotalTaxTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("TotalTaxTextEdit.Properties.Mask.AutoComplete")));
            this.TotalTaxTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("TotalTaxTextEdit.Properties.Mask.BeepOnError")));
            this.TotalTaxTextEdit.Properties.Mask.EditMask = resources.GetString("TotalTaxTextEdit.Properties.Mask.EditMask");
            this.TotalTaxTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("TotalTaxTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.TotalTaxTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("TotalTaxTextEdit.Properties.Mask.MaskType")));
            this.TotalTaxTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("TotalTaxTextEdit.Properties.Mask.PlaceHolder")));
            this.TotalTaxTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("TotalTaxTextEdit.Properties.Mask.SaveLiteral")));
            this.TotalTaxTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("TotalTaxTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.TotalTaxTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("TotalTaxTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.TotalTaxTextEdit.Properties.MaxLength = 10;
            this.TotalTaxTextEdit.Properties.NullValuePrompt = resources.GetString("TotalTaxTextEdit.Properties.NullValuePrompt");
            this.TotalTaxTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("TotalTaxTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.TotalTaxTextEdit.StyleController = this.EntityDataLayoutControl;
            this.TotalTaxTextEdit.EditValueChanged += new System.EventHandler(this.AmountEditValueChanged);
            // 
            // TransactionCurrencyTextEdit
            // 
            resources.ApplyResources(this.TransactionCurrencyTextEdit, "TransactionCurrencyTextEdit");
            this.TransactionCurrencyTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "TransactionCurrency", true));
            this.TransactionCurrencyTextEdit.Name = "TransactionCurrencyTextEdit";
            this.TransactionCurrencyTextEdit.Properties.AccessibleDescription = resources.GetString("TransactionCurrencyTextEdit.Properties.AccessibleDescription");
            this.TransactionCurrencyTextEdit.Properties.AccessibleName = resources.GetString("TransactionCurrencyTextEdit.Properties.AccessibleName");
            this.TransactionCurrencyTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("TransactionCurrencyTextEdit.Properties.AutoHeight")));
            this.TransactionCurrencyTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("TransactionCurrencyTextEdit.Properties.Mask.AutoComplete")));
            this.TransactionCurrencyTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("TransactionCurrencyTextEdit.Properties.Mask.BeepOnError")));
            this.TransactionCurrencyTextEdit.Properties.Mask.EditMask = resources.GetString("TransactionCurrencyTextEdit.Properties.Mask.EditMask");
            this.TransactionCurrencyTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("TransactionCurrencyTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.TransactionCurrencyTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("TransactionCurrencyTextEdit.Properties.Mask.MaskType")));
            this.TransactionCurrencyTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("TransactionCurrencyTextEdit.Properties.Mask.PlaceHolder")));
            this.TransactionCurrencyTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("TransactionCurrencyTextEdit.Properties.Mask.SaveLiteral")));
            this.TransactionCurrencyTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("TransactionCurrencyTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.TransactionCurrencyTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("TransactionCurrencyTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.TransactionCurrencyTextEdit.Properties.NullValuePrompt = resources.GetString("TransactionCurrencyTextEdit.Properties.NullValuePrompt");
            this.TransactionCurrencyTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("TransactionCurrencyTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.TransactionCurrencyTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // UserTextEdit
            // 
            resources.ApplyResources(this.UserTextEdit, "UserTextEdit");
            this.UserTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "User", true));
            this.UserTextEdit.Name = "UserTextEdit";
            this.UserTextEdit.Properties.AccessibleDescription = resources.GetString("UserTextEdit.Properties.AccessibleDescription");
            this.UserTextEdit.Properties.AccessibleName = resources.GetString("UserTextEdit.Properties.AccessibleName");
            this.UserTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("UserTextEdit.Properties.AutoHeight")));
            this.UserTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("UserTextEdit.Properties.Mask.AutoComplete")));
            this.UserTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("UserTextEdit.Properties.Mask.BeepOnError")));
            this.UserTextEdit.Properties.Mask.EditMask = resources.GetString("UserTextEdit.Properties.Mask.EditMask");
            this.UserTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("UserTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.UserTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("UserTextEdit.Properties.Mask.MaskType")));
            this.UserTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("UserTextEdit.Properties.Mask.PlaceHolder")));
            this.UserTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("UserTextEdit.Properties.Mask.SaveLiteral")));
            this.UserTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("UserTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.UserTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("UserTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.UserTextEdit.Properties.NullValuePrompt = resources.GetString("UserTextEdit.Properties.NullValuePrompt");
            this.UserTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("UserTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.UserTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // VersionNumberPictureEdit
            // 
            resources.ApplyResources(this.VersionNumberPictureEdit, "VersionNumberPictureEdit");
            this.VersionNumberPictureEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "VersionNumber", true));
            this.VersionNumberPictureEdit.Name = "VersionNumberPictureEdit";
            this.VersionNumberPictureEdit.Properties.AccessibleDescription = resources.GetString("VersionNumberPictureEdit.Properties.AccessibleDescription");
            this.VersionNumberPictureEdit.Properties.AccessibleName = resources.GetString("VersionNumberPictureEdit.Properties.AccessibleName");
            this.VersionNumberPictureEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // StageCodeLookUpEdit
            // 
            resources.ApplyResources(this.StageCodeLookUpEdit, "StageCodeLookUpEdit");
            this.StageCodeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "StageCode", true));
            this.StageCodeLookUpEdit.Name = "StageCodeLookUpEdit";
            this.StageCodeLookUpEdit.Properties.AccessibleDescription = resources.GetString("StageCodeLookUpEdit.Properties.AccessibleDescription");
            this.StageCodeLookUpEdit.Properties.AccessibleName = resources.GetString("StageCodeLookUpEdit.Properties.AccessibleName");
            this.StageCodeLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("StageCodeLookUpEdit.Properties.AutoHeight")));
            this.StageCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("StageCodeLookUpEdit.Properties.Buttons"))))});
            this.StageCodeLookUpEdit.Properties.NullText = resources.GetString("StageCodeLookUpEdit.Properties.NullText");
            this.StageCodeLookUpEdit.Properties.NullValuePrompt = resources.GetString("StageCodeLookUpEdit.Properties.NullValuePrompt");
            this.StageCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("StageCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.StageCodeLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // StatusCodeLookUpEdit
            // 
            resources.ApplyResources(this.StatusCodeLookUpEdit, "StatusCodeLookUpEdit");
            this.StatusCodeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "StatusCode", true));
            this.StatusCodeLookUpEdit.Name = "StatusCodeLookUpEdit";
            this.StatusCodeLookUpEdit.Properties.AccessibleDescription = resources.GetString("StatusCodeLookUpEdit.Properties.AccessibleDescription");
            this.StatusCodeLookUpEdit.Properties.AccessibleName = resources.GetString("StatusCodeLookUpEdit.Properties.AccessibleName");
            this.StatusCodeLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("StatusCodeLookUpEdit.Properties.AutoHeight")));
            this.StatusCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("StatusCodeLookUpEdit.Properties.Buttons"))))});
            this.StatusCodeLookUpEdit.Properties.NullText = resources.GetString("StatusCodeLookUpEdit.Properties.NullText");
            this.StatusCodeLookUpEdit.Properties.NullValuePrompt = resources.GetString("StatusCodeLookUpEdit.Properties.NullValuePrompt");
            this.StatusCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("StatusCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.StatusCodeLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // PaymentTermsCodeLookUpEdit
            // 
            resources.ApplyResources(this.PaymentTermsCodeLookUpEdit, "PaymentTermsCodeLookUpEdit");
            this.PaymentTermsCodeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "PaymentTermsCode", true));
            this.PaymentTermsCodeLookUpEdit.Name = "PaymentTermsCodeLookUpEdit";
            this.PaymentTermsCodeLookUpEdit.Properties.AccessibleDescription = resources.GetString("PaymentTermsCodeLookUpEdit.Properties.AccessibleDescription");
            this.PaymentTermsCodeLookUpEdit.Properties.AccessibleName = resources.GetString("PaymentTermsCodeLookUpEdit.Properties.AccessibleName");
            this.PaymentTermsCodeLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("PaymentTermsCodeLookUpEdit.Properties.AutoHeight")));
            this.PaymentTermsCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("PaymentTermsCodeLookUpEdit.Properties.Buttons"))))});
            this.PaymentTermsCodeLookUpEdit.Properties.NullText = resources.GetString("PaymentTermsCodeLookUpEdit.Properties.NullText");
            this.PaymentTermsCodeLookUpEdit.Properties.NullValuePrompt = resources.GetString("PaymentTermsCodeLookUpEdit.Properties.NullValuePrompt");
            this.PaymentTermsCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("PaymentTermsCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.PaymentTermsCodeLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // TransactionCurrencyIdLookUpEdit
            // 
            resources.ApplyResources(this.TransactionCurrencyIdLookUpEdit, "TransactionCurrencyIdLookUpEdit");
            this.TransactionCurrencyIdLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "TransactionCurrencyId", true));
            this.TransactionCurrencyIdLookUpEdit.Name = "TransactionCurrencyIdLookUpEdit";
            this.TransactionCurrencyIdLookUpEdit.Properties.AccessibleDescription = resources.GetString("TransactionCurrencyIdLookUpEdit.Properties.AccessibleDescription");
            this.TransactionCurrencyIdLookUpEdit.Properties.AccessibleName = resources.GetString("TransactionCurrencyIdLookUpEdit.Properties.AccessibleName");
            this.TransactionCurrencyIdLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("TransactionCurrencyIdLookUpEdit.Properties.AutoHeight")));
            this.TransactionCurrencyIdLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("TransactionCurrencyIdLookUpEdit.Properties.Buttons"))))});
            this.TransactionCurrencyIdLookUpEdit.Properties.NullText = resources.GetString("TransactionCurrencyIdLookUpEdit.Properties.NullText");
            this.TransactionCurrencyIdLookUpEdit.Properties.NullValuePrompt = resources.GetString("TransactionCurrencyIdLookUpEdit.Properties.NullValuePrompt");
            this.TransactionCurrencyIdLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("TransactionCurrencyIdLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.TransactionCurrencyIdLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // DescriptionTextEdit
            // 
            resources.ApplyResources(this.DescriptionTextEdit, "DescriptionTextEdit");
            this.DescriptionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Description", true));
            this.DescriptionTextEdit.Name = "DescriptionTextEdit";
            this.DescriptionTextEdit.Properties.AccessibleDescription = resources.GetString("DescriptionTextEdit.Properties.AccessibleDescription");
            this.DescriptionTextEdit.Properties.AccessibleName = resources.GetString("DescriptionTextEdit.Properties.AccessibleName");
            this.DescriptionTextEdit.Properties.NullValuePrompt = resources.GetString("DescriptionTextEdit.Properties.NullValuePrompt");
            this.DescriptionTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("DescriptionTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.DescriptionTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ExpiresOnTextEdit
            // 
            resources.ApplyResources(this.ExpiresOnTextEdit, "ExpiresOnTextEdit");
            this.ExpiresOnTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ExpiresOn", true));
            this.ExpiresOnTextEdit.Name = "ExpiresOnTextEdit";
            this.ExpiresOnTextEdit.Properties.AccessibleDescription = resources.GetString("ExpiresOnTextEdit.Properties.AccessibleDescription");
            this.ExpiresOnTextEdit.Properties.AccessibleName = resources.GetString("ExpiresOnTextEdit.Properties.AccessibleName");
            this.ExpiresOnTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("ExpiresOnTextEdit.Properties.AutoHeight")));
            this.ExpiresOnTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ExpiresOnTextEdit.Properties.Buttons"))))});
            this.ExpiresOnTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("ExpiresOnTextEdit.Properties.Mask.AutoComplete")));
            this.ExpiresOnTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("ExpiresOnTextEdit.Properties.Mask.BeepOnError")));
            this.ExpiresOnTextEdit.Properties.Mask.EditMask = resources.GetString("ExpiresOnTextEdit.Properties.Mask.EditMask");
            this.ExpiresOnTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("ExpiresOnTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.ExpiresOnTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("ExpiresOnTextEdit.Properties.Mask.MaskType")));
            this.ExpiresOnTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("ExpiresOnTextEdit.Properties.Mask.PlaceHolder")));
            this.ExpiresOnTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("ExpiresOnTextEdit.Properties.Mask.SaveLiteral")));
            this.ExpiresOnTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("ExpiresOnTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.ExpiresOnTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("ExpiresOnTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.ExpiresOnTextEdit.Properties.NullValuePrompt = resources.GetString("ExpiresOnTextEdit.Properties.NullValuePrompt");
            this.ExpiresOnTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("ExpiresOnTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.ExpiresOnTextEdit.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("ExpiresOnTextEdit.Properties.VistaTimeProperties.AccessibleDescription");
            this.ExpiresOnTextEdit.Properties.VistaTimeProperties.AccessibleName = resources.GetString("ExpiresOnTextEdit.Properties.VistaTimeProperties.AccessibleName");
            this.ExpiresOnTextEdit.Properties.VistaTimeProperties.AutoHeight = ((bool)(resources.GetObject("ExpiresOnTextEdit.Properties.VistaTimeProperties.AutoHeight")));
            this.ExpiresOnTextEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ExpiresOnTextEdit.Properties.VistaTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("ExpiresOnTextEdit.Properties.VistaTimeProperties.Mask.AutoComplete")));
            this.ExpiresOnTextEdit.Properties.VistaTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("ExpiresOnTextEdit.Properties.VistaTimeProperties.Mask.BeepOnError")));
            this.ExpiresOnTextEdit.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("ExpiresOnTextEdit.Properties.VistaTimeProperties.Mask.EditMask");
            this.ExpiresOnTextEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("ExpiresOnTextEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank")));
            this.ExpiresOnTextEdit.Properties.VistaTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("ExpiresOnTextEdit.Properties.VistaTimeProperties.Mask.MaskType")));
            this.ExpiresOnTextEdit.Properties.VistaTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("ExpiresOnTextEdit.Properties.VistaTimeProperties.Mask.PlaceHolder")));
            this.ExpiresOnTextEdit.Properties.VistaTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("ExpiresOnTextEdit.Properties.VistaTimeProperties.Mask.SaveLiteral")));
            this.ExpiresOnTextEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("ExpiresOnTextEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders")));
            this.ExpiresOnTextEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("ExpiresOnTextEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat")));
            this.ExpiresOnTextEdit.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("ExpiresOnTextEdit.Properties.VistaTimeProperties.NullValuePrompt");
            this.ExpiresOnTextEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("ExpiresOnTextEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue" +
        "")));
            this.ExpiresOnTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForOpportunity
            // 
            this.ItemForOpportunity.Control = this.OpportunityTextEdit;
            resources.ApplyResources(this.ItemForOpportunity, "ItemForOpportunity");
            this.ItemForOpportunity.Location = new System.Drawing.Point(0, 264);
            this.ItemForOpportunity.Name = "ItemForOpportunity";
            this.ItemForOpportunity.Size = new System.Drawing.Size(794, 24);
            this.ItemForOpportunity.TextSize = new System.Drawing.Size(132, 14);
            this.ItemForOpportunity.TextToControlDistance = 5;
            // 
            // ItemForQuoteId
            // 
            this.ItemForQuoteId.Control = this.QuoteIdTextEdit;
            resources.ApplyResources(this.ItemForQuoteId, "ItemForQuoteId");
            this.ItemForQuoteId.Location = new System.Drawing.Point(0, 24);
            this.ItemForQuoteId.Name = "ItemForQuoteId";
            this.ItemForQuoteId.Size = new System.Drawing.Size(794, 24);
            this.ItemForQuoteId.TextSize = new System.Drawing.Size(132, 14);
            this.ItemForQuoteId.TextToControlDistance = 5;
            // 
            // ItemForTransactionCurrency
            // 
            this.ItemForTransactionCurrency.Control = this.TransactionCurrencyTextEdit;
            resources.ApplyResources(this.ItemForTransactionCurrency, "ItemForTransactionCurrency");
            this.ItemForTransactionCurrency.Location = new System.Drawing.Point(0, 192);
            this.ItemForTransactionCurrency.Name = "ItemForTransactionCurrency";
            this.ItemForTransactionCurrency.Size = new System.Drawing.Size(794, 24);
            this.ItemForTransactionCurrency.TextSize = new System.Drawing.Size(132, 14);
            this.ItemForTransactionCurrency.TextToControlDistance = 5;
            // 
            // ItemForUser
            // 
            this.ItemForUser.Control = this.UserTextEdit;
            resources.ApplyResources(this.ItemForUser, "ItemForUser");
            this.ItemForUser.Location = new System.Drawing.Point(0, 216);
            this.ItemForUser.Name = "ItemForUser";
            this.ItemForUser.Size = new System.Drawing.Size(794, 24);
            this.ItemForUser.TextSize = new System.Drawing.Size(132, 14);
            this.ItemForUser.TextToControlDistance = 5;
            // 
            // ItemForVersionNumber
            // 
            this.ItemForVersionNumber.Control = this.VersionNumberPictureEdit;
            resources.ApplyResources(this.ItemForVersionNumber, "ItemForVersionNumber");
            this.ItemForVersionNumber.Location = new System.Drawing.Point(0, 216);
            this.ItemForVersionNumber.Name = "ItemForVersionNumber";
            this.ItemForVersionNumber.Size = new System.Drawing.Size(811, 38);
            this.ItemForVersionNumber.TextSize = new System.Drawing.Size(132, 14);
            this.ItemForVersionNumber.TextToControlDistance = 5;
            // 
            // ItemForAccount
            // 
            this.ItemForAccount.Control = this.AccountTextEdit;
            resources.ApplyResources(this.ItemForAccount, "ItemForAccount");
            this.ItemForAccount.Location = new System.Drawing.Point(0, 0);
            this.ItemForAccount.Name = "ItemForAccount";
            this.ItemForAccount.Size = new System.Drawing.Size(794, 24);
            this.ItemForAccount.TextSize = new System.Drawing.Size(132, 14);
            this.ItemForAccount.TextToControlDistance = 5;
            // 
            // ItemForDescription
            // 
            this.ItemForDescription.Control = this.DescriptionTextEdit;
            resources.ApplyResources(this.ItemForDescription, "ItemForDescription");
            this.ItemForDescription.Location = new System.Drawing.Point(0, 120);
            this.ItemForDescription.Name = "ItemForDescription";
            this.ItemForDescription.Size = new System.Drawing.Size(901, 66);
            this.ItemForDescription.TextSize = new System.Drawing.Size(129, 14);
            // 
            // layoutControlGroup5
            // 
            resources.ApplyResources(this.layoutControlGroup5, "layoutControlGroup5");
            this.layoutControlGroup5.ExpandButtonVisible = true;
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForTransactionCurrencyId,
            this.ItemForBillingAddress,
            this.ItemForCountry,
            this.ItemForState,
            this.ItemForPaymentTermsCode,
            this.ItemForBillTo_ContactName,
            this.ItemForPostalCode,
            this.ItemForCity,
            this.ItemForExchangeRate,
            this.ItemForDescription});
            this.layoutControlGroup5.Location = new System.Drawing.Point(0, 96);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Size = new System.Drawing.Size(925, 230);
            // 
            // ItemForTransactionCurrencyId
            // 
            this.ItemForTransactionCurrencyId.Control = this.TransactionCurrencyIdLookUpEdit;
            resources.ApplyResources(this.ItemForTransactionCurrencyId, "ItemForTransactionCurrencyId");
            this.ItemForTransactionCurrencyId.Location = new System.Drawing.Point(0, 96);
            this.ItemForTransactionCurrencyId.Name = "ItemForTransactionCurrencyId";
            this.ItemForTransactionCurrencyId.Size = new System.Drawing.Size(450, 24);
            this.ItemForTransactionCurrencyId.TextSize = new System.Drawing.Size(129, 14);
            // 
            // ItemForBillingAddress
            // 
            this.ItemForBillingAddress.Control = this.BillingAddressNameTextEdit;
            resources.ApplyResources(this.ItemForBillingAddress, "ItemForBillingAddress");
            this.ItemForBillingAddress.Location = new System.Drawing.Point(0, 0);
            this.ItemForBillingAddress.Name = "ItemForBillingAddress";
            this.ItemForBillingAddress.Size = new System.Drawing.Size(901, 24);
            this.ItemForBillingAddress.TextSize = new System.Drawing.Size(129, 14);
            // 
            // BillingAddressNameTextEdit
            // 
            resources.ApplyResources(this.BillingAddressNameTextEdit, "BillingAddressNameTextEdit");
            this.BillingAddressNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.customerAddressBindingSource, "Name", true));
            this.BillingAddressNameTextEdit.Name = "BillingAddressNameTextEdit";
            this.BillingAddressNameTextEdit.Properties.AccessibleDescription = resources.GetString("BillingAddressNameTextEdit.Properties.AccessibleDescription");
            this.BillingAddressNameTextEdit.Properties.AccessibleName = resources.GetString("BillingAddressNameTextEdit.Properties.AccessibleName");
            this.BillingAddressNameTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("BillingAddressNameTextEdit.Properties.AutoHeight")));
            this.BillingAddressNameTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("BillingAddressNameTextEdit.Properties.Mask.AutoComplete")));
            this.BillingAddressNameTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("BillingAddressNameTextEdit.Properties.Mask.BeepOnError")));
            this.BillingAddressNameTextEdit.Properties.Mask.EditMask = resources.GetString("BillingAddressNameTextEdit.Properties.Mask.EditMask");
            this.BillingAddressNameTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("BillingAddressNameTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.BillingAddressNameTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("BillingAddressNameTextEdit.Properties.Mask.MaskType")));
            this.BillingAddressNameTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("BillingAddressNameTextEdit.Properties.Mask.PlaceHolder")));
            this.BillingAddressNameTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("BillingAddressNameTextEdit.Properties.Mask.SaveLiteral")));
            this.BillingAddressNameTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("BillingAddressNameTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.BillingAddressNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("BillingAddressNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.BillingAddressNameTextEdit.Properties.NullValuePrompt = resources.GetString("BillingAddressNameTextEdit.Properties.NullValuePrompt");
            this.BillingAddressNameTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("BillingAddressNameTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.BillingAddressNameTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // customerAddressBindingSource
            // 
            this.customerAddressBindingSource.DataSource = this.EntityBindingSource;
            // 
            // ItemForCountry
            // 
            this.ItemForCountry.Control = this.CountryTextEdit;
            resources.ApplyResources(this.ItemForCountry, "ItemForCountry");
            this.ItemForCountry.Location = new System.Drawing.Point(0, 48);
            this.ItemForCountry.Name = "ItemForCountry";
            this.ItemForCountry.Size = new System.Drawing.Size(450, 24);
            this.ItemForCountry.TextSize = new System.Drawing.Size(129, 14);
            // 
            // CountryTextEdit
            // 
            resources.ApplyResources(this.CountryTextEdit, "CountryTextEdit");
            this.CountryTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.customerAddressBindingSource, "Country", true));
            this.CountryTextEdit.Name = "CountryTextEdit";
            this.CountryTextEdit.Properties.AccessibleDescription = resources.GetString("CountryTextEdit.Properties.AccessibleDescription");
            this.CountryTextEdit.Properties.AccessibleName = resources.GetString("CountryTextEdit.Properties.AccessibleName");
            this.CountryTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("CountryTextEdit.Properties.AutoHeight")));
            this.CountryTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("CountryTextEdit.Properties.Mask.AutoComplete")));
            this.CountryTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("CountryTextEdit.Properties.Mask.BeepOnError")));
            this.CountryTextEdit.Properties.Mask.EditMask = resources.GetString("CountryTextEdit.Properties.Mask.EditMask");
            this.CountryTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("CountryTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.CountryTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("CountryTextEdit.Properties.Mask.MaskType")));
            this.CountryTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("CountryTextEdit.Properties.Mask.PlaceHolder")));
            this.CountryTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("CountryTextEdit.Properties.Mask.SaveLiteral")));
            this.CountryTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("CountryTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.CountryTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("CountryTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.CountryTextEdit.Properties.NullValuePrompt = resources.GetString("CountryTextEdit.Properties.NullValuePrompt");
            this.CountryTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("CountryTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.CountryTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForState
            // 
            this.ItemForState.Control = this.StateTextEdit;
            resources.ApplyResources(this.ItemForState, "ItemForState");
            this.ItemForState.Location = new System.Drawing.Point(0, 24);
            this.ItemForState.Name = "ItemForState";
            this.ItemForState.Size = new System.Drawing.Size(450, 24);
            this.ItemForState.TextSize = new System.Drawing.Size(129, 14);
            // 
            // StateTextEdit
            // 
            resources.ApplyResources(this.StateTextEdit, "StateTextEdit");
            this.StateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.customerAddressBindingSource, "StateOrProvince", true));
            this.StateTextEdit.Name = "StateTextEdit";
            this.StateTextEdit.Properties.AccessibleDescription = resources.GetString("StateTextEdit.Properties.AccessibleDescription");
            this.StateTextEdit.Properties.AccessibleName = resources.GetString("StateTextEdit.Properties.AccessibleName");
            this.StateTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("StateTextEdit.Properties.AutoHeight")));
            this.StateTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("StateTextEdit.Properties.Mask.AutoComplete")));
            this.StateTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("StateTextEdit.Properties.Mask.BeepOnError")));
            this.StateTextEdit.Properties.Mask.EditMask = resources.GetString("StateTextEdit.Properties.Mask.EditMask");
            this.StateTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("StateTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.StateTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("StateTextEdit.Properties.Mask.MaskType")));
            this.StateTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("StateTextEdit.Properties.Mask.PlaceHolder")));
            this.StateTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("StateTextEdit.Properties.Mask.SaveLiteral")));
            this.StateTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("StateTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.StateTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("StateTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.StateTextEdit.Properties.NullValuePrompt = resources.GetString("StateTextEdit.Properties.NullValuePrompt");
            this.StateTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("StateTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.StateTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForPaymentTermsCode
            // 
            this.ItemForPaymentTermsCode.Control = this.PaymentTermsCodeLookUpEdit;
            resources.ApplyResources(this.ItemForPaymentTermsCode, "ItemForPaymentTermsCode");
            this.ItemForPaymentTermsCode.Location = new System.Drawing.Point(450, 72);
            this.ItemForPaymentTermsCode.Name = "ItemForPaymentTermsCode";
            this.ItemForPaymentTermsCode.Size = new System.Drawing.Size(451, 24);
            this.ItemForPaymentTermsCode.TextSize = new System.Drawing.Size(129, 14);
            // 
            // ItemForBillTo_ContactName
            // 
            this.ItemForBillTo_ContactName.Control = this.BillTo_ContactNameTextEdit;
            resources.ApplyResources(this.ItemForBillTo_ContactName, "ItemForBillTo_ContactName");
            this.ItemForBillTo_ContactName.Location = new System.Drawing.Point(0, 72);
            this.ItemForBillTo_ContactName.Name = "ItemForBillTo_ContactName";
            this.ItemForBillTo_ContactName.Size = new System.Drawing.Size(450, 24);
            this.ItemForBillTo_ContactName.TextSize = new System.Drawing.Size(129, 14);
            // 
            // ItemForPostalCode
            // 
            this.ItemForPostalCode.Control = this.PostalCodeTextEdit;
            resources.ApplyResources(this.ItemForPostalCode, "ItemForPostalCode");
            this.ItemForPostalCode.Location = new System.Drawing.Point(450, 48);
            this.ItemForPostalCode.Name = "ItemForPostalCode";
            this.ItemForPostalCode.Size = new System.Drawing.Size(451, 24);
            this.ItemForPostalCode.TextSize = new System.Drawing.Size(129, 14);
            // 
            // PostalCodeTextEdit
            // 
            resources.ApplyResources(this.PostalCodeTextEdit, "PostalCodeTextEdit");
            this.PostalCodeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.customerAddressBindingSource, "PostalCode", true));
            this.PostalCodeTextEdit.Name = "PostalCodeTextEdit";
            this.PostalCodeTextEdit.Properties.AccessibleDescription = resources.GetString("PostalCodeTextEdit.Properties.AccessibleDescription");
            this.PostalCodeTextEdit.Properties.AccessibleName = resources.GetString("PostalCodeTextEdit.Properties.AccessibleName");
            this.PostalCodeTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("PostalCodeTextEdit.Properties.AutoHeight")));
            this.PostalCodeTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("PostalCodeTextEdit.Properties.Mask.AutoComplete")));
            this.PostalCodeTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("PostalCodeTextEdit.Properties.Mask.BeepOnError")));
            this.PostalCodeTextEdit.Properties.Mask.EditMask = resources.GetString("PostalCodeTextEdit.Properties.Mask.EditMask");
            this.PostalCodeTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("PostalCodeTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.PostalCodeTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("PostalCodeTextEdit.Properties.Mask.MaskType")));
            this.PostalCodeTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("PostalCodeTextEdit.Properties.Mask.PlaceHolder")));
            this.PostalCodeTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("PostalCodeTextEdit.Properties.Mask.SaveLiteral")));
            this.PostalCodeTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("PostalCodeTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.PostalCodeTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("PostalCodeTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.PostalCodeTextEdit.Properties.NullValuePrompt = resources.GetString("PostalCodeTextEdit.Properties.NullValuePrompt");
            this.PostalCodeTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("PostalCodeTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.PostalCodeTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForCity
            // 
            this.ItemForCity.Control = this.CityTextEdit;
            resources.ApplyResources(this.ItemForCity, "ItemForCity");
            this.ItemForCity.Location = new System.Drawing.Point(450, 24);
            this.ItemForCity.Name = "ItemForCity";
            this.ItemForCity.Size = new System.Drawing.Size(451, 24);
            this.ItemForCity.TextSize = new System.Drawing.Size(129, 14);
            // 
            // CityTextEdit
            // 
            resources.ApplyResources(this.CityTextEdit, "CityTextEdit");
            this.CityTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.customerAddressBindingSource, "City", true));
            this.CityTextEdit.Name = "CityTextEdit";
            this.CityTextEdit.Properties.AccessibleDescription = resources.GetString("CityTextEdit.Properties.AccessibleDescription");
            this.CityTextEdit.Properties.AccessibleName = resources.GetString("CityTextEdit.Properties.AccessibleName");
            this.CityTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("CityTextEdit.Properties.AutoHeight")));
            this.CityTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("CityTextEdit.Properties.Mask.AutoComplete")));
            this.CityTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("CityTextEdit.Properties.Mask.BeepOnError")));
            this.CityTextEdit.Properties.Mask.EditMask = resources.GetString("CityTextEdit.Properties.Mask.EditMask");
            this.CityTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("CityTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.CityTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("CityTextEdit.Properties.Mask.MaskType")));
            this.CityTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("CityTextEdit.Properties.Mask.PlaceHolder")));
            this.CityTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("CityTextEdit.Properties.Mask.SaveLiteral")));
            this.CityTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("CityTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.CityTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("CityTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.CityTextEdit.Properties.NullValuePrompt = resources.GetString("CityTextEdit.Properties.NullValuePrompt");
            this.CityTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("CityTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.CityTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForExchangeRate
            // 
            this.ItemForExchangeRate.Control = this.ExchangeRateTextEdit;
            resources.ApplyResources(this.ItemForExchangeRate, "ItemForExchangeRate");
            this.ItemForExchangeRate.Location = new System.Drawing.Point(450, 96);
            this.ItemForExchangeRate.Name = "ItemForExchangeRate";
            this.ItemForExchangeRate.Size = new System.Drawing.Size(451, 24);
            this.ItemForExchangeRate.TextSize = new System.Drawing.Size(129, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem1, "emptySpaceItem1");
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(925, 254);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // tabbedControlGroup1
            // 
            resources.ApplyResources(this.tabbedControlGroup1, "tabbedControlGroup1");
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.LineItemLayoutControlGroup;
            this.tabbedControlGroup1.SelectedTabPageIndex = 1;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(949, 373);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup4,
            this.LineItemLayoutControlGroup,
            this.managementLayoutControlGroup});
            // 
            // LineItemLayoutControlGroup
            // 
            resources.ApplyResources(this.LineItemLayoutControlGroup, "LineItemLayoutControlGroup");
            this.LineItemLayoutControlGroup.ExpandButtonVisible = true;
            this.LineItemLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ProductLayoutControlItem,
            this.ItemForNewLineItem,
            this.ItemForRemoveLine,
            this.emptySpaceItem6,
            this.emptySpaceItem8,
            this.ItemForTotalLineItemAmount,
            this.ItemForTotalDiscountAmount,
            this.ItemForTotalTax,
            this.ItemForTotalAmount});
            this.LineItemLayoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.LineItemLayoutControlGroup.Name = "LineItemLayoutControlGroup";
            this.LineItemLayoutControlGroup.Size = new System.Drawing.Size(925, 326);
            // 
            // ProductLayoutControlItem
            // 
            this.ProductLayoutControlItem.Control = this.quoteLineItemGridControl;
            resources.ApplyResources(this.ProductLayoutControlItem, "ProductLayoutControlItem");
            this.ProductLayoutControlItem.Location = new System.Drawing.Point(0, 0);
            this.ProductLayoutControlItem.Name = "ProductLayoutControlItem";
            this.ProductLayoutControlItem.Size = new System.Drawing.Size(925, 204);
            this.ProductLayoutControlItem.TextSize = new System.Drawing.Size(0, 0);
            this.ProductLayoutControlItem.TextToControlDistance = 0;
            this.ProductLayoutControlItem.TextVisible = false;
            // 
            // ItemForNewLineItem
            // 
            this.ItemForNewLineItem.Control = this.btnNew;
            resources.ApplyResources(this.ItemForNewLineItem, "ItemForNewLineItem");
            this.ItemForNewLineItem.Location = new System.Drawing.Point(729, 204);
            this.ItemForNewLineItem.Name = "ItemForNewLineItem";
            this.ItemForNewLineItem.Size = new System.Drawing.Size(95, 26);
            this.ItemForNewLineItem.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForNewLineItem.TextToControlDistance = 0;
            this.ItemForNewLineItem.TextVisible = false;
            // 
            // ItemForRemoveLine
            // 
            this.ItemForRemoveLine.Control = this.btnRemove;
            this.ItemForRemoveLine.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            resources.ApplyResources(this.ItemForRemoveLine, "ItemForRemoveLine");
            this.ItemForRemoveLine.Location = new System.Drawing.Point(830, 204);
            this.ItemForRemoveLine.MinSize = new System.Drawing.Size(54, 26);
            this.ItemForRemoveLine.Name = "ItemForRemoveLine";
            this.ItemForRemoveLine.Size = new System.Drawing.Size(95, 26);
            this.ItemForRemoveLine.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForRemoveLine.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForRemoveLine.TextToControlDistance = 0;
            this.ItemForRemoveLine.TextVisible = false;
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem6, "emptySpaceItem6");
            this.emptySpaceItem6.Location = new System.Drawing.Point(0, 204);
            this.emptySpaceItem6.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(729, 26);
            this.emptySpaceItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem8, "emptySpaceItem8");
            this.emptySpaceItem8.Location = new System.Drawing.Point(824, 204);
            this.emptySpaceItem8.MinSize = new System.Drawing.Size(5, 24);
            this.emptySpaceItem8.Name = "emptySpaceItem8";
            this.emptySpaceItem8.Size = new System.Drawing.Size(6, 26);
            this.emptySpaceItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ItemForTotalLineItemAmount
            // 
            this.ItemForTotalLineItemAmount.Control = this.TotalLineItemAmountTextEdit;
            resources.ApplyResources(this.ItemForTotalLineItemAmount, "ItemForTotalLineItemAmount");
            this.ItemForTotalLineItemAmount.Location = new System.Drawing.Point(0, 230);
            this.ItemForTotalLineItemAmount.Name = "ItemForTotalLineItemAmount";
            this.ItemForTotalLineItemAmount.Size = new System.Drawing.Size(925, 24);
            this.ItemForTotalLineItemAmount.TextSize = new System.Drawing.Size(129, 14);
            // 
            // ItemForTotalDiscountAmount
            // 
            this.ItemForTotalDiscountAmount.Control = this.TotalDiscountAmountTextEdit;
            resources.ApplyResources(this.ItemForTotalDiscountAmount, "ItemForTotalDiscountAmount");
            this.ItemForTotalDiscountAmount.Location = new System.Drawing.Point(0, 254);
            this.ItemForTotalDiscountAmount.Name = "ItemForTotalDiscountAmount";
            this.ItemForTotalDiscountAmount.Size = new System.Drawing.Size(925, 24);
            this.ItemForTotalDiscountAmount.TextSize = new System.Drawing.Size(129, 14);
            // 
            // ItemForTotalTax
            // 
            this.ItemForTotalTax.Control = this.TotalTaxTextEdit;
            resources.ApplyResources(this.ItemForTotalTax, "ItemForTotalTax");
            this.ItemForTotalTax.Location = new System.Drawing.Point(0, 278);
            this.ItemForTotalTax.Name = "ItemForTotalTax";
            this.ItemForTotalTax.Size = new System.Drawing.Size(925, 24);
            this.ItemForTotalTax.TextSize = new System.Drawing.Size(129, 14);
            // 
            // ItemForTotalAmount
            // 
            this.ItemForTotalAmount.Control = this.TotalAmountTextEdit;
            resources.ApplyResources(this.ItemForTotalAmount, "ItemForTotalAmount");
            this.ItemForTotalAmount.Location = new System.Drawing.Point(0, 302);
            this.ItemForTotalAmount.Name = "ItemForTotalAmount";
            this.ItemForTotalAmount.Size = new System.Drawing.Size(925, 24);
            this.ItemForTotalAmount.TextSize = new System.Drawing.Size(129, 14);
            // 
            // layoutControlGroup4
            // 
            resources.ApplyResources(this.layoutControlGroup4, "layoutControlGroup4");
            this.layoutControlGroup4.ExpandButtonVisible = true;
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForName,
            this.ItemForCustomerId,
            this.ItemForExpiresOn,
            this.layoutControlGroup5,
            this.ItemForStatusCode,
            this.ItemForStageCode,
            this.ItemForOpportunityId,
            this.ItemForQuoteNumber});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(925, 326);
            // 
            // ItemForName
            // 
            this.ItemForName.Control = this.NameTextEdit;
            resources.ApplyResources(this.ItemForName, "ItemForName");
            this.ItemForName.Location = new System.Drawing.Point(0, 0);
            this.ItemForName.Name = "ItemForName";
            this.ItemForName.Size = new System.Drawing.Size(925, 24);
            this.ItemForName.TextSize = new System.Drawing.Size(129, 14);
            // 
            // ItemForCustomerId
            // 
            this.ItemForCustomerId.Control = this.CustomerIdSearchLookUpEdit;
            resources.ApplyResources(this.ItemForCustomerId, "ItemForCustomerId");
            this.ItemForCustomerId.Location = new System.Drawing.Point(462, 24);
            this.ItemForCustomerId.Name = "ItemForCustomerId";
            this.ItemForCustomerId.Size = new System.Drawing.Size(463, 24);
            this.ItemForCustomerId.TextSize = new System.Drawing.Size(129, 14);
            // 
            // CustomerIdSearchLookUpEdit
            // 
            resources.ApplyResources(this.CustomerIdSearchLookUpEdit, "CustomerIdSearchLookUpEdit");
            this.CustomerIdSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "CustomerId", true));
            this.CustomerIdSearchLookUpEdit.Name = "CustomerIdSearchLookUpEdit";
            this.CustomerIdSearchLookUpEdit.Properties.AccessibleDescription = resources.GetString("CustomerIdSearchLookUpEdit.Properties.AccessibleDescription");
            this.CustomerIdSearchLookUpEdit.Properties.AccessibleName = resources.GetString("CustomerIdSearchLookUpEdit.Properties.AccessibleName");
            this.CustomerIdSearchLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("CustomerIdSearchLookUpEdit.Properties.AutoHeight")));
            this.CustomerIdSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("CustomerIdSearchLookUpEdit.Properties.Buttons"))))});
            this.CustomerIdSearchLookUpEdit.Properties.NullValuePrompt = resources.GetString("CustomerIdSearchLookUpEdit.Properties.NullValuePrompt");
            this.CustomerIdSearchLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("CustomerIdSearchLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.CustomerIdSearchLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForExpiresOn
            // 
            this.ItemForExpiresOn.Control = this.ExpiresOnTextEdit;
            resources.ApplyResources(this.ItemForExpiresOn, "ItemForExpiresOn");
            this.ItemForExpiresOn.Location = new System.Drawing.Point(462, 48);
            this.ItemForExpiresOn.Name = "ItemForExpiresOn";
            this.ItemForExpiresOn.Size = new System.Drawing.Size(463, 24);
            this.ItemForExpiresOn.TextSize = new System.Drawing.Size(129, 14);
            // 
            // ItemForStatusCode
            // 
            this.ItemForStatusCode.Control = this.StatusCodeLookUpEdit;
            resources.ApplyResources(this.ItemForStatusCode, "ItemForStatusCode");
            this.ItemForStatusCode.Location = new System.Drawing.Point(462, 72);
            this.ItemForStatusCode.Name = "ItemForStatusCode";
            this.ItemForStatusCode.Size = new System.Drawing.Size(463, 24);
            this.ItemForStatusCode.TextSize = new System.Drawing.Size(129, 14);
            this.ItemForStatusCode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // ItemForStageCode
            // 
            this.ItemForStageCode.Control = this.StageCodeLookUpEdit;
            resources.ApplyResources(this.ItemForStageCode, "ItemForStageCode");
            this.ItemForStageCode.Location = new System.Drawing.Point(0, 72);
            this.ItemForStageCode.Name = "ItemForStageCode";
            this.ItemForStageCode.Size = new System.Drawing.Size(462, 24);
            this.ItemForStageCode.TextSize = new System.Drawing.Size(129, 14);
            // 
            // ItemForOpportunityId
            // 
            this.ItemForOpportunityId.Control = this.OpportunityIdSearchLookUpEdit;
            resources.ApplyResources(this.ItemForOpportunityId, "ItemForOpportunityId");
            this.ItemForOpportunityId.Location = new System.Drawing.Point(0, 48);
            this.ItemForOpportunityId.Name = "ItemForOpportunityId";
            this.ItemForOpportunityId.Size = new System.Drawing.Size(462, 24);
            this.ItemForOpportunityId.TextSize = new System.Drawing.Size(129, 14);
            // 
            // OpportunityIdSearchLookUpEdit
            // 
            resources.ApplyResources(this.OpportunityIdSearchLookUpEdit, "OpportunityIdSearchLookUpEdit");
            this.OpportunityIdSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "OpportunityId", true));
            this.OpportunityIdSearchLookUpEdit.Name = "OpportunityIdSearchLookUpEdit";
            this.OpportunityIdSearchLookUpEdit.Properties.AccessibleDescription = resources.GetString("OpportunityIdSearchLookUpEdit.Properties.AccessibleDescription");
            this.OpportunityIdSearchLookUpEdit.Properties.AccessibleName = resources.GetString("OpportunityIdSearchLookUpEdit.Properties.AccessibleName");
            this.OpportunityIdSearchLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("OpportunityIdSearchLookUpEdit.Properties.AutoHeight")));
            this.OpportunityIdSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("OpportunityIdSearchLookUpEdit.Properties.Buttons"))))});
            this.OpportunityIdSearchLookUpEdit.Properties.NullValuePrompt = resources.GetString("OpportunityIdSearchLookUpEdit.Properties.NullValuePrompt");
            this.OpportunityIdSearchLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("OpportunityIdSearchLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.OpportunityIdSearchLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForQuoteNumber
            // 
            this.ItemForQuoteNumber.Control = this.QuoteNumberTextEdit;
            resources.ApplyResources(this.ItemForQuoteNumber, "ItemForQuoteNumber");
            this.ItemForQuoteNumber.Location = new System.Drawing.Point(0, 24);
            this.ItemForQuoteNumber.Name = "ItemForQuoteNumber";
            this.ItemForQuoteNumber.Size = new System.Drawing.Size(462, 24);
            this.ItemForQuoteNumber.TextSize = new System.Drawing.Size(129, 14);
            // 
            // managementLayoutControlGroup
            // 
            resources.ApplyResources(this.managementLayoutControlGroup, "managementLayoutControlGroup");
            this.managementLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.ItemForOwnerId,
            this.emptySpaceItem3,
            this.ItemForCreatedOn,
            this.ItemForCreateBy,
            this.ItemForModifiedOn,
            this.ItemForModifiedBy});
            this.managementLayoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.managementLayoutControlGroup.Name = "managementLayoutControlGroup";
            this.managementLayoutControlGroup.Size = new System.Drawing.Size(925, 326);
            // 
            // ItemForOwnerId
            // 
            this.ItemForOwnerId.Control = this.OwnerIdSearchLookUpEdit;
            resources.ApplyResources(this.ItemForOwnerId, "ItemForOwnerId");
            this.ItemForOwnerId.Location = new System.Drawing.Point(0, 0);
            this.ItemForOwnerId.Name = "ItemForOwnerId";
            this.ItemForOwnerId.Size = new System.Drawing.Size(462, 24);
            this.ItemForOwnerId.TextSize = new System.Drawing.Size(129, 14);
            // 
            // OwnerIdSearchLookUpEdit
            // 
            resources.ApplyResources(this.OwnerIdSearchLookUpEdit, "OwnerIdSearchLookUpEdit");
            this.OwnerIdSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "OwnerId", true));
            this.OwnerIdSearchLookUpEdit.Name = "OwnerIdSearchLookUpEdit";
            this.OwnerIdSearchLookUpEdit.Properties.AccessibleDescription = resources.GetString("OwnerIdSearchLookUpEdit.Properties.AccessibleDescription");
            this.OwnerIdSearchLookUpEdit.Properties.AccessibleName = resources.GetString("OwnerIdSearchLookUpEdit.Properties.AccessibleName");
            this.OwnerIdSearchLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("OwnerIdSearchLookUpEdit.Properties.AutoHeight")));
            this.OwnerIdSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("OwnerIdSearchLookUpEdit.Properties.Buttons"))))});
            this.OwnerIdSearchLookUpEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("OwnerIdSearchLookUpEdit.Properties.Mask.AutoComplete")));
            this.OwnerIdSearchLookUpEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("OwnerIdSearchLookUpEdit.Properties.Mask.BeepOnError")));
            this.OwnerIdSearchLookUpEdit.Properties.Mask.EditMask = resources.GetString("OwnerIdSearchLookUpEdit.Properties.Mask.EditMask");
            this.OwnerIdSearchLookUpEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("OwnerIdSearchLookUpEdit.Properties.Mask.IgnoreMaskBlank")));
            this.OwnerIdSearchLookUpEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("OwnerIdSearchLookUpEdit.Properties.Mask.MaskType")));
            this.OwnerIdSearchLookUpEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("OwnerIdSearchLookUpEdit.Properties.Mask.PlaceHolder")));
            this.OwnerIdSearchLookUpEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("OwnerIdSearchLookUpEdit.Properties.Mask.SaveLiteral")));
            this.OwnerIdSearchLookUpEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("OwnerIdSearchLookUpEdit.Properties.Mask.ShowPlaceHolders")));
            this.OwnerIdSearchLookUpEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("OwnerIdSearchLookUpEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.OwnerIdSearchLookUpEdit.Properties.NullValuePrompt = resources.GetString("OwnerIdSearchLookUpEdit.Properties.NullValuePrompt");
            this.OwnerIdSearchLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("OwnerIdSearchLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.OwnerIdSearchLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem3, "emptySpaceItem3");
            this.emptySpaceItem3.Location = new System.Drawing.Point(462, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(463, 24);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ItemForCreatedOn
            // 
            this.ItemForCreatedOn.Control = this.textEdit1;
            resources.ApplyResources(this.ItemForCreatedOn, "ItemForCreatedOn");
            this.ItemForCreatedOn.Location = new System.Drawing.Point(0, 24);
            this.ItemForCreatedOn.Name = "ItemForCreatedOn";
            this.ItemForCreatedOn.Size = new System.Drawing.Size(462, 24);
            this.ItemForCreatedOn.TextSize = new System.Drawing.Size(129, 14);
            // 
            // textEdit1
            // 
            resources.ApplyResources(this.textEdit1, "textEdit1");
            this.textEdit1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "CreatedOn", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.AccessibleDescription = resources.GetString("textEdit1.Properties.AccessibleDescription");
            this.textEdit1.Properties.AccessibleName = resources.GetString("textEdit1.Properties.AccessibleName");
            this.textEdit1.Properties.AutoHeight = ((bool)(resources.GetObject("textEdit1.Properties.AutoHeight")));
            this.textEdit1.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("textEdit1.Properties.Mask.AutoComplete")));
            this.textEdit1.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("textEdit1.Properties.Mask.BeepOnError")));
            this.textEdit1.Properties.Mask.EditMask = resources.GetString("textEdit1.Properties.Mask.EditMask");
            this.textEdit1.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("textEdit1.Properties.Mask.IgnoreMaskBlank")));
            this.textEdit1.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("textEdit1.Properties.Mask.MaskType")));
            this.textEdit1.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("textEdit1.Properties.Mask.PlaceHolder")));
            this.textEdit1.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("textEdit1.Properties.Mask.SaveLiteral")));
            this.textEdit1.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("textEdit1.Properties.Mask.ShowPlaceHolders")));
            this.textEdit1.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("textEdit1.Properties.Mask.UseMaskAsDisplayFormat")));
            this.textEdit1.Properties.NullValuePrompt = resources.GetString("textEdit1.Properties.NullValuePrompt");
            this.textEdit1.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("textEdit1.Properties.NullValuePromptShowForEmptyValue")));
            this.textEdit1.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForCreateBy
            // 
            this.ItemForCreateBy.Control = this.textEdit2;
            resources.ApplyResources(this.ItemForCreateBy, "ItemForCreateBy");
            this.ItemForCreateBy.Location = new System.Drawing.Point(462, 24);
            this.ItemForCreateBy.Name = "ItemForCreateBy";
            this.ItemForCreateBy.Size = new System.Drawing.Size(463, 24);
            this.ItemForCreateBy.TextSize = new System.Drawing.Size(129, 14);
            // 
            // textEdit2
            // 
            resources.ApplyResources(this.textEdit2, "textEdit2");
            this.textEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "CreatedBy.FullName", true));
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.AccessibleDescription = resources.GetString("textEdit2.Properties.AccessibleDescription");
            this.textEdit2.Properties.AccessibleName = resources.GetString("textEdit2.Properties.AccessibleName");
            this.textEdit2.Properties.AutoHeight = ((bool)(resources.GetObject("textEdit2.Properties.AutoHeight")));
            this.textEdit2.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("textEdit2.Properties.Mask.AutoComplete")));
            this.textEdit2.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("textEdit2.Properties.Mask.BeepOnError")));
            this.textEdit2.Properties.Mask.EditMask = resources.GetString("textEdit2.Properties.Mask.EditMask");
            this.textEdit2.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("textEdit2.Properties.Mask.IgnoreMaskBlank")));
            this.textEdit2.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("textEdit2.Properties.Mask.MaskType")));
            this.textEdit2.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("textEdit2.Properties.Mask.PlaceHolder")));
            this.textEdit2.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("textEdit2.Properties.Mask.SaveLiteral")));
            this.textEdit2.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("textEdit2.Properties.Mask.ShowPlaceHolders")));
            this.textEdit2.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("textEdit2.Properties.Mask.UseMaskAsDisplayFormat")));
            this.textEdit2.Properties.NullValuePrompt = resources.GetString("textEdit2.Properties.NullValuePrompt");
            this.textEdit2.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("textEdit2.Properties.NullValuePromptShowForEmptyValue")));
            this.textEdit2.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForModifiedOn
            // 
            this.ItemForModifiedOn.Control = this.textEdit3;
            resources.ApplyResources(this.ItemForModifiedOn, "ItemForModifiedOn");
            this.ItemForModifiedOn.Location = new System.Drawing.Point(0, 48);
            this.ItemForModifiedOn.Name = "ItemForModifiedOn";
            this.ItemForModifiedOn.Size = new System.Drawing.Size(462, 24);
            this.ItemForModifiedOn.TextSize = new System.Drawing.Size(129, 14);
            // 
            // textEdit3
            // 
            resources.ApplyResources(this.textEdit3, "textEdit3");
            this.textEdit3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "ModifiedOn", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Properties.AccessibleDescription = resources.GetString("textEdit3.Properties.AccessibleDescription");
            this.textEdit3.Properties.AccessibleName = resources.GetString("textEdit3.Properties.AccessibleName");
            this.textEdit3.Properties.AutoHeight = ((bool)(resources.GetObject("textEdit3.Properties.AutoHeight")));
            this.textEdit3.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("textEdit3.Properties.Mask.AutoComplete")));
            this.textEdit3.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("textEdit3.Properties.Mask.BeepOnError")));
            this.textEdit3.Properties.Mask.EditMask = resources.GetString("textEdit3.Properties.Mask.EditMask");
            this.textEdit3.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("textEdit3.Properties.Mask.IgnoreMaskBlank")));
            this.textEdit3.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("textEdit3.Properties.Mask.MaskType")));
            this.textEdit3.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("textEdit3.Properties.Mask.PlaceHolder")));
            this.textEdit3.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("textEdit3.Properties.Mask.SaveLiteral")));
            this.textEdit3.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("textEdit3.Properties.Mask.ShowPlaceHolders")));
            this.textEdit3.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("textEdit3.Properties.Mask.UseMaskAsDisplayFormat")));
            this.textEdit3.Properties.NullValuePrompt = resources.GetString("textEdit3.Properties.NullValuePrompt");
            this.textEdit3.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("textEdit3.Properties.NullValuePromptShowForEmptyValue")));
            this.textEdit3.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForModifiedBy
            // 
            this.ItemForModifiedBy.Control = this.textEdit4;
            resources.ApplyResources(this.ItemForModifiedBy, "ItemForModifiedBy");
            this.ItemForModifiedBy.Location = new System.Drawing.Point(462, 48);
            this.ItemForModifiedBy.Name = "ItemForModifiedBy";
            this.ItemForModifiedBy.Size = new System.Drawing.Size(463, 24);
            this.ItemForModifiedBy.TextSize = new System.Drawing.Size(129, 14);
            // 
            // textEdit4
            // 
            resources.ApplyResources(this.textEdit4, "textEdit4");
            this.textEdit4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ModifiedBy.FullName", true));
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Properties.AccessibleDescription = resources.GetString("textEdit4.Properties.AccessibleDescription");
            this.textEdit4.Properties.AccessibleName = resources.GetString("textEdit4.Properties.AccessibleName");
            this.textEdit4.Properties.AutoHeight = ((bool)(resources.GetObject("textEdit4.Properties.AutoHeight")));
            this.textEdit4.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("textEdit4.Properties.Mask.AutoComplete")));
            this.textEdit4.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("textEdit4.Properties.Mask.BeepOnError")));
            this.textEdit4.Properties.Mask.EditMask = resources.GetString("textEdit4.Properties.Mask.EditMask");
            this.textEdit4.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("textEdit4.Properties.Mask.IgnoreMaskBlank")));
            this.textEdit4.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("textEdit4.Properties.Mask.MaskType")));
            this.textEdit4.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("textEdit4.Properties.Mask.PlaceHolder")));
            this.textEdit4.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("textEdit4.Properties.Mask.SaveLiteral")));
            this.textEdit4.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("textEdit4.Properties.Mask.ShowPlaceHolders")));
            this.textEdit4.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("textEdit4.Properties.Mask.UseMaskAsDisplayFormat")));
            this.textEdit4.Properties.NullValuePrompt = resources.GetString("textEdit4.Properties.NullValuePrompt");
            this.textEdit4.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("textEdit4.Properties.NullValuePromptShowForEmptyValue")));
            this.textEdit4.StyleController = this.EntityDataLayoutControl;
            // 
            // searchLookUpEdit1View
            // 
            resources.ApplyResources(this.searchLookUpEdit1View, "searchLookUpEdit1View");
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsLayout.LayoutVersion = "0.0.0.1";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridView2
            // 
            resources.ApplyResources(this.gridView2, "gridView2");
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsLayout.LayoutVersion = "0.0.0.1";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // QuoteDetailView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "QuoteDetailView";
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).EndInit();
            this.EntityDataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quoteLineItemGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quoteLineItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quoteLineItemGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillTo_ContactNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExchangeRateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpportunityTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuoteIdTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuoteNumberTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalAmountTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDiscountAmountTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalLineItemAmountTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalTaxTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionCurrencyTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VersionNumberPictureEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StageCodeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusCodeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentTermsCodeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionCurrencyIdLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpiresOnTextEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpiresOnTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOpportunity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForQuoteId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTransactionCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForVersionNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTransactionCurrencyId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBillingAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillingAddressNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerAddressBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountryTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPaymentTermsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBillTo_ContactName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPostalCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PostalCodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CityTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForExchangeRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineItemLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductLayoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNewLineItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRemoveLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTotalLineItemAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTotalDiscountAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTotalTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTotalAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCustomerId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerIdSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForExpiresOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStageCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOpportunityId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpportunityIdSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForQuoteNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.managementLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOwnerId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OwnerIdSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreateBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit AccountTextEdit;

        private DevExpress.XtraEditors.TextEdit BillTo_ContactNameTextEdit;
        private DevExpress.XtraEditors.TextEdit ExchangeRateTextEdit;
        private DevExpress.XtraEditors.TextEdit NameTextEdit;
        private DevExpress.XtraEditors.TextEdit OpportunityTextEdit;
        private DevExpress.XtraEditors.TextEdit QuoteIdTextEdit;
        private DevExpress.XtraEditors.TextEdit QuoteNumberTextEdit;
        private DevExpress.XtraEditors.TextEdit TotalAmountTextEdit;
        private DevExpress.XtraEditors.TextEdit TotalDiscountAmountTextEdit;
        private DevExpress.XtraEditors.TextEdit TotalLineItemAmountTextEdit;
        private DevExpress.XtraEditors.TextEdit TotalTaxTextEdit;
        private DevExpress.XtraEditors.TextEdit TransactionCurrencyTextEdit;
        private DevExpress.XtraEditors.TextEdit UserTextEdit;
        private DevExpress.XtraEditors.PictureEdit VersionNumberPictureEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAccount;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOpportunity;
        private DevExpress.XtraLayout.LayoutControlItem ItemForQuoteId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTransactionCurrency;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUser;
        private DevExpress.XtraLayout.LayoutControlItem ItemForVersionNumber;
        private DevExpress.XtraEditors.LookUpEdit StageCodeLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit StatusCodeLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit PaymentTermsCodeLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit TransactionCurrencyIdLookUpEdit;
        private DevExpress.XtraEditors.MemoEdit DescriptionTextEdit;
        private Katrin.AppFramework.WinForms.Controls.DropDownDateEdit ExpiresOnTextEdit;
        private DevExpress.XtraGrid.GridControl quoteLineItemGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView quoteLineItemGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colProduct;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lkpProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalPrice;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private System.Windows.Forms.BindingSource quoteLineItemsBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit seQuantity;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPaymentTermsCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForBillTo_ContactName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForExchangeRate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTransactionCurrencyId;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit BillingAddressNameTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForBillingAddress;
        private System.Windows.Forms.BindingSource customerAddressBindingSource;
        private DevExpress.XtraEditors.TextEdit PostalCodeTextEdit;
        private DevExpress.XtraEditors.TextEdit StateTextEdit;
        private DevExpress.XtraEditors.TextEdit CountryTextEdit;
        private DevExpress.XtraEditors.TextEdit CityTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCity;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCountry;
        private DevExpress.XtraLayout.LayoutControlItem ItemForState;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPostalCode;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem ItemForName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCustomerId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOpportunityId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForExpiresOn;
        private DevExpress.XtraLayout.LayoutControlItem ItemForQuoteNumber;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStageCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStatusCode;
        private DevExpress.XtraLayout.LayoutControlGroup managementLayoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOwnerId;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlGroup LineItemLayoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlItem ProductLayoutControlItem;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNewLineItem;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRemoveLine;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTotalLineItemAmount;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTotalDiscountAmount;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTotalTax;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTotalAmount;
        private DevExpress.XtraEditors.SearchLookUpEdit CustomerIdSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.SearchLookUpEdit OpportunityIdSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit sePrice;
        private DevExpress.XtraEditors.TextEdit textEdit4;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreatedOn;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreateBy;
        private DevExpress.XtraLayout.LayoutControlItem ItemForModifiedOn;
        private DevExpress.XtraLayout.LayoutControlItem ItemForModifiedBy;
        private DevExpress.XtraEditors.PopupContainerEdit OwnerIdSearchLookUpEdit;
    }
}
