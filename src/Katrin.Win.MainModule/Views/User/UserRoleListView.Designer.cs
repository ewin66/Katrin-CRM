namespace Katrin.Win.MainModule.Views.User
{
    partial class UserRoleListView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserRoleListView));
            this.roleGridControl = new DevExpress.XtraGrid.GridControl();
            this.roleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.roleGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIsSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRoleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.objectRepositoryItemCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.applyPanelControl = new DevExpress.XtraEditors.PanelControl();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.roleGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectRepositoryItemCheckEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applyPanelControl)).BeginInit();
            this.applyPanelControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // roleGridControl
            // 
            resources.ApplyResources(this.roleGridControl, "roleGridControl");
            this.roleGridControl.DataSource = this.roleBindingSource;
            this.roleGridControl.EmbeddedNavigator.AccessibleDescription = resources.GetString("roleGridControl.EmbeddedNavigator.AccessibleDescription");
            this.roleGridControl.EmbeddedNavigator.AccessibleName = resources.GetString("roleGridControl.EmbeddedNavigator.AccessibleName");
            this.roleGridControl.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("roleGridControl.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.roleGridControl.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("roleGridControl.EmbeddedNavigator.Anchor")));
            this.roleGridControl.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("roleGridControl.EmbeddedNavigator.BackgroundImage")));
            this.roleGridControl.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("roleGridControl.EmbeddedNavigator.BackgroundImageLayout")));
            this.roleGridControl.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("roleGridControl.EmbeddedNavigator.ImeMode")));
            this.roleGridControl.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("roleGridControl.EmbeddedNavigator.TextLocation")));
            this.roleGridControl.EmbeddedNavigator.ToolTip = resources.GetString("roleGridControl.EmbeddedNavigator.ToolTip");
            this.roleGridControl.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("roleGridControl.EmbeddedNavigator.ToolTipIconType")));
            this.roleGridControl.EmbeddedNavigator.ToolTipTitle = resources.GetString("roleGridControl.EmbeddedNavigator.ToolTipTitle");
            this.roleGridControl.MainView = this.roleGridView;
            this.roleGridControl.Name = "roleGridControl";
            this.roleGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.objectRepositoryItemCheckEdit});
            this.roleGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.roleGridView});
            // 
            // roleGridView
            // 
            resources.ApplyResources(this.roleGridView, "roleGridView");
            this.roleGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIsSelected,
            this.colRoleName});
            this.roleGridView.GridControl = this.roleGridControl;
            this.roleGridView.Name = "roleGridView";
            this.roleGridView.OptionsDetail.EnableMasterViewMode = false;
            this.roleGridView.OptionsLayout.LayoutVersion = "0.0.0.3";
            this.roleGridView.OptionsView.ShowGroupPanel = false;
            this.roleGridView.OptionsView.ShowIndicator = false;
            // 
            // colIsSelected
            // 
            resources.ApplyResources(this.colIsSelected, "colIsSelected");
            this.colIsSelected.FieldName = "IsSelected";
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // colRoleName
            // 
            resources.ApplyResources(this.colRoleName, "colRoleName");
            this.colRoleName.FieldName = "RoleName";
            this.colRoleName.Name = "colRoleName";
            this.colRoleName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // objectRepositoryItemCheckEdit
            // 
            resources.ApplyResources(this.objectRepositoryItemCheckEdit, "objectRepositoryItemCheckEdit");
            this.objectRepositoryItemCheckEdit.Name = "objectRepositoryItemCheckEdit";
            // 
            // applyPanelControl
            // 
            resources.ApplyResources(this.applyPanelControl, "applyPanelControl");
            this.applyPanelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.applyPanelControl.Controls.Add(this.btnOK);
            this.applyPanelControl.Controls.Add(this.btnCancel);
            this.applyPanelControl.Name = "applyPanelControl";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // UserRoleListView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.applyPanelControl);
            this.Controls.Add(this.roleGridControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "UserRoleListView";
            ((System.ComponentModel.ISupportInitialize)(this.roleGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectRepositoryItemCheckEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applyPanelControl)).EndInit();
            this.applyPanelControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl roleGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView roleGridView;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit objectRepositoryItemCheckEdit;
        private DevExpress.XtraEditors.PanelControl applyPanelControl;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.BindingSource roleBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSelected;
        private DevExpress.XtraGrid.Columns.GridColumn colRoleName;
    }
}
