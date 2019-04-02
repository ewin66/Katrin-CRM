using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.Metadata;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms.Controls;
using Katrin.AppFramework.WinForms.MVC;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using ICSharpCode.Core;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.WinForms.Workspaces;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework;
using Katrin.AppFramework.WinForms;
using System.Drawing;
using System.ComponentModel;
namespace Katrin.Win.OpportunityReportModule.Report
{
    public class OpportunityReportController : ObjectController
    {
        private IOpportunityReportView _opportunityReportView;
        private IList _users;
        private RibbonControl _ribbon;
        public override IActionResult Execute(ActionParameters parameters)
        {
            _ribbon = parameters.Get<RibbonControl>("ribbonControl");
            _opportunityReportView = ViewFactory.CreateView("DefaultOpportunityReportView") as IOpportunityReportView;

            OnViewSet();
            var result = new PartialViewResult();
            result.View = _opportunityReportView;
            return result;
        }

        protected void OnViewSet()
        {
            _opportunityReportView.SearchReport += new EventHandler(View_SearchReport);
            _opportunityReportView.NameCellClicked += View_NameCellClicked;
            _opportunityReportView.OnViewReady += _opportunityReportView_OnViewReady;
            _users = _objectSpace.GetObjects("User");

            SetMenu();
        }

        void _opportunityReportView_OnViewReady(object sender, EventArgs e)
        {
            OnViewReady();
        }

        public void OnViewReady()
        {
            //base.OnViewReady();
            var worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += (s, ex) =>
                {
                    ex.Result = GetOpportunityOverviewCollection();
                };
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!(e.Result is IEnumerable)) return;
            _opportunityReportView.Bind((IEnumerable)e.Result);
        }

        void View_SearchReport(object sender, EventArgs e)
        {

        }

        void View_NameCellClicked(object sender, EventArgs<OpportunityOverview> e)
        {
            //ShowEntityDetails<Opportunity.OpportunityDetailView>(EntityDetailWorkingMode.View, "Opportunity",
            //                                                      e.Data.OpportunityId);
        }

        //private void ShowEntityDetails<T>(EntityDetailWorkingMode workingMode, string entityName, Guid id) where T : AbstractDetailView
        //{
        //    string key = id + ":DetailWorkItem";

        //    var detailWorkItem = WorkItem.Items.Get<EnityDetailController<T>>(key);

        //    if (detailWorkItem == null)
        //    {
        //        detailWorkItem = WorkItem.Items.AddNew<EnityDetailController<T>>(key);
        //        detailWorkItem.EntityName = entityName;
        //        detailWorkItem.Initialize();
        //    }
        //    detailWorkItem.State["EntityId"] = id;
        //    detailWorkItem.State["WorkingMode"] = workingMode;
        //    detailWorkItem.Run();
        //}

