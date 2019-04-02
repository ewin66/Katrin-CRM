using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Collections.Generic;
using System.Collections;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.Data;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework;
namespace Katrin.Win.RoleModule.Detail
{
    public class RoleDetailController : ObjectDetailController
    {
        public override string ObjectName
        {
            get
            {
                return "Role";
            }
        }

        private RoleViewModel _roleViewModel = new RoleViewModel();

        protected override bool OnSaving()
        {
            
            SetRole(_roleViewModel);
            return base.OnSaving();
        }

        protected override object GetEntity()
        {
            var entity = _objectSpace.GetOrNew(ObjectName, ObjectId, "RolePrivileges");
            return entity;
        }

        protected override void BindData(object objectInfo)
        {
            _roleViewModel = GetRoleViewModel();
            _detailView.Bind(_roleViewModel);
        }

        private RoleViewModel GetRoleViewModel()
        {
            var role = (Katrin.Domain.Impl.Role)ObjectEntity;
            var roleViewModel = new RoleViewModel
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                Description = role.Description
            };

            IList rolePrivilegeList = role.RolePrivileges;
            var privilegeEntities = _objectSpace.GetObjects("PrivilegeEntity");
            var privileges = _objectSpace.GetObjects("Privilege");

            var viewModelList = new Dictionary<string, EntityViewModel>();

            foreach (var privilegeEntity in privilegeEntities)
            {
                var privilege = ConvertData.Convert<Katrin.Domain.Impl.PrivilegeEntity>(privilegeEntity);
                var selectedEntityId = privilege.PrivilegeEntityId;
                Guid privilegeId = privilege.PrivilegeId;
                string entityName = privilege.EntityName;

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
                var privilegeList = privileges.AsQueryable().Where("PrivilegeId = @0", privilegeId)._First();
                var rolePrivilege = ConvertData.Convert<Katrin.Domain.Impl.Privilege>(privilegeList);
                
                var privilegeViewModel = new PrivilegeViewModel
                {
                    PrivilegeId = rolePrivilege.PrivilegeId,
                    PrivilegeName = rolePrivilege.Name,
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
            var role = (Katrin.Domain.Impl.Role)ObjectEntity;
            role.RoleName = roleViewModel.RoleName;
            role.Description = roleViewModel.Description;

            IList rolePrivilegeList = role.RolePrivileges;

            foreach (var privilege in roleViewModel.SelectedPrivileges)
            {
                var rolePrivilege = new Katrin.Domain.Impl.RolePrivilege();
                var rPrivilege = ConvertData.Convert<Katrin.Domain.Impl.RolePrivilege>(rolePrivilege);

                rPrivilege.RolePrivilegeId = Guid.NewGuid();
                rPrivilege.PrivilegeId = privilege.PrivilegeId;
                rPrivilege.RoleId = ObjectId;
                rolePrivilegeList.Add(rPrivilege);
            }
        }
    }
}
