using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.MetadataServiceReference;
using System.Collections;


namespace Katrin.Win.MainModule.Views.Invoice
{
    public interface IInvoiceDetailView : IEntityDetailView
    {
        void BindContract(List<Guid> selectedContracts);
        ArrayList SelectedContracts { get; }
    }
}
