
using DevExpress.XtraBars.Ribbon;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.RibbonBuilder
{
    public class RibbonPageBuilder : AbstractPartBuilder
    {
        public override object Build(ICSharpCode.Core.Codon codon, object caller, IEnumerable<ICSharpCode.Core.ICondition> conditions)
        {
            var label = codon.Properties["label"] ?? codon.Id;
            var caption = StringParser.Parse(label);
            var page = new RibbonPage(caption);
            int mergeOrder = codon.Properties.Get("mergeOrder", -1);
            page.MergeOrder = mergeOrder;
            page.Name = codon.Id;
            return page;
        }
    }
}