        private OpportunityOverviewCollection GetOpportunityOverviewCollection()
        {

            var overviewCollection = new OpportunityOverviewCollection();

            var extraColumns = new Dictionary<string, string>
                                   {
                                       {"OwnerName", "Owner == null?null:Owner.FullName"},
                                       {"TechnicianName", "Technician == null?null:Technician.FullName"},
                                       {"Contracts", "Contracts"},
                                       {"OriginatingLeadName", "OriginatingLead == null?null:OriginatingLead.Subject"},
                                       {"CustomerName", "Customer == null?null:Customer.Name"}
                                   };
            var predicate = GetPredicate();
            var opportunities = _objectSpace.GetBatchObjects("Opportunity", predicate, extraColumns);
            if (opportunities == null) return overviewCollection;
            var notes = GetNotes();

            var timetrackings = _objectSpace.GetObjects("TimeTracking");

            DateTime startDate, endDate;
            GetDataRange(DataRangeValue, out startDate, out endDate);

            foreach (var opportunity in opportunities)
            {
                var overview = new OpportunityOverview();
                SetPropertyValue(opportunity, "OpportunityId", overview, "OpportunityId");
                SetPropertyValue(opportunity, "Name", overview, "Name");
                SetPropertyValue(opportunity, "CustomerName", overview, "CustomerName");
                var typeCode = (int?)GetPropertyValue(opportunity, "ProjectTypeCode"); //Type
                if (typeCode != null)
                {
                    overview.Type = GetLocalizedPickListValue("Opportunity", "ProjectTypeCode", typeCode.Value);
                }
                string technologyStr = string.Empty;
                var technology = GetPropertyValue(opportunity, "Technology"); //Technology
                if (technology != null)
                    technologyStr = technology.ToString();
                if (!string.IsNullOrEmpty(technologyStr))
                {
                    overview.Technology = technologyStr;
                }
                SetPropertyValue(opportunity, "CloseProbability", overview, "Probability");
                SetPropertyValue(opportunity, "LatestFeedbackOn", overview, "LatestFeadbackOn");
                SetPropertyValue(opportunity, "ExpectedStartOn", overview, "ExpectedStartDate");
                SetPropertyValue(opportunity, "EstimatedWorkAmount", overview, "EstimatedWorkAmount");
                SetPropertyValue(opportunity, "ClosedTime", overview, "ClosedDate");
                var statusCode = (int?)GetPropertyValue(opportunity, "StatusCode"); //Status
                if (statusCode != null)
                {
                    overview.Status = GetLocalizedPickListValue("Opportunity", "StatusCode", statusCode.Value);
                }
                SetPropertyValue(opportunity, "ClosedTime", overview, "ClosedDate");
                var contracts = GetPropertyValue(opportunity, "Contracts") as IList; //ContractTotal
                if (contracts != null)
                {
                    var contractTotal = contracts.AsQueryable().Select("TotalPrice").Cast<decimal?>().Sum();
                    overview.ContractTotal = contractTotal;
                }
                SetPropertyValue(opportunity, "OwnerName", overview, "SaleName");
                var opportunityId = (Guid)GetPropertyValue(opportunity, "OpportunityId");

                var timeTrackingRecords = timetrackings.AsQueryable().Where("OpportunityId = @0", opportunityId);
                overview.SaleTotalEfforts =
                    timeTrackingRecords.Where("TypeCode= 1").Select("Effort").Cast<double?>().Sum();
                overview.SaleCurrentEfforts =
                    timeTrackingRecords.Where("TypeCode= 1  && RecordOn >= @0 && RecordOn <= @1", startDate, endDate)
                    .Select("Effort").Cast<double?>().Sum();
                SetPropertyValue(opportunity, "TechnicianName", overview, "TechnicianName");
                overview.TechnicianTotalEfforts =
                    timeTrackingRecords.Where("TypeCode= 2 || TypeCode= 3").Select("Effort").Cast<double?>().Sum();
                overview.TechnicianCurrentEfforts =
                    timeTrackingRecords.Where("(TypeCode= 2 || TypeCode= 3) && RecordOn >= @0 && RecordOn <= @1", startDate, endDate).
                        Select("Effort").Cast<double?>().Sum();
                if (overview.EstimatedWorkAmount > 0)
                    overview.CostRatio = overview.TechnicianTotalEfforts / overview.EstimatedWorkAmount;
                SetPropertyValue(opportunity, "Description", overview, "Description");

                var noteObjects =
                    notes.AsQueryable().Where("ObjectId = @0", opportunityId).OrderBy("CreatedOn descending").
                        ToArrayList();
                foreach (var noteObject in noteObjects)
                {
                    var note = new Note();

                    var createdById = (Guid?)GetPropertyValue(noteObject, "CreatedById");
                    if (createdById != null)
                    {
                        var creator = _users.AsQueryable().Where("UserId = @0", createdById)._First();
                        if (creator != null)
                            note.CreatedBy = (string)GetPropertyValue(creator, "FullName");
                    }
                    var subject = (string)GetPropertyValue(noteObject, "Subject");
                    var text = (string)GetPropertyValue(noteObject, "NoteText");
                    note.NoteText = string.Format("[{0}] {1}", subject, text);
                    SetPropertyValue(noteObject, "CreatedOn", note, "CreatedOn");
                    overview.Add(note);
                }
                overviewCollection.Add(overview);
            }
            return overviewCollection;
        }



