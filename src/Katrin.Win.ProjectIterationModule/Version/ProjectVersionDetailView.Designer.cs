using System;
namespace Katrin.Win.ProjectIterationModule.Version
{
    partial class ProjectVersionDetailView
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
            GC.SuppressFinalize(this);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectVersionDetailView));
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.Management = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ItemForModifiedBy = new DevExpress.XtraLayout.LayoutControlItem();
            this.ModifiedByTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForCreatedOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.CreatedOnTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForCreatedBy = new DevExpress.XtraLayout.LayoutControlItem();
            this.CreatedByTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForModifiedOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.ModifiedOnTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.General = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForVersionNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.VersionNumberTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.DescriptionMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).BeginInit();
            this.EntityDataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Management)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedByTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreatedOnTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreatedByTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedOnTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.General)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForVersionNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VersionNumberTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionMemoEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // EntityDataLayoutControl
            // 
            this.EntityDataLayoutControl.Controls.Add(this.CreatedByTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.ModifiedOnTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.CreatedOnTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.ModifiedByTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.DescriptionMemoEdit);
            this.EntityDataLayoutControl.Controls.Add(this.VersionNumberTextEdit);
            this.EntityDataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(718, 87, 250, 350);
            // 
            // RootLayoutControlGroup
            // 
            this.RootLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1});
            // 
            // tabbedControlGroup1
            // 
            resources.ApplyResources(this.tabbedControlGroup1, "tabbedControlGroup1");
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.General;
            this.tabbedControlGroup1.SelectedTabPageIndex = 0;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(575, 205);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.General,
            this.Management});
            // 
            // Management
            // 
            resources.ApplyResources(this.Management, "Management");
            this.Management.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.ItemForModifiedBy,
            this.ItemForCreatedOn,
            this.ItemForCreatedBy,
            this.ItemForModifiedOn});
            this.Management.Location = new System.Drawing.Point(0, 0);
            this.Management.Name = "Management";
            this.Management.Size = new System.Drawing.Size(551, 158);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem2, "emptySpaceItem2");
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(551, 110);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ItemForModifiedBy
            // 
            this.ItemForModifiedBy.Control = this.ModifiedByTextEdit;
            resources.ApplyResources(this.ItemForModifiedBy, "ItemForModifiedBy");
            this.ItemForModifiedBy.Location = new System.Drawing.Point(275, 24);
            this.ItemForModifiedBy.MaxSize = new System.Drawing.Size(0, 24);
            this.ItemForModifiedBy.MinSize = new System.Drawing.Size(145, 24);
            this.ItemForModifiedBy.Name = "ItemForModifiedBy";
            this.ItemForModifiedBy.Size = new System.Drawing.Size(276, 24);
            this.ItemForModifiedBy.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForModifiedBy.TextSize = new System.Drawing.Size(87, 14);
            // 
            // ModifiedByTextEdit
            // 
            this.ModifiedByTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ModifiedBy.FullName", true));
            resources.ApplyResources(this.ModifiedByTextEdit, "ModifiedByTextEdit");
            this.ModifiedByTextEdit.Name = "ModifiedByTextEdit";
            this.ModifiedByTextEdit.Properties.ReadOnly = true;
            this.ModifiedByTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForCreatedOn
            // 
            this.ItemForCreatedOn.Control = this.CreatedOnTextEdit;
            resources.ApplyResources(this.ItemForCreatedOn, "ItemForCreatedOn");
            this.ItemForCreatedOn.Location = new System.Drawing.Point(0, 0);
            this.ItemForCreatedOn.MaxSize = new System.Drawing.Size(0, 24);
            this.ItemForCreatedOn.MinSize = new System.Drawing.Size(145, 24);
            this.ItemForCreatedOn.Name = "ItemForCreatedOn";
            this.ItemForCreatedOn.Size = new System.Drawing.Size(275, 24);
            this.ItemForCreatedOn.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForCreatedOn.TextSize = new System.Drawing.Size(87, 14);
            // 
            // CreatedOnTextEdit
            // 
            this.CreatedOnTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "CreatedOn", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            resources.ApplyResources(this.CreatedOnTextEdit, "CreatedOnTextEdit");
            this.CreatedOnTextEdit.Name = "CreatedOnTextEdit";
            this.CreatedOnTextEdit.Properties.ReadOnly = true;
            this.CreatedOnTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForCreatedBy
            // 
            this.ItemForCreatedBy.Control = this.CreatedByTextEdit;
            resources.ApplyResources(this.ItemForCreatedBy, "ItemForCreatedBy");
            this.ItemForCreatedBy.Location = new System.Drawing.Point(275, 0);
            this.ItemForCreatedBy.Name = "ItemForCreatedBy";
            this.ItemForCreatedBy.Size = new System.Drawing.Size(276, 24);
            this.ItemForCreatedBy.TextSize = new System.Drawing.Size(87, 14);
            // 
            // CreatedByTextEdit
            // 
            this.CreatedByTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "CreatedBy.FullName", true));
            resources.ApplyResources(this.CreatedByTextEdit, "CreatedByTextEdit");
            this.CreatedByTextEdit.Name = "CreatedByTextEdit";
            this.CreatedByTextEdit.Properties.ReadOnly = true;
            this.CreatedByTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForModifiedOn
            // 
            this.ItemForModifiedOn.Control = this.ModifiedOnTextEdit;
            resources.ApplyResources(this.ItemForModifiedOn, "ItemForModifiedOn");
            this.ItemForModifiedOn.Location = new System.Drawing.Point(0, 24);
            this.ItemForModifiedOn.MaxSize = new System.Drawing.Size(0, 24);
            this.ItemForModifiedOn.MinSize = new System.Drawing.Size(145, 24);
            this.ItemForModifiedOn.Name = "ItemForModifiedOn";
            this.ItemForModifiedOn.Size = new System.Drawing.Size(275, 24);
            this.ItemForModifiedOn.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForModifiedOn.TextSize = new System.Drawing.Size(87, 14);
            // 
            // ModifiedOnTextEdit
            // 
            this.ModifiedOnTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "ModifiedOn", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            resources.ApplyResources(this.ModifiedOnTextEdit, "ModifiedOnTextEdit");
            this.ModifiedOnTextEdit.Name = "ModifiedOnTextEdit";
            this.ModifiedOnTextEdit.Properties.ReadOnly = true;
            this.ModifiedOnTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // General
            // 
            resources.ApplyResources(this.General, "General");
            this.General.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForVersionNumber,
            this.ItemForDescription});
            this.General.Location = new System.Drawing.Point(0, 0);
            this.General.Name = "General";
            this.General.Size = new System.Drawing.Size(551, 158);
            // 
            // ItemForVersionNumber
            // 
            this.ItemForVersionNumber.Control = this.VersionNumberTextEdit;
            resources.ApplyResources(this.ItemForVersionNumber, "ItemForVersionNumber");
            this.ItemForVersionNumber.Location = new System.Drawing.Point(0, 0);
            this.ItemForVersionNumber.MaxSize = new System.Drawing.Size(0, 24);
            this.ItemForVersionNumber.MinSize = new System.Drawing.Size(145, 24);
            this.ItemForVersionNumber.Name = "ItemForVersionNumber";
            this.ItemForVersionNumber.Size = new System.Drawing.Size(551, 24);
            this.ItemForVersionNumber.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForVersionNumber.TextSize = new System.Drawing.Size(87, 14);
            // 
            // VersionNumberTextEdit
            // 
            this.VersionNumberTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "VersionName", true));
            resources.ApplyResources(this.VersionNumberTextEdit, "VersionNumberTextEdit");
            this.VersionNumberTextEdit.Name = "VersionNumberTextEdit";
            this.VersionNumberTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForDescription
            // 
            this.ItemForDescription.Control = this.DescriptionMemoEdit;
            resources.ApplyResources(this.ItemForDescription, "ItemForDescription");
            this.ItemForDescription.Location = new System.Drawing.Point(0, 24);
            this.ItemForDescription.Name = "ItemForDescription";
            this.ItemForDescription.Size = new System.Drawing.Size(551, 134);
            this.ItemForDescription.TextSize = new System.Drawing.Size(87, 14);
            // 
            // DescriptionMemoEdit
            // 
            this.DescriptionMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Description", true));
            resources.ApplyResources(this.DescriptionMemoEdit, "DescriptionMemoEdit");
            this.DescriptionMemoEdit.Name = "DescriptionMemoEdit";
            this.DescriptionMemoEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ProjectVersionDetailView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ProjectVersionDetailView";
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).EndInit();
            this.EntityDataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Management)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedByTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreatedOnTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreatedByTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedOnTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.General)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForVersionNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VersionNumberTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionMemoEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit ModifiedOnTextEdit;
        private DevExpress.XtraEditors.TextEdit CreatedOnTextEdit;
        private DevExpress.XtraEditors.TextEdit ModifiedByTextEdit;
        private DevExpress.XtraEditors.MemoEdit DescriptionMemoEdit;
        private DevExpress.XtraEditors.TextEdit VersionNumberTextEdit;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup General;
        private DevExpress.XtraLayout.LayoutControlItem ItemForVersionNumber;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private DevExpress.XtraLayout.LayoutControlGroup Management;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForModifiedBy;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreatedOn;
        private DevExpress.XtraLayout.LayoutControlItem ItemForModifiedOn;
        private DevExpress.XtraEditors.TextEdit CreatedByTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreatedBy;
    }
}
