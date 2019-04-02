using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using Katrin.Win.Common.Core;
using Katrin.Win.Infrastructure;
using Katrin.Win.MainModule.Constants;
using DevExpress.XtraEditors;
using Microsoft.Practices.CompositeUI.EventBroker;

namespace Katrin.Win.MainModule.Views.ProjectVersion
{

    public class ProjectVersionDetailPresenter : EntityDetailPresenter<IProjectVersionDetailView>
    {
        public ProjectVersionDetailPresenter()
        {
            EntityName = "ProjectVersion";
        }

        [EventPublication(EventTopicNames.RefreshProjectVersion, PublicationScope.Global)]
        public event EventHandler OnRefreshProjectVersion;

        protected override void OnSaved()
        {
            base.OnSaved();
            EventHandler handler = OnRefreshProjectVersion;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
       
        protected override void BindData(object data)
        {
            var projectId = WorkItem.State["ProjectId"];
            if (projectId != null)
            {
                DynamicEntity.ProjectId = projectId;
                if (WorkingMode == EntityDetailWorkingMode.Add)
                {
                    View.SetProjectEable(false);
                }
            }
            base.BindData(data);
        }
    }
}
