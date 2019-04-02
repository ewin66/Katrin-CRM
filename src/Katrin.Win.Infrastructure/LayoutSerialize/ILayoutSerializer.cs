using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Katrin.Win.Infrastructure.LayoutSerialize
{
    public interface ILayoutSerializer
    {
        void RestoreLayoutFromStream(Stream stream);
        void SaveLayoutToStream(Stream stream);
    }
}
