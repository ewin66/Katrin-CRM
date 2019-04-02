using System;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.WinForms.Controls;

namespace Katrin.Win.OpportunityModule
{
    partial class OpportunityDetailView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpportunityDetailView));
            this.topicTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DescriptionTextEdit = new DevExpress.XtraEditors.MemoEdit();
            this.EstimatedCloseDateTextEdit = new Katrin.AppFramework.WinForms.Controls.DropDownDateEdit();
            this.StatusCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.OpportunityRatingCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.PriorityCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.OpportunityTypeCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.SalesStageCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.EstimatedValueSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.StepNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.TransacitionCurrencyIdLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.CloseProbabilitySpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.DepartmentLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.lcgGeneral = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTransacitionCurrencyId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCloseProbability = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForOriginatingLeadId = new DevExpress.XtraLayout.LayoutControlItem();
            this.OriginatingLeadIdSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lcgDetails = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForStatusCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForOpportunityTypeCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForOpportunityRatingCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPriorityCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForStepName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSalesStageCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.technologyItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.technologyCodeLookUpEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.latestFeedbackOnItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.latestFeedBackOnDateEdit = new Katrin.AppFramework.WinForms.Controls.DropDownDateEdit();
            this.estimatedWorkAmountItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.estimatedWorkAmountSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.projectTypeItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.projectTypeCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.technicianItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.technicianIdSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.expectedStartOnItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.expectedStartOnDateEdit = new Katrin.AppFramework.WinForms.Controls.DropDownDateEdit();
            this.ItemForCustomerId = new DevExpress.XtraLayout.LayoutControlItem();
            this.CustomerIdSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.ItemForEstimatedValue = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForEstimatedCloseDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.managementLayoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForDepartment = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForOwnerId = new DevExpress.XtraLayout.LayoutControlItem();
            this.OwnerIdSearchLookUpEdit = new DevExpress.XtraEditors.PopupContainerEdit();
            this.ItemForCreatedOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.ItemForCreatedBy = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.ItemForModifiedOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.ItemForModifiedBy = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ValidationProviderRecommend = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).BeginInit();
            this.EntityDataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topicTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimatedCloseDateTextEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimatedCloseDateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusCodeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpportunityRatingCodeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorityCodeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpportunityTypeCodeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesStageCodeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimatedValueSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransacitionCurrencyIdLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseProbabilitySpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTransacitionCurrencyId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCloseProbability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOriginatingLeadId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginatingLeadIdSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOpportunityTypeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOpportunityRatingCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPriorityCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStepName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSalesStageCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.technologyItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.technologyCodeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.latestFeedbackOnItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.latestFeedBackOnDateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.latestFeedBackOnDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estimatedWorkAmountItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estimatedWorkAmountSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectTypeItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectTypeCodeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.technicianItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.technicianIdSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expectedStartOnItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expectedStartOnDateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expectedStartOnDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCustomerId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerIdSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEstimatedValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEstimatedCloseDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.managementLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOwnerId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OwnerIdSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProviderRecommend)).BeginInit();
            this.SuspendLayout();
            // 
            // EntityDataLayoutControl
            // 
            resources.ApplyResources(this.EntityDataLayoutControl, "EntityDataLayoutControl");
            this.EntityDataLayoutControl.Controls.Add(this.textEdit4);
            this.EntityDataLayoutControl.Controls.Add(this.estimatedWorkAmountSpinEdit);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit3);
            this.EntityDataLayoutControl.Controls.Add(this.expectedStartOnDateEdit);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit2);
            this.EntityDataLayoutControl.Controls.Add(this.latestFeedBackOnDateEdit);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit1);
            this.EntityDataLayoutControl.Controls.Add(this.technicianIdSearchLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.technologyCodeLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.projectTypeCodeLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.DepartmentLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.topicTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.DescriptionTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.EstimatedCloseDateTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.StatusCodeLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.OpportunityRatingCodeLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.PriorityCodeLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.OpportunityTypeCodeLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.SalesStageCodeLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.EstimatedValueSpinEdit);
            this.EntityDataLayoutControl.Controls.Add(this.StepNameTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.TransacitionCurrencyIdLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.CloseProbabilitySpinEdit);
            this.EntityDataLayoutControl.Controls.Add(this.CustomerIdSearchLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.OriginatingLeadIdSearchLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.OwnerIdSearchLookUpEdit);
            this.EntityDataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(697, 167, 453, 499);
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
            this.RootLayoutControlGroup.Size = new System.Drawing.Size(910, 435);
            // 
            // topicTextEdit
            // 
            resources.ApplyResources(this.topicTextEdit, "topicTextEdit");
            this.topicTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Name", true));
            this.topicTextEdit.Name = "topicTextEdit";
            this.topicTextEdit.Properties.AccessibleDescription = resources.GetString("topicTextEdit.Properties.AccessibleDescription");
            this.topicTextEdit.Properties.AccessibleName = resources.GetString("topicTextEdit.Properties.AccessibleName");
            this.topicTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("topicTextEdit.Properties.AutoHeight")));
            this.topicTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("topicTextEdit.Properties.Mask.AutoComplete")));
            this.topicTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("topicTextEdit.Properties.Mask.BeepOnError")));
            this.topicTextEdit.Properties.Mask.EditMask = resources.GetString("topicTextEdit.Properties.Mask.EditMask");
            this.topicTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("topicTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.topicTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("topicTextEdit.Properties.Mask.MaskType")));
            this.topicTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("topicTextEdit.Properties.Mask.PlaceHolder")));
            this.topicTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("topicTextEdit.Properties.Mask.SaveLiteral")));
            this.topicTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("topicTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.topicTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("topicTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.topicTextEdit.Properties.NullValuePrompt = resources.GetString("topicTextEdit.Properties.NullValuePrompt");
            this.topicTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("topicTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.topicTextEdit.StyleController = this.EntityDataLayoutControl;
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
            // EstimatedCloseDateTextEdit
            // 
            resources.ApplyResources(this.EstimatedCloseDateTextEdit, "EstimatedCloseDateTextEdit");
            this.EstimatedCloseDateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "EstimatedCloseDate", true));
            this.EstimatedCloseDateTextEdit.Name = "EstimatedCloseDateTextEdit";
            this.EstimatedCloseDateTextEdit.Properties.AccessibleDescription = resources.GetString("EstimatedCloseDateTextEdit.Properties.AccessibleDescription");
            this.EstimatedCloseDateTextEdit.Properties.AccessibleName = resources.GetString("EstimatedCloseDateTextEdit.Properties.AccessibleName");
            this.EstimatedCloseDateTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("EstimatedCloseDateTextEdit.Properties.AutoHeight")));
            this.EstimatedCloseDateTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("EstimatedCloseDateTextEdit.Properties.Buttons"))))});
            this.EstimatedCloseDateTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("EstimatedCloseDateTextEdit.Properties.Mask.AutoComplete")));
            this.EstimatedCloseDateTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("EstimatedCloseDateTextEdit.Properties.Mask.BeepOnError")));
            this.EstimatedCloseDateTextEdit.Properties.Mask.EditMask = resources.GetString("EstimatedCloseDateTextEdit.Properties.Mask.EditMask");
            this.EstimatedCloseDateTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("EstimatedCloseDateTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.EstimatedCloseDateTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("EstimatedCloseDateTextEdit.Properties.Mask.MaskType")));
            this.EstimatedCloseDateTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("EstimatedCloseDateTextEdit.Properties.Mask.PlaceHolder")));
            this.EstimatedCloseDateTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("EstimatedCloseDateTextEdit.Properties.Mask.SaveLiteral")));
            this.EstimatedCloseDateTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("EstimatedCloseDateTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.EstimatedCloseDateTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("EstimatedCloseDateTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.EstimatedCloseDateTextEdit.Properties.NullValuePrompt = resources.GetString("EstimatedCloseDateTextEdit.Properties.NullValuePrompt");
            this.EstimatedCloseDateTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("EstimatedCloseDateTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.AccessibleDescription");
            this.EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.AccessibleName = resources.GetString("EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.AccessibleName");
            this.EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.AutoHeight = ((bool)(resources.GetObject("EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.AutoHeight")));
            this.EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.Mask.AutoComplete")));
            this.EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.Mask.BeepOnError")));
            this.EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.Mask.EditMask");
            this.EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank")));
            this.EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.Mask.MaskType")));
            this.EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.Mask.PlaceHolder")));
            this.EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.Mask.SaveLiteral")));
            this.EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders")));
            this.EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFo" +
        "rmat")));
            this.EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.NullValuePrompt");
            this.EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("EstimatedCloseDateTextEdit.Properties.VistaTimeProperties.NullValuePromptShowForE" +
        "mptyValue")));
            this.EstimatedCloseDateTextEdit.StyleController = this.EntityDataLayoutControl;
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
            // OpportunityRatingCodeLookUpEdit
            // 
            resources.ApplyResources(this.OpportunityRatingCodeLookUpEdit, "OpportunityRatingCodeLookUpEdit");
            this.OpportunityRatingCodeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "OpportunityRatingCode", true));
            this.OpportunityRatingCodeLookUpEdit.Name = "OpportunityRatingCodeLookUpEdit";
            this.OpportunityRatingCodeLookUpEdit.Properties.AccessibleDescription = resources.GetString("OpportunityRatingCodeLookUpEdit.Properties.AccessibleDescription");
            this.OpportunityRatingCodeLookUpEdit.Properties.AccessibleName = resources.GetString("OpportunityRatingCodeLookUpEdit.Properties.AccessibleName");
            this.OpportunityRatingCodeLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("OpportunityRatingCodeLookUpEdit.Properties.AutoHeight")));
            this.OpportunityRatingCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("OpportunityRatingCodeLookUpEdit.Properties.Buttons"))))});
            this.OpportunityRatingCodeLookUpEdit.Properties.NullText = resources.GetString("OpportunityRatingCodeLookUpEdit.Properties.NullText");
            this.OpportunityRatingCodeLookUpEdit.Properties.NullValuePrompt = resources.GetString("OpportunityRatingCodeLookUpEdit.Properties.NullValuePrompt");
            this.OpportunityRatingCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("OpportunityRatingCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.OpportunityRatingCodeLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // PriorityCodeLookUpEdit
            // 
            resources.ApplyResources(this.PriorityCodeLookUpEdit, "PriorityCodeLookUpEdit");
            this.PriorityCodeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "PriorityCode", true));
            this.PriorityCodeLookUpEdit.Name = "PriorityCodeLookUpEdit";
            this.PriorityCodeLookUpEdit.Properties.AccessibleDescription = resources.GetString("PriorityCodeLookUpEdit.Properties.AccessibleDescription");
            this.PriorityCodeLookUpEdit.Properties.AccessibleName = resources.GetString("PriorityCodeLookUpEdit.Properties.AccessibleName");
            this.PriorityCodeLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("PriorityCodeLookUpEdit.Properties.AutoHeight")));
            this.PriorityCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("PriorityCodeLookUpEdit.Properties.Buttons"))))});
            this.PriorityCodeLookUpEdit.Properties.NullText = resources.GetString("PriorityCodeLookUpEdit.Properties.NullText");
            this.PriorityCodeLookUpEdit.Properties.NullValuePrompt = resources.GetString("PriorityCodeLookUpEdit.Properties.NullValuePrompt");
            this.PriorityCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("PriorityCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.PriorityCodeLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // OpportunityTypeCodeLookUpEdit
            // 
            resources.ApplyResources(this.OpportunityTypeCodeLookUpEdit, "OpportunityTypeCodeLookUpEdit");
            this.OpportunityTypeCodeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "OpportunityTypeCode", true));
            this.OpportunityTypeCodeLookUpEdit.Name = "OpportunityTypeCodeLookUpEdit";
            this.OpportunityTypeCodeLookUpEdit.Properties.AccessibleDescription = resources.GetString("OpportunityTypeCodeLookUpEdit.Properties.AccessibleDescription");
            this.OpportunityTypeCodeLookUpEdit.Properties.AccessibleName = resources.GetString("OpportunityTypeCodeLookUpEdit.Properties.AccessibleName");
            this.OpportunityTypeCodeLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("OpportunityTypeCodeLookUpEdit.Properties.AutoHeight")));
            this.OpportunityTypeCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("OpportunityTypeCodeLookUpEdit.Properties.Buttons"))))});
            this.OpportunityTypeCodeLookUpEdit.Properties.NullText = resources.GetString("OpportunityTypeCodeLookUpEdit.Properties.NullText");
            this.OpportunityTypeCodeLookUpEdit.Properties.NullValuePrompt = resources.GetString("OpportunityTypeCodeLookUpEdit.Properties.NullValuePrompt");
            this.OpportunityTypeCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("OpportunityTypeCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.OpportunityTypeCodeLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // SalesStageCodeLookUpEdit
            // 
            resources.ApplyResources(this.SalesStageCodeLookUpEdit, "SalesStageCodeLookUpEdit");
            this.SalesStageCodeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "SalesStageCode", true));
            this.SalesStageCodeLookUpEdit.Name = "SalesStageCodeLookUpEdit";
            this.SalesStageCodeLookUpEdit.Properties.AccessibleDescription = resources.GetString("SalesStageCodeLookUpEdit.Properties.AccessibleDescription");
            this.SalesStageCodeLookUpEdit.Properties.AccessibleName = resources.GetString("SalesStageCodeLookUpEdit.Properties.AccessibleName");
            this.SalesStageCodeLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("SalesStageCodeLookUpEdit.Properties.AutoHeight")));
            this.SalesStageCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("SalesStageCodeLookUpEdit.Properties.Buttons"))))});
            this.SalesStageCodeLookUpEdit.Properties.NullText = resources.GetString("SalesStageCodeLookUpEdit.Properties.NullText");
            this.SalesStageCodeLookUpEdit.Properties.NullValuePrompt = resources.GetString("SalesStageCodeLookUpEdit.Properties.NullValuePrompt");
            this.SalesStageCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("SalesStageCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.SalesStageCodeLookUpEdit.StyleController = this.EntityDataLayoutControl;
            this.SalesStageCodeLookUpEdit.EditValueChanged += new System.EventHandler(this.SalesStageCodeLookUpEdit_EditValueChanged);
            // 
            // EstimatedValueSpinEdit
            // 
            resources.ApplyResources(this.EstimatedValueSpinEdit, "EstimatedValueSpinEdit");
            this.EstimatedValueSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "EstimatedValue", true));
            this.EstimatedValueSpinEdit.Name = "EstimatedValueSpinEdit";
            this.EstimatedValueSpinEdit.Properties.AccessibleDescription = resources.GetString("EstimatedValueSpinEdit.Properties.AccessibleDescription");
            this.EstimatedValueSpinEdit.Properties.AccessibleName = resources.GetString("EstimatedValueSpinEdit.Properties.AccessibleName");
            this.EstimatedValueSpinEdit.Properties.AutoHeight = ((bool)(resources.GetObject("EstimatedValueSpinEdit.Properties.AutoHeight")));
            this.EstimatedValueSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.EstimatedValueSpinEdit.Properties.DisplayFormat.FormatString = "{0:n0}";
            this.EstimatedValueSpinEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.EstimatedValueSpinEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.EstimatedValueSpinEdit.Properties.IsFloatValue = false;
            this.EstimatedValueSpinEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("EstimatedValueSpinEdit.Properties.Mask.AutoComplete")));
            this.EstimatedValueSpinEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("EstimatedValueSpinEdit.Properties.Mask.BeepOnError")));
            this.EstimatedValueSpinEdit.Properties.Mask.EditMask = resources.GetString("EstimatedValueSpinEdit.Properties.Mask.EditMask");
            this.EstimatedValueSpinEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("EstimatedValueSpinEdit.Properties.Mask.IgnoreMaskBlank")));
            this.EstimatedValueSpinEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("EstimatedValueSpinEdit.Properties.Mask.MaskType")));
            this.EstimatedValueSpinEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("EstimatedValueSpinEdit.Properties.Mask.PlaceHolder")));
            this.EstimatedValueSpinEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("EstimatedValueSpinEdit.Properties.Mask.SaveLiteral")));
            this.EstimatedValueSpinEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("EstimatedValueSpinEdit.Properties.Mask.ShowPlaceHolders")));
            this.EstimatedValueSpinEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("EstimatedValueSpinEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.EstimatedValueSpinEdit.Properties.MaxLength = 9;
            this.EstimatedValueSpinEdit.Properties.MaxValue = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.EstimatedValueSpinEdit.Properties.NullValuePrompt = resources.GetString("EstimatedValueSpinEdit.Properties.NullValuePrompt");
            this.EstimatedValueSpinEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("EstimatedValueSpinEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.EstimatedValueSpinEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // StepNameTextEdit
            // 
            resources.ApplyResources(this.StepNameTextEdit, "StepNameTextEdit");
            this.StepNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "StepName", true));
            this.StepNameTextEdit.Name = "StepNameTextEdit";
            this.StepNameTextEdit.Properties.AccessibleDescription = resources.GetString("StepNameTextEdit.Properties.AccessibleDescription");
            this.StepNameTextEdit.Properties.AccessibleName = resources.GetString("StepNameTextEdit.Properties.AccessibleName");
            this.StepNameTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("StepNameTextEdit.Properties.AutoHeight")));
            this.StepNameTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("StepNameTextEdit.Properties.Mask.AutoComplete")));
            this.StepNameTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("StepNameTextEdit.Properties.Mask.BeepOnError")));
            this.StepNameTextEdit.Properties.Mask.EditMask = resources.GetString("StepNameTextEdit.Properties.Mask.EditMask");
            this.StepNameTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("StepNameTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.StepNameTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("StepNameTextEdit.Properties.Mask.MaskType")));
            this.StepNameTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("StepNameTextEdit.Properties.Mask.PlaceHolder")));
            this.StepNameTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("StepNameTextEdit.Properties.Mask.SaveLiteral")));
            this.StepNameTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("StepNameTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.StepNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("StepNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.StepNameTextEdit.Properties.NullValuePrompt = resources.GetString("StepNameTextEdit.Properties.NullValuePrompt");
            this.StepNameTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("StepNameTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.StepNameTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // TransacitionCurrencyIdLookUpEdit
            // 
            resources.ApplyResources(this.TransacitionCurrencyIdLookUpEdit, "TransacitionCurrencyIdLookUpEdit");
            this.TransacitionCurrencyIdLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "TransactionCurrencyId", true));
            this.TransacitionCurrencyIdLookUpEdit.Name = "TransacitionCurrencyIdLookUpEdit";
            this.TransacitionCurrencyIdLookUpEdit.Properties.AccessibleDescription = resources.GetString("TransacitionCurrencyIdLookUpEdit.Properties.AccessibleDescription");
            this.TransacitionCurrencyIdLookUpEdit.Properties.AccessibleName = resources.GetString("TransacitionCurrencyIdLookUpEdit.Properties.AccessibleName");
            this.TransacitionCurrencyIdLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("TransacitionCurrencyIdLookUpEdit.Properties.AutoHeight")));
            this.TransacitionCurrencyIdLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("TransacitionCurrencyIdLookUpEdit.Properties.Buttons"))))});
            this.TransacitionCurrencyIdLookUpEdit.Properties.NullValuePrompt = resources.GetString("TransacitionCurrencyIdLookUpEdit.Properties.NullValuePrompt");
            this.TransacitionCurrencyIdLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("TransacitionCurrencyIdLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.TransacitionCurrencyIdLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // CloseProbabilitySpinEdit
            // 
            resources.ApplyResources(this.CloseProbabilitySpinEdit, "CloseProbabilitySpinEdit");
            this.CloseProbabilitySpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "CloseProbability", true));
            this.CloseProbabilitySpinEdit.Name = "CloseProbabilitySpinEdit";
            this.CloseProbabilitySpinEdit.Properties.AccessibleDescription = resources.GetString("CloseProbabilitySpinEdit.Properties.AccessibleDescription");
            this.CloseProbabilitySpinEdit.Properties.AccessibleName = resources.GetString("CloseProbabilitySpinEdit.Properties.AccessibleName");
            this.CloseProbabilitySpinEdit.Properties.AutoHeight = ((bool)(resources.GetObject("CloseProbabilitySpinEdit.Properties.AutoHeight")));
            this.CloseProbabilitySpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.CloseProbabilitySpinEdit.Properties.IsFloatValue = false;
            this.CloseProbabilitySpinEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("CloseProbabilitySpinEdit.Properties.Mask.AutoComplete")));
            this.CloseProbabilitySpinEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("CloseProbabilitySpinEdit.Properties.Mask.BeepOnError")));
            this.CloseProbabilitySpinEdit.Properties.Mask.EditMask = resources.GetString("CloseProbabilitySpinEdit.Properties.Mask.EditMask");
            this.CloseProbabilitySpinEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("CloseProbabilitySpinEdit.Properties.Mask.IgnoreMaskBlank")));
            this.CloseProbabilitySpinEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("CloseProbabilitySpinEdit.Properties.Mask.MaskType")));
            this.CloseProbabilitySpinEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("CloseProbabilitySpinEdit.Properties.Mask.PlaceHolder")));
            this.CloseProbabilitySpinEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("CloseProbabilitySpinEdit.Properties.Mask.SaveLiteral")));
            this.CloseProbabilitySpinEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("CloseProbabilitySpinEdit.Properties.Mask.ShowPlaceHolders")));
            this.CloseProbabilitySpinEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("CloseProbabilitySpinEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.CloseProbabilitySpinEdit.Properties.MaxLength = 3;
            this.CloseProbabilitySpinEdit.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.CloseProbabilitySpinEdit.Properties.NullValuePrompt = resources.GetString("CloseProbabilitySpinEdit.Properties.NullValuePrompt");
            this.CloseProbabilitySpinEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("CloseProbabilitySpinEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.CloseProbabilitySpinEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // DepartmentLookUpEdit
            // 
            resources.ApplyResources(this.DepartmentLookUpEdit, "DepartmentLookUpEdit");
            this.DepartmentLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "DepartmentId", true));
            this.DepartmentLookUpEdit.Name = "DepartmentLookUpEdit";
            this.DepartmentLookUpEdit.Properties.AccessibleDescription = resources.GetString("DepartmentLookUpEdit.Properties.AccessibleDescription");
            this.DepartmentLookUpEdit.Properties.AccessibleName = resources.GetString("DepartmentLookUpEdit.Properties.AccessibleName");
            this.DepartmentLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("DepartmentLookUpEdit.Properties.AutoHeight")));
            this.DepartmentLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("DepartmentLookUpEdit.Properties.Buttons"))))});
            this.DepartmentLookUpEdit.Properties.NullValuePrompt = resources.GetString("DepartmentLookUpEdit.Properties.NullValuePrompt");
            this.DepartmentLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("DepartmentLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.DepartmentLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem1, "emptySpaceItem1");
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(866, 296);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // tabbedControlGroup1
            // 
            resources.ApplyResources(this.tabbedControlGroup1, "tabbedControlGroup1");
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.lcgGeneral;
            this.tabbedControlGroup1.SelectedTabPageIndex = 0;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(890, 415);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgGeneral,
            this.managementLayoutControlGroup});
            // 
            // lcgGeneral
            // 
            resources.ApplyResources(this.lcgGeneral, "lcgGeneral");
            this.lcgGeneral.ExpandButtonVisible = true;
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForName,
            this.ItemForTransacitionCurrencyId,
            this.ItemForCloseProbability,
            this.ItemForOriginatingLeadId,
            this.lcgDetails,
            this.technologyItem,
            this.latestFeedbackOnItem,
            this.estimatedWorkAmountItem,
            this.projectTypeItem,
            this.technicianItem,
            this.expectedStartOnItem,
            this.ItemForCustomerId,
            this.ItemForEstimatedValue,
            this.ItemForEstimatedCloseDate});
            this.lcgGeneral.Location = new System.Drawing.Point(0, 0);
            this.lcgGeneral.Name = "lcgGeneral";
            this.lcgGeneral.Size = new System.Drawing.Size(866, 368);
            // 
            // ItemForName
            // 
            this.ItemForName.Control = this.topicTextEdit;
            resources.ApplyResources(this.ItemForName, "ItemForName");
            this.ItemForName.Location = new System.Drawing.Point(0, 0);
            this.ItemForName.Name = "ItemForName";
            this.ItemForName.Size = new System.Drawing.Size(866, 24);
            this.ItemForName.TextSize = new System.Drawing.Size(135, 14);
            // 
            // ItemForTransacitionCurrencyId
            // 
            this.ItemForTransacitionCurrencyId.Control = this.TransacitionCurrencyIdLookUpEdit;
            resources.ApplyResources(this.ItemForTransacitionCurrencyId, "ItemForTransacitionCurrencyId");
            this.ItemForTransacitionCurrencyId.Location = new System.Drawing.Point(432, 120);
            this.ItemForTransacitionCurrencyId.Name = "ItemForTransacitionCurrencyId";
            this.ItemForTransacitionCurrencyId.Size = new System.Drawing.Size(434, 24);
            this.ItemForTransacitionCurrencyId.TextSize = new System.Drawing.Size(135, 14);
            // 
            // ItemForCloseProbability
            // 
            this.ItemForCloseProbability.Control = this.CloseProbabilitySpinEdit;
            resources.ApplyResources(this.ItemForCloseProbability, "ItemForCloseProbability");
            this.ItemForCloseProbability.Location = new System.Drawing.Point(432, 144);
            this.ItemForCloseProbability.Name = "ItemForCloseProbability";
            this.ItemForCloseProbability.Size = new System.Drawing.Size(434, 24);
            this.ItemForCloseProbability.TextSize = new System.Drawing.Size(135, 14);
            // 
            // ItemForOriginatingLeadId
            // 
            this.ItemForOriginatingLeadId.Control = this.OriginatingLeadIdSearchLookUpEdit;
            resources.ApplyResources(this.ItemForOriginatingLeadId, "ItemForOriginatingLeadId");
            this.ItemForOriginatingLeadId.Location = new System.Drawing.Point(432, 96);
            this.ItemForOriginatingLeadId.Name = "ItemForOriginatingLeadId";
            this.ItemForOriginatingLeadId.Size = new System.Drawing.Size(434, 24);
            this.ItemForOriginatingLeadId.TextSize = new System.Drawing.Size(135, 14);
            // 
            // OriginatingLeadIdSearchLookUpEdit
            // 
            resources.ApplyResources(this.OriginatingLeadIdSearchLookUpEdit, "OriginatingLeadIdSearchLookUpEdit");
            this.OriginatingLeadIdSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "OriginatingLeadId", true));
            this.OriginatingLeadIdSearchLookUpEdit.Name = "OriginatingLeadIdSearchLookUpEdit";
            this.OriginatingLeadIdSearchLookUpEdit.Properties.AccessibleDescription = resources.GetString("OriginatingLeadIdSearchLookUpEdit.Properties.AccessibleDescription");
            this.OriginatingLeadIdSearchLookUpEdit.Properties.AccessibleName = resources.GetString("OriginatingLeadIdSearchLookUpEdit.Properties.AccessibleName");
            this.OriginatingLeadIdSearchLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("OriginatingLeadIdSearchLookUpEdit.Properties.AutoHeight")));
            this.OriginatingLeadIdSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("OriginatingLeadIdSearchLookUpEdit.Properties.Buttons"))))});
            this.OriginatingLeadIdSearchLookUpEdit.Properties.NullValuePrompt = resources.GetString("OriginatingLeadIdSearchLookUpEdit.Properties.NullValuePrompt");
            this.OriginatingLeadIdSearchLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("OriginatingLeadIdSearchLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.OriginatingLeadIdSearchLookUpEdit.Properties.View = this.gridView1;
            this.OriginatingLeadIdSearchLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // gridView1
            // 
            resources.ApplyResources(this.gridView1, "gridView1");
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsLayout.LayoutVersion = "0.0.0.1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // lcgDetails
            // 
            resources.ApplyResources(this.lcgDetails, "lcgDetails");
            this.lcgDetails.ExpandButtonVisible = true;
            this.lcgDetails.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForStatusCode,
            this.ItemForOpportunityTypeCode,
            this.ItemForOpportunityRatingCode,
            this.ItemForDescription,
            this.ItemForPriorityCode,
            this.ItemForStepName,
            this.ItemForSalesStageCode});
            this.lcgDetails.Location = new System.Drawing.Point(0, 168);
            this.lcgDetails.Name = "lcgDetails";
            this.lcgDetails.Size = new System.Drawing.Size(866, 200);
            // 
            // ItemForStatusCode
            // 
            this.ItemForStatusCode.Control = this.StatusCodeLookUpEdit;
            resources.ApplyResources(this.ItemForStatusCode, "ItemForStatusCode");
            this.ItemForStatusCode.Location = new System.Drawing.Point(420, 48);
            this.ItemForStatusCode.Name = "ItemForStatusCode";
            this.ItemForStatusCode.Size = new System.Drawing.Size(422, 24);
            this.ItemForStatusCode.TextSize = new System.Drawing.Size(135, 14);
            // 
            // ItemForOpportunityTypeCode
            // 
            this.ItemForOpportunityTypeCode.Control = this.OpportunityTypeCodeLookUpEdit;
            resources.ApplyResources(this.ItemForOpportunityTypeCode, "ItemForOpportunityTypeCode");
            this.ItemForOpportunityTypeCode.Location = new System.Drawing.Point(420, 0);
            this.ItemForOpportunityTypeCode.Name = "ItemForOpportunityTypeCode";
            this.ItemForOpportunityTypeCode.Size = new System.Drawing.Size(422, 24);
            this.ItemForOpportunityTypeCode.TextSize = new System.Drawing.Size(135, 14);
            // 
            // ItemForOpportunityRatingCode
            // 
            this.ItemForOpportunityRatingCode.Control = this.OpportunityRatingCodeLookUpEdit;
            resources.ApplyResources(this.ItemForOpportunityRatingCode, "ItemForOpportunityRatingCode");
            this.ItemForOpportunityRatingCode.Location = new System.Drawing.Point(420, 24);
            this.ItemForOpportunityRatingCode.Name = "ItemForOpportunityRatingCode";
            this.ItemForOpportunityRatingCode.Size = new System.Drawing.Size(422, 24);
            this.ItemForOpportunityRatingCode.TextSize = new System.Drawing.Size(135, 14);
            // 
            // ItemForDescription
            // 
            this.ItemForDescription.Control = this.DescriptionTextEdit;
            resources.ApplyResources(this.ItemForDescription, "ItemForDescription");
            this.ItemForDescription.Location = new System.Drawing.Point(0, 72);
            this.ItemForDescription.Name = "ItemForDescription";
            this.ItemForDescription.Size = new System.Drawing.Size(842, 84);
            this.ItemForDescription.TextSize = new System.Drawing.Size(135, 14);
            // 
            // ItemForPriorityCode
            // 
            this.ItemForPriorityCode.Control = this.PriorityCodeLookUpEdit;
            resources.ApplyResources(this.ItemForPriorityCode, "ItemForPriorityCode");
            this.ItemForPriorityCode.Location = new System.Drawing.Point(0, 0);
            this.ItemForPriorityCode.Name = "ItemForPriorityCode";
            this.ItemForPriorityCode.Size = new System.Drawing.Size(420, 24);
            this.ItemForPriorityCode.TextSize = new System.Drawing.Size(135, 14);
            // 
            // ItemForStepName
            // 
            this.ItemForStepName.Control = this.StepNameTextEdit;
            resources.ApplyResources(this.ItemForStepName, "ItemForStepName");
            this.ItemForStepName.Location = new System.Drawing.Point(0, 24);
            this.ItemForStepName.Name = "ItemForStepName";
            this.ItemForStepName.Size = new System.Drawing.Size(420, 24);
            this.ItemForStepName.TextSize = new System.Drawing.Size(135, 14);
            // 
            // ItemForSalesStageCode
            // 
            this.ItemForSalesStageCode.Control = this.SalesStageCodeLookUpEdit;
            resources.ApplyResources(this.ItemForSalesStageCode, "ItemForSalesStageCode");
            this.ItemForSalesStageCode.Location = new System.Drawing.Point(0, 48);
            this.ItemForSalesStageCode.Name = "ItemForSalesStageCode";
            this.ItemForSalesStageCode.Size = new System.Drawing.Size(420, 24);
            this.ItemForSalesStageCode.TextSize = new System.Drawing.Size(135, 14);
            // 
            // technologyItem
            // 
            this.technologyItem.Control = this.technologyCodeLookUpEdit;
            resources.ApplyResources(this.technologyItem, "technologyItem");
            this.technologyItem.Location = new System.Drawing.Point(432, 24);
            this.technologyItem.Name = "technologyItem";
            this.technologyItem.Size = new System.Drawing.Size(434, 24);
            this.technologyItem.TextSize = new System.Drawing.Size(135, 14);
            // 
            // technologyCodeLookUpEdit
            // 
            resources.ApplyResources(this.technologyCodeLookUpEdit, "technologyCodeLookUpEdit");
            this.technologyCodeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Technology", true));
            this.technologyCodeLookUpEdit.Name = "technologyCodeLookUpEdit";
            this.technologyCodeLookUpEdit.Properties.AccessibleDescription = resources.GetString("technologyCodeLookUpEdit.Properties.AccessibleDescription");
            this.technologyCodeLookUpEdit.Properties.AccessibleName = resources.GetString("technologyCodeLookUpEdit.Properties.AccessibleName");
            this.technologyCodeLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("technologyCodeLookUpEdit.Properties.AutoHeight")));
            this.technologyCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("technologyCodeLookUpEdit.Properties.Buttons"))))});
            this.technologyCodeLookUpEdit.Properties.NullValuePrompt = resources.GetString("technologyCodeLookUpEdit.Properties.NullValuePrompt");
            this.technologyCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("technologyCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.technologyCodeLookUpEdit.Properties.MaxLength = 100;
            this.technologyCodeLookUpEdit.Properties.PopupSizeable = true;
            this.technologyCodeLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // latestFeedbackOnItem
            // 
            this.latestFeedbackOnItem.Control = this.latestFeedBackOnDateEdit;
            resources.ApplyResources(this.latestFeedbackOnItem, "latestFeedbackOnItem");
            this.latestFeedbackOnItem.Location = new System.Drawing.Point(432, 48);
            this.latestFeedbackOnItem.Name = "latestFeedbackOnItem";
            this.latestFeedbackOnItem.Size = new System.Drawing.Size(434, 24);
            this.latestFeedbackOnItem.TextSize = new System.Drawing.Size(135, 14);
            // 
            // latestFeedBackOnDateEdit
            // 
            resources.ApplyResources(this.latestFeedBackOnDateEdit, "latestFeedBackOnDateEdit");
            this.latestFeedBackOnDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "LatestFeedbackOn", true));
            this.latestFeedBackOnDateEdit.Name = "latestFeedBackOnDateEdit";
            this.latestFeedBackOnDateEdit.Properties.AccessibleDescription = resources.GetString("latestFeedBackOnDateEdit.Properties.AccessibleDescription");
            this.latestFeedBackOnDateEdit.Properties.AccessibleName = resources.GetString("latestFeedBackOnDateEdit.Properties.AccessibleName");
            this.latestFeedBackOnDateEdit.Properties.AutoHeight = ((bool)(resources.GetObject("latestFeedBackOnDateEdit.Properties.AutoHeight")));
            this.latestFeedBackOnDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("latestFeedBackOnDateEdit.Properties.Buttons"))))});
            this.latestFeedBackOnDateEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("latestFeedBackOnDateEdit.Properties.Mask.AutoComplete")));
            this.latestFeedBackOnDateEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("latestFeedBackOnDateEdit.Properties.Mask.BeepOnError")));
            this.latestFeedBackOnDateEdit.Properties.Mask.EditMask = resources.GetString("latestFeedBackOnDateEdit.Properties.Mask.EditMask");
            this.latestFeedBackOnDateEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("latestFeedBackOnDateEdit.Properties.Mask.IgnoreMaskBlank")));
            this.latestFeedBackOnDateEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("latestFeedBackOnDateEdit.Properties.Mask.MaskType")));
            this.latestFeedBackOnDateEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("latestFeedBackOnDateEdit.Properties.Mask.PlaceHolder")));
            this.latestFeedBackOnDateEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("latestFeedBackOnDateEdit.Properties.Mask.SaveLiteral")));
            this.latestFeedBackOnDateEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("latestFeedBackOnDateEdit.Properties.Mask.ShowPlaceHolders")));
            this.latestFeedBackOnDateEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("latestFeedBackOnDateEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.latestFeedBackOnDateEdit.Properties.NullValuePrompt = resources.GetString("latestFeedBackOnDateEdit.Properties.NullValuePrompt");
            this.latestFeedBackOnDateEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("latestFeedBackOnDateEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.latestFeedBackOnDateEdit.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("latestFeedBackOnDateEdit.Properties.VistaTimeProperties.AccessibleDescription");
            this.latestFeedBackOnDateEdit.Properties.VistaTimeProperties.AccessibleName = resources.GetString("latestFeedBackOnDateEdit.Properties.VistaTimeProperties.AccessibleName");
            this.latestFeedBackOnDateEdit.Properties.VistaTimeProperties.AutoHeight = ((bool)(resources.GetObject("latestFeedBackOnDateEdit.Properties.VistaTimeProperties.AutoHeight")));
            this.latestFeedBackOnDateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.latestFeedBackOnDateEdit.Properties.VistaTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("latestFeedBackOnDateEdit.Properties.VistaTimeProperties.Mask.AutoComplete")));
            this.latestFeedBackOnDateEdit.Properties.VistaTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("latestFeedBackOnDateEdit.Properties.VistaTimeProperties.Mask.BeepOnError")));
            this.latestFeedBackOnDateEdit.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("latestFeedBackOnDateEdit.Properties.VistaTimeProperties.Mask.EditMask");
            this.latestFeedBackOnDateEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("latestFeedBackOnDateEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank")));
            this.latestFeedBackOnDateEdit.Properties.VistaTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("latestFeedBackOnDateEdit.Properties.VistaTimeProperties.Mask.MaskType")));
            this.latestFeedBackOnDateEdit.Properties.VistaTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("latestFeedBackOnDateEdit.Properties.VistaTimeProperties.Mask.PlaceHolder")));
            this.latestFeedBackOnDateEdit.Properties.VistaTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("latestFeedBackOnDateEdit.Properties.VistaTimeProperties.Mask.SaveLiteral")));
            this.latestFeedBackOnDateEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("latestFeedBackOnDateEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders")));
            this.latestFeedBackOnDateEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("latestFeedBackOnDateEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayForm" +
        "at")));
            this.latestFeedBackOnDateEdit.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("latestFeedBackOnDateEdit.Properties.VistaTimeProperties.NullValuePrompt");
            this.latestFeedBackOnDateEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("latestFeedBackOnDateEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmp" +
        "tyValue")));
            this.latestFeedBackOnDateEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // estimatedWorkAmountItem
            // 
            this.estimatedWorkAmountItem.Control = this.estimatedWorkAmountSpinEdit;
            resources.ApplyResources(this.estimatedWorkAmountItem, "estimatedWorkAmountItem");
            this.estimatedWorkAmountItem.Location = new System.Drawing.Point(432, 72);
            this.estimatedWorkAmountItem.Name = "estimatedWorkAmountItem";
            this.estimatedWorkAmountItem.Size = new System.Drawing.Size(434, 24);
            this.estimatedWorkAmountItem.TextSize = new System.Drawing.Size(135, 14);
            // 
            // estimatedWorkAmountSpinEdit
            // 
            resources.ApplyResources(this.estimatedWorkAmountSpinEdit, "estimatedWorkAmountSpinEdit");
            this.estimatedWorkAmountSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "EstimatedWorkAmount", true));
            this.estimatedWorkAmountSpinEdit.Name = "estimatedWorkAmountSpinEdit";
            this.estimatedWorkAmountSpinEdit.Properties.AccessibleDescription = resources.GetString("estimatedWorkAmountSpinEdit.Properties.AccessibleDescription");
            this.estimatedWorkAmountSpinEdit.Properties.AccessibleName = resources.GetString("estimatedWorkAmountSpinEdit.Properties.AccessibleName");
            this.estimatedWorkAmountSpinEdit.Properties.AutoHeight = ((bool)(resources.GetObject("estimatedWorkAmountSpinEdit.Properties.AutoHeight")));
            this.estimatedWorkAmountSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.estimatedWorkAmountSpinEdit.Properties.DisplayFormat.FormatString = "{0:0}";
            this.estimatedWorkAmountSpinEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.estimatedWorkAmountSpinEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("estimatedWorkAmountSpinEdit.Properties.Mask.AutoComplete")));
            this.estimatedWorkAmountSpinEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("estimatedWorkAmountSpinEdit.Properties.Mask.BeepOnError")));
            this.estimatedWorkAmountSpinEdit.Properties.Mask.EditMask = resources.GetString("estimatedWorkAmountSpinEdit.Properties.Mask.EditMask");
            this.estimatedWorkAmountSpinEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("estimatedWorkAmountSpinEdit.Properties.Mask.IgnoreMaskBlank")));
            this.estimatedWorkAmountSpinEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("estimatedWorkAmountSpinEdit.Properties.Mask.MaskType")));
            this.estimatedWorkAmountSpinEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("estimatedWorkAmountSpinEdit.Properties.Mask.PlaceHolder")));
            this.estimatedWorkAmountSpinEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("estimatedWorkAmountSpinEdit.Properties.Mask.SaveLiteral")));
            this.estimatedWorkAmountSpinEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("estimatedWorkAmountSpinEdit.Properties.Mask.ShowPlaceHolders")));
            this.estimatedWorkAmountSpinEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("estimatedWorkAmountSpinEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.estimatedWorkAmountSpinEdit.Properties.MaxLength = 8;
            this.estimatedWorkAmountSpinEdit.Properties.NullValuePrompt = resources.GetString("estimatedWorkAmountSpinEdit.Properties.NullValuePrompt");
            this.estimatedWorkAmountSpinEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("estimatedWorkAmountSpinEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.estimatedWorkAmountSpinEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // projectTypeItem
            // 
            this.projectTypeItem.Control = this.projectTypeCodeLookUpEdit;
            resources.ApplyResources(this.projectTypeItem, "projectTypeItem");
            this.projectTypeItem.Location = new System.Drawing.Point(0, 24);
            this.projectTypeItem.Name = "projectTypeItem";
            this.projectTypeItem.Size = new System.Drawing.Size(432, 24);
            this.projectTypeItem.TextSize = new System.Drawing.Size(135, 14);
            // 
            // projectTypeCodeLookUpEdit
            // 
            resources.ApplyResources(this.projectTypeCodeLookUpEdit, "projectTypeCodeLookUpEdit");
            this.projectTypeCodeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ProjectTypeCode", true));
            this.projectTypeCodeLookUpEdit.Name = "projectTypeCodeLookUpEdit";
            this.projectTypeCodeLookUpEdit.Properties.AccessibleDescription = resources.GetString("projectTypeCodeLookUpEdit.Properties.AccessibleDescription");
            this.projectTypeCodeLookUpEdit.Properties.AccessibleName = resources.GetString("projectTypeCodeLookUpEdit.Properties.AccessibleName");
            this.projectTypeCodeLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("projectTypeCodeLookUpEdit.Properties.AutoHeight")));
            this.projectTypeCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("projectTypeCodeLookUpEdit.Properties.Buttons"))))});
            this.projectTypeCodeLookUpEdit.Properties.NullText = resources.GetString("projectTypeCodeLookUpEdit.Properties.NullText");
            this.projectTypeCodeLookUpEdit.Properties.NullValuePrompt = resources.GetString("projectTypeCodeLookUpEdit.Properties.NullValuePrompt");
            this.projectTypeCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("projectTypeCodeLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.projectTypeCodeLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // technicianItem
            // 
            this.technicianItem.Control = this.technicianIdSearchLookUpEdit;
            resources.ApplyResources(this.technicianItem, "technicianItem");
            this.technicianItem.Location = new System.Drawing.Point(0, 48);
            this.technicianItem.Name = "technicianItem";
            this.technicianItem.Size = new System.Drawing.Size(432, 24);
            this.technicianItem.TextSize = new System.Drawing.Size(135, 14);
            // 
            // technicianIdSearchLookUpEdit
            // 
            resources.ApplyResources(this.technicianIdSearchLookUpEdit, "technicianIdSearchLookUpEdit");
            this.technicianIdSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "TechnicianId", true));
            this.technicianIdSearchLookUpEdit.Name = "technicianIdSearchLookUpEdit";
            this.technicianIdSearchLookUpEdit.Properties.AccessibleDescription = resources.GetString("technicianIdSearchLookUpEdit.Properties.AccessibleDescription");
            this.technicianIdSearchLookUpEdit.Properties.AccessibleName = resources.GetString("technicianIdSearchLookUpEdit.Properties.AccessibleName");
            this.technicianIdSearchLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("technicianIdSearchLookUpEdit.Properties.AutoHeight")));
            this.technicianIdSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("technicianIdSearchLookUpEdit.Properties.Buttons"))))});
            this.technicianIdSearchLookUpEdit.Properties.NullValuePrompt = resources.GetString("technicianIdSearchLookUpEdit.Properties.NullValuePrompt");
            this.technicianIdSearchLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("technicianIdSearchLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.technicianIdSearchLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // expectedStartOnItem
            // 
            this.expectedStartOnItem.Control = this.expectedStartOnDateEdit;
            resources.ApplyResources(this.expectedStartOnItem, "expectedStartOnItem");
            this.expectedStartOnItem.Location = new System.Drawing.Point(0, 72);
            this.expectedStartOnItem.Name = "expectedStartOnItem";
            this.expectedStartOnItem.Size = new System.Drawing.Size(432, 24);
            this.expectedStartOnItem.TextSize = new System.Drawing.Size(135, 14);
            // 
            // expectedStartOnDateEdit
            // 
            resources.ApplyResources(this.expectedStartOnDateEdit, "expectedStartOnDateEdit");
            this.expectedStartOnDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ExpectedStartOn", true));
            this.expectedStartOnDateEdit.Name = "expectedStartOnDateEdit";
            this.expectedStartOnDateEdit.Properties.AccessibleDescription = resources.GetString("expectedStartOnDateEdit.Properties.AccessibleDescription");
            this.expectedStartOnDateEdit.Properties.AccessibleName = resources.GetString("expectedStartOnDateEdit.Properties.AccessibleName");
            this.expectedStartOnDateEdit.Properties.AutoHeight = ((bool)(resources.GetObject("expectedStartOnDateEdit.Properties.AutoHeight")));
            this.expectedStartOnDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("expectedStartOnDateEdit.Properties.Buttons"))))});
            this.expectedStartOnDateEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("expectedStartOnDateEdit.Properties.Mask.AutoComplete")));
            this.expectedStartOnDateEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("expectedStartOnDateEdit.Properties.Mask.BeepOnError")));
            this.expectedStartOnDateEdit.Properties.Mask.EditMask = resources.GetString("expectedStartOnDateEdit.Properties.Mask.EditMask");
            this.expectedStartOnDateEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("expectedStartOnDateEdit.Properties.Mask.IgnoreMaskBlank")));
            this.expectedStartOnDateEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("expectedStartOnDateEdit.Properties.Mask.MaskType")));
            this.expectedStartOnDateEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("expectedStartOnDateEdit.Properties.Mask.PlaceHolder")));
            this.expectedStartOnDateEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("expectedStartOnDateEdit.Properties.Mask.SaveLiteral")));
            this.expectedStartOnDateEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("expectedStartOnDateEdit.Properties.Mask.ShowPlaceHolders")));
            this.expectedStartOnDateEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("expectedStartOnDateEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.expectedStartOnDateEdit.Properties.NullValuePrompt = resources.GetString("expectedStartOnDateEdit.Properties.NullValuePrompt");
            this.expectedStartOnDateEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("expectedStartOnDateEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.expectedStartOnDateEdit.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("expectedStartOnDateEdit.Properties.VistaTimeProperties.AccessibleDescription");
            this.expectedStartOnDateEdit.Properties.VistaTimeProperties.AccessibleName = resources.GetString("expectedStartOnDateEdit.Properties.VistaTimeProperties.AccessibleName");
            this.expectedStartOnDateEdit.Properties.VistaTimeProperties.AutoHeight = ((bool)(resources.GetObject("expectedStartOnDateEdit.Properties.VistaTimeProperties.AutoHeight")));
            this.expectedStartOnDateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.expectedStartOnDateEdit.Properties.VistaTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("expectedStartOnDateEdit.Properties.VistaTimeProperties.Mask.AutoComplete")));
            this.expectedStartOnDateEdit.Properties.VistaTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("expectedStartOnDateEdit.Properties.VistaTimeProperties.Mask.BeepOnError")));
            this.expectedStartOnDateEdit.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("expectedStartOnDateEdit.Properties.VistaTimeProperties.Mask.EditMask");
            this.expectedStartOnDateEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("expectedStartOnDateEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank")));
            this.expectedStartOnDateEdit.Properties.VistaTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("expectedStartOnDateEdit.Properties.VistaTimeProperties.Mask.MaskType")));
            this.expectedStartOnDateEdit.Properties.VistaTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("expectedStartOnDateEdit.Properties.VistaTimeProperties.Mask.PlaceHolder")));
            this.expectedStartOnDateEdit.Properties.VistaTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("expectedStartOnDateEdit.Properties.VistaTimeProperties.Mask.SaveLiteral")));
            this.expectedStartOnDateEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("expectedStartOnDateEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders")));
            this.expectedStartOnDateEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("expectedStartOnDateEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayForma" +
        "t")));
            this.expectedStartOnDateEdit.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("expectedStartOnDateEdit.Properties.VistaTimeProperties.NullValuePrompt");
            this.expectedStartOnDateEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("expectedStartOnDateEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmpt" +
        "yValue")));
            this.expectedStartOnDateEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForCustomerId
            // 
            this.ItemForCustomerId.Control = this.CustomerIdSearchLookUpEdit;
            resources.ApplyResources(this.ItemForCustomerId, "ItemForCustomerId");
            this.ItemForCustomerId.Location = new System.Drawing.Point(0, 96);
            this.ItemForCustomerId.Name = "ItemForCustomerId";
            this.ItemForCustomerId.Size = new System.Drawing.Size(432, 24);
            this.ItemForCustomerId.TextSize = new System.Drawing.Size(135, 14);
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
            // ItemForEstimatedValue
            // 
            this.ItemForEstimatedValue.Control = this.EstimatedValueSpinEdit;
            resources.ApplyResources(this.ItemForEstimatedValue, "ItemForEstimatedValue");
            this.ItemForEstimatedValue.Location = new System.Drawing.Point(0, 120);
            this.ItemForEstimatedValue.Name = "ItemForEstimatedValue";
            this.ItemForEstimatedValue.Size = new System.Drawing.Size(432, 24);
            this.ItemForEstimatedValue.TextSize = new System.Drawing.Size(135, 14);
            // 
            // ItemForEstimatedCloseDate
            // 
            this.ItemForEstimatedCloseDate.Control = this.EstimatedCloseDateTextEdit;
            resources.ApplyResources(this.ItemForEstimatedCloseDate, "ItemForEstimatedCloseDate");
            this.ItemForEstimatedCloseDate.Location = new System.Drawing.Point(0, 144);
            this.ItemForEstimatedCloseDate.Name = "ItemForEstimatedCloseDate";
            this.ItemForEstimatedCloseDate.Size = new System.Drawing.Size(432, 24);
            this.ItemForEstimatedCloseDate.TextSize = new System.Drawing.Size(135, 14);
            // 
            // managementLayoutControlGroup
            // 
            resources.ApplyResources(this.managementLayoutControlGroup, "managementLayoutControlGroup");
            this.managementLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.ItemForDepartment,
            this.ItemForOwnerId,
            this.ItemForCreatedOn,
            this.ItemForCreatedBy,
            this.ItemForModifiedOn,
            this.ItemForModifiedBy});
            this.managementLayoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.managementLayoutControlGroup.Name = "managementLayoutControlGroup";
            this.managementLayoutControlGroup.Size = new System.Drawing.Size(866, 368);
            // 
            // ItemForDepartment
            // 
            this.ItemForDepartment.Control = this.DepartmentLookUpEdit;
            resources.ApplyResources(this.ItemForDepartment, "ItemForDepartment");
            this.ItemForDepartment.Location = new System.Drawing.Point(0, 0);
            this.ItemForDepartment.Name = "ItemForDepartment";
            this.ItemForDepartment.Size = new System.Drawing.Size(432, 24);
            this.ItemForDepartment.TextSize = new System.Drawing.Size(135, 14);
            // 
            // ItemForOwnerId
            // 
            this.ItemForOwnerId.Control = this.OwnerIdSearchLookUpEdit;
            resources.ApplyResources(this.ItemForOwnerId, "ItemForOwnerId");
            this.ItemForOwnerId.Location = new System.Drawing.Point(432, 0);
            this.ItemForOwnerId.Name = "ItemForOwnerId";
            this.ItemForOwnerId.Size = new System.Drawing.Size(434, 24);
            this.ItemForOwnerId.TextSize = new System.Drawing.Size(135, 14);
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
            this.OwnerIdSearchLookUpEdit.Properties.NullText = resources.GetString("OwnerIdSearchLookUpEdit.Properties.NullText");
            this.OwnerIdSearchLookUpEdit.Properties.NullValuePrompt = resources.GetString("OwnerIdSearchLookUpEdit.Properties.NullValuePrompt");
            this.OwnerIdSearchLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("OwnerIdSearchLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.OwnerIdSearchLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForCreatedOn
            // 
            this.ItemForCreatedOn.Control = this.textEdit1;
            resources.ApplyResources(this.ItemForCreatedOn, "ItemForCreatedOn");
            this.ItemForCreatedOn.Location = new System.Drawing.Point(0, 24);
            this.ItemForCreatedOn.Name = "ItemForCreatedOn";
            this.ItemForCreatedOn.Size = new System.Drawing.Size(432, 24);
            this.ItemForCreatedOn.TextSize = new System.Drawing.Size(135, 14);
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
            // ItemForCreatedBy
            // 
            this.ItemForCreatedBy.Control = this.textEdit2;
            resources.ApplyResources(this.ItemForCreatedBy, "ItemForCreatedBy");
            this.ItemForCreatedBy.Location = new System.Drawing.Point(432, 24);
            this.ItemForCreatedBy.Name = "ItemForCreatedBy";
            this.ItemForCreatedBy.Size = new System.Drawing.Size(434, 24);
            this.ItemForCreatedBy.TextSize = new System.Drawing.Size(135, 14);
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
            this.ItemForModifiedOn.Size = new System.Drawing.Size(432, 24);
            this.ItemForModifiedOn.TextSize = new System.Drawing.Size(135, 14);
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
            this.ItemForModifiedBy.Location = new System.Drawing.Point(432, 48);
            this.ItemForModifiedBy.Name = "ItemForModifiedBy";
            this.ItemForModifiedBy.Size = new System.Drawing.Size(434, 24);
            this.ItemForModifiedBy.TextSize = new System.Drawing.Size(135, 14);
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
            // gridView3
            // 
            resources.ApplyResources(this.gridView3, "gridView3");
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsLayout.LayoutVersion = "0.0.0.1";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
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
            // OpportunityDetailView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "OpportunityDetailView";
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).EndInit();
            this.EntityDataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topicTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimatedCloseDateTextEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimatedCloseDateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusCodeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpportunityRatingCodeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorityCodeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpportunityTypeCodeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesStageCodeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimatedValueSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransacitionCurrencyIdLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseProbabilitySpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTransacitionCurrencyId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCloseProbability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOriginatingLeadId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginatingLeadIdSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOpportunityTypeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOpportunityRatingCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPriorityCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStepName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSalesStageCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.technologyItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.technologyCodeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.latestFeedbackOnItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.latestFeedBackOnDateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.latestFeedBackOnDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estimatedWorkAmountItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estimatedWorkAmountSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectTypeItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectTypeCodeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.technicianItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.technicianIdSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expectedStartOnItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expectedStartOnDateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expectedStartOnDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCustomerId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerIdSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEstimatedValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEstimatedCloseDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.managementLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOwnerId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OwnerIdSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProviderRecommend)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private DevExpress.XtraEditors.TextEdit topicTextEdit;
        private DevExpress.XtraEditors.MemoEdit DescriptionTextEdit;
        private DropDownDateEdit EstimatedCloseDateTextEdit;
        private DevExpress.XtraEditors.LookUpEdit StatusCodeLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit OpportunityRatingCodeLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit PriorityCodeLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit OpportunityTypeCodeLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit SalesStageCodeLookUpEdit;
        private DevExpress.XtraEditors.SpinEdit EstimatedValueSpinEdit;
        private DevExpress.XtraEditors.TextEdit StepNameTextEdit;
        private DevExpress.XtraEditors.LookUpEdit TransacitionCurrencyIdLookUpEdit;
        private DevExpress.XtraEditors.SpinEdit CloseProbabilitySpinEdit;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LookUpEdit DepartmentLookUpEdit;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgGeneral;
        private DevExpress.XtraLayout.LayoutControlItem ItemForName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEstimatedCloseDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCustomerId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEstimatedValue;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTransacitionCurrencyId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCloseProbability;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOriginatingLeadId;
        private DevExpress.XtraLayout.LayoutControlGroup lcgDetails;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOwnerId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOpportunityTypeCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPriorityCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSalesStageCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOpportunityRatingCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStatusCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStepName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDepartment;
        private DevExpress.XtraLayout.LayoutControlGroup managementLayoutControlGroup;
        private DevExpress.XtraEditors.SearchLookUpEdit CustomerIdSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.SearchLookUpEdit OriginatingLeadIdSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SearchLookUpEdit technicianIdSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.ComboBoxEdit technologyCodeLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit projectTypeCodeLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem projectTypeItem;
        private DevExpress.XtraLayout.LayoutControlItem technologyItem;
        private DevExpress.XtraLayout.LayoutControlItem technicianItem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SpinEdit estimatedWorkAmountSpinEdit;
        private DropDownDateEdit expectedStartOnDateEdit;
        private DropDownDateEdit latestFeedBackOnDateEdit;
        private DevExpress.XtraLayout.LayoutControlItem latestFeedbackOnItem;
        private DevExpress.XtraLayout.LayoutControlItem expectedStartOnItem;
        private DevExpress.XtraLayout.LayoutControlItem estimatedWorkAmountItem;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider ValidationProviderRecommend;
        private DevExpress.XtraEditors.TextEdit textEdit4;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreatedOn;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreatedBy;
        private DevExpress.XtraLayout.LayoutControlItem ItemForModifiedOn;
        private DevExpress.XtraLayout.LayoutControlItem ItemForModifiedBy;
        private DevExpress.XtraEditors.PopupContainerEdit OwnerIdSearchLookUpEdit;
    }
}
