using System;
namespace Katrin.Win.ProjectTaskModule.BatchEffort
{
    partial class NewTaskEffortDetailView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewTaskEffortDetailView));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.RecordOnRepositoryItemTimeEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.ActualInputRepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.EffortRepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.OvertimeRepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.DescriptionRepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.entityGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActualWorkHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemainderTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActualInput = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEffort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOvertime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).BeginInit();
            this.EntityDataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordOnRepositoryItemTimeEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordOnRepositoryItemTimeEdit.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActualInputRepositoryItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffortRepositoryItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OvertimeRepositoryItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionRepositoryItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // EntityDataLayoutControl
            // 
            resources.ApplyResources(this.EntityDataLayoutControl, "EntityDataLayoutControl");
            this.EntityDataLayoutControl.Controls.Add(this.entityGridControl);
            this.EntityDataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(665, 19, 456, 477);
            // 
            // RootLayoutControlGroup
            // 
            resources.ApplyResources(this.RootLayoutControlGroup, "RootLayoutControlGroup");
            this.RootLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.RootLayoutControlGroup.Name = "Root";
            this.RootLayoutControlGroup.OptionsToolTip.ToolTip = resources.GetString("resource.ToolTip");
            this.RootLayoutControlGroup.OptionsToolTip.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("resource.ToolTipIconType")));
            this.RootLayoutControlGroup.OptionsToolTip.ToolTipTitle = resources.GetString("resource.ToolTipTitle");
            this.RootLayoutControlGroup.Size = new System.Drawing.Size(693, 546);
            // 
            // RecordOnRepositoryItemTimeEdit
            // 
            resources.ApplyResources(this.RecordOnRepositoryItemTimeEdit, "RecordOnRepositoryItemTimeEdit");
            this.RecordOnRepositoryItemTimeEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("RecordOnRepositoryItemTimeEdit.Buttons"))))});
            this.RecordOnRepositoryItemTimeEdit.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("RecordOnRepositoryItemTimeEdit.Mask.AutoComplete")));
            this.RecordOnRepositoryItemTimeEdit.Mask.BeepOnError = ((bool)(resources.GetObject("RecordOnRepositoryItemTimeEdit.Mask.BeepOnError")));
            this.RecordOnRepositoryItemTimeEdit.Mask.EditMask = resources.GetString("RecordOnRepositoryItemTimeEdit.Mask.EditMask");
            this.RecordOnRepositoryItemTimeEdit.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("RecordOnRepositoryItemTimeEdit.Mask.IgnoreMaskBlank")));
            this.RecordOnRepositoryItemTimeEdit.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("RecordOnRepositoryItemTimeEdit.Mask.MaskType")));
            this.RecordOnRepositoryItemTimeEdit.Mask.PlaceHolder = ((char)(resources.GetObject("RecordOnRepositoryItemTimeEdit.Mask.PlaceHolder")));
            this.RecordOnRepositoryItemTimeEdit.Mask.SaveLiteral = ((bool)(resources.GetObject("RecordOnRepositoryItemTimeEdit.Mask.SaveLiteral")));
            this.RecordOnRepositoryItemTimeEdit.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("RecordOnRepositoryItemTimeEdit.Mask.ShowPlaceHolders")));
            this.RecordOnRepositoryItemTimeEdit.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("RecordOnRepositoryItemTimeEdit.Mask.UseMaskAsDisplayFormat")));
            this.RecordOnRepositoryItemTimeEdit.Name = "RecordOnRepositoryItemTimeEdit";
            this.RecordOnRepositoryItemTimeEdit.VistaTimeProperties.AccessibleDescription = resources.GetString("RecordOnRepositoryItemTimeEdit.VistaTimeProperties.AccessibleDescription");
            this.RecordOnRepositoryItemTimeEdit.VistaTimeProperties.AccessibleName = resources.GetString("RecordOnRepositoryItemTimeEdit.VistaTimeProperties.AccessibleName");
            this.RecordOnRepositoryItemTimeEdit.VistaTimeProperties.AutoHeight = ((bool)(resources.GetObject("RecordOnRepositoryItemTimeEdit.VistaTimeProperties.AutoHeight")));
            this.RecordOnRepositoryItemTimeEdit.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.RecordOnRepositoryItemTimeEdit.VistaTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("RecordOnRepositoryItemTimeEdit.VistaTimeProperties.Mask.AutoComplete")));
            this.RecordOnRepositoryItemTimeEdit.VistaTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("RecordOnRepositoryItemTimeEdit.VistaTimeProperties.Mask.BeepOnError")));
            this.RecordOnRepositoryItemTimeEdit.VistaTimeProperties.Mask.EditMask = resources.GetString("RecordOnRepositoryItemTimeEdit.VistaTimeProperties.Mask.EditMask");
            this.RecordOnRepositoryItemTimeEdit.VistaTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("RecordOnRepositoryItemTimeEdit.VistaTimeProperties.Mask.IgnoreMaskBlank")));
            this.RecordOnRepositoryItemTimeEdit.VistaTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("RecordOnRepositoryItemTimeEdit.VistaTimeProperties.Mask.MaskType")));
            this.RecordOnRepositoryItemTimeEdit.VistaTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("RecordOnRepositoryItemTimeEdit.VistaTimeProperties.Mask.PlaceHolder")));
            this.RecordOnRepositoryItemTimeEdit.VistaTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("RecordOnRepositoryItemTimeEdit.VistaTimeProperties.Mask.SaveLiteral")));
            this.RecordOnRepositoryItemTimeEdit.VistaTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("RecordOnRepositoryItemTimeEdit.VistaTimeProperties.Mask.ShowPlaceHolders")));
            this.RecordOnRepositoryItemTimeEdit.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("RecordOnRepositoryItemTimeEdit.VistaTimeProperties.Mask.UseMaskAsDisplayFormat")));
            this.RecordOnRepositoryItemTimeEdit.VistaTimeProperties.NullValuePrompt = resources.GetString("RecordOnRepositoryItemTimeEdit.VistaTimeProperties.NullValuePrompt");
            this.RecordOnRepositoryItemTimeEdit.VistaTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("RecordOnRepositoryItemTimeEdit.VistaTimeProperties.NullValuePromptShowForEmptyVal" +
        "ue")));
            // 
            // ActualInputRepositoryItem
            // 
            resources.ApplyResources(this.ActualInputRepositoryItem, "ActualInputRepositoryItem");
            this.ActualInputRepositoryItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ActualInputRepositoryItem.EditFormat.FormatString = "{0:n1}";
            this.ActualInputRepositoryItem.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ActualInputRepositoryItem.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("ActualInputRepositoryItem.Mask.AutoComplete")));
            this.ActualInputRepositoryItem.Mask.BeepOnError = ((bool)(resources.GetObject("ActualInputRepositoryItem.Mask.BeepOnError")));
            this.ActualInputRepositoryItem.Mask.EditMask = resources.GetString("ActualInputRepositoryItem.Mask.EditMask");
            this.ActualInputRepositoryItem.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("ActualInputRepositoryItem.Mask.IgnoreMaskBlank")));
            this.ActualInputRepositoryItem.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("ActualInputRepositoryItem.Mask.MaskType")));
            this.ActualInputRepositoryItem.Mask.PlaceHolder = ((char)(resources.GetObject("ActualInputRepositoryItem.Mask.PlaceHolder")));
            this.ActualInputRepositoryItem.Mask.SaveLiteral = ((bool)(resources.GetObject("ActualInputRepositoryItem.Mask.SaveLiteral")));
            this.ActualInputRepositoryItem.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("ActualInputRepositoryItem.Mask.ShowPlaceHolders")));
            this.ActualInputRepositoryItem.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("ActualInputRepositoryItem.Mask.UseMaskAsDisplayFormat")));
            this.ActualInputRepositoryItem.MaxLength = 5;
            this.ActualInputRepositoryItem.MaxValue = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.ActualInputRepositoryItem.Name = "ActualInputRepositoryItem";
            this.ActualInputRepositoryItem.EditValueChanged += new System.EventHandler(this.RepositoryItem_EditValueChanged);
            this.ActualInputRepositoryItem.Click += new System.EventHandler(this.RepositoryItem_Click);
            // 
            // EffortRepositoryItem
            // 
            resources.ApplyResources(this.EffortRepositoryItem, "EffortRepositoryItem");
            this.EffortRepositoryItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.EffortRepositoryItem.EditFormat.FormatString = "{0:n1}";
            this.EffortRepositoryItem.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.EffortRepositoryItem.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("EffortRepositoryItem.Mask.AutoComplete")));
            this.EffortRepositoryItem.Mask.BeepOnError = ((bool)(resources.GetObject("EffortRepositoryItem.Mask.BeepOnError")));
            this.EffortRepositoryItem.Mask.EditMask = resources.GetString("EffortRepositoryItem.Mask.EditMask");
            this.EffortRepositoryItem.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("EffortRepositoryItem.Mask.IgnoreMaskBlank")));
            this.EffortRepositoryItem.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("EffortRepositoryItem.Mask.MaskType")));
            this.EffortRepositoryItem.Mask.PlaceHolder = ((char)(resources.GetObject("EffortRepositoryItem.Mask.PlaceHolder")));
            this.EffortRepositoryItem.Mask.SaveLiteral = ((bool)(resources.GetObject("EffortRepositoryItem.Mask.SaveLiteral")));
            this.EffortRepositoryItem.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("EffortRepositoryItem.Mask.ShowPlaceHolders")));
            this.EffortRepositoryItem.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("EffortRepositoryItem.Mask.UseMaskAsDisplayFormat")));
            this.EffortRepositoryItem.MaxLength = 5;
            this.EffortRepositoryItem.MaxValue = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.EffortRepositoryItem.Name = "EffortRepositoryItem";
            this.EffortRepositoryItem.EditValueChanged += new System.EventHandler(this.RepositoryItem_EditValueChanged);
            this.EffortRepositoryItem.Click += new System.EventHandler(this.RepositoryItem_Click);
            // 
            // OvertimeRepositoryItem
            // 
            resources.ApplyResources(this.OvertimeRepositoryItem, "OvertimeRepositoryItem");
            this.OvertimeRepositoryItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.OvertimeRepositoryItem.EditFormat.FormatString = "{0:n1}";
            this.OvertimeRepositoryItem.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.OvertimeRepositoryItem.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("OvertimeRepositoryItem.Mask.AutoComplete")));
            this.OvertimeRepositoryItem.Mask.BeepOnError = ((bool)(resources.GetObject("OvertimeRepositoryItem.Mask.BeepOnError")));
            this.OvertimeRepositoryItem.Mask.EditMask = resources.GetString("OvertimeRepositoryItem.Mask.EditMask");
            this.OvertimeRepositoryItem.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("OvertimeRepositoryItem.Mask.IgnoreMaskBlank")));
            this.OvertimeRepositoryItem.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("OvertimeRepositoryItem.Mask.MaskType")));
            this.OvertimeRepositoryItem.Mask.PlaceHolder = ((char)(resources.GetObject("OvertimeRepositoryItem.Mask.PlaceHolder")));
            this.OvertimeRepositoryItem.Mask.SaveLiteral = ((bool)(resources.GetObject("OvertimeRepositoryItem.Mask.SaveLiteral")));
            this.OvertimeRepositoryItem.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("OvertimeRepositoryItem.Mask.ShowPlaceHolders")));
            this.OvertimeRepositoryItem.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("OvertimeRepositoryItem.Mask.UseMaskAsDisplayFormat")));
            this.OvertimeRepositoryItem.MaxLength = 5;
            this.OvertimeRepositoryItem.MaxValue = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.OvertimeRepositoryItem.Name = "OvertimeRepositoryItem";
            this.OvertimeRepositoryItem.EditValueChanged += new System.EventHandler(this.RepositoryItem_EditValueChanged);
            this.OvertimeRepositoryItem.Click += new System.EventHandler(this.RepositoryItem_Click);
            // 
            // DescriptionRepositoryItem
            // 
            resources.ApplyResources(this.DescriptionRepositoryItem, "DescriptionRepositoryItem");
            this.DescriptionRepositoryItem.Name = "DescriptionRepositoryItem";
            this.DescriptionRepositoryItem.EditValueChanged += new System.EventHandler(this.RepositoryItem_EditValueChanged);
            // 
            // entityGridControl
            // 
            resources.ApplyResources(this.entityGridControl, "entityGridControl");
            this.entityGridControl.DataSource = this.EntityBindingSource;
            this.entityGridControl.EmbeddedNavigator.AccessibleDescription = resources.GetString("entityGridControl.EmbeddedNavigator.AccessibleDescription");
            this.entityGridControl.EmbeddedNavigator.AccessibleName = resources.GetString("entityGridControl.EmbeddedNavigator.AccessibleName");
            this.entityGridControl.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("entityGridControl.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.entityGridControl.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("entityGridControl.EmbeddedNavigator.Anchor")));
            this.entityGridControl.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("entityGridControl.EmbeddedNavigator.BackgroundImage")));
            this.entityGridControl.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("entityGridControl.EmbeddedNavigator.BackgroundImageLayout")));
            this.entityGridControl.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("entityGridControl.EmbeddedNavigator.ImeMode")));
            this.entityGridControl.EmbeddedNavigator.MaximumSize = ((System.Drawing.Size)(resources.GetObject("entityGridControl.EmbeddedNavigator.MaximumSize")));
            this.entityGridControl.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("entityGridControl.EmbeddedNavigator.TextLocation")));
            this.entityGridControl.EmbeddedNavigator.ToolTip = resources.GetString("entityGridControl.EmbeddedNavigator.ToolTip");
            this.entityGridControl.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("entityGridControl.EmbeddedNavigator.ToolTipIconType")));
            this.entityGridControl.EmbeddedNavigator.ToolTipTitle = resources.GetString("entityGridControl.EmbeddedNavigator.ToolTipTitle");
            this.entityGridControl.MainView = this.gridView1;
            this.entityGridControl.Name = "entityGridControl";
            this.entityGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            resources.ApplyResources(this.gridView1, "gridView1");
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colProjectId,
            this.colStartDate,
            this.colEndDate,
            this.colActualWorkHours,
            this.colRemainderTime,
            this.colRecordOn,
            this.colActualInput,
            this.colEffort,
            this.colOvertime,
            this.colDescription});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridView1.GridControl = this.entityGridControl;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colProjectId, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colName
            // 
            resources.ApplyResources(this.colName, "colName");
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.FixedWidth = true;
            // 
            // colProjectId
            // 
            resources.ApplyResources(this.colProjectId, "colProjectId");
            this.colProjectId.FieldName = "ProjectName";
            this.colProjectId.Name = "colProjectId";
            this.colProjectId.OptionsColumn.AllowEdit = false;
            this.colProjectId.OptionsColumn.FixedWidth = true;
            // 
            // colStartDate
            // 
            resources.ApplyResources(this.colStartDate, "colStartDate");
            this.colStartDate.FieldName = "StartDate";
            this.colStartDate.Name = "colStartDate";
            // 
            // colEndDate
            // 
            resources.ApplyResources(this.colEndDate, "colEndDate");
            this.colEndDate.FieldName = "EndDate";
            this.colEndDate.Name = "colEndDate";
            // 
            // colActualWorkHours
            // 
            resources.ApplyResources(this.colActualWorkHours, "colActualWorkHours");
            this.colActualWorkHours.FieldName = "ActualWorkHours";
            this.colActualWorkHours.Name = "colActualWorkHours";
            this.colActualWorkHours.OptionsColumn.AllowEdit = false;
            this.colActualWorkHours.OptionsColumn.FixedWidth = true;
            this.colActualWorkHours.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("colActualWorkHours.Summary"))))});
            // 
            // colRemainderTime
            // 
            resources.ApplyResources(this.colRemainderTime, "colRemainderTime");
            this.colRemainderTime.FieldName = "RemainderTime";
            this.colRemainderTime.Name = "colRemainderTime";
            this.colRemainderTime.OptionsColumn.AllowEdit = false;
            // 
            // colRecordOn
            // 
            resources.ApplyResources(this.colRecordOn, "colRecordOn");
            this.colRecordOn.ColumnEdit = this.RecordOnRepositoryItemTimeEdit;
            this.colRecordOn.FieldName = "RecordOn";
            this.colRecordOn.Name = "colRecordOn";
            // 
            // colActualInput
            // 
            resources.ApplyResources(this.colActualInput, "colActualInput");
            this.colActualInput.ColumnEdit = this.ActualInputRepositoryItem;
            this.colActualInput.FieldName = "ActualInput";
            this.colActualInput.Name = "colActualInput";
            this.colActualInput.OptionsColumn.FixedWidth = true;
            this.colActualInput.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("colActualInput.Summary"))))});
            // 
            // colEffort
            // 
            resources.ApplyResources(this.colEffort, "colEffort");
            this.colEffort.ColumnEdit = this.EffortRepositoryItem;
            this.colEffort.FieldName = "Effort";
            this.colEffort.Name = "colEffort";
            this.colEffort.OptionsColumn.FixedWidth = true;
            this.colEffort.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("colEffort.Summary"))))});
            // 
            // colOvertime
            // 
            resources.ApplyResources(this.colOvertime, "colOvertime");
            this.colOvertime.ColumnEdit = this.OvertimeRepositoryItem;
            this.colOvertime.FieldName = "Overtime";
            this.colOvertime.Name = "colOvertime";
            this.colOvertime.OptionsColumn.FixedWidth = true;
            this.colOvertime.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("colOvertime.Summary"))))});
            // 
            // colDescription
            // 
            resources.ApplyResources(this.colDescription, "colDescription");
            this.colDescription.ColumnEdit = this.DescriptionRepositoryItem;
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.FixedWidth = true;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.entityGridControl;
            resources.ApplyResources(this.layoutControlItem2, "layoutControlItem2");
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(673, 526);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // NewTaskEffortDetailView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "NewTaskEffortDetailView";
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).EndInit();
            this.EntityDataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordOnRepositoryItemTimeEdit.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordOnRepositoryItemTimeEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActualInputRepositoryItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffortRepositoryItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OvertimeRepositoryItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionRepositoryItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraGrid.GridControl entityGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectId;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colActualWorkHours;
        private DevExpress.XtraGrid.Columns.GridColumn colActualInput;
        private DevExpress.XtraGrid.Columns.GridColumn colEffort;
        private DevExpress.XtraGrid.Columns.GridColumn colOvertime;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordOn;
        private DevExpress.XtraGrid.Columns.GridColumn colRemainderTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit RecordOnRepositoryItemTimeEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit ActualInputRepositoryItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit EffortRepositoryItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit OvertimeRepositoryItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit DescriptionRepositoryItem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEndDate;

    }
}
