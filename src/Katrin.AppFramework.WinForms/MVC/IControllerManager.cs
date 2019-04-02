using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// Controller Manager Inteface
    /// </summary>
    public interface IControllerManager
    {
        App App { get; }

        #region Methods

        /// <summary>        
        /// Invokes the controller provided as parameter; in this case
        /// the default Execute method of the controller is ran
        /// </summary>
        /// <param name="controllerName">The controller name</param>
        void Invoke(string controllerName);

        /// <summary>
        /// Invokes the action of the controller in parameter.
        /// </summary>
        /// <param name="controllerName">The controller's name to invoke</param>
        /// <param name="actionName">The action's name to invoke</param>
        void Invoke(string controllerName, string actionName, ActionParameters parameters);

        /// <summary>
        /// Render a view
        /// </summary>
        /// <param name="viewName">The view name to render</param>
        void RenderView(string viewName, object viewModel);

        #endregion Methods
    }
}
