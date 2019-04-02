using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Katrin.AppFramework.WinForms.ViewInterface;
using Katrin.AppFramework.WinForms.Workspaces;

namespace Katrin.AppFramework.WinForms.Views
{
    public class ModalViewResult : IActionResult
    {
        private object _view;
        public ModalViewResult(object view)
        {
            Guard.ObjectIsInstanceOfType(view, typeof(Control), "view");
            _view = view;
        }

        public void ExecuteResult(IControllerManager manager)
        {
            manager.App.MainWorkspace.Show((Control)_view, ViewShowType.Dialog);
        }
    }

    public class DetailViewResult : IActionResult
    {
        private object _view;
        public DetailViewResult(object view)
        {
            Guard.ObjectIsInstanceOfType(view, typeof(Control), "view");
            _view = view;
        }

        public void ExecuteResult(IControllerManager manager)
        {
            manager.App.MainWorkspace.Show((Control)_view, ViewShowType.Show);
        }
    }

    public class MdiViewResult : IActionResult
    {
        private object _view;
        private IObjectListView _listView;
        public MdiViewResult(object view, IObjectListView listView)
        {
            Guard.ObjectIsInstanceOfType(view, typeof(Control), "view");
            _view = view;
            _listView = listView;
        }

        public void ExecuteResult(IControllerManager manager)
        {
            //_listView.ControllerManager = manager;
            manager.App.MainWorkspace.Show((Control)_view, ViewShowType.Mdi);
        }
    }
}
