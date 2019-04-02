using System;
using Katrin.AppFramework.WinForms.Controls;
namespace Katrin.Win.ProjectTaskModule.AddEffort
{
    partial class TaskEffortDetailView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskEffortDetailView));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.RecordOnRepositoryItemTimeEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.ActualInputRepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.EffortRepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.OvertimeRepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.DescriptionRepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.entityGridControl = new DevExpress.XtraGrid.GridControl();
            this.ListBindSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRecordOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActualInput = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEffort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOvertime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.projectTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.taskNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.RemainderTimeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ActualWorkHoursTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.iterationTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.RecordOnDateEdit = new Katrin.AppFramework.WinForms.Controls.DropDownDateEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.GeneralGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itemForiterationName = new DevExpress.XtraLayout.LayoutControlItem();
            this.itemForTaskName = new DevExpress.XtraLayout.LayoutControlItem();
            this.itemForRemainderTime = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForActualInput = new DevExpress.XtraLayout.LayoutControlItem();
            this.ActualInputTextEdit = new DevExpress.XtraEditors.SpinEdit();
            this.ItemForOverTime = new DevExpress.XtraLayout.LayoutControlItem();
            this.OverTimeTextEdit = new DevExpress.XtraEditors.SpinEdit();
            this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.DescriptionMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.itemForProjectName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForActualWorkHours = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForRecordOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForEffort = new DevExpress.XtraLayout.LayoutControlItem();
            this.EffortTextEdit = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
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
            ((System.ComponentModel.ISupportInitialize)(this.ListBindSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemainderTimeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActualWorkHoursTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordOnDateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordOnDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeneralGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForiterationName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForTaskName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForRemainderTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForActualInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActualInputTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOverTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverTimeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForProjectName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForActualWorkHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRecordOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEffort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffortTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // EntityDataLayoutControl
            // 
            resources.ApplyResources(this.EntityDataLayoutControl, "EntityDataLayoutControl");
            this.EntityDataLayoutControl.Controls.Add(this.DescriptionMemoEdit);
            this.EntityDataLayoutControl.Controls.Add(this.RecordOnDateEdit);
            this.EntityDataLayoutControl.Controls.Add(this.RemainderTimeTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.ActualWorkHoursTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.btnRemove);
            this.EntityDataLayoutControl.Controls.Add(this.taskNameTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.iterationTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.projectTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.entityGridControl);
            this.EntityDataLayoutControl.Controls.Add(this.ActualInputTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.EffortTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.OverTimeTextEdit);
            this.EntityDataLayoutControl.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
            this.EntityDataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(170, 10, 456, 477);
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
            this.RootLayoutControlGroup.Size = new System.Drawing.Size(809, 410);
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
            this.ActualInputRepositoryItem.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("ActualInputRepositoryItem.Mask.AutoComplete")));
            this.ActualInputRepositoryItem.Mask.BeepOnError = ((bool)(resources.GetObject("ActualInputRepositoryItem.Mask.BeepOnError")));
            this.ActualInputRepositoryItem.Mask.EditMask = resources.GetString("ActualInputRepositoryItem.Mask.EditMask");
            this.ActualInputRepositoryItem.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("ActualInputRepositoryItem.Mask.IgnoreMaskBlank")));
            this.ActualInputRepositoryItem.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("ActualInputRepositoryItem.Mask.MaskType")));
            this.ActualInputRepositoryItem.Mask.PlaceHolder = ((char)(resources.GetObject("ActualInputRepositoryItem.Mask.PlaceHolder")));
            this.ActualInputRepositoryItem.Mask.SaveLiteral = ((bool)(resources.GetObject("ActualInputRepositoryItem.Mask.SaveLiteral")));
            this.ActualInputRepositoryItem.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("ActualInputRepositoryItem.Mask.ShowPlaceHolders")));
            this.ActualInputRepositoryItem.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("ActualInputRepositoryItem.Mask.UseMaskAsDisplayFormat")));
            this.ActualInputRepositoryItem.MaxLength = 4;
            this.ActualInputRepositoryItem.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.ActualInputRepositoryItem.Name = "ActualInputRepositoryItem";
            // 
            // EffortRepositoryItem
            // 
            resources.ApplyResources(this.EffortRepositoryItem, "EffortRepositoryItem");
            this.EffortRepositoryItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.EffortRepositoryItem.DisplayFormat.FormatString = "{0:n2}";
            this.EffortRepositoryItem.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.EffortRepositoryItem.EditFormat.FormatString = "{0:n2}";
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
            this.EffortRepositoryItem.MaxLength = 4;
            this.EffortRepositoryItem.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.EffortRepositoryItem.Name = "EffortRepositoryItem";
            // 
            // OvertimeRepositoryItem
            // 
            resources.ApplyResources(this.OvertimeRepositoryItem, "OvertimeRepositoryItem");
            this.OvertimeRepositoryItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.OvertimeRepositoryItem.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("OvertimeRepositoryItem.Mask.AutoComplete")));
            this.OvertimeRepositoryItem.Mask.BeepOnError = ((bool)(resources.GetObject("OvertimeRepositoryItem.Mask.BeepOnError")));
            this.OvertimeRepositoryItem.Mask.EditMask = resources.GetString("OvertimeRepositoryItem.Mask.EditMask");
            this.OvertimeRepositoryItem.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("OvertimeRepositoryItem.Mask.IgnoreMaskBlank")));
            this.OvertimeRepositoryItem.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("OvertimeRepositoryItem.Mask.MaskType")));
            this.OvertimeRepositoryItem.Mask.PlaceHolder = ((char)(resources.GetObject("OvertimeRepositoryItem.Mask.PlaceHolder")));
            this.OvertimeRepositoryItem.Mask.SaveLiteral = ((bool)(resources.GetObject("OvertimeRepositoryItem.Mask.SaveLiteral")));
            this.OvertimeRepositoryItem.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("OvertimeRepositoryItem.Mask.ShowPlaceHolders")));
            this.OvertimeRepositoryItem.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("OvertimeRepositoryItem.Mask.UseMaskAsDisplayFormat")));
            this.OvertimeRepositoryItem.MaxLength = 4;
            this.OvertimeRepositoryItem.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.OvertimeRepositoryItem.Name = "OvertimeRepositoryItem";
            // 
            // DescriptionRepositoryItem
            // 
            resources.ApplyResources(this.DescriptionRepositoryItem, "DescriptionRepositoryItem");
            this.DescriptionRepositoryItem.Name = "DescriptionRepositoryItem";
            // 
            // entityGridControl
            // 
            resources.ApplyResources(this.entityGridControl, "entityGridControl");
            this.entityGridControl.DataSource = this.ListBindSource;
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
            this.colRecordOn,
            this.colRecordPerson,
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
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colRecordPerson, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colRecordOn
            // 
            resources.ApplyResources(this.colRecordOn, "colRecordOn");
            this.colRecordOn.ColumnEdit = this.RecordOnRepositoryItemTimeEdit;
            this.colRecordOn.FieldName = "RecordOn";
            this.colRecordOn.Name = "colRecordOn";
            this.colRecordOn.OptionsColumn.AllowEdit = false;
            // 
            // colRecordPerson
            // 
            resources.ApplyResources(this.colRecordPerson, "colRecordPerson");
            this.colRecordPerson.FieldName = "RecordPerson";
            this.colRecordPerson.Name = "colRecordPerson";
            // 
            // colActualInput
            // 
            resources.ApplyResources(this.colActualInput, "colActualInput");
            this.colActualInput.ColumnEdit = this.ActualInputRepositoryItem;
            this.colActualInput.DisplayFormat.FormatString = "{0:n2}";
            this.colActualInput.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colActualInput.FieldName = "ActualInput";
            this.colActualInput.Name = "colActualInput";
            this.colActualInput.OptionsColumn.AllowEdit = false;
            this.colActualInput.OptionsColumn.FixedWidth = true;
            this.colActualInput.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("colActualInput.Summary"))))});
            // 
            // colEffort
            // 
            resources.ApplyResources(this.colEffort, "colEffort");
            this.colEffort.ColumnEdit = this.EffortRepositoryItem;
            this.colEffort.DisplayFormat.FormatString = "{0:n2}";
            this.colEffort.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEffort.FieldName = "Effort";
            this.colEffort.Name = "colEffort";
            this.colEffort.OptionsColumn.AllowEdit = false;
            this.colEffort.OptionsColumn.FixedWidth = true;
            this.colEffort.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("colEffort.Summary"))))});
            // 
            // colOvertime
            // 
            resources.ApplyResources(this.colOvertime, "colOvertime");
            this.colOvertime.ColumnEdit = this.OvertimeRepositoryItem;
            this.colOvertime.DisplayFormat.FormatString = "{0:n2}";
            this.colOvertime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOvertime.FieldName = "Overtime";
            this.colOvertime.Name = "colOvertime";
            this.colOvertime.OptionsColumn.AllowEdit = false;
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
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.FixedWidth = true;
            // 
            // btnRemove
            // 
            resources.ApplyResources(this.btnRemove, "btnRemove");
            this.btnRemove.AutoWidthInLayoutControl = true;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.StyleController = this.EntityDataLayoutControl;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // projectTextEdit
            // 
            resources.ApplyResources(this.projectTextEdit, "projectTextEdit");
            this.projectTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ProjectName", true));
            this.projectTextEdit.Name = "projectTextEdit";
            this.projectTextEdit.Properties.AccessibleDescription = resources.GetString("projectTextEdit.Properties.AccessibleDescription");
            this.projectTextEdit.Properties.AccessibleName = resources.GetString("projectTextEdit.Properties.AccessibleName");
            this.projectTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("projectTextEdit.Properties.AutoHeight")));
            this.projectTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("projectTextEdit.Properties.Mask.AutoComplete")));
            this.projectTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("projectTextEdit.Properties.Mask.BeepOnError")));
            this.projectTextEdit.Properties.Mask.EditMask = resources.GetString("projectTextEdit.Properties.Mask.EditMask");
            this.projectTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("projectTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.projectTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("projectTextEdit.Properties.Mask.MaskType")));
            this.projectTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("projectTextEdit.Properties.Mask.PlaceHolder")));
            this.projectTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("projectTextEdit.Properties.Mask.SaveLiteral")));
            this.projectTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("projectTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.projectTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("projectTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.projectTextEdit.Properties.NullValuePrompt = resources.GetString("projectTextEdit.Properties.NullValuePrompt");
            this.projectTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("projectTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.projectTextEdit.Properties.ReadOnly = true;
            this.projectTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // taskNameTextEdit
            // 
            resources.ApplyResources(this.taskNameTextEdit, "taskNameTextEdit");
            this.taskNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Name", true));
            this.taskNameTextEdit.Name = "taskNameTextEdit";
            this.taskNameTextEdit.Properties.AccessibleDescription = resources.GetString("taskNameTextEdit.Properties.AccessibleDescription");
            this.taskNameTextEdit.Properties.AccessibleName = resources.GetString("taskNameTextEdit.Properties.AccessibleName");
            this.taskNameTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("taskNameTextEdit.Properties.AutoHeight")));
            this.taskNameTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("taskNameTextEdit.Properties.Mask.AutoComplete")));
            this.taskNameTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("taskNameTextEdit.Properties.Mask.BeepOnError")));
            this.taskNameTextEdit.Properties.Mask.EditMask = resources.GetString("taskNameTextEdit.Properties.Mask.EditMask");
            this.taskNameTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("taskNameTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.taskNameTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("taskNameTextEdit.Properties.Mask.MaskType")));
            this.taskNameTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("taskNameTextEdit.Properties.Mask.PlaceHolder")));
            this.taskNameTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("taskNameTextEdit.Properties.Mask.SaveLiteral")));
            this.taskNameTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("taskNameTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.taskNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("taskNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.taskNameTextEdit.Properties.NullValuePrompt = resources.GetString("taskNameTextEdit.Properties.NullValuePrompt");
            this.taskNameTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("taskNameTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.taskNameTextEdit.Properties.ReadOnly = true;
            this.taskNameTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // RemainderTimeTextEdit
            // 
            resources.ApplyResources(this.RemainderTimeTextEdit, "RemainderTimeTextEdit");
            this.RemainderTimeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "RemainderTime", true));
            this.RemainderTimeTextEdit.Name = "RemainderTimeTextEdit";
            this.RemainderTimeTextEdit.Properties.AccessibleDescription = resources.GetString("RemainderTimeTextEdit.Properties.AccessibleDescription");
            this.RemainderTimeTextEdit.Properties.AccessibleName = resources.GetString("RemainderTimeTextEdit.Properties.AccessibleName");
            this.RemainderTimeTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("RemainderTimeTextEdit.Properties.AutoHeight")));
            this.RemainderTimeTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("RemainderTimeTextEdit.Properties.Mask.AutoComplete")));
            this.RemainderTimeTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("RemainderTimeTextEdit.Properties.Mask.BeepOnError")));
            this.RemainderTimeTextEdit.Properties.Mask.EditMask = resources.GetString("RemainderTimeTextEdit.Properties.Mask.EditMask");
            this.RemainderTimeTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("RemainderTimeTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.RemainderTimeTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("RemainderTimeTextEdit.Properties.Mask.MaskType")));
            this.RemainderTimeTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("RemainderTimeTextEdit.Properties.Mask.PlaceHolder")));
            this.RemainderTimeTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("RemainderTimeTextEdit.Properties.Mask.SaveLiteral")));
            this.RemainderTimeTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("RemainderTimeTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.RemainderTimeTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("RemainderTimeTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.RemainderTimeTextEdit.Properties.NullValuePrompt = resources.GetString("RemainderTimeTextEdit.Properties.NullValuePrompt");
            this.RemainderTimeTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("RemainderTimeTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.RemainderTimeTextEdit.Properties.ReadOnly = true;
            this.RemainderTimeTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ActualWorkHoursTextEdit
            // 
            resources.ApplyResources(this.ActualWorkHoursTextEdit, "ActualWorkHoursTextEdit");
            this.ActualWorkHoursTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ActualWorkHours", true));
            this.ActualWorkHoursTextEdit.Name = "ActualWorkHoursTextEdit";
            this.ActualWorkHoursTextEdit.Properties.AccessibleDescription = resources.GetString("ActualWorkHoursTextEdit.Properties.AccessibleDescription");
            this.ActualWorkHoursTextEdit.Properties.AccessibleName = resources.GetString("ActualWorkHoursTextEdit.Properties.AccessibleName");
            this.ActualWorkHoursTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("ActualWorkHoursTextEdit.Properties.AutoHeight")));
            this.ActualWorkHoursTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("ActualWorkHoursTextEdit.Properties.Mask.AutoComplete")));
            this.ActualWorkHoursTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("ActualWorkHoursTextEdit.Properties.Mask.BeepOnError")));
            this.ActualWorkHoursTextEdit.Properties.Mask.EditMask = resources.GetString("ActualWorkHoursTextEdit.Properties.Mask.EditMask");
            this.ActualWorkHoursTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("ActualWorkHoursTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.ActualWorkHoursTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("ActualWorkHoursTextEdit.Properties.Mask.MaskType")));
            this.ActualWorkHoursTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("ActualWorkHoursTextEdit.Properties.Mask.PlaceHolder")));
            this.ActualWorkHoursTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("ActualWorkHoursTextEdit.Properties.Mask.SaveLiteral")));
            this.ActualWorkHoursTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("ActualWorkHoursTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.ActualWorkHoursTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("ActualWorkHoursTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.ActualWorkHoursTextEdit.Properties.NullValuePrompt = resources.GetString("ActualWorkHoursTextEdit.Properties.NullValuePrompt");
            this.ActualWorkHoursTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("ActualWorkHoursTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.ActualWorkHoursTextEdit.Properties.ReadOnly = true;
            this.ActualWorkHoursTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // iterationTextEdit
            // 
            resources.ApplyResources(this.iterationTextEdit, "iterationTextEdit");
            this.iterationTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "IterationName", true));
            this.iterationTextEdit.Name = "iterationTextEdit";
            this.iterationTextEdit.Properties.AccessibleDescription = resources.GetString("iterationTextEdit.Properties.AccessibleDescription");
            this.iterationTextEdit.Properties.AccessibleName = resources.GetString("iterationTextEdit.Properties.AccessibleName");
            this.iterationTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("iterationTextEdit.Properties.AutoHeight")));
            this.iterationTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("iterationTextEdit.Properties.Mask.AutoComplete")));
            this.iterationTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("iterationTextEdit.Properties.Mask.BeepOnError")));
            this.iterationTextEdit.Properties.Mask.EditMask = resources.GetString("iterationTextEdit.Properties.Mask.EditMask");
            this.iterationTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("iterationTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.iterationTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("iterationTextEdit.Properties.Mask.MaskType")));
            this.iterationTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("iterationTextEdit.Properties.Mask.PlaceHolder")));
            this.iterationTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("iterationTextEdit.Properties.Mask.SaveLiteral")));
            this.iterationTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("iterationTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.iterationTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("iterationTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.iterationTextEdit.Properties.NullValuePrompt = resources.GetString("iterationTextEdit.Properties.NullValuePrompt");
            this.iterationTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("iterationTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.iterationTextEdit.Properties.ReadOnly = true;
            this.iterationTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // RecordOnDateEdit
            // 
            resources.ApplyResources(this.RecordOnDateEdit, "RecordOnDateEdit");
            this.RecordOnDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "RecordOn", true));
            this.RecordOnDateEdit.Name = "RecordOnDateEdit";
            this.RecordOnDateEdit.Properties.AccessibleDescription = resources.GetString("RecordOnDateEdit.Properties.AccessibleDescription");
            this.RecordOnDateEdit.Properties.AccessibleName = resources.GetString("RecordOnDateEdit.Properties.AccessibleName");
            this.RecordOnDateEdit.Properties.AutoHeight = ((bool)(resources.GetObject("RecordOnDateEdit.Properties.AutoHeight")));
            this.RecordOnDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("RecordOnDateEdit.Properties.Buttons"))))});
            this.RecordOnDateEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("RecordOnDateEdit.Properties.Mask.AutoComplete")));
            this.RecordOnDateEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("RecordOnDateEdit.Properties.Mask.BeepOnError")));
            this.RecordOnDateEdit.Properties.Mask.EditMask = resources.GetString("RecordOnDateEdit.Properties.Mask.EditMask");
            this.RecordOnDateEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("RecordOnDateEdit.Properties.Mask.IgnoreMaskBlank")));
            this.RecordOnDateEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("RecordOnDateEdit.Properties.Mask.MaskType")));
            this.RecordOnDateEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("RecordOnDateEdit.Properties.Mask.PlaceHolder")));
            this.RecordOnDateEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("RecordOnDateEdit.Properties.Mask.SaveLiteral")));
            this.RecordOnDateEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("RecordOnDateEdit.Properties.Mask.ShowPlaceHolders")));
            this.RecordOnDateEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("RecordOnDateEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.RecordOnDateEdit.Properties.NullValuePrompt = resources.GetString("RecordOnDateEdit.Properties.NullValuePrompt");
            this.RecordOnDateEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("RecordOnDateEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.RecordOnDateEdit.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("RecordOnDateEdit.Properties.VistaTimeProperties.AccessibleDescription");
            this.RecordOnDateEdit.Properties.VistaTimeProperties.AccessibleName = resources.GetString("RecordOnDateEdit.Properties.VistaTimeProperties.AccessibleName");
            this.RecordOnDateEdit.Properties.VistaTimeProperties.AutoHeight = ((bool)(resources.GetObject("RecordOnDateEdit.Properties.VistaTimeProperties.AutoHeight")));
            this.RecordOnDateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.RecordOnDateEdit.Properties.VistaTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("RecordOnDateEdit.Properties.VistaTimeProperties.Mask.AutoComplete")));
            this.RecordOnDateEdit.Properties.VistaTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("RecordOnDateEdit.Properties.VistaTimeProperties.Mask.BeepOnError")));
            this.RecordOnDateEdit.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("RecordOnDateEdit.Properties.VistaTimeProperties.Mask.EditMask");
            this.RecordOnDateEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("RecordOnDateEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank")));
            this.RecordOnDateEdit.Properties.VistaTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("RecordOnDateEdit.Properties.VistaTimeProperties.Mask.MaskType")));
            this.RecordOnDateEdit.Properties.VistaTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("RecordOnDateEdit.Properties.VistaTimeProperties.Mask.PlaceHolder")));
            this.RecordOnDateEdit.Properties.VistaTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("RecordOnDateEdit.Properties.VistaTimeProperties.Mask.SaveLiteral")));
            this.RecordOnDateEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("RecordOnDateEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders")));
            this.RecordOnDateEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("RecordOnDateEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat")));
            this.RecordOnDateEdit.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("RecordOnDateEdit.Properties.VistaTimeProperties.NullValuePrompt");
            this.RecordOnDateEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("RecordOnDateEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue")));
            this.RecordOnDateEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnRemove;
            resources.ApplyResources(this.layoutControlItem4, "layoutControlItem4");
            this.layoutControlItem4.Location = new System.Drawing.Point(686, 336);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(79, 27);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(79, 27);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(79, 27);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // tabbedControlGroup1
            // 
            resources.ApplyResources(this.tabbedControlGroup1, "tabbedControlGroup1");
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.GeneralGroup;
            this.tabbedControlGroup1.SelectedTabPageIndex = 0;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(789, 390);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.GeneralGroup,
            this.layoutControlGroup1});
            // 
            // GeneralGroup
            // 
            resources.ApplyResources(this.GeneralGroup, "GeneralGroup");
            this.GeneralGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itemForiterationName,
            this.itemForTaskName,
            this.itemForRemainderTime,
            this.ItemForActualInput,
            this.ItemForOverTime,
            this.ItemForDescription,
            this.itemForProjectName,
            this.ItemForActualWorkHours,
            this.ItemForRecordOn,
            this.ItemForEffort});
            this.GeneralGroup.Location = new System.Drawing.Point(0, 0);
            this.GeneralGroup.Name = "GeneralGroup";
            this.GeneralGroup.Size = new System.Drawing.Size(765, 343);
            // 
            // itemForiterationName
            // 
            this.itemForiterationName.Control = this.iterationTextEdit;
            resources.ApplyResources(this.itemForiterationName, "itemForiterationName");
            this.itemForiterationName.Location = new System.Drawing.Point(382, 24);
            this.itemForiterationName.Name = "itemForiterationName";
            this.itemForiterationName.Size = new System.Drawing.Size(383, 24);
            this.itemForiterationName.TextSize = new System.Drawing.Size(60, 14);
            // 
            // itemForTaskName
            // 
            this.itemForTaskName.Control = this.taskNameTextEdit;
            resources.ApplyResources(this.itemForTaskName, "itemForTaskName");
            this.itemForTaskName.Location = new System.Drawing.Point(0, 0);
            this.itemForTaskName.Name = "itemForTaskName";
            this.itemForTaskName.Size = new System.Drawing.Size(765, 24);
            this.itemForTaskName.TextSize = new System.Drawing.Size(60, 14);
            // 
            // itemForRemainderTime
            // 
            this.itemForRemainderTime.Control = this.RemainderTimeTextEdit;
            resources.ApplyResources(this.itemForRemainderTime, "itemForRemainderTime");
            this.itemForRemainderTime.Location = new System.Drawing.Point(382, 48);
            this.itemForRemainderTime.Name = "itemForRemainderTime";
            this.itemForRemainderTime.Size = new System.Drawing.Size(383, 24);
            this.itemForRemainderTime.TextSize = new System.Drawing.Size(60, 14);
            // 
            // ItemForActualInput
            // 
            this.ItemForActualInput.Control = this.ActualInputTextEdit;
            resources.ApplyResources(this.ItemForActualInput, "ItemForActualInput");
            this.ItemForActualInput.Location = new System.Drawing.Point(382, 72);
            this.ItemForActualInput.Name = "ItemForActualInput";
            this.ItemForActualInput.Size = new System.Drawing.Size(383, 24);
            this.ItemForActualInput.TextSize = new System.Drawing.Size(60, 14);
            // 
            // ActualInputTextEdit
            // 
            resources.ApplyResources(this.ActualInputTextEdit, "ActualInputTextEdit");
            this.ActualInputTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ActualInput", true));
            this.ActualInputTextEdit.Name = "ActualInputTextEdit";
            this.ActualInputTextEdit.Properties.AccessibleDescription = resources.GetString("ActualInputTextEdit.Properties.AccessibleDescription");
            this.ActualInputTextEdit.Properties.AccessibleName = resources.GetString("ActualInputTextEdit.Properties.AccessibleName");
            this.ActualInputTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("ActualInputTextEdit.Properties.AutoHeight")));
            this.ActualInputTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ActualInputTextEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.ActualInputTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("ActualInputTextEdit.Properties.Mask.AutoComplete")));
            this.ActualInputTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("ActualInputTextEdit.Properties.Mask.BeepOnError")));
            this.ActualInputTextEdit.Properties.Mask.EditMask = resources.GetString("ActualInputTextEdit.Properties.Mask.EditMask");
            this.ActualInputTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("ActualInputTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.ActualInputTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("ActualInputTextEdit.Properties.Mask.MaskType")));
            this.ActualInputTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("ActualInputTextEdit.Properties.Mask.PlaceHolder")));
            this.ActualInputTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("ActualInputTextEdit.Properties.Mask.SaveLiteral")));
            this.ActualInputTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("ActualInputTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.ActualInputTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("ActualInputTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.ActualInputTextEdit.Properties.MaxLength = 6;
            this.ActualInputTextEdit.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.ActualInputTextEdit.Properties.NullValuePrompt = resources.GetString("ActualInputTextEdit.Properties.NullValuePrompt");
            this.ActualInputTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("ActualInputTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.ActualInputTextEdit.StyleController = this.EntityDataLayoutControl;
            this.ActualInputTextEdit.EditValueChanged += new System.EventHandler(this.RepositoryItem_EditValueChanged);
            this.ActualInputTextEdit.Click += new System.EventHandler(this.ActualInputTextEdit_Click);
            // 
            // ItemForOverTime
            // 
            this.ItemForOverTime.Control = this.OverTimeTextEdit;
            resources.ApplyResources(this.ItemForOverTime, "ItemForOverTime");
            this.ItemForOverTime.Location = new System.Drawing.Point(382, 96);
            this.ItemForOverTime.Name = "ItemForOverTime";
            this.ItemForOverTime.Size = new System.Drawing.Size(383, 24);
            this.ItemForOverTime.TextSize = new System.Drawing.Size(60, 14);
            // 
            // OverTimeTextEdit
            // 
            resources.ApplyResources(this.OverTimeTextEdit, "OverTimeTextEdit");
            this.OverTimeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "OverTime", true));
            this.OverTimeTextEdit.Name = "OverTimeTextEdit";
            this.OverTimeTextEdit.Properties.AccessibleDescription = resources.GetString("OverTimeTextEdit.Properties.AccessibleDescription");
            this.OverTimeTextEdit.Properties.AccessibleName = resources.GetString("OverTimeTextEdit.Properties.AccessibleName");
            this.OverTimeTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("OverTimeTextEdit.Properties.AutoHeight")));
            this.OverTimeTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.OverTimeTextEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.OverTimeTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("OverTimeTextEdit.Properties.Mask.AutoComplete")));
            this.OverTimeTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("OverTimeTextEdit.Properties.Mask.BeepOnError")));
            this.OverTimeTextEdit.Properties.Mask.EditMask = resources.GetString("OverTimeTextEdit.Properties.Mask.EditMask");
            this.OverTimeTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("OverTimeTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.OverTimeTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("OverTimeTextEdit.Properties.Mask.MaskType")));
            this.OverTimeTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("OverTimeTextEdit.Properties.Mask.PlaceHolder")));
            this.OverTimeTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("OverTimeTextEdit.Properties.Mask.SaveLiteral")));
            this.OverTimeTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("OverTimeTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.OverTimeTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("OverTimeTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.OverTimeTextEdit.Properties.MaxLength = 6;
            this.OverTimeTextEdit.Properties.MaxValue = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.OverTimeTextEdit.Properties.NullValuePrompt = resources.GetString("OverTimeTextEdit.Properties.NullValuePrompt");
            this.OverTimeTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("OverTimeTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.OverTimeTextEdit.StyleController = this.EntityDataLayoutControl;
            this.OverTimeTextEdit.EditValueChanged += new System.EventHandler(this.RepositoryItem_EditValueChanged);
            this.OverTimeTextEdit.Click += new System.EventHandler(this.OverTimeTextEdit_Click);
            // 
            // ItemForDescription
            // 
            this.ItemForDescription.Control = this.DescriptionMemoEdit;
            resources.ApplyResources(this.ItemForDescription, "ItemForDescription");
            this.ItemForDescription.Location = new System.Drawing.Point(0, 120);
            this.ItemForDescription.Name = "ItemForDescription";
            this.ItemForDescription.Size = new System.Drawing.Size(765, 223);
            this.ItemForDescription.TextSize = new System.Drawing.Size(60, 14);
            // 
            // DescriptionMemoEdit
            // 
            resources.ApplyResources(this.DescriptionMemoEdit, "DescriptionMemoEdit");
            this.DescriptionMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Description", true));
            this.DescriptionMemoEdit.Name = "DescriptionMemoEdit";
            this.DescriptionMemoEdit.Properties.AccessibleDescription = resources.GetString("DescriptionMemoEdit.Properties.AccessibleDescription");
            this.DescriptionMemoEdit.Properties.AccessibleName = resources.GetString("DescriptionMemoEdit.Properties.AccessibleName");
            this.DescriptionMemoEdit.Properties.NullValuePrompt = resources.GetString("DescriptionMemoEdit.Properties.NullValuePrompt");
            this.DescriptionMemoEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("DescriptionMemoEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.DescriptionMemoEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // itemForProjectName
            // 
            this.itemForProjectName.Control = this.projectTextEdit;
            resources.ApplyResources(this.itemForProjectName, "itemForProjectName");
            this.itemForProjectName.Location = new System.Drawing.Point(0, 24);
            this.itemForProjectName.Name = "itemForProjectName";
            this.itemForProjectName.Size = new System.Drawing.Size(382, 24);
            this.itemForProjectName.TextSize = new System.Drawing.Size(60, 14);
            // 
            // ItemForActualWorkHours
            // 
            this.ItemForActualWorkHours.Control = this.ActualWorkHoursTextEdit;
            resources.ApplyResources(this.ItemForActualWorkHours, "ItemForActualWorkHours");
            this.ItemForActualWorkHours.Location = new System.Drawing.Point(0, 48);
            this.ItemForActualWorkHours.Name = "ItemForActualWorkHours";
            this.ItemForActualWorkHours.Size = new System.Drawing.Size(382, 24);
            this.ItemForActualWorkHours.TextSize = new System.Drawing.Size(60, 14);
            // 
            // ItemForRecordOn
            // 
            this.ItemForRecordOn.Control = this.RecordOnDateEdit;
            resources.ApplyResources(this.ItemForRecordOn, "ItemForRecordOn");
            this.ItemForRecordOn.Location = new System.Drawing.Point(0, 72);
            this.ItemForRecordOn.Name = "ItemForRecordOn";
            this.ItemForRecordOn.Size = new System.Drawing.Size(382, 24);
            this.ItemForRecordOn.TextSize = new System.Drawing.Size(60, 14);
            // 
            // ItemForEffort
            // 
            this.ItemForEffort.Control = this.EffortTextEdit;
            resources.ApplyResources(this.ItemForEffort, "ItemForEffort");
            this.ItemForEffort.Location = new System.Drawing.Point(0, 96);
            this.ItemForEffort.Name = "ItemForEffort";
            this.ItemForEffort.Size = new System.Drawing.Size(382, 24);
            this.ItemForEffort.TextSize = new System.Drawing.Size(60, 14);
            // 
            // EffortTextEdit
            // 
            resources.ApplyResources(this.EffortTextEdit, "EffortTextEdit");
            this.EffortTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Effort", true));
            this.EffortTextEdit.Name = "EffortTextEdit";
            this.EffortTextEdit.Properties.AccessibleDescription = resources.GetString("EffortTextEdit.Properties.AccessibleDescription");
            this.EffortTextEdit.Properties.AccessibleName = resources.GetString("EffortTextEdit.Properties.AccessibleName");
            this.EffortTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("EffortTextEdit.Properties.AutoHeight")));
            this.EffortTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.EffortTextEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.EffortTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("EffortTextEdit.Properties.Mask.AutoComplete")));
            this.EffortTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("EffortTextEdit.Properties.Mask.BeepOnError")));
            this.EffortTextEdit.Properties.Mask.EditMask = resources.GetString("EffortTextEdit.Properties.Mask.EditMask");
            this.EffortTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("EffortTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.EffortTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("EffortTextEdit.Properties.Mask.MaskType")));
            this.EffortTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("EffortTextEdit.Properties.Mask.PlaceHolder")));
            this.EffortTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("EffortTextEdit.Properties.Mask.SaveLiteral")));
            this.EffortTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("EffortTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.EffortTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("EffortTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.EffortTextEdit.Properties.MaxLength = 6;
            this.EffortTextEdit.Properties.MaxValue = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.EffortTextEdit.Properties.NullValuePrompt = resources.GetString("EffortTextEdit.Properties.NullValuePrompt");
            this.EffortTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("EffortTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.EffortTextEdit.StyleController = this.EntityDataLayoutControl;
            this.EffortTextEdit.EditValueChanged += new System.EventHandler(this.RepositoryItem_EditValueChanged);
            this.EffortTextEdit.Click += new System.EventHandler(this.EffortTextEdit_Click);
            // 
            // layoutControlGroup1
            // 
            resources.ApplyResources(this.layoutControlGroup1, "layoutControlGroup1");
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(765, 343);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.entityGridControl;
            resources.ApplyResources(this.layoutControlItem2, "layoutControlItem2");
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(765, 343);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // TaskEffortDetailView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TaskEffortDetailView";
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
            ((System.ComponentModel.ISupportInitialize)(this.ListBindSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemainderTimeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActualWorkHoursTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordOnDateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordOnDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeneralGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForiterationName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForTaskName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForRemainderTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForActualInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActualInputTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOverTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverTimeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForProjectName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForActualWorkHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRecordOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEffort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffortTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraGrid.GridControl entityGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colActualInput;
        private DevExpress.XtraGrid.Columns.GridColumn colEffort;
        private DevExpress.XtraGrid.Columns.GridColumn colOvertime;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordOn;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordPerson;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraEditors.TextEdit taskNameTextEdit;
        private DevExpress.XtraEditors.TextEdit iterationTextEdit;
        private DevExpress.XtraEditors.TextEdit projectTextEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit RecordOnRepositoryItemTimeEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit ActualInputRepositoryItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit EffortRepositoryItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit OvertimeRepositoryItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit DescriptionRepositoryItem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.TextEdit RemainderTimeTextEdit;
        private DevExpress.XtraEditors.TextEdit ActualWorkHoursTextEdit;
        private System.Windows.Forms.BindingSource ListBindSource;
        private DropDownDateEdit RecordOnDateEdit;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup GeneralGroup;
        private DevExpress.XtraLayout.LayoutControlItem itemForProjectName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForActualWorkHours;
        private DevExpress.XtraLayout.LayoutControlItem itemForiterationName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRecordOn;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEffort;
        private DevExpress.XtraLayout.LayoutControlItem itemForTaskName;
        private DevExpress.XtraLayout.LayoutControlItem itemForRemainderTime;
        private DevExpress.XtraLayout.LayoutControlItem ItemForActualInput;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOverTime;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.MemoEdit DescriptionMemoEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private DevExpress.XtraEditors.SpinEdit ActualInputTextEdit;
        private DevExpress.XtraEditors.SpinEdit EffortTextEdit;
        private DevExpress.XtraEditors.SpinEdit OverTimeTextEdit;

    }
}
