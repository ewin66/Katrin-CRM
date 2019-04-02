using Katrin.AppFramework.WinForms.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Context
{
    public interface IAppContext
    {
        IAppControllerFinder ControllerFinder { get; }     
      
    }
}
