using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.RibbonBuilder
{
    public class SkinGalleryInitializer: IUIElementInitializer
    {
        public void Initialize(object element)
        {
            RibbonGalleryBarItem skinGalleryBarItem = (RibbonGalleryBarItem)element;
            SkinHelper.InitSkinGallery(skinGalleryBarItem, true);
        }
    }
}
