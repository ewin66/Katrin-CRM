using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Core;
using Katrin.Win.Infrastructure;

namespace Katrin.Win.MainModule.Views.ProjectTask
{
    public interface IProjectTaskDetailView : IEntityDetailView
    {
        void SetProjectEable(bool enable);
        event EventHandler<EventArgs<Guid>> OnProjectChange;
    }
}
