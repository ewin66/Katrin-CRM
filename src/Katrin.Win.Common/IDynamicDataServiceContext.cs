using DevExpress.Data.Filtering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Services.Client;

namespace Katrin.Win.Common
{
    public interface IDynamicDataServiceContext
    {
        IList GetObjects(string entityName);
        IList GetObjects(string entityName, CriteriaOperator filter, Dictionary<string, string> properties);
        IList GetBatchObjects(string entityName, CriteriaOperator filter, Dictionary<string, string> properties);
        DataServiceQuery CreateObjectQuery(string entityName, CriteriaOperator filter, Dictionary<string, string> properties);

        object GetOrNew(string entityName, Guid id);
        object GetOrNew(string entityName, Guid id, string path);
        void AddObject(string entityName, object entity);
        void UpdateObject(object entity);
        void LoadProperty(object entity, string propertyName);
        void DeleteObject(string entityName, object entity);
        void SaveChanges();
        Guid GetObjectId(string entityName, object entity);
    }
}
