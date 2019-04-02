using System;
namespace Katrin.Win.NoteModule.Note
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
            noteBindingSource.DataSource = null;
            GC.Collect();
            //GC.SuppressFinalize(this);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteDetailForm));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.noteDataLayoutControl = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.SubjectTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.noteBindingSource = new System.Windows.Forms.BindingSource();
            this.NoteTextMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForSubject = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForNoteText = new DevExpress.XtraLayout.LayoutControlItem();
            this.PutNoteChEdit = new DevExpress.XtraEditors.CheckEdit();
            this.cancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.saveButton = new DevExpress.XtraEditors.SimpleButton();
            this.dxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
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
            this.noteDataLayoutControl.Controls.Add(this.SubjectTextEdit);
            this.noteDataLayoutControl.Controls.Add(this.NoteTextMemoEdit);
            this.noteDataLayoutControl.DataSource = this.noteBindingSource;
            resources.ApplyResources(this.noteDataLayoutControl, "noteDataLayoutControl");
            this.noteDataLayoutControl.Name = "noteDataLayoutControl";
            this.noteDataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(389, 409, 250, 350);
            this.noteDataLayoutControl.Root = this.layoutControlGroup1;
            // 
            // SubjectTextEdit
            // 
            this.SubjectTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.noteBindingSource, "Subject", true));
            this.dxValidationProvider.SetIconAlignment(this.SubjectTextEdit, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            resources.ApplyResources(this.SubjectTextEdit, "SubjectTextEdit");
            this.SubjectTextEdit.Name = "SubjectTextEdit";
            this.SubjectTextEdit.StyleController = this.noteDataLayoutControl;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider.SetValidationRule(this.SubjectTextEdit, conditionValidationRule1);
            // 
            // NoteTextMemoEdit
            // 
            this.NoteTextMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.noteBindingSource, "NoteText", true));
            resources.ApplyResources(this.NoteTextMemoEdit, "NoteTextMemoEdit");
            this.NoteTextMemoEdit.Name = "NoteTextMemoEdit";
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(625, 276);
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
            this.layoutControlGroup2.Size = new System.Drawing.Size(605, 256);
            // 
            // ItemForSubject
            // 
            this.ItemForSubject.Control = this.SubjectTextEdit;
            resources.ApplyResources(this.ItemForSubject, "ItemForSubject");
            this.ItemForSubject.Location = new System.Drawing.Point(0, 0);
            this.ItemForSubject.Name = "ItemForSubject";
            this.ItemForSubject.Size = new System.Drawing.Size(605, 24);
            this.ItemForSubject.TextSize = new System.Drawing.Size(48, 13);
            // 
            // ItemForNoteText
            // 
            this.ItemForNoteText.Control = this.NoteTextMemoEdit;
            resources.ApplyResources(this.ItemForNoteText, "ItemForNoteText");
            this.ItemForNoteText.Location = new System.Drawing.Point(0, 24);
            this.ItemForNoteText.Name = "ItemForNoteText";
            this.ItemForNoteText.Size = new System.Drawing.Size(605, 232);
            this.ItemForNoteText.TextSize = new System.Drawing.Size(48, 13);
            // 
            // PutNoteChEdit
            // 
            resources.ApplyResources(this.PutNoteChEdit, "PutNoteChEdit");
            this.PutNoteChEdit.Name = "PutNoteChEdit";
            this.PutNoteChEdit.Properties.Caption = resources.GetString("PutNoteChEdit.Properties.Caption");
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
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
            this.panel1.Controls.Add(this.PutNoteDateToModifyEdit);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.PutNoteChEdit);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // PutNoteDateToModifyEdit
            // 
            resources.ApplyResources(this.PutNoteDateToModifyEdit, "PutNoteDateToModifyEdit");
            this.PutNoteDateToModifyEdit.Name = "PutNoteDateToModifyEdit";
            this.PutNoteDateToModifyEdit.Properties.Caption = resources.GetString("PutNoteDateToModifyEdit.Properties.Caption");
            // 
            // NoteDetailForm
            // 
            this.AcceptButton = this.saveButton;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.noteDataLayoutControl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NoteDetailForm";
            this.Load += new System.EventHandler(this.NoteDetailForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NoteDetailForm_KeyUp);
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
