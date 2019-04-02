using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Katrin.Win.Infrastructure.LayoutSerialize
{
    public interface ISupportLayoutSerializer
    {
        Dictionary<string, ILayoutSerializer> SerializableObjects { get; }
    }
}
