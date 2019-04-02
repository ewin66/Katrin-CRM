namespace Katrin.Win.NotificationModule
{
    partial class FilterControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterControl));
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colFilters = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colImageIndex = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.colNodeName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            resources.ApplyResources(this.treeList1, "treeList1");
            this.treeList1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName,
            this.colFilters,
            this.colNodeName,
            this.colImageIndex});
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsView.ShowColumns = false;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowIndentAsRowStyle = true;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            // 
            // colName
            // 
            resources.ApplyResources(this.colName, "colName");
            this.colName.ColumnEdit = this.repositoryItemButtonEdit1;
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowFocus = false;
            // 
            // repositoryItemButtonEdit1
            // 
            resources.ApplyResources(this.repositoryItemButtonEdit1, "repositoryItemButtonEdit1");
            this.repositoryItemButtonEdit1.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.repositoryItemButtonEdit1.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("repositoryItemButtonEdit1.Mask.AutoComplete")));
            this.repositoryItemButtonEdit1.Mask.BeepOnError = ((bool)(resources.GetObject("repositoryItemButtonEdit1.Mask.BeepOnError")));
            this.repositoryItemButtonEdit1.Mask.EditMask = resources.GetString("repositoryItemButtonEdit1.Mask.EditMask");
            this.repositoryItemButtonEdit1.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("repositoryItemButtonEdit1.Mask.IgnoreMaskBlank")));
            this.repositoryItemButtonEdit1.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("repositoryItemButtonEdit1.Mask.MaskType")));
            this.repositoryItemButtonEdit1.Mask.PlaceHolder = ((char)(resources.GetObject("repositoryItemButtonEdit1.Mask.PlaceHolder")));
            this.repositoryItemButtonEdit1.Mask.SaveLiteral = ((bool)(resources.GetObject("repositoryItemButtonEdit1.Mask.SaveLiteral")));
            this.repositoryItemButtonEdit1.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("repositoryItemButtonEdit1.Mask.ShowPlaceHolders")));
            this.repositoryItemButtonEdit1.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("repositoryItemButtonEdit1.Mask.UseMaskAsDisplayFormat")));
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // colFilters
            // 
            resources.ApplyResources(this.colFilters, "colFilters");
            this.colFilters.FieldName = "Filters";
            this.colFilters.Name = "colFilters";
            // 
            // colImageIndex
            // 
            resources.ApplyResources(this.colImageIndex, "colImageIndex");
            this.colImageIndex.FieldName = "ImageIndex";
            this.colImageIndex.Name = "colImageIndex";
            // 
            // groupControl1
            // 
            resources.ApplyResources(this.groupControl1, "groupControl1");
            this.groupControl1.Controls.Add(this.treeList1);
            this.groupControl1.Name = "groupControl1";
            // 
            // colNodeName
            // 
            resources.ApplyResources(this.colNodeName, "colNodeName");
            this.colNodeName.FieldName = "NodeName";
            this.colNodeName.Name = "colNodeName";
            // 
            // FilterControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "FilterControl";
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFilters;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colImageIndex;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNodeName;
    }
}
