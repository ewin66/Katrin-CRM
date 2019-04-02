using DevExpress.Data.Filtering;
using DevExpress.Data.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace Katrin.AppFramework.WinForms.Context
{
    public interface IActionContext
    {
        event EventHandler CurrentChanged;
        event EventHandler FilterChanged;
        event EventHandler DataSourceChange;
        event EventHandler GetDataSource;
        object CurrentObject { get; set; }
        void SetFilter(string key, CriteriaOperator filter);
        void SetFilters(Dictionary<string, CriteriaOperator> rangeFilters);
        CriteriaOperator GetFilters();
        void RefreshData();
        BindingSource BindingSource { get; }
        CriteriaOperator GetFilter(string key);
        void SetCurrentObject(string propertyName, object value);
    }

    public class ActionContext : IActionContext
    {
        private Dictionary<string, CriteriaOperator> _filters;
        //private BindingSource _filteredDataSource;
        public event EventHandler CurrentChanged;
        public event EventHandler FilterChanged;
        public event EventHandler GetDataSource;
        public event EventHandler DataSourceChange;

        public ActionContext()
        {
            BindingSource = new BindingSource();
            BindingSource.DataSourceChanged += BindingSourceDataSourceChanged;
            _filters = new Dictionary<string, CriteriaOperator>();
            BindingSource.CurrentChanged += BindingSourceCurrentChanged;
        }

        void BindingSourceDataSourceChanged(object sender, EventArgs e)
        {
            EventHandler handle = DataSourceChange;
            if (handle == null) return;
            handle(sender, e);
        }

        void BindingSourceCurrentChanged(object sender, EventArgs e)
        {
            OnCurrentChanged(e);
        }

        public object CurrentObject
        {
            get
            {
                return BindingSource.Current;
            }
            set
            {
                BindingSource.Position = BindingSource.List.IndexOf(value);
            }
        }

        public void SetCurrentObject(string propertyName, object value)
        {
            int position =Find(BindingSource, new KeyValuePair<string, object>(propertyName, value));
            BindingSource.Position = position;
        }

        public BindingSource BindingSource
        {
            get;
            private set;
        }

        public CriteriaOperator GetFilter(string key)
        {
            if (_filters.Keys.Contains(key))
                return _filters[key];
            return null;
        }

        public CriteriaOperator GetFilters()
        {
            return CriteriaOperator.And(_filters.Values.ToArray());
        }

        public void SetFilter(string key, CriteriaOperator filter)
        {
            if (filter is ConstantValue) throw new Exception("Constantvalue can't be set as filter");
            CriteriaOperator oldVlaue;
            _filters.TryGetValue(key, out oldVlaue);
            _filters[key] = filter;
        }

        private bool IsFilterEqual(CriteriaOperator filter1, CriteriaOperator filter2)
        {
            string filterString1 = (object)filter1 == null ? string.Empty : filter1.ToString();
            string filterString2 = (object)filter2 == null ? string.Empty : filter2.ToString();
            return filterString1 == filterString2;
        }

        public void SetFilters(Dictionary<string, CriteriaOperator> rangeFilters)
        {
            if (rangeFilters.Count <= 0) return;
            foreach (var item in rangeFilters)
            {
                _filters[item.Key] = item.Value;
            }
        }

        protected virtual void OnCurrentChanged(EventArgs e)
        {
            var handler = CurrentChanged;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnFilterChanged(EventArgs e)
        {
            var handler = FilterChanged;
            if (handler != null) handler(this, e);
        }


        public static int Find(BindingSource source, params KeyValuePair<string,object>[] keys)
        {
            PropertyDescriptor[] properties = new PropertyDescriptor[keys.Length];

            ITypedList typedList = source as ITypedList;

            if (source.Count <= 0) return -1;

            PropertyDescriptorCollection props;

            if (typedList != null) // obtain the PropertyDescriptors from the list
            {
                props = typedList.GetItemProperties(null);
            }
            else // use the TypeDescriptor on the first element of the list
            {
                props = TypeDescriptor.GetProperties(source[0]);
            }

            for (int i = 0; i < keys.Length; i++)
            {
                properties[i] = props.Find(keys[i].Key, true); // will throw if the property isn't found
            }

            for (int i = 0; i < source.Count; i++)
            {
                object row = source[i];
                bool match = true;

                for (int p = 0; p < keys.Length; p++)
                {
                    if (!properties[p].GetValue(row).Equals(keys[p].Value))
                    {
                        match = false;
                        break;
                    }
                }

                if (match) return i;
            }

            return -1;
        }

        public void RefreshData()
        {
            var handler = GetDataSource;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
