using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.MetadataServiceReference;

namespace Katrin.Win.MetadataManager.OptionSetView
{
    public interface IOptionSetDetailView
    {
        void Bind(object entity);
        event EventHandler SaveOptionSet;
    }
}
