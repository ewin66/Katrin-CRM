using System;
namespace Katrin.Win.AttendanceModule.Detail
{
    partial class AttendanceDetailView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendanceDetailView));
            this.RecordPopupContainerEdit = new DevExpress.XtraEditors.PopupContainerEdit();
            this.RecordOndateEdit = new Katrin.AppFramework.WinForms.Controls.DropDownDateEdit();
            this.AttendanceUnitCodeLookupEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.AttendanceTimespinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.ItemForAttendanceTime = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForRecordOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAttendanceUnitCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.General = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForRecord = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.DescriptionMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ItemForAttendanceType = new DevExpress.XtraLayout.LayoutControlItem();
            this.AttendanceTypeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.Management = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).BeginInit();
            this.EntityDataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordPopupContainerEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordOndateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordOndateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceUnitCodeLookupEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceTimespinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAttendanceTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRecordOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAttendanceUnitCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.General)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAttendanceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceTypeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Management)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // EntityDataLayoutControl
            // 
            resources.ApplyResources(this.EntityDataLayoutControl, "EntityDataLayoutControl");
            this.EntityDataLayoutControl.Controls.Add(this.AttendanceTypeLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.DescriptionMemoEdit);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit4);
            this.EntityDataLayoutControl.Controls.Add(this.AttendanceUnitCodeLookupEdit);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit);
            this.EntityDataLayoutControl.Controls.Add(this.RecordOndateEdit);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit1);
            this.EntityDataLayoutControl.Controls.Add(this.RecordPopupContainerEdit);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit3);
            this.EntityDataLayoutControl.Controls.Add(this.AttendanceTimespinEdit);
            this.EntityDataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(505, 164, 393, 500);
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
            this.RootLayoutControlGroup.Size = new System.Drawing.Size(775, 508);
            // 
            // RecordPopupContainerEdit
            // 
            resources.ApplyResources(this.RecordPopupContainerEdit, "RecordPopupContainerEdit");
            this.RecordPopupContainerEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "RecordPersonId", true));
            this.RecordPopupContainerEdit.Name = "RecordPopupContainerEdit";
            this.RecordPopupContainerEdit.Properties.AccessibleDescription = resources.GetString("RecordPopupContainerEdit.Properties.AccessibleDescription");
            this.RecordPopupContainerEdit.Properties.AccessibleName = resources.GetString("RecordPopupContainerEdit.Properties.AccessibleName");
            this.RecordPopupContainerEdit.Properties.AutoHeight = ((bool)(resources.GetObject("RecordPopupContainerEdit.Properties.AutoHeight")));
            this.RecordPopupContainerEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("RecordPopupContainerEdit.Properties.Buttons"))))});
            this.RecordPopupContainerEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("RecordPopupContainerEdit.Properties.Mask.AutoComplete")));
            this.RecordPopupContainerEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("RecordPopupContainerEdit.Properties.Mask.BeepOnError")));
            this.RecordPopupContainerEdit.Properties.Mask.EditMask = resources.GetString("RecordPopupContainerEdit.Properties.Mask.EditMask");
            this.RecordPopupContainerEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("RecordPopupContainerEdit.Properties.Mask.IgnoreMaskBlank")));
            this.RecordPopupContainerEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("RecordPopupContainerEdit.Properties.Mask.MaskType")));
            this.RecordPopupContainerEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("RecordPopupContainerEdit.Properties.Mask.PlaceHolder")));
            this.RecordPopupContainerEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("RecordPopupContainerEdit.Properties.Mask.SaveLiteral")));
            this.RecordPopupContainerEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("RecordPopupContainerEdit.Properties.Mask.ShowPlaceHolders")));
            this.RecordPopupContainerEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("RecordPopupContainerEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.RecordPopupContainerEdit.Properties.NullValuePrompt = resources.GetString("RecordPopupContainerEdit.Properties.NullValuePrompt");
            this.RecordPopupContainerEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("RecordPopupContainerEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.RecordPopupContainerEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // RecordOndateEdit
            // 
            resources.ApplyResources(this.RecordOndateEdit, "RecordOndateEdit");
            this.RecordOndateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "RecordOn", true));
            this.RecordOndateEdit.Name = "RecordOndateEdit";
            this.RecordOndateEdit.Properties.AccessibleDescription = resources.GetString("RecordOndateEdit.Properties.AccessibleDescription");
            this.RecordOndateEdit.Properties.AccessibleName = resources.GetString("RecordOndateEdit.Properties.AccessibleName");
            this.RecordOndateEdit.Properties.AutoHeight = ((bool)(resources.GetObject("RecordOndateEdit.Properties.AutoHeight")));
            this.RecordOndateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("RecordOndateEdit.Properties.Buttons"))))});
            this.RecordOndateEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("RecordOndateEdit.Properties.Mask.AutoComplete")));
            this.RecordOndateEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("RecordOndateEdit.Properties.Mask.BeepOnError")));
            this.RecordOndateEdit.Properties.Mask.EditMask = resources.GetString("RecordOndateEdit.Properties.Mask.EditMask");
            this.RecordOndateEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("RecordOndateEdit.Properties.Mask.IgnoreMaskBlank")));
            this.RecordOndateEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("RecordOndateEdit.Properties.Mask.MaskType")));
            this.RecordOndateEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("RecordOndateEdit.Properties.Mask.PlaceHolder")));
            this.RecordOndateEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("RecordOndateEdit.Properties.Mask.SaveLiteral")));
            this.RecordOndateEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("RecordOndateEdit.Properties.Mask.ShowPlaceHolders")));
            this.RecordOndateEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("RecordOndateEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.RecordOndateEdit.Properties.NullValuePrompt = resources.GetString("RecordOndateEdit.Properties.NullValuePrompt");
            this.RecordOndateEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("RecordOndateEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.RecordOndateEdit.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("RecordOndateEdit.Properties.VistaTimeProperties.AccessibleDescription");
            this.RecordOndateEdit.Properties.VistaTimeProperties.AccessibleName = resources.GetString("RecordOndateEdit.Properties.VistaTimeProperties.AccessibleName");
            this.RecordOndateEdit.Properties.VistaTimeProperties.AutoHeight = ((bool)(resources.GetObject("RecordOndateEdit.Properties.VistaTimeProperties.AutoHeight")));
            this.RecordOndateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.RecordOndateEdit.Properties.VistaTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("RecordOndateEdit.Properties.VistaTimeProperties.Mask.AutoComplete")));
            this.RecordOndateEdit.Properties.VistaTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("RecordOndateEdit.Properties.VistaTimeProperties.Mask.BeepOnError")));
            this.RecordOndateEdit.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("RecordOndateEdit.Properties.VistaTimeProperties.Mask.EditMask");
            this.RecordOndateEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("RecordOndateEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank")));
            this.RecordOndateEdit.Properties.VistaTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("RecordOndateEdit.Properties.VistaTimeProperties.Mask.MaskType")));
            this.RecordOndateEdit.Properties.VistaTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("RecordOndateEdit.Properties.VistaTimeProperties.Mask.PlaceHolder")));
            this.RecordOndateEdit.Properties.VistaTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("RecordOndateEdit.Properties.VistaTimeProperties.Mask.SaveLiteral")));
            this.RecordOndateEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("RecordOndateEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders")));
            this.RecordOndateEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("RecordOndateEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat")));
            this.RecordOndateEdit.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("RecordOndateEdit.Properties.VistaTimeProperties.NullValuePrompt");
            this.RecordOndateEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("RecordOndateEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue")));
            this.RecordOndateEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // AttendanceUnitCodeLookupEdit
            // 
            resources.ApplyResources(this.AttendanceUnitCodeLookupEdit, "AttendanceUnitCodeLookupEdit");
            this.AttendanceUnitCodeLookupEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "AttendanceUnitCode", true));
            this.AttendanceUnitCodeLookupEdit.Name = "AttendanceUnitCodeLookupEdit";
            this.AttendanceUnitCodeLookupEdit.Properties.AccessibleDescription = resources.GetString("AttendanceUnitCodeLookupEdit.Properties.AccessibleDescription");
            this.AttendanceUnitCodeLookupEdit.Properties.AccessibleName = resources.GetString("AttendanceUnitCodeLookupEdit.Properties.AccessibleName");
            this.AttendanceUnitCodeLookupEdit.Properties.AutoHeight = ((bool)(resources.GetObject("AttendanceUnitCodeLookupEdit.Properties.AutoHeight")));
            this.AttendanceUnitCodeLookupEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("AttendanceUnitCodeLookupEdit.Properties.Buttons"))))});
            this.AttendanceUnitCodeLookupEdit.Properties.DataSource = this.EntityBindingSource;
            this.AttendanceUnitCodeLookupEdit.Properties.DisplayMember = "AttendanceUnitCode";
            this.AttendanceUnitCodeLookupEdit.Properties.NullText = resources.GetString("AttendanceUnitCodeLookupEdit.Properties.NullText");
            this.AttendanceUnitCodeLookupEdit.Properties.NullValuePrompt = resources.GetString("AttendanceUnitCodeLookupEdit.Properties.NullValuePrompt");
            this.AttendanceUnitCodeLookupEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("AttendanceUnitCodeLookupEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.AttendanceUnitCodeLookupEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // AttendanceTimespinEdit
            // 
            resources.ApplyResources(this.AttendanceTimespinEdit, "AttendanceTimespinEdit");
            this.AttendanceTimespinEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "AttendanceLength", true));
            this.AttendanceTimespinEdit.Name = "AttendanceTimespinEdit";
            this.AttendanceTimespinEdit.Properties.AccessibleDescription = resources.GetString("AttendanceTimespinEdit.Properties.AccessibleDescription");
            this.AttendanceTimespinEdit.Properties.AccessibleName = resources.GetString("AttendanceTimespinEdit.Properties.AccessibleName");
            this.AttendanceTimespinEdit.Properties.AutoHeight = ((bool)(resources.GetObject("AttendanceTimespinEdit.Properties.AutoHeight")));
            this.AttendanceTimespinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.AttendanceTimespinEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.AttendanceTimespinEdit.Properties.IsFloatValue = false;
            this.AttendanceTimespinEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("AttendanceTimespinEdit.Properties.Mask.AutoComplete")));
            this.AttendanceTimespinEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("AttendanceTimespinEdit.Properties.Mask.BeepOnError")));
            this.AttendanceTimespinEdit.Properties.Mask.EditMask = resources.GetString("AttendanceTimespinEdit.Properties.Mask.EditMask");
            this.AttendanceTimespinEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("AttendanceTimespinEdit.Properties.Mask.IgnoreMaskBlank")));
            this.AttendanceTimespinEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("AttendanceTimespinEdit.Properties.Mask.MaskType")));
            this.AttendanceTimespinEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("AttendanceTimespinEdit.Properties.Mask.PlaceHolder")));
            this.AttendanceTimespinEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("AttendanceTimespinEdit.Properties.Mask.SaveLiteral")));
            this.AttendanceTimespinEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("AttendanceTimespinEdit.Properties.Mask.ShowPlaceHolders")));
            this.AttendanceTimespinEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("AttendanceTimespinEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.AttendanceTimespinEdit.Properties.MaxLength = 3;
            this.AttendanceTimespinEdit.Properties.MaxValue = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.AttendanceTimespinEdit.Properties.NullValuePrompt = resources.GetString("AttendanceTimespinEdit.Properties.NullValuePrompt");
            this.AttendanceTimespinEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("AttendanceTimespinEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.AttendanceTimespinEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForAttendanceTime
            // 
            this.ItemForAttendanceTime.Control = this.AttendanceTimespinEdit;
            resources.ApplyResources(this.ItemForAttendanceTime, "ItemForAttendanceTime");
            this.ItemForAttendanceTime.Location = new System.Drawing.Point(0, 48);
            this.ItemForAttendanceTime.MaxSize = new System.Drawing.Size(0, 24);
            this.ItemForAttendanceTime.MinSize = new System.Drawing.Size(163, 24);
            this.ItemForAttendanceTime.Name = "ItemForAttendanceTime";
            this.ItemForAttendanceTime.Size = new System.Drawing.Size(365, 24);
            this.ItemForAttendanceTime.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForAttendanceTime.TextSize = new System.Drawing.Size(97, 14);
            // 
            // ItemForRecordOn
            // 
            this.ItemForRecordOn.Control = this.RecordOndateEdit;
            resources.ApplyResources(this.ItemForRecordOn, "ItemForRecordOn");
            this.ItemForRecordOn.Location = new System.Drawing.Point(0, 24);
            this.ItemForRecordOn.MaxSize = new System.Drawing.Size(0, 24);
            this.ItemForRecordOn.MinSize = new System.Drawing.Size(155, 24);
            this.ItemForRecordOn.Name = "ItemForRecordOn";
            this.ItemForRecordOn.Size = new System.Drawing.Size(365, 24);
            this.ItemForRecordOn.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForRecordOn.TextSize = new System.Drawing.Size(97, 14);
            // 
            // ItemForAttendanceUnitCode
            // 
            this.ItemForAttendanceUnitCode.Control = this.AttendanceUnitCodeLookupEdit;
            resources.ApplyResources(this.ItemForAttendanceUnitCode, "ItemForAttendanceUnitCode");
            this.ItemForAttendanceUnitCode.Location = new System.Drawing.Point(365, 48);
            this.ItemForAttendanceUnitCode.MaxSize = new System.Drawing.Size(0, 24);
            this.ItemForAttendanceUnitCode.MinSize = new System.Drawing.Size(163, 24);
            this.ItemForAttendanceUnitCode.Name = "ItemForAttendanceUnitCode";
            this.ItemForAttendanceUnitCode.Size = new System.Drawing.Size(366, 24);
            this.ItemForAttendanceUnitCode.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForAttendanceUnitCode.TextSize = new System.Drawing.Size(97, 14);
            // 
            // tabbedControlGroup1
            // 
            resources.ApplyResources(this.tabbedControlGroup1, "tabbedControlGroup1");
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.General;
            this.tabbedControlGroup1.SelectedTabPageIndex = 0;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(755, 488);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.General,
            this.Management});
            // 
            // General
            // 
            resources.ApplyResources(this.General, "General");
            this.General.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForAttendanceUnitCode,
            this.ItemForRecord,
            this.ItemForDescription,
            this.emptySpaceItem2,
            this.ItemForAttendanceTime,
            this.ItemForRecordOn,
            this.ItemForAttendanceType});
            this.General.Location = new System.Drawing.Point(0, 0);
            this.General.Name = "General";
            this.General.Size = new System.Drawing.Size(731, 441);
            // 
            // ItemForRecord
            // 
            this.ItemForRecord.Control = this.RecordPopupContainerEdit;
            resources.ApplyResources(this.ItemForRecord, "ItemForRecord");
            this.ItemForRecord.Location = new System.Drawing.Point(365, 0);
            this.ItemForRecord.MaxSize = new System.Drawing.Size(0, 24);
            this.ItemForRecord.MinSize = new System.Drawing.Size(155, 24);
            this.ItemForRecord.Name = "ItemForRecord";
            this.ItemForRecord.Size = new System.Drawing.Size(366, 24);
            this.ItemForRecord.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForRecord.TextSize = new System.Drawing.Size(97, 14);
            // 
            // ItemForDescription
            // 
            this.ItemForDescription.Control = this.DescriptionMemoEdit;
            resources.ApplyResources(this.ItemForDescription, "ItemForDescription");
            this.ItemForDescription.Location = new System.Drawing.Point(0, 72);
            this.ItemForDescription.MinSize = new System.Drawing.Size(176, 20);
            this.ItemForDescription.Name = "ItemForDescription";
            this.ItemForDescription.Size = new System.Drawing.Size(731, 369);
            this.ItemForDescription.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForDescription.TextSize = new System.Drawing.Size(97, 14);
            // 
            // DescriptionMemoEdit
            // 
            resources.ApplyResources(this.DescriptionMemoEdit, "DescriptionMemoEdit");
            this.DescriptionMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "Description", true));
            this.DescriptionMemoEdit.Name = "DescriptionMemoEdit";
            this.DescriptionMemoEdit.Properties.AccessibleDescription = resources.GetString("DescriptionMemoEdit.Properties.AccessibleDescription");
            this.DescriptionMemoEdit.Properties.AccessibleName = resources.GetString("DescriptionMemoEdit.Properties.AccessibleName");
            this.DescriptionMemoEdit.Properties.NullValuePrompt = resources.GetString("DescriptionMemoEdit.Properties.NullValuePrompt");
            this.DescriptionMemoEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("DescriptionMemoEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.DescriptionMemoEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem2, "emptySpaceItem2");
            this.emptySpaceItem2.Location = new System.Drawing.Point(365, 24);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(366, 24);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ItemForAttendanceType
            // 
            this.ItemForAttendanceType.Control = this.AttendanceTypeLookUpEdit;
            resources.ApplyResources(this.ItemForAttendanceType, "ItemForAttendanceType");
            this.ItemForAttendanceType.Location = new System.Drawing.Point(0, 0);
            this.ItemForAttendanceType.Name = "ItemForAttendanceType";
            this.ItemForAttendanceType.Size = new System.Drawing.Size(365, 24);
            this.ItemForAttendanceType.TextSize = new System.Drawing.Size(97, 14);
            // 
            // AttendanceTypeLookUpEdit
            // 
            resources.ApplyResources(this.AttendanceTypeLookUpEdit, "AttendanceTypeLookUpEdit");
            this.AttendanceTypeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "AttendanceTypeCode", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.AttendanceTypeLookUpEdit.Name = "AttendanceTypeLookUpEdit";
            this.AttendanceTypeLookUpEdit.Properties.AccessibleDescription = resources.GetString("AttendanceTypeLookUpEdit.Properties.AccessibleDescription");
            this.AttendanceTypeLookUpEdit.Properties.AccessibleName = resources.GetString("AttendanceTypeLookUpEdit.Properties.AccessibleName");
            this.AttendanceTypeLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("AttendanceTypeLookUpEdit.Properties.AutoHeight")));
            this.AttendanceTypeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("AttendanceTypeLookUpEdit.Properties.Buttons"))))});
            this.AttendanceTypeLookUpEdit.Properties.NullValuePrompt = resources.GetString("AttendanceTypeLookUpEdit.Properties.NullValuePrompt");
            this.AttendanceTypeLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("AttendanceTypeLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.AttendanceTypeLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // Management
            // 
            resources.ApplyResources(this.Management, "Management");
            this.Management.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem7,
            this.layoutControlItem6});
            this.Management.Location = new System.Drawing.Point(0, 0);
            this.Management.Name = "Management";
            this.Management.Size = new System.Drawing.Size(731, 441);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem1, "emptySpaceItem1");
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(731, 393);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.textEdit;
            resources.ApplyResources(this.layoutControlItem8, "layoutControlItem8");
            this.layoutControlItem8.Location = new System.Drawing.Point(365, 0);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(155, 24);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(366, 24);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(97, 14);
            // 
            // textEdit
            // 
            resources.ApplyResources(this.textEdit, "textEdit");
            this.textEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "CreatedBy.FullName", true));
            this.textEdit.Name = "textEdit";
            this.textEdit.Properties.AccessibleDescription = resources.GetString("textEdit.Properties.AccessibleDescription");
            this.textEdit.Properties.AccessibleName = resources.GetString("textEdit.Properties.AccessibleName");
            this.textEdit.Properties.AutoHeight = ((bool)(resources.GetObject("textEdit.Properties.AutoHeight")));
            this.textEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("textEdit.Properties.Mask.AutoComplete")));
            this.textEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("textEdit.Properties.Mask.BeepOnError")));
            this.textEdit.Properties.Mask.EditMask = resources.GetString("textEdit.Properties.Mask.EditMask");
            this.textEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("textEdit.Properties.Mask.IgnoreMaskBlank")));
            this.textEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("textEdit.Properties.Mask.MaskType")));
            this.textEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("textEdit.Properties.Mask.PlaceHolder")));
            this.textEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("textEdit.Properties.Mask.SaveLiteral")));
            this.textEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("textEdit.Properties.Mask.ShowPlaceHolders")));
            this.textEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("textEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.textEdit.Properties.NullValuePrompt = resources.GetString("textEdit.Properties.NullValuePrompt");
            this.textEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("textEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.textEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.textEdit4;
            resources.ApplyResources(this.layoutControlItem9, "layoutControlItem9");
            this.layoutControlItem9.Location = new System.Drawing.Point(365, 24);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(155, 24);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(366, 24);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(97, 14);
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
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.textEdit1;
            resources.ApplyResources(this.layoutControlItem7, "layoutControlItem7");
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(155, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(365, 24);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(97, 14);
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
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.textEdit3;
            resources.ApplyResources(this.layoutControlItem6, "layoutControlItem6");
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(155, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(365, 24);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(97, 14);
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
            // AttendanceDetailView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "AttendanceDetailView";
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).EndInit();
            this.EntityDataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordPopupContainerEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordOndateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordOndateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceUnitCodeLookupEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceTimespinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAttendanceTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRecordOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAttendanceUnitCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.General)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAttendanceType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceTypeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Management)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PopupContainerEdit RecordPopupContainerEdit;
        private DevExpress.XtraEditors.LookUpEdit AttendanceUnitCodeLookupEdit;
        private DevExpress.XtraEditors.SpinEdit AttendanceTimespinEdit;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup General;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRecord;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAttendanceTime;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRecordOn;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAttendanceUnitCode;
        private DevExpress.XtraLayout.LayoutControlGroup Management;
        private DevExpress.XtraEditors.TextEdit textEdit4;
        private DevExpress.XtraEditors.TextEdit textEdit;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.MemoEdit DescriptionMemoEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private Katrin.AppFramework.WinForms.Controls.DropDownDateEdit RecordOndateEdit;
        private DevExpress.XtraEditors.LookUpEdit AttendanceTypeLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAttendanceType;
    }
}
