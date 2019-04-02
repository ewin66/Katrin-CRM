using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.MetadataServiceReference;

namespace Katrin.Win.MetadataManager
{
    public interface IMetadataDetailView
    {
        void Bind(List<Entity> entity);
        bool ValidateData();
        void SetControlState(Guid entityId);
        void SelectTab(int tabIndex);
        void PostEditors();
    }
}
