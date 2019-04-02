using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.Utils
{
    public class ObservableCollectionEx<T> : ObservableCollection<T>,IObservableCollection<T>
    {
        public void AddRange(IEnumerable<T> items)
        {
            var previousNotificationSetting = IsNotifying;
            IsNotifying = false;
            items.Apply(i => Items.Add(i));
            IsNotifying = previousNotificationSetting;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            OnPropertyChanged(new PropertyChangedEventArgs(string.Empty));
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            var previousNotificationSetting = IsNotifying;
            IsNotifying = false;
            foreach (var item in items)
            {
                Items.Remove(item);
            }
            IsNotifying = previousNotificationSetting;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            OnPropertyChanged(new PropertyChangedEventArgs(string.Empty));
        }

        public bool IsNotifying
        {
            get;
            set;
        }

        protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (!IsNotifying) return;
            base.OnCollectionChanged(e);
        }

        public void RaisePropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (IsNotifying)
                base.OnPropertyChanged(e);
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }
    }
}
