using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using Katrin.Win.Common;
using Katrin.Win.Common.MetadataServiceReference;

namespace Katrin.Win
{
    public class LookupListItem<T>
    {
        public string DisplayName { get; set; }
        public T Value { get; set; }
        public bool IsDeafult { get; set; }
    }

    public static class RepositoryItemLookUpEditExtension
    {

        public static void BindComboBoxList(this ComboBoxEdit comboBoxEdit, Entity entity, string attributeName)
        {
            comboBoxEdit.Properties.BindComboBoxList(entity, attributeName);
        }

        public static void BindPickList(this LookUpEdit lookUpEdit, Entity entity)
        {
            if (lookUpEdit.DataBindings.Count == 0)
                return;

            var binding = lookUpEdit.DataBindings[0];
            string attributeName = binding.BindingMemberInfo.BindingMember;
            lookUpEdit.Properties.BindPickList(entity, attributeName);
        }

        public static void BindLookupList(this LookUpEdit lookUpEdit, Entity entity, bool withEmptyRow)
        {
            if (lookUpEdit.DataBindings.Count == 0)
                return;

            var binding = lookUpEdit.DataBindings[0];
            string attributeName = binding.BindingMemberInfo.BindingMember;
            if (entity == null) return;
            var attribute = entity.Attributes.FirstOrDefault(a => a.PhysicalName.Equals(attributeName));
            if (attribute != null && attribute.AttributeLookupValues.Any())
            {
                var items = GetLookupValues(withEmptyRow, attribute);
                InitializeLookUpEdit(lookUpEdit.Properties, items);
            }
        }

        private static List<LookupListItem<Guid?>> GetLookupValues(bool withEmptyRow, EntityAttribute attribute)
        {
            var lookupValue = attribute.AttributeLookupValues.First();
            var lookupValueEntity = lookupValue.Entity;
            string displayMemberName =
                lookupValueEntity.Attributes.First(a => a.AttributeId == lookupValue.DisplayEntityAttributeId).PhysicalName;
            string valueMemberName = lookupValueEntity.Name + "Id";
            var values = new DynamicDataServiceContext().GetObjects(lookupValueEntity.PhysicalName);

            var items = new List<LookupListItem<Guid?>>();
            foreach (var value in values)
            {
                var item = new LookupListItem<Guid?>();
                object displayName = value.GetType().GetProperty(displayMemberName).GetValue(value, null);
                if (displayName != null)
                {
                    item.DisplayName = displayName.ToString();
                    item.Value = (Guid)value.GetType().GetProperty(valueMemberName).GetValue(value, null);
                    items.Add(item);
                }
            }
            if (withEmptyRow)
            {
                items.Insert(0, new LookupListItem<Guid?>());
            }
            return items;
        }
        
        public static void BindPickList(this RepositoryItemLookUpEdit lookUpEdit, Entity entity, string entityPropertyName)
        {
            var attribute = entity.Attributes
                .FirstOrDefault(a => a.PhysicalName.Equals(entityPropertyName));
            int langId = System.Globalization.CultureInfo.CurrentCulture.LCID;
            if (attribute != null && attribute.OptionSet != null)
            {
                var items = GetPickListValues(attribute, langId);

                InitializeLookUpEdit(lookUpEdit, items);
            }
        }

        public static void BindComboBoxList(this RepositoryItemComboBox comboBoxEdit, Entity entity, string entityPropertyName)
        {
            var attribute = entity.Attributes
                .FirstOrDefault(a => a.PhysicalName.Equals(entityPropertyName));
            int langId = System.Globalization.CultureInfo.CurrentCulture.LCID;
            if (attribute != null && attribute.OptionSet != null)
            {
                var items = GetComboBoxListValues(attribute, langId);
                comboBoxEdit.Items.AddRange(items);
            }
        }

        private static List<LookupListItem<int?>> GetPickListValues(EntityAttribute attribute, int langId)
        {
            var values = attribute.OptionSet.AttributePicklistValues.OrderBy(v => v.DisplayOrder);
            var items = new List<LookupListItem<int?>>();
            var labels = MetadataProvider.Instance.LocalizedLabels;
            foreach (var value in values)
            {
                var item = new LookupListItem<int?>();
                var localizedLabels = labels.Where(l => l.ObjectId == value.AttributePicklistValueId);
                var localizedLabel = localizedLabels.FirstOrDefault(l => l.LanguageId == langId) ?? localizedLabels.First();
                if (localizedLabel != null)
                {
                    item.DisplayName = localizedLabel.Label;
                }
                item.Value = value.Value;
                items.Add(item);
            }
            if (attribute.IsNullable.HasValue && attribute.IsNullable.Value)
            {
                items.Insert(0, new LookupListItem<int?>());
            }
            return items;
        }

        private static List<ComboBoxItem> GetComboBoxListValues(EntityAttribute attribute, int langId)
        {
            var values = attribute.OptionSet.AttributePicklistValues.OrderBy(v => v.DisplayOrder);
            var items = new List<ComboBoxItem>();
            var labels = MetadataProvider.Instance.LocalizedLabels;
            foreach (var value in values)
            {
                
                var localizedLabels = labels.Where(l => l.ObjectId == value.AttributePicklistValueId);
                var localizedLabel = localizedLabels.FirstOrDefault(l => l.LanguageId == langId) ?? localizedLabels.First();
                if (localizedLabel != null)
                {
                    var item = new ComboBoxItem(value);
                    item.Value = localizedLabel.Label;
                    items.Add(item);
                }
                
            }
            if (attribute.IsNullable.HasValue && attribute.IsNullable.Value)
            {
                items.Insert(0, new ComboBoxItem(""));
            }
            return items;
        }

        public static void InitializeLookUpEdit<T>(this RepositoryItemLookUpEdit lookUpEdit, List<LookupListItem<T>> items)
        {
            string displayMember = "DisplayName";
            string valueMember = "Value";
            InitializeLookUpEdit(lookUpEdit, items, displayMember, valueMember);
            lookUpEdit.Columns.Clear();
            lookUpEdit.Columns.Add(new LookUpColumnInfo(lookUpEdit.DisplayMember));
            lookUpEdit.ShowHeader = false;
        }

        internal static void InitializeLookUpEdit(this RepositoryItemLookUpEditBase lookUpEdit, object datasource, string displayNameber, string valueMember)
        {
            lookUpEdit.DisplayMember = displayNameber;
            lookUpEdit.ValueMember = valueMember;
            lookUpEdit.DataSource = datasource;
            lookUpEdit.NullText = string.Empty;
            lookUpEdit.TextEditStyle = TextEditStyles.DisableTextEditor;
            lookUpEdit.ShowFooter = false;
            lookUpEdit.AllowNullInput = DefaultBoolean.True;
        }

        public static void SetCheckedListBox(CheckedListBoxControl listBox, object datasource, string displayNameber, string valueMember)
        {
            listBox.DataSource = datasource;
            listBox.DisplayMember = displayNameber;
            listBox.ValueMember = valueMember;
            listBox.DataSource = datasource;
        }

        
    }
}
