using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using Katrin.Win.Common;
using DevExpress.Data.Filtering;
using System.Windows.Forms;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework.WinForms.Context;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Grid;
using ICSharpCode.Core;
using Katrin.AppFramework.Metadata;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.WinForms.Workspaces;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.Win.MainModule.Views.ProjectTask;
using Katrin.AppFramework.Data;
using Katrin.AppFramework.WinForms;
using Katrin.AppFramework.WinForms.Messages;
namespace Katrin.Win.ProjectTaskModule.Chart
{
    public interface IProejctTaskFilter : IView
    {
        Guid? ProjectId { get; set; }
        Guid? ProjectIterationId { get; set; }
        Guid? MemberId { get; set; }
        string ObjectName { get; set; }
        void BeginUpdate();
        void EndUpdate();

        void BindData();
        IActionContext Context { get; set; }
        void ReadFilterConfig();
        void InitFilters();
        void BindProjectLookUp(List<LookupListItem<Guid?>> projects);
        void BindIterationLookUp(List<LookupListItem<Guid?>> iterations);
        void BindMemberLookUp(List<LookupListItem<Guid?>> members);


        event EventHandler UpdateContextFilters;
        event EventHandler<EventArgs<Guid?>> OnProjectChanged;
        event EventHandler InitProjectTaskFilters;

    }

    public class ProjectTaskLookBoardData
    {
        public string ProjectName { get; set; }
        public string ProjectIterationName { get; set; }
        public string Description { get; set; }
        public Color BgColor { get; set; }
        public string Name { get; set; }
        public Guid? TaskId { get; set; }
        public int StatusCode { get; set; }
        public string OwnerFullName { get; set; }
        public double? ActualWorkHours { get; set; }
        public double? Effort { get; set; }
    }

    public class ProjectTaskChartController : BaseController
    {
        private IProjectTaskChartView _projectTaskChartView;
        Dictionary<string, Color> _bgColorList = new Dictionary<string, Color>();
        List<Color> _colorList = new List<Color>()
            {
                Color.FromArgb(231, 231, 231),Color.FromArgb(0xA1,0xA1,0xA1),Color.FromArgb(0xB0,0xE2,0xFF),Color.FromArgb(0xC2,0xC2,0xC2),
                Color.FromArgb(0xD1,0xEE,0xEE),Color.FromArgb(0xBF,0xEF,0xFF),Color.FromArgb(0x7B,0x68,0xEE),Color.FromArgb(0xAB,0x82,0xFF),
                Color.FromArgb(0xFF,0xE4,0xC4),Color.FromArgb(0xFF,0xA5,0x00),Color.FromArgb(0xEE,0x82,0xEE),Color.FromArgb(0xCD,0x91,0x9E),
                Color.FromArgb(0xC1,0xCD,0xCD),Color.FromArgb(0x9A,0xC0,0xCD),Color.FromArgb(0xCC,0xCC,0xCC),Color.FromArgb(0x77,0x88,0x99)
            };

        public override IActionResult Execute(ActionParameters parameters)
        {
            _projectTaskChartView = ViewFactory.CreateView("DefaultProjectTaskChartView") as IProjectTaskChartView;
            _projectTaskFilterView = _projectTaskChartView.TaskFilter;
            this._projectTaskFilterView.ObjectName = this.ObjectName;
            this._projectTaskFilterView.ReadFilterConfig();
            OnViewSet();
            var result = new PartialViewResult();
            result.View = _projectTaskChartView;
            return result;
        }

        public ProjectTaskChartController()
        {
            ObjectName = "ProjectTaskChart";
            ControllerId = "ProjectTask";
        }

        protected override  void OnViewSet()
        {
            base.OnViewSet();
            //_projectTaskChartView.BindProjectTaskData += _projectTaskChartView_BindProjectTaskData;
            _projectTaskChartView.OnStatusCodeChange += OnStatusCodeChange;
            _projectTaskChartView.OnEditItem += OnEditItem;
            _projectTaskChartView.InitEditors();
        }

        public override void UpdateContextFilters()
        {
            base.UpdateContextFilters();
            BindData();
        }


        private void OnEditItem(object sender, EventArgs<object> e)
        {
            var projectTask = ConvertData.Convert<Katrin.Domain.Impl.ProjectTask>(e.Data);
            var parameters = new ActionParameters("ProjectTask", projectTask.TaskId, ViewShowType.Show){
                    {"WorkingMode",EntityDetailWorkingMode.Edit}
                };
            App.Instance.Invoke("ProjectTask", "Detail", parameters);
        }


