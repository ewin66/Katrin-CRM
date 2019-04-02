using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms.Grid;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework;
using DevExpress.Data.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Katrin.AppFramework.WinForms.Controls;
using Katrin.AppFramework.Metadata;
using Katrin.AppFramework.MetadataServiceReference;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Katrin.Win.HistoryModule
{
    public class HistoryController : ListController
    {
        public HistoryController()
        {
            ObjectName = "Audit";
        }

        public  IActionResult Detail(ActionParameters parameters)
        {
            return null;
        }

        public override IActionResult Execute(ActionParameters parameters)
        {
            _listView = CreateListView("DefaultListView");
            _listView.ObjectName = ObjectName;
            if (parameters.ObjectId != Guid.Empty)
            {
                var objectId = parameters.ObjectId;
                FixedFilter = new BinaryOperator("ObjectId", objectId);
                BindListData();
            }
            var result = new PartialViewResult();
            result.View = _listView;
            return result;
        }

        public override object SelectedObject
        {
            get { return _listView.SelectedObject; }
        }

        protected override List<string> IncludingPath
        {
            get { return new List<string>() { "ObjectType" }; }
        }

        private string GetPickListLabel(object lableOjbectValue, EntityAttribute attribute)
        {
            if (lableOjbectValue == null) return null;
            int pickListValue;
            if (!int.TryParse(lableOjbectValue.ToString(), out pickListValue))
            {
                return null;
            }
            var pickListValueObject =
                attribute.OptionSet.AttributePicklistValues.FirstOrDefault(c => c.Value == pickListValue);
            if (pickListValueObject == null) return null;
            return GetLocalizedLabel(pickListValueObject.AttributePicklistValueId);
        }

        private static string GetLocalizedLabel(Guid objectId)
        {
            int language = CultureManager.CurrentCulture.LCID;
            var localizedLabels =
                MetadataRepository.LocalizedLabels.Where(c => c.ObjectId == objectId)
                                  .ToList();
            if (!localizedLabels.Any()) return null;

            var matchedLabel = localizedLabels.FirstOrDefault(c => c.LanguageId == language) ?? localizedLabels.First();

            return matchedLabel.Label;
        }

        protected override object GetListData()
        {
            var historyList = (ODataListSource) base.GetListData();
            historyList.DataSourceChanged += (sender, e) =>
                {
                    if (historyList.Count == 0) return;
                    object firstHistoryRecord = historyList.List._First();
                    Type historyType = firstHistoryRecord.GetType();
                    var objectName = historyType.GetProperty("ObjectType")
                                                .GetValue(firstHistoryRecord, null).ToString();
                    Entity entity = MetadataRepository.Entities.FirstOrDefault(c => c.PhysicalName == objectName);
                    if (entity == null) return;

                    var fieldNamePropertyInfo = historyType.GetProperty("FieldName");
                    var originalValuePropertyInfo = historyType.GetProperty("OriginalValue");
                    var newValuePropertyInfo = historyType.GetProperty("NewValue");
                    
                    foreach (var h in historyList.List)
                    {
                        
                        var attributeName = fieldNamePropertyInfo.GetValue(h, null);
                        if (attributeName == null) continue;
                        var atrribute = entity.Attributes.FirstOrDefault(a => a.PhysicalName == attributeName.ToString());
                        if (atrribute == null) continue;
                        var label = GetLocalizedLabel(atrribute.AttributeId);
                        if (!string.IsNullOrEmpty(label))
                            fieldNamePropertyInfo.SetValue(h, label, null);

                        object originalValue = originalValuePropertyInfo.GetValue(h, null);
                        object newValue = newValuePropertyInfo.GetValue(h, null);
                        if (atrribute.OptionSet != null)
                        {
                            originalValuePropertyInfo.SetValue(h, GetPickListLabel(originalValue, atrribute), null);
                            newValuePropertyInfo.SetValue(h, GetPickListLabel(newValue, atrribute), null);
                        }
                        else if (atrribute.AttributeLookupValues.Any())
                        {
                            var lookupValue = atrribute.AttributeLookupValues.First();
                            var displayAttribute =
                                lookupValue.Entity.Attributes.First(
                                    a => a.AttributeId == lookupValue.DisplayEntityAttributeId);
                            SetLookupValueText(originalValue, lookupValue, displayAttribute, originalValuePropertyInfo,
                                               h);
                            SetLookupValueText(newValue, lookupValue, displayAttribute, newValuePropertyInfo, h);
                        }
                    }
                };

            return historyList;
        }

        private void SetLookupValueText(object historyValue, AttributeLookupValue lookupValue,
                                        EntityAttribute displayAttribute, PropertyInfo originalValuePropertyInfo,
                                        object h)
        {
            Guid id;
            if (historyValue != null && Guid.TryParse(historyValue.ToString(), out id))
            {
                var keyAttribute = lookupValue.Entity.Attributes.First(a => a.IsPKAttribute == true);
                var query = _objectSpace.GetObjectQuery(lookupValue.Entity.PhysicalName, null, null, true);
                var textQuery = query.Where(keyAttribute.PhysicalName + "=@0", id).Select(displayAttribute.PhysicalName);
                var displayText = textQuery._First();
                originalValuePropertyInfo.SetValue(h, displayText, null);
            }
        }
    }
}
