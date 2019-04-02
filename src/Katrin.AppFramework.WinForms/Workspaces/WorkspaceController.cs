using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;

namespace Katrin.AppFramework.WinForms.Workspaces
{
    public class WorkspaceController: ControllerBase, IObjectAware
    {
        public string ObjectName
        {
            get;
            set;
        }

        public string ControllerId
        {
            get;
            set;
        }

        public virtual IActionResult List(ActionParameters parameters)
        {
            string viewName = ObjectName;
            if (parameters.ViewShowType != ViewShowType.Mdi && parameters.ContainsKey("FixedFilter"))
            {
                viewName += parameters.Get<CriteriaOperator>("FixedFilter").LegacyToString();
            }
            return ShowView(parameters, viewName, "List");
        }

        public IActionResult Detail(ActionParameters parameters)
        {
            string viewName = parameters.ObjectName + "-" + parameters.ObjectId;
            return ShowView(parameters, viewName, "Detail");
        }

        private IActionResult ShowView(ActionParameters parameters, string viewName, string pathName)
        {
            ViewShowType viewType = parameters.ViewShowType;
            if (App.Instance.ViewManager.ActivateView(viewName, viewType)) return null;
            var workspace = new RibbonFormWorkspace(parameters);

            workspace.ObjectName = ObjectName;
            workspace.Name = viewName;
            var path = "/" + ObjectName + "/" + pathName;
            workspace.BasePath = path;
         
            workspace.LoadViews(parameters);
            if (workspace.ActiveView == null && !(workspace.ActionResult  is IPartialViewResult))
                return workspace.ActionResult;
            if (viewType == ViewShowType.Dialog)
                return new ModalViewResult(workspace);
            else if (viewType == ViewShowType.Show)
            {
                workspace.Location = new System.Drawing.Point(100, 100);
                ((RibbonFormWorkspace)workspace).SetBounds(((RibbonFormWorkspace)workspace).Bounds.X,
                    ((RibbonFormWorkspace)workspace).Bounds.Y, 900, 700);
                workspace.RestoreLayout();
                return new DetailViewResult(workspace);
            }
            else
                workspace.RestoreLayout();
                return new MdiViewResult(workspace, null);

        }
    }
}
