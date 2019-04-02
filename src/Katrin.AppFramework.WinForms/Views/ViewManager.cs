using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.Workspaces;
using Katrin.AppFramework.ConfigService;
using Katrin.AppFramework.WinForms.Context;
using Katrin.AppFramework.WinForms.MVC;
namespace Katrin.AppFramework.WinForms.Views
{
    public class ViewManager:IListener<ViewManageMessage>,IAppControllerFinder
    {
        private Dictionary<string, Control> _documents = new Dictionary<string, Control>();
        public ViewManager()
        {
            EventAggregationManager.AddListener(this);
        }

        public bool ActivateView(string viewName, ViewShowType viewShowType)
        {
            
            bool result = false;
            if (_documents.ContainsKey(viewName))
            {
                if (viewShowType == ViewShowType.Mdi) App.Instance.MainWorkspace.TabbedView.ActivateDocument(_documents[viewName]);
                else if (_documents[viewName] is Form)
                {
                    ((Form)_documents[viewName]).Activate();
                }
                result = true;
            }
            return result;
        }

        public void AddView(string viewName, Control view)
        {
            if (_documents.ContainsKey(viewName)) return;
            _documents.Add(viewName, view);
        }

        /// <summary>
        /// Restore opend view to defaultlayout.
        /// </summary>
        public void RestoreAllViewDefaultLayout()
        {
            foreach (KeyValuePair<string, Control> doc in this._documents)
            {
                if (doc.Value is ILayoutRemember)
                {
                    ILayoutRemember layout = doc.Value as ILayoutRemember;
                    layout.RestoreDefaultLayout();
                }
            }
        }


        void IListener<ViewManageMessage>.Handle(ViewManageMessage message)
        {
            if (message.ViewAction == ViewAction.Remove)
            {
                if (!_documents.ContainsKey(message.ViewName)) return;
                _documents.Remove(message.ViewName);
            }
            else if (message.ViewAction == ViewAction.Add)
            {
                if (message.RelationObject == null) return;
                if (!(message.RelationObject is Control)) return;
                AddView(message.ViewName, (Control)message.RelationObject);
            }
        }


        #region IAppControllerFinder
       public IList<IController> FinController(string controllerId)
        {
            List<IController> controllers = new List<IController>();
            foreach (KeyValuePair<string, Control> pair in this._documents)
            {
                IWorkspace1 workspace = pair.Value as IWorkspace1;
                IController controller = workspace.FindController(controllerId);
                if (controller != null)
                {
                    controllers.Add(controller);
                }
            }
            return controllers;
        }

        public IList<T> FinController<T>(string controllerId)
        {
            List<T> controllers = new List<T>();
            foreach (KeyValuePair<string, Control> pair in this._documents)
            {
                IWorkspace1 workspace = pair.Value as IWorkspace1;
                T controller = workspace.FindController<T>(controllerId);
                if (controller != null)
                {
                    controllers.Add(controller);
                }
            }
            return controllers;
        }
        #endregion

       
    }
}
