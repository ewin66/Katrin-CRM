using Katrin.AppFramework.WinForms.MVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// Action Filter interface
    /// </summary>
    public interface IActionFilter
    {
        /// <summary>
        /// The before method. This method is executed before the execution of an action
        /// </summary>
        /// <param name="preContext">The context of execution</param>
        void OnActionExecuting(ActionExecutingContext preContext);

        /// <summary>
        /// The after method. This method is executed after the execution of an action
        /// </summary>
        /// <param name="postContext">The context of execution</param>
        void OnActionExecuted(ActionExecutedContext postContext);
    }
}
