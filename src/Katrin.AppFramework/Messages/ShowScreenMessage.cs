using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.Messages
{
    public class ShowScreenMessage
    {
        public string Path { get; private set; }
        public string ObjectName { get; private set; }
        public ShowScreenMessage(string path,string objectName)
        {
            Path = path;
            ObjectName = objectName;
        }
    }
}
