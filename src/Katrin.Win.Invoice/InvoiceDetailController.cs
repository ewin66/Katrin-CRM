using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Windows.Forms;


using Katrin.Win.Common;
using System.Collections;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.Domain.Impl;
using Katrin.AppFramework.Data;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Workspaces;
using Katrin.AppFramework.WinForms;
//using System.Data.Services.Client;


namespace Katrin.Win.InvoiceModule
{
    public enum InvoiceStatus
    {
        InProgress = 1,
        OnHold,
        Won,
        Lost
    }
    public class InvoiceDetailController : ObjectDetailController
    {
        private InvoiceDetailView _invoiceDetailView;
        public InvoiceDetailController()
        {
            //this._e = "Invoice";
        }
        public override string ObjectName
        {
            get
            {
                return "Invoice";
            }
        }
        protected override bool OnSaving()
        {
            SetInvoiceContract();
            return base.OnSaving();
        }

        protected override object GetEntity()
        {
            var entity = this._objectSpace.GetOrNew(this.ObjectName, this.ObjectId, "InvoiceContracts,CreatedBy,ModifiedBy");
            Katrin.Domain.Impl.Invoice invoice = entity as Katrin.Domain.Impl.Invoice;
            if (WorkingMode == EntityDetailWorkingMode.Add)
            {
                invoice.StatusCode = (int)5;
                invoice.TransactionCurrencyId = Guid.Parse("992a4ff1-856d-421f-a928-654357e4b70b");
            }
            return invoice;
        }

        private void SetInvoiceContract()
        {
            InvoiceDetailView view = this._detailView as InvoiceDetailView;
            Katrin.Domain.Impl.Invoice invoice = this.ObjectEntity as Katrin.Domain.Impl.Invoice;
            if (view.SelectedContracts != null)
            {
                //Type contractType = DynamicTypeBuilder.Instance.GetDynamicType("InvoiceContract");
                var invoiceContracts = invoice.InvoiceContracts;

                while (invoiceContracts.Count > 0)
                {
                    invoiceContracts.RemoveAt(0);
                }
                foreach (var selectedContract in view.SelectedContracts)
                {
                    //var contract = Activator.CreateInstance(contractType);
                    var scontract = ConvertData.Convert<InvoiceContract>(selectedContract);
                    InvoiceContract contract = new InvoiceContract();
                    contract.InvoiceContractId = Guid.NewGuid();
                    contract.InvoiceId = this.ObjectId;
                    contract.ContractId = scontract.ContractId;
                    invoiceContracts.Add(contract);
                }
            }
        }

        protected override void OnViewSet()
        {
            _invoiceDetailView = this._detailView as InvoiceDetailView;
            _invoiceDetailView.OnStatusCodeChanged += OnStatusCodeChanged;
            base.OnViewSet();
            Katrin.Domain.Impl.Invoice invoice = this.ObjectEntity as Katrin.Domain.Impl.Invoice;
            System.Data.Services.Client.DataServiceCollection<InvoiceContract> inviceContracts =
                invoice.InvoiceContracts;
            var selectedContracts = new List<Guid>();
            foreach (var inviceContract in inviceContracts)
            {
                Guid contractId = inviceContract.ContractId;
                selectedContracts.Add(contractId);

            }

            _invoiceDetailView.BindContract(selectedContracts);
        }

        void OnStatusCodeChanged(object sender, EventArgs e)
        {
            Guid selectedId = Guid.Empty;
            selectedId = _objectSpace.GetObjectId(ObjectName, ObjectEntity);
            var parameters = new ActionParameters(ObjectName, selectedId, ViewShowType.Show)
                {
                    {"NoteSubject","Invoice Cancelled"},
                    {"PutNoteEnable","false"}
                };
            App.Instance.Invoke("NoteDetail", "NoteAction", parameters);
        }
    }
}
