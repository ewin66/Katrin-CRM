using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.Utils
{
    public interface IObservableCollection<T> : IList<T>, INotifyPropertyChangedEx, INotifyCollectionChanged
    {
        /// <summary>
        ///   Adds the range.
        /// </summary>
        /// <param name = "items">The items.</param>
        void AddRange(IEnumerable<T> items);

        /// <summary>
        ///   Removes the range.
        /// </summary>
        /// <param name = "items">The items.</param>
        void RemoveRange(IEnumerable<T> items);
    }
}
