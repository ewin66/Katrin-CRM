using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Core;
namespace Katrin.Win.MainModule.Views.Role
{
    public class RoleController : RecordListController<RoleListView, RoleDetailView>
    {
        protected override string EntityName
        {
            get { return "Role"; }
        }

        protected override Guid GetId(object entity)
        {
            if (entity == null)
                return Guid.Empty;
            return DynamicDataServiceContext.GetObjectId(EntityName, entity);
        }
    }
}
