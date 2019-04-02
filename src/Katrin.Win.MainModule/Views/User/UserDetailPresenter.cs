using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Katrin.Win.Common.Core;
using Microsoft.Practices.CompositeUI.Commands;
using Katrin.Win.Common;
using System.Collections;
using Katrin.Win.Common.Controls;
namespace Katrin.Win.MainModule.Views.User
{
    public class UserDetailPresenter : EntityDetailPresenter<IUserDetailView>
    {
        public UserDetailPresenter()
        {
            EntityName = "User";
        }
        #region Save And SaveAndClose Mothod
        private string oldPassword;
        protected override void OnSaving()
        {
            base.OnSaving();
            string password = DynamicEntity.Password;
            if (!string.IsNullOrEmpty(password))
            {
                password = BCrypt.Net.BCrypt.HashPassword(password, 4);
                oldPassword = password;
            }
            if (oldPassword == null) oldPassword = password;
            DynamicEntity.Password = oldPassword;
            View.HasSave = true;
            string firstName = DynamicEntity.FirstName;
            string lastName = DynamicEntity.LastName;
            DynamicEntity.FullName = lastName + firstName;
        }

        protected override void OnSaved()
        {
            base.OnSaved();
            DynamicEntity.Password = string.Empty;
            View.ClearPassword();
        }

        [CommandHandler("SelectRole")]
        public void OnUserRole(object sender, EventArgs e)
        {
            string key = EntityId + ":UserRoleListWorkItem";
            var detailView = WorkItem.Items.Get<UserRoleListView>(key);
            IEnumerable userRoleList = DynamicEntity.UserRoles;
            if (detailView == null)
            {
                var userRoles = (from object userRoleEntity in userRoleList
                                 select new SysBits.DynamicProxies.DynamicProxy(userRoleEntity)
                                     into dynamicEntity
                                     select new UserRole
                                                {
                                                    Id = ((dynamic)dynamicEntity).Id,
                                                    RoleID = ((dynamic)dynamicEntity).RoleId,
                                                    UserId = ((dynamic)dynamicEntity).UserId
                                                }).ToList();

                WorkItem.State["UserRoleList"] = userRoles;
                detailView = WorkItem.Items.AddNew<UserRoleListView>(key);
            }
            else
            {
                detailView.ShowDialog();
            }

            if (detailView.DialogResult == DialogResult.OK)
            {
                SetUserRoleList();
            }
        }

        private void SetUserRoleList()
        {
            var userRoleListResult = WorkItem.State["UserRoleList"] as List<UserRole>;

            if (userRoleListResult == null) return;
            IList userRoleListAble = DynamicEntity.UserRoles;
            userRoleListAble.Clear();
            var userRoleType = DynamicTypeBuilder.Instance.GetDynamicType("UserRole");
            foreach (var userRole in userRoleListResult)
            {
                var userRoleEntity = Activator.CreateInstance(userRoleType);
                dynamic dynamicEntity = new SysBits.DynamicProxies.DynamicProxy(userRoleEntity);
                dynamicEntity.Id = userRole.Id;
                dynamicEntity.RoleId = userRole.RoleID;
                dynamicEntity.UserId = EntityId;
                userRoleListAble.Add(userRoleEntity);
            }
        }

        
        #endregion

        protected override void OnViewSet()
        {
            base.OnViewSet();
            RegisterCommand("DetailGeneralPageGroup", "SelectRole", "Role", "", "Role");
        }

        protected override void BindData(object data)
        {
            oldPassword = DynamicEntity.Password;
            DynamicEntity.Password = string.Empty;
            base.BindData(data);
        }

        private void RegisterCommand(string groupName, string commandName, string imageName, string overlay, string caption)
        {
            var localizedCaption = Properties.Resources.ResourceManager.GetString(caption);
            var buttonItem = new BarButtonItemEx(imageName, overlay) { Caption = localizedCaption };
            if (WorkItem.Commands[commandName] != null)
            {
                WorkItem.Commands[commandName].AddInvoker(buttonItem, "ItemClick");
            }
            buttonItem.Name = commandName;
            WorkItem.UIExtensionSites[groupName].Add(buttonItem);
        }

        protected override object GetEntity()
        {
            var entity = DynamicDataServiceContext.GetOrNew(EntityName, EntityId, "UserRoles,CreatedBy,ModifiedBy");
            return entity;
        }
    }
}
