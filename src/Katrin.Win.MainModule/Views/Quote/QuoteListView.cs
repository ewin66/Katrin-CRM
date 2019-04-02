using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Katrin.Win.Common.Core;
using System.Collections.Generic;
using Katrin.Win.Common;
namespace Katrin.Win.MainModule.Views.Quote
{
    public partial class QuoteListView : EntityListView
    {
        //protected override object GetData(string entityName, string predicate, params object[] values)
        //{
        //    Dictionary<string, string> extraColunms = new Dictionary<string, string>();
        //    extraColunms.Add("OpportunityName", "Opportunity==null?null:Opportunity.Name");
        //    extraColunms.Add("OwnerName", "Owner == null?null:Owner.FullName");
        //    return DynamicDataServiceContext.GetEntities(entityName, extraColunms, predicate, values);
        //}
    }
}
