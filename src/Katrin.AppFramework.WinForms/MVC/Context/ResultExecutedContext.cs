using Katrin.AppFramework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC.Context
{
    /// <summary>
    /// The context of the post result execution attribute
    /// </summary>
    /// <author>Mohamadou Yacoubou</author>
    public class ResultExecutedContext : FilterContext
    {
        #region Constructors

        public ResultExecutedContext(IController controller, IActionResult result, bool canceled, Exception exception)
            : base(controller)
        {
            Guard.ArgumentNotNull(result, "result");

            Result = result;
            Canceled = canceled;
            Exception = exception;
        }

        #endregion Constructors

        #region Public Properties
        /// <summary>
        /// Indicated wheter the execution of an action is cancelled
        /// </summary>
        /// <value><c>true</c> if canceled; otherwise, <c>false</c>.</value>
        public virtual bool Canceled
        {
            get;
            set;
        }
        /// <summary>
        /// The exception thrown by an action
        /// </summary>
        /// <value>The exception.</value>
        public virtual Exception Exception
        {
            get;
            set;
        }
        /// <summary>
        /// Indicates if an exception is handled by the filter
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
        public virtual IActionResult Result
        {
            get;
            set;
        }

        #endregion Public Properties
    }
}
