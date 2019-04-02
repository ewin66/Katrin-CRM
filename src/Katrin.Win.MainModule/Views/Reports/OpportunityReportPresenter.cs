using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic;
using System.Data;
using System.Reflection;
using Katrin.Win.Common;
using Katrin.Win.Infrastructure;
using Katrin.Win.MainModule.Properties;
using DevExpress.XtraReports.UI;
using Katrin.Win.Common.MetadataServiceReference;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Utility;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.Constants;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UserDesigner;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Control;
using System.IO;
using DevExpress.XtraPrinting.Native;
using DevExpress.Utils;
using System.Drawing;
using Katrin.Win.Common.Controls;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using Katrin.Win.Common.Controls;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.Data.Filtering;
namespace Katrin.Win.MainModule.Views.Reports
{

    public class OpportunityReportPresenter : Presenter<IOpportunityReportView>
    {
        private IList _users;

        private IDynamicDataServiceContext _dynamicDataServiceContext;

        protected IDynamicDataServiceContext DynamicDataServiceContext
        {
            get { return _dynamicDataServiceContext ?? (_dynamicDataServiceContext = new DynamicDataServiceContext()); }
        }

        private void GetDataRange(int? value, out DateTime startDate, out DateTime endDate)
        {
            startDate = new DateTime(2000, 1, 1);
            endDate = new DateTime(2050, 12, 31);
            if (value != null)
            {
                var range = (DateRange) value.Value;
                switch (range)
                {
                    case DateRange.ThisWeek:
                        startDate = Utils.Date.WeekBegin();
                        endDate = Utils.Date.WeekEnd();
                        break;
                    case DateRange.LastWeek:
                        var lastWeekDay = Utils.Date.WeekBegin().AddDays(-1);
                        startDate = Utils.Date.WeekBegin(lastWeekDay);
                        endDate = Utils.Date.WeekEnd(lastWeekDay);
                        break;
                    case DateRange.ThisMonth:
                        startDate = Utils.Date.MonthBegin();
                        endDate = Utils.Date.MonthEnd();
                        break;
                    case DateRange.LastMonth:
                        var lastMonthDay = Utils.Date.MonthBegin().AddDays(-1);
                        startDate = Utils.Date.MonthBegin(lastMonthDay);
                        endDate = Utils.Date.MonthEnd(lastMonthDay);
                        break;
                    case DateRange.ThisQuarter:
                        startDate = Utils.Date.QuarterBegin();
                        endDate = Utils.Date.QuarterEnd();
                        break;
                    case DateRange.LastQuarter:
                        var quarter = Utils.Date.Quarter();
                        startDate = Utils.Date.QuarterBegin(quarter - 1);
                        endDate = Utils.Date.QuarterEnd(quarter - 1);
                        break;
                    case DateRange.ThisYear:
                        startDate = Utils.Date.YearBegin();
                        endDate = Utils.Date.YearEnd();
                        break;
                    case DateRange.LastYear:
                        startDate = Utils.Date.YearBegin(DateTime.Now.AddYears(-1));
                        endDate = Utils.Date.YearEnd(DateTime.Now.AddYears(-1));
                        break;
                    case DateRange.Custom:
                        if(beginDateBar.EditValue != null)
                            startDate = (DateTime)beginDateBar.EditValue;
                        if(endDateBar.EditValue != null)
                            endDate = (DateTime)endDateBar.EditValue;
                        break;
                }
            }
        }

        protected override void OnViewSet()
        {
            base.OnViewSet();

            View.SearchReport += new EventHandler(View_SearchReport);
            View.NameCellClicked += View_NameCellClicked;
            _users = DynamicDataServiceContext.GetObjects("User");
            
            SetMenu();
        }

        public override void OnViewReady()
        {
            base.OnViewReady();
            var overviewCollection = GetOpportunityOverviewCollection();

            View.Bind(overviewCollection);
        }

        void View_SearchReport(object sender, EventArgs e)
        {
            
        }

        void View_NameCellClicked(object sender, DataEventArgs<OpportunityOverview> e)
        {
            ShowEntityDetails<Opportunity.OpportunityDetailView>(EntityDetailWorkingMode.View, "Opportunity",
                                                                  e.Data.OpportunityId);
        }

