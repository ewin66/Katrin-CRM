using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Messages
{
    /// <summary>
    /// this message sended when Save or Save&close.
    /// Notify related module to refresh.
    /// author:hecq
    /// date:2012-11-14
    /// </summary>
    public class NotifyRelatedMessage
    {
        public string ObjectName { get; set; }
    }
}
