using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework.WinForms.Workspaces;
using ICSharpCode.Core;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework;
using Katrin.AppFramework.Data;
using DevExpress.XtraRichEdit;
using DevExpress.Data.Filtering;
using Katrin.AppFramework.Metadata;
using System.Globalization;
using DevExpress.XtraBars.Ribbon;
using Katrin.AppFramework.WinForms.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using System.Drawing;
using Katrin.AppFramework.WinForms;
using System.ComponentModel;
namespace Katrin.Win.ProjectReportModule.Report
{
    public class ProjectReportController : ObjectController
    {
        private IList _users;
        private RibbonControl _ribbon;
        private IProjectReportView _projectReportView;
        public override IActionResult Execute(ActionParameters parameters)
        {
            _ribbon = parameters.Get<RibbonControl>("ribbonControl");
            _projectReportView = ViewFactory.CreateView("DefaultProjectReportView") as IProjectReportView;
            OnViewSet();
            var result = new PartialViewResult();
            result.View = _projectReportView;
            return result;
        }

        protected  void OnViewSet()
        {
            _projectReportView.SearchReport += new EventHandler(View_SearchReport);
            _projectReportView.NameCellClicked += View_NameCellClicked;
            _projectReportView.OnViewReady += _projectReportView_OnViewReady;
            _users = _objectSpace.GetObjects("User");
            SetMenu();
        }

        void _projectReportView_OnViewReady(object sender, EventArgs e)
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
            _projectReportView.Bind((IEnumerable)e.Result);
        }

        void View_SearchReport(object sender, EventArgs e)
        {
            var overviewCollection = GetOpportunityOverviewCollection();

            _projectReportView.Bind(overviewCollection);
        }

