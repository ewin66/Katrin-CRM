namespace Katrin.Win.MainModule.Views.Note
{
    partial class NoteDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteDetailForm));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.noteDataLayoutControl = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.SubjectTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.noteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NoteTextMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForSubject = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForNoteText = new DevExpress.XtraLayout.LayoutControlItem();
            this.PutNoteChEdit = new DevExpress.XtraEditors.CheckEdit();
            this.cancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.saveButton = new DevExpress.XtraEditors.SimpleButton();
            this.dxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.PutNoteDateToModifyEdit = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.noteDataLayoutControl)).BeginInit();
            this.noteDataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SubjectTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteTextMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNoteText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PutNoteChEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PutNoteDateToModifyEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // noteDataLayoutControl
            // 
            resources.ApplyResources(this.noteDataLayoutControl, "noteDataLayoutControl");
            this.noteDataLayoutControl.Appearance.DisabledLayoutGroupCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("noteDataLayoutControl.Appearance.DisabledLayoutGroupCaption.GradientMode")));
            this.noteDataLayoutControl.Appearance.DisabledLayoutGroupCaption.Image = ((System.Drawing.Image)(resources.GetObject("noteDataLayoutControl.Appearance.DisabledLayoutGroupCaption.Image")));
            this.noteDataLayoutControl.Appearance.DisabledLayoutItem.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("noteDataLayoutControl.Appearance.DisabledLayoutItem.GradientMode")));
            this.noteDataLayoutControl.Appearance.DisabledLayoutItem.Image = ((System.Drawing.Image)(resources.GetObject("noteDataLayoutControl.Appearance.DisabledLayoutItem.Image")));
            this.noteDataLayoutControl.Controls.Add(this.SubjectTextEdit);
            this.noteDataLayoutControl.Controls.Add(this.NoteTextMemoEdit);
            this.noteDataLayoutControl.DataSource = this.noteBindingSource;
            this.noteDataLayoutControl.Name = "noteDataLayoutControl";
            this.noteDataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(389, 409, 250, 350);
            this.noteDataLayoutControl.Root = this.layoutControlGroup1;
            // 
            // SubjectTextEdit
            // 
            resources.ApplyResources(this.SubjectTextEdit, "SubjectTextEdit");
            this.SubjectTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.noteBindingSource, "Subject", true));
            this.dxValidationProvider.SetIconAlignment(this.SubjectTextEdit, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.SubjectTextEdit.Name = "SubjectTextEdit";
            this.SubjectTextEdit.Properties.AccessibleDescription = resources.GetString("SubjectTextEdit.Properties.AccessibleDescription");
            this.SubjectTextEdit.Properties.AccessibleName = resources.GetString("SubjectTextEdit.Properties.AccessibleName");
            this.SubjectTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("SubjectTextEdit.Properties.AutoHeight")));
            this.SubjectTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("SubjectTextEdit.Properties.Mask.AutoComplete")));
            this.SubjectTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("SubjectTextEdit.Properties.Mask.BeepOnError")));
            this.SubjectTextEdit.Properties.Mask.EditMask = resources.GetString("SubjectTextEdit.Properties.Mask.EditMask");
            this.SubjectTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("SubjectTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.SubjectTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("SubjectTextEdit.Properties.Mask.MaskType")));
            this.SubjectTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("SubjectTextEdit.Properties.Mask.PlaceHolder")));
            this.SubjectTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("SubjectTextEdit.Properties.Mask.SaveLiteral")));
            this.SubjectTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("SubjectTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.SubjectTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("SubjectTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.SubjectTextEdit.Properties.NullValuePrompt = resources.GetString("SubjectTextEdit.Properties.NullValuePrompt");
            this.SubjectTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("SubjectTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.SubjectTextEdit.StyleController = this.noteDataLayoutControl;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider.SetValidationRule(this.SubjectTextEdit, conditionValidationRule1);
            // 
            // NoteTextMemoEdit
            // 
            resources.ApplyResources(this.NoteTextMemoEdit, "NoteTextMemoEdit");
            this.NoteTextMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.noteBindingSource, "NoteText", true));
            this.NoteTextMemoEdit.Name = "NoteTextMemoEdit";
            this.NoteTextMemoEdit.Properties.AccessibleDescription = resources.GetString("NoteTextMemoEdit.Properties.AccessibleDescription");
            this.NoteTextMemoEdit.Properties.AccessibleName = resources.GetString("NoteTextMemoEdit.Properties.AccessibleName");
            this.NoteTextMemoEdit.Properties.NullValuePrompt = resources.GetString("NoteTextMemoEdit.Properties.NullValuePrompt");
            this.NoteTextMemoEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("NoteTextMemoEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.NoteTextMemoEdit.StyleController = this.noteDataLayoutControl;
            // 
            // layoutControlGroup1
            // 
            resources.ApplyResources(this.layoutControlGroup1, "layoutControlGroup1");
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(729, 297);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            resources.ApplyResources(this.layoutControlGroup2, "layoutControlGroup2");
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForSubject,
            this.ItemForNoteText});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(709, 277);
            // 
            // ItemForSubject
            // 
            this.ItemForSubject.Control = this.SubjectTextEdit;
            resources.ApplyResources(this.ItemForSubject, "ItemForSubject");
            this.ItemForSubject.Location = new System.Drawing.Point(0, 0);
            this.ItemForSubject.Name = "ItemForSubject";
            this.ItemForSubject.Size = new System.Drawing.Size(709, 24);
            this.ItemForSubject.TextSize = new System.Drawing.Size(24, 14);
            // 
            // ItemForNoteText
            // 
            this.ItemForNoteText.Control = this.NoteTextMemoEdit;
            resources.ApplyResources(this.ItemForNoteText, "ItemForNoteText");
            this.ItemForNoteText.Location = new System.Drawing.Point(0, 24);
            this.ItemForNoteText.Name = "ItemForNoteText";
            this.ItemForNoteText.Size = new System.Drawing.Size(709, 253);
            this.ItemForNoteText.TextSize = new System.Drawing.Size(24, 14);
            // 
            // PutNoteChEdit
            // 
            resources.ApplyResources(this.PutNoteChEdit, "PutNoteChEdit");
            this.PutNoteChEdit.Name = "PutNoteChEdit";
            this.PutNoteChEdit.Properties.AccessibleDescription = resources.GetString("PutNoteChEdit.Properties.AccessibleDescription");
            this.PutNoteChEdit.Properties.AccessibleName = resources.GetString("PutNoteChEdit.Properties.AccessibleName");
            this.PutNoteChEdit.Properties.AutoHeight = ((bool)(resources.GetObject("PutNoteChEdit.Properties.AutoHeight")));
            this.PutNoteChEdit.Properties.Caption = resources.GetString("PutNoteChEdit.Properties.Caption");
            this.PutNoteChEdit.Properties.DisplayValueChecked = resources.GetString("PutNoteChEdit.Properties.DisplayValueChecked");
            this.PutNoteChEdit.Properties.DisplayValueGrayed = resources.GetString("PutNoteChEdit.Properties.DisplayValueGrayed");
            this.PutNoteChEdit.Properties.DisplayValueUnchecked = resources.GetString("PutNoteChEdit.Properties.DisplayValueUnchecked");
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.PutNoteDateToModifyEdit);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.PutNoteChEdit);
            this.panel1.Name = "panel1";
            // 
            // PutNoteDateToModifyEdit
            // 
            resources.ApplyResources(this.PutNoteDateToModifyEdit, "PutNoteDateToModifyEdit");
            this.PutNoteDateToModifyEdit.Name = "PutNoteDateToModifyEdit";
            this.PutNoteDateToModifyEdit.Properties.AccessibleDescription = resources.GetString("PutNoteDateToModifyEdit.Properties.AccessibleDescription");
            this.PutNoteDateToModifyEdit.Properties.AccessibleName = resources.GetString("PutNoteDateToModifyEdit.Properties.AccessibleName");
            this.PutNoteDateToModifyEdit.Properties.AutoHeight = ((bool)(resources.GetObject("PutNoteDateToModifyEdit.Properties.AutoHeight")));
            this.PutNoteDateToModifyEdit.Properties.Caption = resources.GetString("PutNoteDateToModifyEdit.Properties.Caption");
            this.PutNoteDateToModifyEdit.Properties.DisplayValueChecked = resources.GetString("PutNoteDateToModifyEdit.Properties.DisplayValueChecked");
            this.PutNoteDateToModifyEdit.Properties.DisplayValueGrayed = resources.GetString("PutNoteDateToModifyEdit.Properties.DisplayValueGrayed");
            this.PutNoteDateToModifyEdit.Properties.DisplayValueUnchecked = resources.GetString("PutNoteDateToModifyEdit.Properties.DisplayValueUnchecked");
            // 
            // NoteDetailForm
            // 
            this.AcceptButton = this.saveButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.noteDataLayoutControl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NoteDetailForm";
            ((System.ComponentModel.ISupportInitialize)(this.noteDataLayoutControl)).EndInit();
            this.noteDataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SubjectTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteTextMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNoteText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PutNoteChEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PutNoteDateToModifyEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl noteDataLayoutControl;
        private System.Windows.Forms.BindingSource noteBindingSource;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNoteText;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSubject;
        private DevExpress.XtraEditors.SimpleButton cancelButton;
        private DevExpress.XtraEditors.SimpleButton saveButton;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider;
        private DevExpress.XtraEditors.TextEdit SubjectTextEdit;
        private DevExpress.XtraEditors.MemoEdit NoteTextMemoEdit;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.CheckEdit PutNoteChEdit;
        private DevExpress.XtraEditors.CheckEdit PutNoteDateToModifyEdit;
    }
}
