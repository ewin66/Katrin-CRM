namespace Katrin.Win.MainModule.Views.Role
{
    partial class RoleDetailView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoleDetailView));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.RoleNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.lcgGeneral = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.menuItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.MenuGridControl = new DevExpress.XtraGrid.GridControl();
            this.roleMenuActionsBindingSource = new System.Windows.Forms.BindingSource();
            this.menuGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.actionItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.actionGridControl = new DevExpress.XtraGrid.GridControl();
            this.actionBindingSource = new System.Windows.Forms.BindingSource();
            this.gridActionView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPrivilegeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.DescriptionTextEdit = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).BeginInit();
            this.EntityDataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoleNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleMenuActionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridActionView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // EntityDataLayoutControl
            // 
            resources.ApplyResources(this.EntityDataLayoutControl, "EntityDataLayoutControl");
            this.EntityDataLayoutControl.Controls.Add(this.actionGridControl);
            this.EntityDataLayoutControl.Controls.Add(this.RoleNameTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.MenuGridControl);
            this.EntityDataLayoutControl.Controls.Add(this.DescriptionTextEdit);
            this.EntityDataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(166, 250, 250, 350);
            // 
            // RootLayoutControlGroup
            // 
            resources.ApplyResources(this.RootLayoutControlGroup, "RootLayoutControlGroup");
            this.RootLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgGeneral});
            this.RootLayoutControlGroup.Name = "Root";
            this.RootLayoutControlGroup.OptionsToolTip.ToolTip = resources.GetString("resource.ToolTip");
            this.RootLayoutControlGroup.OptionsToolTip.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("resource.ToolTipIconType")));
            this.RootLayoutControlGroup.OptionsToolTip.ToolTipTitle = resources.GetString("resource.ToolTipTitle");
            this.RootLayoutControlGroup.Size = new System.Drawing.Size(858, 406);
            // 
            // RoleNameTextEdit
            // 
            resources.ApplyResources(this.RoleNameTextEdit, "RoleNameTextEdit");
            this.RoleNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "RoleName", true));
            this.RoleNameTextEdit.Name = "RoleNameTextEdit";
            this.RoleNameTextEdit.Properties.AccessibleDescription = resources.GetString("RoleNameTextEdit.Properties.AccessibleDescription");
            this.RoleNameTextEdit.Properties.AccessibleName = resources.GetString("RoleNameTextEdit.Properties.AccessibleName");
            this.RoleNameTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("RoleNameTextEdit.Properties.AutoHeight")));
            this.RoleNameTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("RoleNameTextEdit.Properties.Mask.AutoComplete")));
            this.RoleNameTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("RoleNameTextEdit.Properties.Mask.BeepOnError")));
            this.RoleNameTextEdit.Properties.Mask.EditMask = resources.GetString("RoleNameTextEdit.Properties.Mask.EditMask");
            this.RoleNameTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("RoleNameTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.RoleNameTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("RoleNameTextEdit.Properties.Mask.MaskType")));
            this.RoleNameTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("RoleNameTextEdit.Properties.Mask.PlaceHolder")));
            this.RoleNameTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("RoleNameTextEdit.Properties.Mask.SaveLiteral")));
            this.RoleNameTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("RoleNameTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.RoleNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("RoleNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.RoleNameTextEdit.Properties.NullValuePrompt = resources.GetString("RoleNameTextEdit.Properties.NullValuePrompt");
            this.RoleNameTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("RoleNameTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.RoleNameTextEdit.StyleController = this.EntityDataLayoutControl;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.ValidationProvider.SetValidationRule(this.RoleNameTextEdit, conditionValidationRule1);
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.AllowDrawBackground = false;
            resources.ApplyResources(this.lcgGeneral, "lcgGeneral");
            this.lcgGeneral.ExpandButtonVisible = true;
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForUserName,
            this.menuItem,
            this.actionItem,
            this.ItemDescription});
            this.lcgGeneral.Location = new System.Drawing.Point(0, 0);
            this.lcgGeneral.Name = "lcgGeneral";
            this.lcgGeneral.Size = new System.Drawing.Size(838, 386);
            // 
            // ItemForUserName
            // 
            this.ItemForUserName.Control = this.RoleNameTextEdit;
            resources.ApplyResources(this.ItemForUserName, "ItemForUserName");
            this.ItemForUserName.Location = new System.Drawing.Point(0, 0);
            this.ItemForUserName.Name = "ItemForRoleName";
            this.ItemForUserName.Size = new System.Drawing.Size(814, 24);
            this.ItemForUserName.TextSize = new System.Drawing.Size(60, 14);
            // 
            // menuItem
            // 
            this.menuItem.Control = this.MenuGridControl;
            resources.ApplyResources(this.menuItem, "menuItem");
            this.menuItem.Location = new System.Drawing.Point(0, 95);
            this.menuItem.Name = "menuItem";
            this.menuItem.Size = new System.Drawing.Size(814, 123);
            this.menuItem.TextSize = new System.Drawing.Size(60, 14);
            // 
            // MenuGridControl
            // 
            resources.ApplyResources(this.MenuGridControl, "MenuGridControl");
            this.MenuGridControl.DataSource = this.roleMenuActionsBindingSource;
            this.MenuGridControl.EmbeddedNavigator.AccessibleDescription = resources.GetString("MenuGridControl.EmbeddedNavigator.AccessibleDescription");
            this.MenuGridControl.EmbeddedNavigator.AccessibleName = resources.GetString("MenuGridControl.EmbeddedNavigator.AccessibleName");
            this.MenuGridControl.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("MenuGridControl.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.MenuGridControl.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("MenuGridControl.EmbeddedNavigator.Anchor")));
            this.MenuGridControl.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MenuGridControl.EmbeddedNavigator.BackgroundImage")));
            this.MenuGridControl.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("MenuGridControl.EmbeddedNavigator.BackgroundImageLayout")));
            this.MenuGridControl.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("MenuGridControl.EmbeddedNavigator.ImeMode")));
            this.MenuGridControl.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("MenuGridControl.EmbeddedNavigator.TextLocation")));
            this.MenuGridControl.EmbeddedNavigator.ToolTip = resources.GetString("MenuGridControl.EmbeddedNavigator.ToolTip");
            this.MenuGridControl.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("MenuGridControl.EmbeddedNavigator.ToolTipIconType")));
            this.MenuGridControl.EmbeddedNavigator.ToolTipTitle = resources.GetString("MenuGridControl.EmbeddedNavigator.ToolTipTitle");
            this.MenuGridControl.MainView = this.menuGridView;
            this.MenuGridControl.Name = "MenuGridControl";
            this.MenuGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.menuGridView});
            // 
            // roleMenuActionsBindingSource
            // 
            this.roleMenuActionsBindingSource.DataSource = this.EntityBindingSource;
            // 
            // menuGridView
            // 
            resources.ApplyResources(this.menuGridView, "menuGridView");
            this.menuGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName});
            this.menuGridView.GridControl = this.MenuGridControl;
            this.menuGridView.Name = "menuGridView";
            this.menuGridView.OptionsDetail.EnableMasterViewMode = false;
            this.menuGridView.OptionsView.ShowGroupPanel = false;
            // 
            // colName
            // 
            resources.ApplyResources(this.colName, "colName");
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // actionItem
            // 
            this.actionItem.Control = this.actionGridControl;
            resources.ApplyResources(this.actionItem, "actionItem");
            this.actionItem.Location = new System.Drawing.Point(0, 218);
            this.actionItem.Name = "actionItem";
            this.actionItem.Size = new System.Drawing.Size(814, 124);
            this.actionItem.TextSize = new System.Drawing.Size(60, 14);
            // 
            // actionGridControl
            // 
            resources.ApplyResources(this.actionGridControl, "actionGridControl");
            this.actionGridControl.DataSource = this.actionBindingSource;
            this.actionGridControl.EmbeddedNavigator.AccessibleDescription = resources.GetString("actionGridControl.EmbeddedNavigator.AccessibleDescription");
            this.actionGridControl.EmbeddedNavigator.AccessibleName = resources.GetString("actionGridControl.EmbeddedNavigator.AccessibleName");
            this.actionGridControl.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("actionGridControl.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.actionGridControl.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("actionGridControl.EmbeddedNavigator.Anchor")));
            this.actionGridControl.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("actionGridControl.EmbeddedNavigator.BackgroundImage")));
            this.actionGridControl.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("actionGridControl.EmbeddedNavigator.BackgroundImageLayout")));
            this.actionGridControl.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("actionGridControl.EmbeddedNavigator.ImeMode")));
            this.actionGridControl.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("actionGridControl.EmbeddedNavigator.TextLocation")));
            this.actionGridControl.EmbeddedNavigator.ToolTip = resources.GetString("actionGridControl.EmbeddedNavigator.ToolTip");
            this.actionGridControl.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("actionGridControl.EmbeddedNavigator.ToolTipIconType")));
            this.actionGridControl.EmbeddedNavigator.ToolTipTitle = resources.GetString("actionGridControl.EmbeddedNavigator.ToolTipTitle");
            this.actionGridControl.MainView = this.gridActionView;
            this.actionGridControl.Name = "actionGridControl";
            this.actionGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridActionView});
            // 
            // actionBindingSource
            // 
            this.actionBindingSource.DataSource = this.roleMenuActionsBindingSource;
            // 
            // gridActionView
            // 
            resources.ApplyResources(this.gridActionView, "gridActionView");
            this.gridActionView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPrivilegeName,
            this.colSelected});
            this.gridActionView.GridControl = this.actionGridControl;
            this.gridActionView.Name = "gridActionView";
            this.gridActionView.OptionsView.ShowGroupPanel = false;
            // 
            // colPrivilegeName
            // 
            resources.ApplyResources(this.colPrivilegeName, "colPrivilegeName");
            this.colPrivilegeName.FieldName = "PrivilegeName";
            this.colPrivilegeName.Name = "colPrivilegeName";
            this.colPrivilegeName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // colSelected
            // 
            resources.ApplyResources(this.colSelected, "colSelected");
            this.colSelected.FieldName = "Selected";
            this.colSelected.Name = "colSelected";
            this.colSelected.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // ItemDescription
            // 
            this.ItemDescription.Control = this.DescriptionTextEdit;
            resources.ApplyResources(this.ItemDescription, "ItemDescription");
            this.ItemDescription.Location = new System.Drawing.Point(0, 24);
            this.ItemDescription.Name = "ItemDescription";
            this.ItemDescription.Size = new System.Drawing.Size(814, 71);
            this.ItemDescription.TextSize = new System.Drawing.Size(60, 14);
            // 
            // DescriptionTextEdit
            // 
            resources.ApplyResources(this.DescriptionTextEdit, "DescriptionTextEdit");
            this.DescriptionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Description", true));
            this.DescriptionTextEdit.Name = "DescriptionTextEdit";
            this.DescriptionTextEdit.Properties.AccessibleDescription = resources.GetString("DescriptionTextEdit.Properties.AccessibleDescription");
            this.DescriptionTextEdit.Properties.AccessibleName = resources.GetString("DescriptionTextEdit.Properties.AccessibleName");
            this.DescriptionTextEdit.Properties.NullValuePrompt = resources.GetString("DescriptionTextEdit.Properties.NullValuePrompt");
            this.DescriptionTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("DescriptionTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.DescriptionTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // RoleDetailView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "RoleDetailView";
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).EndInit();
            this.EntityDataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoleNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleMenuActionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridActionView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit RoleNameTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup lcgGeneral;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUserName;
        private DevExpress.XtraEditors.MemoEdit DescriptionTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemDescription;
        private DevExpress.XtraGrid.GridControl actionGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridActionView;
        private DevExpress.XtraGrid.GridControl MenuGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView menuGridView;
        private DevExpress.XtraLayout.LayoutControlItem menuItem;
        private DevExpress.XtraLayout.LayoutControlItem actionItem;
        private System.Windows.Forms.BindingSource roleMenuActionsBindingSource;
        private System.Windows.Forms.BindingSource actionBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colPrivilegeName;
        private DevExpress.XtraGrid.Columns.GridColumn colSelected;
        private DevExpress.XtraGrid.Columns.GridColumn colName;      
    }
}
