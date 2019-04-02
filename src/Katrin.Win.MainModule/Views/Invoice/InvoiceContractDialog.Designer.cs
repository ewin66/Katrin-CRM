namespace Katrin.Win.MainModule.Views.Invoice
{
    partial class InvoiceContractDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceContractDialog));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.EntityGridControl = new DevExpress.XtraGrid.GridControl();
            this.entityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EntityGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colContractNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpiresOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOpportunityId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOwnerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkpStatusCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActiveOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillingCustomerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SelectedRepositoryItemCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.lkpOwnerId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lkpOpportunityId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.DepartmentRepositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.CustomerRepositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EntityGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedRepositoryItemCheckEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpOwnerId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpOpportunityId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentRepositoryItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerRepositoryItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            resources.ApplyResources(this.layoutControl1, "layoutControl1");
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Controls.Add(this.EntityGridControl);
            this.layoutControl1.Controls.Add(this.layoutControl2);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnOK);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(534, 211, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            // 
            // EntityGridControl
            // 
            resources.ApplyResources(this.EntityGridControl, "EntityGridControl");
            this.EntityGridControl.DataSource = this.entityBindingSource;
            this.EntityGridControl.EmbeddedNavigator.AccessibleDescription = resources.GetString("EntityGridControl.EmbeddedNavigator.AccessibleDescription");
            this.EntityGridControl.EmbeddedNavigator.AccessibleName = resources.GetString("EntityGridControl.EmbeddedNavigator.AccessibleName");
            this.EntityGridControl.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("EntityGridControl.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.EntityGridControl.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("EntityGridControl.EmbeddedNavigator.Anchor")));
            this.EntityGridControl.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EntityGridControl.EmbeddedNavigator.BackgroundImage")));
            this.EntityGridControl.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("EntityGridControl.EmbeddedNavigator.BackgroundImageLayout")));
            this.EntityGridControl.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("EntityGridControl.EmbeddedNavigator.ImeMode")));
            this.EntityGridControl.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("EntityGridControl.EmbeddedNavigator.TextLocation")));
            this.EntityGridControl.EmbeddedNavigator.ToolTip = resources.GetString("EntityGridControl.EmbeddedNavigator.ToolTip");
            this.EntityGridControl.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("EntityGridControl.EmbeddedNavigator.ToolTipIconType")));
            this.EntityGridControl.EmbeddedNavigator.ToolTipTitle = resources.GetString("EntityGridControl.EmbeddedNavigator.ToolTipTitle");
            this.EntityGridControl.MainView = this.EntityGridView;
            this.EntityGridControl.Name = "EntityGridControl";
            this.EntityGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lkpOwnerId,
            this.lkpOpportunityId,
            this.lkpStatusCode,
            this.DepartmentRepositoryItemLookUpEdit,
            this.CustomerRepositoryItemLookUpEdit,
            this.SelectedRepositoryItemCheckEdit});
            this.EntityGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.EntityGridView});
            // 
            // EntityGridView
            // 
            resources.ApplyResources(this.EntityGridView, "EntityGridView");
            this.EntityGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colContractNumber,
            this.colDescription,
            this.colExpiresOn,
            this.colOpportunityId,
            this.colOwnerId,
            this.colStatusCode,
            this.colTitle,
            this.colTotalPrice,
            this.colDepartmentId,
            this.colActiveOn,
            this.colBillingCustomerId,
            this.colSelected});
            this.EntityGridView.GridControl = this.EntityGridControl;
            this.EntityGridView.Name = "EntityGridView";
            this.EntityGridView.OptionsDetail.EnableMasterViewMode = false;
            this.EntityGridView.OptionsView.ShowGroupPanel = false;
            this.EntityGridView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.EntityGridView_CustomUnboundColumnData);
            // 
            // colContractNumber
            // 
            resources.ApplyResources(this.colContractNumber, "colContractNumber");
            this.colContractNumber.FieldName = "ContractNumber";
            this.colContractNumber.Name = "colContractNumber";
            this.colContractNumber.OptionsColumn.AllowEdit = false;
            this.colContractNumber.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // colDescription
            // 
            resources.ApplyResources(this.colDescription, "colDescription");
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // colExpiresOn
            // 
            resources.ApplyResources(this.colExpiresOn, "colExpiresOn");
            this.colExpiresOn.FieldName = "ExpiresOn";
            this.colExpiresOn.Name = "colExpiresOn";
            this.colExpiresOn.OptionsColumn.AllowEdit = false;
            this.colExpiresOn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // colOpportunityId
            // 
            resources.ApplyResources(this.colOpportunityId, "colOpportunityId");
            this.colOpportunityId.FieldName = "OpportunityName";
            this.colOpportunityId.Name = "colOpportunityId";
            this.colOpportunityId.OptionsColumn.AllowEdit = false;
            this.colOpportunityId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // colOwnerId
            // 
            resources.ApplyResources(this.colOwnerId, "colOwnerId");
            this.colOwnerId.FieldName = "OwnerName";
            this.colOwnerId.Name = "colOwnerId";
            this.colOwnerId.OptionsColumn.AllowEdit = false;
            this.colOwnerId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // colStatusCode
            // 
            resources.ApplyResources(this.colStatusCode, "colStatusCode");
            this.colStatusCode.ColumnEdit = this.lkpStatusCode;
            this.colStatusCode.FieldName = "StatusCode";
            this.colStatusCode.Name = "colStatusCode";
            this.colStatusCode.OptionsColumn.AllowEdit = false;
            this.colStatusCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // lkpStatusCode
            // 
            resources.ApplyResources(this.lkpStatusCode, "lkpStatusCode");
            this.lkpStatusCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("lkpStatusCode.Buttons"))))});
            this.lkpStatusCode.Name = "lkpStatusCode";
            // 
            // colTitle
            // 
            resources.ApplyResources(this.colTitle, "colTitle");
            this.colTitle.FieldName = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.OptionsColumn.AllowEdit = false;
            this.colTitle.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // colTotalPrice
            // 
            resources.ApplyResources(this.colTotalPrice, "colTotalPrice");
            this.colTotalPrice.FieldName = "TotalPrice";
            this.colTotalPrice.Name = "colTotalPrice";
            this.colTotalPrice.OptionsColumn.AllowEdit = false;
            this.colTotalPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // colDepartmentId
            // 
            resources.ApplyResources(this.colDepartmentId, "colDepartmentId");
            this.colDepartmentId.FieldName = "DepartmentName";
            this.colDepartmentId.Name = "colDepartmentId";
            this.colDepartmentId.OptionsColumn.AllowEdit = false;
            this.colDepartmentId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // colActiveOn
            // 
            resources.ApplyResources(this.colActiveOn, "colActiveOn");
            this.colActiveOn.FieldName = "ActiveOn";
            this.colActiveOn.Name = "colActiveOn";
            this.colActiveOn.OptionsColumn.AllowEdit = false;
            this.colActiveOn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // colBillingCustomerId
            // 
            resources.ApplyResources(this.colBillingCustomerId, "colBillingCustomerId");
            this.colBillingCustomerId.FieldName = "BillingCustomerName";
            this.colBillingCustomerId.Name = "colBillingCustomerId";
            this.colBillingCustomerId.OptionsColumn.AllowEdit = false;
            this.colBillingCustomerId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // colSelected
            // 
            resources.ApplyResources(this.colSelected, "colSelected");
            this.colSelected.ColumnEdit = this.SelectedRepositoryItemCheckEdit;
            this.colSelected.FieldName = "IsSelected";
            this.colSelected.Name = "colSelected";
            this.colSelected.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            this.colSelected.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            // 
            // SelectedRepositoryItemCheckEdit
            // 
            resources.ApplyResources(this.SelectedRepositoryItemCheckEdit, "SelectedRepositoryItemCheckEdit");
            this.SelectedRepositoryItemCheckEdit.Name = "SelectedRepositoryItemCheckEdit";
            // 
            // lkpOwnerId
            // 
            resources.ApplyResources(this.lkpOwnerId, "lkpOwnerId");
            this.lkpOwnerId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("lkpOwnerId.Buttons"))))});
            this.lkpOwnerId.Name = "lkpOwnerId";
            // 
            // lkpOpportunityId
            // 
            resources.ApplyResources(this.lkpOpportunityId, "lkpOpportunityId");
            this.lkpOpportunityId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("lkpOpportunityId.Buttons"))))});
            this.lkpOpportunityId.Name = "lkpOpportunityId";
            // 
            // DepartmentRepositoryItemLookUpEdit
            // 
            resources.ApplyResources(this.DepartmentRepositoryItemLookUpEdit, "DepartmentRepositoryItemLookUpEdit");
            this.DepartmentRepositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("DepartmentRepositoryItemLookUpEdit.Buttons"))))});
            this.DepartmentRepositoryItemLookUpEdit.Name = "DepartmentRepositoryItemLookUpEdit";
            // 
            // CustomerRepositoryItemLookUpEdit
            // 
            resources.ApplyResources(this.CustomerRepositoryItemLookUpEdit, "CustomerRepositoryItemLookUpEdit");
            this.CustomerRepositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("CustomerRepositoryItemLookUpEdit.Buttons"))))});
            this.CustomerRepositoryItemLookUpEdit.Name = "CustomerRepositoryItemLookUpEdit";
            // 
            // layoutControl2
            // 
            resources.ApplyResources(this.layoutControl2, "layoutControl2");
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.Root;
            // 
            // Root
            // 
            resources.ApplyResources(this.Root, "Root");
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(747, 23);
            this.Root.TextVisible = false;
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.StyleController = this.layoutControl1;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // layoutControlGroup1
            // 
            resources.ApplyResources(this.layoutControlGroup1, "layoutControlGroup1");
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem2,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(939, 470);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnOK;
            resources.ApplyResources(this.layoutControlItem6, "layoutControlItem6");
            this.layoutControlItem6.Location = new System.Drawing.Point(751, 423);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(84, 27);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(84, 27);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(84, 27);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 5, 0, 0);
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Default;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnCancel;
            this.layoutControlItem7.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            resources.ApplyResources(this.layoutControlItem7, "layoutControlItem7");
            this.layoutControlItem7.Location = new System.Drawing.Point(835, 423);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(84, 27);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(84, 27);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(84, 27);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 0, 0, 0);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.layoutControl2;
            resources.ApplyResources(this.layoutControlItem2, "layoutControlItem2");
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 423);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(751, 27);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.EntityGridControl;
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(919, 423);
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // InvoiceContractDialog
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoiceContractDialog";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EntityGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedRepositoryItemCheckEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpOwnerId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpOpportunityId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentRepositoryItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerRepositoryItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl EntityGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView EntityGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colContractNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colExpiresOn;
        private DevExpress.XtraGrid.Columns.GridColumn colOpportunityId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lkpOpportunityId;
        private DevExpress.XtraGrid.Columns.GridColumn colOwnerId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lkpOwnerId;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lkpStatusCode;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit DepartmentRepositoryItemLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colActiveOn;
        private DevExpress.XtraGrid.Columns.GridColumn colBillingCustomerId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit CustomerRepositoryItemLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colSelected;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit SelectedRepositoryItemCheckEdit;
        protected System.Windows.Forms.BindingSource entityBindingSource;

    }
}
