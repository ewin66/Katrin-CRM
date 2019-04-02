using Katrin.Win.Common.Core;
using Katrin.Win.MainModule.Constants;
using Microsoft.Practices.CompositeUI.EventBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.MainModule.Views.ProjectModule
{
    public class ProjectModuleDetailPresenter : EntityDetailPresenter<IProjectModuleDetailView>
    {
        public ProjectModuleDetailPresenter()
        {
            EntityName = "ProjectModule";
        }

        [EventPublication(EventTopicNames.RefreshProjectModule, PublicationScope.Global)]
        public event EventHandler OnRefreshProjectModule;

        protected override void OnSaved()
        {
            base.OnSaved();
            EventHandler handler = OnRefreshProjectModule;
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
