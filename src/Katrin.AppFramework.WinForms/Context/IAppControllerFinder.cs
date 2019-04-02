using Katrin.AppFramework.WinForms.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Context
{
    public interface IAppControllerFinder
    {
        IList<IController> FinController(string controllerId);
        IList<T> FinController<T>(string controllerId);
    }
}
