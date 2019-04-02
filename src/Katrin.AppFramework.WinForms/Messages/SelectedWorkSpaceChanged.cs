using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Messages
{
    /// <summary>
    /// this message sended when user selected workspace.
    /// </summary>
    public class SelectedWorkSpaceChanged
    {
        public string WorkSpaceName { get; set; }
        public string ModuleName { get; set; }
    }
    /// <summary>
    /// this message sended when user closed workspace.
    /// </summary>
    public class WorkSpaceClosed
    {
        public string WorkSpaceName { get; set; }
        public string ModuleName { get; set; }
    }
}
