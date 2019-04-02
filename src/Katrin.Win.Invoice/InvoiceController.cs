using Katrin.AppFramework.WinForms.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Katrin.Win.InvoiceModule
{
    public class InvoiceController : ListController
    {
        public override string ObjectName
        {
            get
            {
                return "Invoice";
            }
        }
    }
}
