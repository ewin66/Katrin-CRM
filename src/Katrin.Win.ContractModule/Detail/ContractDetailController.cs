using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Katrin.Win.DetailViewModule;

namespace Katrin.Win.ContractModule.Detail
{
    public class ContractDetailController : ObjectDetailController
    {
        public override string ObjectName
        {
            get
            {
                return "Contract";
            }
        }
    }
}
