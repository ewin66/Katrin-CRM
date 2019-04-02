using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC.Context
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// The context of an Authorization filter
    /// </summary>
    public class AuthorizationContext : FilterContext
    {
        #region Fields

        private bool isAuthenticated = false;
        private bool isAuthorized = false;

        #endregion Fields

        #region Constructors

        public AuthorizationContext()
        {
        }

        public AuthorizationContext(IController controller)
            : base(controller)
        {
        }

        #endregion Constructors

        #region Public Properties

        public bool IsAuthenticated
        {
            get { return isAuthenticated; }
            set
            {
                isAuthenticated = value;
                this.IsAuthorized = value;
            }
        }

        public bool IsAuthorized
        {
            get { return isAuthorized; }
            set { isAuthorized = value; }
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
