using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Core;

namespace Katrin.Win.MainModule.Views.Contract
{
    public class ContractController : EntityListController<ContractListView, ContractDetailView>
    {
        protected override string EntityName
        {
            get { return "Contract"; }
        }
    }
}
