using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.CompositeUI;
using DevExpress.Utils.Serializing;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;

namespace Katrin.Win
{
    public static class XtraSerializerExtenison
    {
        //public static void RestoreLayoutFromString(this ISupportXtraSerializer serializer, string layout)
        //{
        //    using (var stream = new MemoryStream())
        //    {
        //        if (string.IsNullOrEmpty(layout)) return;
        //        var writter = new StreamWriter(stream);
        //        writter.AutoFlush = true;
        //        writter.Write(layout);

        //        stream.Position = 0;
        //        serializer.RestoreLayoutFromStream(stream);
        //    }
        //}

        public static void RestoreLayoutFromString(this ColumnView serializer, string layout)
        {
            using (var stream = new MemoryStream())
            {
                if (string.IsNullOrEmpty(layout)) return;
                var writter = new StreamWriter(stream);
                writter.AutoFlush = true;
                writter.Write(layout);

                stream.Position = 0;
                serializer.RestoreLayoutFromStream(stream, DevExpress.Utils.OptionsLayoutBase.FullLayout);
            }
        }

        public static void SaveLayoutToString(this ColumnView serializer, StringBuilder layout)
        {
            using (var stream = new MemoryStream())
            {
                serializer.SaveLayoutToStream(stream, DevExpress.Utils.OptionsLayoutBase.FullLayout);
                stream.Position = 0;
                var reader = new StreamReader(stream);
                StringWriter writter = new StringWriter(layout);
                writter.Write(reader.ReadToEnd());
                writter.Flush();
            }
        }
    }
}
