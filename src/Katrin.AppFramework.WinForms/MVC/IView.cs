using Katrin.AppFramework.WinForms.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// Base Interface for view
    /// </summary>
    public interface IView:IDisposable
    {
        #region Events
        event EventHandler Closed;
        #endregion

        #region Properties

        /// <summary>
        /// <see cref="IControllerManager"/>
        /// </summary>
        IControllerManager ControllerManager
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates that the view is a child view
        /// </summary>
        bool IsChildForm
        {
            get;
            set;
        }

        object Model { get; set; }

        /// <summary>
        /// The view name
        /// </summary>
        string ViewName
        {
            get;
            set;
        }

        /// <summary>
        /// workspaceid
        /// </summary>
        Guid WorkSpaceID
        {
            get;
            set;
        }
        IWorkSpaceContext Context { get; set; }
        #endregion Properties

        #region Methods

        /// <summary>
        /// Initialize DataSources
        /// </summary>
        void BindDataToView();

        /// <summary>
        /// Display the view
        /// </summary>
        void ShowView();

        /// <summary>
        /// Display the view
        /// </summary>
        void ActiveView();

        /// <summary>
        /// Hide the view
        /// </summary>
        void CloseView();
       
        #endregion Methods
    }
}