        private void GetDataRange(int? value, out DateTime startDate, out DateTime endDate)
        {
            startDate = new DateTime(2000, 1, 1);
            endDate = new DateTime(2050, 12, 31);
            if (value == null) return;
            if (Katrin.AppFramework.Utils.DateRang.DateRange.Custom == (Katrin.AppFramework.Utils.DateRang.DateRange)value.Value)
            {

                if (beginDateBar.EditValue != null)
                    startDate = (DateTime)beginDateBar.EditValue;
                if (endDateBar.EditValue != null)
                    endDate = (DateTime)endDateBar.EditValue;
            }
            else
            {
                DateRang.GetDataRange(value, out startDate, out endDate);
            }
        }

        private IEnumerable GetNotes()
        {
            CriteriaOperator filter = null;
            if (DataRangeValue != null)
            {
                DateTime startDate, endDate;
                GetDataRange(DataRangeValue, out startDate, out endDate);
                filter = new BinaryOperator("CreatedOn", startDate, BinaryOperatorType.GreaterOrEqual)
                        & new BinaryOperator("CreatedOn", endDate, BinaryOperatorType.LessOrEqual);
            }

            var notes = _objectSpace.GetObjects("Note", filter, null);
            return notes;
        }

        private CriteriaOperator GetPredicate()
        {
            CriteriaOperator filter = null;
            if (TechnicianIds.Count > 0)
                filter &= new InOperator("TechnicianId", TechnicianIds);

            if (OwnerIds.Count > 0)
                filter &= new InOperator("OwnerId", OwnerIds);

            if (statusItem.EditValue != null && statusItem.EditValue.ToString() != "-1")
            {
                filter &= new BinaryOperator("StatusCode", statusItem.EditValue);
            }

            if (DataRangeValue != null)
            {
                DateTime startDate, endDate;
                GetDataRange(DataRangeValue, out startDate, out endDate);
                filter &= new BinaryOperator("CreatedOn", endDate, BinaryOperatorType.LessOrEqual);
                GroupOperator nestedGroup = new GroupOperator(new OperandProperty("ClosedTime").IsNotNull(),
                    new BinaryOperator("ClosedTime", startDate, BinaryOperatorType.GreaterOrEqual),
                    new BinaryOperator("ClosedTime", endDate, BinaryOperatorType.LessOrEqual));
                nestedGroup.OperatorType = GroupOperatorType.And;
                GroupOperator group = new GroupOperator(new UnaryOperator(UnaryOperatorType.IsNull, "ClosedTime"), nestedGroup);
                group.OperatorType = GroupOperatorType.Or;

                filter &= group;
            }
            return filter;
        }

        private string GetLocalizedPickListValue(string entityName, string attributeName, int value)
        {
            var entity = MetadataRepository.Entities.First(e => e.PhysicalName == entityName);
            var attribute = entity.Attributes.First(a => a.PhysicalName == attributeName);
            if (attribute.OptionSet == null)
                return null;

            var pickListValue = attribute.OptionSet.AttributePicklistValues.FirstOrDefault(v => v.Value == value);
            if (pickListValue == null)
                return value.ToString(CultureInfo.InvariantCulture);
            //throw new ApplicationException(string.Format("The property {0} of {1} doesn't have the value: {2}", attributeName, entityName, value));
            var culture = System.Globalization.CultureInfo.CurrentCulture;
            var localizedLabels = MetadataRepository.LocalizedLabels
                .Where(l => l.ObjectId == pickListValue.AttributePicklistValueId);

            var localizedLabel = localizedLabels.FirstOrDefault(l => l.LanguageId == culture.LCID) ??
                                 localizedLabels.First();
            return localizedLabel.Label;
        }

        private void SetPropertyValue(object source, string sourceProperty, object target, string targetProperty)
        {
            var sourcePropertyInfo = source.GetType().GetProperty(sourceProperty);
            var targetPropertyInfo = target.GetType().GetProperty(targetProperty);
            targetPropertyInfo.SetValue(target, sourcePropertyInfo.GetValue(source, null), null);
        }

