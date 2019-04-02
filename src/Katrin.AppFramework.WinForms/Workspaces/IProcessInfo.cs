using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Workspaces
{
    public interface IProcessInfo
    {
        void BeginProcess();
        void ShowProcessInfo(string processInfo);
        void EndProcess();
    }
}
