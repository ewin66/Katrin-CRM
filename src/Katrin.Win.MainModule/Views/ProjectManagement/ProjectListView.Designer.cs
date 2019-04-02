namespace Katrin.Win.MainModule.Views.ProjectManagement
{
    partial class ProjectListView
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
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlannedStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlannedEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlannedProgress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActualStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActualEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActualProgress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManagerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstimatedEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.entityGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // entityGridControl
            // 
            this.entityGridControl.MainView = this.gridView1;
            this.entityGridControl.Size = new System.Drawing.Size(499, 265);
            this.entityGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colPlannedStartDate,
            this.colPlannedEndDate,
            this.colPlannedProgress,
            this.colActualStartDate,
            this.colActualEndDate,
            this.colActualProgress,
            this.colManagerId,
            this.colStatusCode,
            this.colEstimatedEndDate});
            this.gridView1.GridControl = this.entityGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 274;
            // 
            // colPlannedStartDate
            // 
            this.colPlannedStartDate.FieldName = "PlannedStartDate";
            this.colPlannedStartDate.Name = "colPlannedStartDate";
            this.colPlannedStartDate.Visible = true;
            this.colPlannedStartDate.VisibleIndex = 4;
            this.colPlannedStartDate.Width = 124;
            // 
            // colPlannedEndDate
            // 
            this.colPlannedEndDate.FieldName = "PlannedEndDate";
            this.colPlannedEndDate.Name = "colPlannedEndDate";
            this.colPlannedEndDate.Visible = true;
            this.colPlannedEndDate.VisibleIndex = 6;
            this.colPlannedEndDate.Width = 107;
            // 
            // colPlannedProgress
            // 
            this.colPlannedProgress.FieldName = "PlannedProgress";
            this.colPlannedProgress.Name = "colPlannedProgress";
            this.colPlannedProgress.Visible = true;
            this.colPlannedProgress.VisibleIndex = 2;
            this.colPlannedProgress.Width = 98;
            // 
            // colActualStartDate
            // 
            this.colActualStartDate.FieldName = "ActualStartDate";
            this.colActualStartDate.Name = "colActualStartDate";
            this.colActualStartDate.Visible = true;
            this.colActualStartDate.VisibleIndex = 5;
            this.colActualStartDate.Width = 105;
            // 
            // colActualEndDate
            // 
            this.colActualEndDate.FieldName = "ActualEndDate";
            this.colActualEndDate.Name = "colActualEndDate";
            this.colActualEndDate.Visible = true;
            this.colActualEndDate.VisibleIndex = 8;
            this.colActualEndDate.Width = 102;
            // 
            // colActualProgress
            // 
            this.colActualProgress.FieldName = "ActualProgress";
            this.colActualProgress.Name = "colActualProgress";
            this.colActualProgress.Visible = true;
            this.colActualProgress.VisibleIndex = 3;
            this.colActualProgress.Width = 81;
            // 
            // colManagerId
            // 
            this.colManagerId.Caption = "ManagerId";
            this.colManagerId.FieldName = "ManagerName";
            this.colManagerId.Name = "colManagerId";
            this.colManagerId.Visible = true;
            this.colManagerId.VisibleIndex = 9;
            this.colManagerId.Width = 100;
            // 
            // colStatusCode
            // 
            this.colStatusCode.FieldName = "StatusCode";
            this.colStatusCode.Name = "colStatusCode";
            this.colStatusCode.Visible = true;
            this.colStatusCode.VisibleIndex = 1;
            this.colStatusCode.Width = 74;
            // 
            // colEstimatedEndDate
            // 
            this.colEstimatedEndDate.FieldName = "EstimatedEndDate";
            this.colEstimatedEndDate.Name = "colEstimatedEndDate";
            this.colEstimatedEndDate.Visible = true;
            this.colEstimatedEndDate.VisibleIndex = 7;
            this.colEstimatedEndDate.Width = 99;
            // 
            // ProjectListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ProjectListView";
            this.Size = new System.Drawing.Size(499, 265);
            ((System.ComponentModel.ISupportInitialize)(this.entityGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPlannedStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPlannedEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPlannedProgress;
        private DevExpress.XtraGrid.Columns.GridColumn colActualStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colActualEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn colActualProgress;
        private DevExpress.XtraGrid.Columns.GridColumn colManagerId;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusCode;
        private DevExpress.XtraGrid.Columns.GridColumn colEstimatedEndDate;
    }
}
