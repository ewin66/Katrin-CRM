using Katrin.AppFramework.WinForms.MVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// Exception filter interface
    /// </summary>
    public interface IExceptionFilter
    {
        /// <summary>
        /// The method is executed after all other filters. It handle exceptions
        /// </summary>
        /// <param name="filterContext">The context of execution</param>
        void OnException(ExceptionContext filterContext);
    }
}
