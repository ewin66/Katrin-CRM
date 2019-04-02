using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.MetadataServiceReference;
namespace Katrin.Win.MainModule.Views.Invoice
{
    public interface IInvoiceContractDialog 
    {
        event EventHandler InvoiceContractOkClicked;
        void ShowView();
        void BindList(IEnumerable contracts);
        void Close();
        void PostEditors();
        void InitEditors(Entity entity, List<LocalizedLabel> labels);
        Dictionary<Guid, object> SelectedContracts { get; set; }
    }
}
