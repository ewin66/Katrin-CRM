using DevExpress.XtraLayout;
namespace Katrin.Win.MainModule.Views.ProjectTask
{
    partial class ProjectTaskListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectTaskListView));
            this.layountContrl = new DevExpress.XtraLayout.LayoutControl();
            this.memberLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.ProjectIterationSearchLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.ProjectSearchLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForProject = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForIteration = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForMember = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.TopPanel)).BeginInit();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layountContrl)).BeginInit();
            this.layountContrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectIterationSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIteration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMember)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            resources.ApplyResources(this.TopPanel, "TopPanel");
            //this.TopPanel.Controls.Add(this.layountContrl);
            // 
            // layountContrl
            // 
            resources.ApplyResources(this.layountContrl, "layountContrl");
            this.layountContrl.Appearance.DisabledLayoutGroupCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("layountContrl.Appearance.DisabledLayoutGroupCaption.GradientMode")));
            this.layountContrl.Appearance.DisabledLayoutGroupCaption.Image = ((System.Drawing.Image)(resources.GetObject("layountContrl.Appearance.DisabledLayoutGroupCaption.Image")));
            this.layountContrl.Appearance.DisabledLayoutItem.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("layountContrl.Appearance.DisabledLayoutItem.GradientMode")));
            this.layountContrl.Appearance.DisabledLayoutItem.Image = ((System.Drawing.Image)(resources.GetObject("layountContrl.Appearance.DisabledLayoutItem.Image")));
            this.layountContrl.Controls.Add(this.memberLookUp);
            this.layountContrl.Controls.Add(this.ProjectIterationSearchLookUpEdit);
            this.layountContrl.Controls.Add(this.ProjectSearchLookUpEdit);
            this.layountContrl.Name = "layountContrl";
            this.layountContrl.Root = this.Root;
            // 
            // memberLookUp
            // 
            resources.ApplyResources(this.memberLookUp, "memberLookUp");
            this.memberLookUp.Name = "memberLookUp";
            this.memberLookUp.Properties.AccessibleDescription = resources.GetString("memberLookUp.Properties.AccessibleDescription");
            this.memberLookUp.Properties.AccessibleName = resources.GetString("memberLookUp.Properties.AccessibleName");
            this.memberLookUp.Properties.AutoHeight = ((bool)(resources.GetObject("memberLookUp.Properties.AutoHeight")));
            this.memberLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("memberLookUp.Properties.Buttons"))))});
            this.memberLookUp.Properties.NullValuePrompt = resources.GetString("memberLookUp.Properties.NullValuePrompt");
            this.memberLookUp.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("memberLookUp.Properties.NullValuePromptShowForEmptyValue")));
            this.memberLookUp.StyleController = this.layountContrl;
            // 
            // ProjectIterationSearchLookUpEdit
            // 
            resources.ApplyResources(this.ProjectIterationSearchLookUpEdit, "ProjectIterationSearchLookUpEdit");
            this.ProjectIterationSearchLookUpEdit.Name = "ProjectIterationSearchLookUpEdit";
            this.ProjectIterationSearchLookUpEdit.Properties.AccessibleDescription = resources.GetString("ProjectIterationSearchLookUpEdit.Properties.AccessibleDescription");
            this.ProjectIterationSearchLookUpEdit.Properties.AccessibleName = resources.GetString("ProjectIterationSearchLookUpEdit.Properties.AccessibleName");
            this.ProjectIterationSearchLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("ProjectIterationSearchLookUpEdit.Properties.AutoHeight")));
            this.ProjectIterationSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ProjectIterationSearchLookUpEdit.Properties.Buttons"))))});
            this.ProjectIterationSearchLookUpEdit.Properties.NullValuePrompt = resources.GetString("ProjectIterationSearchLookUpEdit.Properties.NullValuePrompt");
            this.ProjectIterationSearchLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("ProjectIterationSearchLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.ProjectIterationSearchLookUpEdit.StyleController = this.layountContrl;
            // 
            // ProjectSearchLookUpEdit
            // 
            resources.ApplyResources(this.ProjectSearchLookUpEdit, "ProjectSearchLookUpEdit");
            this.ProjectSearchLookUpEdit.Name = "ProjectSearchLookUpEdit";
            this.ProjectSearchLookUpEdit.Properties.AccessibleDescription = resources.GetString("ProjectSearchLookUpEdit.Properties.AccessibleDescription");
            this.ProjectSearchLookUpEdit.Properties.AccessibleName = resources.GetString("ProjectSearchLookUpEdit.Properties.AccessibleName");
            this.ProjectSearchLookUpEdit.Properties.AutoHeight = ((bool)(resources.GetObject("ProjectSearchLookUpEdit.Properties.AutoHeight")));
            this.ProjectSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ProjectSearchLookUpEdit.Properties.Buttons"))))});
            this.ProjectSearchLookUpEdit.Properties.NullValuePrompt = resources.GetString("ProjectSearchLookUpEdit.Properties.NullValuePrompt");
            this.ProjectSearchLookUpEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("ProjectSearchLookUpEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.ProjectSearchLookUpEdit.StyleController = this.layountContrl;
            // 
            // Root
            // 
            resources.ApplyResources(this.Root, "Root");
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForProject,
            this.ItemForIteration,
            this.ItemForMember});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(560, 25);
            // 
            // ItemForProject
            // 
            this.ItemForProject.Control = this.ProjectSearchLookUpEdit;
            resources.ApplyResources(this.ItemForProject, "ItemForProject");
            this.ItemForProject.Location = new System.Drawing.Point(0, 0);
            this.ItemForProject.Name = "ItemForProject";
            this.ItemForProject.Size = new System.Drawing.Size(161, 25);
            this.ItemForProject.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForProject.TextSize = new System.Drawing.Size(24, 14);
            this.ItemForProject.TextToControlDistance = 5;
            // 
            // ItemForIteration
            // 
            this.ItemForIteration.Control = this.ProjectIterationSearchLookUpEdit;
            resources.ApplyResources(this.ItemForIteration, "ItemForIteration");
            this.ItemForIteration.Location = new System.Drawing.Point(161, 0);
            this.ItemForIteration.Name = "ItemForIteration";
            this.ItemForIteration.Size = new System.Drawing.Size(235, 25);
            this.ItemForIteration.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForIteration.TextSize = new System.Drawing.Size(24, 14);
            this.ItemForIteration.TextToControlDistance = 5;
            // 
            // ItemForMember
            // 
            this.ItemForMember.Control = this.memberLookUp;
            resources.ApplyResources(this.ItemForMember, "ItemForMember");
            this.ItemForMember.Location = new System.Drawing.Point(396, 0);
            this.ItemForMember.Name = "ItemForMember";
            this.ItemForMember.Size = new System.Drawing.Size(164, 25);
            this.ItemForMember.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForMember.TextSize = new System.Drawing.Size(24, 14);
            this.ItemForMember.TextToControlDistance = 5;
            // 
            // ProjectTaskListView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ProjectTaskListView";
            ((System.ComponentModel.ISupportInitialize)(this.TopPanel)).EndInit();
            this.TopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layountContrl)).EndInit();
            this.layountContrl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memberLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectIterationSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIteration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMember)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private LayoutControl layountContrl;
        private LayoutControlGroup Root;
        private DevExpress.XtraEditors.LookUpEdit memberLookUp;
        private DevExpress.XtraEditors.LookUpEdit ProjectIterationSearchLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit ProjectSearchLookUpEdit;
        private LayoutControlItem ItemForProject;
        private LayoutControlItem ItemForIteration;
        private LayoutControlItem ItemForMember;
    }
}
