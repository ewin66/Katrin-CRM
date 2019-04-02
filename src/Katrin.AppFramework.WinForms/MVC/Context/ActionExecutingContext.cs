using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC.Context
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// The context of the pre execution action attribute
    /// </summary>
    public class ActionExecutingContext : FilterContext
    {
        #region Constructors

        public ActionExecutingContext(IController controller)
            : base(controller)
        {
        }

        #endregion Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the result. If the result is different of null, then the execution of the action is cancelled
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
