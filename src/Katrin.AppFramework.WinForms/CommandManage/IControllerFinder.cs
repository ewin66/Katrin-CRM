using Katrin.AppFramework.WinForms.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.CommandManage
{
    public interface IControllerFinder
    {
        IController FindController(string controllerId);
        T FindController<T>(string controllerId);
    }
}
