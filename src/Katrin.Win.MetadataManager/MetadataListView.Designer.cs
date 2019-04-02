namespace Katrin.Win.MetadataManager
{
    partial class MetadataListView
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
            this.metadataGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIsAuditEnabled = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.entityGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metadataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // entityGridControl
            // 
            this.entityGridControl.MainView = this.metadataGridView;
            this.entityGridControl.Size = new System.Drawing.Size(460, 284);
            this.entityGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.metadataGridView});
            // 
            // metadataGridView
            // 
            this.metadataGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIsAuditEnabled,
            this.colName});
            this.metadataGridView.GridControl = this.entityGridControl;
            this.metadataGridView.Name = "metadataGridView";
            this.metadataGridView.OptionsBehavior.AllowIncrementalSearch = true;
            this.metadataGridView.OptionsBehavior.Editable = false;
            this.metadataGridView.OptionsDetail.EnableMasterViewMode = false;
            this.metadataGridView.OptionsView.ShowGroupPanel = false;
            this.metadataGridView.OptionsView.ShowIndicator = false;
            // 
            // colIsAuditEnabled
            // 
            this.colIsAuditEnabled.FieldName = "IsAuditEnabled";
            this.colIsAuditEnabled.Name = "colIsAuditEnabled";
            this.colIsAuditEnabled.Visible = true;
            this.colIsAuditEnabled.VisibleIndex = 1;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // MetadataListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "MetadataListView";
            this.Size = new System.Drawing.Size(460, 284);
            ((System.ComponentModel.ISupportInitialize)(this.entityGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metadataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView metadataGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colIsAuditEnabled;
        private DevExpress.XtraGrid.Columns.GridColumn colName;

    }
}
