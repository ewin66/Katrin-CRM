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


namespace Katrin.Win.MainModule.Views.ProjectReport
{
    public partial class ProjectReportView : XtraUserControl, IProjectReportView
    {
        private ProjectReportPresenter _presenter;

        public event EventHandler SearchReport;
        public event EventHandler<DataEventArgs<ProjectOverview>> NameCellClicked
        {
            add { _report.NameCellClicked +=value; }
            remove { _report.NameCellClicked -= value; }
        }


        public PrintControl ReportPrintControl
        {
            get { return printControl; }
        }

        private readonly ProjectReport _report;
        public ProjectReportView()
        {
            InitializeComponent();

            //BindEnum<ProjectStatus>(stausLookUpEdit, "All", -1);
            //stausLookUpEdit.EditValue = -1;
            CreatePrintBarManager(printControl);
            _report = new ProjectReport();
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
        public ProjectReportPresenter Presenter
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

        //public void Init()
        //{
        //    //BindGridLookUp(ownerGridLookUpEdit);

        //    //BindGridLookUp(technicianGridLookUpEdit);
        //}

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

        #region ??

        /// <summary>
        /// ????
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            EventHandler handler = SearchReport;
            if (handler != null) handler(this, e);
        }

        
        #endregion


        //public List<Guid> TechnicianIds
        //{
        //    get
        //    {
        //        List<Guid> selectedUsers = new List<Guid>();
        //        //var marksSelection = (GridCheckMarksSelection) technicianGridLookUpEdit.Tag;
        //        //if (marksSelection != null)
        //        //{
        //        //    foreach (var user in marksSelection.Selection)
        //        //    {
        //        //        var propertyInfo = user.GetType().GetProperty("UserId");
        //        //        selectedUsers.Add((Guid) propertyInfo.GetValue(user, null));
        //        //    }
        //        //}
        //        return selectedUsers;
        //    }
        //}

        //public List<Guid> OwnerIds
        //{
        //    get
        //    {
        //        List<Guid> selectedUsers = new List<Guid>();
        //        //var marksSelection = (GridCheckMarksSelection)ownerGridLookUpEdit.Tag;
        //        //if (marksSelection != null)
        //        //{
        //        //    foreach (var user in marksSelection.Selection)
        //        //    {
        //        //        var propertyInfo = user.GetType().GetProperty("UserId");
        //        //        selectedUsers.Add((Guid)propertyInfo.GetValue(user, null));
        //        //    }
        //        //}
        //        return selectedUsers;
        //    }
        //}

 
        public int? StatusValue
        {
            get
            {
                //int statusValue = -1;
                //if (stausLookUpEdit.EditValue != null)
                //    int.TryParse(stausLookUpEdit.EditValue.ToString(), out statusValue);
                //if (statusValue != -1) return statusValue;
                return null;
            }
        }

        //public IList UserDataSource { get; set; }
    }
}
