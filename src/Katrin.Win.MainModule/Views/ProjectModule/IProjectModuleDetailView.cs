using Katrin.Win.Common.Core;
using Katrin.Win.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.MainModule.Views.ProjectModule
{
    public interface IProjectModuleDetailView : IEntityDetailView
    {
        void SetProjectEable(bool enable);
        bool ValidateResult { get; set; }
        event EventHandler<EventArgs<Guid>> OnProjectChange;
    }
}
