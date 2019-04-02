using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Katrin.AppFramework.WinForms.CommandManage
{
    class CommandDrawer
    {
        public void SetItemGlyph(ICSharpCode.Core.Codon codon,BarItem item)
        {
            string imageName = codon.Properties["imageName"];
            string overlayName = codon.Properties["overlay"];


            if (string.IsNullOrEmpty(imageName)) return;
            var icon = WinFormsResourceService.GetIcon(imageName.ToLower());

            if (icon == null) return;
            Image largeImage = icon.ToBitmap();

            if (!string.IsNullOrEmpty(overlayName))
            {
                var overlay = WinFormsResourceService.GetBitmap(overlayName.ToLower());
                if (overlay != null)
                    DrawOverlay(largeImage, overlay);
            }
            item.LargeGlyph = largeImage;
            item.Glyph = new Bitmap(largeImage, new Size(16, 16));
        }

        private void DrawOverlay(Image image, Image overlay)
        {
            if (overlay == null) return;
            using (var canvas = Graphics.FromImage(image))
            {
                canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                int x = image.Width - overlay.Width;
                int y = image.Height - overlay.Height;
                canvas.DrawImage(overlay, x, y);
                canvas.Save();
            }
        }
    }
}
