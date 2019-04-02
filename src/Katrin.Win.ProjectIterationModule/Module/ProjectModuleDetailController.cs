using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.Win.DetailViewModule;

namespace Katrin.Win.ProjectIterationModule.Module
{
    public class ProjectModuleDetailController : ObjectDetailController
    {
        private IProjectModuleDetailView _moduleView;
        private Guid _projectId = Guid.Empty;
        public override string ObjectName
        {
            get
            {
                return "ProjectModule";
            }
        }

        protected override string RibbonPath
        {
            get
            {
                return "/ProjectModule/Detail/Ribbon";
            }
        }


        public override IActionResult Execute(ActionParameters parameters)
        {
            if (parameters.ContainsKey("ProjectId"))
                _projectId = parameters.Get<Guid>("ProjectId");
            //var view = Detail(objectName, objectId, workMode);
            return base.Execute(parameters);
        }

        protected override void OnViewSet()
        {
            if (!(_detailView is IProjectModuleDetailView)) return;
            _moduleView = (IProjectModuleDetailView)_detailView;
            base.OnViewSet();
        }

        protected override void OnSaved()
        {
            base.OnSaved();
            //EventHandler handler = OnRefreshProjectModule;
            //if (handler != null)
            //{
            //    handler(this, new EventArgs());
            //}
        }

        protected override void BindData(object objectInfo)
        {

            var module = (Katrin.Domain.Impl.ProjectModule)ObjectEntity;
            if (_projectId != Guid.Empty)
                module.ProjectId = _projectId;
            else
                _projectId = module.ProjectId;
            if (_projectId != Guid.Empty)
            {
                _moduleView.SetProjectEable(false);
            }
            base.BindData(objectInfo);
        }
    }
}
