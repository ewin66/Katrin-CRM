namespace Katrin.Win.MainModule.Views.SystemSetting
{
    partial class ConfigurationList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationList));
            this.configurationGridControl = new DevExpress.XtraGrid.GridControl();
            this.configurationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.configurationConditionGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.activeRepositoryItemCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.applyPanelControl = new DevExpress.XtraEditors.PanelControl();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configurationGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configurationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configurationConditionGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeRepositoryItemCheckEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applyPanelControl)).BeginInit();
            this.applyPanelControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // EntityDataLayoutControl
            // 
            resources.ApplyResources(this.EntityDataLayoutControl, "EntityDataLayoutControl");
            this.EntityDataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(429, 29, 250, 350);
            // 
            // RootLayoutControlGroup
            // 
            resources.ApplyResources(this.RootLayoutControlGroup, "RootLayoutControlGroup");
            this.RootLayoutControlGroup.OptionsToolTip.ToolTip = resources.GetString("resource.ToolTip");
            this.RootLayoutControlGroup.OptionsToolTip.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("resource.ToolTipIconType")));
            this.RootLayoutControlGroup.OptionsToolTip.ToolTipTitle = resources.GetString("resource.ToolTipTitle");
            this.RootLayoutControlGroup.Size = new System.Drawing.Size(539, 20);
            // 
            // configurationGridControl
            // 
            resources.ApplyResources(this.configurationGridControl, "configurationGridControl");
            this.configurationGridControl.DataSource = this.configurationBindingSource;
            this.configurationGridControl.EmbeddedNavigator.AccessibleDescription = resources.GetString("configurationGridControl.EmbeddedNavigator.AccessibleDescription");
            this.configurationGridControl.EmbeddedNavigator.AccessibleName = resources.GetString("configurationGridControl.EmbeddedNavigator.AccessibleName");
            this.configurationGridControl.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("configurationGridControl.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.configurationGridControl.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("configurationGridControl.EmbeddedNavigator.Anchor")));
            this.configurationGridControl.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("configurationGridControl.EmbeddedNavigator.BackgroundImage")));
            this.configurationGridControl.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("configurationGridControl.EmbeddedNavigator.BackgroundImageLayout")));
            this.configurationGridControl.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("configurationGridControl.EmbeddedNavigator.ImeMode")));
            this.configurationGridControl.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("configurationGridControl.EmbeddedNavigator.TextLocation")));
            this.configurationGridControl.EmbeddedNavigator.ToolTip = resources.GetString("configurationGridControl.EmbeddedNavigator.ToolTip");
            this.configurationGridControl.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("configurationGridControl.EmbeddedNavigator.ToolTipIconType")));
            this.configurationGridControl.EmbeddedNavigator.ToolTipTitle = resources.GetString("configurationGridControl.EmbeddedNavigator.ToolTipTitle");
            this.configurationGridControl.MainView = this.configurationConditionGrid;
            this.configurationGridControl.Name = "configurationGridControl";
            this.configurationGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.activeRepositoryItemCheckEdit});
            this.configurationGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.configurationConditionGrid});
            // 
            // configurationConditionGrid
            // 
            resources.ApplyResources(this.configurationConditionGrid, "configurationConditionGrid");
            this.configurationConditionGrid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColName,
            this.ColValue});
            this.configurationConditionGrid.GridControl = this.configurationGridControl;
            this.configurationConditionGrid.Name = "configurationConditionGrid";
            this.configurationConditionGrid.OptionsLayout.LayoutVersion = "0.0.0.1";
            this.configurationConditionGrid.OptionsView.ShowGroupPanel = false;
            this.configurationConditionGrid.OptionsView.ShowIndicator = false;
            // 
            // ColName
            // 
            resources.ApplyResources(this.ColName, "ColName");
            this.ColName.FieldName = "Name";
            this.ColName.Name = "ColName";
            this.ColName.OptionsColumn.AllowEdit = false;
            this.ColName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // ColValue
            // 
            resources.ApplyResources(this.ColValue, "ColValue");
            this.ColValue.FieldName = "Value";
            this.ColValue.Name = "ColValue";
            this.ColValue.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // activeRepositoryItemCheckEdit
            // 
            resources.ApplyResources(this.activeRepositoryItemCheckEdit, "activeRepositoryItemCheckEdit");
            this.activeRepositoryItemCheckEdit.Name = "activeRepositoryItemCheckEdit";
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
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ConfigurationList
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.applyPanelControl);
            this.Controls.Add(this.configurationGridControl);
            this.Name = "ConfigurationList";
            this.Controls.SetChildIndex(this.configurationGridControl, 0);
            this.Controls.SetChildIndex(this.applyPanelControl, 0);
            this.Controls.SetChildIndex(this.EntityDataLayoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configurationGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configurationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configurationConditionGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeRepositoryItemCheckEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applyPanelControl)).EndInit();
            this.applyPanelControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl configurationGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView configurationConditionGrid;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit activeRepositoryItemCheckEdit;
        private DevExpress.XtraGrid.Columns.GridColumn ColName;
        private DevExpress.XtraGrid.Columns.GridColumn ColValue;
        private DevExpress.XtraEditors.PanelControl applyPanelControl;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.BindingSource configurationBindingSource;
    }
}
