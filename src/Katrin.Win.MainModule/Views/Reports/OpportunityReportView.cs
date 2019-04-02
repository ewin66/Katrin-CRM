using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Katrin.Win.MainModule.Properties;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraPrinting.Control;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using Microsoft.Practices.CompositeUI.Utility;
using Microsoft.Practices.ObjectBuilder;
using Katrin.Win.Common.Controls;

namespace Katrin.Win.MainModule.Views.Reports
{
    public partial class OpportunityReportView : XtraUserControl, IOpportunityReportView
    {
        private OpportunityReportPresenter _presenter;

        public event EventHandler SearchReport;
        public event EventHandler<DataEventArgs<OpportunityOverview>> NameCellClicked
        {
            add { _report.NameCellClicked +=value; }
            remove { _report.NameCellClicked -= value; }
        }

        private readonly OpportunityReport _report;

        public PrintControl ReportPrintControl
        {
            get { return printControl; }
        }

        public OpportunityReportView()
        {
            InitializeComponent();
            CreatePrintBarManager(printControl);
            _report = new OpportunityReport();
            printControl.PrintingSystem = _report.PrintingSystem;
            _report.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ClosePreview, CommandVisibility.None);
        }

        private void BindEnum<T>(LookUpEdit lookUpEdit, string emptyText, int? emptyValue)
        {
            var statusTypeNames = Enum.GetNames(typeof (T));
            var statusItems = statusTypeNames
                .Select(name => new LookupListItem<int?>
                                    {
                                        DisplayName = Resources.ResourceManager.GetString(name),
                                        Value = (int) Enum.Parse(typeof (T), name)
                                    }).ToList();
            if (!string.IsNullOrEmpty(emptyText))
            {
                string localizedEmptyText = Resources.ResourceManager.GetString(emptyText);
                statusItems.Insert(0, new LookupListItem<int?> {DisplayName = localizedEmptyText, Value = emptyValue});
            }
            lookUpEdit.Properties.InitializeLookUpEdit(statusItems);
        }

        [CreateNew]
        public OpportunityReportPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _presenter.OnViewReady();
        }


        public void Bind(IEnumerable list)
        {
            _report.DataSource = list;
            _report.CreateDocument(true);
        }


        
        #region ????
        /// <summary>
        /// ?????
        /// </summary>
        /// <param name="pc"></param>
        /// <returns></returns>
		protected PrintBarManager CreatePrintBarManager(PrintControl pc) {
			PrintBarManager printBarManager = new PrintBarManager();
            //printBarManager.Form = printControl;
            //printBarManager.Initialize(pc);
            //printBarManager.MainMenu.Visible = false;
            //printBarManager.AllowCustomization = false;
			return printBarManager;
		}


        /// <summary>
        /// ???????????
        /// </summary>
        /// <returns></returns>
        public bool ValidateData()
        {
            return true;
        }

        #endregion


    }
}
