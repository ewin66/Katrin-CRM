using Katrin.AppFramework.WinForms.MVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// Result filter interface
    /// </summary>
    public interface IResultFilter
    {
        #region Methods

        /// <summary>
        /// The after method. It is executed after the execution of an action result
        /// </summary>
        /// <param name="filterContext"></param>
        void OnResultExecuted(ResultExecutedContext filterContext);

        /// <summary>
        /// The before method. It is executed before the execution of an action result
        /// </summary>
        /// <param name="filterContext">The context of execution</param>
        void OnResultExecuting(ResultExecutingContext filterContext);

        #endregion Methods
    }
}
