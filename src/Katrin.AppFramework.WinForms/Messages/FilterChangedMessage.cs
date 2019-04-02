using DevExpress.Data.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Messages
{
    public class FilterChangedMessage: ObjectMessage
    {
        public CriteriaOperator Filter { get; set; }
    }
}
