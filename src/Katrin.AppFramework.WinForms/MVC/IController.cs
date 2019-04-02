using Katrin.AppFramework.WinForms.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// Controller interface.
    /// </summary>
    public interface IController:IDisposable
    {
        #region Methods

        /// <summary>
        /// Default method for actions; all actions provide the Execute() method
        /// </summary>
        /// <returns></returns>
        IActionResult Execute(ActionParameters parameters);

        /// <summary>
        /// Check if a given action should be executed asynchronously
        /// </summary>
        /// <param name="actionName">The action's name</param>
        /// <returns>true if the action is asynchronous, false either</returns>
        bool IsAnAsynchronousAction(string actionName);

        /// <summary>
        /// WorkSpace.
        /// </summary>
        Guid WorkSpaceID { get; set; }

        IWorkSpaceContext Context { get; set; }
        #endregion Methods
    }
}
