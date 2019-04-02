using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Utils.Serializing;

namespace Katrin.Win.Infrastructure.LayoutSerialize
{
    public class XtraSerializerAdapter : ILayoutSerializer
    {
        private ISupportXtraSerializer _serializer;

        public XtraSerializerAdapter(ISupportXtraSerializer serializer)
        {
            _serializer = serializer;
        }

        public void RestoreLayoutFromStream(System.IO.Stream stream)
        {
            _serializer.RestoreLayoutFromStream(stream);
        }

        public void SaveLayoutToStream(System.IO.Stream stream)
        {
            _serializer.SaveLayoutToStream(stream);
        }
    }
}
