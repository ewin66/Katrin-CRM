using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Katrin.Win.DetailViewModule;

namespace Katrin.Win.LeadModule.Detail
{
    public class LeadDetailController : ObjectDetailController
    {

        public override string ObjectName
        {
            get
            {
               
                return "Lead";
            }
        }

        protected override bool OnSaving()
        {
            
            var lead = (Katrin.Domain.Impl.Lead)ObjectEntity;
            string firstName = lead.FirstName;
            string lastName = lead.LastName;
            lead.FullName = firstName + " " + lastName;
            return base.OnSaving(); 
        }
    }
}
