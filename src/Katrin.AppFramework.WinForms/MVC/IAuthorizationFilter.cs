using Katrin.AppFramework.WinForms.MVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// Authorization filter interface
    /// </summary>
    public interface IAuthorizationFilter
    {
        /// <summary>
        /// The unique method that is executed before all other filters
        /// </summary>
        /// <param name="filterContext">The context of execution</param>
        void OnAuthorization(AuthorizationContext filterContext);
    }
}
