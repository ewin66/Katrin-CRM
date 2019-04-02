using Katrin.AppFramework.Data;
using Katrin.AppFramework.Metadata;
using Katrin.AppFramework.MetadataServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Grid
{
    public class ColumnFieldProjectStragegy : IFieldProjectStrategy
    {
        private const string _sperator = "_p_";
        public string Project(string fieldName)
        {
            if (fieldName.Contains(_sperator)) throw new Exception("Can't project a field name that contains any dashes!");
            return fieldName.Replace(".", _sperator);
        }

        public string UnProject(string projectedName)
        {
            return projectedName.Replace(_sperator, ".");
        }
    }

    public class ColumnProjection
    {
        private IFieldProjectStrategy _projectStrategy = new ColumnFieldProjectStragegy();
        public ColumnProjection(string propertyPath, Entity entity)
        {
            PropertyPath = propertyPath;
            var attribute = entity.Attributes.FirstOrDefault(a => a.PhysicalName == propertyPath);
            if (attribute != null && attribute.AttributeLookupValues.Any())
            {
                var lookupValue = attribute.AttributeLookupValues.First();
                var chidPropertyName = lookupValue.Entity.Attributes
                    .First(a => a.AttributeId == lookupValue.DisplayEntityAttributeId).PhysicalName;
                var propertyName = propertyPath.Replace("Id", string.Empty);
                propertyPath = string.Format("{0}.{1}", propertyName, chidPropertyName);
            }

            Projection = _projectStrategy.Project(propertyPath);
            bool isChildPropertyIncluded = propertyPath.Contains(".");
            if (isChildPropertyIncluded)
            {
                var segments = propertyPath.Split('.');
                QueryExpression = string.Format("{0} == null?null:{1}", segments[0], propertyPath);
            }
            else
            {
                QueryExpression = propertyPath;
            }
        }
        public string PropertyPath { get; private set; }
        public string Projection { get; private set; }
        public string QueryExpression { get; private set; }
    }
}
