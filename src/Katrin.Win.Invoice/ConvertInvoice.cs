using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.Metadata;
using Katrin.AppFramework.WinForms.Views;

namespace Katrin.Win.InvoiceModule
{
    public class ConvertInvoice : IObjectConvert
    {
        public void ConvertObject(object sourceObject,object targetObject)
        {
            if (MetadataRepository.MappingList.Where(c => c.SourceAttributeName == "ContractId").Any())
            {
                var contractIdPro = sourceObject.GetType().GetProperty("ContractId");
                if (contractIdPro == null) return;
                var invoiceContract = new Katrin.Domain.Impl.InvoiceContract();
                var invoce = (Katrin.Domain.Impl.Invoice)targetObject;
                //var contract = (Katrin.Domain.Impl.Contract)sourceObj;
                invoiceContract.ContractId = (Guid)contractIdPro.GetValue(sourceObject,null);
                invoiceContract.InvoiceId = invoce.InvoiceId;
                invoiceContract.InvoiceContractId = Guid.NewGuid();
                var inviceContracts = invoce.InvoiceContracts;
                inviceContracts.Add(invoiceContract);
            }
        }
    }
}
