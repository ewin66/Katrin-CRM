using System;
using System.Linq;
using Microsoft.Practices.CompositeUI.EventBroker;
using Katrin.Win.MainModule.Constants;
using Katrin.Win.Infrastructure;
using System.Collections.Generic;
using Katrin.Win.Common.Core;
using Microsoft.Practices.CompositeUI;
using Katrin.Win.MainModule.Views.Note;
using CABDevExpress.SmartPartInfos;
using Microsoft.Practices.CompositeUI.Commands;

namespace Katrin.Win.MainModule.Views.Opportunity
{
    public class OpportunityController : EntityListController<OpportunityListView, OpportunityDetailView>
    {
        protected override string EntityName
        {
            get { return "Opportunity"; }
        }
    }
}