        private object GetPropertyValue(object source, string sourceProperty)
        {
            var sourcePropertyInfo = source.GetType().GetProperty(sourceProperty);
            return sourcePropertyInfo.GetValue(source, null);
        }

        protected string GetLocalizedCaption(string name)
        {
            return StringParser.Parse("${res:" + name + "}");
        }
        private void SetMenu()
        {
            //RibbonPage generalPage = (RibbonPage)WorkItem.RootWorkItem.UIExtensionSites[ExtensionSiteNames.Ribbon].First();
            RibbonControl ribbon = this._ribbon;
            RibbonController control = new RibbonController(ribbon, _opportunityReportView.ReportPrintControl);
            ribbon.AutoSizeItems = true;
            string groupName = "GeneralPageGroup";
            InitStatus(groupName, ribbon.Pages[0].Groups[0]);
            InitTechnicianPerson(groupName, ribbon.Pages[0].Groups[0]);
            InitSalePerson(groupName, ribbon.Pages[0].Groups[0]);
            InitDateRang(groupName, ribbon.Pages[0].Groups[0]);
            InitDate(groupName, ribbon.Pages[0].Groups[0]);
            InitSearchButton(groupName, ribbon.Pages[0].Groups[0]);
        }


        private void BindEnum<T>(RepositoryItemLookUpEdit lookUpEdit, string emptyText, int? emptyValue)
        {
            var statusTypeNames = Enum.GetNames(typeof(T));
            var statusItems = statusTypeNames
                .Select(name => new LookupListItem<int?>
                {
                    DisplayName = GetLocalizedCaption(name),
                    Value = (int)Enum.Parse(typeof(T), name)
                }).ToList();
            if (!string.IsNullOrEmpty(emptyText))
            {
                string localizedEmptyText = GetLocalizedCaption(emptyText);
                statusItems.Insert(0, new LookupListItem<int?> { DisplayName = localizedEmptyText, Value = emptyValue });
            }
            lookUpEdit.Properties.InitializeLookUpEdit(statusItems);
        }

        BarEditItem statusItem;
        private void InitStatus(string groupName, RibbonPageGroup ribbonGroup)
        {
            statusItem = new BarEditItem();
            statusItem.Width = 100;
            statusItem.Caption = GetLocalizedCaption("Status");
            statusItem.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            RepositoryItemLookUpEdit statusData = new RepositoryItemLookUpEdit();
            BindEnum<OpportunityStatus>(statusData, "All", -1);
            statusItem.Edit = statusData;
            ribbonGroup.ItemLinks.Add(statusItem);

        }

        private List<Guid> TechnicianIds
        {
            get { return technicianData.GetSelection(); }
        }
        RepositoryItemPopupContainerEdit technicianData;
        private void InitTechnicianPerson(string groupName, RibbonPageGroup ribbonGroup)
        {
            BarEditItem technicianItem = new BarEditItem();
            technicianItem.Width = 100;
            technicianItem.Caption = GetLocalizedCaption("TechnologyPerson");
            technicianItem.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            technicianData = new RepositoryItemPopupContainerEdit();
            technicianData.InitEdit("User", "Department", true);
            technicianItem.Edit = technicianData;
            ribbonGroup.ItemLinks.Add(technicianItem);

        }

        private List<Guid> OwnerIds
        {
            get { return saleData.GetSelection(); }
        }
        RepositoryItemPopupContainerEdit saleData;
        private void InitSalePerson(string groupName, RibbonPageGroup ribbonGroup)
        {
            BarEditItem saleItem = new BarEditItem();
            saleItem.Width = 100;
            saleItem.Caption = GetLocalizedCaption("OwnerPerson");
            saleItem.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            saleData = new RepositoryItemPopupContainerEdit();
            saleData.InitEdit("User", "Department", true);
            saleItem.Edit = saleData;
            ribbonGroup.ItemLinks.Add(saleItem, true);

        }

