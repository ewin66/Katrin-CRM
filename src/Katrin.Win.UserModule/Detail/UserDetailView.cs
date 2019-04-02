using System;
using System.Linq;
using Katrin.AppFramework.MetadataServiceReference;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework.WinForms.Messages;
using DevExpress.XtraEditors.DXErrorProvider;
using Katrin.Win.UserModule.Properties;
using DevExpress.XtraEditors;
using System.Collections;
using System.Collections.Generic;
using ICSharpCode.Core;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using Katrin.AppFramework.Security;

namespace Katrin.Win.UserModule.Detail
{
    public partial class UserDetailView : DetailView, IUserDetailView
    {
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

        public void SetUserNameFocused()
        {
            UserNameTextEdit.Focus();
        }
        public ArrayList SelectedRoles
        {
            get { return roleLookUpEdit.Properties.GridSelection.Selection; }
        }

        public void BindRole(List<Guid> selectedRoles)
        {
            if (!AuthorizationManager.CheckAccess("User", "Write"))
                roleLookUpEdit.Enabled = false;
            roleLookUpEdit.Properties.DisplayMember = "RoleName";
            roleLookUpEdit.Properties.BindDataAsync("Role", "RoleId", selectedRoles);
            roleLookUpEdit.Properties.View.OptionsSelection.MultiSelect = true;
        }

        public override void InitValidation()
        {
            SetValidationRule(UserNameTextEdit, ValidationRules.IsNotBlankRule(ItemForUserName.Text));
            _validationSort.Add(PasswordTextEdit.Name,string.Empty);
            _validationSort.Add(ConfirmPasswordTextEdit.Name, string.Empty);
            SetValidationRule(LastNameTextEdit, ValidationRules.IsNotBlankRule(ItemForLastName.Text));
            SetValidationRule(FirstNameTextEdit, ValidationRules.IsNotBlankRule(ItemForFirstName.Text));
        }

        public override bool ValidateData()
        {
            return true;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LastNameTextEdit.EditValueChanged -= LastNameTextEdit_EditValueChanged;
            FirstNameTextEdit.EditValueChanged -= FirstNameTextEdit_EditValueChanged;
            LastNameTextEdit.EditValueChanged += LastNameTextEdit_EditValueChanged;
            FirstNameTextEdit.EditValueChanged += FirstNameTextEdit_EditValueChanged;
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
            if (!string.IsNullOrEmpty(PasswordTextEdit.Text) || !string.IsNullOrEmpty(ConfirmPasswordTextEdit.Text))
            {
                SetValidationRule(PasswordTextEdit, passwordLengthRule);
                var passwordCompareRule = new CompareAgainstControlValidationRule()
                                              {
                                                  CompareControlOperator = CompareControlOperator.Equals,
                                                  Control = PasswordTextEdit,
                                                  ErrorText = ResourceService.GetString("ConfirmPasswordNotMatch"),
                                                  ErrorType = ErrorType.Warning
                                              };
                SetValidationRule(ConfirmPasswordTextEdit, passwordCompareRule);
            }

            return base.ValidateData();
        }

        public void ClearPassword()
        {
            SetValidationRule(PasswordTextEdit, null);
            SetValidationRule(ConfirmPasswordTextEdit, null);
            ConfirmPasswordTextEdit.Text = string.Empty;
            PasswordTextEdit.Text = string.Empty;
        }
        public bool HasSave
        {
            get;
            set;
        }
        private void PasswordTextEdit_TextChanged(object sender, EventArgs e)
        {
            if (HasSave)
                PasswordTextEdit.Text = "";
        }


        public override void Bind(object entity)
        {
            base.Bind(entity);
           
        }

        private void LastNameTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            BindFullName();
        }

        private void FirstNameTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            BindFullName();
        }

        private void BindFullName()
        {
            
            var user = (Katrin.Domain.Impl.User)EntityBindingSource.Current;
            if(!string.IsNullOrEmpty(LastNameTextEdit.Text))
                user.LastName = LastNameTextEdit.Text;
            if (!string.IsNullOrEmpty(FirstNameTextEdit.Text))
                user.FirstName = FirstNameTextEdit.Text;
            
            string[] arrCombine = { string.Empty," ",","};
            var items = new List<ComboBoxItem>();
            for (int c = 0; c < arrCombine.Length; c++)
            {
                string fullName = LastNameTextEdit.Text + arrCombine[c] + FirstNameTextEdit.Text;
                fullName = fullName.TrimEnd(arrCombine[c].ToCharArray()).TrimStart(arrCombine[c].ToCharArray());
                if (!items.Any(l => l.Value.ToString() == fullName) && !string.IsNullOrEmpty(fullName))
                    items.Add(new ComboBoxItem() { Value = fullName });
                fullName = FirstNameTextEdit.Text + arrCombine[c] + LastNameTextEdit.Text;
                fullName = fullName.TrimEnd(arrCombine[c].ToCharArray()).TrimStart(arrCombine[c].ToCharArray());
                if (!items.Any(l => l.Value.ToString() == fullName) && !string.IsNullOrEmpty(fullName))
                    items.Add(new ComboBoxItem() { Value = fullName });
            }
            FullNameLookUp.Properties.Items.Clear();
            FullNameLookUp.Properties.Items.AddRange(items);
            FullNameLookUp.Properties.NullText = string.Empty;
            if (items.Count > 0 && !items.Select(c => c.Value).Contains(FullNameLookUp.Text))
                FullNameLookUp.Text = items.First().Value.ToString();
            else if (items.Count == 0)
                FullNameLookUp.Text = string.Empty;
        }
    }

    public class PasswordLengthRule : ValidationRule
    {
        public PasswordLengthRule()
        {
            ErrorText = ResourceService.GetString("PasswordLengthValidation");
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
