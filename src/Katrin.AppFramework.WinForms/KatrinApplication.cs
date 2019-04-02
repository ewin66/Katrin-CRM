using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Workspaces;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework.WinForms.Context;

namespace Katrin.AppFramework.WinForms
{
    public class App:IAppContext
    {
       
        private ControllerManager _controllerManager;
        private static App _instance;
        private ViewManager _viewManager;
        private Dictionary<string,IModuleService> _services;
        private App()
        {
            _controllerManager = new ControllerManager(this);
            _viewManager = new ViewManager();
            this._services = new Dictionary<string, IModuleService>();
            this.LoadServices();
        }

        private void LoadServices()
        {
           this._services = AddInTree.BuildDictionaryItems<IModuleService>("/Workbench/Service", null, false);   
        }

        public static App Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new App();
                }
                return _instance;
            }
        }

        public IWorkspace MainWorkspace { get; set; }
        public ViewManager ViewManager { get { return _viewManager; } }

        public void Invoke(string controllerName, string actionName, ActionParameters parameters)
        {
            _controllerManager.Invoke(controllerName, actionName, parameters);
        }
        #region IAppContext
        public IAppControllerFinder ControllerFinder
        {
            get 
            {
                return this._viewManager;
            }
        }  
        #endregion
    }
}
