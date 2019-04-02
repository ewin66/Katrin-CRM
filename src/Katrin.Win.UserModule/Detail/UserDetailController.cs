using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.Data;
using Katrin.AppFramework;
using Katrin.AppFramework.WinForms;
using Katrin.AppFramework.WinForms.Messages;
using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;
using ICSharpCode.Core;
using System.Windows.Forms;

namespace Katrin.Win.UserModule.Detail
{
    public class UserDetailController : ObjectDetailController
    {

        private IUserDetailView _userDetailView;
        public override string ObjectName
        {
            get
            {
                return "User";
            }
        }
        private string oldPassword;
        protected override bool OnSaving()
        {
            if (!_userDetailView.ValidateData(WorkingMode)) return false;
            var user = (Katrin.Domain.Impl.User)ObjectEntity;
            
            string userName = string.Empty;
            userName = user.UserName;
            var filter = new BinaryOperator("UserName", userName) &
                         new BinaryOperator("UserId", user.UserId, BinaryOperatorType.NotEqual);
            var existUsers = _objectSpace.GetObjectQuery(ObjectName, null,filter,true);
            int count = existUsers.Count();
            if (count > 0)
            {
                XtraMessageBox.Show(StringParser.Parse("UserExisted"),
                StringParser.Parse("Katrin"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
                _userDetailView.SetUserNameFocused();
                return false;
            }
            
            string password = user.Password;
            if (!string.IsNullOrEmpty(password))
            {
                password = BCrypt.Net.BCrypt.HashPassword(password, 4);
                oldPassword = password;
            }
            if (oldPassword == null) oldPassword = password;
            _userDetailView.HasSave = true;
            Katrin.Domain.Impl.User nullUser = ConvertData.Convert<Katrin.Domain.Impl.User>(ObjectEntity);
            nullUser.Password = string.Empty;
            BindData(nullUser);
            user.Password = oldPassword;
            SetUserRole();
            return true;
        }

        protected override void OnSaved()
        {
            base.OnSaved();
            var user = (Katrin.Domain.Impl.User)ObjectEntity;
            user.Password = string.Empty;
            _userDetailView.ClearPassword();
            BindData(ObjectEntity);
            _userDetailView.HasSave = false;
        }

        protected override object GetEntity()
        {
            var entity = (Katrin.Domain.Impl.User)_objectSpace.GetOrNew(ObjectName, ObjectId, "UserRoles,CreatedBy,ModifiedBy");
            oldPassword = entity.Password;
            entity.Password = string.Empty;
            return entity;
        }
        private void SetUserRole()
        {
            if (_userDetailView.SelectedRoles != null)
            {
                var user = (Katrin.Domain.Impl.User)ObjectEntity;
                user.UserRoles.Clear();
                foreach (var selectedRole in _userDetailView.SelectedRoles)
                {
                    var role = ConvertData.Convert<Katrin.Domain.Impl.Role>(selectedRole);
                    var userRole = new Katrin.Domain.Impl.UserRole();
                    userRole.Id = Guid.NewGuid();
                    userRole.UserId = ObjectId;
                    userRole.RoleId = role.RoleId;
                    user.UserRoles.Add(userRole);
                }
            }
        }
        protected override void OnViewSet()
        {
            if (!(_detailView is IUserDetailView)) return;
            _userDetailView = (IUserDetailView)_detailView;
            base.OnViewSet();
            var user = (Katrin.Domain.Impl.User)ObjectEntity;
            var userRoles = user.UserRoles;
            var selectedRoles = new List<Guid>();
            foreach (var userRole in userRoles)
            {
                selectedRoles.Add(userRole.RoleId ?? Guid.Empty);
            }
            _userDetailView.BindRole(selectedRoles);
        }

       
    }
}
