
using System;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.ViewInterface;
using Katrin.AppFramework.WinForms.Views;
using ICSharpCode.Core;
using Katrin.Domain.Impl;

namespace Katrin.Win.OpportunityModule
{

    public class OpVisibilityConditionEvaluator : IConditionEvaluator
	{
        /// <summary>
        /// check the command won,fail,recyle can be visibale.
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
		public bool IsValid(object caller, Condition condition)
		{
            if (!(caller is OpportunityDetailController)) return true;
            OpportunityDetailController detailpresenter = (OpportunityDetailController)caller;
            string itemType = condition.Properties["type"];
            Opportunity opportunity = detailpresenter.ObjectEntity as Opportunity;

          

            if (detailpresenter.WorkingMode == EntityDetailWorkingMode.Add ||
                detailpresenter.WorkingMode == EntityDetailWorkingMode.View ||
                detailpresenter.WorkingMode == EntityDetailWorkingMode.Convert)
            {
                return false;
            }

            switch (itemType)
            {
                case "Won":         
            
                case "Fail":
                    if (opportunity.StatusCode != (int)OpportunityStatus.InProgress)
                    {
                        return false;
                    }
           
                    break;
                case "Recyle":
                    if (opportunity.StatusCode != (int)OpportunityStatus.Lost)
                    {
                        return false;
                    }
                    break;
                default:
                    throw new Exception("Unkown cmd type in opportunity Condition,they must be Won,Fail,Recyle");
                    break;
            }

            return true;
    
		}
	}
}
