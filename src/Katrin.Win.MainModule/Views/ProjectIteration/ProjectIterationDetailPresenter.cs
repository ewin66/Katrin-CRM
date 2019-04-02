using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Katrin.Win.Common.Core;
using Katrin.Win.MainModule.Constants;
using Microsoft.Practices.CompositeUI.EventBroker;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Katrin.Win.Infrastructure;
using System.Collections;
using DevExpress.Data.Filtering;

namespace Katrin.Win.MainModule.Views.ProjectIteration
{
    public class ProjectIterationDetailPresenter : EntityDetailPresenter<IProjectIterationDetailView>
    {
        public ProjectIterationDetailPresenter()
        {
            EntityName = "ProjectIteration";
        }

        [EventPublication(EventTopicNames.RefreshProjectIteration, PublicationScope.Global)]
        public event EventHandler OnRefreshProjectIteration;

        protected override void OnSaved()
        {
            base.OnSaved();
            EventHandler handler = OnRefreshProjectIteration;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
        protected override void OnViewSet()
        {
            View.OnProjectChange += OnProjectChange;
            base.OnViewSet();
        }

        private void OnProjectChange(object sender, EventArgs<Guid> e)
        {
            if (WorkingMode != EntityDetailWorkingMode.Add) return;
            Guid projectId = e.Data;
            CriteriaOperator filter = new BinaryOperator("ProjectId", projectId);
            filter &= new BinaryOperator("ProjectIterationId", DynamicEntity.ProjectIterationId, BinaryOperatorType.NotEqual);
            var iterationList = DynamicDataServiceContext.GetObjects(EntityName, filter, null);

            DateTime startDate = DateTime.Today;
            IList projectIterationList = iterationList as IList;
            if (projectIterationList.Count > 0)
            {
                startDate = projectIterationList.AsQueryable().Select("Deadline").Cast<DateTime>().Max();
                startDate = startDate.AddDays(1);
            }
            DynamicEntity.StartDate = startDate;
        }

        protected override void OnSaving()
        {
            bool result = true;
            View.ValidateResult = result;
            if (!View.ValidateData()) return;
            DateTime startDate = DynamicEntity.StartDate;
            DateTime endDate = DynamicEntity.Deadline;
            if(startDate > endDate)
            {
                result = false;
                XtraMessageBox.Show(Properties.Resources.IterationDateCompareMessage,
                          Properties.Resources.Katrin,
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information,
                          MessageBoxDefaultButton.Button1);
            }
            if (result)
            {
                CriteriaOperator filter = new BinaryOperator("projectid", DynamicEntity.ProjectId)
                            & new BinaryOperator("ProjectIterationId", DynamicEntity.ProjectIterationId,BinaryOperatorType.NotEqual);
                var iterationList = DynamicDataServiceContext.GetObjects(EntityName, filter,null);
                foreach (var iteration in iterationList)
                {
                    dynamic dynamic = iteration.AsDyanmic();
                    DateTime iterationStartDate = dynamic.StartDate;
                    DateTime iterationEndDate = dynamic.Deadline;
                    if (startDate < iterationEndDate && endDate > iterationStartDate)
                    {
                        result = false;
                        XtraMessageBox.Show(Properties.Resources.IterationDateErrorMessage,
                          Properties.Resources.Katrin,
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information,
                          MessageBoxDefaultButton.Button1);
                        break;
                    }
                }
            }
            View.ValidateResult = result;
        }

        protected override void BindData(object data)
        {
            var projectId = WorkItem.State["ProjectId"];
            var fromProject = WorkItem.State["FromProject"];
            if (projectId != null)
            {
                DynamicEntity.ProjectId = projectId;
                if (fromProject != null)
                {
                    View.SetProjectEable(false);
                }
            }
            base.BindData(data);
        }
    }
}
