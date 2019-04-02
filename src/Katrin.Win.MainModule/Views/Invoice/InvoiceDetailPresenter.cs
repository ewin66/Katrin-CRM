using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Windows.Forms;
using Katrin.Win.Infrastructure;
using Microsoft.Practices.CompositeUI;
using Katrin.Win.Common.Core;
using Microsoft.Practices.CompositeUI.Commands;
using Katrin.Win.Common;
using System.Collections;
using Katrin.Win.Common.MetadataServiceReference;
using CABDevExpress.SmartPartInfos;
using Katrin.Win.MainModule.Constants;
namespace Katrin.Win.MainModule.Views.Invoice
{
    public class InvoiceDetailPresenter : EntityDetailPresenter<IInvoiceDetailView>
    {
        public InvoiceDetailPresenter()
        {
            EntityName = "Invoice";
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            SetInvoiceContract();
        }

        protected override object GetEntity()
        {
            var entity = DynamicDataServiceContext.GetOrNew(EntityName, EntityId, "InvoiceContracts,CreatedBy,ModifiedBy");
            if (WorkingMode == EntityDetailWorkingMode.Add)
            {
                entity.AsDyanmic().StatusCode = 1;
                entity.AsDyanmic().TransactionCurrencyId = Guid.Parse("992a4ff1-856d-421f-a928-654357e4b70b");
            }
            ConvertEntity(entity);
            return entity;
        }

        protected override void ConvertEntity(object entity)
        {
            if (ConvertEntiy != null && WorkingMode == EntityDetailWorkingMode.Convert && ConvertName != "" 
                && MetadataProvider.Instance.MappingList.Where(c => c.SourceAttributeName == "ContractId").Any())
            {
                Type contractType = DynamicTypeBuilder.Instance.GetDynamicType("InvoiceContract");
                var contract = Activator.CreateInstance(contractType);
                SetProperValue(ConvertEntiy, "ContractId", contract, "ContractId");
                SetProperValue(entity, "InvoiceId", contract, "InvoiceId");
                contract.GetType().GetProperty("InvoiceContractId").SetValue(contract, Guid.NewGuid(), null);
                IList inviceContracts = entity.GetType().GetProperty("InvoiceContracts").GetValue(entity, null) as IList;
                inviceContracts.Add(contract);
            }
            base.ConvertEntity(entity);
        }

        private void SetInvoiceContract()
        {
            if (View.SelectedContracts != null)
            {
                Type contractType = DynamicTypeBuilder.Instance.GetDynamicType("InvoiceContract");
                IList invoiceContracts = DynamicEntity.InvoiceContracts;
                while (invoiceContracts.Count>0)
                {
                    invoiceContracts.RemoveAt(0);
                }
                foreach (var selectedContract in View.SelectedContracts)
                {
                    
                    var contract = Activator.CreateInstance(contractType);
                    dynamic dynamicContract = new SysBits.DynamicProxies.DynamicProxy(contract);
                    dynamicContract.InvoiceContractId = Guid.NewGuid();
                    dynamicContract.InvoiceId = EntityId;
                    dynamicContract.ContractId = selectedContract.AsDyanmic().ContractId;
                    invoiceContracts.Add(contract);
                }
            }
        }

        protected override void OnViewSet()
        {
            base.OnViewSet();

            //var contractList = DynamicDataServiceContext.GetEntities("Contract");
            IList inviceContracts = DynamicEntity.InvoiceContracts;
            var selectedContracts = new List<Guid>();
            foreach (var inviceContract in inviceContracts)
            {
                Guid contractId = inviceContract.AsDyanmic().ContractId;
                selectedContracts.Add(contractId);
                //var contract = contractList.AsQueryable().Where("ContractId = @0", contractId)._First();
                //if (contract != null) selectedContracts.Add(contract);
            }

            View.BindContract(selectedContracts);
        }
    }
}
