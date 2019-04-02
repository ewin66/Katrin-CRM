using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Core;
using Katrin.Win.Infrastructure;

namespace Katrin.Win.MainModule.Views.ProjectIteration
{
    public interface IProjectIterationDetailView : IEntityDetailView
    {
        void SetProjectEable(bool enable);
        bool ValidateResult { get; set; }
        event EventHandler<EventArgs<Guid>> OnProjectChange;
        event EventHandler<EventArgs<Guid>> OnVersionChange;
    }
}
