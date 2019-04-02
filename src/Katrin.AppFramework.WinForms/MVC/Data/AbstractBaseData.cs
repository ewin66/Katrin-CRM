using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC.Data
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// Base class which encapsulates front end datas
    /// </summary>
    public class AbstractBaseData : BindableBase, IDataErrorInfo
    {
        #region Fields

        /// <summary>
        /// data status
        /// </summary>
        bool _isDeleted;

        /// <summary>
        /// data status
        /// </summary>
        bool _isModified;

        /// <summary>
        /// data status
        /// </summary>
        bool _isNew;

        /// <summary>
        /// The error message
        /// </summary>
        protected String _error;

        /// <summary>
        /// Dictionary of error per property
        /// </summary>
        protected StringDictionary _propError = new StringDictionary();

        #endregion Fields

        #region Constructors

        public AbstractBaseData()
        {
            Initialize();
        }

        #endregion Constructors

        #region Public Properties

        public string Error
        {
            get { return _error; }
        }

        /// <summary>
        /// Data status
        /// </summary>
        public bool IsDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; }
        }

        /// <summary>
        /// Data status
        /// </summary>
        public bool IsModified
        {
            get { return _isModified; }
            set { _isModified = value; }
        }

        /// <summary>
        /// Data statusss
        /// </summary>
        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }

        /// <summary>
        /// Gets the error of a specific property
        /// </summary>
        /// <param name="propertyName">The property name</param>d
        /// <returns>The error message</returns>
        public string this[string propertyName]
        {
            get { return _propError[propertyName]; }
            set
            {
                _propError[propertyName] = value;
                PropertyHasChanged();
            }
        }

        #endregion Public Properties

        #region Protected Methods

        /// <summary>
        /// Override this method to set up event handlers so user
        /// code in a partial class can respond to events raised by
        /// generated code.
        /// </summary>
        protected virtual void Initialize()
        {
            /* allows subclass to initialize events before any other activity occurs */
        }

        /// <summary>
        /// Performs processing required when the current
        /// property has changed.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This implementation uses System.Diagnostics.StackTrace to
        /// determine the name of the current property, and so must be called
        /// directly from the property to be checked.
        /// </para>
        /// </remarks>
        [System.Runtime.CompilerServices.MethodImpl(
          System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        protected void PropertyHasChanged()
        {
            string propertyName =
              new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name.Substring(4);
            PropertyHasChanged(propertyName);
        }

        /// <summary>
        /// Performs processing required when a property
        /// has changed.
        /// </summary>
        /// <param name="propertyName">Name of the property that
        /// has changed.
        /// </param>        
        protected virtual void PropertyHasChanged(string propertyName)
        {
            OnPropertyChanged(propertyName);
        }

        #endregion Protected Methods

        #region Public Methods

        /// <summary>
        /// Clear the property error dictionary
        /// </summary>
        public void ClearPropertyErrors()
        {
            this._propError.Clear();
            this.PropertyHasChanged("_propError");
        }

        #endregion Public Methods
    }
}
