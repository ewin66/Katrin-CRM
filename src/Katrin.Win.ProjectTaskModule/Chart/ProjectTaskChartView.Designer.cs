using System;
using Katrin.Win.Common.Controls;
namespace Katrin.Win.ProjectTaskModule.Chart
{
    partial class ProjectTaskChartView
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
            taskLookBoardByStage = null;
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
            this.components = new System.ComponentModel.Container();
            Katrin.AppFramework.WinForms.Context.ActionContext actionContext1 = new Katrin.AppFramework.WinForms.Context.ActionContext();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectTaskChartView));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.taskFilterControl1 = new Katrin.Win.ProjectTaskModule.Common.TaskFilterControl();
            this.TiltleTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.taskLookBoardByStage = new Katrin.Win.Common.Controls.LookBoardByStage();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.EntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            this.TiltleTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.taskFilterControl1);
            resources.ApplyResources(this.dataLayoutControl1, "dataLayoutControl1");
            this.dataLayoutControl1.Appearance.DisabledLayoutGroupCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("dataLayoutControl1.Appearance.DisabledLayoutGroupCaption.GradientMode")));
            this.dataLayoutControl1.Appearance.DisabledLayoutGroupCaption.Image = ((System.Drawing.Image)(resources.GetObject("dataLayoutControl1.Appearance.DisabledLayoutGroupCaption.Image")));
            this.dataLayoutControl1.Appearance.DisabledLayoutItem.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("dataLayoutControl1.Appearance.DisabledLayoutItem.GradientMode")));
            this.dataLayoutControl1.Appearance.DisabledLayoutItem.Image = ((System.Drawing.Image)(resources.GetObject("dataLayoutControl1.Appearance.DisabledLayoutItem.Image")));
            this.dataLayoutControl1.Controls.Add(this.TiltleTableLayoutPanel);
            this.dataLayoutControl1.Controls.Add(this.taskLookBoardByStage);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(739, 227, 408, 350);
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            // 
            // taskFilterControl1
            // 
            actionContext1.CurrentObject = null;
            this.taskFilterControl1.Context = actionContext1;
            this.taskFilterControl1.ControllerManager = null;
            this.taskFilterControl1.IsChildForm = true;
            resources.ApplyResources(this.taskFilterControl1, "taskFilterControl1");
            this.taskFilterControl1.MemberId = null;
            this.taskFilterControl1.Model = null;
            this.taskFilterControl1.Name = "taskFilterControl1";
            this.taskFilterControl1.ObjectName = null;
            this.taskFilterControl1.ProjectId = null;
            this.taskFilterControl1.ProjectIterationId = null;
            this.taskFilterControl1.ViewName = null;
            // 
            // TiltleTableLayoutPanel
            // 
            resources.ApplyResources(this.TiltleTableLayoutPanel, "TiltleTableLayoutPanel");
            this.TiltleTableLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.TiltleTableLayoutPanel.Controls.Add(this.textEdit4, 3, 0);
            this.TiltleTableLayoutPanel.Controls.Add(this.textEdit3, 2, 0);
            this.TiltleTableLayoutPanel.Controls.Add(this.textEdit2, 1, 0);
            this.TiltleTableLayoutPanel.Controls.Add(this.textEdit1, 0, 0);
            this.TiltleTableLayoutPanel.ForeColor = System.Drawing.Color.White;
            this.TiltleTableLayoutPanel.Name = "TiltleTableLayoutPanel";
            // 
            // textEdit4
            // 
            resources.ApplyResources(this.textEdit4, "textEdit4");
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Properties.AccessibleDescription = resources.GetString("textEdit4.Properties.AccessibleDescription");
            this.textEdit4.Properties.AccessibleName = resources.GetString("textEdit4.Properties.AccessibleName");
            this.textEdit4.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("textEdit4.Properties.Appearance.BackColor")));
            this.textEdit4.Properties.Appearance.BorderColor = ((System.Drawing.Color)(resources.GetObject("textEdit4.Properties.Appearance.BorderColor")));
            this.textEdit4.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("textEdit4.Properties.Appearance.Font")));
            this.textEdit4.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("textEdit4.Properties.Appearance.ForeColor")));
            this.textEdit4.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("textEdit4.Properties.Appearance.GradientMode")));
            this.textEdit4.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("textEdit4.Properties.Appearance.Image")));
            this.textEdit4.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit4.Properties.Appearance.Options.UseBorderColor = true;
            this.textEdit4.Properties.Appearance.Options.UseFont = true;
            this.textEdit4.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit4.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit4.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit4.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.textEdit4.Properties.AutoHeight = ((bool)(resources.GetObject("textEdit4.Properties.AutoHeight")));
            this.textEdit4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
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
            // 
            // textEdit3
            // 
            resources.ApplyResources(this.textEdit3, "textEdit3");
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Properties.AccessibleDescription = resources.GetString("textEdit3.Properties.AccessibleDescription");
            this.textEdit3.Properties.AccessibleName = resources.GetString("textEdit3.Properties.AccessibleName");
            this.textEdit3.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("textEdit3.Properties.Appearance.BackColor")));
            this.textEdit3.Properties.Appearance.BorderColor = ((System.Drawing.Color)(resources.GetObject("textEdit3.Properties.Appearance.BorderColor")));
            this.textEdit3.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("textEdit3.Properties.Appearance.Font")));
            this.textEdit3.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("textEdit3.Properties.Appearance.ForeColor")));
            this.textEdit3.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("textEdit3.Properties.Appearance.GradientMode")));
            this.textEdit3.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("textEdit3.Properties.Appearance.Image")));
            this.textEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit3.Properties.Appearance.Options.UseBorderColor = true;
            this.textEdit3.Properties.Appearance.Options.UseFont = true;
            this.textEdit3.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit3.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit3.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit3.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.textEdit3.Properties.AutoHeight = ((bool)(resources.GetObject("textEdit3.Properties.AutoHeight")));
            this.textEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
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
            // 
            // textEdit2
            // 
            resources.ApplyResources(this.textEdit2, "textEdit2");
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.AccessibleDescription = resources.GetString("textEdit2.Properties.AccessibleDescription");
            this.textEdit2.Properties.AccessibleName = resources.GetString("textEdit2.Properties.AccessibleName");
            this.textEdit2.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("textEdit2.Properties.Appearance.BackColor")));
            this.textEdit2.Properties.Appearance.BorderColor = ((System.Drawing.Color)(resources.GetObject("textEdit2.Properties.Appearance.BorderColor")));
            this.textEdit2.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("textEdit2.Properties.Appearance.Font")));
            this.textEdit2.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("textEdit2.Properties.Appearance.ForeColor")));
            this.textEdit2.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("textEdit2.Properties.Appearance.GradientMode")));
            this.textEdit2.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("textEdit2.Properties.Appearance.Image")));
            this.textEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit2.Properties.Appearance.Options.UseBorderColor = true;
            this.textEdit2.Properties.Appearance.Options.UseFont = true;
            this.textEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit2.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit2.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.textEdit2.Properties.AutoHeight = ((bool)(resources.GetObject("textEdit2.Properties.AutoHeight")));
            this.textEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
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
            // 
            // textEdit1
            // 
            resources.ApplyResources(this.textEdit1, "textEdit1");
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.AccessibleDescription = resources.GetString("textEdit1.Properties.AccessibleDescription");
            this.textEdit1.Properties.AccessibleName = resources.GetString("textEdit1.Properties.AccessibleName");
            this.textEdit1.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("textEdit1.Properties.Appearance.BackColor")));
            this.textEdit1.Properties.Appearance.BorderColor = ((System.Drawing.Color)(resources.GetObject("textEdit1.Properties.Appearance.BorderColor")));
            this.textEdit1.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("textEdit1.Properties.Appearance.Font")));
            this.textEdit1.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("textEdit1.Properties.Appearance.ForeColor")));
            this.textEdit1.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("textEdit1.Properties.Appearance.GradientMode")));
            this.textEdit1.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("textEdit1.Properties.Appearance.Image")));
            this.textEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit1.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit1.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.textEdit1.Properties.AutoHeight = ((bool)(resources.GetObject("textEdit1.Properties.AutoHeight")));
            this.textEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
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
            // 
            // taskLookBoardByStage
            // 
            resources.ApplyResources(this.taskLookBoardByStage, "taskLookBoardByStage");
            this.taskLookBoardByStage.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("taskLookBoardByStage.Appearance.BackColor")));
            this.taskLookBoardByStage.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("taskLookBoardByStage.Appearance.GradientMode")));
            this.taskLookBoardByStage.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("taskLookBoardByStage.Appearance.Image")));
            this.taskLookBoardByStage.Appearance.Options.UseBackColor = true;
            this.taskLookBoardByStage.BoardDataList = null;
            this.taskLookBoardByStage.LookAndFeel.SkinName = "MetroBlack";
            this.taskLookBoardByStage.Name = "taskLookBoardByStage";
            // 
            // layoutControlGroup1
            // 
            resources.ApplyResources(this.layoutControlGroup1, "layoutControlGroup1");
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(812, 454);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.taskLookBoardByStage;
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(212, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(792, 382);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            this.layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.TiltleTableLayoutPanel;
            resources.ApplyResources(this.layoutControlItem2, "layoutControlItem2");
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(24, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(792, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            this.layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.taskFilterControl1;
            resources.ApplyResources(this.layoutControlItem3, "layoutControlItem3");
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(0, 29);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(212, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(792, 26);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            this.layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // gridView2
            // 
            resources.ApplyResources(this.gridView2, "gridView2");
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridView1
            // 
            resources.ApplyResources(this.gridView1, "gridView1");
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // ProjectTaskChartView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "ProjectTaskChartView";
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            this.TiltleTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private LookBoardByStage taskLookBoardByStage;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.TableLayoutPanel TiltleTableLayoutPanel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource EntityBindingSource;
        private DevExpress.XtraEditors.TextEdit textEdit4;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private Common.TaskFilterControl taskFilterControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;

    }
}
