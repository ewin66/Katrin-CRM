namespace Katrin.Win
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.loginButton = new DevExpress.XtraEditors.SimpleButton();
            this.cancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.userNameLabel = new DevExpress.XtraEditors.LabelControl();
            this.userNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.passwordLabel = new DevExpress.XtraEditors.LabelControl();
            this.passwordTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.serverTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.autoLoginCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.rememberPasswordCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.serviceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.userNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoLoginCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rememberPasswordCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            resources.ApplyResources(this.loginButton, "loginButton");
            this.loginButton.Name = "loginButton";
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // userNameLabel
            // 
            resources.ApplyResources(this.userNameLabel, "userNameLabel");
            this.userNameLabel.Name = "userNameLabel";
            // 
            // userNameTextEdit
            // 
            resources.ApplyResources(this.userNameTextEdit, "userNameTextEdit");
            this.userNameTextEdit.Name = "userNameTextEdit";
            this.userNameTextEdit.Properties.MaxLength = 50;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Please type your user name.";
            this.dxValidationProvider1.SetValidationRule(this.userNameTextEdit, conditionValidationRule1);
            // 
            // passwordLabel
            // 
            resources.ApplyResources(this.passwordLabel, "passwordLabel");
            this.passwordLabel.Name = "passwordLabel";
            // 
            // passwordTextEdit
            // 
            resources.ApplyResources(this.passwordTextEdit, "passwordTextEdit");
            this.passwordTextEdit.Name = "passwordTextEdit";
            this.passwordTextEdit.Properties.MaxLength = 50;
            this.passwordTextEdit.Properties.UseSystemPasswordChar = true;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Please type your password.";
            this.dxValidationProvider1.SetValidationRule(this.passwordTextEdit, conditionValidationRule2);
            // 
            // marqueeProgressBarControl1
            // 
            resources.ApplyResources(this.marqueeProgressBarControl1, "marqueeProgressBarControl1");
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            // 
            // serverTextEdit
            // 
            resources.ApplyResources(this.serverTextEdit, "serverTextEdit");
            this.serverTextEdit.Name = "serverTextEdit";
            // 
            // labelControl1
            // 
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // pictureEdit1
            // 
            resources.ApplyResources(this.pictureEdit1, "pictureEdit1");
            this.pictureEdit1.EditValue = global::Katrin.Win.Properties.Resources.login;
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            // 
            // autoLoginCheckEdit
            // 
            resources.ApplyResources(this.autoLoginCheckEdit, "autoLoginCheckEdit");
            this.autoLoginCheckEdit.Name = "autoLoginCheckEdit";
            this.autoLoginCheckEdit.Properties.Caption = resources.GetString("autoLoginCheckEdit.Properties.Caption");
            // 
            // rememberPasswordCheckEdit
            // 
            resources.ApplyResources(this.rememberPasswordCheckEdit, "rememberPasswordCheckEdit");
            this.rememberPasswordCheckEdit.Name = "rememberPasswordCheckEdit";
            this.rememberPasswordCheckEdit.Properties.Caption = resources.GetString("rememberPasswordCheckEdit.Properties.Caption");
            // 
            // serviceTextEdit
            // 
            resources.ApplyResources(this.serviceTextEdit, "serviceTextEdit");
            this.serviceTextEdit.Name = "serviceTextEdit";
            // 
            // labelControl2
            // 
            resources.ApplyResources(this.labelControl2, "labelControl2");
            this.labelControl2.Name = "labelControl2";
            // 
            // LoginForm
            // 
            this.AcceptButton = this.loginButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.serviceTextEdit);
            this.Controls.Add(this.rememberPasswordCheckEdit);
            this.Controls.Add(this.autoLoginCheckEdit);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.serverTextEdit);
            this.Controls.Add(this.marqueeProgressBarControl1);
            this.Controls.Add(this.passwordTextEdit);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userNameTextEdit);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.pictureEdit1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)(this.userNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoLoginCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rememberPasswordCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton loginButton;
        private DevExpress.XtraEditors.SimpleButton cancelButton;
        private DevExpress.XtraEditors.LabelControl userNameLabel;
        private DevExpress.XtraEditors.TextEdit userNameTextEdit;
        private DevExpress.XtraEditors.LabelControl passwordLabel;
        private DevExpress.XtraEditors.TextEdit passwordTextEdit;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.TextEdit serverTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit autoLoginCheckEdit;
        private DevExpress.XtraEditors.CheckEdit rememberPasswordCheckEdit;
        private DevExpress.XtraEditors.TextEdit serviceTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}
