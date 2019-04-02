using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.MetadataServiceReference;

namespace Katrin.Win.MetadataManager
{
    public class MetadataController : RecordListController<MetadataListView, MetadataDetailView>
    {
        protected override string EntityName
        {
            get { return typeof(Entity).Name; }
        }

        protected override Guid GetId(object entity)
        {
            if (entity == null) return Guid.Empty;
            Entity currentEntity = (Entity)entity;
            return currentEntity.EntityId;
        }
    }
}
