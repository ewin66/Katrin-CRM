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
using DevExpress.XtraRichEdit;
using DevExpress.XtraBars.Ribbon;
using Katrin.Win.Common.Controls;
using Katrin.Win.MainModule.Constants;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.Data.Filtering;

namespace Katrin.Win.MainModule.Views.ProjectReport
{
    public class ProjectReportPresenter : Presenter<IProjectReportView>
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
                var range = (Katrin.Win.MainModule.Views.Reports.DateRange) value.Value;
                switch (range)
                {
                    case Katrin.Win.MainModule.Views.Reports.DateRange.ThisWeek:
                        startDate = Utils.Date.WeekBegin();
                        endDate = Utils.Date.WeekEnd();
                        break;
                    case Katrin.Win.MainModule.Views.Reports.DateRange.LastWeek:
                        var lastWeekDay = Utils.Date.WeekBegin().AddDays(-1);
                        startDate = Utils.Date.WeekBegin(lastWeekDay);
                        endDate = Utils.Date.WeekEnd(lastWeekDay);
                        break;
                    case Katrin.Win.MainModule.Views.Reports.DateRange.ThisMonth:
                        startDate = Utils.Date.MonthBegin();
                        endDate = Utils.Date.MonthEnd();
                        break;
                    case Katrin.Win.MainModule.Views.Reports.DateRange.LastMonth:
                        var lastMonthDay = Utils.Date.MonthBegin().AddDays(-1);
                        startDate = Utils.Date.MonthBegin(lastMonthDay);
                        endDate = Utils.Date.MonthEnd(lastMonthDay);
                        break;
                    case Katrin.Win.MainModule.Views.Reports.DateRange.ThisQuarter:
                        startDate = Utils.Date.QuarterBegin();
                        endDate = Utils.Date.QuarterEnd();
                        break;
                    case Katrin.Win.MainModule.Views.Reports.DateRange.LastQuarter:
                        var quarter = Utils.Date.Quarter();
                        startDate = Utils.Date.QuarterBegin(quarter - 1);
                        endDate = Utils.Date.QuarterEnd(quarter - 1);
                        break;
                    case Katrin.Win.MainModule.Views.Reports.DateRange.ThisYear:
                        startDate = Utils.Date.YearBegin();
                        endDate = Utils.Date.YearEnd();
                        break;
                    case Katrin.Win.MainModule.Views.Reports.DateRange.LastYear:
                        startDate = Utils.Date.YearBegin(DateTime.Now.AddYears(-1));
                        endDate = Utils.Date.YearEnd(DateTime.Now.AddYears(-1));
                        break;
                    case Katrin.Win.MainModule.Views.Reports.DateRange.Custom:
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
            //View.UserDataSource = _users;

            //View.Init();
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
            var overviewCollection = GetOpportunityOverviewCollection();

            View.Bind(overviewCollection);
        }

