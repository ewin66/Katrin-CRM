using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Messages
{
    public class ObjectSetChangedMessage : AbstractMessage
    {
        public string ParentObjectName { get; set; }
    }
}
