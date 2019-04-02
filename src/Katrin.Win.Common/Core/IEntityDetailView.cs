using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.MetadataServiceReference;
using Katrin.Win.Infrastructure.Services;

namespace Katrin.Win.Common.Core
{
    public interface IEntityDetailView
    {
        UserDataPersistenceService UserDataPersistenceService { get; set; }
        string EntityName { get; set; }
        void SetEditorStatus(bool isReadOnly);
        void InitEditors(Entity entity);
        void Bind(object entity);
        bool ValidateData();
        void PostEditors();
        void BeginInit();
        void EndInit();
    }
}
