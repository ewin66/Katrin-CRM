using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// Contains filters information of a specific action
    /// </summary>
    public class FilterInfo
    {
        #region Fields

        /// <summary>
        /// The list of action filters attribute
        /// </summary>
        private IList<IActionFilter> _actionFilters = new List<IActionFilter>();

        /// <summary>
        /// The list of authorization filters attribute
        /// </summary>
        private IList<IAuthorizationFilter> _authorizationFilters = new List<IAuthorizationFilter>();

        /// <summary>
        /// The list of exception filters attribute
        /// </summary>
        private IList<IExceptionFilter> _exceptionFilters = new List<IExceptionFilter>();

        /// <summary>
        /// The list of result filters attribute
        /// </summary>
        private IList<IResultFilter> _resultFilters = new List<IResultFilter>();

        #endregion Fields

        #region Public Properties

        public IList<IActionFilter> ActionFilters
        {
            get
            {
                return _actionFilters;
            }
            internal set
            {
                _actionFilters = value;
            }
        }

        public IList<IAuthorizationFilter> AuthorizationFilters
        {
            get
            {
                return _authorizationFilters;
            }
            internal set
            {
                _authorizationFilters = value;
            }
        }

        public IList<IExceptionFilter> ExceptionFilters
        {
            get { return _exceptionFilters; }
            internal set { _exceptionFilters = value; }
        }

        public IList<IResultFilter> ResultFilters
        {
            get
            {
                return _resultFilters;
            }
            internal set
            {
                _resultFilters = value;
            }
        }

        #endregion Public Properties
    }
}
