using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraBars;
using System.Drawing;
using System.Drawing.Drawing2D;
using Katrin.Win.Common.Properties;

namespace Katrin.Win.Common.Controls
{
    public sealed class BarButtonItemEx : BarButtonItem
    {
        public BarButtonItemEx(string imageName, string overlayImageName)
        {
            if (!string.IsNullOrEmpty(imageName))
            {
                var image = GetIcon(imageName);
                if (image == null) return;
                if (!string.IsNullOrEmpty(overlayImageName))
                {
                    using (var overlay = GetOverlayImage(overlayImageName))
                    {
                        DrawOverlay(image, overlay);
                    }
                }
                LargeGlyph = image;
                Glyph = new Bitmap(image, new Size(16,16));
            }
        }


        private static Bitmap GetIcon(string name)
        {
            return GetIcon(name, new Size(48, 48), ".ico");
        }

        private static Bitmap GetIcon(string name, Size size,string extendName)
        {
            var asm = System.Reflection.Assembly.GetExecutingAssembly();
            var rnames = asm.GetManifestResourceNames();
            var tofind = "." + name + extendName;
            var rname = rnames.Where(c => c.EndsWith(tofind, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            if (rname != null)
            {
                using (var stream = asm.GetManifestResourceStream(rname))
                {
                    if (extendName.EndsWith(".ico"))
                    {
                        Icon icon = new Icon(stream, size);
                        return icon.ToBitmap();
                    }
                    else
                    {
                        return new Bitmap(stream, true);
                    }
                }
            }
            return null;
        } 


        private static Bitmap GetOverlayImage(string name)
        {
            //return (Bitmap)Resources.ResourceManager.GetObject("ri_overlay_" + name.ToLower());
            string overLayName = "overlay_" + name.ToLower();
            return GetIcon(overLayName,new Size(16,16),".png");
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