        public int? DataRangeValue
        {
            get
            {
                int dataRangeValue = -1;
                if (dateRangItem.EditValue != null)
                    int.TryParse(dateRangItem.EditValue.ToString(), out dataRangeValue);
                if (dataRangeValue != -1) return dataRangeValue;
                return null;
            }
        }

        BarEditItem dateRangItem;
        private void InitDateRang(string groupName, RibbonPageGroup ribbonGroup)
        {
            dateRangItem = new BarEditItem();
            dateRangItem.Width = 100;
            dateRangItem.Caption = GetLocalizedCaption("DateRang");
            dateRangItem.EditValue = 1;
            dateRangItem.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            RepositoryItemImageComboBox dateRangData = new RepositoryItemImageComboBox();
            dateRangItem.EditValueChanged += (sender, e) =>
            {
                var visibility = DataRangeValue == (int)Katrin.AppFramework.Utils.DateRang.DateRange.Custom
                             ? BarItemVisibility.Always
                             : BarItemVisibility.Never;
                beginDateBar.Visibility = visibility;
                endDateBar.Visibility = visibility;
            };
            var statusTypeNames = Enum.GetNames(typeof(Katrin.AppFramework.Utils.DateRang.DateRange));
            var statusItems = statusTypeNames
                .Select(name => new LookupListItem<int?>
                {
                    DisplayName = GetLocalizedCaption(name),
                    Value = (int)Enum.Parse(typeof(Katrin.AppFramework.Utils.DateRang.DateRange), name)
                }).ToList();

            string localizedEmptyText = GetLocalizedCaption("All");
            statusItems.Insert(0, new LookupListItem<int?> { DisplayName = localizedEmptyText, Value = -1 });
            foreach (var item in statusItems)
            {
                dateRangData.Items.Add(new ImageComboBoxItem(item.DisplayName, item.Value, -1));
            }
            dateRangItem.Edit = dateRangData;
            ribbonGroup.ItemLinks.Add(dateRangItem);

        }

        BarEditItem beginDateBar;
        BarEditItem endDateBar;
        private void InitDate(string groupName, RibbonPageGroup ribbonGroup)
        {
            beginDateBar = new BarEditItem();
            beginDateBar.Visibility = BarItemVisibility.Never;
            beginDateBar.Width = 100;
            beginDateBar.Caption = GetLocalizedCaption("BeginDate");
            beginDateBar.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            RepositoryItemDateEdit begindateValue = new RepositoryItemDateEdit();
            beginDateBar.Edit = begindateValue;
            ribbonGroup.ItemLinks.Add(beginDateBar, true);



            endDateBar = new BarEditItem();
            endDateBar.Visibility = BarItemVisibility.Never;
            endDateBar.Width = 100;
            endDateBar.Caption = GetLocalizedCaption("EndDate");
            endDateBar.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            RepositoryItemDateEdit enddateValue = new RepositoryItemDateEdit();
            endDateBar.Edit = enddateValue;
            ribbonGroup.ItemLinks.Add(endDateBar);

        }

        private void InitSearchButton(string groupName, RibbonPageGroup ribbonGroup)
        {
            var buttonItem = new BarButtonItem() { Caption = GetLocalizedCaption("Search") };

            var icon = WinFormsResourceService.GetIcon("search");
            Image largeImage = icon.ToBitmap();
            buttonItem.LargeGlyph = largeImage;
            buttonItem.Glyph = new Bitmap(largeImage, new Size(16, 16));


            buttonItem.ItemClick += (sender, e) =>
            {
                var worker = new BackgroundWorker();
                worker.WorkerSupportsCancellation = true;
                worker.DoWork += (s, ex) =>
                {
                    ex.Result = GetOpportunityOverviewCollection();
                };
                worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
                worker.RunWorkerAsync();
            };
            ribbonGroup.ItemLinks.Add(buttonItem, true);

        }

        #region no user

        public override object SelectedObject
        {
            get { throw new NotImplementedException(); }
        }
        #endregion
    }
}
