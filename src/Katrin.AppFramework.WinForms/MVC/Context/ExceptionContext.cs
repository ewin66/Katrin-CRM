using Katrin.AppFramework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC.Context
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// The context of an Exception attribute
    /// </summary>
    public class ExceptionContext : FilterContext
    {
        #region Constructors

        public ExceptionContext(IController controller, Exception exception)
            : base(controller)
        {
            Guard.ArgumentNotNull(exception, "exception");

            this.Exception = exception;
        }

        public ExceptionContext(IController controller, Exception exception, Type type)
            : this(controller, exception)
        {
            Guard.ArgumentNotNull(type, "type");

            this.Type = type;
        }

        #endregion Constructors

        #region Public Properties

        /// <summary>
        /// if ExceptionHandled is set to true then contains the Exception
        /// </summary>
        /// <value>The exception.</value>
        public virtual Exception Exception
        {
            get;
            set;
        }

        /// <summary>
        /// Indicate whether the caught exception is handled or not
        /// </summary>
        public virtual bool ExceptionHandled
        {
            get;
            set;
        }

        /// <summary>
        /// <see cref="IActionResult"/>
        /// </summary>
        public virtual IActionResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// The type of the exception to handle
        /// </summary>
        public virtual Type Type
        {
            get;
            set;
        }

        #endregion Public Properties
    }
}
