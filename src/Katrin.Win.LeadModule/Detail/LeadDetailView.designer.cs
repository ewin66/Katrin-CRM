using Katrin.AppFramework.WinForms.Controls;
using System;
using System.Windows.Forms;

namespace Katrin.Win.LeadModule.Detail
{
    partial class LeadDetailView
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
            GC.SuppressFinalize(this);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeadDetailView));
            this.CompanyNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.EmailAddressTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.FaxTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.FirstNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.LastNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.MobilePhoneTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.RevenueTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.SubjectTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.Telephone1TextEdit = new DevExpress.XtraEditors.TextEdit();
            this.Telephone2TextEdit = new DevExpress.XtraEditors.TextEdit();
            this.WebSiteUrlTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DescriptionMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.NumberOfEmployeesSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.LeadSourceCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.AddressTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.CityTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ZIPTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DepartmentIdLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.PriorityCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.StatusCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.OriginalMessageTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.CountryLookUpEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
            this.infotabbedControlGroup = new DevExpress.XtraLayout.TabbedControlGroup();
            this.lcgGeneral = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForSubject = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForFirstName = new DevExpress.XtraLayout.LayoutControlItem();
            this.contactGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForEmailAddress = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForWebSiteUrl = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCountry = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCity = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAddress = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForZIP = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTelephone2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForMobilePhone = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTelephone1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForFax = new DevExpress.XtraLayout.LayoutControlItem();
            this.detailsGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForNumberOfEmployees = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForRevenue = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForOriginalMessage = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForStatusCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPriorityCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCompanyName = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ItemForTechnology = new DevExpress.XtraLayout.LayoutControlItem();
            this.technologyCodeLookUpEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ItemForLeadSourceCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForLastName = new DevExpress.XtraLayout.LayoutControlItem();
            this.itemForEmailResponseTime = new DevExpress.XtraLayout.LayoutControlItem();
            this.emailResponseTimeDateEdit = new Katrin.AppFramework.WinForms.Controls.DropDownDateEdit();
            this.itemForClosingTime = new DevExpress.XtraLayout.LayoutControlItem();
            this.closingTimeDateEdit = new Katrin.AppFramework.WinForms.Controls.DropDownDateEdit();
            this.managementLayoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ItemForDepartmentId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForOwnerId = new DevExpress.XtraLayout.LayoutControlItem();
            this.OwnerIdSearchLookUpEdit = new DevExpress.XtraEditors.PopupContainerEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).BeginInit();
            this.EntityDataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailAddressTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaxTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MobilePhoneTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RevenueTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubjectTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Telephone1TextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Telephone2TextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebSiteUrlTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfEmployeesSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeadSourceCodeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddressTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CityTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZIPTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentIdLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorityCodeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusCodeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalMessageTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountryLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infotabbedControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEmailAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForWebSiteUrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForZIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTelephone2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMobilePhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTelephone1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailsGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNumberOfEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRevenue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOriginalMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPriorityCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCompanyName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTechnology)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.technologyCodeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLeadSourceCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForEmailResponseTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailResponseTimeDateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailResponseTimeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForClosingTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closingTimeDateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closingTimeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.managementLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDepartmentId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOwnerId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OwnerIdSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // EntityDataLayoutControl
            // 
            this.EntityDataLayoutControl.Controls.Add(this.closingTimeDateEdit);
            this.EntityDataLayoutControl.Controls.Add(this.emailResponseTimeDateEdit);
            this.EntityDataLayoutControl.Controls.Add(this.technologyCodeLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit4);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit3);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit2);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit1);
            this.EntityDataLayoutControl.Controls.Add(this.SubjectTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.FirstNameTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.CompanyNameTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.LeadSourceCodeLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.NumberOfEmployeesSpinEdit);
            this.EntityDataLayoutControl.Controls.Add(this.PriorityCodeLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.RevenueTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.LastNameTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.DepartmentIdLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.StatusCodeLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.DescriptionMemoEdit);
            this.EntityDataLayoutControl.Controls.Add(this.OriginalMessageTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.Telephone1TextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.FaxTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.MobilePhoneTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.Telephone2TextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.EmailAddressTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.WebSiteUrlTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.CityTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.AddressTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.ZIPTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.CountryLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.OwnerIdSearchLookUpEdit);
            resources.ApplyResources(this.EntityDataLayoutControl, "EntityDataLayoutControl");
            this.EntityDataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(413, -18, 374, 538);
            // 
            // RootLayoutControlGroup
            // 
            this.RootLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.infotabbedControlGroup});
            this.RootLayoutControlGroup.Name = "Root";
            this.RootLayoutControlGroup.Size = new System.Drawing.Size(874, 664);
            // 
            // CompanyNameTextEdit
            // 
            this.CompanyNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "CompanyName", true));
            resources.ApplyResources(this.CompanyNameTextEdit, "CompanyNameTextEdit");
            this.CompanyNameTextEdit.Name = "CompanyNameTextEdit";
            this.CompanyNameTextEdit.Properties.MaxLength = 100;
            this.CompanyNameTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // EmailAddressTextEdit
            // 
            this.EmailAddressTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "EmailAddress", true));
            resources.ApplyResources(this.EmailAddressTextEdit, "EmailAddressTextEdit");
            this.EmailAddressTextEdit.Name = "EmailAddressTextEdit";
            this.EmailAddressTextEdit.Properties.Mask.EditMask = resources.GetString("EmailAddressTextEdit.Properties.Mask.EditMask");
            this.EmailAddressTextEdit.Properties.MaxLength = 100;
            this.EmailAddressTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // FaxTextEdit
            // 
            this.FaxTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Fax", true));
            resources.ApplyResources(this.FaxTextEdit, "FaxTextEdit");
            this.FaxTextEdit.Name = "FaxTextEdit";
            this.FaxTextEdit.Properties.MaxLength = 50;
            this.FaxTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // FirstNameTextEdit
            // 
            this.FirstNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "FirstName", true));
            resources.ApplyResources(this.FirstNameTextEdit, "FirstNameTextEdit");
            this.FirstNameTextEdit.Name = "FirstNameTextEdit";
            this.FirstNameTextEdit.Properties.MaxLength = 50;
            this.FirstNameTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // LastNameTextEdit
            // 
            this.LastNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "LastName", true));
            resources.ApplyResources(this.LastNameTextEdit, "LastNameTextEdit");
            this.LastNameTextEdit.Name = "LastNameTextEdit";
            this.LastNameTextEdit.Properties.MaxLength = 50;
            this.LastNameTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // MobilePhoneTextEdit
            // 
            this.MobilePhoneTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "MobilePhone", true));
            resources.ApplyResources(this.MobilePhoneTextEdit, "MobilePhoneTextEdit");
            this.MobilePhoneTextEdit.Name = "MobilePhoneTextEdit";
            this.MobilePhoneTextEdit.Properties.MaxLength = 50;
            this.MobilePhoneTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // RevenueTextEdit
            // 
            this.RevenueTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Revenue", true));
            resources.ApplyResources(this.RevenueTextEdit, "RevenueTextEdit");
            this.RevenueTextEdit.Name = "RevenueTextEdit";
            this.RevenueTextEdit.Properties.DisplayFormat.FormatString = "c2";
            this.RevenueTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.RevenueTextEdit.Properties.Mask.EditMask = resources.GetString("RevenueTextEdit.Properties.Mask.EditMask");
            this.RevenueTextEdit.Properties.MaxLength = 12;
            this.RevenueTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // SubjectTextEdit
            // 
            this.SubjectTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Subject", true));
            resources.ApplyResources(this.SubjectTextEdit, "SubjectTextEdit");
            this.SubjectTextEdit.Name = "SubjectTextEdit";
            this.SubjectTextEdit.Properties.MaxLength = 300;
            this.SubjectTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // Telephone1TextEdit
            // 
            this.Telephone1TextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Telephone1", true));
            resources.ApplyResources(this.Telephone1TextEdit, "Telephone1TextEdit");
            this.Telephone1TextEdit.Name = "Telephone1TextEdit";
            this.Telephone1TextEdit.Properties.MaxLength = 50;
            this.Telephone1TextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // Telephone2TextEdit
            // 
            this.Telephone2TextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Telephone2", true));
            resources.ApplyResources(this.Telephone2TextEdit, "Telephone2TextEdit");
            this.Telephone2TextEdit.Name = "Telephone2TextEdit";
            this.Telephone2TextEdit.Properties.MaxLength = 50;
            this.Telephone2TextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // WebSiteUrlTextEdit
            // 
            this.WebSiteUrlTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "WebSiteUrl", true));
            resources.ApplyResources(this.WebSiteUrlTextEdit, "WebSiteUrlTextEdit");
            this.WebSiteUrlTextEdit.Name = "WebSiteUrlTextEdit";
            this.WebSiteUrlTextEdit.Properties.Mask.EditMask = resources.GetString("WebSiteUrlTextEdit.Properties.Mask.EditMask");
            this.WebSiteUrlTextEdit.Properties.MaxLength = 200;
            this.WebSiteUrlTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // DescriptionMemoEdit
            // 
            this.DescriptionMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Description", true));
            resources.ApplyResources(this.DescriptionMemoEdit, "DescriptionMemoEdit");
            this.DescriptionMemoEdit.Name = "DescriptionMemoEdit";
            this.DescriptionMemoEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // NumberOfEmployeesSpinEdit
            // 
            this.NumberOfEmployeesSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "NumberOfEmployees", true));
            resources.ApplyResources(this.NumberOfEmployeesSpinEdit, "NumberOfEmployeesSpinEdit");
            this.NumberOfEmployeesSpinEdit.Name = "NumberOfEmployeesSpinEdit";
            this.NumberOfEmployeesSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.NumberOfEmployeesSpinEdit.Properties.Mask.EditMask = resources.GetString("NumberOfEmployeesSpinEdit.Properties.Mask.EditMask");
            this.NumberOfEmployeesSpinEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("NumberOfEmployeesSpinEdit.Properties.Mask.MaskType")));
            this.NumberOfEmployeesSpinEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("NumberOfEmployeesSpinEdit.Properties.Mask.ShowPlaceHolders")));
            this.NumberOfEmployeesSpinEdit.Properties.MaxLength = 5;
            this.NumberOfEmployeesSpinEdit.Properties.MaxValue = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.NumberOfEmployeesSpinEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // LeadSourceCodeLookUpEdit
            // 
            this.LeadSourceCodeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "LeadSourceCode", true));
            resources.ApplyResources(this.LeadSourceCodeLookUpEdit, "LeadSourceCodeLookUpEdit");
            this.LeadSourceCodeLookUpEdit.Name = "LeadSourceCodeLookUpEdit";
            this.LeadSourceCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("LeadSourceCodeLookUpEdit.Properties.Buttons"))))});
            this.LeadSourceCodeLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // AddressTextEdit
            // 
            this.AddressTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Address", true));
            resources.ApplyResources(this.AddressTextEdit, "AddressTextEdit");
            this.AddressTextEdit.Name = "AddressTextEdit";
            this.AddressTextEdit.Properties.MaxLength = 100;
            this.AddressTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // CityTextEdit
            // 
            this.CityTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "City", true));
            resources.ApplyResources(this.CityTextEdit, "CityTextEdit");
            this.CityTextEdit.Name = "CityTextEdit";
            this.CityTextEdit.Properties.MaxLength = 100;
            this.CityTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ZIPTextEdit
            // 
            this.ZIPTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ZIP", true));
            resources.ApplyResources(this.ZIPTextEdit, "ZIPTextEdit");
            this.ZIPTextEdit.Name = "ZIPTextEdit";
            this.ZIPTextEdit.Properties.Mask.EditMask = resources.GetString("ZIPTextEdit.Properties.Mask.EditMask");
            this.ZIPTextEdit.Properties.MaxLength = 50;
            this.ZIPTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // DepartmentIdLookUpEdit
            // 
            this.DepartmentIdLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "DepartmentId", true));
            resources.ApplyResources(this.DepartmentIdLookUpEdit, "DepartmentIdLookUpEdit");
            this.DepartmentIdLookUpEdit.Name = "DepartmentIdLookUpEdit";
            this.DepartmentIdLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("DepartmentIdLookUpEdit.Properties.Buttons"))))});
            this.DepartmentIdLookUpEdit.Properties.NullText = resources.GetString("DepartmentIdLookUpEdit.Properties.NullText");
            this.DepartmentIdLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // PriorityCodeLookUpEdit
            // 
            this.PriorityCodeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "PriorityCode", true));
            resources.ApplyResources(this.PriorityCodeLookUpEdit, "PriorityCodeLookUpEdit");
            this.PriorityCodeLookUpEdit.Name = "PriorityCodeLookUpEdit";
            this.PriorityCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("PriorityCodeLookUpEdit.Properties.Buttons"))))});
            this.PriorityCodeLookUpEdit.Properties.NullText = resources.GetString("PriorityCodeLookUpEdit.Properties.NullText");
            this.PriorityCodeLookUpEdit.Properties.PopupSizeable = false;
            this.PriorityCodeLookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.PriorityCodeLookUpEdit.StyleController = this.EntityDataLayoutControl;
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
            // OriginalMessageTextEdit
            // 
            this.OriginalMessageTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "OriginalMessage", true));
            resources.ApplyResources(this.OriginalMessageTextEdit, "OriginalMessageTextEdit");
            this.OriginalMessageTextEdit.Name = "OriginalMessageTextEdit";
            this.OriginalMessageTextEdit.Properties.Mask.EditMask = resources.GetString("OriginalMessageTextEdit.Properties.Mask.EditMask");
            this.OriginalMessageTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // CountryLookUpEdit
            // 
            this.CountryLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Country", true));
            resources.ApplyResources(this.CountryLookUpEdit, "CountryLookUpEdit");
            this.CountryLookUpEdit.Name = "CountryLookUpEdit";
            this.CountryLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("CountryLookUpEdit.Properties.Buttons"))))});
            this.CountryLookUpEdit.Properties.MaxLength = 100;
            this.CountryLookUpEdit.Properties.PopupSizeable = true;
            this.CountryLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // textEdit1
            // 
            this.textEdit1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "CreatedOn", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            resources.ApplyResources(this.textEdit1, "textEdit1");
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.StyleController = this.EntityDataLayoutControl;
            // 
            // textEdit2
            // 
            this.textEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "CreatedBy.FullName", true));
            resources.ApplyResources(this.textEdit2, "textEdit2");
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.StyleController = this.EntityDataLayoutControl;
            // 
            // textEdit3
            // 
            this.textEdit3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "ModifiedOn", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            resources.ApplyResources(this.textEdit3, "textEdit3");
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.StyleController = this.EntityDataLayoutControl;
            // 
            // textEdit4
            // 
            this.textEdit4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ModifiedBy.FullName", true));
            resources.ApplyResources(this.textEdit4, "textEdit4");
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.StyleController = this.EntityDataLayoutControl;
            // 
            // infotabbedControlGroup
            // 
            resources.ApplyResources(this.infotabbedControlGroup, "infotabbedControlGroup");
            this.infotabbedControlGroup.Location = new System.Drawing.Point(0, 0);
            this.infotabbedControlGroup.Name = "infotabbedControlGroup";
            this.infotabbedControlGroup.SelectedTabPage = this.managementLayoutControlGroup;
            this.infotabbedControlGroup.SelectedTabPageIndex = 1;
            this.infotabbedControlGroup.Size = new System.Drawing.Size(854, 644);
            this.infotabbedControlGroup.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgGeneral,
            this.managementLayoutControlGroup});
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.AllowDrawBackground = false;
            resources.ApplyResources(this.lcgGeneral, "lcgGeneral");
            this.lcgGeneral.ExpandButtonVisible = true;
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForSubject,
            this.ItemForFirstName,
            this.contactGroup,
            this.detailsGroup,
            this.ItemForCompanyName,
            this.emptySpaceItem1,
            this.ItemForTechnology,
            this.ItemForLeadSourceCode,
            this.ItemForLastName,
            this.itemForEmailResponseTime,
            this.itemForClosingTime});
            this.lcgGeneral.Location = new System.Drawing.Point(0, 0);
            this.lcgGeneral.Name = "lcgGeneral";
            this.lcgGeneral.Size = new System.Drawing.Size(830, 597);
            // 
            // ItemForSubject
            // 
            this.ItemForSubject.Control = this.SubjectTextEdit;
            resources.ApplyResources(this.ItemForSubject, "ItemForSubject");
            this.ItemForSubject.Location = new System.Drawing.Point(0, 0);
            this.ItemForSubject.Name = "ItemForSubject";
            this.ItemForSubject.Size = new System.Drawing.Size(830, 24);
            this.ItemForSubject.TextSize = new System.Drawing.Size(157, 14);
            // 
            // ItemForFirstName
            // 
            this.ItemForFirstName.Control = this.FirstNameTextEdit;
            resources.ApplyResources(this.ItemForFirstName, "ItemForFirstName");
            this.ItemForFirstName.Location = new System.Drawing.Point(415, 24);
            this.ItemForFirstName.Name = "ItemForFirstName";
            this.ItemForFirstName.Size = new System.Drawing.Size(415, 24);
            this.ItemForFirstName.TextSize = new System.Drawing.Size(157, 14);
            // 
            // contactGroup
            // 
            resources.ApplyResources(this.contactGroup, "contactGroup");
            this.contactGroup.ExpandButtonVisible = true;
            this.contactGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForEmailAddress,
            this.ItemForWebSiteUrl,
            this.ItemForCountry,
            this.ItemForCity,
            this.ItemForAddress,
            this.ItemForZIP,
            this.ItemForTelephone2,
            this.ItemForMobilePhone,
            this.ItemForTelephone1,
            this.ItemForFax});
            this.contactGroup.Location = new System.Drawing.Point(0, 433);
            this.contactGroup.Name = "contactGroup";
            this.contactGroup.Size = new System.Drawing.Size(830, 164);
            // 
            // ItemForEmailAddress
            // 
            this.ItemForEmailAddress.Control = this.EmailAddressTextEdit;
            resources.ApplyResources(this.ItemForEmailAddress, "ItemForEmailAddress");
            this.ItemForEmailAddress.Location = new System.Drawing.Point(0, 48);
            this.ItemForEmailAddress.Name = "ItemForEmailAddress";
            this.ItemForEmailAddress.Size = new System.Drawing.Size(411, 24);
            this.ItemForEmailAddress.TextSize = new System.Drawing.Size(157, 14);
            // 
            // ItemForWebSiteUrl
            // 
            this.ItemForWebSiteUrl.Control = this.WebSiteUrlTextEdit;
            resources.ApplyResources(this.ItemForWebSiteUrl, "ItemForWebSiteUrl");
            this.ItemForWebSiteUrl.Location = new System.Drawing.Point(411, 48);
            this.ItemForWebSiteUrl.Name = "ItemForWebSiteUrl";
            this.ItemForWebSiteUrl.Size = new System.Drawing.Size(395, 24);
            this.ItemForWebSiteUrl.TextSize = new System.Drawing.Size(157, 14);
            // 
            // ItemForCountry
            // 
            this.ItemForCountry.Control = this.CountryLookUpEdit;
            resources.ApplyResources(this.ItemForCountry, "ItemForCountry");
            this.ItemForCountry.Location = new System.Drawing.Point(0, 72);
            this.ItemForCountry.Name = "ItemForCountry";
            this.ItemForCountry.Size = new System.Drawing.Size(411, 24);
            this.ItemForCountry.TextSize = new System.Drawing.Size(157, 14);
            // 
            // ItemForCity
            // 
            this.ItemForCity.Control = this.CityTextEdit;
            resources.ApplyResources(this.ItemForCity, "ItemForCity");
            this.ItemForCity.Location = new System.Drawing.Point(411, 72);
            this.ItemForCity.Name = "ItemForCity";
            this.ItemForCity.Size = new System.Drawing.Size(395, 24);
            this.ItemForCity.TextSize = new System.Drawing.Size(157, 14);
            // 
            // ItemForAddress
            // 
            this.ItemForAddress.Control = this.AddressTextEdit;
            resources.ApplyResources(this.ItemForAddress, "ItemForAddress");
            this.ItemForAddress.Location = new System.Drawing.Point(0, 96);
            this.ItemForAddress.Name = "ItemForAddress";
            this.ItemForAddress.Size = new System.Drawing.Size(411, 24);
            this.ItemForAddress.TextSize = new System.Drawing.Size(157, 14);
            // 
            // ItemForZIP
            // 
            this.ItemForZIP.Control = this.ZIPTextEdit;
            resources.ApplyResources(this.ItemForZIP, "ItemForZIP");
            this.ItemForZIP.Location = new System.Drawing.Point(411, 96);
            this.ItemForZIP.Name = "ItemForZIP";
            this.ItemForZIP.Size = new System.Drawing.Size(395, 24);
            this.ItemForZIP.TextSize = new System.Drawing.Size(157, 14);
            // 
            // ItemForTelephone2
            // 
            this.ItemForTelephone2.Control = this.Telephone2TextEdit;
            resources.ApplyResources(this.ItemForTelephone2, "ItemForTelephone2");
            this.ItemForTelephone2.Location = new System.Drawing.Point(411, 0);
            this.ItemForTelephone2.Name = "ItemForTelephone2";
            this.ItemForTelephone2.Size = new System.Drawing.Size(395, 24);
            this.ItemForTelephone2.TextSize = new System.Drawing.Size(157, 14);
            // 
            // ItemForMobilePhone
            // 
            this.ItemForMobilePhone.Control = this.MobilePhoneTextEdit;
            resources.ApplyResources(this.ItemForMobilePhone, "ItemForMobilePhone");
            this.ItemForMobilePhone.Location = new System.Drawing.Point(0, 24);
            this.ItemForMobilePhone.Name = "ItemForMobilePhone";
            this.ItemForMobilePhone.Size = new System.Drawing.Size(411, 24);
            this.ItemForMobilePhone.TextSize = new System.Drawing.Size(157, 14);
            // 
            // ItemForTelephone1
            // 
            this.ItemForTelephone1.Control = this.Telephone1TextEdit;
            resources.ApplyResources(this.ItemForTelephone1, "ItemForTelephone1");
            this.ItemForTelephone1.Location = new System.Drawing.Point(0, 0);
            this.ItemForTelephone1.Name = "ItemForTelephone1";
            this.ItemForTelephone1.Size = new System.Drawing.Size(411, 24);
            this.ItemForTelephone1.TextSize = new System.Drawing.Size(157, 14);
            // 
            // ItemForFax
            // 
            this.ItemForFax.Control = this.FaxTextEdit;
            resources.ApplyResources(this.ItemForFax, "ItemForFax");
            this.ItemForFax.Location = new System.Drawing.Point(411, 24);
            this.ItemForFax.Name = "ItemForFax";
            this.ItemForFax.Size = new System.Drawing.Size(395, 24);
            this.ItemForFax.TextSize = new System.Drawing.Size(157, 14);
            // 
            // detailsGroup
            // 
            this.detailsGroup.AllowDrawBackground = false;
            resources.ApplyResources(this.detailsGroup, "detailsGroup");
            this.detailsGroup.ExpandButtonVisible = true;
            this.detailsGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForNumberOfEmployees,
            this.ItemForRevenue,
            this.ItemForDescription,
            this.ItemForOriginalMessage,
            this.ItemForStatusCode,
            this.ItemForPriorityCode});
            this.detailsGroup.Location = new System.Drawing.Point(0, 120);
            this.detailsGroup.Name = "detailsGroup";
            this.detailsGroup.Size = new System.Drawing.Size(830, 313);
            // 
            // ItemForNumberOfEmployees
            // 
            this.ItemForNumberOfEmployees.Control = this.NumberOfEmployeesSpinEdit;
            resources.ApplyResources(this.ItemForNumberOfEmployees, "ItemForNumberOfEmployees");
            this.ItemForNumberOfEmployees.Location = new System.Drawing.Point(0, 24);
            this.ItemForNumberOfEmployees.Name = "ItemForNumberOfEmployees";
            this.ItemForNumberOfEmployees.Size = new System.Drawing.Size(406, 24);
            this.ItemForNumberOfEmployees.TextSize = new System.Drawing.Size(157, 14);
            // 
            // ItemForRevenue
            // 
            this.ItemForRevenue.Control = this.RevenueTextEdit;
            resources.ApplyResources(this.ItemForRevenue, "ItemForRevenue");
            this.ItemForRevenue.Location = new System.Drawing.Point(406, 24);
            this.ItemForRevenue.Name = "ItemForRevenue";
            this.ItemForRevenue.Size = new System.Drawing.Size(400, 24);
            this.ItemForRevenue.TextSize = new System.Drawing.Size(157, 14);
            // 
            // ItemForDescription
            // 
            this.ItemForDescription.Control = this.DescriptionMemoEdit;
            resources.ApplyResources(this.ItemForDescription, "ItemForDescription");
            this.ItemForDescription.Location = new System.Drawing.Point(0, 72);
            this.ItemForDescription.Name = "ItemForDescription";
            this.ItemForDescription.Size = new System.Drawing.Size(806, 197);
            this.ItemForDescription.TextSize = new System.Drawing.Size(157, 14);
            // 
            // ItemForOriginalMessage
            // 
            this.ItemForOriginalMessage.Control = this.OriginalMessageTextEdit;
            resources.ApplyResources(this.ItemForOriginalMessage, "ItemForOriginalMessage");
            this.ItemForOriginalMessage.Location = new System.Drawing.Point(0, 48);
            this.ItemForOriginalMessage.Name = "ItemForOriginalMessage";
            this.ItemForOriginalMessage.Size = new System.Drawing.Size(806, 24);
            this.ItemForOriginalMessage.TextSize = new System.Drawing.Size(157, 14);
            // 
            // ItemForStatusCode
            // 
            this.ItemForStatusCode.Control = this.StatusCodeLookUpEdit;
            resources.ApplyResources(this.ItemForStatusCode, "ItemForStatusCode");
            this.ItemForStatusCode.Location = new System.Drawing.Point(406, 0);
            this.ItemForStatusCode.Name = "ItemForStatusCode";
            this.ItemForStatusCode.Size = new System.Drawing.Size(400, 24);
            this.ItemForStatusCode.TextSize = new System.Drawing.Size(157, 14);
            // 
            // ItemForPriorityCode
            // 
            this.ItemForPriorityCode.Control = this.PriorityCodeLookUpEdit;
            resources.ApplyResources(this.ItemForPriorityCode, "ItemForPriorityCode");
            this.ItemForPriorityCode.Location = new System.Drawing.Point(0, 0);
            this.ItemForPriorityCode.Name = "ItemForPriorityCode";
            this.ItemForPriorityCode.Size = new System.Drawing.Size(406, 24);
            this.ItemForPriorityCode.TextSize = new System.Drawing.Size(157, 14);
            // 
            // ItemForCompanyName
            // 
            this.ItemForCompanyName.Control = this.CompanyNameTextEdit;
            resources.ApplyResources(this.ItemForCompanyName, "ItemForCompanyName");
            this.ItemForCompanyName.Location = new System.Drawing.Point(415, 48);
            this.ItemForCompanyName.Name = "ItemForCompanyName";
            this.ItemForCompanyName.Size = new System.Drawing.Size(415, 24);
            this.ItemForCompanyName.TextSize = new System.Drawing.Size(157, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem1, "emptySpaceItem1");
            this.emptySpaceItem1.Location = new System.Drawing.Point(415, 96);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(415, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ItemForTechnology
            // 
            this.ItemForTechnology.Control = this.technologyCodeLookUpEdit;
            resources.ApplyResources(this.ItemForTechnology, "ItemForTechnology");
            this.ItemForTechnology.Location = new System.Drawing.Point(0, 96);
            this.ItemForTechnology.Name = "ItemForTechnology";
            this.ItemForTechnology.Size = new System.Drawing.Size(415, 24);
            this.ItemForTechnology.TextSize = new System.Drawing.Size(157, 14);
            // 
            // technologyCodeLookUpEdit
            // 
            this.technologyCodeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Technology", true));
            resources.ApplyResources(this.technologyCodeLookUpEdit, "technologyCodeLookUpEdit");
            this.technologyCodeLookUpEdit.Name = "technologyCodeLookUpEdit";
            this.technologyCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("technologyCodeLookUpEdit.Properties.Buttons"))))});
            this.technologyCodeLookUpEdit.Properties.MaxLength = 100;
            this.technologyCodeLookUpEdit.Properties.PopupSizeable = true;
            this.technologyCodeLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForLeadSourceCode
            // 
            this.ItemForLeadSourceCode.Control = this.LeadSourceCodeLookUpEdit;
            resources.ApplyResources(this.ItemForLeadSourceCode, "ItemForLeadSourceCode");
            this.ItemForLeadSourceCode.Location = new System.Drawing.Point(0, 48);
            this.ItemForLeadSourceCode.Name = "ItemForLeadSourceCode";
            this.ItemForLeadSourceCode.Size = new System.Drawing.Size(415, 24);
            this.ItemForLeadSourceCode.TextSize = new System.Drawing.Size(157, 14);
            // 
            // ItemForLastName
            // 
            this.ItemForLastName.Control = this.LastNameTextEdit;
            resources.ApplyResources(this.ItemForLastName, "ItemForLastName");
            this.ItemForLastName.Location = new System.Drawing.Point(0, 24);
            this.ItemForLastName.Name = "ItemForLastName";
            this.ItemForLastName.Size = new System.Drawing.Size(415, 24);
            this.ItemForLastName.TextSize = new System.Drawing.Size(157, 14);
            // 
            // itemForEmailResponseTime
            // 
            this.itemForEmailResponseTime.Control = this.emailResponseTimeDateEdit;
            resources.ApplyResources(this.itemForEmailResponseTime, "itemForEmailResponseTime");
            this.itemForEmailResponseTime.Location = new System.Drawing.Point(0, 72);
            this.itemForEmailResponseTime.Name = "itemForEmailResponseTime";
            this.itemForEmailResponseTime.Size = new System.Drawing.Size(415, 24);
            this.itemForEmailResponseTime.TextSize = new System.Drawing.Size(157, 14);
            // 
            // emailResponseTimeDateEdit
            // 
            this.emailResponseTimeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "FirstResponsedOn", true));
            resources.ApplyResources(this.emailResponseTimeDateEdit, "emailResponseTimeDateEdit");
            this.emailResponseTimeDateEdit.Name = "emailResponseTimeDateEdit";
            this.emailResponseTimeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("emailResponseTimeDateEdit.Properties.Buttons"))))});
            this.emailResponseTimeDateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.emailResponseTimeDateEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // itemForClosingTime
            // 
            this.itemForClosingTime.Control = this.closingTimeDateEdit;
            resources.ApplyResources(this.itemForClosingTime, "itemForClosingTime");
            this.itemForClosingTime.Location = new System.Drawing.Point(415, 72);
            this.itemForClosingTime.Name = "itemForClosingTime";
            this.itemForClosingTime.Size = new System.Drawing.Size(415, 24);
            this.itemForClosingTime.TextSize = new System.Drawing.Size(157, 14);
            // 
            // closingTimeDateEdit
            // 
            this.closingTimeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ClosedOn", true));
            resources.ApplyResources(this.closingTimeDateEdit, "closingTimeDateEdit");
            this.closingTimeDateEdit.Name = "closingTimeDateEdit";
            this.closingTimeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("closingTimeDateEdit.Properties.Buttons"))))});
            this.closingTimeDateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.closingTimeDateEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // managementLayoutControlGroup
            // 
            resources.ApplyResources(this.managementLayoutControlGroup, "managementLayoutControlGroup");
            this.managementLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem3,
            this.ItemForDepartmentId,
            this.ItemForOwnerId,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.managementLayoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.managementLayoutControlGroup.Name = "managementLayoutControlGroup";
            this.managementLayoutControlGroup.Size = new System.Drawing.Size(830, 597);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem3, "emptySpaceItem3");
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(830, 525);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ItemForDepartmentId
            // 
            this.ItemForDepartmentId.Control = this.DepartmentIdLookUpEdit;
            resources.ApplyResources(this.ItemForDepartmentId, "ItemForDepartmentId");
            this.ItemForDepartmentId.Location = new System.Drawing.Point(0, 0);
            this.ItemForDepartmentId.Name = "ItemForDepartmentId";
            this.ItemForDepartmentId.Size = new System.Drawing.Size(415, 24);
            this.ItemForDepartmentId.TextSize = new System.Drawing.Size(157, 14);
            // 
            // ItemForOwnerId
            // 
            this.ItemForOwnerId.Control = this.OwnerIdSearchLookUpEdit;
            resources.ApplyResources(this.ItemForOwnerId, "ItemForOwnerId");
            this.ItemForOwnerId.Location = new System.Drawing.Point(415, 0);
            this.ItemForOwnerId.Name = "ItemForOwnerId";
            this.ItemForOwnerId.Size = new System.Drawing.Size(415, 24);
            this.ItemForOwnerId.TextSize = new System.Drawing.Size(157, 14);
            // 
            // OwnerIdSearchLookUpEdit
            // 
            this.OwnerIdSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "OwnerId", true));
            resources.ApplyResources(this.OwnerIdSearchLookUpEdit, "OwnerIdSearchLookUpEdit");
            this.OwnerIdSearchLookUpEdit.Name = "OwnerIdSearchLookUpEdit";
            this.OwnerIdSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("OwnerIdSearchLookUpEdit.Properties.Buttons"))))});
            this.OwnerIdSearchLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textEdit1;
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(415, 24);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(157, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEdit2;
            resources.ApplyResources(this.layoutControlItem2, "layoutControlItem2");
            this.layoutControlItem2.Location = new System.Drawing.Point(415, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(415, 24);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(157, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.textEdit3;
            resources.ApplyResources(this.layoutControlItem3, "layoutControlItem3");
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(415, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(157, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.textEdit4;
            resources.ApplyResources(this.layoutControlItem4, "layoutControlItem4");
            this.layoutControlItem4.Location = new System.Drawing.Point(415, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(415, 24);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(157, 14);
            // 
            // LeadDetailView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "LeadDetailView";
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).EndInit();
            this.EntityDataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailAddressTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaxTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MobilePhoneTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RevenueTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubjectTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Telephone1TextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Telephone2TextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebSiteUrlTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfEmployeesSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeadSourceCodeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddressTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CityTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZIPTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentIdLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorityCodeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusCodeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalMessageTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountryLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infotabbedControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEmailAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForWebSiteUrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForZIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTelephone2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMobilePhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTelephone1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailsGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNumberOfEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRevenue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOriginalMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPriorityCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCompanyName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTechnology)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.technologyCodeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLeadSourceCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForEmailResponseTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailResponseTimeDateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailResponseTimeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForClosingTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closingTimeDateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closingTimeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.managementLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDepartmentId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOwnerId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OwnerIdSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit CompanyNameTextEdit;
        private DevExpress.XtraEditors.TextEdit EmailAddressTextEdit;
        private DevExpress.XtraEditors.TextEdit FaxTextEdit;
        private DevExpress.XtraEditors.TextEdit FirstNameTextEdit;
        private DevExpress.XtraEditors.TextEdit LastNameTextEdit;
        private DevExpress.XtraEditors.TextEdit MobilePhoneTextEdit;
        private DevExpress.XtraEditors.TextEdit RevenueTextEdit;
        private DevExpress.XtraEditors.TextEdit SubjectTextEdit;
        private DevExpress.XtraEditors.TextEdit Telephone1TextEdit;
        private DevExpress.XtraEditors.TextEdit Telephone2TextEdit;
        private DevExpress.XtraEditors.TextEdit WebSiteUrlTextEdit;
        private DevExpress.XtraEditors.MemoEdit DescriptionMemoEdit;
        private DevExpress.XtraEditors.SpinEdit NumberOfEmployeesSpinEdit;
        private DevExpress.XtraEditors.LookUpEdit LeadSourceCodeLookUpEdit;
        private DevExpress.XtraEditors.TextEdit AddressTextEdit;
        private DevExpress.XtraEditors.TextEdit CityTextEdit;
        private DevExpress.XtraEditors.TextEdit ZIPTextEdit;
        private DevExpress.XtraEditors.LookUpEdit DepartmentIdLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit StatusCodeLookUpEdit;
        private DevExpress.XtraEditors.TextEdit OriginalMessageTextEdit;
        private DevExpress.XtraEditors.LookUpEdit PriorityCodeLookUpEdit;
        private DevExpress.XtraEditors.ComboBoxEdit CountryLookUpEdit;
        private DevExpress.XtraEditors.TextEdit textEdit4;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.TabbedControlGroup infotabbedControlGroup;
        private DevExpress.XtraLayout.LayoutControlGroup lcgGeneral;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSubject;
        private DevExpress.XtraLayout.LayoutControlItem ItemForFirstName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLeadSourceCode;
        private DevExpress.XtraLayout.LayoutControlGroup contactGroup;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEmailAddress;
        private DevExpress.XtraLayout.LayoutControlItem ItemForWebSiteUrl;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCountry;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCity;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAddress;
        private DevExpress.XtraLayout.LayoutControlItem ItemForZIP;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTelephone2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMobilePhone;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTelephone1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForFax;
        private DevExpress.XtraLayout.LayoutControlGroup detailsGroup;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNumberOfEmployees;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRevenue;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOriginalMessage;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStatusCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPriorityCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCompanyName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLastName;
        private DevExpress.XtraLayout.LayoutControlGroup managementLayoutControlGroup;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDepartmentId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOwnerId;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.PopupContainerEdit OwnerIdSearchLookUpEdit;
        private DevExpress.XtraEditors.ComboBoxEdit technologyCodeLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTechnology;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DropDownDateEdit closingTimeDateEdit;
        private DropDownDateEdit emailResponseTimeDateEdit;
        private DevExpress.XtraLayout.LayoutControlItem itemForEmailResponseTime;
        private DevExpress.XtraLayout.LayoutControlItem itemForClosingTime;

    }
}
