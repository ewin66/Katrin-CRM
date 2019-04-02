using Katrin.AppFramework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC.Context
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// The context of the pre result execution attribute
    /// </summary>
    public class ResultExecutingContext : FilterContext
    {
        #region Constructors

        public ResultExecutingContext(IController controller, IActionResult actionResult)
            : base(controller)
        {
            Guard.ArgumentNotNull(actionResult, "actionResult");
            Result = actionResult;
        }

        public ResultExecutingContext(IController controller, IActionResult actionResult, bool cancel)
            : this(controller, actionResult)
        {
            this.Cancel = cancel;
        }

        #endregion Constructors

        #region Public Properties

        public bool Cancel
        {
            get;
            set;
        }

        public virtual IActionResult Result
        {
            get;
            set;
        }

        #endregion Public Properties
    }
}
