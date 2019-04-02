using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// The specific Render view action result. It's display a view
    /// </summary>
    /// <remarks>
    /// The class is marked as internal class, so that it's not accessible from a development project
    /// </remarks>
    public class ViewResult : IActionResult
    {
        #region Fields

        /// <summary>
        /// The name of the view to display
        /// </summary>
        private string _viewName;
        private object _viewModel;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructor. Injecting the view name using the constructor
        /// </summary>
        /// <param name="viewName"></param>
        internal ViewResult(string viewName, object viewModel)
        {
            this._viewName = viewName;
            this._viewModel = viewModel;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// <see cref="IActionResult"/>
        /// </summary>
        public void ExecuteResult(IControllerManager manager)
        {
            manager.RenderView(_viewName, _viewModel);
        }

        #endregion Public Methods
    }
}
