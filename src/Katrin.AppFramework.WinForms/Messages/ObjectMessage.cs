using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Messages
{
    public class ObjectMessage
    {
        public string ObjectName { get; set; }
    }

    /// <summary>
    /// this message sended when object added
    /// date 2012-11-13
    /// </summary>
    public class ObjectAddedMessage
    {
        public string ObjectName { get; set; }
        public Guid ObjectID { get; set; }
    }
}
