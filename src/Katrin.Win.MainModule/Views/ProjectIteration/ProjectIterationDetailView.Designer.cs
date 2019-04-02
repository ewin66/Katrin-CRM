using Katrin.Win.Common.Controls;
namespace Katrin.Win.MainModule.Views.ProjectIteration
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
            this.ProjectSearchLookUpEdit = new Katrin.Win.Common.Controls.WcfSearchLookUpEdit();
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
            this.EndDateEdit = new Katrin.Win.Common.Controls.DropDownDateEdit();
            this.itemforproject = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForVersionName = new DevExpress.XtraLayout.LayoutControlItem();
            this.VersionNumberSearchLookUpEdit = new Katrin.Win.Common.Controls.WcfSearchLookUpEdit();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.itemForStartDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.StartDateEdit = new Katrin.Win.Common.Controls.DropDownDateEdit();
            this.ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            this.wcfSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).BeginInit();
            this.EntityDataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectiveTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wcfSearchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // EntityDataLayoutControl
            // 
            resources.ApplyResources(this.EntityDataLayoutControl, "EntityDataLayoutControl");
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
            // 
            // RootLayoutControlGroup
            // 
            resources.ApplyResources(this.RootLayoutControlGroup, "RootLayoutControlGroup");
            this.RootLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1});
            this.RootLayoutControlGroup.Name = "Root";
            this.RootLayoutControlGroup.OptionsToolTip.ToolTip = resources.GetString("resource.ToolTip");
            this.RootLayoutControlGroup.OptionsToolTip.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("resource.ToolTipIconType")));
            this.RootLayoutControlGroup.OptionsToolTip.ToolTipTitle = resources.GetString("resource.ToolTipTitle");
            this.RootLayoutControlGroup.Size = new System.Drawing.Size(948, 440);
            // 
            // NameTextEdit
            // 
            resources.ApplyResources(this.NameTextEdit, "NameTextEdit");
            this.NameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Name", true));
            this.NameTextEdit.Name = "NameTextEdit";
            this.NameTextEdit.Properties.AccessibleDescription = resources.GetString("NameTextEdit.Properties.AccessibleDescription");
            this.NameTextEdit.Properties.AccessibleName = resources.GetString("NameTextEdit.Properties.AccessibleName");
            this.NameTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("NameTextEdit.Properties.AutoHeight")));
            this.NameTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("NameTextEdit.Properties.Mask.AutoComplete")));
            this.NameTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("NameTextEdit.Properties.Mask.BeepOnError")));
            this.NameTextEdit.Properties.Mask.EditMask = resources.GetString("NameTextEdit.Properties.Mask.EditMask");
            this.NameTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("NameTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.NameTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("NameTextEdit.Properties.Mask.MaskType")));
            this.NameTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("NameTextEdit.Properties.Mask.PlaceHolder")));
            this.NameTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("NameTextEdit.Properties.Mask.SaveLiteral")));
            this.NameTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("NameTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.NameTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("NameTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.NameTextEdit.Properties.NullValuePrompt = resources.GetString("NameTextEdit.Properties.NullValuePrompt");
            this.NameTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("NameTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.NameTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ObjectiveTextEdit
            // 
            resources.ApplyResources(this.ObjectiveTextEdit, "ObjectiveTextEdit");
            this.ObjectiveTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Objective", true));
            this.ObjectiveTextEdit.Name = "ObjectiveTextEdit";
            this.ObjectiveTextEdit.Properties.AccessibleDescription = resources.GetString("ObjectiveTextEdit.Properties.AccessibleDescription");
            this.ObjectiveTextEdit.Properties.AccessibleName = resources.GetString("ObjectiveTextEdit.Properties.AccessibleName");
            this.ObjectiveTextEdit.Properties.NullValuePrompt = resources.GetString("ObjectiveTextEdit.Properties.NullValuePrompt");
            this.ObjectiveTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("ObjectiveTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.ObjectiveTextEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // textEdit1
            // 
            resources.ApplyResources(this.textEdit1, "textEdit1");
            this.textEdit1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "CreatedOn", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.AccessibleDescription = resources.GetString("textEdit1.Properties.AccessibleDescription");
            this.textEdit1.Properties.AccessibleName = resources.GetString("textEdit1.Properties.AccessibleName");
            this.textEdit1.Properties.AutoHeight = ((bool)(resources.GetObject("textEdit1.Properties.AutoHeight")));
            this.textEdit1.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("textEdit1.Properties.Mask.AutoComplete")));
            this.textEdit1.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("textEdit1.Properties.Mask.BeepOnError")));
            this.textEdit1.Properties.Mask.EditMask = resources.GetString("textEdit1.Properties.Mask.EditMask");
            this.textEdit1.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("textEdit1.Properties.Mask.IgnoreMaskBlank")));
            this.textEdit1.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("textEdit1.Properties.Mask.MaskType")));
            this.textEdit1.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("textEdit1.Properties.Mask.PlaceHolder")));
            this.textEdit1.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("textEdit1.Properties.Mask.SaveLiteral")));
            this.textEdit1.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("textEdit1.Properties.Mask.ShowPlaceHolders")));
            this.textEdit1.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("textEdit1.Properties.Mask.UseMaskAsDisplayFormat")));
            this.textEdit1.Properties.NullValuePrompt = resources.GetString("textEdit1.Properties.NullValuePrompt");
            this.textEdit1.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("textEdit1.Properties.NullValuePromptShowForEmptyValue")));
            this.textEdit1.StyleController = this.EntityDataLayoutControl;
            // 
            // textEdit2
            // 
            resources.ApplyResources(this.textEdit2, "textEdit2");
            this.textEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "CreatedBy.FullName", true));
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.AccessibleDescription = resources.GetString("textEdit2.Properties.AccessibleDescription");
            this.textEdit2.Properties.AccessibleName = resources.GetString("textEdit2.Properties.AccessibleName");
            this.textEdit2.Properties.AutoHeight = ((bool)(resources.GetObject("textEdit2.Properties.AutoHeight")));
            this.textEdit2.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("textEdit2.Properties.Mask.AutoComplete")));
            this.textEdit2.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("textEdit2.Properties.Mask.BeepOnError")));
            this.textEdit2.Properties.Mask.EditMask = resources.GetString("textEdit2.Properties.Mask.EditMask");
            this.textEdit2.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("textEdit2.Properties.Mask.IgnoreMaskBlank")));
            this.textEdit2.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("textEdit2.Properties.Mask.MaskType")));
            this.textEdit2.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("textEdit2.Properties.Mask.PlaceHolder")));
            this.textEdit2.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("textEdit2.Properties.Mask.SaveLiteral")));
            this.textEdit2.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("textEdit2.Properties.Mask.ShowPlaceHolders")));
            this.textEdit2.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("textEdit2.Properties.Mask.UseMaskAsDisplayFormat")));
            this.textEdit2.Properties.NullValuePrompt = resources.GetString("textEdit2.Properties.NullValuePrompt");
            this.textEdit2.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("textEdit2.Properties.NullValuePromptShowForEmptyValue")));
            this.textEdit2.StyleController = this.EntityDataLayoutControl;
            // 
            // textEdit3
            // 
            resources.ApplyResources(this.textEdit3, "textEdit3");
            this.textEdit3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EntityBindingSource, "ModifiedOn", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Properties.AccessibleDescription = resources.GetString("textEdit3.Properties.AccessibleDescription");
            this.textEdit3.Properties.AccessibleName = resources.GetString("textEdit3.Properties.AccessibleName");
            this.textEdit3.Properties.AutoHeight = ((bool)(resources.GetObject("textEdit3.Properties.AutoHeight")));
            this.textEdit3.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("textEdit3.Properties.Mask.AutoComplete")));
            this.textEdit3.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("textEdit3.Properties.Mask.BeepOnError")));
            this.textEdit3.Properties.Mask.EditMask = resources.GetString("textEdit3.Properties.Mask.EditMask");
            this.textEdit3.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("textEdit3.Properties.Mask.IgnoreMaskBlank")));
            this.textEdit3.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("textEdit3.Properties.Mask.MaskType")));
            this.textEdit3.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("textEdit3.Properties.Mask.PlaceHolder")));
            this.textEdit3.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("textEdit3.Properties.Mask.SaveLiteral")));
            this.textEdit3.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("textEdit3.Properties.Mask.ShowPlaceHolders")));
            this.textEdit3.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("textEdit3.Properties.Mask.UseMaskAsDisplayFormat")));
            this.textEdit3.Properties.NullValuePrompt = resources.GetString("textEdit3.Properties.NullValuePrompt");
            this.textEdit3.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("textEdit3.Properties.NullValuePromptShowForEmptyValue")));
            this.textEdit3.StyleController = this.EntityDataLayoutControl;
            // 
            // textEdit4
            // 
            resources.ApplyResources(this.textEdit4, "textEdit4");
            this.textEdit4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ModifiedBy.FullName", true));
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Properties.AccessibleDescription = resources.GetString("textEdit4.Properties.AccessibleDescription");
            this.textEdit4.Properties.AccessibleName = resources.GetString("textEdit4.Properties.AccessibleName");
            this.textEdit4.Properties.AutoHeight = ((bool)(resources.GetObject("textEdit4.Properties.AutoHeight")));
            this.textEdit4.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("textEdit4.Properties.Mask.AutoComplete")));
            this.textEdit4.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("textEdit4.Properties.Mask.BeepOnError")));
            this.textEdit4.Properties.Mask.EditMask = resources.GetString("textEdit4.Properties.Mask.EditMask");
            this.textEdit4.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("textEdit4.Properties.Mask.IgnoreMaskBlank")));
            this.textEdit4.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("textEdit4.Properties.Mask.MaskType")));
            this.textEdit4.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("textEdit4.Properties.Mask.PlaceHolder")));
            this.textEdit4.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("textEdit4.Properties.Mask.SaveLiteral")));
            this.textEdit4.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("textEdit4.Properties.Mask.ShowPlaceHolders")));
            this.textEdit4.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("textEdit4.Properties.Mask.UseMaskAsDisplayFormat")));
            this.textEdit4.Properties.NullValuePrompt = resources.GetString("textEdit4.Properties.NullValuePrompt");
            this.textEdit4.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("textEdit4.Properties.NullValuePromptShowForEmptyValue")));
            this.textEdit4.StyleController = this.EntityDataLayoutControl;
            // 
            // ProjectSearchLookUpEdit
            // 
            resources.ApplyResources(this.ProjectSearchLookUpEdit, "ProjectSearchLookUpEdit");
            this.ProjectSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ProjectId", true));
            this.ProjectSearchLookUpEdit.Name = "ProjectSearchLookUpEdit";
            this.ProjectSearchLookUpEdit.StyleController = this.EntityDataLayoutControl;
            this.ProjectSearchLookUpEdit.EditValueChanged += new System.EventHandler(this.ProjectSearchLookUpEdit_EditValueChanged);
            // 
            // gridView1
            // 
            resources.ApplyResources(this.gridView1, "gridView1");
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
            this.layoutControlItem1.TextSize = new System.Drawing.Size(105, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEdit2;
            resources.ApplyResources(this.layoutControlItem2, "layoutControlItem2");
            this.layoutControlItem2.Location = new System.Drawing.Point(453, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(451, 24);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(105, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.textEdit3;
            resources.ApplyResources(this.layoutControlItem3, "layoutControlItem3");
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(453, 349);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(105, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.textEdit4;
            resources.ApplyResources(this.layoutControlItem4, "layoutControlItem4");
            this.layoutControlItem4.Location = new System.Drawing.Point(453, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(451, 349);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(105, 14);
            // 
            // tabbedControlGroup1
            // 
            resources.ApplyResources(this.tabbedControlGroup1, "tabbedControlGroup1");
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.managementLayoutControlGroup;
            this.tabbedControlGroup1.SelectedTabPageIndex = 1;
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
            this.emptySpaceItem1,
            this.itemForStartDate,
            this.ItemForName});
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
            this.ItemForObjective.TextSize = new System.Drawing.Size(105, 14);
            // 
            // itemForEndTime
            // 
            this.itemForEndTime.Control = this.EndDateEdit;
            resources.ApplyResources(this.itemForEndTime, "itemForEndTime");
            this.itemForEndTime.Location = new System.Drawing.Point(452, 24);
            this.itemForEndTime.Name = "itemForEndTime";
            this.itemForEndTime.Size = new System.Drawing.Size(452, 24);
            this.itemForEndTime.TextSize = new System.Drawing.Size(105, 14);
            // 
            // EndDateEdit
            // 
            resources.ApplyResources(this.EndDateEdit, "EndDateEdit");
            this.EndDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Deadline", true));
            this.EndDateEdit.Name = "EndDateEdit";
            this.EndDateEdit.Properties.AccessibleDescription = resources.GetString("EndDateEdit.Properties.AccessibleDescription");
            this.EndDateEdit.Properties.AccessibleName = resources.GetString("EndDateEdit.Properties.AccessibleName");
            this.EndDateEdit.Properties.AutoHeight = ((bool)(resources.GetObject("EndDateEdit.Properties.AutoHeight")));
            this.EndDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("EndDateEdit.Properties.Buttons"))))});
            this.EndDateEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("EndDateEdit.Properties.Mask.AutoComplete")));
            this.EndDateEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("EndDateEdit.Properties.Mask.BeepOnError")));
            this.EndDateEdit.Properties.Mask.EditMask = resources.GetString("EndDateEdit.Properties.Mask.EditMask");
            this.EndDateEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("EndDateEdit.Properties.Mask.IgnoreMaskBlank")));
            this.EndDateEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("EndDateEdit.Properties.Mask.MaskType")));
            this.EndDateEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("EndDateEdit.Properties.Mask.PlaceHolder")));
            this.EndDateEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("EndDateEdit.Properties.Mask.SaveLiteral")));
            this.EndDateEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("EndDateEdit.Properties.Mask.ShowPlaceHolders")));
            this.EndDateEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("EndDateEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.EndDateEdit.Properties.NullValuePrompt = resources.GetString("EndDateEdit.Properties.NullValuePrompt");
            this.EndDateEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("EndDateEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.EndDateEdit.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("EndDateEdit.Properties.VistaTimeProperties.AccessibleDescription");
            this.EndDateEdit.Properties.VistaTimeProperties.AccessibleName = resources.GetString("EndDateEdit.Properties.VistaTimeProperties.AccessibleName");
            this.EndDateEdit.Properties.VistaTimeProperties.AutoHeight = ((bool)(resources.GetObject("EndDateEdit.Properties.VistaTimeProperties.AutoHeight")));
            this.EndDateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.EndDateEdit.Properties.VistaTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("EndDateEdit.Properties.VistaTimeProperties.Mask.AutoComplete")));
            this.EndDateEdit.Properties.VistaTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("EndDateEdit.Properties.VistaTimeProperties.Mask.BeepOnError")));
            this.EndDateEdit.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("EndDateEdit.Properties.VistaTimeProperties.Mask.EditMask");
            this.EndDateEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("EndDateEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank")));
            this.EndDateEdit.Properties.VistaTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("EndDateEdit.Properties.VistaTimeProperties.Mask.MaskType")));
            this.EndDateEdit.Properties.VistaTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("EndDateEdit.Properties.VistaTimeProperties.Mask.PlaceHolder")));
            this.EndDateEdit.Properties.VistaTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("EndDateEdit.Properties.VistaTimeProperties.Mask.SaveLiteral")));
            this.EndDateEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("EndDateEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders")));
            this.EndDateEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("EndDateEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat")));
            this.EndDateEdit.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("EndDateEdit.Properties.VistaTimeProperties.NullValuePrompt");
            this.EndDateEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("EndDateEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue")));
            this.EndDateEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // itemforproject
            // 
            this.itemforproject.Control = this.ProjectSearchLookUpEdit;
            resources.ApplyResources(this.itemforproject, "itemforproject");
            this.itemforproject.Location = new System.Drawing.Point(452, 0);
            this.itemforproject.Name = "itemforproject";
            this.itemforproject.Size = new System.Drawing.Size(452, 24);
            this.itemforproject.TextSize = new System.Drawing.Size(105, 14);
            // 
            // ItemForVersionName
            // 
            this.ItemForVersionName.Control = this.VersionNumberSearchLookUpEdit;
            resources.ApplyResources(this.ItemForVersionName, "ItemForVersionName");
            this.ItemForVersionName.Location = new System.Drawing.Point(0, 48);
            this.ItemForVersionName.Name = "ItemForVersionName";
            this.ItemForVersionName.Size = new System.Drawing.Size(452, 24);
            this.ItemForVersionName.TextSize = new System.Drawing.Size(105, 14);
            // 
            // VersionNumberSearchLookUpEdit
            // 
            resources.ApplyResources(this.VersionNumberSearchLookUpEdit, "VersionNumberSearchLookUpEdit");
            this.VersionNumberSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ProjectVersionId", true));
            this.VersionNumberSearchLookUpEdit.Name = "VersionNumberSearchLookUpEdit";
            this.VersionNumberSearchLookUpEdit.StyleController = this.EntityDataLayoutControl;
            this.VersionNumberSearchLookUpEdit.EditValueChanged += new System.EventHandler(this.VersionNameSearchLookUpEdit_EditValueChanged);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem1, "emptySpaceItem1");
            this.emptySpaceItem1.Location = new System.Drawing.Point(452, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(452, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // itemForStartDate
            // 
            this.itemForStartDate.Control = this.StartDateEdit;
            resources.ApplyResources(this.itemForStartDate, "itemForStartDate");
            this.itemForStartDate.Location = new System.Drawing.Point(0, 24);
            this.itemForStartDate.Name = "itemForStartDate";
            this.itemForStartDate.Size = new System.Drawing.Size(452, 24);
            this.itemForStartDate.TextSize = new System.Drawing.Size(105, 14);
            // 
            // StartDateEdit
            // 
            resources.ApplyResources(this.StartDateEdit, "StartDateEdit");
            this.StartDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "StartDate", true));
            this.StartDateEdit.Name = "StartDateEdit";
            this.StartDateEdit.Properties.AccessibleDescription = resources.GetString("StartDateEdit.Properties.AccessibleDescription");
            this.StartDateEdit.Properties.AccessibleName = resources.GetString("StartDateEdit.Properties.AccessibleName");
            this.StartDateEdit.Properties.AutoHeight = ((bool)(resources.GetObject("StartDateEdit.Properties.AutoHeight")));
            this.StartDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("StartDateEdit.Properties.Buttons"))))});
            this.StartDateEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("StartDateEdit.Properties.Mask.AutoComplete")));
            this.StartDateEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("StartDateEdit.Properties.Mask.BeepOnError")));
            this.StartDateEdit.Properties.Mask.EditMask = resources.GetString("StartDateEdit.Properties.Mask.EditMask");
            this.StartDateEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("StartDateEdit.Properties.Mask.IgnoreMaskBlank")));
            this.StartDateEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("StartDateEdit.Properties.Mask.MaskType")));
            this.StartDateEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("StartDateEdit.Properties.Mask.PlaceHolder")));
            this.StartDateEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("StartDateEdit.Properties.Mask.SaveLiteral")));
            this.StartDateEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("StartDateEdit.Properties.Mask.ShowPlaceHolders")));
            this.StartDateEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("StartDateEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.StartDateEdit.Properties.NullValuePrompt = resources.GetString("StartDateEdit.Properties.NullValuePrompt");
            this.StartDateEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("StartDateEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.StartDateEdit.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("StartDateEdit.Properties.VistaTimeProperties.AccessibleDescription");
            this.StartDateEdit.Properties.VistaTimeProperties.AccessibleName = resources.GetString("StartDateEdit.Properties.VistaTimeProperties.AccessibleName");
            this.StartDateEdit.Properties.VistaTimeProperties.AutoHeight = ((bool)(resources.GetObject("StartDateEdit.Properties.VistaTimeProperties.AutoHeight")));
            this.StartDateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.StartDateEdit.Properties.VistaTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("StartDateEdit.Properties.VistaTimeProperties.Mask.AutoComplete")));
            this.StartDateEdit.Properties.VistaTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("StartDateEdit.Properties.VistaTimeProperties.Mask.BeepOnError")));
            this.StartDateEdit.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("StartDateEdit.Properties.VistaTimeProperties.Mask.EditMask");
            this.StartDateEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("StartDateEdit.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank")));
            this.StartDateEdit.Properties.VistaTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("StartDateEdit.Properties.VistaTimeProperties.Mask.MaskType")));
            this.StartDateEdit.Properties.VistaTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("StartDateEdit.Properties.VistaTimeProperties.Mask.PlaceHolder")));
            this.StartDateEdit.Properties.VistaTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("StartDateEdit.Properties.VistaTimeProperties.Mask.SaveLiteral")));
            this.StartDateEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("StartDateEdit.Properties.VistaTimeProperties.Mask.ShowPlaceHolders")));
            this.StartDateEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("StartDateEdit.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat")));
            this.StartDateEdit.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("StartDateEdit.Properties.VistaTimeProperties.NullValuePrompt");
            this.StartDateEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("StartDateEdit.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue")));
            this.StartDateEdit.StyleController = this.EntityDataLayoutControl;
            // 
            // ItemForName
            // 
            this.ItemForName.Control = this.NameTextEdit;
            resources.ApplyResources(this.ItemForName, "ItemForName");
            this.ItemForName.Location = new System.Drawing.Point(0, 0);
            this.ItemForName.Name = "ItemForName";
            this.ItemForName.Size = new System.Drawing.Size(452, 24);
            this.ItemForName.TextSize = new System.Drawing.Size(105, 14);
            // 
            // wcfSearchLookUpEdit1View
            // 
            resources.ApplyResources(this.wcfSearchLookUpEdit1View, "wcfSearchLookUpEdit1View");
            this.wcfSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.wcfSearchLookUpEdit1View.Name = "wcfSearchLookUpEdit1View";
            this.wcfSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.wcfSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // ProjectIterationDetailView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ProjectIterationDetailView";
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).EndInit();
            this.EntityDataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectiveTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wcfSearchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit NameTextEdit;
        private DevExpress.XtraEditors.MemoEdit ObjectiveTextEdit;
        private DevExpress.XtraEditors.TextEdit textEdit4;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private Katrin.Win.Common.Controls.WcfSearchLookUpEdit ProjectSearchLookUpEdit;
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
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private WcfSearchLookUpEdit VersionNumberSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView wcfSearchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem ItemForVersionName;
    }
}