        private void ShowEntityDetails<T>(EntityDetailWorkingMode workingMode, string entityName, Guid id) where T:AbstractDetailView
        {
            string key = id + ":DetailWorkItem";

            var detailWorkItem = WorkItem.Items.Get<EnityDetailController<T>>(key);

            if (detailWorkItem == null)
            {
                detailWorkItem = WorkItem.Items.AddNew<EnityDetailController<T>>(key);
                detailWorkItem.EntityName = entityName;
                detailWorkItem.Initialize();
            }
            detailWorkItem.State["EntityId"] = id;
            detailWorkItem.State["WorkingMode"] = workingMode;
            detailWorkItem.Run();
        }

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
            var opportunities = DynamicDataServiceContext.GetBatchObjects("Opportunity", predicate, extraColumns);
            if (opportunities == null) return overviewCollection;
            var notes = GetNotes();

            var timetrackings = DynamicDataServiceContext.GetObjects("TimeTracking");

            DateTime startDate, endDate;
            GetDataRange(DataRangeValue, out startDate, out endDate);
            
            foreach (var opportunity in opportunities)
            {
                var overview = new OpportunityOverview();
                SetPropertyValue(opportunity, "OpportunityId", overview, "OpportunityId");
                SetPropertyValue(opportunity, "Name", overview, "Name");
                SetPropertyValue(opportunity, "CustomerName", overview, "CustomerName");
                var typeCode = (int?) GetPropertyValue(opportunity, "ProjectTypeCode"); //Type
                if (typeCode != null)
                {
                    overview.Type = GetLocalizedPickListValue("Opportunity", "ProjectTypeCode", typeCode.Value);
                }
                var technologyCode = (int?) GetPropertyValue(opportunity, "TechnologyCode"); //Technology
                if (technologyCode != null)
                {
                    overview.Technology = GetLocalizedPickListValue("Opportunity", "TechnologyCode",
                                                                    technologyCode.Value);
                }
                SetPropertyValue(opportunity, "CloseProbability", overview, "Probability");
                SetPropertyValue(opportunity, "LatestFeedbackOn", overview, "LatestFeadbackOn");
                SetPropertyValue(opportunity, "ExpectedStartOn", overview, "ExpectedStartDate");
                SetPropertyValue(opportunity, "EstimatedWorkAmount", overview, "EstimatedWorkAmount");
                SetPropertyValue(opportunity, "ClosedTime", overview, "ClosedDate");
                var statusCode = (int?) GetPropertyValue(opportunity, "StatusCode"); //Status
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
                var opportunityId = (Guid) GetPropertyValue(opportunity, "OpportunityId");

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
                    overview.CostRatio = overview.TechnicianTotalEfforts/overview.EstimatedWorkAmount;
                SetPropertyValue(opportunity, "Description", overview, "Description");

                var noteObjects =
                    notes.AsQueryable().Where("ObjectId = @0", opportunityId).OrderBy("CreatedOn descending").
                        ToArrayList();
                foreach (var noteObject in noteObjects)
                {
                    var note = new Note();

                    var createdById = (Guid?) GetPropertyValue(noteObject, "CreatedById");
                    if (createdById != null)
                    {
                        var creator = _users.AsQueryable().Where("UserId = @0", createdById)._First();
                        if (creator != null)
                            note.CreatedBy = (string)GetPropertyValue(creator, "FullName");
                    }
                    var subject = (string) GetPropertyValue(noteObject, "Subject");
                    var text = (string) GetPropertyValue(noteObject, "NoteText");
                    note.NoteText = string.Format("[{0}] {1}", subject, text);
                    SetPropertyValue(noteObject, "CreatedOn", note, "CreatedOn");
                    overview.Add(note);
                }
                overviewCollection.Add(overview);
            }
            return overviewCollection;
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

            var notes = DynamicDataServiceContext.GetObjects("Note", filter, null);
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
                    new BinaryOperator("ClosedTime",endDate,BinaryOperatorType.LessOrEqual));
                nestedGroup.OperatorType = GroupOperatorType.And;
                GroupOperator group = new GroupOperator(new UnaryOperator(UnaryOperatorType.IsNull, "ClosedTime"), nestedGroup);
                group.OperatorType = GroupOperatorType.Or;

