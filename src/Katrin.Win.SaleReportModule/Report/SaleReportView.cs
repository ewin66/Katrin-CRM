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

namespace Katrin.Win.SaleReportModule.Report
{
    public partial class SaleReportView : BaseView, ISaleReportView
    {
        public event EventHandler SearchReport;
        public event EventHandler OnViewReady;
        public event EventHandler<EventArgs<SaleOverview>> NameCellClicked
        {
            add { _report.NameCellClicked +=value; }
            remove { _report.NameCellClicked -= value; }
        }

        private readonly SaleReport _report;

        public PrintControl ReportPrintControl
        {
            get { return printControl; }
        }

        public SaleReportView()
        {
            InitializeComponent();
            CreatePrintBarManager(printControl);
            _report = new SaleReport();
            printControl.PrintingSystem = _report.PrintingSystem;
            _report.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ClosePreview, CommandVisibility.None);
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

        public void DimensionItemChange(ArrayList dimensions)
        {
            _report.DimensionItemChange(dimensions);
        }

        public void ChangeChart(string stargetName, int dimsionIndex, int chartType)
        {
            _report.ChangeChart(stargetName, dimsionIndex, chartType);
        }

        public void SelectChart(int selectValue)
        {
            _report.SelectChart(selectValue);
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
