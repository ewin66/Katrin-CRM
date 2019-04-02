using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Katrin.Win.Infrastructure;
using Katrin.Win.Common;
using Microsoft.Practices.CompositeUI;

namespace Katrin.Win.MainModule.Views.User
{
    public class UserRoleListPresenter : Presenter<IUserRoleListView>
    {
        public Guid UserId { get; set; }
        private IList<UserRole> _userRoleList = new List<UserRole>();

        private IDynamicDataServiceContext _dynamicDataServiceContext;

        protected IDynamicDataServiceContext DynamicDataServiceContext
        {
            get { return _dynamicDataServiceContext ?? (_dynamicDataServiceContext = new DynamicDataServiceContext()); }
        }

        protected override void OnViewSet()
        {
            //_userRoleList = View.UserRoleList;
            View.OK += ViewOK;
            View.OnClose += ViewClose;
            var list = GetRoleViewModel();
            View.BindRole(list);
            View.ShowView();
        }
        

        private List<RoleModel> GetRoleViewModel()
        {
            _userRoleList = WorkItem.State["UserRoleList"] as IList<UserRole>;
            var roleList = DynamicDataServiceContext.GetObjects("Role");
            List<RoleModel> roleLastList = new List<RoleModel>();
            foreach (var role in roleList)
            {
                RoleModel roleModel = new RoleModel();
                roleModel.RoleId = Guid.Parse(role.GetType().GetProperty("RoleId").GetValue(role,null).ToString());
                roleModel.RoleName = role.GetType().GetProperty("RoleName").GetValue(role, null).ToString();
                if (_userRoleList.Count > 0)
                {
                    roleModel.IsSelected = _userRoleList.Select(a => a.RoleID).ToList().Contains(roleModel.RoleId);
                    View.SelectedRoles.Add(roleModel.RoleId);
                }
                roleLastList.Add(roleModel);
            }
            return roleLastList;
        }

        private void SetUserRoles(List<Guid> selectRoleList)
        {
            _userRoleList.Clear();
            foreach (var selectRole in selectRoleList)
            {
                var userRole = new UserRole();
                userRole.Id = Guid.NewGuid();
                userRole.RoleID = selectRole;
                userRole.UserId = UserId;
                _userRoleList.Add(userRole);
            }
        }

        public void Close()
        {
            View.Close();
        }

        void ViewClose(object sender, EventArgs e)
        {

        }

        void ViewOK(object sender, EventArgs e)
        {
            View.PostEditors();
            SetUserRoles(View.SelectedRoles);
            WorkItem.State["UserRoleList"] = _userRoleList;
            View.Close();
        }
    }
}
