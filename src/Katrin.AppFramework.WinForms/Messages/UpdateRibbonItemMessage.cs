using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Messages
{
    public class UpdateRibbonItemMessage: AbstractMessage
    {
        public string ItemName { get; set; }
        public UpdateRibbonItemMessage(Guid workspaceId, string objectName)
        {
            this._objectName = objectName;
            this._workspceId = workspaceId;
        }
        public UpdateRibbonItemMessage(Guid workspaceId, string objectName,string itemName)
        {
            this._objectName = objectName;
            this._workspceId = workspaceId;
            this.ItemName = itemName;
        }
    }
}
