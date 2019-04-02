using System;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Collections.Generic;
using System.Windows.Forms;
using Katrin.Win.Common.Core;
using Katrin.Win.MainModule.Properties;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeUI.SmartParts;
using Katrin.Win.Common.MetadataServiceReference;

namespace Katrin.Win.MainModule.Views.User
{
    [SmartPart]
    public partial class UserDetailView : AbstractDetailView, IUserDetailView
    {
        private UserDetailPresenter _presenter;

        [CreateNew]
        public UserDetailPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        public UserDetailView()
        {
            InitializeComponent();

        }

        public override void InitEditors(Entity entity)
        {
            base.InitEditors(entity);
            DepartmentIdLookUpEdit.BindLookupList(entity, true);
            JobLevelLookUpEdit.BindPickList(entity);
        }
        public override void InitValidation()
        {
            SetValidationRule(UserNameTextEdit, ValidationRules.IsNotBlankRule(ItemForUserName.Text));
            SetValidationRule(FirstNameTextEdit, ValidationRules.IsNotBlankRule(ItemForFirstName.Text));
            SetValidationRule(LastNameTextEdit, ValidationRules.IsNotBlankRule(ItemForLastName.Text));
        }

        public bool ValidateData(EntityDetailWorkingMode WorkingMode)
        {
            var user = EntityBindingSource.Current;
            var passwordLengthRule = new PasswordLengthRule();
            Guid userId = Guid.Parse(user.GetType().GetProperty("UserId").GetValue(user,null).ToString());
            if (WorkingMode == EntityDetailWorkingMode.Add)
            {
                SetValidationRule(PasswordTextEdit, ValidationRules.IsNotBlankRule(ItemForPassword.Text));
                SetValidationRule(PasswordTextEdit, passwordLengthRule);
                SetValidationRule(ConfirmPasswordTextEdit, ValidationRules.IsNotBlankRule(ItemForConfirmPassword.Text));
            }
            if (!string.IsNullOrEmpty(PasswordTextEdit.Text))
            {
                SetValidationRule(PasswordTextEdit, passwordLengthRule);
                var passwordCompareRule = new CompareAgainstControlValidationRule()
                                              {
                                                  CompareControlOperator = CompareControlOperator.Equals,
                                                  Control = PasswordTextEdit,
                                                  ErrorText = Resources.ConfirmPasswordNotMatch,
                                                  ErrorType = ErrorType.Warning
                                              };
                SetValidationRule(ConfirmPasswordTextEdit, passwordCompareRule);
            }

            return ValidationProvider.Validate();
        }

        public void ClearPassword()
        {
            ConfirmPasswordTextEdit.Text = string.Empty;
        }
        public bool HasSave
        {
            get;
            set;
        }
        private void PasswordTextEdit_TextChanged(object sender, EventArgs e)
        {
            if(HasSave)
            PasswordTextEdit.Text = "";
        }
    }

    public class PasswordLengthRule : ValidationRule
    {
        public PasswordLengthRule()
        {
            ErrorText = Resources.PasswordLengthValidation;
            ErrorType = ErrorType.Warning;
        }

        public override bool Validate(System.Windows.Forms.Control control, object value)
        {
            var textEdit = control as TextEdit;
            return textEdit != null && !string.IsNullOrEmpty(textEdit.Text) && textEdit.Text.Length > 5;
        }
    }

    public class RoleModel
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }

    public class UserRole
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleID { get; set; }
    }
}
