using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC.Data
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// Base class that allow front end datas to support bidirectional databinding
    /// </summary>
    public abstract class BindableBase : INotifyPropertyChanged
    {
        #region Protected Methods

        /// <summary>
        /// Call this method to raise the PropertyChanged event for a specific property.
        /// </summary>
        /// <param name="propertyName">Name of the property that has changed.</param>
        /// <remarks>
        /// This method may be called by properties in the business
        /// class to indicate the change in a specific property.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion Protected Methods

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events
    }
}