        protected override void BindListData()
        {
            BindData();
        }

        public void BindData()
        {
            
            var filterCriteria = _projectTaskFilterView.Context.GetFilters();
            if ((object)_queryFilter != null && (object)filterCriteria != null)
                filterCriteria &= _queryFilter;
            else if ((object)_queryFilter != null)
            {
                filterCriteria = _queryFilter;
            }
            List<string> incluePath = new List<string>(){"Owner"};
            var projections = GridViewExtension.GetColumnProjections(EntityName, incluePath);
            var fetchColumns = projections.Select(p => string.Format("{0} AS {1}", p.QueryExpression, p.Projection)).ToArray();
            var selector = string.Format("new({0})", string.Join(",", fetchColumns));
            var query = _objectSpace.GetObjectQuery(EntityName, selector, filterCriteria);

            var worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += (s, e) =>
            {
                e.Result = query.ToArrayList();
            };
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _projectTaskFilterView.Context.BindingSource.DataSource = e.Result;
            BindTaskData();
        }

        private void BindTaskData()
        {
            BindingList<object> taskList = new BindingList<object>();

            foreach (var item in _projectTaskFilterView.Context.BindingSource)
            {
                ProjectTaskLookBoardData boardData = new ProjectTaskLookBoardData();
                var projectTask = ConvertData.Convert<Katrin.Domain.Impl.ProjectTask>(item);
                boardData.Name = projectTask.Name;
                boardData.TaskId = projectTask.TaskId;
                boardData.StatusCode = projectTask.StatusCode;
                boardData.OwnerFullName = projectTask.Owner == null?string.Empty:projectTask.Owner.FullName;
                boardData.ActualWorkHours = projectTask.ActualWorkHours;
                boardData.Effort = projectTask.Effort;
                if (projectTask.PriorityCode != null)
                    boardData.ProjectName = GetLocalizedPickListValue(EntityName, "PriorityCode", projectTask.PriorityCode??0);
                boardData.ProjectIterationName = StringParser.Parse("${res:colSumEffort}") + ":" + projectTask.Effort;
                boardData.Description = StringParser.Parse("${res:colSumQuoteWorkHours}") + ":" + projectTask.ActualWorkHours;
                SetBackColor(boardData);
                taskList.Add(boardData);
            }
            _projectTaskChartView.BindTaskData(taskList);
        }

        private void SetBackColor(ProjectTaskLookBoardData boardData)
        {
            if (string.IsNullOrEmpty(boardData.OwnerFullName)) return;
            if (_bgColorList.Keys.Contains(boardData.OwnerFullName))
            {
                boardData.BgColor = _bgColorList[boardData.OwnerFullName];
            }
            else
            {
                boardData.BgColor = _colorList[_bgColorList.Count % 16];
                _bgColorList.Add(boardData.OwnerFullName, boardData.BgColor);
            }
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

        private string EntityName
        {
            get { return "ProjectTask"; }
        }


        private void OnStatusCodeChange(object sender,EventArgs<object,int,int> e)
        {
            var fromStatus = e.Data2;
            var newStatus = e.Data3;
            
            var isTaskCompleted = fromStatus ==3 || fromStatus == 4;
            var attemptingComplete  = newStatus ==3 || fromStatus == 4;
            var projectTask = ConvertData.Convert<Katrin.Domain.Impl.ProjectTask>(e.Data1);
            var hasRemaininWorks = projectTask.ActualWorkHours > projectTask.Effort;

            if (!isTaskCompleted && attemptingComplete && hasRemaininWorks)
            {
                Cursor.Current = Cursors.WaitCursor;
                var parameters = new ActionParameters("ProjectTaskEffort", projectTask.TaskId, ViewShowType.Show){
                    {"WorkingMode",EntityDetailWorkingMode.Edit}
                };
                App.Instance.Invoke("ProjectTaskEffort", "Detail", parameters);
                Cursor.Current = Cursors.Default;
            }
            BackgroundWorker bgWorker = new BackgroundWorker();
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += (ws, we) =>
                {
                    var entity = (Katrin.Domain.Impl.ProjectTask)_objectSpace.GetOrNew(EntityName, projectTask.TaskId,null);
                    entity.StatusCode = newStatus;
                    _objectSpace.SaveChanges();
                };
            bgWorker.RunWorkerAsync();
           

        }
    }
}
