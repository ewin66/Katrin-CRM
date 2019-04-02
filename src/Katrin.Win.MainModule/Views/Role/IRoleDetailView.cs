using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.MetadataServiceReference;
namespace Katrin.Win.MainModule.Views.Role
{
    public interface IRoleDetailView : IEntityDetailView
    {
        event EventHandler Search;
        event EventHandler MenuSelecting;
        void InitRelationMenus(List<Entity> entities);
    }
}
