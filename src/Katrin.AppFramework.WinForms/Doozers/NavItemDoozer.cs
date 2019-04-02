using ICSharpCode.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Doozers
{
    public class NavItemDescriptor
    {
        public object Caller { get; private set; }
        public Codon Codon { get; private set; }
        public IList SubItems{get; private set;}

        public NavItemDescriptor(object caller, Codon codon, IList subItems)
        {
            Caller = caller;
            Codon = codon;
            SubItems = subItems;
        }
    }

    public class NavItemDoozer: IDoozer
    {
        public bool HandleConditions
        {
            get { return true; }
        }

        public object BuildItem(BuildItemArgs args)
        {
            return new NavItemDescriptor(args.Caller, args.Codon, args.BuildSubItems<object>());
        }
    }
}
