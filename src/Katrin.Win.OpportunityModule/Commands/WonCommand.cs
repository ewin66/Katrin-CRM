using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.Core;
using Katrin.Domain.Impl;

namespace Katrin.Win.OpportunityModule.Commands
{
    public class WonCommand : AbstractCommand
    {
        public override void Run()
        {
            if (!(this.Owner is OpportunityDetailController))
            {
                throw new Exception("opportunity cmd error:owner must be OpportunityDetailController");
            }
            OpportunityDetailController opController = (OpportunityDetailController)this.Owner;            
            Opportunity op = opController.ObjectEntity as Opportunity;
            opController.SetOpportunityWon(op);        
        }
    }
}
