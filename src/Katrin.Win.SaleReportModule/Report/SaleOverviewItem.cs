using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ICSharpCode.Core;

namespace Katrin.Win.SaleReportModule.Report
{
    public class SaleOverview
    {
        public string UnitName
        {
            get
            {
                if (UnitType == Report.UnitType.Year)
                {
                    return Year.ToString() + ResourceService.GetString("Year");
                }
                else if (UnitType == Report.UnitType.Season)
                {
                    return Year.ToString() + ResourceService.GetString("Year") + "-" + Season.ToString() + ResourceService.GetString("Season");
                }
                else
                {
                    return Year.ToString() + ResourceService.GetString("Year") + "-" + Month.ToString() + ResourceService.GetString("Month");
                }
            }
        }
        public UnitType UnitType { get; set; }
        public int Year { get; set; }
        public int Season {get;set;}
        public int Month { get; set; }
        public string SalesName { get; set; }
        public string DepartMentName { get; set; }
        public string TechnologyName { get; set; }
        public string TechnologyPerson { get; set; }
        public double LeadNumber { get; set; }
        public double FirstEmailCount { get; set; }
        public double ResponseRate {
            get
            {
                return LeadNumber == 0?0:FirstEmailCount * 1.0 / LeadNumber;
            }
        }
        public double NumberIntoOpportunity { get; set; }
        public double RateIntoOpportunity {
            get
            {
                return LeadNumber == 0 ? 0 : NumberIntoOpportunity * 1.0 / LeadNumber;
            }
        }
        public double NumberOfTheDead { get; set; }
        public double ClosureRate {
            get
            {
                return LeadNumber == 0 ? 0 : NumberOfTheDead * 1.0 / LeadNumber;
            }
        }
        public double OpportunityNumber { get; set; }
        public double NumberIntoContract { get; set; }
        public double QuoteSuccessRate {
            get
            {
                return OpportunityNumber == 0 ? 0 : NumberIntoContract * 1.0 / OpportunityNumber;
            }
        }
        public decimal ContractAmount { get; set; }
        public double ContractNumber { get; set; }
        public double OldCustomerNumber { get; set; }
        public double RateOfOldCustomer {
            get
            {
                return ContractNumber == 0 ? 0 : OldCustomerNumber * 1.0 / ContractNumber;
            }
        } 
    }


}
