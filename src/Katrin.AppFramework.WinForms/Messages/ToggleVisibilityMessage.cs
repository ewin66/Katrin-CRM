using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Messages
{
    public class ToggleVisibilityMessage: AbstractMessage
    {
        public string ViewName { get; set; }
        public ToggleVisibilityMessage(string objectName, string viewName,Guid workspaceId)
        {
            ViewName = viewName;
            ObjectName = objectName;
            this._workspceId = workspaceId;
            this._appType = MessageDefine.MsgAppTypes.WorkSpace;
            this._domainType = MessageDefine.MsgDomainTypes.Entity;
        }
    }
}
