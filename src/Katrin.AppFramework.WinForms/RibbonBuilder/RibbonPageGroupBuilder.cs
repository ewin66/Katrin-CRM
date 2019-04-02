
using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraBars;
using ICSharpCode.Core;
namespace Katrin.AppFramework.WinForms.RibbonBuilder
{
    public class RibbonPageGroupBuilder : AbstractPartBuilder
    {
        public override object Build(ICSharpCode.Core.Codon codon, object caller, IEnumerable<ICSharpCode.Core.ICondition> conditions)
        {
            var label = codon.Properties["label"] ?? codon.Id;
            var caption = StringParser.Parse(label);
            RibbonPageGroup ribbonPage = new RibbonPageGroup(caption);
            ribbonPage.AllowTextClipping = false;
            ribbonPage.Name = codon.Id;
            ribbonPage.ItemLinks.CollectionChanged += ItemLinks_CollectionChanged;
            return ribbonPage;
        }

        void ItemLinks_CollectionChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e)
        {
            if (!(e.Element is BarButtonItemLink)) return;
            BarButtonItemLink linkItem = e.Element as BarButtonItemLink;
            
            if (linkItem.Item == null) return;
            if (!(linkItem.Item is BarButtonItemEx)) return;
            var barButton = linkItem.Item as BarButtonItemEx;
            if(barButton.BeginGroup)
                linkItem.BeginGroup = true;   
        }
    }
}