                filter &= group;
            }
            return filter;
        }

        private string GetLocalizedPickListValue(string entityName, string attributeName, int value)
        {
            var entity = MetadataProvider.Instance.EntiyMetadata.First(e => e.PhysicalName == entityName);
            var attribute = entity.Attributes.First(a => a.PhysicalName == attributeName);
            if (attribute.OptionSet == null)
                return null;

            var pickListValue = attribute.OptionSet.AttributePicklistValues.FirstOrDefault(v => v.Value == value);
            if (pickListValue == null)
                return value.ToString(CultureInfo.InvariantCulture);
                //throw new ApplicationException(string.Format("The property {0} of {1} doesn't have the value: {2}", attributeName, entityName, value));
            var culture = System.Globalization.CultureInfo.CurrentCulture;
            var localizedLabels = MetadataProvider.Instance.LocalizedLabels
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
            return Properties.Resources.ResourceManager.GetString(name);
        }
        private void SetMenu()
        {
            RibbonPage generalPage = (RibbonPage)WorkItem.RootWorkItem.UIExtensionSites[ExtensionSiteNames.Ribbon].First();
            RibbonControl ribbon = generalPage.Ribbon;
            RibbonController control = new RibbonController(ribbon, View.ReportPrintControl);
            WorkItem.Items.Add(control.PrintPreviewRibbonPage);
            string groupName = "GeneralPageGroup";
            InitStatus(groupName, generalPage.Groups[0]);
            InitTechnicianPerson(groupName, generalPage.Groups[0]);
            InitSalePerson(groupName, generalPage.Groups[0]);
            InitDateRang(groupName, generalPage.Groups[0]);
            InitDate(groupName, generalPage.Groups[0]);
            InitSearchButton(groupName, generalPage.Groups[0]);
        }


        private void BindEnum<T>(RepositoryItemLookUpEdit lookUpEdit, string emptyText, int? emptyValue)
        {
            var statusTypeNames = Enum.GetNames(typeof(T));
            var statusItems = statusTypeNames
                .Select(name => new LookupListItem<int?>
                {
                    DisplayName = Resources.ResourceManager.GetString(name),
                    Value = (int)Enum.Parse(typeof(T), name)
                }).ToList();
            if (!string.IsNullOrEmpty(emptyText))
            {
                string localizedEmptyText = Resources.ResourceManager.GetString(emptyText);
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
            WorkItem.Items.Add(statusItem);
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
            WorkItem.Items.Add(technicianItem);
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
            ribbonGroup.ItemLinks.Add(saleItem,true);
            WorkItem.Items.Add(saleItem);
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
                    var visibility = DataRangeValue == (int)DateRange.Custom
                                 ? BarItemVisibility.Always
                                 : BarItemVisibility.Never;
                    beginDateBar.Visibility = visibility;
                    endDateBar.Visibility = visibility;
                };
            var statusTypeNames = Enum.GetNames(typeof(DateRange));
            var statusItems = statusTypeNames
                .Select(name => new LookupListItem<int?>
                {
                    DisplayName = Resources.ResourceManager.GetString(name),
                    Value = (int)Enum.Parse(typeof(DateRange), name)
                }).ToList();

            string localizedEmptyText = Resources.ResourceManager.GetString("All");
            statusItems.Insert(0, new LookupListItem<int?> { DisplayName = localizedEmptyText, Value = -1 });
            foreach (var item in statusItems)
            {
                dateRangData.Items.Add(new ImageComboBoxItem(item.DisplayName,item.Value, -1));
            }
            dateRangItem.Edit = dateRangData;
            ribbonGroup.ItemLinks.Add(dateRangItem);
            WorkItem.Items.Add(dateRangItem);
        }

        BarEditItem beginDateBar;
        BarEditItem endDateBar;
        private void InitDate(string groupName, RibbonPageGroup ribbonGroup)
        {
            beginDateBar = new BarEditItem();
            beginDateBar.Visibility = BarItemVisibility.Never;
            beginDateBar.Width = 100;
            beginDateBar.Caption = Properties.Resources.BeginDate;
            beginDateBar.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            RepositoryItemDateEdit begindateValue = new RepositoryItemDateEdit();
            beginDateBar.Edit = begindateValue;
            ribbonGroup.ItemLinks.Add(beginDateBar,true);
            WorkItem.Items.Add(beginDateBar);


            endDateBar = new BarEditItem();
            endDateBar.Visibility = BarItemVisibility.Never;
            endDateBar.Width = 100;
            endDateBar.Caption = Properties.Resources.EndDate;
            endDateBar.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            RepositoryItemDateEdit enddateValue = new RepositoryItemDateEdit();
            endDateBar.Edit = enddateValue;
            ribbonGroup.ItemLinks.Add(endDateBar);
            WorkItem.Items.Add(endDateBar);
        }

        private void InitSearchButton(string groupName, RibbonPageGroup ribbonGroup)
        {
            var buttonItem = new BarButtonItemEx("Search", "Search") { Caption = GetLocalizedCaption("Search") };
            //BarButtonItem buttonItem = new BarButtonItem() { Caption = "??" };
           
            buttonItem.ItemClick += (sender, e) =>
                {
                    var overviewCollection = GetOpportunityOverviewCollection();
                    View.Bind(overviewCollection);
                };
            ribbonGroup.ItemLinks.Add(buttonItem,true);
            WorkItem.Items.Add(buttonItem);
        }
    }
}
