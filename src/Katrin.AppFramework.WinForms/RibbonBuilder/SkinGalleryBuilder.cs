using Katrin.AppFramework.Parts;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.RibbonBuilder
{
    public class SkinGalleryBuilder : AbstractPartBuilder
    {
        public override object Build(ICSharpCode.Core.Codon codon, object caller, IEnumerable<ICSharpCode.Core.ICondition> conditions)
        {
            RibbonGalleryBarItem skinGalleryBarItem = new RibbonGalleryBarItem();
            skinGalleryBarItem.Gallery.AllowHoverImages = true;
            skinGalleryBarItem.Gallery.FixedHoverImageSize = false;
            skinGalleryBarItem.Gallery.ItemCheckMode = DevExpress.XtraBars.Ribbon.Gallery.ItemCheckMode.SingleRadio;
            skinGalleryBarItem.Id = 1;
            skinGalleryBarItem.Name = "skinGalleryBarItem";
            var label = codon.Properties["label"] ?? codon.Id;
            skinGalleryBarItem.Caption = label;
            return skinGalleryBarItem;
        }
    }
}
