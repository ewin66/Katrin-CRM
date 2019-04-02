using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Core;

namespace Katrin.Win.MainModule.Views.Invoice
{
    public class InvoiceController: EntityListController<InvoiceListView, InvoiceDetailView>
    {
        protected override string EntityName
        {
            get { return "Invoice"; }
        }
    }
}
