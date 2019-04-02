using Katrin.AppFramework.WinForms.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Messages
{
    public enum ViewAction
    {
        Add,
        Remove
    }

    public class ViewManageMessage
    {
        public string ViewName { get; set; }
        public ViewAction ViewAction { get; set; }
        public object RelationObject { get; set; }
    }
}