        void View_NameCellClicked(object sender, DataEventArgs<ProjectOverview> e)
        {
            ShowEntityDetails<Opportunity.OpportunityDetailView>(EntityDetailWorkingMode.View, "Project",
                                                                  e.Data.ProjectId);
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

        protected string GetLocalizedCaption(string name)
        {
            return Properties.Resources.ResourceManager.GetString(name);
        }

        private ProjectOverviewCollection GetOpportunityOverviewCollection()
        {
            var extraColumns = new Dictionary<string, string>
                                   {
                                       {"CustomerName", "Customer == null?null:Customer.Name"},
                                       {"ProjectWeekReports", "ProjectWeekReports"},
                                       {"ProjectTasks", "ProjectTasks"}
                                   };
            var predicate = GetPredicate();

            var projects = DynamicDataServiceContext.GetBatchObjects("Project", predicate, extraColumns);

            DateTime startDate, endDate;
            GetDataRange(DataRangeValue, out startDate, out endDate);
            var overviewCollection = new ProjectOverviewCollection();
            if (projects == null) return overviewCollection;
            foreach (var project in projects)
            {
                var overview = new ProjectOverview();
                var dyanmicProject = project.AsDyanmic();
                overview.ProjectId = dyanmicProject.ProjectId;
                overview.Name = dyanmicProject.Name;
                overview.CustomerName = dyanmicProject.CustomerName;

                //
                string projectTypeCode = GetLocalizedPickListValue("Project", "ProjectTypeCode", dyanmicProject.ProjectTypeCode);
                overview.Type = GetLocalizedCaption("ProjectTypeCode") + (string.IsNullOrEmpty(projectTypeCode) ? "(TBD)" : projectTypeCode);

                //
                string technologyCode = GetLocalizedPickListValue("Project", "TechnologyCode", dyanmicProject.TechnologyCode);
                overview.Technology = GetLocalizedCaption("TechnologyCode") + (string.IsNullOrEmpty(technologyCode) ? "(TBD)" : technologyCode);

                //
                string probabilityCode = GetLocalizedPickListValue("Project", "ProbabilityCode", dyanmicProject.ProbabilityCode);
                overview.Probability = GetLocalizedCaption("ProbabilityCode") + (string.IsNullOrEmpty(probabilityCode) ? "(TBD)" : probabilityCode);
                IList projectTasks = dyanmicProject.ProjectTasks;
                projectTasks = projectTasks.AsQueryable().Where("IsDeleted = false").ToArrayList();
                IList Owners = projectTasks.AsQueryable().Where("OwnerId != null").Select("OwnerId").Cast<Guid>().ToList();
                List<object> taskHistory = GetTaskHistory(startDate, endDate, projectTasks.AsQueryable().Select("TaskId").Cast<object>().ToList()) as List<object>;
                string owners = GetResponsibilityPerson(Owners);
                overview.ResponsibilityPerson = GetLocalizedCaption("ProjectMember") + (string.IsNullOrEmpty(owners) ? "(TBD)" : owners);
                overview.ProjectSummaryInfo = overview.Type + " " + overview.Technology + " " + overview.Probability + " " + overview.ResponsibilityPerson;
                overview.LatestFeadbackOn = dyanmicProject.LatestFeadbackOn;
                overview.EstimatedEndDate = dyanmicProject.EstimatedEndDate;

                //total
                overview.TotalQuoteWorkHours = projectTasks.AsQueryable().Select("QuoteWorkHours").Cast<double?>().Sum();
                overview.TotalActualWorkHours = projectTasks.AsQueryable().Select("ActualWorkHours").Cast<double?>().Sum();
                overview.TotalActualInput = projectTasks.AsQueryable().Select("ActualInput").Cast<double?>().Sum();
                overview.TotalEffort = projectTasks.AsQueryable().Select("Effort").Cast<double?>().Sum();
                overview.TotalRemainderTime = overview.TotalActualWorkHours - overview.TotalEffort;
                overview.TotalEvaluateExactlyRate = overview.TotalActualWorkHours == 0 ? 0 : overview.TotalQuoteWorkHours / overview.TotalActualWorkHours;
                overview.TotalInputEffortRate = overview.TotalActualInput == 0 ? 0 : overview.TotalEffort / overview.TotalActualInput;

                //week
                overview.WeekQuoteWorkHours = projectTasks.AsQueryable().Where("StartDate<=@1 && (EndDate==null || EndDate>=@0)", startDate, endDate)
                    .Select("QuoteWorkHours").Cast<double?>().Sum();
                overview.WeekActualWorkHours = projectTasks.AsQueryable().Where("StartDate<=@1 && (EndDate == null || EndDate>=@0)", startDate, endDate)
                    .Select("ActualWorkHours").Cast<double?>().Sum();
                overview.WeekActualInput = taskHistory==null?0:taskHistory.Select(c=>c.AsDyanmic().ActualInput).Cast<double?>().Sum();
                overview.WeekEffort = taskHistory==null?0:taskHistory.Select(c=>c.AsDyanmic().Effort).Cast<double?>().Sum();
                overview.WeekRemainderTime = overview.WeekActualWorkHours - overview.WeekEffort;
                
                //rate
                overview.EvaluateExactlyRate = overview.WeekActualWorkHours==0?0:overview.WeekQuoteWorkHours / overview.WeekActualWorkHours;
                overview.InputEffortRate =overview.WeekActualInput==0?0: overview.WeekEffort / overview.WeekActualInput;

                overview.ActualStartDate = dyanmicProject.ActualStartDate;

                // ProjectStatus and  Quality from ProjectWeekReport
                IList projectWeekReports = dyanmicProject.ProjectWeekReports;
                projectWeekReports = projectWeekReports.AsQueryable().Where("RecordOn>=@0 && RecordOn<=@1", startDate, endDate).ToArrayList();
                string projectStatus = "";
                string quality = "";
                foreach (var weekReport in projectWeekReports)
                {
                    projectStatus += GetHtmlText(weekReport.AsDyanmic().CriteriaProgress);
                    quality += GetHtmlText(weekReport.AsDyanmic().CriteriaQuality);
                }
                overview.ProjectStatus = projectStatus;
                overview.Quality = quality;
                overview.Objective = dyanmicProject.Objective;
                overviewCollection.Add(overview);
            }
            return overviewCollection;
        }

        RichEditControl rich;
        private string GetHtmlText(string htmlString)
        {
            if(rich == null)
            rich = new RichEditControl();
            rich.HtmlText = htmlString;
            return rich.Text;
        }


        private IEnumerable GetTaskHistory(DateTime startDate, DateTime endDate, List<object> taskListId)
        {
            if (taskListId.Count <= 0) return null;
            CriteriaOperator filter = new BinaryOperator("RecordOn", startDate, BinaryOperatorType.GreaterOrEqual);
            filter &= new BinaryOperator("RecordOn", endDate, BinaryOperatorType.LessOrEqual);
            if (taskListId.Count > 0) filter &= new InOperator("TaskId", taskListId);

            return DynamicDataServiceContext.GetBatchObjects("TaskTimeHistory", filter, null);
        }

        private string GetResponsibilityPerson(IList Owners)
        {
            List<string> result = new List<string>();
            string fullName = string.Empty;
            foreach (var item in Owners)
            {
                fullName = _users.AsQueryable().Where("userid=@0", item).Select("FullName")._First().ToString();
                if (!result.Contains(fullName))
                {
                    result.Add(fullName);
                }
            }
            if (result.Count <= 0) return "";
            return result.Cast<string>().Aggregate((s,t)=>s+"," + t);
        }

        

        private CriteriaOperator GetPredicate()
        {
            CriteriaOperator filter = null;
            if(ProjectIds.Count>0)
                filter &= new InOperator("ProjectId", ProjectIds);

            if (ManagerIds.Count > 0)
                filter &= new InOperator("ManagerId", ManagerIds);

            if (statusItem.EditValue != null && statusItem.EditValue.ToString() != "-1")
            {
                filter &= new BinaryOperator("StatusCode", statusItem.EditValue);
            }

            if (DataRangeValue != null)
            {
                DateTime startDate, endDate;
                GetDataRange(DataRangeValue, out startDate, out endDate);
                filter &= new BinaryOperator("ActualStartDate", endDate, BinaryOperatorType.LessOrEqual);


                GroupOperator nestedGroup = new GroupOperator(new OperandProperty("ActualEndDate").IsNotNull(), 
                    new BinaryOperator("ActualEndDate", startDate, BinaryOperatorType.GreaterOrEqual));
                nestedGroup.OperatorType = GroupOperatorType.And;
                CriteriaOperator endDateOperator = nestedGroup;

                GroupOperator group = new GroupOperator(GroupOperatorType.Or, endDateOperator, new UnaryOperator(UnaryOperatorType.IsNull, "ActualEndDate"));
                endDateOperator |= new UnaryOperator(UnaryOperatorType.IsNull, "ActualEndDate");

                filter &= endDateOperator;
            }
            return filter;
        }

        private string GetLocalizedPickListValue(string entityName, string attributeName, object objectValue)
        {
            if (objectValue == null) return string.Empty;
            int value = int.Parse(objectValue.ToString());
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

        private void SetMenu()
        {
            RibbonPage generalPage = (RibbonPage)WorkItem.RootWorkItem.UIExtensionSites[ExtensionSiteNames.Ribbon].First();
            RibbonControl ribbon = generalPage.Ribbon;
            RibbonController control = new RibbonController(ribbon, View.ReportPrintControl);
            WorkItem.Items.Add(control.PrintPreviewRibbonPage);
            string groupName = "GeneralPageGroup";
            InitStatus(groupName, generalPage.Groups[0]);
            InitDateRang(groupName, generalPage.Groups[0]);
            InitProject(groupName, generalPage.Groups[0]);
            InitManagerPerson(groupName, generalPage.Groups[0]);
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
            BindEnum<ProjectStatus>(statusData, "All", -1);
            statusItem.Edit = statusData;
            ribbonGroup.ItemLinks.Add(statusItem);
            WorkItem.Items.Add(statusItem);
        }


        private List<Guid> ProjectIds
        {
            get { return projectData.GetSelection(); }
        }

        RepositoryItemPopupContainerEdit projectData;
        private void InitProject(string groupName, RibbonPageGroup ribbonGroup)
        {
            BarEditItem projectItem = new BarEditItem();
            projectItem.Width = 100;
            projectItem.Caption = GetLocalizedCaption("ProjectName");
            projectItem.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            projectData = new RepositoryItemPopupContainerEdit();
            projectData.InitEdit("Project", "", true);
            projectItem.Edit = projectData;
            ribbonGroup.ItemLinks.Add(projectItem, true);
            WorkItem.Items.Add(projectItem);
        }

        private List<Guid> ManagerIds
        {
            get { return managerData.GetSelection(); }
        }

        RepositoryItemPopupContainerEdit managerData;
        private void InitManagerPerson(string groupName, RibbonPageGroup ribbonGroup)
        {
            BarEditItem managerItem = new BarEditItem();
            managerItem.Width = 100;
            managerItem.Caption = GetLocalizedCaption("ProjectManager");
            managerItem.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            managerData = new RepositoryItemPopupContainerEdit();
            managerData.InitEdit("User", "Department", true);
            managerItem.Edit = managerData;
            ribbonGroup.ItemLinks.Add(managerItem);
            WorkItem.Items.Add(managerItem);
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
                var visibility = DataRangeValue == (int)ProjectDateRange.Custom
                             ? BarItemVisibility.Always
                             : BarItemVisibility.Never;
                beginDateBar.Visibility = visibility;
                endDateBar.Visibility = visibility;
            };
            var statusTypeNames = Enum.GetNames(typeof(ProjectDateRange));
            var statusItems = statusTypeNames
                .Select(name => new LookupListItem<int?>
                {
                    DisplayName = Resources.ResourceManager.GetString(name),
                    Value = (int)Enum.Parse(typeof(ProjectDateRange), name)
                }).ToList();

            string localizedEmptyText = Resources.ResourceManager.GetString("All");
            statusItems.Insert(0, new LookupListItem<int?> { DisplayName = localizedEmptyText, Value = -1 });
            foreach (var item in statusItems)
            {
                dateRangData.Items.Add(new ImageComboBoxItem(item.DisplayName, item.Value, -1));
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
            ribbonGroup.ItemLinks.Add(beginDateBar, true);
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
            var buttonItem = new BarButtonItemEx("Search", null) { Caption = GetLocalizedCaption("Search") };

            buttonItem.ItemClick += (sender, e) =>
            {
                var overviewCollection = GetOpportunityOverviewCollection();
                View.Bind(overviewCollection);
            };
            ribbonGroup.ItemLinks.Add(buttonItem, true);
            WorkItem.Items.Add(buttonItem);
        }
        
    }
}
