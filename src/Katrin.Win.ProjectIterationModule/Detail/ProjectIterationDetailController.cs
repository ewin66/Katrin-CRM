using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Collections;
using DevExpress.Data.Filtering;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Messages;
using ICSharpCode.Core;
using Katrin.AppFramework.WinForms.MVC;

namespace Katrin.Win.ProjectIterationModule.ProjectIteration
{
    public class ProjectIterationDetailController : ObjectDetailController
    {
        private IProjectIterationDetailView _iterationView;
        private Guid _projectId = Guid.Empty;
        public override string ObjectName
        {
            get
            {
                return "ProjectIteration";
            }
        }

        protected override string RibbonPath
        {
            get
            {
                return "/ProjectIteration/Detail/Ribbon";
            }
        }

        //[EventPublication(EventTopicNames.RefreshProjectIteration, PublicationScope.Global)]
        //public event EventHandler OnRefreshProjectIteration;

        public override IActionResult Execute(ActionParameters parameters)
        {
            if (parameters.ContainsKey("ProjectId"))
                _projectId = parameters.Get<Guid>("ProjectId");
            //var view = Detail(objectName, objectId, workMode);
            return base.Execute(parameters);
        }

        protected override object GetEntity()
        {
            var entity = _objectSpace.GetOrNew(ObjectName, ObjectId, null);
            Katrin.Domain.Impl.ProjectIteration projectIteration = entity as Katrin.Domain.Impl.ProjectIteration;
            if (WorkingMode == EntityDetailWorkingMode.Add)
            {
                projectIteration.StatusCode = (int)1;
            }
            return projectIteration;
        }

        protected override void OnSaved()
        {
            base.OnSaved();
            //EventHandler handler = OnRefreshProjectIteration;
            //if (handler != null)
            //{
            //    handler(this, new EventArgs());
            //}
        }
        protected override void OnViewSet()
        {
            if (!(_detailView is IProjectIterationDetailView)) return;
            _iterationView = (IProjectIterationDetailView)_detailView;
            _iterationView.OnProjectChange += OnProjectChange;
            base.OnViewSet();
        }

        private void OnProjectChange(object sender, EventArgs<Guid> e)
        {
            if (WorkingMode != EntityDetailWorkingMode.Add) return;
            Guid projectId = e.Data;
            CriteriaOperator filter = new BinaryOperator("ProjectId", projectId);
            var projectIteration = (Katrin.Domain.Impl.ProjectIteration)ObjectEntity;
            filter &= new BinaryOperator("ProjectIterationId", projectIteration.ProjectIterationId, BinaryOperatorType.NotEqual);
            var iterationList = (List<Katrin.Domain.Impl.ProjectIteration>)_objectSpace.GetObjects(ObjectName, filter, null);

            DateTime startDate = DateTime.Today;
            if (iterationList.Count > 0)
            {
                startDate = iterationList.Select(c => c.Deadline).Cast<DateTime>().Max();
                startDate = startDate.AddDays(1);
            }
            projectIteration.StartDate = startDate;
        }

        protected override bool OnSaving()
        {
            bool result = true;
            _iterationView.ValidateResult = result;
            if (!_iterationView.ValidateData()) return false;
            var projectIteration = (Katrin.Domain.Impl.ProjectIteration)ObjectEntity;
            DateTime startDate = projectIteration.StartDate ?? DateTime.Today;
            DateTime endDate = projectIteration.Deadline ?? DateTime.Today;
            if (startDate > endDate)
            {
                result = false;
                XtraMessageBox.Show(StringParser.Parse("IterationDateCompareMessage"),
                          StringParser.Parse("Katrin"),
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information,
                          MessageBoxDefaultButton.Button1);
            }
            if (result)
            {
                CriteriaOperator filter = new BinaryOperator("projectid", projectIteration.ProjectId)
                            & new BinaryOperator("ProjectIterationId", projectIteration.ProjectIterationId, BinaryOperatorType.NotEqual);
                var iterationList = (List<Katrin.Domain.Impl.ProjectIteration>)_objectSpace.GetObjects(ObjectName, filter, null);
                foreach (var iteration in iterationList)
                {
                    DateTime iterationStartDate = iteration.StartDate ?? DateTime.Today;
                    DateTime iterationEndDate = iteration.Deadline ?? DateTime.Today;
                    if (startDate < iterationEndDate && endDate > iterationStartDate)
                    {
                        result = false;
                        XtraMessageBox.Show(StringParser.Parse("IterationDateErrorMessage"),
                          StringParser.Parse("Katrin"),
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information,
                          MessageBoxDefaultButton.Button1);
                        break;
                    }
                }
            }
            _iterationView.ValidateResult = result;
            return true;
        }

        protected override void BindData(object objectInfo)
        {
            var iteration = (Katrin.Domain.Impl.ProjectIteration)ObjectEntity;
            if (_projectId != Guid.Empty)
                iteration.ProjectId = _projectId;
            else
                _projectId = iteration.ProjectId;
            if (_projectId != Guid.Empty)
            {
                _iterationView.SetProjectEable(false);
            }
            base.BindData(objectInfo);
        }
    }
}
