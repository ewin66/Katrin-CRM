using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Context
{
    public interface IIDE
    {
        void BeginProcess();
        void ShowProcessInfo(string processInfo);
        void EndProcess();
    }
}
