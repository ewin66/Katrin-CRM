using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.CommandManage
{
    public interface IRunTimeCommandRigister
    {
        IControllerFinder ControllerFinder { get; }
        bool ClearOldCommand(string groupName);
        bool AddRunTimeCommand(string groupName,
            string caption,
            string imgSource,
            ICommand action,
            bool check);
        
    }
}
