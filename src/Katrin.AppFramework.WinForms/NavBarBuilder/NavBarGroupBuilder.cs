using Katrin.AppFramework.Parts;
using DevExpress.XtraNavBar;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.NavBarBuilder
{
    public class NavBarGroupBuilder : AbstractPartBuilder
    {
        public override object Build(ICSharpCode.Core.Codon codon, object caller, IEnumerable<ICSharpCode.Core.ICondition> conditions)
        {
            var label = codon.Properties["label"] ?? codon.Id;
            var caption = StringParser.Parse(label);
            var group = new NavBarGroup(caption);
            SetItemImage(group, codon);
            return group;
        }

        private void SetItemImage(NavBarGroup group,ICSharpCode.Core.Codon codon)
        {
            if (string.IsNullOrEmpty(codon.Properties["icon"])) return;
            var icon = WinFormsResourceService.GetIcon(codon.Properties["icon"]);
            if (icon == null) return;
            group.LargeImage = icon.ToBitmap();
            group.SmallImage = icon.ToBitmap();
        }
    }
}
