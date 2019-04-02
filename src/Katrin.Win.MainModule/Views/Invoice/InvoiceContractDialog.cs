using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using System.Collections;
using System.IO;
using System.Reflection;
using Katrin.Win.Common.MetadataServiceReference;
namespace Katrin.Win.MainModule.Views.Invoice
{
    [SmartPart]
    public partial class InvoiceContractDialog : XtraForm, IInvoiceContractDialog
    {
        private  Dictionary<Guid,object> _selectedContracts = new Dictionary<Guid,object>();
        public event EventHandler InvoiceContractOkClicked;

        public Dictionary<Guid, object> SelectedContracts
        {
            get { return _selectedContracts; }
            set { _selectedContracts = value; }
        }
        private InvoiceContractDialogPresenter _presenter;

        [CreateNew]
        public InvoiceContractDialogPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        public InvoiceContractDialog()
        {
            InitializeComponent();

            //Assembly asm = this.GetType().Assembly;
            //Stream stream = asm.GetManifestResourceStream("Katrin.Win.MainModule.DefaultLayout.Contract.List.xml");

            //EntityGridView.RestoreDefaultLayout("Contract", stream);
        }

        public void ShowView()
        {
            ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            PostEditors();
            EventHandler handler = InvoiceContractOkClicked;
            if (handler != null)
            {
                handler(this, e);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public  void InitEditors(Entity entity, List<LocalizedLabel> labels)
        {
            lkpStatusCode.BindPickList(entity, "StatusCode");
        }

        public void BindList(IEnumerable contracts)
        {
            
            entityBindingSource.DataSource = contracts;
        }

        public void PostEditors()
        {
            EntityGridView.PostEditor();
        }

        private void EntityGridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Row == null) return;
            Guid entityID = (Guid)e.Row.GetType().GetProperty("ContractId").GetValue(e.Row, null);
            if (e.IsGetData)
            {
                e.Value = SelectedContracts.ContainsKey(entityID);
            }
            else
            {
                bool isSelected = (bool)e.Value;
                if (isSelected)
                {
                    if (!SelectedContracts.ContainsKey(entityID)) SelectedContracts.Add(entityID, e.Row);
                }
                else
                {
                    SelectedContracts.Remove(entityID);
                }
            }
        }
    }

}
