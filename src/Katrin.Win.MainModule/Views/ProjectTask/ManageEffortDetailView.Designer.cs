namespace Katrin.Win.MainModule.Views.ProjectTask
{
    partial class ManageEffortDetailView
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
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageEffortDetailView));
            this.RecordOnRepositoryItemTimeEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.ActualInputRepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.EffortRepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.OvertimeRepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.DescriptionRepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.entityGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActualWorkHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemainderTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActualInput = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEffort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOvertime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).BeginInit();
            this.EntityDataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordOnRepositoryItemTimeEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordOnRepositoryItemTimeEdit.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActualInputRepositoryItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffortRepositoryItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OvertimeRepositoryItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionRepositoryItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // EntityDataLayoutControl
            // 
            this.EntityDataLayoutControl.Controls.Add(this.btnRemove);
            this.EntityDataLayoutControl.Controls.Add(this.entityGridControl);
            this.EntityDataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(190, 98, 456, 477);
            resources.ApplyResources(this.EntityDataLayoutControl, "EntityDataLayoutControl");
            // 
            // RootLayoutControlGroup
            // 
            this.RootLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem4});
            this.RootLayoutControlGroup.Name = "Root";
            this.RootLayoutControlGroup.Size = new System.Drawing.Size(948, 440);
            resources.ApplyResources(this.RootLayoutControlGroup, "RootLayoutControlGroup");
            // 
            // RecordOnRepositoryItemTimeEdit
            // 
            this.RecordOnRepositoryItemTimeEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("RecordOnRepositoryItemTimeEdit.Buttons"))))});
            this.RecordOnRepositoryItemTimeEdit.Name = "RecordOnRepositoryItemTimeEdit";
            this.RecordOnRepositoryItemTimeEdit.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // ActualInputRepositoryItem
            // 
            resources.ApplyResources(this.ActualInputRepositoryItem, "ActualInputRepositoryItem");
            this.ActualInputRepositoryItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ActualInputRepositoryItem.MaxLength = 4;
            this.ActualInputRepositoryItem.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.ActualInputRepositoryItem.Name = "ActualInputRepositoryItem";
            this.ActualInputRepositoryItem.EditValueChanged += new System.EventHandler(this.RepositoryItem_EditValueChanged);
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
            this.EffortRepositoryItem.MaxLength = 4;
            this.EffortRepositoryItem.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.EffortRepositoryItem.Name = "EffortRepositoryItem";
            this.EffortRepositoryItem.EditValueChanged += new System.EventHandler(this.RepositoryItem_EditValueChanged);
            // 
            // OvertimeRepositoryItem
            // 
            resources.ApplyResources(this.OvertimeRepositoryItem, "OvertimeRepositoryItem");
            this.OvertimeRepositoryItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.OvertimeRepositoryItem.MaxLength = 4;
            this.OvertimeRepositoryItem.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.OvertimeRepositoryItem.Name = "OvertimeRepositoryItem";
            this.OvertimeRepositoryItem.EditValueChanged += new System.EventHandler(this.RepositoryItem_EditValueChanged);
            // 
            // DescriptionRepositoryItem
            // 
            this.DescriptionRepositoryItem.Name = "DescriptionRepositoryItem";
            this.DescriptionRepositoryItem.EditValueChanged += new System.EventHandler(this.RepositoryItem_EditValueChanged);
            // 
            // entityGridControl
            // 
            this.entityGridControl.DataSource = this.EntityBindingSource;
            resources.ApplyResources(this.entityGridControl, "entityGridControl");
            this.entityGridControl.MainView = this.gridView1;
            this.entityGridControl.Name = "entityGridControl";
            this.entityGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colProjectId,
            this.colActualWorkHours,
            this.colRemainderTime,
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
            this.gridView1.GroupCount = 2;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colProjectId, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colRecordPerson, DevExpress.Data.ColumnSortOrder.Ascending)});
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
            // colActualWorkHours
            // 
            this.colActualWorkHours.FieldName = "ActualWorkHours";
            this.colActualWorkHours.Name = "colActualWorkHours";
            this.colActualWorkHours.OptionsColumn.AllowEdit = false;
            this.colActualWorkHours.OptionsColumn.FixedWidth = true;
            this.colActualWorkHours.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("colActualWorkHours.Summary"))))});
            resources.ApplyResources(this.colActualWorkHours, "colActualWorkHours");
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
            this.colRecordOn.ColumnEdit = this.RecordOnRepositoryItemTimeEdit;
            this.colRecordOn.FieldName = "RecordOn";
            this.colRecordOn.Name = "colRecordOn";
            resources.ApplyResources(this.colRecordOn, "colRecordOn");
            // 
            // colRecordPerson
            // 
            resources.ApplyResources(this.colRecordPerson, "colRecordPerson");
            this.colRecordPerson.FieldName = "RecordPerson";
            this.colRecordPerson.Name = "colRecordPerson";
            this.colRecordPerson.OptionsColumn.AllowEdit = false;
            // 
            // colActualInput
            // 
            this.colActualInput.ColumnEdit = this.ActualInputRepositoryItem;
            this.colActualInput.DisplayFormat.FormatString = "{0:n2}";
            this.colActualInput.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colActualInput.FieldName = "ActualInput";
            this.colActualInput.Name = "colActualInput";
            this.colActualInput.OptionsColumn.FixedWidth = true;
            this.colActualInput.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("colActualInput.Summary"))))});
            resources.ApplyResources(this.colActualInput, "colActualInput");
            // 
            // colEffort
            // 
            this.colEffort.ColumnEdit = this.EffortRepositoryItem;
            this.colEffort.DisplayFormat.FormatString = "{0:n2}";
            this.colEffort.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEffort.FieldName = "Effort";
            this.colEffort.Name = "colEffort";
            this.colEffort.OptionsColumn.FixedWidth = true;
            this.colEffort.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("colEffort.Summary"))))});
            resources.ApplyResources(this.colEffort, "colEffort");
            // 
            // colOvertime
            // 
            this.colOvertime.ColumnEdit = this.OvertimeRepositoryItem;
            this.colOvertime.DisplayFormat.FormatString = "{0:n2}";
            this.colOvertime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOvertime.FieldName = "Overtime";
            this.colOvertime.Name = "colOvertime";
            this.colOvertime.OptionsColumn.FixedWidth = true;
            this.colOvertime.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("colOvertime.Summary"))))});
            resources.ApplyResources(this.colOvertime, "colOvertime");
            // 
            // colDescription
            // 
            resources.ApplyResources(this.colDescription, "colDescription");
            this.colDescription.ColumnEdit = this.DescriptionRepositoryItem;
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.FixedWidth = true;
            // 
            // btnRemove
            // 
            this.btnRemove.AutoWidthInLayoutControl = true;
            resources.ApplyResources(this.btnRemove, "btnRemove");
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.StyleController = this.EntityDataLayoutControl;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.entityGridControl;
            resources.ApplyResources(this.layoutControlItem2, "layoutControlItem2");
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(928, 393);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnRemove;
            resources.ApplyResources(this.layoutControlItem4, "layoutControlItem4");
            this.layoutControlItem4.Location = new System.Drawing.Point(849, 393);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(79, 27);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(79, 27);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(79, 27);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem1, "emptySpaceItem1");
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 393);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(849, 27);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ManageEffortDetailView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ManageEffortDetailView";
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).EndInit();
            this.EntityDataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordOnRepositoryItemTimeEdit.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordOnRepositoryItemTimeEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActualInputRepositoryItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffortRepositoryItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OvertimeRepositoryItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionRepositoryItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn colRecordPerson;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit RecordOnRepositoryItemTimeEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit ActualInputRepositoryItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit EffortRepositoryItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit OvertimeRepositoryItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit DescriptionRepositoryItem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;

    }
}
