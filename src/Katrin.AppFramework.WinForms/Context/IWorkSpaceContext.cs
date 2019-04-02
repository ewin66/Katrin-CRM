using Katrin.AppFramework.WinForms.CommandManage;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Workspaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Context
{

    public interface IWorkSpaceContext : IProcessInfo,IDisposable
    {
        IAppContext AppContext { get; }
        IWorkspaceInfo WorkSpace { get; }
        IControllerFinder ControllerFinder { get; }
        ActionParameters ActionParameter {get;}
        /// <summary>
        /// Update command in workspace.
        /// </summary>
        void UpdateCommandState();
       
       
    }
}
