using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC
{
    public class ActionInvoker
    {
        public IActionResult Invoke(IController controller, string actionName, ActionParameters parameters)
        {
            if (string.IsNullOrEmpty(actionName)) actionName = "Execute";
            return (IActionResult)controller.GetType().GetMethod(actionName).Invoke(controller, new[] { parameters });
        }
    }
}
