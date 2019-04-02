using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using DevExpress.XtraEditors.Controls;

using Katrin.Win.Common.Controls;
using DevExpress.XtraPrinting.Control;
using Katrin.AppFramework.Extensions;
using ICSharpCode.Core;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Views;

namespace Katrin.Win.OpportunityReportModule.Report
{
    public partial class OpportunityReportView : BaseView, IOpportunityReportView
    {
        public event EventHandler SearchReport;
        public event EventHandler OnViewReady;
        public event EventHandler<EventArgs<OpportunityOverview>> NameCellClicked
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
                                        DisplayName = StringParser.Parse("${res:name}"),
                                        Value = (int) Enum.Parse(typeof (T), name)
                                    }).ToList();
            if (!string.IsNullOrEmpty(emptyText))
            {
                string localizedEmptyText = StringParser.Parse("${res:emptyText}");
                statusItems.Insert(0, new LookupListItem<int?> {DisplayName = localizedEmptyText, Value = emptyValue});
            }
            lookUpEdit.Properties.InitializeLookUpEdit(statusItems);
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (OnViewReady != null) OnViewReady(null, null);
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
