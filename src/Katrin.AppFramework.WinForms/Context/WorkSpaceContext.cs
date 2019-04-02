using Katrin.AppFramework.WinForms.CommandManage;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Workspaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Context
{
    class WorkSpaceContext:IWorkSpaceContext
    {
        private IWorkspaceInfo _iWorkspaceInfo;
        private IControllerFinder _iControllerFinder;
        private IWorkspace1 _workspace;
        private ActionParameters _actionParameters;
        private IProcessInfo _processer;

        public WorkSpaceContext(IWorkspaceInfo workspaceInfo,
            IControllerFinder controllerFinder,
            IWorkspace1 workspace,
            ActionParameters actionParameters,
            IProcessInfo processer)
        {
            this._iWorkspaceInfo = workspaceInfo;
            this._workspace = workspace;
            this._iControllerFinder = controllerFinder;
            this._actionParameters = actionParameters;
            this._processer = processer;
        }

        #region IAppContext
        public IWorkspaceInfo WorkSpace
        {
            get {return this._iWorkspaceInfo; }
        }

        public IControllerFinder ControllerFinder
        {
            get {return this._iControllerFinder; }
        }

        public void UpdateCommandState()
        {
            this._workspace.UpdateCommandState();
        }
     
        #endregion




        public IAppContext AppContext
        {
            get { return App.Instance; }
        }

        public MVC.ActionParameters ActionParameter
        {
            get { return _actionParameters; }
        }

        #region IProcessInfo
        public void BeginProcess()
        {
            if (this._processer != null) this._processer.BeginProcess();
        }

        public void ShowProcessInfo(string processInfo)
        {
            throw new NotImplementedException();
        }

        public void EndProcess()
        {
            if(this._processer != null)this._processer.EndProcess();
        }
        #endregion

        public void Dispose()
        {
            this._workspace = null;
            this._actionParameters = null;
            this._iControllerFinder = null;
            this._iWorkspaceInfo = null;
            this._processer = null;
           
        }
    }
}
