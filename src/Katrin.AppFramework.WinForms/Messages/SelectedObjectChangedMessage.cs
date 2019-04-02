using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Messages
{
    public class SelectedObjectChangedMessage: AbstractMessage
    {
        public object SelectedObject { get; set; }
        public SelectedObjectChangedMessage()
        {
            this._appType = MessageDefine.MsgAppTypes.WorkSpace;
            this._domainType = MessageDefine.MsgDomainTypes.Record;
        }
        //public Guid ObjectId { get; set; }
    }
}
