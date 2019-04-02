using ICSharpCode.Core;
using System;
namespace Katrin.Win.ProjectTaskModule.Common
{
    partial class TaskFilterControl
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
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.memberLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.ProjectSearchLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.ProjectIterationSearchLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForProject = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForIteration = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPerson = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectIterationSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIteration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.memberLookUp);
            this.dataLayoutControl1.Controls.Add(this.ProjectSearchLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.ProjectIterationSearchLookUpEdit);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Margin = new System.Windows.Forms.Padding(0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(783, 210, 408, 350);
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(817, 25);
            this.dataLayoutControl1.TabIndex = 1;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // memberLookUp
            // 
            this.memberLookUp.Location = new System.Drawing.Point(619, 2);
            this.memberLookUp.Name = "memberLookUp";
            this.memberLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.memberLookUp.Size = new System.Drawing.Size(196, 20);
            this.memberLookUp.StyleController = this.dataLayoutControl1;
            this.memberLookUp.TabIndex = 111;
            this.memberLookUp.EditValueChanged += new System.EventHandler(this.memberLookUp_EditValueChanged);
            // 
            // ProjectSearchLookUpEdit
            // 
            this.ProjectSearchLookUpEdit.Location = new System.Drawing.Point(52, 2);
            this.ProjectSearchLookUpEdit.Name = "ProjectSearchLookUpEdit";
            this.ProjectSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ProjectSearchLookUpEdit.Size = new System.Drawing.Size(186, 20);
            this.ProjectSearchLookUpEdit.StyleController = this.dataLayoutControl1;
            this.ProjectSearchLookUpEdit.TabIndex = 110;
            this.ProjectSearchLookUpEdit.EditValueChanged += new System.EventHandler(this.ProjectSearchLookUpEdit_EditValueChanged);
            // 
            // ProjectIterationSearchLookUpEdit
            // 
            this.ProjectIterationSearchLookUpEdit.Location = new System.Drawing.Point(292, 2);
            this.ProjectIterationSearchLookUpEdit.Name = "ProjectIterationSearchLookUpEdit";
            this.ProjectIterationSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ProjectIterationSearchLookUpEdit.Size = new System.Drawing.Size(273, 20);
            this.ProjectIterationSearchLookUpEdit.StyleController = this.dataLayoutControl1;
            this.ProjectIterationSearchLookUpEdit.TabIndex = 109;
            this.ProjectIterationSearchLookUpEdit.EditValueChanged += new System.EventHandler(this.ProjectIterationSearchLookUpEdit_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForProject,
            this.ItemForIteration,
            this.ItemForPerson});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(817, 25);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // ItemForProject
            // 
            this.ItemForProject.Control = this.ProjectSearchLookUpEdit;
            this.ItemForProject.CustomizationFormText = "ItemForProject";
            this.ItemForProject.Location = new System.Drawing.Point(0, 0);
            this.ItemForProject.MinSize = new System.Drawing.Size(50, 25);
            this.ItemForProject.Name = "ItemForProject";
            this.ItemForProject.Size = new System.Drawing.Size(240, 25);
            this.ItemForProject.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForProject.Text = ResourceService.GetString("Project");
            this.ItemForProject.TextSize = new System.Drawing.Size(47, 14);
            // 
            // ItemForIteration
            // 
            this.ItemForIteration.Control = this.ProjectIterationSearchLookUpEdit;
            this.ItemForIteration.CustomizationFormText = "ItemForIteration";
            this.ItemForIteration.Location = new System.Drawing.Point(240, 0);
            this.ItemForIteration.MinSize = new System.Drawing.Size(50, 25);
            this.ItemForIteration.Name = "ItemForIteration";
            this.ItemForIteration.Size = new System.Drawing.Size(327, 25);
            this.ItemForIteration.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForIteration.Text = ResourceService.GetString("Iteration");
            this.ItemForIteration.TextSize = new System.Drawing.Size(47, 14);
            // 
            // ItemForPerson
            // 
            this.ItemForPerson.Control = this.memberLookUp;
            this.ItemForPerson.CustomizationFormText = "Project Member";
            this.ItemForPerson.Location = new System.Drawing.Point(567, 0);
            this.ItemForPerson.Name = "ItemForPerson";
            this.ItemForPerson.Size = new System.Drawing.Size(250, 25);
            this.ItemForPerson.Text = ResourceService.GetString("Member");
            this.ItemForPerson.TextSize = new System.Drawing.Size(47, 14);
            // 
            // TaskFilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "TaskFilterControl";
            this.Size = new System.Drawing.Size(817, 25);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memberLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectIterationSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIteration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPerson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.LookUpEdit memberLookUp;
        private DevExpress.XtraEditors.LookUpEdit ProjectSearchLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit ProjectIterationSearchLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForProject;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIteration;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPerson;

    }
}
