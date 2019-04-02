using Katrin.AppFramework.WinForms.Controls;
using System.Windows.Forms;
using System;
namespace Katrin.Win.ContactModule.Detail
{
    partial class ContactDetailView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactDetailView));
            this.AssistantNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.AssistantPhoneTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DepartmentTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.EMailAddress1TextEdit = new DevExpress.XtraEditors.TextEdit();
            this.EmployeeIdTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.FaxTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.FirstNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.JobTitleTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.LastNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ManagerNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ManangerPhoneTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.MobilePhoneTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.NickNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.SpousesNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.SuffixTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.Telephone1TextEdit = new DevExpress.XtraEditors.TextEdit();
            this.Telephone2TextEdit = new DevExpress.XtraEditors.TextEdit();
            this.BirthDateTextEdit = new Katrin.AppFramework.WinForms.Controls.DropDownDateEdit();
            this.AnniversaryTextEdit = new Katrin.AppFramework.WinForms.Controls.DropDownDateEdit();
            this.NumberOfChildrenTextEdit = new DevExpress.XtraEditors.SpinEdit();
            this.AccountRoleCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.GenderCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.HasChildrenCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.EducationCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.FamilyStatusCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.DescriptionTextEdit = new DevExpress.XtraEditors.MemoEdit();
            this.OriginatingLeadIdLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.ParentCustomerIdLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.managementLayoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForOwnerId = new DevExpress.XtraLayout.LayoutControlItem();
            this.OwnerIdLookUpEdit = new DevExpress.XtraEditors.PopupContainerEdit();
            this.ItemForOriginatingLeadId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDepartment = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgGeneral = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForTelephone1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForMobilePhone = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForEMailAddress1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgProfessinal = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForManagerName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForManangerPhone = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAssistantName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAccountRoleCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAssistantPhone = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForParentCustomerId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForEmployeeId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForJobTitle = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForLastName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForNickName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSuffix = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTelephone2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForFax = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForFirstName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgPersonal = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForGenderCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForBirthDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForFamilyStatusCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAnniversary = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForNumberOfChildren = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForHasChildrenCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSpousesName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForEducationCode = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).BeginInit();
            this.EntityDataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AssistantNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AssistantPhoneTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EMailAddress1TextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeIdTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaxTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JobTitleTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManagerNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManangerPhoneTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MobilePhoneTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NickNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpousesNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SuffixTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Telephone1TextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Telephone2TextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BirthDateTextEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BirthDateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnniversaryTextEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnniversaryTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfChildrenTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountRoleCodeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GenderCodeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HasChildrenCodeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EducationCodeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FamilyStatusCodeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginatingLeadIdLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParentCustomerIdLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.managementLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOwnerId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OwnerIdLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOriginatingLeadId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTelephone1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMobilePhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEMailAddress1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgProfessinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForManagerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForManangerPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAssistantName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccountRoleCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAssistantPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForParentCustomerId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEmployeeId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForJobTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNickName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSuffix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTelephone2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPersonal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGenderCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBirthDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFamilyStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAnniversary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNumberOfChildren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForHasChildrenCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSpousesName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEducationCode)).BeginInit();
            this.SuspendLayout();
            // 
            // EntityDataLayoutControl
            // 
            resources.ApplyResources(this.EntityDataLayoutControl, "EntityDataLayoutControl");
            this.EntityDataLayoutControl.Controls.Add(this.textEdit4);
            this.EntityDataLayoutControl.Controls.Add(this.AssistantNameTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit3);
            this.EntityDataLayoutControl.Controls.Add(this.AssistantPhoneTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit2);
            this.EntityDataLayoutControl.Controls.Add(this.DepartmentTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit1);
            this.EntityDataLayoutControl.Controls.Add(this.EMailAddress1TextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.EmployeeIdTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.FaxTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.FirstNameTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.JobTitleTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.LastNameTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.ManagerNameTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.ManangerPhoneTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.MobilePhoneTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.NickNameTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.SpousesNameTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.SuffixTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.Telephone1TextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.Telephone2TextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.BirthDateTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.AnniversaryTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.NumberOfChildrenTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.AccountRoleCodeLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.GenderCodeLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.HasChildrenCodeLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.EducationCodeLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.FamilyStatusCodeLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.DescriptionTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.OriginatingLeadIdLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.ParentCustomerIdLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.OwnerIdLookUpEdit);
            this.EntityDataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(578, 129, 456, 477);
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
            this.RootLayoutControlGroup.Size = new System.Drawing.Size(948, 440);
            // 
            // AssistantNameTextEdit
            // 
            resources.ApplyResources(this.AssistantNameTextEdit, "AssistantNameTextEdit");
            this.AssistantNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "AssistantName", true));
            this.AssistantNameTextEdit.Name = "AssistantNameTextEdit";
            this.AssistantNameTextEdit.Properties.AccessibleDescription = resources.GetString("AssistantNameTextEdit.Properties.AccessibleDescription");
            this.AssistantNameTextEdit.Properties.AccessibleName = resources.GetString("AssistantNameTextEdit.Properties.AccessibleName");
            this.AssistantNameTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("AssistantNameTextEdit.Properties.AutoHeight")));
            this.AssistantNameTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("AssistantNameTextEdit.Properties.Mask.AutoComplete")));
            this.AssistantNameTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("AssistantNameTextEdit.Properties.Mask.BeepOnError")));
            this.AssistantNameTextEdit.Properties.Mask.EditMask = resources.GetString("AssistantNameTextEdit.Properties.Mask.EditMask");
            this.AssistantNameTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("AssistantNameTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.AssistantNameTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("AssistantNameTextEdit.Properties.Mask.MaskType")));
            this.AssistantNameTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("AssistantNameTextEdit.Properties.Mask.PlaceHolder")));
            this.AssistantNameTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("AssistantNameTextEdit.Properties.Mask.SaveLiteral")));
            this.AssistantNameTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("AssistantNameTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.AssistantNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("AssistantNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.AssistantNameTextEdit.Properties.NullValuePrompt = resources.GetString("AssistantNameTextEdit.Properties.NullValuePrompt");
            this.AssistantNameTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("AssistantNameTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.AssistantNameTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // AssistantPhoneTextEdit
            // 
            resources.ApplyResources(this.AssistantPhoneTextEdit, "AssistantPhoneTextEdit");
            this.AssistantPhoneTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "AssistantPhone", true));
            this.AssistantPhoneTextEdit.Name = "AssistantPhoneTextEdit";
            this.AssistantPhoneTextEdit.Properties.AccessibleDescription = resources.GetString("AssistantPhoneTextEdit.Properties.AccessibleDescription");
            this.AssistantPhoneTextEdit.Properties.AccessibleName = resources.GetString("AssistantPhoneTextEdit.Properties.AccessibleName");
            this.AssistantPhoneTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("AssistantPhoneTextEdit.Properties.AutoHeight")));
            this.AssistantPhoneTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("AssistantPhoneTextEdit.Properties.Mask.AutoComplete")));
            this.AssistantPhoneTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("AssistantPhoneTextEdit.Properties.Mask.BeepOnError")));
            this.AssistantPhoneTextEdit.Properties.Mask.EditMask = resources.GetString("AssistantPhoneTextEdit.Properties.Mask.EditMask");
            this.AssistantPhoneTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("AssistantPhoneTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.AssistantPhoneTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("AssistantPhoneTextEdit.Properties.Mask.MaskType")));
            this.AssistantPhoneTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("AssistantPhoneTextEdit.Properties.Mask.PlaceHolder")));
            this.AssistantPhoneTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("AssistantPhoneTextEdit.Properties.Mask.SaveLiteral")));
            this.AssistantPhoneTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("AssistantPhoneTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.AssistantPhoneTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("AssistantPhoneTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.AssistantPhoneTextEdit.Properties.NullValuePrompt = resources.GetString("AssistantPhoneTextEdit.Properties.NullValuePrompt");
            this.AssistantPhoneTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("AssistantPhoneTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.AssistantPhoneTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // DepartmentTextEdit
            // 
            resources.ApplyResources(this.DepartmentTextEdit, "DepartmentTextEdit");
            this.DepartmentTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Department", true));
            this.DepartmentTextEdit.Name = "DepartmentTextEdit";
            this.DepartmentTextEdit.Properties.AccessibleDescription = resources.GetString("DepartmentTextEdit.Properties.AccessibleDescription");
            this.DepartmentTextEdit.Properties.AccessibleName = resources.GetString("DepartmentTextEdit.Properties.AccessibleName");
            this.DepartmentTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("DepartmentTextEdit.Properties.AutoHeight")));
            this.DepartmentTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("DepartmentTextEdit.Properties.Mask.AutoComplete")));
            this.DepartmentTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("DepartmentTextEdit.Properties.Mask.BeepOnError")));
            this.DepartmentTextEdit.Properties.Mask.EditMask = resources.GetString("DepartmentTextEdit.Properties.Mask.EditMask");
            this.DepartmentTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("DepartmentTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.DepartmentTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("DepartmentTextEdit.Properties.Mask.MaskType")));
            this.DepartmentTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("DepartmentTextEdit.Properties.Mask.PlaceHolder")));
            this.DepartmentTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("DepartmentTextEdit.Properties.Mask.SaveLiteral")));
            this.DepartmentTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("DepartmentTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.DepartmentTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("DepartmentTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.DepartmentTextEdit.Properties.NullValuePrompt = resources.GetString("DepartmentTextEdit.Properties.NullValuePrompt");
            this.DepartmentTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("DepartmentTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.DepartmentTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // EMailAddress1TextEdit
            // 
            resources.ApplyResources(this.EMailAddress1TextEdit, "EMailAddress1TextEdit");
            this.EMailAddress1TextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "EMailAddress1", true));
            this.EMailAddress1TextEdit.Name = "EMailAddress1TextEdit";
            this.EMailAddress1TextEdit.Properties.AccessibleDescription = resources.GetString("EMailAddress1TextEdit.Properties.AccessibleDescription");
            this.EMailAddress1TextEdit.Properties.AccessibleName = resources.GetString("EMailAddress1TextEdit.Properties.AccessibleName");
            this.EMailAddress1TextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("EMailAddress1TextEdit.Properties.AutoHeight")));
            this.EMailAddress1TextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("EMailAddress1TextEdit.Properties.Mask.AutoComplete")));
            this.EMailAddress1TextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("EMailAddress1TextEdit.Properties.Mask.BeepOnError")));
            this.EMailAddress1TextEdit.Properties.Mask.EditMask = resources.GetString("EMailAddress1TextEdit.Properties.Mask.EditMask");
            this.EMailAddress1TextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("EMailAddress1TextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.EMailAddress1TextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("EMailAddress1TextEdit.Properties.Mask.MaskType")));
            this.EMailAddress1TextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("EMailAddress1TextEdit.Properties.Mask.PlaceHolder")));
            this.EMailAddress1TextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("EMailAddress1TextEdit.Properties.Mask.SaveLiteral")));
            this.EMailAddress1TextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("EMailAddress1TextEdit.Properties.Mask.ShowPlaceHolders")));
            this.EMailAddress1TextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("EMailAddress1TextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.EMailAddress1TextEdit.Properties.NullValuePrompt = resources.GetString("EMailAddress1TextEdit.Properties.NullValuePrompt");
            this.EMailAddress1TextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("EMailAddress1TextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.EMailAddress1TextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // EmployeeIdTextEdit
            // 
            resources.ApplyResources(this.EmployeeIdTextEdit, "EmployeeIdTextEdit");
            this.EmployeeIdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "EmployeeId", true));
            this.EmployeeIdTextEdit.Name = "EmployeeIdTextEdit";
            this.EmployeeIdTextEdit.Properties.AccessibleDescription = resources.GetString("EmployeeIdTextEdit.Properties.AccessibleDescription");
            this.EmployeeIdTextEdit.Properties.AccessibleName = resources.GetString("EmployeeIdTextEdit.Properties.AccessibleName");
            this.EmployeeIdTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("EmployeeIdTextEdit.Properties.AutoHeight")));
            this.EmployeeIdTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("EmployeeIdTextEdit.Properties.Mask.AutoComplete")));
            this.EmployeeIdTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("EmployeeIdTextEdit.Properties.Mask.BeepOnError")));
            this.EmployeeIdTextEdit.Properties.Mask.EditMask = resources.GetString("EmployeeIdTextEdit.Properties.Mask.EditMask");
            this.EmployeeIdTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("EmployeeIdTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.EmployeeIdTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("EmployeeIdTextEdit.Properties.Mask.MaskType")));
            this.EmployeeIdTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("EmployeeIdTextEdit.Properties.Mask.PlaceHolder")));
            this.EmployeeIdTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("EmployeeIdTextEdit.Properties.Mask.SaveLiteral")));
            this.EmployeeIdTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("EmployeeIdTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.EmployeeIdTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("EmployeeIdTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.EmployeeIdTextEdit.Properties.NullValuePrompt = resources.GetString("EmployeeIdTextEdit.Properties.NullValuePrompt");
            this.EmployeeIdTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("EmployeeIdTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.EmployeeIdTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // FaxTextEdit
            // 
            resources.ApplyResources(this.FaxTextEdit, "FaxTextEdit");
            this.FaxTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Fax", true));
            this.FaxTextEdit.Name = "FaxTextEdit";
            this.FaxTextEdit.Properties.AccessibleDescription = resources.GetString("FaxTextEdit.Properties.AccessibleDescription");
            this.FaxTextEdit.Properties.AccessibleName = resources.GetString("FaxTextEdit.Properties.AccessibleName");
            this.FaxTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("FaxTextEdit.Properties.AutoHeight")));
            this.FaxTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("FaxTextEdit.Properties.Mask.AutoComplete")));
            this.FaxTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("FaxTextEdit.Properties.Mask.BeepOnError")));
            this.FaxTextEdit.Properties.Mask.EditMask = resources.GetString("FaxTextEdit.Properties.Mask.EditMask");
            this.FaxTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("FaxTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.FaxTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("FaxTextEdit.Properties.Mask.MaskType")));
            this.FaxTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("FaxTextEdit.Properties.Mask.PlaceHolder")));
            this.FaxTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("FaxTextEdit.Properties.Mask.SaveLiteral")));
            this.FaxTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("FaxTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.FaxTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("FaxTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.FaxTextEdit.Properties.NullValuePrompt = resources.GetString("FaxTextEdit.Properties.NullValuePrompt");
            this.FaxTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("FaxTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.FaxTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // FirstNameTextEdit
            // 
            resources.ApplyResources(this.FirstNameTextEdit, "FirstNameTextEdit");
            this.FirstNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "FirstName", true));
            this.FirstNameTextEdit.Name = "FirstNameTextEdit";
            this.FirstNameTextEdit.Properties.AccessibleDescription = resources.GetString("FirstNameTextEdit.Properties.AccessibleDescription");
            this.FirstNameTextEdit.Properties.AccessibleName = resources.GetString("FirstNameTextEdit.Properties.AccessibleName");
            this.FirstNameTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("FirstNameTextEdit.Properties.AutoHeight")));
            this.FirstNameTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("FirstNameTextEdit.Properties.Mask.AutoComplete")));
            this.FirstNameTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("FirstNameTextEdit.Properties.Mask.BeepOnError")));
            this.FirstNameTextEdit.Properties.Mask.EditMask = resources.GetString("FirstNameTextEdit.Properties.Mask.EditMask");
            this.FirstNameTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("FirstNameTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.FirstNameTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("FirstNameTextEdit.Properties.Mask.MaskType")));
            this.FirstNameTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("FirstNameTextEdit.Properties.Mask.PlaceHolder")));
            this.FirstNameTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("FirstNameTextEdit.Properties.Mask.SaveLiteral")));
            this.FirstNameTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("FirstNameTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.FirstNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("FirstNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.FirstNameTextEdit.Properties.NullValuePrompt = resources.GetString("FirstNameTextEdit.Properties.NullValuePrompt");
            this.FirstNameTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("FirstNameTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.FirstNameTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // JobTitleTextEdit
            // 
            resources.ApplyResources(this.JobTitleTextEdit, "JobTitleTextEdit");
            this.JobTitleTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "JobTitle", true));
            this.JobTitleTextEdit.Name = "JobTitleTextEdit";
            this.JobTitleTextEdit.Properties.AccessibleDescription = resources.GetString("JobTitleTextEdit.Properties.AccessibleDescription");
            this.JobTitleTextEdit.Properties.AccessibleName = resources.GetString("JobTitleTextEdit.Properties.AccessibleName");
            this.JobTitleTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("JobTitleTextEdit.Properties.AutoHeight")));
            this.JobTitleTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("JobTitleTextEdit.Properties.Mask.AutoComplete")));
            this.JobTitleTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("JobTitleTextEdit.Properties.Mask.BeepOnError")));
            this.JobTitleTextEdit.Properties.Mask.EditMask = resources.GetString("JobTitleTextEdit.Properties.Mask.EditMask");
            this.JobTitleTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("JobTitleTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.JobTitleTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("JobTitleTextEdit.Properties.Mask.MaskType")));
            this.JobTitleTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("JobTitleTextEdit.Properties.Mask.PlaceHolder")));
            this.JobTitleTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("JobTitleTextEdit.Properties.Mask.SaveLiteral")));
            this.JobTitleTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("JobTitleTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.JobTitleTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("JobTitleTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.JobTitleTextEdit.Properties.NullValuePrompt = resources.GetString("JobTitleTextEdit.Properties.NullValuePrompt");
            this.JobTitleTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("JobTitleTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.JobTitleTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // LastNameTextEdit
            // 
            resources.ApplyResources(this.LastNameTextEdit, "LastNameTextEdit");
            this.LastNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "LastName", true));
            this.LastNameTextEdit.Name = "LastNameTextEdit";
            this.LastNameTextEdit.Properties.AccessibleDescription = resources.GetString("LastNameTextEdit.Properties.AccessibleDescription");
            this.LastNameTextEdit.Properties.AccessibleName = resources.GetString("LastNameTextEdit.Properties.AccessibleName");
            this.LastNameTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("LastNameTextEdit.Properties.AutoHeight")));
            this.LastNameTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("LastNameTextEdit.Properties.Mask.AutoComplete")));
            this.LastNameTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("LastNameTextEdit.Properties.Mask.BeepOnError")));
            this.LastNameTextEdit.Properties.Mask.EditMask = resources.GetString("LastNameTextEdit.Properties.Mask.EditMask");
            this.LastNameTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("LastNameTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.LastNameTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("LastNameTextEdit.Properties.Mask.MaskType")));
            this.LastNameTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("LastNameTextEdit.Properties.Mask.PlaceHolder")));
            this.LastNameTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("LastNameTextEdit.Properties.Mask.SaveLiteral")));
            this.LastNameTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("LastNameTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.LastNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("LastNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.LastNameTextEdit.Properties.NullValuePrompt = resources.GetString("LastNameTextEdit.Properties.NullValuePrompt");
            this.LastNameTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("LastNameTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.LastNameTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ManagerNameTextEdit
            // 
            resources.ApplyResources(this.ManagerNameTextEdit, "ManagerNameTextEdit");
            this.ManagerNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ManagerName", true));
            this.ManagerNameTextEdit.Name = "ManagerNameTextEdit";
            this.ManagerNameTextEdit.Properties.AccessibleDescription = resources.GetString("ManagerNameTextEdit.Properties.AccessibleDescription");
            this.ManagerNameTextEdit.Properties.AccessibleName = resources.GetString("ManagerNameTextEdit.Properties.AccessibleName");
            this.ManagerNameTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("ManagerNameTextEdit.Properties.AutoHeight")));
            this.ManagerNameTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("ManagerNameTextEdit.Properties.Mask.AutoComplete")));
            this.ManagerNameTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("ManagerNameTextEdit.Properties.Mask.BeepOnError")));
            this.ManagerNameTextEdit.Properties.Mask.EditMask = resources.GetString("ManagerNameTextEdit.Properties.Mask.EditMask");
            this.ManagerNameTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("ManagerNameTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.ManagerNameTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("ManagerNameTextEdit.Properties.Mask.MaskType")));
            this.ManagerNameTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("ManagerNameTextEdit.Properties.Mask.PlaceHolder")));
            this.ManagerNameTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("ManagerNameTextEdit.Properties.Mask.SaveLiteral")));
            this.ManagerNameTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("ManagerNameTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.ManagerNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("ManagerNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.ManagerNameTextEdit.Properties.NullValuePrompt = resources.GetString("ManagerNameTextEdit.Properties.NullValuePrompt");
            this.ManagerNameTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("ManagerNameTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.ManagerNameTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ManangerPhoneTextEdit
            // 
            resources.ApplyResources(this.ManangerPhoneTextEdit, "ManangerPhoneTextEdit");
            this.ManangerPhoneTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ManangerPhone", true));
            this.ManangerPhoneTextEdit.Name = "ManangerPhoneTextEdit";
            this.ManangerPhoneTextEdit.Properties.AccessibleDescription = resources.GetString("ManangerPhoneTextEdit.Properties.AccessibleDescription");
            this.ManangerPhoneTextEdit.Properties.AccessibleName = resources.GetString("ManangerPhoneTextEdit.Properties.AccessibleName");
            this.ManangerPhoneTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("ManangerPhoneTextEdit.Properties.AutoHeight")));
            this.ManangerPhoneTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("ManangerPhoneTextEdit.Properties.Mask.AutoComplete")));
            this.ManangerPhoneTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("ManangerPhoneTextEdit.Properties.Mask.BeepOnError")));
            this.ManangerPhoneTextEdit.Properties.Mask.EditMask = resources.GetString("ManangerPhoneTextEdit.Properties.Mask.EditMask");
            this.ManangerPhoneTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("ManangerPhoneTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.ManangerPhoneTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("ManangerPhoneTextEdit.Properties.Mask.MaskType")));
            this.ManangerPhoneTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("ManangerPhoneTextEdit.Properties.Mask.PlaceHolder")));
            this.ManangerPhoneTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("ManangerPhoneTextEdit.Properties.Mask.SaveLiteral")));
            this.ManangerPhoneTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("ManangerPhoneTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.ManangerPhoneTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("ManangerPhoneTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.ManangerPhoneTextEdit.Properties.NullValuePrompt = resources.GetString("ManangerPhoneTextEdit.Properties.NullValuePrompt");
            this.ManangerPhoneTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("ManangerPhoneTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.ManangerPhoneTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // MobilePhoneTextEdit
            // 
            resources.ApplyResources(this.MobilePhoneTextEdit, "MobilePhoneTextEdit");
            this.MobilePhoneTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "MobilePhone", true));
            this.MobilePhoneTextEdit.Name = "MobilePhoneTextEdit";
            this.MobilePhoneTextEdit.Properties.AccessibleDescription = resources.GetString("MobilePhoneTextEdit.Properties.AccessibleDescription");
            this.MobilePhoneTextEdit.Properties.AccessibleName = resources.GetString("MobilePhoneTextEdit.Properties.AccessibleName");
            this.MobilePhoneTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("MobilePhoneTextEdit.Properties.AutoHeight")));
            this.MobilePhoneTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("MobilePhoneTextEdit.Properties.Mask.AutoComplete")));
            this.MobilePhoneTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("MobilePhoneTextEdit.Properties.Mask.BeepOnError")));
            this.MobilePhoneTextEdit.Properties.Mask.EditMask = resources.GetString("MobilePhoneTextEdit.Properties.Mask.EditMask");
            this.MobilePhoneTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("MobilePhoneTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.MobilePhoneTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("MobilePhoneTextEdit.Properties.Mask.MaskType")));
            this.MobilePhoneTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("MobilePhoneTextEdit.Properties.Mask.PlaceHolder")));
            this.MobilePhoneTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("MobilePhoneTextEdit.Properties.Mask.SaveLiteral")));
            this.MobilePhoneTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("MobilePhoneTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.MobilePhoneTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("MobilePhoneTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.MobilePhoneTextEdit.Properties.NullValuePrompt = resources.GetString("MobilePhoneTextEdit.Properties.NullValuePrompt");
            this.MobilePhoneTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("MobilePhoneTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.MobilePhoneTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // NickNameTextEdit
            // 
            resources.ApplyResources(this.NickNameTextEdit, "NickNameTextEdit");
            this.NickNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "NickName", true));
            this.NickNameTextEdit.Name = "NickNameTextEdit";
            this.NickNameTextEdit.Properties.AccessibleDescription = resources.GetString("NickNameTextEdit.Properties.AccessibleDescription");
            this.NickNameTextEdit.Properties.AccessibleName = resources.GetString("NickNameTextEdit.Properties.AccessibleName");
            this.NickNameTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("NickNameTextEdit.Properties.AutoHeight")));
            this.NickNameTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("NickNameTextEdit.Properties.Mask.AutoComplete")));
            this.NickNameTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("NickNameTextEdit.Properties.Mask.BeepOnError")));
            this.NickNameTextEdit.Properties.Mask.EditMask = resources.GetString("NickNameTextEdit.Properties.Mask.EditMask");
            this.NickNameTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("NickNameTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.NickNameTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("NickNameTextEdit.Properties.Mask.MaskType")));
            this.NickNameTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("NickNameTextEdit.Properties.Mask.PlaceHolder")));
            this.NickNameTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("NickNameTextEdit.Properties.Mask.SaveLiteral")));
            this.NickNameTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("NickNameTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.NickNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("NickNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.NickNameTextEdit.Properties.NullValuePrompt = resources.GetString("NickNameTextEdit.Properties.NullValuePrompt");
            this.NickNameTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("NickNameTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.NickNameTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // SpousesNameTextEdit
            // 
            resources.ApplyResources(this.SpousesNameTextEdit, "SpousesNameTextEdit");
            this.SpousesNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "SpousesName", true));
            this.SpousesNameTextEdit.Name = "SpousesNameTextEdit";
            this.SpousesNameTextEdit.Properties.AccessibleDescription = resources.GetString("SpousesNameTextEdit.Properties.AccessibleDescription");
            this.SpousesNameTextEdit.Properties.AccessibleName = resources.GetString("SpousesNameTextEdit.Properties.AccessibleName");
            this.SpousesNameTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("SpousesNameTextEdit.Properties.AutoHeight")));
            this.SpousesNameTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("SpousesNameTextEdit.Properties.Mask.AutoComplete")));
            this.SpousesNameTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("SpousesNameTextEdit.Properties.Mask.BeepOnError")));
            this.SpousesNameTextEdit.Properties.Mask.EditMask = resources.GetString("SpousesNameTextEdit.Properties.Mask.EditMask");
            this.SpousesNameTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("SpousesNameTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.SpousesNameTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("SpousesNameTextEdit.Properties.Mask.MaskType")));
            this.SpousesNameTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("SpousesNameTextEdit.Properties.Mask.PlaceHolder")));
            this.SpousesNameTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("SpousesNameTextEdit.Properties.Mask.SaveLiteral")));
            this.SpousesNameTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("SpousesNameTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.SpousesNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("SpousesNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.SpousesNameTextEdit.Properties.NullValuePrompt = resources.GetString("SpousesNameTextEdit.Properties.NullValuePrompt");
            this.SpousesNameTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("SpousesNameTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.SpousesNameTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // SuffixTextEdit
            // 
            resources.ApplyResources(this.SuffixTextEdit, "SuffixTextEdit");
            this.SuffixTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Suffix", true));
            this.SuffixTextEdit.Name = "SuffixTextEdit";
            this.SuffixTextEdit.Properties.AccessibleDescription = resources.GetString("SuffixTextEdit.Properties.AccessibleDescription");
            this.SuffixTextEdit.Properties.AccessibleName = resources.GetString("SuffixTextEdit.Properties.AccessibleName");
            this.SuffixTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("SuffixTextEdit.Properties.AutoHeight")));
            this.SuffixTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("SuffixTextEdit.Properties.Mask.AutoComplete")));
            this.SuffixTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("SuffixTextEdit.Properties.Mask.BeepOnError")));
            this.SuffixTextEdit.Properties.Mask.EditMask = resources.GetString("SuffixTextEdit.Properties.Mask.EditMask");
            this.SuffixTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("SuffixTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.SuffixTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("SuffixTextEdit.Properties.Mask.MaskType")));
            this.SuffixTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("SuffixTextEdit.Properties.Mask.PlaceHolder")));
            this.SuffixTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("SuffixTextEdit.Properties.Mask.SaveLiteral")));
            this.SuffixTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("SuffixTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.SuffixTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("SuffixTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.SuffixTextEdit.Properties.NullValuePrompt = resources.GetString("SuffixTextEdit.Properties.NullValuePrompt");
            this.SuffixTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("SuffixTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.SuffixTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // Telephone1TextEdit
            // 
            resources.ApplyResources(this.Telephone1TextEdit, "Telephone1TextEdit");
            this.Telephone1TextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Telephone1", true));
            this.Telephone1TextEdit.Name = "Telephone1TextEdit";
            this.Telephone1TextEdit.Properties.AccessibleDescription = resources.GetString("Telephone1TextEdit.Properties.AccessibleDescription");
            this.Telephone1TextEdit.Properties.AccessibleName = resources.GetString("Telephone1TextEdit.Properties.AccessibleName");
            this.Telephone1TextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("Telephone1TextEdit.Properties.AutoHeight")));
            this.Telephone1TextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("Telephone1TextEdit.Properties.Mask.AutoComplete")));
            this.Telephone1TextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("Telephone1TextEdit.Properties.Mask.BeepOnError")));
            this.Telephone1TextEdit.Properties.Mask.EditMask = resources.GetString("Telephone1TextEdit.Properties.Mask.EditMask");
            this.Telephone1TextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("Telephone1TextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.Telephone1TextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("Telephone1TextEdit.Properties.Mask.MaskType")));
            this.Telephone1TextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("Telephone1TextEdit.Properties.Mask.PlaceHolder")));
            this.Telephone1TextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("Telephone1TextEdit.Properties.Mask.SaveLiteral")));
            this.Telephone1TextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("Telephone1TextEdit.Properties.Mask.ShowPlaceHolders")));
            this.Telephone1TextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("Telephone1TextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.Telephone1TextEdit.Properties.NullValuePrompt = resources.GetString("Telephone1TextEdit.Properties.NullValuePrompt");
            this.Telephone1TextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("Telephone1TextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.Telephone1TextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // Telephone2TextEdit
            // 
            resources.ApplyResources(this.Telephone2TextEdit, "Telephone2TextEdit");
            this.Telephone2TextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Telephone2", true));
            this.Telephone2TextEdit.Name = "Telephone2TextEdit";
            this.Telephone2TextEdit.Properties.AccessibleDescription = resources.GetString("Telephone2TextEdit.Properties.AccessibleDescription");
            this.Telephone2TextEdit.Properties.AccessibleName = resources.GetString("Telephone2TextEdit.Properties.AccessibleName");
            this.Telephone2TextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("Telephone2TextEdit.Properties.AutoHeight")));
            this.Telephone2TextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("Telephone2TextEdit.Properties.Mask.AutoComplete")));
            this.Telephone2TextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("Telephone2TextEdit.Properties.Mask.BeepOnError")));
            this.Telephone2TextEdit.Properties.Mask.EditMask = resources.GetString("Telephone2TextEdit.Properties.Mask.EditMask");
            this.Telephone2TextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("Telephone2TextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.Telephone2TextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("Telephone2TextEdit.Properties.Mask.MaskType")));
            this.Telephone2TextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("Telephone2TextEdit.Properties.Mask.PlaceHolder")));
            this.Telephone2TextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("Telephone2TextEdit.Properties.Mask.SaveLiteral")));
            this.Telephone2TextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("Telephone2TextEdit.Properties.Mask.ShowPlaceHolders")));
            this.Telephone2TextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("Telephone2TextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.Telephone2TextEdit.Properties.NullValuePrompt = resources.GetString("Telephone2TextEdit.Properties.NullValuePrompt");
            this.Telephone2TextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("Telephone2TextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.Telephone2TextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // BirthDateTextEdit
            // 
            resources.ApplyResources(this.BirthDateTextEdit, "BirthDateTextEdit");
            this.BirthDateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "BirthDate", true));
            this.BirthDateTextEdit.Name = "BirthDateTextEdit";
            this.BirthDateTextEdit.Properties.AccessibleDescription = resources.GetString("BirthDateTextEdit.Properties.AccessibleDescription");
            this.BirthDateTextEdit.Properties.AccessibleName = resources.GetString("BirthDateTextEdit.Properties.AccessibleName");
            this.BirthDateTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("BirthDateTextEdit.Properties.AutoHeight")));
            this.BirthDateTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("BirthDateTextEdit.Properties.Buttons"))))});
            this.BirthDateTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("BirthDateTextEdit.Properties.Mask.AutoComplete")));
            this.BirthDateTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("BirthDateTextEdit.Properties.Mask.BeepOnError")));
            this.BirthDateTextEdit.Properties.Mask.EditMask = resources.GetString("BirthDateTextEdit.Properties.Mask.EditMask");
            this.BirthDateTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("BirthDateTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.BirthDateTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("BirthDateTextEdit.Properties.Mask.MaskType")));
            this.BirthDateTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("BirthDateTextEdit.Properties.Mask.PlaceHolder")));
            this.BirthDateTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("BirthDateTextEdit.Properties.Mask.SaveLiteral")));
            this.BirthDateTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("BirthDateTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.BirthDateTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("BirthDateTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.BirthDateTextEdit.Properties.NullValuePrompt = resources.GetString("BirthDateTextEdit.Properties.NullValuePrompt");
            this.BirthDateTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("BirthDateTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.BirthDateTextEdit.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("BirthDateTextEdit.Properties.VistaTimeProperties.AccessibleDescription");
            this.BirthDateTextEdit.Properties.VistaTimeProperties.AccessibleName = resources.GetString("BirthDateTextEdit.Properties.VistaTimeProperties.AccessibleName");
            this.BirthDateTextEdit.Properties.VistaTimeProperties.AutoHeight = ((bool)(resources.GetObject("BirthDateTextEdit.Properties.VistaTimeProperties.AutoHeight")));
            this.BirthDateTextEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.BirthDateTextEdit.Properties.VistaTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("BirthDateTextEdit.Properties.VistaTimeProperties.Mask.AutoComplete")));
            this.BirthDateTextEdit.Properties.VistaTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("BirthDateTextEdit.Properties.VistaTimeProperties.Mask.BeepOnError")));
            this.BirthDateTextEdit.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("BirthDateTextEdit.Properties.VistaTimeProperties.Mask.EditMask");
            this.BirthDateTextEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("BirthDateTextEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank")));
            this.BirthDateTextEdit.Properties.VistaTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("BirthDateTextEdit.Properties.VistaTimeProperties.Mask.MaskType")));
            this.BirthDateTextEdit.Properties.VistaTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("BirthDateTextEdit.Properties.VistaTimeProperties.Mask.PlaceHolder")));
            this.BirthDateTextEdit.Properties.VistaTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("BirthDateTextEdit.Properties.VistaTimeProperties.Mask.SaveLiteral")));
            this.BirthDateTextEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("BirthDateTextEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders")));
            this.BirthDateTextEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("BirthDateTextEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat")));
            this.BirthDateTextEdit.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("BirthDateTextEdit.Properties.VistaTimeProperties.NullValuePrompt");
            this.BirthDateTextEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("BirthDateTextEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue" +
        "")));
            this.BirthDateTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // AnniversaryTextEdit
            // 
            resources.ApplyResources(this.AnniversaryTextEdit, "AnniversaryTextEdit");
            this.AnniversaryTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Anniversary", true));
            this.AnniversaryTextEdit.Name = "AnniversaryTextEdit";
            this.AnniversaryTextEdit.Properties.AccessibleDescription = resources.GetString("AnniversaryTextEdit.Properties.AccessibleDescription");
            this.AnniversaryTextEdit.Properties.AccessibleName = resources.GetString("AnniversaryTextEdit.Properties.AccessibleName");
            this.AnniversaryTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("AnniversaryTextEdit.Properties.AutoHeight")));
            this.AnniversaryTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("AnniversaryTextEdit.Properties.Buttons"))))});
            this.AnniversaryTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("AnniversaryTextEdit.Properties.Mask.AutoComplete")));
            this.AnniversaryTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("AnniversaryTextEdit.Properties.Mask.BeepOnError")));
            this.AnniversaryTextEdit.Properties.Mask.EditMask = resources.GetString("AnniversaryTextEdit.Properties.Mask.EditMask");
            this.AnniversaryTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("AnniversaryTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.AnniversaryTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("AnniversaryTextEdit.Properties.Mask.MaskType")));
            this.AnniversaryTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("AnniversaryTextEdit.Properties.Mask.PlaceHolder")));
            this.AnniversaryTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("AnniversaryTextEdit.Properties.Mask.SaveLiteral")));
            this.AnniversaryTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("AnniversaryTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.AnniversaryTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("AnniversaryTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.AnniversaryTextEdit.Properties.NullValuePrompt = resources.GetString("AnniversaryTextEdit.Properties.NullValuePrompt");
            this.AnniversaryTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("AnniversaryTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.AnniversaryTextEdit.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("AnniversaryTextEdit.Properties.VistaTimeProperties.AccessibleDescription");
            this.AnniversaryTextEdit.Properties.VistaTimeProperties.AccessibleName = resources.GetString("AnniversaryTextEdit.Properties.VistaTimeProperties.AccessibleName");
            this.AnniversaryTextEdit.Properties.VistaTimeProperties.AutoHeight = ((bool)(resources.GetObject("AnniversaryTextEdit.Properties.VistaTimeProperties.AutoHeight")));
            this.AnniversaryTextEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.AnniversaryTextEdit.Properties.VistaTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("AnniversaryTextEdit.Properties.VistaTimeProperties.Mask.AutoComplete")));
            this.AnniversaryTextEdit.Properties.VistaTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("AnniversaryTextEdit.Properties.VistaTimeProperties.Mask.BeepOnError")));
            this.AnniversaryTextEdit.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("AnniversaryTextEdit.Properties.VistaTimeProperties.Mask.EditMask");
            this.AnniversaryTextEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("AnniversaryTextEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank")));
            this.AnniversaryTextEdit.Properties.VistaTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("AnniversaryTextEdit.Properties.VistaTimeProperties.Mask.MaskType")));
            this.AnniversaryTextEdit.Properties.VistaTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("AnniversaryTextEdit.Properties.VistaTimeProperties.Mask.PlaceHolder")));
            this.AnniversaryTextEdit.Properties.VistaTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("AnniversaryTextEdit.Properties.VistaTimeProperties.Mask.SaveLiteral")));
            this.AnniversaryTextEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("AnniversaryTextEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders")));
            this.AnniversaryTextEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("AnniversaryTextEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat")));
            this.AnniversaryTextEdit.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("AnniversaryTextEdit.Properties.VistaTimeProperties.NullValuePrompt");
            this.AnniversaryTextEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("AnniversaryTextEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmptyVal" +
        "ue")));
            this.AnniversaryTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // NumberOfChildrenTextEdit
            // 
            resources.ApplyResources(this.NumberOfChildrenTextEdit, "NumberOfChildrenTextEdit");
            this.NumberOfChildrenTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "NumberOfChildren", true));
            this.NumberOfChildrenTextEdit.Name = "NumberOfChildrenTextEdit";
            this.NumberOfChildrenTextEdit.Properties.AccessibleDescription = resources.GetString("NumberOfChildrenTextEdit.Properties.AccessibleDescription");
            this.NumberOfChildrenTextEdit.Properties.AccessibleName = resources.GetString("NumberOfChildrenTextEdit.Properties.AccessibleName");
            this.NumberOfChildrenTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("NumberOfChildrenTextEdit.Properties.AutoHeight")));
            this.NumberOfChildrenTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.NumberOfChildrenTextEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.NumberOfChildrenTextEdit.Properties.IsFloatValue = false;
            this.NumberOfChildrenTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("NumberOfChildrenTextEdit.Properties.Mask.AutoComplete")));
            this.NumberOfChildrenTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("NumberOfChildrenTextEdit.Properties.Mask.BeepOnError")));
            this.NumberOfChildrenTextEdit.Properties.Mask.EditMask = resources.GetString("NumberOfChildrenTextEdit.Properties.Mask.EditMask");
            this.NumberOfChildrenTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("NumberOfChildrenTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.NumberOfChildrenTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("NumberOfChildrenTextEdit.Properties.Mask.MaskType")));
            this.NumberOfChildrenTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("NumberOfChildrenTextEdit.Properties.Mask.PlaceHolder")));
            this.NumberOfChildrenTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("NumberOfChildrenTextEdit.Properties.Mask.SaveLiteral")));
            this.NumberOfChildrenTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("NumberOfChildrenTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.NumberOfChildrenTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("NumberOfChildrenTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.NumberOfChildrenTextEdit.Properties.MaxLength = 2;
            this.NumberOfChildrenTextEdit.Properties.MaxValue = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.NumberOfChildrenTextEdit.Properties.NullValuePrompt = resources.GetString("NumberOfChildrenTextEdit.Properties.NullValuePrompt");
            this.NumberOfChildrenTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("NumberOfChildrenTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.NumberOfChildrenTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // AccountRoleCodeLookUpEdit
            // 
            resources.ApplyResources(this.AccountRoleCodeLookUpEdit, "AccountRoleCodeLookUpEdit");
            this.AccountRoleCodeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "AccountRoleCode", true));
            this.AccountRoleCodeLookUpEdit.Name = "AccountRoleCodeLookUpEdit";
            this.AccountRoleCodeLookUpEdit.Properties.AccessibleDescription = resources.GetString("AccountRoleCodeLookUpEdit.Properties.AccessibleDescription");
            this.AccountRoleCodeLookUpEdit.Properties.AccessibleName = resources.GetString("AccountRoleCodeLookUpEdit.Properties.AccessibleName");
            this.AccountRoleCodeLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("AccountRoleCodeLookUpEdit.Properties.AutoHeight")));
            this.AccountRoleCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("AccountRoleCodeLookUpEdit.Properties.Buttons"))))});
            this.AccountRoleCodeLookUpEdit.Properties.NullText = resources.GetString("AccountRoleCodeLookUpEdit.Properties.NullText");
            this.AccountRoleCodeLookUpEdit.Properties.NullValuePrompt = resources.GetString("AccountRoleCodeLookUpEdit.Properties.NullValuePrompt");
            this.AccountRoleCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("AccountRoleCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.AccountRoleCodeLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // GenderCodeLookUpEdit
            // 
            resources.ApplyResources(this.GenderCodeLookUpEdit, "GenderCodeLookUpEdit");
            this.GenderCodeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "GenderCode", true));
            this.GenderCodeLookUpEdit.Name = "GenderCodeLookUpEdit";
            this.GenderCodeLookUpEdit.Properties.AccessibleDescription = resources.GetString("GenderCodeLookUpEdit.Properties.AccessibleDescription");
            this.GenderCodeLookUpEdit.Properties.AccessibleName = resources.GetString("GenderCodeLookUpEdit.Properties.AccessibleName");
            this.GenderCodeLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("GenderCodeLookUpEdit.Properties.AutoHeight")));
            this.GenderCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("GenderCodeLookUpEdit.Properties.Buttons"))))});
            this.GenderCodeLookUpEdit.Properties.NullText = resources.GetString("GenderCodeLookUpEdit.Properties.NullText");
            this.GenderCodeLookUpEdit.Properties.NullValuePrompt = resources.GetString("GenderCodeLookUpEdit.Properties.NullValuePrompt");
            this.GenderCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("GenderCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.GenderCodeLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // HasChildrenCodeLookUpEdit
            // 
            resources.ApplyResources(this.HasChildrenCodeLookUpEdit, "HasChildrenCodeLookUpEdit");
            this.HasChildrenCodeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "HasChildrenCode", true));
            this.HasChildrenCodeLookUpEdit.Name = "HasChildrenCodeLookUpEdit";
            this.HasChildrenCodeLookUpEdit.Properties.AccessibleDescription = resources.GetString("HasChildrenCodeLookUpEdit.Properties.AccessibleDescription");
            this.HasChildrenCodeLookUpEdit.Properties.AccessibleName = resources.GetString("HasChildrenCodeLookUpEdit.Properties.AccessibleName");
            this.HasChildrenCodeLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("HasChildrenCodeLookUpEdit.Properties.AutoHeight")));
            this.HasChildrenCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("HasChildrenCodeLookUpEdit.Properties.Buttons"))))});
            this.HasChildrenCodeLookUpEdit.Properties.NullText = resources.GetString("HasChildrenCodeLookUpEdit.Properties.NullText");
            this.HasChildrenCodeLookUpEdit.Properties.NullValuePrompt = resources.GetString("HasChildrenCodeLookUpEdit.Properties.NullValuePrompt");
            this.HasChildrenCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("HasChildrenCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.HasChildrenCodeLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // EducationCodeLookUpEdit
            // 
            resources.ApplyResources(this.EducationCodeLookUpEdit, "EducationCodeLookUpEdit");
            this.EducationCodeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "EducationCode", true));
            this.EducationCodeLookUpEdit.Name = "EducationCodeLookUpEdit";
            this.EducationCodeLookUpEdit.Properties.AccessibleDescription = resources.GetString("EducationCodeLookUpEdit.Properties.AccessibleDescription");
            this.EducationCodeLookUpEdit.Properties.AccessibleName = resources.GetString("EducationCodeLookUpEdit.Properties.AccessibleName");
            this.EducationCodeLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("EducationCodeLookUpEdit.Properties.AutoHeight")));
            this.EducationCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("EducationCodeLookUpEdit.Properties.Buttons"))))});
            this.EducationCodeLookUpEdit.Properties.NullText = resources.GetString("EducationCodeLookUpEdit.Properties.NullText");
            this.EducationCodeLookUpEdit.Properties.NullValuePrompt = resources.GetString("EducationCodeLookUpEdit.Properties.NullValuePrompt");
            this.EducationCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("EducationCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.EducationCodeLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // FamilyStatusCodeLookUpEdit
            // 
            resources.ApplyResources(this.FamilyStatusCodeLookUpEdit, "FamilyStatusCodeLookUpEdit");
            this.FamilyStatusCodeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "FamilyStatusCode", true));
            this.FamilyStatusCodeLookUpEdit.Name = "FamilyStatusCodeLookUpEdit";
            this.FamilyStatusCodeLookUpEdit.Properties.AccessibleDescription = resources.GetString("FamilyStatusCodeLookUpEdit.Properties.AccessibleDescription");
            this.FamilyStatusCodeLookUpEdit.Properties.AccessibleName = resources.GetString("FamilyStatusCodeLookUpEdit.Properties.AccessibleName");
            this.FamilyStatusCodeLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("FamilyStatusCodeLookUpEdit.Properties.AutoHeight")));
            this.FamilyStatusCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("FamilyStatusCodeLookUpEdit.Properties.Buttons"))))});
            this.FamilyStatusCodeLookUpEdit.Properties.NullText = resources.GetString("FamilyStatusCodeLookUpEdit.Properties.NullText");
            this.FamilyStatusCodeLookUpEdit.Properties.NullValuePrompt = resources.GetString("FamilyStatusCodeLookUpEdit.Properties.NullValuePrompt");
            this.FamilyStatusCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("FamilyStatusCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.FamilyStatusCodeLookUpEdit.StyleController = this.EntityDataLayoutControl;
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
            // OriginatingLeadIdLookUpEdit
            // 
            resources.ApplyResources(this.OriginatingLeadIdLookUpEdit, "OriginatingLeadIdLookUpEdit");
            this.OriginatingLeadIdLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "OriginatingLeadId", true));
            this.OriginatingLeadIdLookUpEdit.Name = "OriginatingLeadIdLookUpEdit";
            this.OriginatingLeadIdLookUpEdit.Properties.AccessibleDescription = resources.GetString("OriginatingLeadIdLookUpEdit.Properties.AccessibleDescription");
            this.OriginatingLeadIdLookUpEdit.Properties.AccessibleName = resources.GetString("OriginatingLeadIdLookUpEdit.Properties.AccessibleName");
            this.OriginatingLeadIdLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("OriginatingLeadIdLookUpEdit.Properties.AutoHeight")));
            this.OriginatingLeadIdLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("OriginatingLeadIdLookUpEdit.Properties.Buttons"))))});
            this.OriginatingLeadIdLookUpEdit.Properties.NullValuePrompt = resources.GetString("OriginatingLeadIdLookUpEdit.Properties.NullValuePrompt");
            this.OriginatingLeadIdLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("OriginatingLeadIdLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.OriginatingLeadIdLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ParentCustomerIdLookUpEdit
            // 
            resources.ApplyResources(this.ParentCustomerIdLookUpEdit, "ParentCustomerIdLookUpEdit");
            this.ParentCustomerIdLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ParentCustomerId", true));
            this.ParentCustomerIdLookUpEdit.Name = "ParentCustomerIdLookUpEdit";
            this.ParentCustomerIdLookUpEdit.Properties.AccessibleDescription = resources.GetString("ParentCustomerIdLookUpEdit.Properties.AccessibleDescription");
            this.ParentCustomerIdLookUpEdit.Properties.AccessibleName = resources.GetString("ParentCustomerIdLookUpEdit.Properties.AccessibleName");
            this.ParentCustomerIdLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("ParentCustomerIdLookUpEdit.Properties.AutoHeight")));
            this.ParentCustomerIdLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ParentCustomerIdLookUpEdit.Properties.Buttons"))))});
            this.ParentCustomerIdLookUpEdit.Properties.NullValuePrompt = resources.GetString("ParentCustomerIdLookUpEdit.Properties.NullValuePrompt");
            this.ParentCustomerIdLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("ParentCustomerIdLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.ParentCustomerIdLookUpEdit.StyleController = this.EntityDataLayoutControl;
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
            // tabbedControlGroup1
            // 
            resources.ApplyResources(this.tabbedControlGroup1, "tabbedControlGroup1");
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.managementLayoutControlGroup;
            this.tabbedControlGroup1.SelectedTabPageIndex = 2;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(928, 420);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgGeneral,
            this.lcgPersonal,
            this.managementLayoutControlGroup});
            // 
            // managementLayoutControlGroup
            // 
            resources.ApplyResources(this.managementLayoutControlGroup, "managementLayoutControlGroup");
            this.managementLayoutControlGroup.ExpandButtonVisible = true;
            this.managementLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForOwnerId,
            this.ItemForOriginatingLeadId,
            this.ItemForDepartment,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem1});
            this.managementLayoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.managementLayoutControlGroup.Name = "managementLayoutControlGroup";
            this.managementLayoutControlGroup.Size = new System.Drawing.Size(904, 373);
            // 
            // ItemForOwnerId
            // 
            this.ItemForOwnerId.Control = this.OwnerIdLookUpEdit;
            resources.ApplyResources(this.ItemForOwnerId, "ItemForOwnerId");
            this.ItemForOwnerId.Location = new System.Drawing.Point(0, 0);
            this.ItemForOwnerId.Name = "ItemForOwnerId";
            this.ItemForOwnerId.Size = new System.Drawing.Size(450, 24);
            this.ItemForOwnerId.TextSize = new System.Drawing.Size(107, 14);
            // 
            // OwnerIdLookUpEdit
            // 
            resources.ApplyResources(this.OwnerIdLookUpEdit, "OwnerIdLookUpEdit");
            this.OwnerIdLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "OwnerId", true));
            this.OwnerIdLookUpEdit.Name = "OwnerIdLookUpEdit";
            this.OwnerIdLookUpEdit.Properties.AccessibleDescription = resources.GetString("OwnerIdLookUpEdit.Properties.AccessibleDescription");
            this.OwnerIdLookUpEdit.Properties.AccessibleName = resources.GetString("OwnerIdLookUpEdit.Properties.AccessibleName");
            this.OwnerIdLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("OwnerIdLookUpEdit.Properties.AutoHeight")));
            this.OwnerIdLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("OwnerIdLookUpEdit.Properties.Buttons"))))});
            this.OwnerIdLookUpEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("OwnerIdLookUpEdit.Properties.Mask.AutoComplete")));
            this.OwnerIdLookUpEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("OwnerIdLookUpEdit.Properties.Mask.BeepOnError")));
            this.OwnerIdLookUpEdit.Properties.Mask.EditMask = resources.GetString("OwnerIdLookUpEdit.Properties.Mask.EditMask");
            this.OwnerIdLookUpEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("OwnerIdLookUpEdit.Properties.Mask.IgnoreMaskBlank")));
            this.OwnerIdLookUpEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("OwnerIdLookUpEdit.Properties.Mask.MaskType")));
            this.OwnerIdLookUpEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("OwnerIdLookUpEdit.Properties.Mask.PlaceHolder")));
            this.OwnerIdLookUpEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("OwnerIdLookUpEdit.Properties.Mask.SaveLiteral")));
            this.OwnerIdLookUpEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("OwnerIdLookUpEdit.Properties.Mask.ShowPlaceHolders")));
            this.OwnerIdLookUpEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("OwnerIdLookUpEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.OwnerIdLookUpEdit.Properties.NullText = resources.GetString("OwnerIdLookUpEdit.Properties.NullText");
            this.OwnerIdLookUpEdit.Properties.NullValuePrompt = resources.GetString("OwnerIdLookUpEdit.Properties.NullValuePrompt");
            this.OwnerIdLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("OwnerIdLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.OwnerIdLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForOriginatingLeadId
            // 
            this.ItemForOriginatingLeadId.Control = this.OriginatingLeadIdLookUpEdit;
            resources.ApplyResources(this.ItemForOriginatingLeadId, "ItemForOriginatingLeadId");
            this.ItemForOriginatingLeadId.Location = new System.Drawing.Point(450, 0);
            this.ItemForOriginatingLeadId.Name = "ItemForOriginatingLeadId";
            this.ItemForOriginatingLeadId.Size = new System.Drawing.Size(454, 24);
            this.ItemForOriginatingLeadId.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForDepartment
            // 
            this.ItemForDepartment.Control = this.DepartmentTextEdit;
            resources.ApplyResources(this.ItemForDepartment, "ItemForDepartment");
            this.ItemForDepartment.Location = new System.Drawing.Point(0, 24);
            this.ItemForDepartment.Name = "ItemForDepartment";
            this.ItemForDepartment.Size = new System.Drawing.Size(452, 24);
            this.ItemForDepartment.TextSize = new System.Drawing.Size(107, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textEdit1;
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(452, 24);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(107, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEdit2;
            resources.ApplyResources(this.layoutControlItem2, "layoutControlItem2");
            this.layoutControlItem2.Location = new System.Drawing.Point(452, 48);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(452, 24);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(107, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.textEdit3;
            resources.ApplyResources(this.layoutControlItem3, "layoutControlItem3");
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(452, 301);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(107, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.textEdit4;
            resources.ApplyResources(this.layoutControlItem4, "layoutControlItem4");
            this.layoutControlItem4.Location = new System.Drawing.Point(452, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(452, 301);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(107, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem1, "emptySpaceItem1");
            this.emptySpaceItem1.Location = new System.Drawing.Point(452, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(452, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgGeneral
            // 
            resources.ApplyResources(this.lcgGeneral, "lcgGeneral");
            this.lcgGeneral.ExpandButtonVisible = true;
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForTelephone1,
            this.ItemForDescription,
            this.ItemForMobilePhone,
            this.ItemForEMailAddress1,
            this.lcgProfessinal,
            this.ItemForLastName,
            this.ItemForNickName,
            this.ItemForSuffix,
            this.ItemForTelephone2,
            this.ItemForFax,
            this.ItemForFirstName});
            this.lcgGeneral.Location = new System.Drawing.Point(0, 0);
            this.lcgGeneral.Name = "lcgGeneral";
            this.lcgGeneral.Size = new System.Drawing.Size(904, 373);
            // 
            // ItemForTelephone1
            // 
            this.ItemForTelephone1.Control = this.Telephone1TextEdit;
            resources.ApplyResources(this.ItemForTelephone1, "ItemForTelephone1");
            this.ItemForTelephone1.Location = new System.Drawing.Point(0, 48);
            this.ItemForTelephone1.Name = "ItemForTelephone1";
            this.ItemForTelephone1.Size = new System.Drawing.Size(442, 24);
            this.ItemForTelephone1.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForDescription
            // 
            this.ItemForDescription.Control = this.DescriptionTextEdit;
            resources.ApplyResources(this.ItemForDescription, "ItemForDescription");
            this.ItemForDescription.Location = new System.Drawing.Point(0, 120);
            this.ItemForDescription.Name = "ItemForDescription";
            this.ItemForDescription.Size = new System.Drawing.Size(904, 113);
            this.ItemForDescription.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForMobilePhone
            // 
            this.ItemForMobilePhone.Control = this.MobilePhoneTextEdit;
            resources.ApplyResources(this.ItemForMobilePhone, "ItemForMobilePhone");
            this.ItemForMobilePhone.Location = new System.Drawing.Point(0, 72);
            this.ItemForMobilePhone.Name = "ItemForMobilePhone";
            this.ItemForMobilePhone.Size = new System.Drawing.Size(442, 24);
            this.ItemForMobilePhone.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForEMailAddress1
            // 
            this.ItemForEMailAddress1.Control = this.EMailAddress1TextEdit;
            resources.ApplyResources(this.ItemForEMailAddress1, "ItemForEMailAddress1");
            this.ItemForEMailAddress1.Location = new System.Drawing.Point(0, 96);
            this.ItemForEMailAddress1.Name = "ItemForEMailAddress1";
            this.ItemForEMailAddress1.Size = new System.Drawing.Size(904, 24);
            this.ItemForEMailAddress1.TextSize = new System.Drawing.Size(107, 14);
            // 
            // lcgProfessinal
            // 
            resources.ApplyResources(this.lcgProfessinal, "lcgProfessinal");
            this.lcgProfessinal.ExpandButtonVisible = true;
            this.lcgProfessinal.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForManagerName,
            this.ItemForManangerPhone,
            this.ItemForAssistantName,
            this.ItemForAccountRoleCode,
            this.ItemForAssistantPhone,
            this.ItemForParentCustomerId,
            this.ItemForEmployeeId,
            this.ItemForJobTitle});
            this.lcgProfessinal.Location = new System.Drawing.Point(0, 233);
            this.lcgProfessinal.Name = "lcgProfessinal";
            this.lcgProfessinal.Size = new System.Drawing.Size(904, 140);
            // 
            // ItemForManagerName
            // 
            this.ItemForManagerName.Control = this.ManagerNameTextEdit;
            resources.ApplyResources(this.ItemForManagerName, "ItemForManagerName");
            this.ItemForManagerName.Location = new System.Drawing.Point(0, 48);
            this.ItemForManagerName.Name = "ItemForManagerName";
            this.ItemForManagerName.Size = new System.Drawing.Size(441, 24);
            this.ItemForManagerName.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForManangerPhone
            // 
            this.ItemForManangerPhone.Control = this.ManangerPhoneTextEdit;
            resources.ApplyResources(this.ItemForManangerPhone, "ItemForManangerPhone");
            this.ItemForManangerPhone.Location = new System.Drawing.Point(0, 72);
            this.ItemForManangerPhone.Name = "ItemForManangerPhone";
            this.ItemForManangerPhone.Size = new System.Drawing.Size(441, 24);
            this.ItemForManangerPhone.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForAssistantName
            // 
            this.ItemForAssistantName.Control = this.AssistantNameTextEdit;
            resources.ApplyResources(this.ItemForAssistantName, "ItemForAssistantName");
            this.ItemForAssistantName.Location = new System.Drawing.Point(441, 48);
            this.ItemForAssistantName.Name = "ItemForAssistantName";
            this.ItemForAssistantName.Size = new System.Drawing.Size(439, 24);
            this.ItemForAssistantName.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForAccountRoleCode
            // 
            this.ItemForAccountRoleCode.Control = this.AccountRoleCodeLookUpEdit;
            resources.ApplyResources(this.ItemForAccountRoleCode, "ItemForAccountRoleCode");
            this.ItemForAccountRoleCode.Location = new System.Drawing.Point(0, 0);
            this.ItemForAccountRoleCode.Name = "ItemForAccountRoleCode";
            this.ItemForAccountRoleCode.Size = new System.Drawing.Size(440, 24);
            this.ItemForAccountRoleCode.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForAssistantPhone
            // 
            this.ItemForAssistantPhone.Control = this.AssistantPhoneTextEdit;
            resources.ApplyResources(this.ItemForAssistantPhone, "ItemForAssistantPhone");
            this.ItemForAssistantPhone.Location = new System.Drawing.Point(441, 72);
            this.ItemForAssistantPhone.Name = "ItemForAssistantPhone";
            this.ItemForAssistantPhone.Size = new System.Drawing.Size(439, 24);
            this.ItemForAssistantPhone.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForParentCustomerId
            // 
            this.ItemForParentCustomerId.Control = this.ParentCustomerIdLookUpEdit;
            resources.ApplyResources(this.ItemForParentCustomerId, "ItemForParentCustomerId");
            this.ItemForParentCustomerId.Location = new System.Drawing.Point(440, 24);
            this.ItemForParentCustomerId.Name = "ItemForParentCustomerId";
            this.ItemForParentCustomerId.Size = new System.Drawing.Size(440, 24);
            this.ItemForParentCustomerId.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForEmployeeId
            // 
            this.ItemForEmployeeId.Control = this.EmployeeIdTextEdit;
            resources.ApplyResources(this.ItemForEmployeeId, "ItemForEmployeeId");
            this.ItemForEmployeeId.Location = new System.Drawing.Point(0, 24);
            this.ItemForEmployeeId.Name = "ItemForEmployeeId";
            this.ItemForEmployeeId.Size = new System.Drawing.Size(440, 24);
            this.ItemForEmployeeId.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForJobTitle
            // 
            this.ItemForJobTitle.Control = this.JobTitleTextEdit;
            resources.ApplyResources(this.ItemForJobTitle, "ItemForJobTitle");
            this.ItemForJobTitle.Location = new System.Drawing.Point(440, 0);
            this.ItemForJobTitle.Name = "ItemForJobTitle";
            this.ItemForJobTitle.Size = new System.Drawing.Size(440, 24);
            this.ItemForJobTitle.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForLastName
            // 
            this.ItemForLastName.Control = this.LastNameTextEdit;
            resources.ApplyResources(this.ItemForLastName, "ItemForLastName");
            this.ItemForLastName.Location = new System.Drawing.Point(0, 0);
            this.ItemForLastName.Name = "ItemForLastName";
            this.ItemForLastName.Size = new System.Drawing.Size(442, 24);
            this.ItemForLastName.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForNickName
            // 
            this.ItemForNickName.Control = this.NickNameTextEdit;
            resources.ApplyResources(this.ItemForNickName, "ItemForNickName");
            this.ItemForNickName.Location = new System.Drawing.Point(0, 24);
            this.ItemForNickName.Name = "ItemForNickName";
            this.ItemForNickName.Size = new System.Drawing.Size(442, 24);
            this.ItemForNickName.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForSuffix
            // 
            this.ItemForSuffix.Control = this.SuffixTextEdit;
            resources.ApplyResources(this.ItemForSuffix, "ItemForSuffix");
            this.ItemForSuffix.Location = new System.Drawing.Point(442, 24);
            this.ItemForSuffix.Name = "ItemForSuffix";
            this.ItemForSuffix.Size = new System.Drawing.Size(462, 24);
            this.ItemForSuffix.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForTelephone2
            // 
            this.ItemForTelephone2.Control = this.Telephone2TextEdit;
            resources.ApplyResources(this.ItemForTelephone2, "ItemForTelephone2");
            this.ItemForTelephone2.Location = new System.Drawing.Point(442, 72);
            this.ItemForTelephone2.Name = "ItemForTelephone2";
            this.ItemForTelephone2.Size = new System.Drawing.Size(462, 24);
            this.ItemForTelephone2.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForFax
            // 
            this.ItemForFax.Control = this.FaxTextEdit;
            resources.ApplyResources(this.ItemForFax, "ItemForFax");
            this.ItemForFax.Location = new System.Drawing.Point(442, 48);
            this.ItemForFax.Name = "ItemForFax";
            this.ItemForFax.Size = new System.Drawing.Size(462, 24);
            this.ItemForFax.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForFirstName
            // 
            this.ItemForFirstName.Control = this.FirstNameTextEdit;
            resources.ApplyResources(this.ItemForFirstName, "ItemForFirstName");
            this.ItemForFirstName.Location = new System.Drawing.Point(442, 0);
            this.ItemForFirstName.Name = "ItemForFirstName";
            this.ItemForFirstName.Size = new System.Drawing.Size(462, 24);
            this.ItemForFirstName.TextSize = new System.Drawing.Size(107, 14);
            // 
            // lcgPersonal
            // 
            resources.ApplyResources(this.lcgPersonal, "lcgPersonal");
            this.lcgPersonal.ExpandButtonVisible = true;
            this.lcgPersonal.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForGenderCode,
            this.ItemForBirthDate,
            this.ItemForFamilyStatusCode,
            this.ItemForAnniversary,
            this.ItemForNumberOfChildren,
            this.ItemForHasChildrenCode,
            this.ItemForSpousesName,
            this.ItemForEducationCode});
            this.lcgPersonal.Location = new System.Drawing.Point(0, 0);
            this.lcgPersonal.Name = "lcgPersonal";
            this.lcgPersonal.Size = new System.Drawing.Size(904, 373);
            // 
            // ItemForGenderCode
            // 
            this.ItemForGenderCode.Control = this.GenderCodeLookUpEdit;
            resources.ApplyResources(this.ItemForGenderCode, "ItemForGenderCode");
            this.ItemForGenderCode.Location = new System.Drawing.Point(0, 0);
            this.ItemForGenderCode.Name = "ItemForGenderCode";
            this.ItemForGenderCode.Size = new System.Drawing.Size(449, 24);
            this.ItemForGenderCode.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForBirthDate
            // 
            this.ItemForBirthDate.Control = this.BirthDateTextEdit;
            resources.ApplyResources(this.ItemForBirthDate, "ItemForBirthDate");
            this.ItemForBirthDate.Location = new System.Drawing.Point(449, 0);
            this.ItemForBirthDate.Name = "ItemForBirthDate";
            this.ItemForBirthDate.Size = new System.Drawing.Size(455, 24);
            this.ItemForBirthDate.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForFamilyStatusCode
            // 
            this.ItemForFamilyStatusCode.Control = this.FamilyStatusCodeLookUpEdit;
            resources.ApplyResources(this.ItemForFamilyStatusCode, "ItemForFamilyStatusCode");
            this.ItemForFamilyStatusCode.Location = new System.Drawing.Point(0, 48);
            this.ItemForFamilyStatusCode.Name = "ItemForFamilyStatusCode";
            this.ItemForFamilyStatusCode.Size = new System.Drawing.Size(449, 24);
            this.ItemForFamilyStatusCode.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForAnniversary
            // 
            this.ItemForAnniversary.Control = this.AnniversaryTextEdit;
            resources.ApplyResources(this.ItemForAnniversary, "ItemForAnniversary");
            this.ItemForAnniversary.Location = new System.Drawing.Point(449, 24);
            this.ItemForAnniversary.Name = "ItemForAnniversary";
            this.ItemForAnniversary.Size = new System.Drawing.Size(455, 24);
            this.ItemForAnniversary.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForNumberOfChildren
            // 
            this.ItemForNumberOfChildren.Control = this.NumberOfChildrenTextEdit;
            resources.ApplyResources(this.ItemForNumberOfChildren, "ItemForNumberOfChildren");
            this.ItemForNumberOfChildren.Location = new System.Drawing.Point(449, 72);
            this.ItemForNumberOfChildren.Name = "ItemForNumberOfChildren";
            this.ItemForNumberOfChildren.Size = new System.Drawing.Size(455, 301);
            this.ItemForNumberOfChildren.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForHasChildrenCode
            // 
            this.ItemForHasChildrenCode.Control = this.HasChildrenCodeLookUpEdit;
            resources.ApplyResources(this.ItemForHasChildrenCode, "ItemForHasChildrenCode");
            this.ItemForHasChildrenCode.Location = new System.Drawing.Point(0, 72);
            this.ItemForHasChildrenCode.Name = "ItemForHasChildrenCode";
            this.ItemForHasChildrenCode.Size = new System.Drawing.Size(449, 301);
            this.ItemForHasChildrenCode.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForSpousesName
            // 
            this.ItemForSpousesName.Control = this.SpousesNameTextEdit;
            resources.ApplyResources(this.ItemForSpousesName, "ItemForSpousesName");
            this.ItemForSpousesName.Location = new System.Drawing.Point(449, 48);
            this.ItemForSpousesName.Name = "ItemForSpousesName";
            this.ItemForSpousesName.Size = new System.Drawing.Size(455, 24);
            this.ItemForSpousesName.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ItemForEducationCode
            // 
            this.ItemForEducationCode.Control = this.EducationCodeLookUpEdit;
            resources.ApplyResources(this.ItemForEducationCode, "ItemForEducationCode");
            this.ItemForEducationCode.Location = new System.Drawing.Point(0, 24);
            this.ItemForEducationCode.Name = "ItemForEducationCode";
            this.ItemForEducationCode.Size = new System.Drawing.Size(449, 24);
            this.ItemForEducationCode.TextSize = new System.Drawing.Size(107, 14);
            // 
            // ContactDetailView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ContactDetailView";
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).EndInit();
            this.EntityDataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AssistantNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AssistantPhoneTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EMailAddress1TextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeIdTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaxTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JobTitleTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManagerNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManangerPhoneTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MobilePhoneTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NickNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpousesNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SuffixTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Telephone1TextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Telephone2TextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BirthDateTextEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BirthDateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnniversaryTextEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnniversaryTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfChildrenTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountRoleCodeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GenderCodeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HasChildrenCodeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EducationCodeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FamilyStatusCodeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginatingLeadIdLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParentCustomerIdLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.managementLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOwnerId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OwnerIdLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOriginatingLeadId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTelephone1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMobilePhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEMailAddress1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgProfessinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForManagerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForManangerPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAssistantName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccountRoleCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAssistantPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForParentCustomerId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEmployeeId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForJobTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNickName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSuffix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTelephone2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPersonal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGenderCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBirthDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFamilyStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAnniversary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNumberOfChildren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForHasChildrenCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSpousesName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEducationCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit AssistantNameTextEdit;
        private DevExpress.XtraEditors.TextEdit AssistantPhoneTextEdit;
        private DevExpress.XtraEditors.TextEdit DepartmentTextEdit;
        private DevExpress.XtraEditors.TextEdit EMailAddress1TextEdit;
        private DevExpress.XtraEditors.TextEdit EmployeeIdTextEdit;
        private DevExpress.XtraEditors.TextEdit FaxTextEdit;
        private DevExpress.XtraEditors.TextEdit FirstNameTextEdit;
        private DevExpress.XtraEditors.TextEdit JobTitleTextEdit;
        private DevExpress.XtraEditors.TextEdit LastNameTextEdit;
        private DevExpress.XtraEditors.TextEdit ManagerNameTextEdit;
        private DevExpress.XtraEditors.TextEdit ManangerPhoneTextEdit;
        private DevExpress.XtraEditors.TextEdit MobilePhoneTextEdit;
        private DevExpress.XtraEditors.TextEdit NickNameTextEdit;
        private DevExpress.XtraEditors.TextEdit SpousesNameTextEdit;
        private DevExpress.XtraEditors.TextEdit SuffixTextEdit;
        private DevExpress.XtraEditors.TextEdit Telephone1TextEdit;
        private DevExpress.XtraEditors.TextEdit Telephone2TextEdit;
        private DropDownDateEdit BirthDateTextEdit;
        private DropDownDateEdit AnniversaryTextEdit;
        private DevExpress.XtraEditors.SpinEdit NumberOfChildrenTextEdit;
        private DevExpress.XtraEditors.LookUpEdit AccountRoleCodeLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit GenderCodeLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit HasChildrenCodeLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit EducationCodeLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit FamilyStatusCodeLookUpEdit;
        private DevExpress.XtraEditors.MemoEdit DescriptionTextEdit;
        private DevExpress.XtraEditors.LookUpEdit OriginatingLeadIdLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit ParentCustomerIdLookUpEdit;
        private DevExpress.XtraEditors.TextEdit textEdit4;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgGeneral;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTelephone1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMobilePhone;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEMailAddress1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgProfessinal;
        private DevExpress.XtraLayout.LayoutControlItem ItemForManagerName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForManangerPhone;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAssistantName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAccountRoleCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAssistantPhone;
        private DevExpress.XtraLayout.LayoutControlItem ItemForParentCustomerId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEmployeeId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForJobTitle;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLastName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNickName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSuffix;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTelephone2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForFax;
        private DevExpress.XtraLayout.LayoutControlItem ItemForFirstName;
        private DevExpress.XtraLayout.LayoutControlGroup lcgPersonal;
        private DevExpress.XtraLayout.LayoutControlItem ItemForGenderCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForBirthDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForFamilyStatusCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAnniversary;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNumberOfChildren;
        private DevExpress.XtraLayout.LayoutControlItem ItemForHasChildrenCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSpousesName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEducationCode;
        private DevExpress.XtraLayout.LayoutControlGroup managementLayoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOwnerId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOriginatingLeadId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDepartment;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.PopupContainerEdit OwnerIdLookUpEdit;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
