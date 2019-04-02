using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Messages
{
    /// <summary>
    /// this message sended when gridview need formating service.
    /// author:hecq
    /// date:2012-11-13
    /// </summary>
   public class FormatRequestMessage
    {
     
       public string ObjectName { get; set; }
       public object GridView { get; set; }
    }
}
