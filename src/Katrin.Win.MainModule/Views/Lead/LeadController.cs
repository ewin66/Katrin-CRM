using System;
using System.Linq;
using Katrin.Win.Common.Core;

namespace Katrin.Win.MainModule.Views.Lead
{
    public class LeadController : EntityListController<LeadListView, LeadDetailView>
    {
        protected override string EntityName
        {
            get { return "Lead"; }
        }
    }
}
