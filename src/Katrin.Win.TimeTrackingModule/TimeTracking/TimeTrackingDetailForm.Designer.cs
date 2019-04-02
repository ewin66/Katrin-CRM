
using System;
namespace Katrin.Win.TimeTrackingModule.TimeTracking
{
    partial class TimeTrackingDetailForm
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
            timeTrackingBindingSource.DataSource = null;
            GC.Collect();
            GC.SuppressFinalize(this);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeTrackingDetailForm));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.timeTrackingDataLayoutControl = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.recordOnDateEdit = new Katrin.Win.TimeTrackingModule.TimeTracking.DropDownDateEdit();
            this.timeTrackingBindingSource = new System.Windows.Forms.BindingSource();
            this.descriptionEdit = new DevExpress.XtraEditors.MemoEdit();
            this.TypeCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.EffortSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.controlLayoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.infoLayoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForNoteText = new DevExpress.XtraLayout.LayoutControlItem();
            this.recordOnItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTypeCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForEffort = new DevExpress.XtraLayout.LayoutControlItem();
            this.cancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.saveButton = new DevExpress.XtraEditors.SimpleButton();
            this.dxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.controlPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.timeTrackingDataLayoutControl)).BeginInit();
            this.timeTrackingDataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recordOnDateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordOnDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTrackingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeCodeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffortSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNoteText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordOnItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTypeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEffort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).BeginInit();
            this.controlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeTrackingDataLayoutControl
            // 
            this.timeTrackingDataLayoutControl.Controls.Add(this.recordOnDateEdit);
            this.timeTrackingDataLayoutControl.Controls.Add(this.descriptionEdit);
            this.timeTrackingDataLayoutControl.Controls.Add(this.TypeCodeLookUpEdit);
            this.timeTrackingDataLayoutControl.Controls.Add(this.EffortSpinEdit);
            this.timeTrackingDataLayoutControl.DataSource = this.timeTrackingBindingSource;
            resources.ApplyResources(this.timeTrackingDataLayoutControl, "timeTrackingDataLayoutControl");
            this.timeTrackingDataLayoutControl.Name = "timeTrackingDataLayoutControl";
            this.timeTrackingDataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(637, 183, 250, 350);
            this.timeTrackingDataLayoutControl.Root = this.controlLayoutControlGroup;
            // 
            // recordOnDateEdit
            // 
            this.recordOnDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.timeTrackingBindingSource, "RecordOn", true));
            resources.ApplyResources(this.recordOnDateEdit, "recordOnDateEdit");
            this.recordOnDateEdit.Name = "recordOnDateEdit";
            this.recordOnDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("recordOnDateEdit.Properties.Buttons"))))});
            this.recordOnDateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.recordOnDateEdit.StyleController = this.timeTrackingDataLayoutControl;
            // 
            // descriptionEdit
            // 
            this.descriptionEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.timeTrackingBindingSource, "Description", true));
            resources.ApplyResources(this.descriptionEdit, "descriptionEdit");
            this.descriptionEdit.Name = "descriptionEdit";
            this.descriptionEdit.StyleController = this.timeTrackingDataLayoutControl;
            // 
            // TypeCodeLookUpEdit
            // 
            this.TypeCodeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.timeTrackingBindingSource, "TypeCode", true));
            resources.ApplyResources(this.TypeCodeLookUpEdit, "TypeCodeLookUpEdit");
            this.TypeCodeLookUpEdit.Name = "TypeCodeLookUpEdit";
            this.TypeCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("TypeCodeLookUpEdit.Properties.Buttons"))))});
            this.TypeCodeLookUpEdit.StyleController = this.timeTrackingDataLayoutControl;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "This value is not valid";
            this.dxValidationProvider.SetValidationRule(this.TypeCodeLookUpEdit, conditionValidationRule3);
            // 
            // EffortSpinEdit
            // 
            this.EffortSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.timeTrackingBindingSource, "Effort", true));
            resources.ApplyResources(this.EffortSpinEdit, "EffortSpinEdit");
            this.EffortSpinEdit.Name = "EffortSpinEdit";
            this.EffortSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.EffortSpinEdit.Properties.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.EffortSpinEdit.Properties.MaxValue = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.EffortSpinEdit.StyleController = this.timeTrackingDataLayoutControl;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider.SetValidationRule(this.EffortSpinEdit, conditionValidationRule1);
            // 
            // controlLayoutControlGroup
            // 
            resources.ApplyResources(this.controlLayoutControlGroup, "controlLayoutControlGroup");
            this.controlLayoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.controlLayoutControlGroup.GroupBordersVisible = false;
            this.controlLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.infoLayoutControlGroup});
            this.controlLayoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.controlLayoutControlGroup.Name = "controlLayoutControlGroup";
            this.controlLayoutControlGroup.Size = new System.Drawing.Size(625, 276);
            this.controlLayoutControlGroup.TextVisible = false;
            // 
            // infoLayoutControlGroup
            // 
            this.infoLayoutControlGroup.AllowDrawBackground = false;
            resources.ApplyResources(this.infoLayoutControlGroup, "infoLayoutControlGroup");
            this.infoLayoutControlGroup.GroupBordersVisible = false;
            this.infoLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForNoteText,
            this.recordOnItem,
            this.ItemForTypeCode,
            this.ItemForEffort});
            this.infoLayoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.infoLayoutControlGroup.Name = "infoLayoutControlGroup";
            this.infoLayoutControlGroup.Size = new System.Drawing.Size(605, 256);
            // 
            // ItemForNoteText
            // 
            this.ItemForNoteText.Control = this.descriptionEdit;
            resources.ApplyResources(this.ItemForNoteText, "ItemForNoteText");
            this.ItemForNoteText.Location = new System.Drawing.Point(0, 24);
            this.ItemForNoteText.Name = "ItemForNoteText";
            this.ItemForNoteText.Size = new System.Drawing.Size(605, 232);
            this.ItemForNoteText.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.ItemForNoteText.TextSize = new System.Drawing.Size(50, 14);
            this.ItemForNoteText.TextToControlDistance = 5;
            // 
            // recordOnItem
            // 
            this.recordOnItem.Control = this.recordOnDateEdit;
            resources.ApplyResources(this.recordOnItem, "recordOnItem");
            this.recordOnItem.Location = new System.Drawing.Point(415, 0);
            this.recordOnItem.Name = "recordOnItem";
            this.recordOnItem.Size = new System.Drawing.Size(190, 24);
            this.recordOnItem.TextSize = new System.Drawing.Size(51, 13);
            // 
            // ItemForTypeCode
            // 
            this.ItemForTypeCode.Control = this.TypeCodeLookUpEdit;
            resources.ApplyResources(this.ItemForTypeCode, "ItemForTypeCode");
            this.ItemForTypeCode.Location = new System.Drawing.Point(0, 0);
            this.ItemForTypeCode.Name = "ItemForTypeCode";
            this.ItemForTypeCode.Size = new System.Drawing.Size(234, 24);
            this.ItemForTypeCode.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.ItemForTypeCode.TextSize = new System.Drawing.Size(50, 14);
            this.ItemForTypeCode.TextToControlDistance = 5;
            // 
            // ItemForEffort
            // 
            this.ItemForEffort.Control = this.EffortSpinEdit;
            resources.ApplyResources(this.ItemForEffort, "ItemForEffort");
            this.ItemForEffort.Location = new System.Drawing.Point(234, 0);
            this.ItemForEffort.Name = "ItemForEffort";
            this.ItemForEffort.Size = new System.Drawing.Size(181, 24);
            this.ItemForEffort.TextSize = new System.Drawing.Size(51, 13);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.cancelButton);
            this.controlPanel.Controls.Add(this.saveButton);
            resources.ApplyResources(this.controlPanel, "controlPanel");
            this.controlPanel.Name = "controlPanel";
            // 
            // TimeTrackingDetailForm
            // 
            this.AcceptButton = this.saveButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.timeTrackingDataLayoutControl);
            this.Controls.Add(this.controlPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimeTrackingDetailForm";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TimeTrackingDetailForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.timeTrackingDataLayoutControl)).EndInit();
            this.timeTrackingDataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recordOnDateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordOnDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTrackingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeCodeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffortSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNoteText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordOnItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTypeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEffort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).EndInit();
            this.controlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl timeTrackingDataLayoutControl;
        private System.Windows.Forms.BindingSource timeTrackingBindingSource;
        private DevExpress.XtraLayout.LayoutControlGroup controlLayoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlGroup infoLayoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNoteText;
        private DevExpress.XtraEditors.SimpleButton cancelButton;
        private DevExpress.XtraEditors.SimpleButton saveButton;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider;
        private DevExpress.XtraEditors.MemoEdit descriptionEdit;
        private System.Windows.Forms.Panel controlPanel;
        private DropDownDateEdit recordOnDateEdit;
        private DevExpress.XtraLayout.LayoutControlItem recordOnItem;
        private DevExpress.XtraEditors.LookUpEdit TypeCodeLookUpEdit;
        private DevExpress.XtraEditors.SpinEdit EffortSpinEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTypeCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEffort;
    }
}