        void View_NameCellClicked(object sender, EventArgs<ProjectOverview> e)
        {
            //ShowEntityDetails<Opportunity.OpportunityDetailView>(EntityDetailWorkingMode.View, "Project",
            //                                                      e.Data.ProjectId);
        }

        
        protected string GetLocalizedCaption(string name)
        {
            return StringParser.Parse("${res:"+name+"}");
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

        private ProjectOverviewCollection GetOpportunityOverviewCollection()
        {
            var extraColumns = new Dictionary<string, string>
                                   {
                                       {"Customer", "Customer"},
                                       {"ProjectWeekReports", "ProjectWeekReports"},
                                       {"ProjectTasks", "ProjectTasks"}
                                   };
            var predicate = GetPredicate();

            var projects = _objectSpace.GetBatchObjects("Project", predicate, extraColumns);

            DateTime startDate, endDate;
            GetDataRange(DataRangeValue, out startDate, out endDate);
            var overviewCollection = new ProjectOverviewCollection();
            if (projects == null) return overviewCollection;
            foreach (var projectObj in projects)
            {
                var overview = new ProjectOverview();
                var project = ConvertData.Convert<Katrin.Domain.Impl.Project>(projectObj);
                overview.ProjectId = project.ProjectId;
                overview.Name = project.Name;
                overview.CustomerName = project.Customer == null?string.Empty:project.Customer.Name;

                //
                string projectTypeCode = GetLocalizedPickListValue("Project", "ProjectTypeCode", project.ProjectTypeCode);
                overview.Type = GetLocalizedCaption("ProjectTypeCode") + (string.IsNullOrEmpty(projectTypeCode) ? "(TBD)" : projectTypeCode);

                //
                string technologyStr = string.Empty;
                var technology = GetPropertyValue(project, "Technology"); //Technology
                if (technology != null)
                    technologyStr = technology.ToString();
                
                overview.Technology = GetLocalizedCaption("TechnologyCode") + (string.IsNullOrEmpty(technologyStr) ? "(TBD)" : technologyStr);

                //
                string probabilityCode = GetLocalizedPickListValue("Project", "ProbabilityCode", project.ProbabilityCode);
                overview.Probability = GetLocalizedCaption("ProbabilityCode") + (string.IsNullOrEmpty(probabilityCode) ? "(TBD)" : probabilityCode);
                IList projectTasks = project.ProjectTasks.ToList();
                projectTasks = projectTasks.AsQueryable().Where("IsDeleted = false").ToArrayList();
                IList Owners = projectTasks.AsQueryable().Where("OwnerId != null").Select("OwnerId").Cast<Guid>().ToList();
                IList taskHistory = GetTaskHistory(startDate, endDate, projectTasks.AsQueryable().Select("TaskId").Cast<object>().ToList()) as IList;
                string owners = GetResponsibilityPerson(Owners);
                overview.ResponsibilityPerson = GetLocalizedCaption("ProjectMember") + (string.IsNullOrEmpty(owners) ? "(TBD)" : owners);
                overview.ProjectSummaryInfo = overview.Type + " " + overview.Technology + " " + overview.Probability + " " + overview.ResponsibilityPerson;
                overview.LatestFeadbackOn = project.LatestFeadbackOn;
                overview.EstimatedEndDate = project.EstimatedEndDate;

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
                overview.WeekActualInput = taskHistory == null ? 0 : taskHistory.AsQueryable().Select("ActualInput").Cast<double?>().Sum();
                overview.WeekEffort = taskHistory == null ? 0 : taskHistory.AsQueryable().Select("Effort").Cast<double?>().Sum();
                overview.WeekRemainderTime = overview.WeekActualWorkHours - overview.WeekEffort;

                //rate
                overview.EvaluateExactlyRate = overview.WeekActualWorkHours == 0 ? 0 : overview.WeekQuoteWorkHours / overview.WeekActualWorkHours;
                overview.InputEffortRate = overview.WeekActualInput == 0 ? 0 : overview.WeekEffort / overview.WeekActualInput;

                overview.ActualStartDate = project.ActualStartDate;

                // ProjectStatus and  Quality from ProjectWeekReport
                IList projectWeekReports = project.ProjectWeekReports;
                projectWeekReports = projectWeekReports.AsQueryable().Where("RecordOn>=@0 && RecordOn<=@1", startDate, endDate).ToArrayList();
                string projectStatus = "";
                string quality = "";
                foreach (var weekReport in projectWeekReports)
                {
                    var weekR = ConvertData.Convert<Katrin.Domain.Impl.ProjectWeekReport>(weekReport);
                    projectStatus += GetHtmlText(weekR.CriteriaProgress);
                    quality += GetHtmlText(weekR.CriteriaQuality);
                }
                overview.ProjectStatus = projectStatus;
                overview.Quality = quality;
                overview.Objective = project.Objective;
                overviewCollection.Add(overview);
            }
            return overviewCollection;
        }

        RichEditControl rich;
        private string GetHtmlText(string htmlString)
        {
            if (rich == null)
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

            return _objectSpace.GetBatchObjects("TaskTimeHistory", filter, null);
        }

        private string GetResponsibilityPerson(IList Owners)
        {
            List<string> result = new List<string>();
            string fullName = string.Empty;
            foreach (var item in Owners)
            {
                var userInfo = _users.AsQueryable().Where("userid=@0", item);
                if (userInfo == null) continue;
                var userName = userInfo.Select("FullName")._First();
                if (userName == null) continue;
                fullName = userName.ToString();
                if (!result.Contains(fullName))
                {
                    result.Add(fullName);
                }
            }
            if (result.Count <= 0) return "";
            return result.Cast<string>().Aggregate((s, t) => s + "," + t);
        }



        private CriteriaOperator GetPredicate()
        {
            CriteriaOperator filter = null;
            if (ProjectIds.Count > 0)
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

        private object GetPropertyValue(object source, string sourceProperty)
        {
            var sourcePropertyInfo = source.GetType().GetProperty(sourceProperty);
            return sourcePropertyInfo.GetValue(source, null);
        }

        private string GetLocalizedPickListValue(string entityName, string attributeName, object objectValue)
        {
            if (objectValue == null) return string.Empty;
            int value = int.Parse(objectValue.ToString());
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

        private void SetMenu()
        {
            //RibbonPage generalPage = (RibbonPage)WorkItem.RootWorkItem.UIExtensionSites[ExtensionSiteNames.Ribbon].First();
            RibbonControl ribbon = this._ribbon;
            RibbonController control = new RibbonController(ribbon, _projectReportView.ReportPrintControl);
            ribbon.AutoSizeItems = true;
            string groupName = "GeneralPageGroup";
            InitStatus(groupName, ribbon.Pages[0].Groups[0]);
            InitDateRang(groupName, ribbon.Pages[0].Groups[0]);
            InitProject(groupName, ribbon.Pages[0].Groups[0]);
            InitManagerPerson(groupName, ribbon.Pages[0].Groups[0]);
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
            BindEnum<ProjectStatus>(statusData, "All", -1);
            statusItem.Edit = statusData;
            ribbonGroup.ItemLinks.Add(statusItem);
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
                    DisplayName = GetLocalizedCaption(name),
                    Value = (int)Enum.Parse(typeof(ProjectDateRange), name)
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
