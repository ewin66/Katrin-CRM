using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC.Context
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// Base class of all filter context
    /// </summary>
    public class FilterContext
    {
        #region Constructors

        public FilterContext()
        {
        }

        public FilterContext(IController controller)
        {
            this.Controller = controller;
        }

        #endregion Constructors

        #region Public Properties

        public IController Controller
        {
            get;
            set;
        }

        #endregion Public Properties
    }
}
