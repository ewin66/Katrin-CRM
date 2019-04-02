using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.Win.DetailViewModule;
using DevExpress.XtraEditors;


namespace Katrin.Win.ProjectIterationModule.Version
{

    public class ProjectVersionDetailController : ObjectDetailController
    {
        private Guid _projectId = Guid.Empty;
        private IProjectVersionDetailView _versionView;
        public override string ObjectName
        {
            get
            {
                return "ProjectVersion";
            }
        }

        protected override string RibbonPath
        {
            get
            {
                return "/ProjectVersion/Detail/Ribbon";
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
            if (!(_detailView is IProjectVersionDetailView)) return;
            _versionView = (IProjectVersionDetailView)_detailView;
            base.OnViewSet();
        }

        protected override void OnSaved()
        {
            base.OnSaved();
            //EventHandler handler = OnRefreshProjectVersion;
            //if (handler != null)
            //{
            //    handler(this, new EventArgs());
            //}
        }

        protected override void BindData(object objectInfo)
        {
            var version = (Katrin.Domain.Impl.ProjectVersion)ObjectEntity;
            if (_projectId != Guid.Empty)
                version.ProjectId = _projectId;
            else
                _projectId = version.ProjectId;
            if (_projectId != Guid.Empty)
            {
                _versionView.SetProjectEable(false);
            }
            base.BindData(objectInfo);
        }
    }
}
