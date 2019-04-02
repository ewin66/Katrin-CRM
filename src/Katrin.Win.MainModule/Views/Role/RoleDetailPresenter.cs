using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Windows.Forms;
using Katrin.Win.Infrastructure;
using Microsoft.Practices.CompositeUI.Commands;
using Katrin.Win.Common;
using Katrin.Win.Common.Core;
using Microsoft.Practices.CompositeUI;
using Katrin.Win.Common.MetadataServiceReference;
using System.Collections;

namespace Katrin.Win.MainModule.Views.Role
{
    public class RoleDetailPresenter : EntityDetailPresenter<IRoleDetailView>
    {
        public RoleDetailPresenter()
        {
            EntityName = "Role";
        }
        private RoleViewModel _roleViewModel = new RoleViewModel();
        
        protected override void OnSaving()
        {
            base.OnSaving();
            SetRole(_roleViewModel);
        }

        protected override object GetEntity()
        {
            var entity = DynamicDataServiceContext.GetOrNew(EntityName, EntityId, "RolePrivileges");
            return entity;
        }

        protected override void BindData(object data)
        {
            _roleViewModel = GetRoleViewModel();
            View.Bind(_roleViewModel);
        }

        private RoleViewModel GetRoleViewModel()
        {
            var roleViewModel = new RoleViewModel
                                    {
                                        RoleId = DynamicEntity.RoleId,
                                        RoleName = DynamicEntity.RoleName,
                                        Description = DynamicEntity.Description
                                    };

            IList rolePrivilegeList = DynamicEntity.RolePrivileges;
            var privilegeEntities = DynamicDataServiceContext.GetObjects("PrivilegeEntity");
            var privileges = DynamicDataServiceContext.GetObjects("Privilege");

            var viewModelList = new Dictionary<string, EntityViewModel>();

            foreach (var privilegeEntity in privilegeEntities)
            {
                dynamic dynamicEntity = new SysBits.DynamicProxies.DynamicProxy(privilegeEntity);
                var selectedEntityId = dynamicEntity.PrivilegeEntityId;
                Guid privilegeId = dynamicEntity.PrivilegeId;
                string entityName = dynamicEntity.EntityName;

                EntityViewModel entityViewModel;
                if (viewModelList.ContainsKey(entityName))
                {
                    entityViewModel = viewModelList[entityName];
                }
                else
                {
                    entityViewModel = new EntityViewModel()
                                          {
                                              EntityId = selectedEntityId,
                                              Name = entityName
                                          };
                    roleViewModel.SelectedEntities.Add(entityViewModel);
                    viewModelList.Add(entityName, entityViewModel);
                }

                var privilege = privileges.AsQueryable().Where("PrivilegeId = @0", privilegeId)._First();
                dynamic dynamicPrivilege = new SysBits.DynamicProxies.DynamicProxy(privilege);

                var privilegeViewModel = new PrivilegeViewModel
                {
                    PrivilegeId =dynamicPrivilege.PrivilegeId,
                    PrivilegeName = dynamicPrivilege.Name,
                    Selected = SelectedPrivilege(rolePrivilegeList, privilegeId)
                };
                entityViewModel.Privileges.Add(privilegeViewModel);
            }

            return roleViewModel;
        }

        private bool SelectedPrivilege(IList rolePrivilegeList, Guid privilegeId)
        {
            var rolePrivilege = rolePrivilegeList.AsQueryable().Where("PrivilegeId = @0", privilegeId)._First();
            return rolePrivilege != null;
        }

        private void SetRole(RoleViewModel roleViewModel)
        {
            var rolePrivilegeType = DynamicTypeBuilder.Instance.GetDynamicType("RolePrivilege");

            DynamicEntity.RoleName = roleViewModel.RoleName;
            DynamicEntity.Description = roleViewModel.Description;

            IList rolePrivilegeList = DynamicEntity.RolePrivileges;

            foreach (var privilege in roleViewModel.SelectedPrivileges)
            {
                var rolePrivilege = Activator.CreateInstance(rolePrivilegeType);
                dynamic dynamicPrivilege = new SysBits.DynamicProxies.DynamicProxy(rolePrivilege);
                dynamicPrivilege.RolePrivilegeId = Guid.NewGuid();
                dynamicPrivilege.PrivilegeId = privilege.PrivilegeId;
                dynamicPrivilege.RoleId = EntityId;
                rolePrivilegeList.Add(rolePrivilege);
            }
        }
    }
}
