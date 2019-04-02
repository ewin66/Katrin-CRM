using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Doozers
{
    public class DockPanelDoozer : IDoozer
    {
        public bool HandleConditions
        {
            get { return false; }
        }

        public object BuildItem(BuildItemArgs args)
        {
            return new DockPanelDescriptor(args.Caller, args.Codon);
        }
    }
}
