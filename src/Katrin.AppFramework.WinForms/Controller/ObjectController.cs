using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Grid;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework.WinForms.Workspaces;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Base;
using ICSharpCode.Core;

namespace Katrin.AppFramework.WinForms.Controller
{
    public abstract class ObjectController : ControllerBase, IObjectAware, ISelection
    {
        protected IObjectSpace _objectSpace = new ODataObjectSpace();

        public virtual string ObjectName
        {
            get;
            set;
        }

        public virtual string ControllerId
        {
            get;
            set;
        }

        protected virtual string RibbonPath
        {
            get { return string.Empty; }
        }

        public abstract object SelectedObject
        {
            get;
        }
    }
}
