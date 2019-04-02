using Katrin.AppFramework.WinForms.Controls;
using Katrin.Win.Common.Controls;
using System.Windows.Forms;
using System;
namespace Katrin.Win.UserModule.Detail
{
    partial class UserDetailView
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
            //GC.SuppressFinalize(this);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserDetailView));
            Katrin.Win.Common.Controls.GridCheckMarksSelection gridCheckMarksSelection1 = new Katrin.Win.Common.Controls.GridCheckMarksSelection();
            this.ConfirmPasswordTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.EmailAddressTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.FirstNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.HomePhoneTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.LastNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.MobilePhoneTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.NickNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.PasswordTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.TitleTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.UserNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.lcgGeneral = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgAccount = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForNickName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForConfirmPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.roleLookUpEdit = new Katrin.Win.Common.Controls.MyGridLookUpEdit();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgPosition = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForDepartmentId = new DevExpress.XtraLayout.LayoutControlItem();
            this.DepartmentIdLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.ItemForEntryDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.EntryDateDateEdit = new Katrin.AppFramework.WinForms.Controls.DropDownDateEdit();
            this.ItemForJobLevel = new DevExpress.XtraLayout.LayoutControlItem();
            this.JobLevelLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.ItemForLastPromotionDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.LastPromotionDateDateEdit = new Katrin.AppFramework.WinForms.Controls.DropDownDateEdit();
            this.ItemForTitle = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgPersonal = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForLastName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForFirstName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForFullName = new DevExpress.XtraLayout.LayoutControlItem();
            this.FullNameLookUp = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ItemGraduatedCollege = new DevExpress.XtraLayout.LayoutControlItem();
            this.GraduatedCollegeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForWorkExperience = new DevExpress.XtraLayout.LayoutControlItem();
            this.WorkExperienceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForTechnicalExpertise = new DevExpress.XtraLayout.LayoutControlItem();
            this.TechnicalExpertiseTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForEnglishLevel = new DevExpress.XtraLayout.LayoutControlItem();
            this.EnglishLevelTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForEnglishCommunication = new DevExpress.XtraLayout.LayoutControlItem();
            this.EnglishCommunicationTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForBirthDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.BirthDateDateEdit = new Katrin.AppFramework.WinForms.Controls.DropDownDateEdit();
            this.ItemForHobby = new DevExpress.XtraLayout.LayoutControlItem();
            this.HobbyTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForNativePlace = new DevExpress.XtraLayout.LayoutControlItem();
            this.NativePlaceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgContact = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForMSN = new DevExpress.XtraLayout.LayoutControlItem();
            this.MSNTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForEmailAddress = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForQQ = new DevExpress.XtraLayout.LayoutControlItem();
            this.QQTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForHomePhone = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForMobilePhone = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.managementLayoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForCreatedBy = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.ItemForCreatedOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.ItemForModifiedOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.ItemForModifiedBy = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).BeginInit();
            this.EntityDataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConfirmPasswordTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailAddressTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomePhoneTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MobilePhoneTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NickNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNickName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForConfirmPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDepartmentId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentIdLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEntryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntryDateDateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntryDateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForJobLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JobLevelLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastPromotionDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastPromotionDateDateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastPromotionDateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPersonal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFullName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullNameLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGraduatedCollege)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraduatedCollegeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForWorkExperience)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkExperienceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTechnicalExpertise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TechnicalExpertiseTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEnglishLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnglishLevelTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEnglishCommunication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnglishCommunicationTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBirthDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BirthDateDateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BirthDateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForHobby)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HobbyTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNativePlace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NativePlaceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMSN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MSNTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEmailAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForQQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QQTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForHomePhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMobilePhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.managementLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // EntityDataLayoutControl
            // 
            resources.ApplyResources(this.EntityDataLayoutControl, "EntityDataLayoutControl");
            this.EntityDataLayoutControl.Controls.Add(this.FullNameLookUp);
            this.EntityDataLayoutControl.Controls.Add(this.roleLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.LastPromotionDateDateEdit);
            this.EntityDataLayoutControl.Controls.Add(this.JobLevelLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.WorkExperienceTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.HobbyTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.MSNTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.QQTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.BirthDateDateEdit);
            this.EntityDataLayoutControl.Controls.Add(this.TechnicalExpertiseTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.EnglishLevelTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.EnglishCommunicationTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.EntryDateDateEdit);
            this.EntityDataLayoutControl.Controls.Add(this.GraduatedCollegeTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.NativePlaceTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.DepartmentIdLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit4);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit3);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit2);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit1);
            this.EntityDataLayoutControl.Controls.Add(this.ConfirmPasswordTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.EmailAddressTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.FirstNameTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.HomePhoneTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.LastNameTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.MobilePhoneTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.NickNameTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.PasswordTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.TitleTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.UserNameTextEdit);
            this.EntityDataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(495, 155, 416, 350);
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
            this.RootLayoutControlGroup.Size = new System.Drawing.Size(841, 603);
            // 
            // ConfirmPasswordTextEdit
            // 
            resources.ApplyResources(this.ConfirmPasswordTextEdit, "ConfirmPasswordTextEdit");
            this.ConfirmPasswordTextEdit.Name = "ConfirmPasswordTextEdit";
            this.ConfirmPasswordTextEdit.Properties.AccessibleDescription = resources.GetString("ConfirmPasswordTextEdit.Properties.AccessibleDescription");
            this.ConfirmPasswordTextEdit.Properties.AccessibleName = resources.GetString("ConfirmPasswordTextEdit.Properties.AccessibleName");
            this.ConfirmPasswordTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("ConfirmPasswordTextEdit.Properties.AutoHeight")));
            this.ConfirmPasswordTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("ConfirmPasswordTextEdit.Properties.Mask.AutoComplete")));
            this.ConfirmPasswordTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("ConfirmPasswordTextEdit.Properties.Mask.BeepOnError")));
            this.ConfirmPasswordTextEdit.Properties.Mask.EditMask = resources.GetString("ConfirmPasswordTextEdit.Properties.Mask.EditMask");
            this.ConfirmPasswordTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("ConfirmPasswordTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.ConfirmPasswordTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("ConfirmPasswordTextEdit.Properties.Mask.MaskType")));
            this.ConfirmPasswordTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("ConfirmPasswordTextEdit.Properties.Mask.PlaceHolder")));
            this.ConfirmPasswordTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("ConfirmPasswordTextEdit.Properties.Mask.SaveLiteral")));
            this.ConfirmPasswordTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("ConfirmPasswordTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.ConfirmPasswordTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("ConfirmPasswordTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.ConfirmPasswordTextEdit.Properties.NullValuePrompt = resources.GetString("ConfirmPasswordTextEdit.Properties.NullValuePrompt");
            this.ConfirmPasswordTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("ConfirmPasswordTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.ConfirmPasswordTextEdit.Properties.UseSystemPasswordChar = true;
            this.ConfirmPasswordTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // EmailAddressTextEdit
            // 
            resources.ApplyResources(this.EmailAddressTextEdit, "EmailAddressTextEdit");
            this.EmailAddressTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "EmailAddress", true));
            this.EmailAddressTextEdit.Name = "EmailAddressTextEdit";
            this.EmailAddressTextEdit.Properties.AccessibleDescription = resources.GetString("EmailAddressTextEdit.Properties.AccessibleDescription");
            this.EmailAddressTextEdit.Properties.AccessibleName = resources.GetString("EmailAddressTextEdit.Properties.AccessibleName");
            this.EmailAddressTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("EmailAddressTextEdit.Properties.AutoHeight")));
            this.EmailAddressTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("EmailAddressTextEdit.Properties.Mask.AutoComplete")));
            this.EmailAddressTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("EmailAddressTextEdit.Properties.Mask.BeepOnError")));
            this.EmailAddressTextEdit.Properties.Mask.EditMask = resources.GetString("EmailAddressTextEdit.Properties.Mask.EditMask");
            this.EmailAddressTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("EmailAddressTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.EmailAddressTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("EmailAddressTextEdit.Properties.Mask.MaskType")));
            this.EmailAddressTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("EmailAddressTextEdit.Properties.Mask.PlaceHolder")));
            this.EmailAddressTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("EmailAddressTextEdit.Properties.Mask.SaveLiteral")));
            this.EmailAddressTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("EmailAddressTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.EmailAddressTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("EmailAddressTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.EmailAddressTextEdit.Properties.NullValuePrompt = resources.GetString("EmailAddressTextEdit.Properties.NullValuePrompt");
            this.EmailAddressTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("EmailAddressTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.EmailAddressTextEdit.StyleController = this.EntityDataLayoutControl;
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
            // HomePhoneTextEdit
            // 
            resources.ApplyResources(this.HomePhoneTextEdit, "HomePhoneTextEdit");
            this.HomePhoneTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "HomePhone", true));
            this.HomePhoneTextEdit.Name = "HomePhoneTextEdit";
            this.HomePhoneTextEdit.Properties.AccessibleDescription = resources.GetString("HomePhoneTextEdit.Properties.AccessibleDescription");
            this.HomePhoneTextEdit.Properties.AccessibleName = resources.GetString("HomePhoneTextEdit.Properties.AccessibleName");
            this.HomePhoneTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("HomePhoneTextEdit.Properties.AutoHeight")));
            this.HomePhoneTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("HomePhoneTextEdit.Properties.Mask.AutoComplete")));
            this.HomePhoneTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("HomePhoneTextEdit.Properties.Mask.BeepOnError")));
            this.HomePhoneTextEdit.Properties.Mask.EditMask = resources.GetString("HomePhoneTextEdit.Properties.Mask.EditMask");
            this.HomePhoneTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("HomePhoneTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.HomePhoneTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("HomePhoneTextEdit.Properties.Mask.MaskType")));
            this.HomePhoneTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("HomePhoneTextEdit.Properties.Mask.PlaceHolder")));
            this.HomePhoneTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("HomePhoneTextEdit.Properties.Mask.SaveLiteral")));
            this.HomePhoneTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("HomePhoneTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.HomePhoneTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("HomePhoneTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.HomePhoneTextEdit.Properties.NullValuePrompt = resources.GetString("HomePhoneTextEdit.Properties.NullValuePrompt");
            this.HomePhoneTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("HomePhoneTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.HomePhoneTextEdit.StyleController = this.EntityDataLayoutControl;
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
            // PasswordTextEdit
            // 
            resources.ApplyResources(this.PasswordTextEdit, "PasswordTextEdit");
            this.PasswordTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Password", true));
            this.PasswordTextEdit.Name = "PasswordTextEdit";
            this.PasswordTextEdit.Properties.AccessibleDescription = resources.GetString("PasswordTextEdit.Properties.AccessibleDescription");
            this.PasswordTextEdit.Properties.AccessibleName = resources.GetString("PasswordTextEdit.Properties.AccessibleName");
            this.PasswordTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("PasswordTextEdit.Properties.AutoHeight")));
            this.PasswordTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("PasswordTextEdit.Properties.Mask.AutoComplete")));
            this.PasswordTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("PasswordTextEdit.Properties.Mask.BeepOnError")));
            this.PasswordTextEdit.Properties.Mask.EditMask = resources.GetString("PasswordTextEdit.Properties.Mask.EditMask");
            this.PasswordTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("PasswordTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.PasswordTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("PasswordTextEdit.Properties.Mask.MaskType")));
            this.PasswordTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("PasswordTextEdit.Properties.Mask.PlaceHolder")));
            this.PasswordTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("PasswordTextEdit.Properties.Mask.SaveLiteral")));
            this.PasswordTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("PasswordTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.PasswordTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("PasswordTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.PasswordTextEdit.Properties.NullValuePrompt = resources.GetString("PasswordTextEdit.Properties.NullValuePrompt");
            this.PasswordTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("PasswordTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.PasswordTextEdit.Properties.UseSystemPasswordChar = true;
            this.PasswordTextEdit.StyleController = this.EntityDataLayoutControl;
            this.PasswordTextEdit.TextChanged += new System.EventHandler(this.PasswordTextEdit_TextChanged);
            // 
            // TitleTextEdit
            // 
            resources.ApplyResources(this.TitleTextEdit, "TitleTextEdit");
            this.TitleTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Title", true));
            this.TitleTextEdit.Name = "TitleTextEdit";
            this.TitleTextEdit.Properties.AccessibleDescription = resources.GetString("TitleTextEdit.Properties.AccessibleDescription");
            this.TitleTextEdit.Properties.AccessibleName = resources.GetString("TitleTextEdit.Properties.AccessibleName");
            this.TitleTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("TitleTextEdit.Properties.AutoHeight")));
            this.TitleTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("TitleTextEdit.Properties.Mask.AutoComplete")));
            this.TitleTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("TitleTextEdit.Properties.Mask.BeepOnError")));
            this.TitleTextEdit.Properties.Mask.EditMask = resources.GetString("TitleTextEdit.Properties.Mask.EditMask");
            this.TitleTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("TitleTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.TitleTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("TitleTextEdit.Properties.Mask.MaskType")));
            this.TitleTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("TitleTextEdit.Properties.Mask.PlaceHolder")));
            this.TitleTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("TitleTextEdit.Properties.Mask.SaveLiteral")));
            this.TitleTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("TitleTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.TitleTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("TitleTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.TitleTextEdit.Properties.NullValuePrompt = resources.GetString("TitleTextEdit.Properties.NullValuePrompt");
            this.TitleTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("TitleTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.TitleTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // UserNameTextEdit
            // 
            resources.ApplyResources(this.UserNameTextEdit, "UserNameTextEdit");
            this.UserNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "UserName", true));
            this.UserNameTextEdit.Name = "UserNameTextEdit";
            this.UserNameTextEdit.Properties.AccessibleDescription = resources.GetString("UserNameTextEdit.Properties.AccessibleDescription");
            this.UserNameTextEdit.Properties.AccessibleName = resources.GetString("UserNameTextEdit.Properties.AccessibleName");
            this.UserNameTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("UserNameTextEdit.Properties.AutoHeight")));
            this.UserNameTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("UserNameTextEdit.Properties.Mask.AutoComplete")));
            this.UserNameTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("UserNameTextEdit.Properties.Mask.BeepOnError")));
            this.UserNameTextEdit.Properties.Mask.EditMask = resources.GetString("UserNameTextEdit.Properties.Mask.EditMask");
            this.UserNameTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("UserNameTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.UserNameTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("UserNameTextEdit.Properties.Mask.MaskType")));
            this.UserNameTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("UserNameTextEdit.Properties.Mask.PlaceHolder")));
            this.UserNameTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("UserNameTextEdit.Properties.Mask.SaveLiteral")));
            this.UserNameTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("UserNameTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.UserNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("UserNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.UserNameTextEdit.Properties.NullValuePrompt = resources.GetString("UserNameTextEdit.Properties.NullValuePrompt");
            this.UserNameTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("UserNameTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.UserNameTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // tabbedControlGroup1
            // 
            resources.ApplyResources(this.tabbedControlGroup1, "tabbedControlGroup1");
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.lcgGeneral;
            this.tabbedControlGroup1.SelectedTabPageIndex = 0;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(821, 583);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgGeneral,
            this.managementLayoutControlGroup});
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.AllowDrawBackground = false;
            resources.ApplyResources(this.lcgGeneral, "lcgGeneral");
            this.lcgGeneral.ExpandButtonVisible = true;
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgAccount,
            this.lcgPosition,
            this.lcgPersonal,
            this.lcgContact});
            this.lcgGeneral.Location = new System.Drawing.Point(0, 0);
            this.lcgGeneral.Name = "lcgGeneral";
            this.lcgGeneral.Size = new System.Drawing.Size(797, 536);
            // 
            // lcgAccount
            // 
            resources.ApplyResources(this.lcgAccount, "lcgAccount");
            this.lcgAccount.ExpandButtonVisible = true;
            this.lcgAccount.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForUserName,
            this.ItemForNickName,
            this.ItemForPassword,
            this.ItemForConfirmPassword,
            this.layoutControlItem1,
            this.emptySpaceItem1});
            this.lcgAccount.Location = new System.Drawing.Point(0, 0);
            this.lcgAccount.Name = "lcgAccount";
            this.lcgAccount.Size = new System.Drawing.Size(797, 116);
            // 
            // ItemForUserName
            // 
            this.ItemForUserName.Control = this.UserNameTextEdit;
            resources.ApplyResources(this.ItemForUserName, "ItemForUserName");
            this.ItemForUserName.Location = new System.Drawing.Point(0, 0);
            this.ItemForUserName.Name = "ItemForUserName";
            this.ItemForUserName.Size = new System.Drawing.Size(386, 24);
            this.ItemForUserName.TextSize = new System.Drawing.Size(124, 14);
            // 
            // ItemForNickName
            // 
            this.ItemForNickName.Control = this.NickNameTextEdit;
            resources.ApplyResources(this.ItemForNickName, "ItemForNickName");
            this.ItemForNickName.Location = new System.Drawing.Point(386, 0);
            this.ItemForNickName.Name = "ItemForNickName";
            this.ItemForNickName.Size = new System.Drawing.Size(387, 24);
            this.ItemForNickName.TextSize = new System.Drawing.Size(124, 14);
            // 
            // ItemForPassword
            // 
            this.ItemForPassword.Control = this.PasswordTextEdit;
            resources.ApplyResources(this.ItemForPassword, "ItemForPassword");
            this.ItemForPassword.Location = new System.Drawing.Point(0, 24);
            this.ItemForPassword.Name = "ItemForPassword";
            this.ItemForPassword.Size = new System.Drawing.Size(386, 24);
            this.ItemForPassword.TextSize = new System.Drawing.Size(124, 14);
            // 
            // ItemForConfirmPassword
            // 
            this.ItemForConfirmPassword.Control = this.ConfirmPasswordTextEdit;
            resources.ApplyResources(this.ItemForConfirmPassword, "ItemForConfirmPassword");
            this.ItemForConfirmPassword.Location = new System.Drawing.Point(386, 24);
            this.ItemForConfirmPassword.Name = "ItemForConfirmPassword";
            this.ItemForConfirmPassword.Size = new System.Drawing.Size(387, 24);
            this.ItemForConfirmPassword.TextSize = new System.Drawing.Size(124, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.roleLookUpEdit;
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(386, 24);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(124, 14);
            // 
            // roleLookUpEdit
            // 
            resources.ApplyResources(this.roleLookUpEdit, "roleLookUpEdit");
            this.roleLookUpEdit.Name = "roleLookUpEdit";
            this.roleLookUpEdit.Properties.AccessibleDescription = resources.GetString("roleLookUpEdit.Properties.AccessibleDescription");
            this.roleLookUpEdit.Properties.AccessibleName = resources.GetString("roleLookUpEdit.Properties.AccessibleName");
            this.roleLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("roleLookUpEdit.Properties.AutoHeight")));
            this.roleLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("roleLookUpEdit.Properties.Buttons"))))});
            gridCheckMarksSelection1.Selection = ((System.Collections.ArrayList)(resources.GetObject("gridCheckMarksSelection1.Selection")));
            gridCheckMarksSelection1.View = null;
            this.roleLookUpEdit.Properties.GridSelection = gridCheckMarksSelection1;
            this.roleLookUpEdit.Properties.NullValuePrompt = resources.GetString("roleLookUpEdit.Properties.NullValuePrompt");
            this.roleLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("roleLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.roleLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem1, "emptySpaceItem1");
            this.emptySpaceItem1.Location = new System.Drawing.Point(386, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(387, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgPosition
            // 
            resources.ApplyResources(this.lcgPosition, "lcgPosition");
            this.lcgPosition.ExpandButtonVisible = true;
            this.lcgPosition.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForDepartmentId,
            this.ItemForEntryDate,
            this.ItemForJobLevel,
            this.ItemForLastPromotionDate,
            this.ItemForTitle,
            this.emptySpaceItem3});
            this.lcgPosition.Location = new System.Drawing.Point(0, 116);
            this.lcgPosition.Name = "lcgPosition";
            this.lcgPosition.Size = new System.Drawing.Size(797, 116);
            // 
            // ItemForDepartmentId
            // 
            this.ItemForDepartmentId.Control = this.DepartmentIdLookUpEdit;
            resources.ApplyResources(this.ItemForDepartmentId, "ItemForDepartmentId");
            this.ItemForDepartmentId.Location = new System.Drawing.Point(0, 0);
            this.ItemForDepartmentId.Name = "ItemForDepartmentId";
            this.ItemForDepartmentId.Size = new System.Drawing.Size(386, 24);
            this.ItemForDepartmentId.TextSize = new System.Drawing.Size(124, 14);
            // 
            // DepartmentIdLookUpEdit
            // 
            resources.ApplyResources(this.DepartmentIdLookUpEdit, "DepartmentIdLookUpEdit");
            this.DepartmentIdLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "DepartmentId", true));
            this.DepartmentIdLookUpEdit.Name = "DepartmentIdLookUpEdit";
            this.DepartmentIdLookUpEdit.Properties.AccessibleDescription = resources.GetString("DepartmentIdLookUpEdit.Properties.AccessibleDescription");
            this.DepartmentIdLookUpEdit.Properties.AccessibleName = resources.GetString("DepartmentIdLookUpEdit.Properties.AccessibleName");
            this.DepartmentIdLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("DepartmentIdLookUpEdit.Properties.AutoHeight")));
            this.DepartmentIdLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("DepartmentIdLookUpEdit.Properties.Buttons"))))});
            this.DepartmentIdLookUpEdit.Properties.NullText = resources.GetString("DepartmentIdLookUpEdit.Properties.NullText");
            this.DepartmentIdLookUpEdit.Properties.NullValuePrompt = resources.GetString("DepartmentIdLookUpEdit.Properties.NullValuePrompt");
            this.DepartmentIdLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("DepartmentIdLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.DepartmentIdLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForEntryDate
            // 
            this.ItemForEntryDate.Control = this.EntryDateDateEdit;
            resources.ApplyResources(this.ItemForEntryDate, "ItemForEntryDate");
            this.ItemForEntryDate.Location = new System.Drawing.Point(386, 0);
            this.ItemForEntryDate.Name = "ItemForEntryDate";
            this.ItemForEntryDate.Size = new System.Drawing.Size(387, 24);
            this.ItemForEntryDate.TextSize = new System.Drawing.Size(124, 14);
            // 
            // EntryDateDateEdit
            // 
            resources.ApplyResources(this.EntryDateDateEdit, "EntryDateDateEdit");
            this.EntryDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "EntryDate", true));
            this.EntryDateDateEdit.Name = "EntryDateDateEdit";
            this.EntryDateDateEdit.Properties.AccessibleDescription = resources.GetString("EntryDateDateEdit.Properties.AccessibleDescription");
            this.EntryDateDateEdit.Properties.AccessibleName = resources.GetString("EntryDateDateEdit.Properties.AccessibleName");
            this.EntryDateDateEdit.Properties.AutoHeight = ((bool)(resources.GetObject("EntryDateDateEdit.Properties.AutoHeight")));
            this.EntryDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("EntryDateDateEdit.Properties.Buttons"))))});
            this.EntryDateDateEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("EntryDateDateEdit.Properties.Mask.AutoComplete")));
            this.EntryDateDateEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("EntryDateDateEdit.Properties.Mask.BeepOnError")));
            this.EntryDateDateEdit.Properties.Mask.EditMask = resources.GetString("EntryDateDateEdit.Properties.Mask.EditMask");
            this.EntryDateDateEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("EntryDateDateEdit.Properties.Mask.IgnoreMaskBlank")));
            this.EntryDateDateEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("EntryDateDateEdit.Properties.Mask.MaskType")));
            this.EntryDateDateEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("EntryDateDateEdit.Properties.Mask.PlaceHolder")));
            this.EntryDateDateEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("EntryDateDateEdit.Properties.Mask.SaveLiteral")));
            this.EntryDateDateEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("EntryDateDateEdit.Properties.Mask.ShowPlaceHolders")));
            this.EntryDateDateEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("EntryDateDateEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.EntryDateDateEdit.Properties.NullValuePrompt = resources.GetString("EntryDateDateEdit.Properties.NullValuePrompt");
            this.EntryDateDateEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("EntryDateDateEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.EntryDateDateEdit.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("EntryDateDateEdit.Properties.VistaTimeProperties.AccessibleDescription");
            this.EntryDateDateEdit.Properties.VistaTimeProperties.AccessibleName = resources.GetString("EntryDateDateEdit.Properties.VistaTimeProperties.AccessibleName");
            this.EntryDateDateEdit.Properties.VistaTimeProperties.AutoHeight = ((bool)(resources.GetObject("EntryDateDateEdit.Properties.VistaTimeProperties.AutoHeight")));
            this.EntryDateDateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.EntryDateDateEdit.Properties.VistaTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("EntryDateDateEdit.Properties.VistaTimeProperties.Mask.AutoComplete")));
            this.EntryDateDateEdit.Properties.VistaTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("EntryDateDateEdit.Properties.VistaTimeProperties.Mask.BeepOnError")));
            this.EntryDateDateEdit.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("EntryDateDateEdit.Properties.VistaTimeProperties.Mask.EditMask");
            this.EntryDateDateEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("EntryDateDateEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank")));
            this.EntryDateDateEdit.Properties.VistaTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("EntryDateDateEdit.Properties.VistaTimeProperties.Mask.MaskType")));
            this.EntryDateDateEdit.Properties.VistaTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("EntryDateDateEdit.Properties.VistaTimeProperties.Mask.PlaceHolder")));
            this.EntryDateDateEdit.Properties.VistaTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("EntryDateDateEdit.Properties.VistaTimeProperties.Mask.SaveLiteral")));
            this.EntryDateDateEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("EntryDateDateEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders")));
            this.EntryDateDateEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("EntryDateDateEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat")));
            this.EntryDateDateEdit.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("EntryDateDateEdit.Properties.VistaTimeProperties.NullValuePrompt");
            this.EntryDateDateEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("EntryDateDateEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue" +
        "")));
            this.EntryDateDateEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForJobLevel
            // 
            this.ItemForJobLevel.Control = this.JobLevelLookUpEdit;
            resources.ApplyResources(this.ItemForJobLevel, "ItemForJobLevel");
            this.ItemForJobLevel.Location = new System.Drawing.Point(0, 24);
            this.ItemForJobLevel.Name = "ItemForJobLevel";
            this.ItemForJobLevel.Size = new System.Drawing.Size(386, 24);
            this.ItemForJobLevel.TextSize = new System.Drawing.Size(124, 14);
            // 
            // JobLevelLookUpEdit
            // 
            resources.ApplyResources(this.JobLevelLookUpEdit, "JobLevelLookUpEdit");
            this.JobLevelLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "JobLevelCode", true));
            this.JobLevelLookUpEdit.Name = "JobLevelLookUpEdit";
            this.JobLevelLookUpEdit.Properties.AccessibleDescription = resources.GetString("JobLevelLookUpEdit.Properties.AccessibleDescription");
            this.JobLevelLookUpEdit.Properties.AccessibleName = resources.GetString("JobLevelLookUpEdit.Properties.AccessibleName");
            this.JobLevelLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("JobLevelLookUpEdit.Properties.AutoHeight")));
            this.JobLevelLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("JobLevelLookUpEdit.Properties.Buttons"))))});
            this.JobLevelLookUpEdit.Properties.NullValuePrompt = resources.GetString("JobLevelLookUpEdit.Properties.NullValuePrompt");
            this.JobLevelLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("JobLevelLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.JobLevelLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForLastPromotionDate
            // 
            this.ItemForLastPromotionDate.Control = this.LastPromotionDateDateEdit;
            resources.ApplyResources(this.ItemForLastPromotionDate, "ItemForLastPromotionDate");
            this.ItemForLastPromotionDate.Location = new System.Drawing.Point(386, 24);
            this.ItemForLastPromotionDate.Name = "ItemForLastPromotionDate";
            this.ItemForLastPromotionDate.Size = new System.Drawing.Size(387, 24);
            this.ItemForLastPromotionDate.TextSize = new System.Drawing.Size(124, 14);
            // 
            // LastPromotionDateDateEdit
            // 
            resources.ApplyResources(this.LastPromotionDateDateEdit, "LastPromotionDateDateEdit");
            this.LastPromotionDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "LastPromotionDate", true));
            this.LastPromotionDateDateEdit.Name = "LastPromotionDateDateEdit";
            this.LastPromotionDateDateEdit.Properties.AccessibleDescription = resources.GetString("LastPromotionDateDateEdit.Properties.AccessibleDescription");
            this.LastPromotionDateDateEdit.Properties.AccessibleName = resources.GetString("LastPromotionDateDateEdit.Properties.AccessibleName");
            this.LastPromotionDateDateEdit.Properties.AutoHeight = ((bool)(resources.GetObject("LastPromotionDateDateEdit.Properties.AutoHeight")));
            this.LastPromotionDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("LastPromotionDateDateEdit.Properties.Buttons"))))});
            this.LastPromotionDateDateEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("LastPromotionDateDateEdit.Properties.Mask.AutoComplete")));
            this.LastPromotionDateDateEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("LastPromotionDateDateEdit.Properties.Mask.BeepOnError")));
            this.LastPromotionDateDateEdit.Properties.Mask.EditMask = resources.GetString("LastPromotionDateDateEdit.Properties.Mask.EditMask");
            this.LastPromotionDateDateEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("LastPromotionDateDateEdit.Properties.Mask.IgnoreMaskBlank")));
            this.LastPromotionDateDateEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("LastPromotionDateDateEdit.Properties.Mask.MaskType")));
            this.LastPromotionDateDateEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("LastPromotionDateDateEdit.Properties.Mask.PlaceHolder")));
            this.LastPromotionDateDateEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("LastPromotionDateDateEdit.Properties.Mask.SaveLiteral")));
            this.LastPromotionDateDateEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("LastPromotionDateDateEdit.Properties.Mask.ShowPlaceHolders")));
            this.LastPromotionDateDateEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("LastPromotionDateDateEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.LastPromotionDateDateEdit.Properties.NullValuePrompt = resources.GetString("LastPromotionDateDateEdit.Properties.NullValuePrompt");
            this.LastPromotionDateDateEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("LastPromotionDateDateEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.LastPromotionDateDateEdit.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("LastPromotionDateDateEdit.Properties.VistaTimeProperties.AccessibleDescription");
            this.LastPromotionDateDateEdit.Properties.VistaTimeProperties.AccessibleName = resources.GetString("LastPromotionDateDateEdit.Properties.VistaTimeProperties.AccessibleName");
            this.LastPromotionDateDateEdit.Properties.VistaTimeProperties.AutoHeight = ((bool)(resources.GetObject("LastPromotionDateDateEdit.Properties.VistaTimeProperties.AutoHeight")));
            this.LastPromotionDateDateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.LastPromotionDateDateEdit.Properties.VistaTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("LastPromotionDateDateEdit.Properties.VistaTimeProperties.Mask.AutoComplete")));
            this.LastPromotionDateDateEdit.Properties.VistaTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("LastPromotionDateDateEdit.Properties.VistaTimeProperties.Mask.BeepOnError")));
            this.LastPromotionDateDateEdit.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("LastPromotionDateDateEdit.Properties.VistaTimeProperties.Mask.EditMask");
            this.LastPromotionDateDateEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("LastPromotionDateDateEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank")));
            this.LastPromotionDateDateEdit.Properties.VistaTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("LastPromotionDateDateEdit.Properties.VistaTimeProperties.Mask.MaskType")));
            this.LastPromotionDateDateEdit.Properties.VistaTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("LastPromotionDateDateEdit.Properties.VistaTimeProperties.Mask.PlaceHolder")));
            this.LastPromotionDateDateEdit.Properties.VistaTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("LastPromotionDateDateEdit.Properties.VistaTimeProperties.Mask.SaveLiteral")));
            this.LastPromotionDateDateEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("LastPromotionDateDateEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders")));
            this.LastPromotionDateDateEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("LastPromotionDateDateEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFor" +
        "mat")));
            this.LastPromotionDateDateEdit.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("LastPromotionDateDateEdit.Properties.VistaTimeProperties.NullValuePrompt");
            this.LastPromotionDateDateEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("LastPromotionDateDateEdit.Properties.VistaTimeProperties.NullValuePromptShowForEm" +
        "ptyValue")));
            this.LastPromotionDateDateEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForTitle
            // 
            this.ItemForTitle.Control = this.TitleTextEdit;
            resources.ApplyResources(this.ItemForTitle, "ItemForTitle");
            this.ItemForTitle.Location = new System.Drawing.Point(0, 48);
            this.ItemForTitle.Name = "ItemForTitle";
            this.ItemForTitle.Size = new System.Drawing.Size(386, 24);
            this.ItemForTitle.TextSize = new System.Drawing.Size(124, 14);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem3, "emptySpaceItem3");
            this.emptySpaceItem3.Location = new System.Drawing.Point(386, 48);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(387, 24);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgPersonal
            // 
            resources.ApplyResources(this.lcgPersonal, "lcgPersonal");
            this.lcgPersonal.ExpandButtonVisible = true;
            this.lcgPersonal.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForLastName,
            this.ItemForFirstName,
            this.ItemForFullName,
            this.ItemGraduatedCollege,
            this.ItemForWorkExperience,
            this.ItemForTechnicalExpertise,
            this.ItemForEnglishLevel,
            this.ItemForEnglishCommunication,
            this.ItemForBirthDate,
            this.ItemForHobby,
            this.ItemForNativePlace,
            this.emptySpaceItem4});
            this.lcgPersonal.Location = new System.Drawing.Point(0, 232);
            this.lcgPersonal.Name = "lcgPersonal";
            this.lcgPersonal.Size = new System.Drawing.Size(797, 188);
            // 
            // ItemForLastName
            // 
            this.ItemForLastName.Control = this.LastNameTextEdit;
            resources.ApplyResources(this.ItemForLastName, "ItemForLastName");
            this.ItemForLastName.Location = new System.Drawing.Point(0, 0);
            this.ItemForLastName.Name = "ItemForLastName";
            this.ItemForLastName.Size = new System.Drawing.Size(386, 24);
            this.ItemForLastName.TextSize = new System.Drawing.Size(124, 14);
            // 
            // ItemForFirstName
            // 
            this.ItemForFirstName.Control = this.FirstNameTextEdit;
            resources.ApplyResources(this.ItemForFirstName, "ItemForFirstName");
            this.ItemForFirstName.Location = new System.Drawing.Point(386, 0);
            this.ItemForFirstName.Name = "ItemForFirstName";
            this.ItemForFirstName.Size = new System.Drawing.Size(387, 24);
            this.ItemForFirstName.TextSize = new System.Drawing.Size(124, 14);
            // 
            // ItemForFullName
            // 
            this.ItemForFullName.Control = this.FullNameLookUp;
            resources.ApplyResources(this.ItemForFullName, "ItemForFullName");
            this.ItemForFullName.Location = new System.Drawing.Point(0, 24);
            this.ItemForFullName.Name = "ItemForFullName";
            this.ItemForFullName.Size = new System.Drawing.Size(386, 24);
            this.ItemForFullName.TextSize = new System.Drawing.Size(124, 14);
            // 
            // FullNameLookUp
            // 
            resources.ApplyResources(this.FullNameLookUp, "FullNameLookUp");
            this.FullNameLookUp.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "FullName", true));
            this.FullNameLookUp.Name = "FullNameLookUp";
            this.FullNameLookUp.Properties.AccessibleDescription = resources.GetString("FullNameLookUp.Properties.AccessibleDescription");
            this.FullNameLookUp.Properties.AccessibleName = resources.GetString("FullNameLookUp.Properties.AccessibleName");
            this.FullNameLookUp.Properties.AutoHeight = ((bool)(resources.GetObject("FullNameLookUp.Properties.AutoHeight")));
            this.FullNameLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("FullNameLookUp.Properties.Buttons"))))});
            this.FullNameLookUp.Properties.MaxLength = 100;
            this.FullNameLookUp.Properties.NullValuePrompt = resources.GetString("FullNameLookUp.Properties.NullValuePrompt");
            this.FullNameLookUp.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("FullNameLookUp.Properties.NullValuePromptShowForEmptyValue")));
            this.FullNameLookUp.Properties.PopupSizeable = true;
            this.FullNameLookUp.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemGraduatedCollege
            // 
            this.ItemGraduatedCollege.Control = this.GraduatedCollegeTextEdit;
            resources.ApplyResources(this.ItemGraduatedCollege, "ItemGraduatedCollege");
            this.ItemGraduatedCollege.Location = new System.Drawing.Point(386, 24);
            this.ItemGraduatedCollege.MinSize = new System.Drawing.Size(182, 24);
            this.ItemGraduatedCollege.Name = "ItemGraduatedCollege";
            this.ItemGraduatedCollege.Size = new System.Drawing.Size(387, 24);
            this.ItemGraduatedCollege.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemGraduatedCollege.TextSize = new System.Drawing.Size(124, 14);
            // 
            // GraduatedCollegeTextEdit
            // 
            resources.ApplyResources(this.GraduatedCollegeTextEdit, "GraduatedCollegeTextEdit");
            this.GraduatedCollegeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "GraduatedCollege", true));
            this.GraduatedCollegeTextEdit.Name = "GraduatedCollegeTextEdit";
            this.GraduatedCollegeTextEdit.Properties.AccessibleDescription = resources.GetString("GraduatedCollegeTextEdit.Properties.AccessibleDescription");
            this.GraduatedCollegeTextEdit.Properties.AccessibleName = resources.GetString("GraduatedCollegeTextEdit.Properties.AccessibleName");
            this.GraduatedCollegeTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("GraduatedCollegeTextEdit.Properties.AutoHeight")));
            this.GraduatedCollegeTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("GraduatedCollegeTextEdit.Properties.Mask.AutoComplete")));
            this.GraduatedCollegeTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("GraduatedCollegeTextEdit.Properties.Mask.BeepOnError")));
            this.GraduatedCollegeTextEdit.Properties.Mask.EditMask = resources.GetString("GraduatedCollegeTextEdit.Properties.Mask.EditMask");
            this.GraduatedCollegeTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("GraduatedCollegeTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.GraduatedCollegeTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("GraduatedCollegeTextEdit.Properties.Mask.MaskType")));
            this.GraduatedCollegeTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("GraduatedCollegeTextEdit.Properties.Mask.PlaceHolder")));
            this.GraduatedCollegeTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("GraduatedCollegeTextEdit.Properties.Mask.SaveLiteral")));
            this.GraduatedCollegeTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("GraduatedCollegeTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.GraduatedCollegeTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("GraduatedCollegeTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.GraduatedCollegeTextEdit.Properties.MaxLength = 100;
            this.GraduatedCollegeTextEdit.Properties.NullValuePrompt = resources.GetString("GraduatedCollegeTextEdit.Properties.NullValuePrompt");
            this.GraduatedCollegeTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("GraduatedCollegeTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.GraduatedCollegeTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForWorkExperience
            // 
            this.ItemForWorkExperience.Control = this.WorkExperienceTextEdit;
            resources.ApplyResources(this.ItemForWorkExperience, "ItemForWorkExperience");
            this.ItemForWorkExperience.Location = new System.Drawing.Point(0, 48);
            this.ItemForWorkExperience.Name = "ItemForWorkExperience";
            this.ItemForWorkExperience.Size = new System.Drawing.Size(386, 24);
            this.ItemForWorkExperience.TextSize = new System.Drawing.Size(124, 14);
            // 
            // WorkExperienceTextEdit
            // 
            resources.ApplyResources(this.WorkExperienceTextEdit, "WorkExperienceTextEdit");
            this.WorkExperienceTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "WorkExperience", true));
            this.WorkExperienceTextEdit.Name = "WorkExperienceTextEdit";
            this.WorkExperienceTextEdit.Properties.AccessibleDescription = resources.GetString("WorkExperienceTextEdit.Properties.AccessibleDescription");
            this.WorkExperienceTextEdit.Properties.AccessibleName = resources.GetString("WorkExperienceTextEdit.Properties.AccessibleName");
            this.WorkExperienceTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("WorkExperienceTextEdit.Properties.AutoHeight")));
            this.WorkExperienceTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("WorkExperienceTextEdit.Properties.Mask.AutoComplete")));
            this.WorkExperienceTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("WorkExperienceTextEdit.Properties.Mask.BeepOnError")));
            this.WorkExperienceTextEdit.Properties.Mask.EditMask = resources.GetString("WorkExperienceTextEdit.Properties.Mask.EditMask");
            this.WorkExperienceTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("WorkExperienceTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.WorkExperienceTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("WorkExperienceTextEdit.Properties.Mask.MaskType")));
            this.WorkExperienceTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("WorkExperienceTextEdit.Properties.Mask.PlaceHolder")));
            this.WorkExperienceTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("WorkExperienceTextEdit.Properties.Mask.SaveLiteral")));
            this.WorkExperienceTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("WorkExperienceTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.WorkExperienceTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("WorkExperienceTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.WorkExperienceTextEdit.Properties.MaxLength = 50;
            this.WorkExperienceTextEdit.Properties.NullValuePrompt = resources.GetString("WorkExperienceTextEdit.Properties.NullValuePrompt");
            this.WorkExperienceTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("WorkExperienceTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.WorkExperienceTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForTechnicalExpertise
            // 
            this.ItemForTechnicalExpertise.Control = this.TechnicalExpertiseTextEdit;
            resources.ApplyResources(this.ItemForTechnicalExpertise, "ItemForTechnicalExpertise");
            this.ItemForTechnicalExpertise.Location = new System.Drawing.Point(386, 48);
            this.ItemForTechnicalExpertise.Name = "ItemForTechnicalExpertise";
            this.ItemForTechnicalExpertise.Size = new System.Drawing.Size(387, 24);
            this.ItemForTechnicalExpertise.TextSize = new System.Drawing.Size(124, 14);
            // 
            // TechnicalExpertiseTextEdit
            // 
            resources.ApplyResources(this.TechnicalExpertiseTextEdit, "TechnicalExpertiseTextEdit");
            this.TechnicalExpertiseTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "TechnicalExpertise", true));
            this.TechnicalExpertiseTextEdit.Name = "TechnicalExpertiseTextEdit";
            this.TechnicalExpertiseTextEdit.Properties.AccessibleDescription = resources.GetString("TechnicalExpertiseTextEdit.Properties.AccessibleDescription");
            this.TechnicalExpertiseTextEdit.Properties.AccessibleName = resources.GetString("TechnicalExpertiseTextEdit.Properties.AccessibleName");
            this.TechnicalExpertiseTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("TechnicalExpertiseTextEdit.Properties.AutoHeight")));
            this.TechnicalExpertiseTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("TechnicalExpertiseTextEdit.Properties.Mask.AutoComplete")));
            this.TechnicalExpertiseTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("TechnicalExpertiseTextEdit.Properties.Mask.BeepOnError")));
            this.TechnicalExpertiseTextEdit.Properties.Mask.EditMask = resources.GetString("TechnicalExpertiseTextEdit.Properties.Mask.EditMask");
            this.TechnicalExpertiseTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("TechnicalExpertiseTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.TechnicalExpertiseTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("TechnicalExpertiseTextEdit.Properties.Mask.MaskType")));
            this.TechnicalExpertiseTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("TechnicalExpertiseTextEdit.Properties.Mask.PlaceHolder")));
            this.TechnicalExpertiseTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("TechnicalExpertiseTextEdit.Properties.Mask.SaveLiteral")));
            this.TechnicalExpertiseTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("TechnicalExpertiseTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.TechnicalExpertiseTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("TechnicalExpertiseTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.TechnicalExpertiseTextEdit.Properties.MaxLength = 50;
            this.TechnicalExpertiseTextEdit.Properties.NullValuePrompt = resources.GetString("TechnicalExpertiseTextEdit.Properties.NullValuePrompt");
            this.TechnicalExpertiseTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("TechnicalExpertiseTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.TechnicalExpertiseTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForEnglishLevel
            // 
            this.ItemForEnglishLevel.Control = this.EnglishLevelTextEdit;
            resources.ApplyResources(this.ItemForEnglishLevel, "ItemForEnglishLevel");
            this.ItemForEnglishLevel.Location = new System.Drawing.Point(0, 72);
            this.ItemForEnglishLevel.Name = "ItemForEnglishLevel";
            this.ItemForEnglishLevel.Size = new System.Drawing.Size(386, 24);
            this.ItemForEnglishLevel.TextSize = new System.Drawing.Size(124, 14);
            // 
            // EnglishLevelTextEdit
            // 
            resources.ApplyResources(this.EnglishLevelTextEdit, "EnglishLevelTextEdit");
            this.EnglishLevelTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "EnglishLevel", true));
            this.EnglishLevelTextEdit.Name = "EnglishLevelTextEdit";
            this.EnglishLevelTextEdit.Properties.AccessibleDescription = resources.GetString("EnglishLevelTextEdit.Properties.AccessibleDescription");
            this.EnglishLevelTextEdit.Properties.AccessibleName = resources.GetString("EnglishLevelTextEdit.Properties.AccessibleName");
            this.EnglishLevelTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("EnglishLevelTextEdit.Properties.AutoHeight")));
            this.EnglishLevelTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("EnglishLevelTextEdit.Properties.Mask.AutoComplete")));
            this.EnglishLevelTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("EnglishLevelTextEdit.Properties.Mask.BeepOnError")));
            this.EnglishLevelTextEdit.Properties.Mask.EditMask = resources.GetString("EnglishLevelTextEdit.Properties.Mask.EditMask");
            this.EnglishLevelTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("EnglishLevelTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.EnglishLevelTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("EnglishLevelTextEdit.Properties.Mask.MaskType")));
            this.EnglishLevelTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("EnglishLevelTextEdit.Properties.Mask.PlaceHolder")));
            this.EnglishLevelTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("EnglishLevelTextEdit.Properties.Mask.SaveLiteral")));
            this.EnglishLevelTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("EnglishLevelTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.EnglishLevelTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("EnglishLevelTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.EnglishLevelTextEdit.Properties.MaxLength = 50;
            this.EnglishLevelTextEdit.Properties.NullValuePrompt = resources.GetString("EnglishLevelTextEdit.Properties.NullValuePrompt");
            this.EnglishLevelTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("EnglishLevelTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.EnglishLevelTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForEnglishCommunication
            // 
            this.ItemForEnglishCommunication.Control = this.EnglishCommunicationTextEdit;
            resources.ApplyResources(this.ItemForEnglishCommunication, "ItemForEnglishCommunication");
            this.ItemForEnglishCommunication.Location = new System.Drawing.Point(386, 72);
            this.ItemForEnglishCommunication.Name = "ItemForEnglishCommunication";
            this.ItemForEnglishCommunication.Size = new System.Drawing.Size(387, 24);
            this.ItemForEnglishCommunication.TextSize = new System.Drawing.Size(124, 14);
            // 
            // EnglishCommunicationTextEdit
            // 
            resources.ApplyResources(this.EnglishCommunicationTextEdit, "EnglishCommunicationTextEdit");
            this.EnglishCommunicationTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "EnglishCommunication", true));
            this.EnglishCommunicationTextEdit.Name = "EnglishCommunicationTextEdit";
            this.EnglishCommunicationTextEdit.Properties.AccessibleDescription = resources.GetString("EnglishCommunicationTextEdit.Properties.AccessibleDescription");
            this.EnglishCommunicationTextEdit.Properties.AccessibleName = resources.GetString("EnglishCommunicationTextEdit.Properties.AccessibleName");
            this.EnglishCommunicationTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("EnglishCommunicationTextEdit.Properties.AutoHeight")));
            this.EnglishCommunicationTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("EnglishCommunicationTextEdit.Properties.Mask.AutoComplete")));
            this.EnglishCommunicationTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("EnglishCommunicationTextEdit.Properties.Mask.BeepOnError")));
            this.EnglishCommunicationTextEdit.Properties.Mask.EditMask = resources.GetString("EnglishCommunicationTextEdit.Properties.Mask.EditMask");
            this.EnglishCommunicationTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("EnglishCommunicationTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.EnglishCommunicationTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("EnglishCommunicationTextEdit.Properties.Mask.MaskType")));
            this.EnglishCommunicationTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("EnglishCommunicationTextEdit.Properties.Mask.PlaceHolder")));
            this.EnglishCommunicationTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("EnglishCommunicationTextEdit.Properties.Mask.SaveLiteral")));
            this.EnglishCommunicationTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("EnglishCommunicationTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.EnglishCommunicationTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("EnglishCommunicationTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.EnglishCommunicationTextEdit.Properties.MaxLength = 50;
            this.EnglishCommunicationTextEdit.Properties.NullValuePrompt = resources.GetString("EnglishCommunicationTextEdit.Properties.NullValuePrompt");
            this.EnglishCommunicationTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("EnglishCommunicationTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.EnglishCommunicationTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForBirthDate
            // 
            this.ItemForBirthDate.Control = this.BirthDateDateEdit;
            resources.ApplyResources(this.ItemForBirthDate, "ItemForBirthDate");
            this.ItemForBirthDate.Location = new System.Drawing.Point(0, 96);
            this.ItemForBirthDate.Name = "ItemForBirthDate";
            this.ItemForBirthDate.Size = new System.Drawing.Size(386, 24);
            this.ItemForBirthDate.TextSize = new System.Drawing.Size(124, 14);
            // 
            // BirthDateDateEdit
            // 
            resources.ApplyResources(this.BirthDateDateEdit, "BirthDateDateEdit");
            this.BirthDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "BirthDate", true));
            this.BirthDateDateEdit.Name = "BirthDateDateEdit";
            this.BirthDateDateEdit.Properties.AccessibleDescription = resources.GetString("BirthDateDateEdit.Properties.AccessibleDescription");
            this.BirthDateDateEdit.Properties.AccessibleName = resources.GetString("BirthDateDateEdit.Properties.AccessibleName");
            this.BirthDateDateEdit.Properties.AutoHeight = ((bool)(resources.GetObject("BirthDateDateEdit.Properties.AutoHeight")));
            this.BirthDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("BirthDateDateEdit.Properties.Buttons"))))});
            this.BirthDateDateEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("BirthDateDateEdit.Properties.Mask.AutoComplete")));
            this.BirthDateDateEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("BirthDateDateEdit.Properties.Mask.BeepOnError")));
            this.BirthDateDateEdit.Properties.Mask.EditMask = resources.GetString("BirthDateDateEdit.Properties.Mask.EditMask");
            this.BirthDateDateEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("BirthDateDateEdit.Properties.Mask.IgnoreMaskBlank")));
            this.BirthDateDateEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("BirthDateDateEdit.Properties.Mask.MaskType")));
            this.BirthDateDateEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("BirthDateDateEdit.Properties.Mask.PlaceHolder")));
            this.BirthDateDateEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("BirthDateDateEdit.Properties.Mask.SaveLiteral")));
            this.BirthDateDateEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("BirthDateDateEdit.Properties.Mask.ShowPlaceHolders")));
            this.BirthDateDateEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("BirthDateDateEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.BirthDateDateEdit.Properties.NullValuePrompt = resources.GetString("BirthDateDateEdit.Properties.NullValuePrompt");
            this.BirthDateDateEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("BirthDateDateEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.BirthDateDateEdit.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("BirthDateDateEdit.Properties.VistaTimeProperties.AccessibleDescription");
            this.BirthDateDateEdit.Properties.VistaTimeProperties.AccessibleName = resources.GetString("BirthDateDateEdit.Properties.VistaTimeProperties.AccessibleName");
            this.BirthDateDateEdit.Properties.VistaTimeProperties.AutoHeight = ((bool)(resources.GetObject("BirthDateDateEdit.Properties.VistaTimeProperties.AutoHeight")));
            this.BirthDateDateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.BirthDateDateEdit.Properties.VistaTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("BirthDateDateEdit.Properties.VistaTimeProperties.Mask.AutoComplete")));
            this.BirthDateDateEdit.Properties.VistaTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("BirthDateDateEdit.Properties.VistaTimeProperties.Mask.BeepOnError")));
            this.BirthDateDateEdit.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("BirthDateDateEdit.Properties.VistaTimeProperties.Mask.EditMask");
            this.BirthDateDateEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("BirthDateDateEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank")));
            this.BirthDateDateEdit.Properties.VistaTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("BirthDateDateEdit.Properties.VistaTimeProperties.Mask.MaskType")));
            this.BirthDateDateEdit.Properties.VistaTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("BirthDateDateEdit.Properties.VistaTimeProperties.Mask.PlaceHolder")));
            this.BirthDateDateEdit.Properties.VistaTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("BirthDateDateEdit.Properties.VistaTimeProperties.Mask.SaveLiteral")));
            this.BirthDateDateEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("BirthDateDateEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders")));
            this.BirthDateDateEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("BirthDateDateEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat")));
            this.BirthDateDateEdit.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("BirthDateDateEdit.Properties.VistaTimeProperties.NullValuePrompt");
            this.BirthDateDateEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("BirthDateDateEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue" +
        "")));
            this.BirthDateDateEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForHobby
            // 
            this.ItemForHobby.Control = this.HobbyTextEdit;
            resources.ApplyResources(this.ItemForHobby, "ItemForHobby");
            this.ItemForHobby.Location = new System.Drawing.Point(386, 96);
            this.ItemForHobby.Name = "ItemForHobby";
            this.ItemForHobby.Size = new System.Drawing.Size(387, 24);
            this.ItemForHobby.TextSize = new System.Drawing.Size(124, 14);
            // 
            // HobbyTextEdit
            // 
            resources.ApplyResources(this.HobbyTextEdit, "HobbyTextEdit");
            this.HobbyTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "Hobby", true));
            this.HobbyTextEdit.Name = "HobbyTextEdit";
            this.HobbyTextEdit.Properties.AccessibleDescription = resources.GetString("HobbyTextEdit.Properties.AccessibleDescription");
            this.HobbyTextEdit.Properties.AccessibleName = resources.GetString("HobbyTextEdit.Properties.AccessibleName");
            this.HobbyTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("HobbyTextEdit.Properties.AutoHeight")));
            this.HobbyTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("HobbyTextEdit.Properties.Mask.AutoComplete")));
            this.HobbyTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("HobbyTextEdit.Properties.Mask.BeepOnError")));
            this.HobbyTextEdit.Properties.Mask.EditMask = resources.GetString("HobbyTextEdit.Properties.Mask.EditMask");
            this.HobbyTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("HobbyTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.HobbyTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("HobbyTextEdit.Properties.Mask.MaskType")));
            this.HobbyTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("HobbyTextEdit.Properties.Mask.PlaceHolder")));
            this.HobbyTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("HobbyTextEdit.Properties.Mask.SaveLiteral")));
            this.HobbyTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("HobbyTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.HobbyTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("HobbyTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.HobbyTextEdit.Properties.MaxLength = 100;
            this.HobbyTextEdit.Properties.NullValuePrompt = resources.GetString("HobbyTextEdit.Properties.NullValuePrompt");
            this.HobbyTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("HobbyTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.HobbyTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForNativePlace
            // 
            this.ItemForNativePlace.Control = this.NativePlaceTextEdit;
            resources.ApplyResources(this.ItemForNativePlace, "ItemForNativePlace");
            this.ItemForNativePlace.Location = new System.Drawing.Point(0, 120);
            this.ItemForNativePlace.Name = "ItemForNativePlace";
            this.ItemForNativePlace.Size = new System.Drawing.Size(386, 24);
            this.ItemForNativePlace.TextSize = new System.Drawing.Size(124, 14);
            // 
            // NativePlaceTextEdit
            // 
            resources.ApplyResources(this.NativePlaceTextEdit, "NativePlaceTextEdit");
            this.NativePlaceTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "NativePlace", true));
            this.NativePlaceTextEdit.Name = "NativePlaceTextEdit";
            this.NativePlaceTextEdit.Properties.AccessibleDescription = resources.GetString("NativePlaceTextEdit.Properties.AccessibleDescription");
            this.NativePlaceTextEdit.Properties.AccessibleName = resources.GetString("NativePlaceTextEdit.Properties.AccessibleName");
            this.NativePlaceTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("NativePlaceTextEdit.Properties.AutoHeight")));
            this.NativePlaceTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("NativePlaceTextEdit.Properties.Mask.AutoComplete")));
            this.NativePlaceTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("NativePlaceTextEdit.Properties.Mask.BeepOnError")));
            this.NativePlaceTextEdit.Properties.Mask.EditMask = resources.GetString("NativePlaceTextEdit.Properties.Mask.EditMask");
            this.NativePlaceTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("NativePlaceTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.NativePlaceTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("NativePlaceTextEdit.Properties.Mask.MaskType")));
            this.NativePlaceTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("NativePlaceTextEdit.Properties.Mask.PlaceHolder")));
            this.NativePlaceTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("NativePlaceTextEdit.Properties.Mask.SaveLiteral")));
            this.NativePlaceTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("NativePlaceTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.NativePlaceTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("NativePlaceTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.NativePlaceTextEdit.Properties.MaxLength = 100;
            this.NativePlaceTextEdit.Properties.NullValuePrompt = resources.GetString("NativePlaceTextEdit.Properties.NullValuePrompt");
            this.NativePlaceTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("NativePlaceTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.NativePlaceTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem4, "emptySpaceItem4");
            this.emptySpaceItem4.Location = new System.Drawing.Point(386, 120);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(387, 24);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgContact
            // 
            resources.ApplyResources(this.lcgContact, "lcgContact");
            this.lcgContact.ExpandButtonVisible = true;
            this.lcgContact.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForMSN,
            this.ItemForEmailAddress,
            this.ItemForQQ,
            this.ItemForHomePhone,
            this.ItemForMobilePhone,
            this.emptySpaceItem5});
            this.lcgContact.Location = new System.Drawing.Point(0, 420);
            this.lcgContact.Name = "lcgContact";
            this.lcgContact.Size = new System.Drawing.Size(797, 116);
            // 
            // ItemForMSN
            // 
            this.ItemForMSN.Control = this.MSNTextEdit;
            resources.ApplyResources(this.ItemForMSN, "ItemForMSN");
            this.ItemForMSN.Location = new System.Drawing.Point(0, 0);
            this.ItemForMSN.Name = "ItemForMSN";
            this.ItemForMSN.Size = new System.Drawing.Size(386, 24);
            this.ItemForMSN.TextSize = new System.Drawing.Size(124, 14);
            // 
            // MSNTextEdit
            // 
            resources.ApplyResources(this.MSNTextEdit, "MSNTextEdit");
            this.MSNTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "MSN", true));
            this.MSNTextEdit.Name = "MSNTextEdit";
            this.MSNTextEdit.Properties.AccessibleDescription = resources.GetString("MSNTextEdit.Properties.AccessibleDescription");
            this.MSNTextEdit.Properties.AccessibleName = resources.GetString("MSNTextEdit.Properties.AccessibleName");
            this.MSNTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("MSNTextEdit.Properties.AutoHeight")));
            this.MSNTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("MSNTextEdit.Properties.Mask.AutoComplete")));
            this.MSNTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("MSNTextEdit.Properties.Mask.BeepOnError")));
            this.MSNTextEdit.Properties.Mask.EditMask = resources.GetString("MSNTextEdit.Properties.Mask.EditMask");
            this.MSNTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("MSNTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.MSNTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("MSNTextEdit.Properties.Mask.MaskType")));
            this.MSNTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("MSNTextEdit.Properties.Mask.PlaceHolder")));
            this.MSNTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("MSNTextEdit.Properties.Mask.SaveLiteral")));
            this.MSNTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("MSNTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.MSNTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("MSNTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.MSNTextEdit.Properties.MaxLength = 50;
            this.MSNTextEdit.Properties.NullValuePrompt = resources.GetString("MSNTextEdit.Properties.NullValuePrompt");
            this.MSNTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("MSNTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.MSNTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForEmailAddress
            // 
            this.ItemForEmailAddress.Control = this.EmailAddressTextEdit;
            resources.ApplyResources(this.ItemForEmailAddress, "ItemForEmailAddress");
            this.ItemForEmailAddress.Location = new System.Drawing.Point(386, 0);
            this.ItemForEmailAddress.Name = "ItemForEmailAddress";
            this.ItemForEmailAddress.Size = new System.Drawing.Size(387, 24);
            this.ItemForEmailAddress.TextSize = new System.Drawing.Size(124, 14);
            // 
            // ItemForQQ
            // 
            this.ItemForQQ.Control = this.QQTextEdit;
            resources.ApplyResources(this.ItemForQQ, "ItemForQQ");
            this.ItemForQQ.Location = new System.Drawing.Point(0, 24);
            this.ItemForQQ.Name = "ItemForQQ";
            this.ItemForQQ.Size = new System.Drawing.Size(386, 24);
            this.ItemForQQ.TextSize = new System.Drawing.Size(124, 14);
            // 
            // QQTextEdit
            // 
            resources.ApplyResources(this.QQTextEdit, "QQTextEdit");
            this.QQTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "QQ", true));
            this.QQTextEdit.Name = "QQTextEdit";
            this.QQTextEdit.Properties.AccessibleDescription = resources.GetString("QQTextEdit.Properties.AccessibleDescription");
            this.QQTextEdit.Properties.AccessibleName = resources.GetString("QQTextEdit.Properties.AccessibleName");
            this.QQTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("QQTextEdit.Properties.AutoHeight")));
            this.QQTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("QQTextEdit.Properties.Mask.AutoComplete")));
            this.QQTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("QQTextEdit.Properties.Mask.BeepOnError")));
            this.QQTextEdit.Properties.Mask.EditMask = resources.GetString("QQTextEdit.Properties.Mask.EditMask");
            this.QQTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("QQTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.QQTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("QQTextEdit.Properties.Mask.MaskType")));
            this.QQTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("QQTextEdit.Properties.Mask.PlaceHolder")));
            this.QQTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("QQTextEdit.Properties.Mask.SaveLiteral")));
            this.QQTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("QQTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.QQTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("QQTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.QQTextEdit.Properties.MaxLength = 50;
            this.QQTextEdit.Properties.NullValuePrompt = resources.GetString("QQTextEdit.Properties.NullValuePrompt");
            this.QQTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("QQTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.QQTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForHomePhone
            // 
            this.ItemForHomePhone.Control = this.HomePhoneTextEdit;
            resources.ApplyResources(this.ItemForHomePhone, "ItemForHomePhone");
            this.ItemForHomePhone.Location = new System.Drawing.Point(386, 24);
            this.ItemForHomePhone.Name = "ItemForHomePhone";
            this.ItemForHomePhone.Size = new System.Drawing.Size(387, 24);
            this.ItemForHomePhone.TextSize = new System.Drawing.Size(124, 14);
            // 
            // ItemForMobilePhone
            // 
            this.ItemForMobilePhone.Control = this.MobilePhoneTextEdit;
            resources.ApplyResources(this.ItemForMobilePhone, "ItemForMobilePhone");
            this.ItemForMobilePhone.Location = new System.Drawing.Point(0, 48);
            this.ItemForMobilePhone.Name = "ItemForMobilePhone";
            this.ItemForMobilePhone.Size = new System.Drawing.Size(386, 24);
            this.ItemForMobilePhone.TextSize = new System.Drawing.Size(124, 14);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem5, "emptySpaceItem5");
            this.emptySpaceItem5.Location = new System.Drawing.Point(386, 48);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(387, 24);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // managementLayoutControlGroup
            // 
            resources.ApplyResources(this.managementLayoutControlGroup, "managementLayoutControlGroup");
            this.managementLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForCreatedBy,
            this.ItemForCreatedOn,
            this.ItemForModifiedOn,
            this.ItemForModifiedBy});
            this.managementLayoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.managementLayoutControlGroup.Name = "managementLayoutControlGroup";
            this.managementLayoutControlGroup.Size = new System.Drawing.Size(797, 536);
            // 
            // ItemForCreatedBy
            // 
            this.ItemForCreatedBy.Control = this.textEdit2;
            resources.ApplyResources(this.ItemForCreatedBy, "ItemForCreatedBy");
            this.ItemForCreatedBy.Location = new System.Drawing.Point(359, 0);
            this.ItemForCreatedBy.Name = "ItemForCreatedBy";
            this.ItemForCreatedBy.Size = new System.Drawing.Size(438, 24);
            this.ItemForCreatedBy.TextSize = new System.Drawing.Size(124, 14);
            // 
            // textEdit2
            // 
            resources.ApplyResources(this.textEdit2, "textEdit2");
            this.textEdit2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "CreatedBy.FullName", true));
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
            // ItemForCreatedOn
            // 
            this.ItemForCreatedOn.Control = this.textEdit1;
            resources.ApplyResources(this.ItemForCreatedOn, "ItemForCreatedOn");
            this.ItemForCreatedOn.Location = new System.Drawing.Point(0, 0);
            this.ItemForCreatedOn.Name = "ItemForCreatedOn";
            this.ItemForCreatedOn.Size = new System.Drawing.Size(359, 24);
            this.ItemForCreatedOn.TextSize = new System.Drawing.Size(124, 14);
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
            // ItemForModifiedOn
            // 
            this.ItemForModifiedOn.Control = this.textEdit3;
            resources.ApplyResources(this.ItemForModifiedOn, "ItemForModifiedOn");
            this.ItemForModifiedOn.Location = new System.Drawing.Point(0, 24);
            this.ItemForModifiedOn.Name = "ItemForModifiedOn";
            this.ItemForModifiedOn.Size = new System.Drawing.Size(359, 512);
            this.ItemForModifiedOn.TextSize = new System.Drawing.Size(124, 14);
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
            this.ItemForModifiedBy.Location = new System.Drawing.Point(359, 24);
            this.ItemForModifiedBy.Name = "ItemForModifiedBy";
            this.ItemForModifiedBy.Size = new System.Drawing.Size(438, 512);
            this.ItemForModifiedBy.TextSize = new System.Drawing.Size(124, 14);
            // 
            // textEdit4
            // 
            resources.ApplyResources(this.textEdit4, "textEdit4");
            this.textEdit4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "ModifiedBy.FullName", true));
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
            // UserDetailView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UserDetailView";
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).EndInit();
            this.EntityDataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConfirmPasswordTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailAddressTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomePhoneTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MobilePhoneTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NickNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNickName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForConfirmPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDepartmentId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentIdLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEntryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntryDateDateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntryDateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForJobLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JobLevelLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastPromotionDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastPromotionDateDateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastPromotionDateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPersonal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFullName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullNameLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGraduatedCollege)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraduatedCollegeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForWorkExperience)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkExperienceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTechnicalExpertise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TechnicalExpertiseTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEnglishLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnglishLevelTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEnglishCommunication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnglishCommunicationTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBirthDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BirthDateDateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BirthDateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForHobby)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HobbyTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNativePlace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NativePlaceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMSN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MSNTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEmailAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForQQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QQTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForHomePhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMobilePhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.managementLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit EmailAddressTextEdit;
        private DevExpress.XtraEditors.TextEdit FirstNameTextEdit;
        private DevExpress.XtraEditors.TextEdit HomePhoneTextEdit;
        private DevExpress.XtraEditors.TextEdit LastNameTextEdit;
        private DevExpress.XtraEditors.TextEdit MobilePhoneTextEdit;
        private DevExpress.XtraEditors.TextEdit NickNameTextEdit;
        private DevExpress.XtraEditors.TextEdit PasswordTextEdit;
        private DevExpress.XtraEditors.TextEdit TitleTextEdit;
        private DevExpress.XtraEditors.TextEdit UserNameTextEdit;
        private DevExpress.XtraEditors.TextEdit ConfirmPasswordTextEdit;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup managementLayoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlGroup lcgGeneral;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEmailAddress;
        private DevExpress.XtraLayout.LayoutControlItem ItemForHomePhone;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMobilePhone;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUserName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForFirstName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNickName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPassword;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTitle;
        private DevExpress.XtraLayout.LayoutControlItem ItemForConfirmPassword;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLastName;
        private DevExpress.XtraEditors.TextEdit textEdit4;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreatedBy;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreatedOn;
        private DevExpress.XtraLayout.LayoutControlItem ItemForModifiedOn;
        private DevExpress.XtraLayout.LayoutControlItem ItemForModifiedBy;
        private DevExpress.XtraEditors.LookUpEdit DepartmentIdLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDepartmentId;
        private DevExpress.XtraEditors.TextEdit NativePlaceTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNativePlace;
        private DevExpress.XtraEditors.TextEdit GraduatedCollegeTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemGraduatedCollege;
        private DevExpress.XtraEditors.TextEdit EnglishLevelTextEdit;
        private DevExpress.XtraEditors.TextEdit EnglishCommunicationTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEntryDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEnglishCommunication;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEnglishLevel;
        private DevExpress.XtraEditors.TextEdit WorkExperienceTextEdit;
        private DevExpress.XtraEditors.TextEdit HobbyTextEdit;
        private DevExpress.XtraEditors.TextEdit MSNTextEdit;
        private DevExpress.XtraEditors.TextEdit QQTextEdit;
        private DevExpress.XtraEditors.TextEdit TechnicalExpertiseTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForQQ;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTechnicalExpertise;
        private DevExpress.XtraLayout.LayoutControlItem ItemForBirthDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMSN;
        private DevExpress.XtraLayout.LayoutControlItem ItemForHobby;
        private DevExpress.XtraLayout.LayoutControlItem ItemForWorkExperience;
        private DropDownDateEdit BirthDateDateEdit;
        private DropDownDateEdit EntryDateDateEdit;
        private DevExpress.XtraEditors.LookUpEdit JobLevelLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForJobLevel;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLastPromotionDate;
        private DropDownDateEdit LastPromotionDateDateEdit;
        private MyGridLookUpEdit roleLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.ComboBoxEdit FullNameLookUp;
        private DevExpress.XtraLayout.LayoutControlItem ItemForFullName;
        private DevExpress.XtraLayout.LayoutControlGroup lcgAccount;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgPosition;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlGroup lcgPersonal;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.LayoutControlGroup lcgContact;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;      
    }
}
