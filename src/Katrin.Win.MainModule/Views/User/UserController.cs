using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Core;

namespace Katrin.Win.MainModule.Views.User
{
    public class UserController:RecordListController<UserListView,UserDetailView>
    {
        protected override string EntityName
        {
            get { return "User"; }
        }

        protected override Guid GetId(object entity)
        {
            if (entity == null)
                return Guid.Empty;
            return DynamicDataServiceContext.GetObjectId(EntityName, entity);
        }
    }
}
