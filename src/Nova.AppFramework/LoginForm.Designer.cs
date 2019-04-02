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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
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
            ((System.ComponentModel.ISupportInitialize)(this.userNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoLoginCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rememberPasswordCheckEdit.Properties)).BeginInit();
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
            this.userNameTextEdit.Properties.AccessibleDescription = resources.GetString("userNameTextEdit.Properties.AccessibleDescription");
            this.userNameTextEdit.Properties.AccessibleName = resources.GetString("userNameTextEdit.Properties.AccessibleName");
            this.userNameTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("userNameTextEdit.Properties.AutoHeight")));
            this.userNameTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("userNameTextEdit.Properties.Mask.AutoComplete")));
            this.userNameTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("userNameTextEdit.Properties.Mask.BeepOnError")));
            this.userNameTextEdit.Properties.Mask.EditMask = resources.GetString("userNameTextEdit.Properties.Mask.EditMask");
            this.userNameTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("userNameTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.userNameTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("userNameTextEdit.Properties.Mask.MaskType")));
            this.userNameTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("userNameTextEdit.Properties.Mask.PlaceHolder")));
            this.userNameTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("userNameTextEdit.Properties.Mask.SaveLiteral")));
            this.userNameTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("userNameTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.userNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("userNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.userNameTextEdit.Properties.MaxLength = 50;
            this.userNameTextEdit.Properties.NullValuePrompt = resources.GetString("userNameTextEdit.Properties.NullValuePrompt");
            this.userNameTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("userNameTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "Please type your user name.";
            this.dxValidationProvider1.SetValidationRule(this.userNameTextEdit, conditionValidationRule3);
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
            this.passwordTextEdit.Properties.AccessibleDescription = resources.GetString("passwordTextEdit.Properties.AccessibleDescription");
            this.passwordTextEdit.Properties.AccessibleName = resources.GetString("passwordTextEdit.Properties.AccessibleName");
            this.passwordTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("passwordTextEdit.Properties.AutoHeight")));
            this.passwordTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("passwordTextEdit.Properties.Mask.AutoComplete")));
            this.passwordTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("passwordTextEdit.Properties.Mask.BeepOnError")));
            this.passwordTextEdit.Properties.Mask.EditMask = resources.GetString("passwordTextEdit.Properties.Mask.EditMask");
            this.passwordTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("passwordTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.passwordTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("passwordTextEdit.Properties.Mask.MaskType")));
            this.passwordTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("passwordTextEdit.Properties.Mask.PlaceHolder")));
            this.passwordTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("passwordTextEdit.Properties.Mask.SaveLiteral")));
            this.passwordTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("passwordTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.passwordTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("passwordTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.passwordTextEdit.Properties.MaxLength = 50;
            this.passwordTextEdit.Properties.NullValuePrompt = resources.GetString("passwordTextEdit.Properties.NullValuePrompt");
            this.passwordTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("passwordTextEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.passwordTextEdit.Properties.UseSystemPasswordChar = true;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Please type your password.";
            this.dxValidationProvider1.SetValidationRule(this.passwordTextEdit, conditionValidationRule1);
            // 
            // marqueeProgressBarControl1
            // 
            resources.ApplyResources(this.marqueeProgressBarControl1, "marqueeProgressBarControl1");
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Properties.AccessibleDescription = resources.GetString("marqueeProgressBarControl1.Properties.AccessibleDescription");
            this.marqueeProgressBarControl1.Properties.AccessibleName = resources.GetString("marqueeProgressBarControl1.Properties.AccessibleName");
            this.marqueeProgressBarControl1.Properties.AutoHeight = ((bool)(resources.GetObject("marqueeProgressBarControl1.Properties.AutoHeight")));
            // 
            // serverTextEdit
            // 
            resources.ApplyResources(this.serverTextEdit, "serverTextEdit");
            this.serverTextEdit.Name = "serverTextEdit";
            this.serverTextEdit.Properties.AccessibleDescription = resources.GetString("serverTextEdit.Properties.AccessibleDescription");
            this.serverTextEdit.Properties.AccessibleName = resources.GetString("serverTextEdit.Properties.AccessibleName");
            this.serverTextEdit.Properties.AutoHeight = ((bool)(resources.GetObject("serverTextEdit.Properties.AutoHeight")));
            this.serverTextEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("serverTextEdit.Properties.Mask.AutoComplete")));
            this.serverTextEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("serverTextEdit.Properties.Mask.BeepOnError")));
            this.serverTextEdit.Properties.Mask.EditMask = resources.GetString("serverTextEdit.Properties.Mask.EditMask");
            this.serverTextEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("serverTextEdit.Properties.Mask.IgnoreMaskBlank")));
            this.serverTextEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("serverTextEdit.Properties.Mask.MaskType")));
            this.serverTextEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("serverTextEdit.Properties.Mask.PlaceHolder")));
            this.serverTextEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("serverTextEdit.Properties.Mask.SaveLiteral")));
            this.serverTextEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("serverTextEdit.Properties.Mask.ShowPlaceHolders")));
            this.serverTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("serverTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.serverTextEdit.Properties.NullValuePrompt = resources.GetString("serverTextEdit.Properties.NullValuePrompt");
            this.serverTextEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("serverTextEdit.Properties.NullValuePromptShowForEmptyValue")));
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
            this.pictureEdit1.Properties.AccessibleDescription = resources.GetString("pictureEdit1.Properties.AccessibleDescription");
            this.pictureEdit1.Properties.AccessibleName = resources.GetString("pictureEdit1.Properties.AccessibleName");
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            // 
            // autoLoginCheckEdit
            // 
            resources.ApplyResources(this.autoLoginCheckEdit, "autoLoginCheckEdit");
            this.autoLoginCheckEdit.Name = "autoLoginCheckEdit";
            this.autoLoginCheckEdit.Properties.AccessibleDescription = resources.GetString("autoLoginCheckEdit.Properties.AccessibleDescription");
            this.autoLoginCheckEdit.Properties.AccessibleName = resources.GetString("autoLoginCheckEdit.Properties.AccessibleName");
            this.autoLoginCheckEdit.Properties.AutoHeight = ((bool)(resources.GetObject("autoLoginCheckEdit.Properties.AutoHeight")));
            this.autoLoginCheckEdit.Properties.Caption = resources.GetString("autoLoginCheckEdit.Properties.Caption");
            this.autoLoginCheckEdit.Properties.DisplayValueChecked = resources.GetString("autoLoginCheckEdit.Properties.DisplayValueChecked");
            this.autoLoginCheckEdit.Properties.DisplayValueGrayed = resources.GetString("autoLoginCheckEdit.Properties.DisplayValueGrayed");
            this.autoLoginCheckEdit.Properties.DisplayValueUnchecked = resources.GetString("autoLoginCheckEdit.Properties.DisplayValueUnchecked");
            // 
            // rememberPasswordCheckEdit
            // 
            resources.ApplyResources(this.rememberPasswordCheckEdit, "rememberPasswordCheckEdit");
            this.rememberPasswordCheckEdit.Name = "rememberPasswordCheckEdit";
            this.rememberPasswordCheckEdit.Properties.AccessibleDescription = resources.GetString("rememberPasswordCheckEdit.Properties.AccessibleDescription");
            this.rememberPasswordCheckEdit.Properties.AccessibleName = resources.GetString("rememberPasswordCheckEdit.Properties.AccessibleName");
            this.rememberPasswordCheckEdit.Properties.AutoHeight = ((bool)(resources.GetObject("rememberPasswordCheckEdit.Properties.AutoHeight")));
            this.rememberPasswordCheckEdit.Properties.Caption = resources.GetString("rememberPasswordCheckEdit.Properties.Caption");
            this.rememberPasswordCheckEdit.Properties.DisplayValueChecked = resources.GetString("rememberPasswordCheckEdit.Properties.DisplayValueChecked");
            this.rememberPasswordCheckEdit.Properties.DisplayValueGrayed = resources.GetString("rememberPasswordCheckEdit.Properties.DisplayValueGrayed");
            this.rememberPasswordCheckEdit.Properties.DisplayValueUnchecked = resources.GetString("rememberPasswordCheckEdit.Properties.DisplayValueUnchecked");
            // 
            // LoginForm
            // 
            this.AcceptButton = this.loginButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
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
    }
}
