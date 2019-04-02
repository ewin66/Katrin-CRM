using System;
using Katrin.AppFramework.WinForms.Controls;
using Katrin.Win.Common.Controls;
namespace Katrin.Win.ProjectIterationModule.ProjectIteration
{
    partial class ProjectIterationDetailView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectIterationDetailView));
            this.NameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ObjectiveTextEdit = new DevExpress.XtraEditors.MemoEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
            this.ProjectSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.managementLayoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.lcgGeneral = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForObjective = new DevExpress.XtraLayout.LayoutControlItem();
            this.itemForEndTime = new DevExpress.XtraLayout.LayoutControlItem();
            this.EndDateEdit = new Katrin.AppFramework.WinForms.Controls.DropDownDateEdit();
            this.itemforproject = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForVersionName = new DevExpress.XtraLayout.LayoutControlItem();
            this.VersionNumberSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.itemForStartDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.StartDateEdit = new Katrin.AppFramework.WinForms.Controls.DropDownDateEdit();
            this.ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            this.wcfSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.statusLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.itemForStatus = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).BeginInit();
            this.EntityDataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectiveTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.managementLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForObjective)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForEndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndDateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemforproject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForVersionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VersionNumberSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wcfSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // EntityDataLayoutControl
            // 
            this.EntityDataLayoutControl.Controls.Add(this.statusLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.VersionNumberSearchLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.EndDateEdit);
            this.EntityDataLayoutControl.Controls.Add(this.StartDateEdit);
            this.EntityDataLayoutControl.Controls.Add(this.ProjectSearchLookUpEdit);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit4);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit3);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit2);
            this.EntityDataLayoutControl.Controls.Add(this.textEdit1);
            this.EntityDataLayoutControl.Controls.Add(this.NameTextEdit);
            this.EntityDataLayoutControl.Controls.Add(this.ObjectiveTextEdit);
            this.EntityDataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1026, 211, 456, 477);
            resources.ApplyResources(this.EntityDataLayoutControl, "EntityDataLayoutControl");
            // 
            // RootLayoutControlGroup
            // 
            this.RootLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1});
            this.RootLayoutControlGroup.Name = "Root";
            this.RootLayoutControlGroup.Size = new System.Drawing.Size(948, 440);
            resources.ApplyResources(this.RootLayoutControlGroup, "RootLayoutControlGroup");
            // 
            // NameTextEdit
            // 
            this.NameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Name", true));
            resources.ApplyResources(this.NameTextEdit, "NameTextEdit");
            this.NameTextEdit.Name = "NameTextEdit";
            this.NameTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ObjectiveTextEdit
            // 
            this.ObjectiveTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Objective", true));
            resources.ApplyResources(this.ObjectiveTextEdit, "ObjectiveTextEdit");
            this.ObjectiveTextEdit.Name = "ObjectiveTextEdit";
            this.ObjectiveTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // textEdit1
            // 
            this.textEdit1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "CreatedOn", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            resources.ApplyResources(this.textEdit1, "textEdit1");
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.StyleController = this.EntityDataLayoutControl;
            // 
            // textEdit2
            // 
            this.textEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "CreatedBy.FullName", true));
            resources.ApplyResources(this.textEdit2, "textEdit2");
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.StyleController = this.EntityDataLayoutControl;
            // 
            // textEdit3
            // 
            this.textEdit3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "ModifiedOn", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            resources.ApplyResources(this.textEdit3, "textEdit3");
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.StyleController = this.EntityDataLayoutControl;
            // 
            // textEdit4
            // 
            this.textEdit4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ModifiedBy.FullName", true));
            resources.ApplyResources(this.textEdit4, "textEdit4");
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.StyleController = this.EntityDataLayoutControl;
            // 
            // ProjectSearchLookUpEdit
            // 
            this.ProjectSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ProjectId", true));
            resources.ApplyResources(this.ProjectSearchLookUpEdit, "ProjectSearchLookUpEdit");
            this.ProjectSearchLookUpEdit.Name = "ProjectSearchLookUpEdit";
            this.ProjectSearchLookUpEdit.StyleController = this.EntityDataLayoutControl;
            this.ProjectSearchLookUpEdit.EditValueChanged += new System.EventHandler(this.ProjectSearchLookUpEdit_EditValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // managementLayoutControlGroup
            // 
            resources.ApplyResources(this.managementLayoutControlGroup, "managementLayoutControlGroup");
            this.managementLayoutControlGroup.ExpandButtonVisible = true;
            this.managementLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.managementLayoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.managementLayoutControlGroup.Name = "managementLayoutControlGroup";
            this.managementLayoutControlGroup.Size = new System.Drawing.Size(904, 373);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textEdit1;
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(453, 24);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(87, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEdit2;
            resources.ApplyResources(this.layoutControlItem2, "layoutControlItem2");
            this.layoutControlItem2.Location = new System.Drawing.Point(453, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(451, 24);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(87, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.textEdit3;
            resources.ApplyResources(this.layoutControlItem3, "layoutControlItem3");
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(453, 349);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(87, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.textEdit4;
            resources.ApplyResources(this.layoutControlItem4, "layoutControlItem4");
            this.layoutControlItem4.Location = new System.Drawing.Point(453, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(451, 349);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(87, 14);
            // 
            // tabbedControlGroup1
            // 
            resources.ApplyResources(this.tabbedControlGroup1, "tabbedControlGroup1");
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.lcgGeneral;
            this.tabbedControlGroup1.SelectedTabPageIndex = 0;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(928, 420);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgGeneral,
            this.managementLayoutControlGroup});
            // 
            // lcgGeneral
            // 
            resources.ApplyResources(this.lcgGeneral, "lcgGeneral");
            this.lcgGeneral.ExpandButtonVisible = true;
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForObjective,
            this.itemForEndTime,
            this.itemforproject,
            this.ItemForVersionName,
            this.itemForStartDate,
            this.ItemForName,
            this.itemForStatus});
            this.lcgGeneral.Location = new System.Drawing.Point(0, 0);
            this.lcgGeneral.Name = "lcgGeneral";
            this.lcgGeneral.Size = new System.Drawing.Size(904, 373);
            // 
            // ItemForObjective
            // 
            this.ItemForObjective.Control = this.ObjectiveTextEdit;
            resources.ApplyResources(this.ItemForObjective, "ItemForObjective");
            this.ItemForObjective.Location = new System.Drawing.Point(0, 72);
            this.ItemForObjective.Name = "ItemForObjective";
            this.ItemForObjective.Size = new System.Drawing.Size(904, 301);
            this.ItemForObjective.TextSize = new System.Drawing.Size(87, 14);
            // 
            // itemForEndTime
            // 
            this.itemForEndTime.Control = this.EndDateEdit;
            resources.ApplyResources(this.itemForEndTime, "itemForEndTime");
            this.itemForEndTime.Location = new System.Drawing.Point(452, 24);
            this.itemForEndTime.Name = "itemForEndTime";
            this.itemForEndTime.Size = new System.Drawing.Size(452, 24);
            this.itemForEndTime.TextSize = new System.Drawing.Size(87, 14);
            // 
            // EndDateEdit
            // 
            this.EndDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Deadline", true));
            resources.ApplyResources(this.EndDateEdit, "EndDateEdit");
            this.EndDateEdit.Name = "EndDateEdit";
            this.EndDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("EndDateEdit.Properties.Buttons"))))});
            this.EndDateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.EndDateEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // itemforproject
            // 
            this.itemforproject.Control = this.ProjectSearchLookUpEdit;
            resources.ApplyResources(this.itemforproject, "itemforproject");
            this.itemforproject.Location = new System.Drawing.Point(452, 0);
            this.itemforproject.Name = "itemforproject";
            this.itemforproject.Size = new System.Drawing.Size(452, 24);
            this.itemforproject.TextSize = new System.Drawing.Size(87, 14);
            // 
            // ItemForVersionName
            // 
            this.ItemForVersionName.Control = this.VersionNumberSearchLookUpEdit;
            resources.ApplyResources(this.ItemForVersionName, "ItemForVersionName");
            this.ItemForVersionName.Location = new System.Drawing.Point(0, 48);
            this.ItemForVersionName.Name = "ItemForVersionName";
            this.ItemForVersionName.Size = new System.Drawing.Size(452, 24);
            this.ItemForVersionName.TextSize = new System.Drawing.Size(87, 14);
            // 
            // VersionNumberSearchLookUpEdit
            // 
            this.VersionNumberSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ProjectVersionId", true));
            resources.ApplyResources(this.VersionNumberSearchLookUpEdit, "VersionNumberSearchLookUpEdit");
            this.VersionNumberSearchLookUpEdit.Name = "VersionNumberSearchLookUpEdit";
            this.VersionNumberSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("VersionNumberSearchLookUpEdit.Properties.Buttons"))))});
            this.VersionNumberSearchLookUpEdit.StyleController = this.EntityDataLayoutControl;
            this.VersionNumberSearchLookUpEdit.EditValueChanged += new System.EventHandler(this.VersionNameSearchLookUpEdit_EditValueChanged);
            // 
            // itemForStartDate
            // 
            this.itemForStartDate.Control = this.StartDateEdit;
            resources.ApplyResources(this.itemForStartDate, "itemForStartDate");
            this.itemForStartDate.Location = new System.Drawing.Point(0, 24);
            this.itemForStartDate.Name = "itemForStartDate";
            this.itemForStartDate.Size = new System.Drawing.Size(452, 24);
            this.itemForStartDate.TextSize = new System.Drawing.Size(87, 14);
            // 
            // StartDateEdit
            // 
            this.StartDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "StartDate", true));
            resources.ApplyResources(this.StartDateEdit, "StartDateEdit");
            this.StartDateEdit.Name = "StartDateEdit";
            this.StartDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("StartDateEdit.Properties.Buttons"))))});
            this.StartDateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.StartDateEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForName
            // 
            this.ItemForName.Control = this.NameTextEdit;
            resources.ApplyResources(this.ItemForName, "ItemForName");
            this.ItemForName.Location = new System.Drawing.Point(0, 0);
            this.ItemForName.Name = "ItemForName";
            this.ItemForName.Size = new System.Drawing.Size(452, 24);
            this.ItemForName.TextSize = new System.Drawing.Size(87, 14);
            // 
            // wcfSearchLookUpEdit1View
            // 
            this.wcfSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.wcfSearchLookUpEdit1View.Name = "wcfSearchLookUpEdit1View";
            this.wcfSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.wcfSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // statusLookUpEdit
            // 
            this.statusLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "StatusCode", true));
            resources.ApplyResources(this.statusLookUpEdit, "statusLookUpEdit");
            this.statusLookUpEdit.Name = "statusLookUpEdit";
            this.statusLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("lookUpEdit1.Properties.Buttons"))))});
            this.statusLookUpEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // itemForStatus
            // 
            this.itemForStatus.Control = this.statusLookUpEdit;
            resources.ApplyResources(this.itemForStatus, "itemForStatus");
            this.itemForStatus.Location = new System.Drawing.Point(452, 48);
            this.itemForStatus.Name = "itemForStatus";
            this.itemForStatus.Size = new System.Drawing.Size(452, 24);
            this.itemForStatus.TextSize = new System.Drawing.Size(87, 14);
            // 
            // ProjectIterationDetailView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ProjectIterationDetailView";
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).EndInit();
            this.EntityDataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectiveTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.managementLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForObjective)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForEndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndDateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemforproject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForVersionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VersionNumberSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wcfSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit NameTextEdit;
        private DevExpress.XtraEditors.MemoEdit ObjectiveTextEdit;
        private DevExpress.XtraEditors.TextEdit textEdit4;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SearchLookUpEdit ProjectSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup managementLayoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgGeneral;
        private DevExpress.XtraLayout.LayoutControlItem ItemForObjective;
        private DevExpress.XtraLayout.LayoutControlItem ItemForName;
        private DevExpress.XtraLayout.LayoutControlItem itemforproject;
        private DropDownDateEdit EndDateEdit;
        private DropDownDateEdit StartDateEdit;
        private DevExpress.XtraLayout.LayoutControlItem itemForStartDate;
        private DevExpress.XtraLayout.LayoutControlItem itemForEndTime;
        private DevExpress.XtraEditors.SearchLookUpEdit VersionNumberSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView wcfSearchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem ItemForVersionName;
        private DevExpress.XtraEditors.LookUpEdit statusLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem itemForStatus;
    }
}
