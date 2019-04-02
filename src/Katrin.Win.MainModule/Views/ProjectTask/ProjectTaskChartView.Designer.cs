namespace Katrin.Win.MainModule.Views.ProjectTask
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
            
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectTaskChartView));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.memberLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.EntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TiltleTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.taskLookBoardByStage = new Katrin.Win.Common.Controls.LookBoardByStage();
            this.ProjectSearchLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.ProjectIterationSearchLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForProject = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForIteration = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPerson = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).BeginInit();
            this.TiltleTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectIterationSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIteration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            resources.ApplyResources(this.dataLayoutControl1, "dataLayoutControl1");
            this.dataLayoutControl1.Appearance.DisabledLayoutGroupCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("dataLayoutControl1.Appearance.DisabledLayoutGroupCaption.GradientMode")));
            this.dataLayoutControl1.Appearance.DisabledLayoutGroupCaption.Image = ((System.Drawing.Image)(resources.GetObject("dataLayoutControl1.Appearance.DisabledLayoutGroupCaption.Image")));
            this.dataLayoutControl1.Appearance.DisabledLayoutItem.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("dataLayoutControl1.Appearance.DisabledLayoutItem.GradientMode")));
            this.dataLayoutControl1.Appearance.DisabledLayoutItem.Image = ((System.Drawing.Image)(resources.GetObject("dataLayoutControl1.Appearance.DisabledLayoutItem.Image")));
            this.dataLayoutControl1.Controls.Add(this.memberLookUp);
            this.dataLayoutControl1.Controls.Add(this.TiltleTableLayoutPanel);
            this.dataLayoutControl1.Controls.Add(this.taskLookBoardByStage);
            this.dataLayoutControl1.Controls.Add(this.ProjectSearchLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.ProjectIterationSearchLookUpEdit);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(788, 210, 408, 350);
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
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
            this.memberLookUp.StyleController = this.dataLayoutControl1;
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
            this.textEdit4.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
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
            this.textEdit3.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
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
            this.textEdit2.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
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
            this.textEdit1.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
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
            this.ProjectSearchLookUpEdit.StyleController = this.dataLayoutControl1;
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
            this.ProjectIterationSearchLookUpEdit.StyleController = this.dataLayoutControl1;
            // 
            // layoutControlGroup1
            // 
            resources.ApplyResources(this.layoutControlGroup1, "layoutControlGroup1");
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.ItemForProject,
            this.ItemForIteration,
            this.ItemForPerson});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(812, 454);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.taskLookBoardByStage;
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 54);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(792, 380);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.TiltleTableLayoutPanel;
            resources.ApplyResources(this.layoutControlItem2, "layoutControlItem2");
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(792, 29);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // ItemForProject
            // 
            this.ItemForProject.Control = this.ProjectSearchLookUpEdit;
            resources.ApplyResources(this.ItemForProject, "ItemForProject");
            this.ItemForProject.Location = new System.Drawing.Point(0, 0);
            this.ItemForProject.MinSize = new System.Drawing.Size(50, 25);
            this.ItemForProject.Name = "ItemForProject";
            this.ItemForProject.Size = new System.Drawing.Size(232, 25);
            this.ItemForProject.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForProject.TextSize = new System.Drawing.Size(24, 14);
            // 
            // ItemForIteration
            // 
            this.ItemForIteration.Control = this.ProjectIterationSearchLookUpEdit;
            resources.ApplyResources(this.ItemForIteration, "ItemForIteration");
            this.ItemForIteration.Location = new System.Drawing.Point(232, 0);
            this.ItemForIteration.MinSize = new System.Drawing.Size(50, 25);
            this.ItemForIteration.Name = "ItemForIteration";
            this.ItemForIteration.Size = new System.Drawing.Size(317, 25);
            this.ItemForIteration.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForIteration.TextSize = new System.Drawing.Size(24, 14);
            // 
            // ItemForPerson
            // 
            this.ItemForPerson.Control = this.memberLookUp;
            resources.ApplyResources(this.ItemForPerson, "ItemForPerson");
            this.ItemForPerson.Location = new System.Drawing.Point(549, 0);
            this.ItemForPerson.Name = "ItemForPerson";
            this.ItemForPerson.Size = new System.Drawing.Size(243, 25);
            this.ItemForPerson.TextSize = new System.Drawing.Size(24, 14);
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
            ((System.ComponentModel.ISupportInitialize)(this.memberLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).EndInit();
            this.TiltleTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectIterationSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIteration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private Common.Controls.LookBoardByStage taskLookBoardByStage;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.TableLayoutPanel TiltleTableLayoutPanel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForProject;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIteration;
        private System.Windows.Forms.BindingSource EntityBindingSource;
        private DevExpress.XtraEditors.LookUpEdit ProjectSearchLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit ProjectIterationSearchLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit memberLookUp;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPerson;
        private DevExpress.XtraEditors.TextEdit textEdit4;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;

    }
}
