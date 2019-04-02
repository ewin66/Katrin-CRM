using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.WcfLinq;
using Microsoft.Data.Edm;

namespace Katrin.Win.Common.Controls
{
    public class DynamicWcfInstantFeedbackSource : WcfInstantFeedbackSource
    {
        private readonly DynamicDataServiceContext _context;
        private readonly string _entityName;

        public DynamicWcfInstantFeedbackSource(string entityName)
        {
            _context = new DynamicDataServiceContext();
            _entityName = entityName;
            GetSource += DynamicWcfInstantFeedbackSourceGetSource;
        }

        void DynamicWcfInstantFeedbackSourceGetSource(object sender, GetSourceEventArgs e)
        {
            var entityType = DynamicDataServiceContext.GetTypeDefinition(_entityName);
            var primaryFieldName = entityType.Key().First().Name;
            e.Query = _context.CreateObjectQuery(_entityName, null, null);
            e.KeyExpression = primaryFieldName;
        }

        public string GetDisplayTextByKeyValue(object keyValue, string displayMember)
        {
            var displayValue = _context.GetPropertyValue(_entityName, keyValue, displayMember);
            if (displayValue != null) return displayValue.ToString();
            return string.Empty;
        }
    }
}
