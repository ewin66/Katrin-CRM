using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Katrin.Win.Common.MetadataServiceReference;
using Katrin.Win.Common.Core;

namespace Katrin.Win.MainModule.Views.User
{
    public interface IUserDetailView : IEntityDetailView
    {
        void ClearPassword();
        bool HasSave { get; set; }
    }
}
