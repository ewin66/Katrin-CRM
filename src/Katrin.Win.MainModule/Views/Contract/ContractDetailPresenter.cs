using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Infrastructure;
using Katrin.Win.Common;
using System.Collections;
using Katrin.Win.Common.MetadataServiceReference;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Katrin.Win.Common.Core;

namespace Katrin.Win.MainModule.Views.Contract
{
    public class ContractDetailPresenter : EntityDetailPresenter<IContractDetailView>
    {
        public ContractDetailPresenter()
        {
            EntityName = "Contract";
        }
    }
}
