using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// The specific redirect to action result. It's invoke another controller's action
    /// </summary>
    /// <remarks>
    /// The class is marked as internal class, so that it's not accessible from a development project
    /// </remarks>
    public class RedirectToActionResult : IActionResult
    {
        #region Fields

        /// <summary>
        /// The action name
        /// </summary>
        private string _actionName;

        /// <summary>
        /// The controller name
        /// </summary>
        private string _controllerName;

        private ActionParameters _parameters;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructor. The controller name and action name are injected using constructor injection
        /// </summary>
        /// <param name="controllerName">The name of the controller</param>
        /// <param name="actionName">The name of the actio</param>
        public RedirectToActionResult(string controllerName, string actionName, ActionParameters parameters)
        {
            this._controllerName = controllerName;
            this._actionName = actionName;
            this._parameters = parameters;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// <see cref="IActionResult"/>
        /// </summary>
        /// <param name="manager"></param>
        public void ExecuteResult(IControllerManager manager)
        {
            //Execution de l'action
            manager.Invoke(_controllerName, _actionName, _parameters);
        }
        #endregion Public Methods

        
    }
}
