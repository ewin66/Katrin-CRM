using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// Response object of an action execution.
    /// </summary>
    public interface IActionResult
    {
        #region Methods

        /// <summary>
        /// Execute the action result
        /// </summary>
        /// <param name="manager">The controller manager</param>
        void ExecuteResult(IControllerManager manager);
        #endregion Methods
    }
}
