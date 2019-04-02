using Katrin.AppFramework.WinForms.Controller;
using Katrin.Win.DetailViewModule;
using Katrin.Win.OpportunityModule;
using System;
using System.Linq;


namespace Katrin.Win.OpportunityModule
{
    public class OpportunityController : ListController
    {
        public override string ObjectName
        {
            get
            {
                return "Opportunity";
            }
        }

        protected override string RibbonPath
        {
            get { return "/Opportunity/List/Ribbon"; }
        }
    }
}
