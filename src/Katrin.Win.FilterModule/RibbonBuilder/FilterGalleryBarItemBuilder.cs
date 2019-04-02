using Katrin.AppFramework.Parts;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using System;
using System.Collections.Generic;
using Katrin.AppFramework.WinForms;

namespace Katrin.Win.FilterModule.RibbonBuilder
{
    public class FilterGalleryBarItemBuilder : AbstractPartBuilder
    {
        public override object Build(ICSharpCode.Core.Codon codon, object caller, IEnumerable<ICSharpCode.Core.ICondition> conditions)
        {
            FilterGalleryBarItem galleryBarItem = new FilterGalleryBarItem(caller);
            return galleryBarItem;
        }
    }
}
