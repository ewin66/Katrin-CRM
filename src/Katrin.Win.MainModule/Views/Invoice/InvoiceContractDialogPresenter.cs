using System;
using System.Globalization;
using System.Linq;
using DevExpress.Utils;
using System.Collections.Generic;
using Katrin.Win.Infrastructure;
using Microsoft.Practices.CompositeUI;
using Katrin.Win.Common;
using System.Collections;
using Katrin.Win.Common.MetadataServiceReference;

namespace Katrin.Win.MainModule.Views.Invoice
{
    public class InvoiceContractDialogPresenter : Presenter<IInvoiceContractDialog>
    {

        private IDynamicDataServiceContext _dynamicDataServiceContext;

        protected IDynamicDataServiceContext DynamicDataServiceContext
        {
            get { return _dynamicDataServiceContext ?? (_dynamicDataServiceContext = new DynamicDataServiceContext()); }
        }

        public void InvoiceContractOkClicked(object sender, EventArgs e)
        {
            WorkItem.State["invoiceContractResultList"] = View.SelectedContracts;
            View.Close();
        }

        private  IEnumerable GetData()
        {
            string entityName = "Contract";
            Dictionary<string, string> extraColumns = new Dictionary<string, string>();
            extraColumns.Add("BillingCustomerName", "BillingCustomer==null?null:BillingCustomer.Name");
            extraColumns.Add("OpportunityName", "Opportunity==null?null:Opportunity.Name");
            extraColumns.Add("OwnerName", "Owner==null?null:Owner.FullName");
            extraColumns.Add("DepartmentName", "Department == null?null:Department.Name");
            //extraColumns.Add("IsSelected", "Department == null?null:Department.Name");
            var resultList = DynamicDataServiceContext.GetEntities(entityName,extraColumns, null,null);
            return resultList;
        }

        protected override void OnViewSet()
        {
            View.InvoiceContractOkClicked += InvoiceContractOkClicked;
            var metadataService = new MetadataServiceClient();
            var entityMetadata = metadataService.GetMetaEntities().First(e => e.TableName == "Contract");
            int langId = System.Globalization.CultureInfo.CurrentCulture.LCID;
            var labels = metadataService.GetLocalizedLabels(langId);
            View.InitEditors(entityMetadata, labels);

            if (WorkItem.State["invoiceContractList"] != null)
            {
                var invoiceContractList = (IList)WorkItem.State["invoiceContractList"];
                View.SelectedContracts.Clear();
                foreach (object obj in invoiceContractList)
                {
                    dynamic dynamicEntity = new SysBits.DynamicProxies.DynamicProxy(obj);
                    Guid key = dynamicEntity.ContractId;
                    if (!View.SelectedContracts.ContainsKey(key))
                        View.SelectedContracts.Add(key, obj);
                }
            }
            View.BindList(GetData());
            View.ShowView();
        }
    }
}
