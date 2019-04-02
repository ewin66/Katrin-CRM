using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC.Context
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// The context of the post action execution attribute
    /// </summary>
    public class ActionExecutedContext : FilterContext
    {
        #region Constructors

        public ActionExecutedContext(IController controller, bool cancelled, Exception exception)
            : base(controller)
        {
            this.Cancelled = cancelled;
            this.Exception = exception;
        }

        #endregion Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether the execution of an action is cancelled.
        /// </summary>
        /// <value><c>true</c> if cancelled; otherwise, <c>false</c>.</value>
        public virtual bool Cancelled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the exception (thrown by an action).
        /// </summary>
        /// <value>The exception.</value>
        public virtual Exception Exception
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the exception is handled by the filter.
        /// </summary>
        /// <value><c>true</c> if the exception is handled; otherwise, <c>false</c>.</value>
        public bool ExceptionHandled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        public IActionResult Result
        {
            get;
            set;
        }

        #endregion Public Properties
    }
}
