using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraBars.Ribbon;

namespace Katrin.AppFramework.WinForms.Controls
{
    public class MergeOwnerChangedEventArgs : EventArgs
    {
        public RibbonControl OldValue { get; private set; }
        public RibbonControl NewValue { get; private set; }

        public MergeOwnerChangedEventArgs(RibbonControl oldValue, RibbonControl newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }

    public class RibbonControlEx : RibbonControl
    {
        public event EventHandler<MergeOwnerChangedEventArgs> MergeOwnerChanged;

        public RibbonControlEx()
        {
            this.AutoSizeItems = true;
        }

        public new RibbonControl MergeOwner
        {
            get { return base.MergeOwner; }
            set
            {
                if (base.MergeOwner != value)
                {
                    var args = new MergeOwnerChangedEventArgs(base.MergeOwner, value);
                    base.MergeOwner = value;
                    OnMergeOwnerChanged(args);
                }
            }
        }

        protected override void RaiseMerge(RibbonMergeEventArgs e)
        {
            RibbonControlEx control = e.MergedChild as RibbonControlEx;
            control.MergeOwner = this;
            base.RaiseMerge(e);
        }

        protected virtual void OnMergeOwnerChanged(MergeOwnerChangedEventArgs args)
        {
            var handler = MergeOwnerChanged;
            if (handler != null) handler(this, args);
        }
    }
}
