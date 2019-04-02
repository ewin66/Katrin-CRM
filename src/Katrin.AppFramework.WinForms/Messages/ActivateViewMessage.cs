using Katrin.AppFramework.WinForms.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Messages
{
    public class ActivateViewMessage:AbstractMessage
    {
        public ActionParameters Parameters { get; set; }
        public string ViewName { get; set; }
        public ActivateViewMessage(Guid workspaceId,string viewName)
        {
            this._workspceId = workspaceId;
            this.ViewName = viewName;
        }
    }
}
