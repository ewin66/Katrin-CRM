using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;

namespace Katrin.AppFramework.WinForms.Messages
{
    public class UpdateContextFilterMessage
    {
        public CriteriaOperator FixedFilter { get; set; }
        public UpdateContextFilterMessage()
        {
            
        }
    }
}
