using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC
{
    public interface IPartialViewResult : IActionResult
    {
        IView View { get; set; }
    }

    public class PartialViewResult : IPartialViewResult
    {
        public void ExecuteResult(IControllerManager manager)
        {
        }

        public IView View
        {
            get;
            set;
        }
    }
}
