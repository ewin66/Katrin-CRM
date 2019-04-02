using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Core;
using Katrin.Win.Infrastructure;

namespace Katrin.Win.MainModule.Views.ProjectVersion
{
    public interface IProjectVersionDetailView : IEntityDetailView
    {
        void SetProjectEable(bool enable);
        bool ValidateResult { get; set; }
        event EventHandler<EventArgs<Guid>> OnProjectChange;
    }
}
