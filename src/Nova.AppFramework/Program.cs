using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework
{
    public class Program
    {
        [STAThread]
        static void Main()
        {
            WinApplication application = new WinApplication();
            application.Start();
        }
    }
}
