using System;
using Katrin.AppFramework.WinForms.Controls;
using Katrin.Win.Common.Controls;
namespace Katrin.Win.InvoiceModule
{
    partial class InvoiceDetailView
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
            Katrin.Win.Common.Controls.GridCheckMarksSelection gridCheckMarksSelection1 = new Katrin.Win.Common.Controls.GridCheckMarksSelection();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceDetailView));
            this.ExchangeRateTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.InvoiceIdTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.InvoiceNumberTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.NameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.PaidAmountTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.TotalAmountTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.TransactionCurrencyTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.UserTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.VersionNumberPictureEdit = new DevExpress.XtraEditors.PictureEdit();
            this.DateDeliveredTextEdit = new Katrin.AppFramework.WinForms.Controls.DropDownDateEdit();
            this.ReceivedDateTextEdit = new Katrin.AppFramework.WinForms.Controls.DropDownDateEdit();
            this.TransactionCurrencyIdLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.StatusCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.DescriptionTextEdit = new DevExpress.XtraEditors.MemoEdit();
            this.ItemForTransactionCurrency = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForUser = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForVersionNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForInvoiceId = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForInvoiceNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForOwnerId = new DevExpress.XtraLayout.LayoutControlItem();
            this.OwnerIdLookUpEdit = new DevExpress.XtraEditors.PopupContainerEdit();
            this.ItemForPaidAmount = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTransactionCurrencyId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForReceivedDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTotalAmount = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDateDelivered = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForExchangeRate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForStatusCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.BillingCustomerIdSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.ItemForContracts = new DevExpress.XtraLayout.LayoutControlItem();
            this.contractGridLookUpEdit = new Katrin.Win.Common.Controls.MyGridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.managementGeneratedGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ItemForCreatedOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.ItemForCreatedBy = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.ItemForModifiedOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.ItemForModifiedBy = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
            this.gridViewCustomer = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).BeginInit();
            this.EntityDataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExchangeRateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceIdTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceNumberTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaidAmountTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalAmountTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionCurrencyTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VersionNumberPictureEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDeliveredTextEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDeliveredTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedDateTextEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedDateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionCurrencyIdLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusCodeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTransactionCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForVersionNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForInvoiceId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForInvoiceNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOwnerId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OwnerIdLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPaidAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTransactionCurrencyId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForReceivedDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTotalAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDateDelivered)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForExchangeRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillingCustomerIdSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForContracts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractGridLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.managementGeneratedGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // EntityDataLayoutControl
            // 
            this.EntityDataLayoutControl.Controls.Add(this.textEdit4);
            this.EntityDataLayoutControl.Controls.Add(this.contractGridLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit3);
            this.EntityDataLayoutControl.Controls.Add(this.BillingCustomerIdSearchLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit2);
            this.EntityDataLayoutControl.Controls.Add(this.ExchangeRateTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit1);
            this.EntityDataLayoutControl.Controls.Add(this.InvoiceIdTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.InvoiceNumberTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.NameTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.PaidAmountTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.TotalAmountTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.TransactionCurrencyTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.UserTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.VersionNumberPictureEdit);
            this.EntityDataLayoutControl.Controls.Add(this.DateDeliveredTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.ReceivedDateTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.TransactionCurrencyIdLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.StatusCodeLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.DescriptionTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.OwnerIdLookUpEdit);
            this.EntityDataLayoutControl.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForTransactionCurrency,
            this.ItemForUser,
            this.ItemForVersionNumber,
            this.ItemForInvoiceId});
            resources.ApplyResources(this.EntityDataLayoutControl, "EntityDataLayoutControl");
            this.EntityDataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(826, 228, 466, 350);
            // 
            // RootLayoutControlGroup
            // 
            resources.ApplyResources(this.RootLayoutControlGroup, "RootLayoutControlGroup");
            this.RootLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1});
            this.RootLayoutControlGroup.Name = "Root";
            this.RootLayoutControlGroup.Size = new System.Drawing.Size(1008, 616);
            // 
            // ExchangeRateTextEdit
            // 
            this.ExchangeRateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ExchangeRate", true));
            resources.ApplyResources(this.ExchangeRateTextEdit, "ExchangeRateTextEdit");
            this.ExchangeRateTextEdit.Name = "ExchangeRateTextEdit";
            this.ExchangeRateTextEdit.Properties.DisplayFormat.FormatString = "{0:0.00}";
            this.ExchangeRateTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ExchangeRateTextEdit.Properties.Mask.EditMask = resources.GetString("ExchangeRateTextEdit.Properties.Mask.EditMask");
            this.ExchangeRateTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("ExchangeRateTextEdit.Properties.Mask.MaskType")));
            this.ExchangeRateTextEdit.Properties.MaxLength = 6;
            this.ExchangeRateTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // InvoiceIdTextEdit
            // 
            this.InvoiceIdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "InvoiceId", true));
            resources.ApplyResources(this.InvoiceIdTextEdit, "InvoiceIdTextEdit");
            this.InvoiceIdTextEdit.Name = "InvoiceIdTextEdit";
            this.InvoiceIdTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // InvoiceNumberTextEdit
            // 
            this.InvoiceNumberTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "InvoiceNumber", true));
            resources.ApplyResources(this.InvoiceNumberTextEdit, "InvoiceNumberTextEdit");
            this.InvoiceNumberTextEdit.Name = "InvoiceNumberTextEdit";
            this.InvoiceNumberTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // NameTextEdit
            // 
            this.NameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Name", true));
            resources.ApplyResources(this.NameTextEdit, "NameTextEdit");
            this.NameTextEdit.Name = "NameTextEdit";
            this.NameTextEdit.Properties.MaxLength = 300;
            this.NameTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // PaidAmountTextEdit
            // 
            this.PaidAmountTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "PaidAmount", true));
            resources.ApplyResources(this.PaidAmountTextEdit, "PaidAmountTextEdit");
            this.PaidAmountTextEdit.Name = "PaidAmountTextEdit";
            this.PaidAmountTextEdit.Properties.DisplayFormat.FormatString = "{0:N2}";
            this.PaidAmountTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.PaidAmountTextEdit.Properties.Mask.EditMask = resources.GetString("PaidAmountTextEdit.Properties.Mask.EditMask");
            this.PaidAmountTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("PaidAmountTextEdit.Properties.Mask.MaskType")));
            this.PaidAmountTextEdit.Properties.MaxLength = 12;
            this.PaidAmountTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // TotalAmountTextEdit
            // 
            this.TotalAmountTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "TotalAmount", true));
            resources.ApplyResources(this.TotalAmountTextEdit, "TotalAmountTextEdit");
            this.TotalAmountTextEdit.Name = "TotalAmountTextEdit";
            this.TotalAmountTextEdit.Properties.DisplayFormat.FormatString = "{0:N2}";
            this.TotalAmountTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TotalAmountTextEdit.Properties.Mask.EditMask = resources.GetString("TotalAmountTextEdit.Properties.Mask.EditMask");
            this.TotalAmountTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("TotalAmountTextEdit.Properties.Mask.MaskType")));
            this.TotalAmountTextEdit.Properties.MaxLength = 12;
            this.TotalAmountTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // TransactionCurrencyTextEdit
            // 
            this.TransactionCurrencyTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "TransactionCurrency", true));
            resources.ApplyResources(this.TransactionCurrencyTextEdit, "TransactionCurrencyTextEdit");
            this.TransactionCurrencyTextEdit.Name = "TransactionCurrencyTextEdit";
            this.TransactionCurrencyTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // UserTextEdit
            // 
            this.UserTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "User", true));
            resources.ApplyResources(this.UserTextEdit, "UserTextEdit");
            this.UserTextEdit.Name = "UserTextEdit";
            this.UserTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // VersionNumberPictureEdit
            // 
            this.VersionNumberPictureEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "VersionNumber", true));
            resources.ApplyResources(this.VersionNumberPictureEdit, "VersionNumberPictureEdit");
            this.VersionNumberPictureEdit.Name = "VersionNumberPictureEdit";
            this.VersionNumberPictureEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // DateDeliveredTextEdit
            // 
            this.DateDeliveredTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "DateDelivered", true));
            resources.ApplyResources(this.DateDeliveredTextEdit, "DateDeliveredTextEdit");
            this.DateDeliveredTextEdit.Name = "DateDeliveredTextEdit";
            this.DateDeliveredTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("DateDeliveredTextEdit.Properties.Buttons"))))});
            this.DateDeliveredTextEdit.Properties.Mask.EditMask = resources.GetString("DateDeliveredTextEdit.Properties.Mask.EditMask");
            this.DateDeliveredTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("DateDeliveredTextEdit.Properties.Mask.MaskType")));
            this.DateDeliveredTextEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DateDeliveredTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ReceivedDateTextEdit
            // 
            this.ReceivedDateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ReceivedDate", true));
            resources.ApplyResources(this.ReceivedDateTextEdit, "ReceivedDateTextEdit");
            this.ReceivedDateTextEdit.Name = "ReceivedDateTextEdit";
            this.ReceivedDateTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ReceivedDateTextEdit.Properties.Buttons"))))});
            this.ReceivedDateTextEdit.Properties.Mask.EditMask = resources.GetString("ReceivedDateTextEdit.Properties.Mask.EditMask");
            this.ReceivedDateTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("ReceivedDateTextEdit.Properties.Mask.MaskType")));
            this.ReceivedDateTextEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ReceivedDateTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // TransactionCurrencyIdLookUpEdit
            // 
            this.TransactionCurrencyIdLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "TransactionCurrencyId", true));
            resources.ApplyResources(this.TransactionCurrencyIdLookUpEdit, "TransactionCurrencyIdLookUpEdit");
            this.TransactionCurrencyIdLookUpEdit.Name = "TransactionCurrencyIdLookUpEdit";
            this.TransactionCurrencyIdLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("TransactionCurrencyIdLookUpEdit.Properties.Buttons"))))});
            this.TransactionCurrencyIdLookUpEdit.Properties.NullText = resources.GetString("TransactionCurrencyIdLookUpEdit.Properties.NullText");
            this.TransactionCurrencyIdLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // StatusCodeLookUpEdit
            // 
            this.StatusCodeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "StatusCode", true));
            resources.ApplyResources(this.StatusCodeLookUpEdit, "StatusCodeLookUpEdit");
            this.StatusCodeLookUpEdit.Name = "StatusCodeLookUpEdit";
            this.StatusCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("StatusCodeLookUpEdit.Properties.Buttons"))))});
            this.StatusCodeLookUpEdit.Properties.NullText = resources.GetString("StatusCodeLookUpEdit.Properties.NullText");
            this.StatusCodeLookUpEdit.StyleController = this.EntityDataLayoutControl;
            this.StatusCodeLookUpEdit.EditValueChanged += new System.EventHandler(this.StatusCodeLookUpEdit_EditValueChanged);
            // 
            // DescriptionTextEdit
            // 
            this.DescriptionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Description", true));
            resources.ApplyResources(this.DescriptionTextEdit, "DescriptionTextEdit");
            this.DescriptionTextEdit.Name = "DescriptionTextEdit";
            this.DescriptionTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForTransactionCurrency
            // 
            this.ItemForTransactionCurrency.Control = this.TransactionCurrencyTextEdit;
            resources.ApplyResources(this.ItemForTransactionCurrency, "ItemForTransactionCurrency");
            this.ItemForTransactionCurrency.Location = new System.Drawing.Point(0, 360);
            this.ItemForTransactionCurrency.Name = "ItemForTransactionCurrency";
            this.ItemForTransactionCurrency.Size = new System.Drawing.Size(844, 24);
            this.ItemForTransactionCurrency.TextSize = new System.Drawing.Size(50, 20);
            this.ItemForTransactionCurrency.TextToControlDistance = 5;
            // 
            // ItemForUser
            // 
            this.ItemForUser.Control = this.UserTextEdit;
            resources.ApplyResources(this.ItemForUser, "ItemForUser");
            this.ItemForUser.Location = new System.Drawing.Point(0, 24);
            this.ItemForUser.Name = "ItemForUser";
            this.ItemForUser.Size = new System.Drawing.Size(844, 24);
            this.ItemForUser.TextSize = new System.Drawing.Size(50, 20);
            this.ItemForUser.TextToControlDistance = 5;
            // 
            // ItemForVersionNumber
            // 
            this.ItemForVersionNumber.Control = this.VersionNumberPictureEdit;
            resources.ApplyResources(this.ItemForVersionNumber, "ItemForVersionNumber");
            this.ItemForVersionNumber.Location = new System.Drawing.Point(0, 24);
            this.ItemForVersionNumber.Name = "ItemForVersionNumber";
            this.ItemForVersionNumber.Size = new System.Drawing.Size(844, 206);
            this.ItemForVersionNumber.TextSize = new System.Drawing.Size(50, 20);
            this.ItemForVersionNumber.TextToControlDistance = 5;
            // 
            // ItemForInvoiceId
            // 
            this.ItemForInvoiceId.Control = this.InvoiceIdTextEdit;
            resources.ApplyResources(this.ItemForInvoiceId, "ItemForInvoiceId");
            this.ItemForInvoiceId.Location = new System.Drawing.Point(0, 72);
            this.ItemForInvoiceId.Name = "ItemForInvoiceId";
            this.ItemForInvoiceId.Size = new System.Drawing.Size(844, 24);
            this.ItemForInvoiceId.TextSize = new System.Drawing.Size(50, 20);
            this.ItemForInvoiceId.TextToControlDistance = 5;
            // 
            // tabbedControlGroup1
            // 
            resources.ApplyResources(this.tabbedControlGroup1, "tabbedControlGroup1");
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.layoutControlGroup4;
            this.tabbedControlGroup1.SelectedTabPageIndex = 0;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(988, 596);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup4,
            this.managementGeneratedGroup});
            // 
            // layoutControlGroup4
            // 
            resources.ApplyResources(this.layoutControlGroup4, "layoutControlGroup4");
            this.layoutControlGroup4.ExpandButtonVisible = true;
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForName,
            this.ItemForInvoiceNumber,
            this.ItemForOwnerId,
            this.ItemForPaidAmount,
            this.ItemForTransactionCurrencyId,
            this.ItemForReceivedDate,
            this.ItemForTotalAmount,
            this.ItemForDateDelivered,
            this.ItemForExchangeRate,
            this.ItemForStatusCode,
            this.ItemForDescription,
            this.layoutControlItem4,
            this.ItemForContracts});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(964, 549);
            // 
            // ItemForName
            // 
            this.ItemForName.Control = this.NameTextEdit;
            resources.ApplyResources(this.ItemForName, "ItemForName");
            this.ItemForName.Location = new System.Drawing.Point(0, 0);
            this.ItemForName.Name = "ItemForName";
            this.ItemForName.Size = new System.Drawing.Size(964, 24);
            this.ItemForName.TextSize = new System.Drawing.Size(86, 14);
            // 
            // ItemForInvoiceNumber
            // 
            this.ItemForInvoiceNumber.Control = this.InvoiceNumberTextEdit;
            resources.ApplyResources(this.ItemForInvoiceNumber, "ItemForInvoiceNumber");
            this.ItemForInvoiceNumber.Location = new System.Drawing.Point(0, 24);
            this.ItemForInvoiceNumber.Name = "ItemForInvoiceNumber";
            this.ItemForInvoiceNumber.Size = new System.Drawing.Size(413, 24);
            this.ItemForInvoiceNumber.TextSize = new System.Drawing.Size(86, 14);
            // 
            // ItemForOwnerId
            // 
            this.ItemForOwnerId.Control = this.OwnerIdLookUpEdit;
            resources.ApplyResources(this.ItemForOwnerId, "ItemForOwnerId");
            this.ItemForOwnerId.Location = new System.Drawing.Point(0, 120);
            this.ItemForOwnerId.Name = "ItemForOwnerId";
            this.ItemForOwnerId.Size = new System.Drawing.Size(413, 24);
            this.ItemForOwnerId.TextSize = new System.Drawing.Size(86, 14);
            // 
            // OwnerIdLookUpEdit
            // 
            this.OwnerIdLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "OwnerId", true));
            resources.ApplyResources(this.OwnerIdLookUpEdit, "OwnerIdLookUpEdit");
            this.OwnerIdLookUpEdit.Name = "OwnerIdLookUpEdit";
            this.OwnerIdLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("OwnerIdLookUpEdit.Properties.Buttons"))))});
            this.OwnerIdLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForPaidAmount
            // 
            this.ItemForPaidAmount.Control = this.PaidAmountTextEdit;
            resources.ApplyResources(this.ItemForPaidAmount, "ItemForPaidAmount");
            this.ItemForPaidAmount.Location = new System.Drawing.Point(0, 48);
            this.ItemForPaidAmount.Name = "ItemForPaidAmount";
            this.ItemForPaidAmount.Size = new System.Drawing.Size(413, 24);
            this.ItemForPaidAmount.TextSize = new System.Drawing.Size(86, 14);
            // 
            // ItemForTransactionCurrencyId
            // 
            this.ItemForTransactionCurrencyId.Control = this.TransactionCurrencyIdLookUpEdit;
            resources.ApplyResources(this.ItemForTransactionCurrencyId, "ItemForTransactionCurrencyId");
            this.ItemForTransactionCurrencyId.Location = new System.Drawing.Point(0, 96);
            this.ItemForTransactionCurrencyId.Name = "ItemForTransactionCurrencyId";
            this.ItemForTransactionCurrencyId.Size = new System.Drawing.Size(413, 24);
            this.ItemForTransactionCurrencyId.TextSize = new System.Drawing.Size(86, 14);
            // 
            // ItemForReceivedDate
            // 
            this.ItemForReceivedDate.Control = this.ReceivedDateTextEdit;
            resources.ApplyResources(this.ItemForReceivedDate, "ItemForReceivedDate");
            this.ItemForReceivedDate.Location = new System.Drawing.Point(0, 72);
            this.ItemForReceivedDate.Name = "ItemForReceivedDate";
            this.ItemForReceivedDate.Size = new System.Drawing.Size(413, 24);
            this.ItemForReceivedDate.TextSize = new System.Drawing.Size(86, 14);
            // 
            // ItemForTotalAmount
            // 
            this.ItemForTotalAmount.Control = this.TotalAmountTextEdit;
            resources.ApplyResources(this.ItemForTotalAmount, "ItemForTotalAmount");
            this.ItemForTotalAmount.Location = new System.Drawing.Point(413, 48);
            this.ItemForTotalAmount.Name = "ItemForTotalAmount";
            this.ItemForTotalAmount.Size = new System.Drawing.Size(551, 24);
            this.ItemForTotalAmount.TextSize = new System.Drawing.Size(86, 14);
            // 
            // ItemForDateDelivered
            // 
            this.ItemForDateDelivered.Control = this.DateDeliveredTextEdit;
            resources.ApplyResources(this.ItemForDateDelivered, "ItemForDateDelivered");
            this.ItemForDateDelivered.Location = new System.Drawing.Point(413, 72);
            this.ItemForDateDelivered.Name = "ItemForDateDelivered";
            this.ItemForDateDelivered.Size = new System.Drawing.Size(551, 24);
            this.ItemForDateDelivered.TextSize = new System.Drawing.Size(86, 14);
            // 
            // ItemForExchangeRate
            // 
            this.ItemForExchangeRate.Control = this.ExchangeRateTextEdit;
            resources.ApplyResources(this.ItemForExchangeRate, "ItemForExchangeRate");
            this.ItemForExchangeRate.Location = new System.Drawing.Point(413, 96);
            this.ItemForExchangeRate.Name = "ItemForExchangeRate";
            this.ItemForExchangeRate.Size = new System.Drawing.Size(551, 24);
            this.ItemForExchangeRate.TextSize = new System.Drawing.Size(86, 14);
            // 
            // ItemForStatusCode
            // 
            this.ItemForStatusCode.Control = this.StatusCodeLookUpEdit;
            resources.ApplyResources(this.ItemForStatusCode, "ItemForStatusCode");
            this.ItemForStatusCode.Location = new System.Drawing.Point(413, 120);
            this.ItemForStatusCode.Name = "ItemForStatusCode";
            this.ItemForStatusCode.Size = new System.Drawing.Size(551, 24);
            this.ItemForStatusCode.TextSize = new System.Drawing.Size(86, 14);
            // 
            // ItemForDescription
            // 
            this.ItemForDescription.Control = this.DescriptionTextEdit;
            resources.ApplyResources(this.ItemForDescription, "ItemForDescription");
            this.ItemForDescription.Location = new System.Drawing.Point(0, 168);
            this.ItemForDescription.Name = "ItemForDescription";
            this.ItemForDescription.Size = new System.Drawing.Size(964, 381);
            this.ItemForDescription.TextSize = new System.Drawing.Size(86, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.BillingCustomerIdSearchLookUpEdit;
            resources.ApplyResources(this.layoutControlItem4, "layoutControlItem4");
            this.layoutControlItem4.Location = new System.Drawing.Point(413, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(551, 24);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(86, 14);
            // 
            // BillingCustomerIdSearchLookUpEdit
            // 
            this.BillingCustomerIdSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "BillingCustomerId", true));
            resources.ApplyResources(this.BillingCustomerIdSearchLookUpEdit, "BillingCustomerIdSearchLookUpEdit");
            this.BillingCustomerIdSearchLookUpEdit.Name = "BillingCustomerIdSearchLookUpEdit";
            this.BillingCustomerIdSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("BillingCustomerIdSearchLookUpEdit.Properties.Buttons"))))});
            this.BillingCustomerIdSearchLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForContracts
            // 
            this.ItemForContracts.Control = this.contractGridLookUpEdit;
            resources.ApplyResources(this.ItemForContracts, "ItemForContracts");
            this.ItemForContracts.Location = new System.Drawing.Point(0, 144);
            this.ItemForContracts.Name = "ItemForContracts";
            this.ItemForContracts.Size = new System.Drawing.Size(964, 24);
            this.ItemForContracts.TextSize = new System.Drawing.Size(86, 14);
            // 
            // contractGridLookUpEdit
            // 
            resources.ApplyResources(this.contractGridLookUpEdit, "contractGridLookUpEdit");
            this.contractGridLookUpEdit.Name = "contractGridLookUpEdit";
            this.contractGridLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("contractGridLookUpEdit.Properties.Buttons"))))});
            gridCheckMarksSelection1.Selection = ((System.Collections.ArrayList)(resources.GetObject("gridCheckMarksSelection1.Selection")));
            gridCheckMarksSelection1.View = null;
            this.contractGridLookUpEdit.Properties.GridSelection = gridCheckMarksSelection1;
            this.contractGridLookUpEdit.Properties.View = this.gridLookUpEdit1View;
            this.contractGridLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // managementGeneratedGroup
            // 
            this.managementGeneratedGroup.AllowDrawBackground = false;
            resources.ApplyResources(this.managementGeneratedGroup, "managementGeneratedGroup");
            this.managementGeneratedGroup.GroupBordersVisible = false;
            this.managementGeneratedGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem5,
            this.ItemForCreatedOn,
            this.ItemForCreatedBy,
            this.ItemForModifiedOn,
            this.ItemForModifiedBy});
            this.managementGeneratedGroup.Location = new System.Drawing.Point(0, 0);
            this.managementGeneratedGroup.Name = "managementGeneratedGroup";
            this.managementGeneratedGroup.Size = new System.Drawing.Size(964, 549);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem5, "emptySpaceItem5");
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(964, 501);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ItemForCreatedOn
            // 
            this.ItemForCreatedOn.Control = this.textEdit1;
            resources.ApplyResources(this.ItemForCreatedOn, "ItemForCreatedOn");
            this.ItemForCreatedOn.Location = new System.Drawing.Point(0, 0);
            this.ItemForCreatedOn.Name = "ItemForCreatedOn";
            this.ItemForCreatedOn.Size = new System.Drawing.Size(482, 24);
            this.ItemForCreatedOn.TextSize = new System.Drawing.Size(86, 14);
            // 
            // textEdit1
            // 
            this.textEdit1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "CreatedOn", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            resources.ApplyResources(this.textEdit1, "textEdit1");
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForCreatedBy
            // 
            this.ItemForCreatedBy.Control = this.textEdit2;
            resources.ApplyResources(this.ItemForCreatedBy, "ItemForCreatedBy");
            this.ItemForCreatedBy.Location = new System.Drawing.Point(482, 0);
            this.ItemForCreatedBy.Name = "ItemForCreatedBy";
            this.ItemForCreatedBy.Size = new System.Drawing.Size(482, 24);
            this.ItemForCreatedBy.TextSize = new System.Drawing.Size(86, 14);
            // 
            // textEdit2
            // 
            this.textEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "CreatedBy.FullName", true));
            resources.ApplyResources(this.textEdit2, "textEdit2");
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForModifiedOn
            // 
            this.ItemForModifiedOn.Control = this.textEdit3;
            resources.ApplyResources(this.ItemForModifiedOn, "ItemForModifiedOn");
            this.ItemForModifiedOn.Location = new System.Drawing.Point(0, 24);
            this.ItemForModifiedOn.Name = "ItemForModifiedOn";
            this.ItemForModifiedOn.Size = new System.Drawing.Size(482, 24);
            this.ItemForModifiedOn.TextSize = new System.Drawing.Size(86, 14);
            // 
            // textEdit3
            // 
            this.textEdit3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "ModifiedOn", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            resources.ApplyResources(this.textEdit3, "textEdit3");
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForModifiedBy
            // 
            this.ItemForModifiedBy.Control = this.textEdit4;
            resources.ApplyResources(this.ItemForModifiedBy, "ItemForModifiedBy");
            this.ItemForModifiedBy.Location = new System.Drawing.Point(482, 24);
            this.ItemForModifiedBy.Name = "ItemForModifiedBy";
            this.ItemForModifiedBy.Size = new System.Drawing.Size(482, 24);
            this.ItemForModifiedBy.TextSize = new System.Drawing.Size(86, 14);
            // 
            // textEdit4
            // 
            this.textEdit4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ModifiedBy.FullName", true));
            resources.ApplyResources(this.textEdit4, "textEdit4");
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.StyleController = this.EntityDataLayoutControl;
            // 
            // gridViewCustomer
            // 
            this.gridViewCustomer.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewCustomer.Name = "gridViewCustomer";
            this.gridViewCustomer.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewCustomer.OptionsView.ShowGroupPanel = false;
            // 
            // InvoiceDetailView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "InvoiceDetailView";
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).EndInit();
            this.EntityDataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExchangeRateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceIdTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceNumberTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaidAmountTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalAmountTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionCurrencyTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VersionNumberPictureEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDeliveredTextEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDeliveredTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedDateTextEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedDateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionCurrencyIdLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusCodeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTransactionCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForVersionNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForInvoiceId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForInvoiceNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOwnerId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OwnerIdLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPaidAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTransactionCurrencyId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForReceivedDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTotalAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDateDelivered)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForExchangeRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillingCustomerIdSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForContracts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractGridLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.managementGeneratedGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit ExchangeRateTextEdit;
        private DevExpress.XtraEditors.TextEdit InvoiceIdTextEdit;
        private DevExpress.XtraEditors.TextEdit InvoiceNumberTextEdit;
        private DevExpress.XtraEditors.TextEdit NameTextEdit;
        private DevExpress.XtraEditors.TextEdit PaidAmountTextEdit;
        private DevExpress.XtraEditors.TextEdit TotalAmountTextEdit;
        private DevExpress.XtraEditors.TextEdit TransactionCurrencyTextEdit;
        private DevExpress.XtraEditors.TextEdit UserTextEdit;
        private DevExpress.XtraEditors.PictureEdit VersionNumberPictureEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForInvoiceId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTransactionCurrency;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUser;
        private DevExpress.XtraLayout.LayoutControlItem ItemForVersionNumber;
        private Katrin.AppFramework.WinForms.Controls.DropDownDateEdit DateDeliveredTextEdit;
        private Katrin.AppFramework.WinForms.Controls.DropDownDateEdit ReceivedDateTextEdit;
        private DevExpress.XtraEditors.LookUpEdit TransactionCurrencyIdLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit StatusCodeLookUpEdit;
        private DevExpress.XtraEditors.MemoEdit DescriptionTextEdit;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup managementGeneratedGroup;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem ItemForName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForInvoiceNumber;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOwnerId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPaidAmount;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTransactionCurrencyId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForReceivedDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTotalAmount;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDateDelivered;
        private DevExpress.XtraLayout.LayoutControlItem ItemForExchangeRate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStatusCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private DevExpress.XtraEditors.SearchLookUpEdit BillingCustomerIdSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCustomer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private Katrin.Win.Common.Controls.MyGridLookUpEdit contractGridLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem ItemForContracts;
        private DevExpress.XtraEditors.TextEdit textEdit4;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreatedOn;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreatedBy;
        private DevExpress.XtraLayout.LayoutControlItem ItemForModifiedOn;
        private DevExpress.XtraLayout.LayoutControlItem ItemForModifiedBy;
        private DevExpress.XtraEditors.PopupContainerEdit OwnerIdLookUpEdit;
    }
}
