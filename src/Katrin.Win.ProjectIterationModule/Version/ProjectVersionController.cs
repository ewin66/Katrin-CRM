using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework;
using Katrin.AppFramework.WinForms;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.MVC;
using DevExpress.Data.Filtering;

namespace Katrin.Win.ProjectIterationModule.Version
{
    public class ProjectVersionController : ListController, IObjectWidget, IListener<SelectedObjectChangedMessage>
    {

        public ProjectVersionController()
        {
            ObjectName = "ProjectVersion";
        }

        public string ParentObjectName
        {
            get;
            set;
        }

        public override IActionResult Execute(ActionParameters parameters)
        {
            _listView = CreateListView("DefaultListView");
            _listView.ObjectName = ObjectName;
            var result = new PartialViewResult();
            result.View = _listView;
            return result;
        }

        void IListener<SelectedObjectChangedMessage>.Handle(SelectedObjectChangedMessage message)
        {
            if (message.ObjectName == ParentObjectName)
            {
                if (message.SelectedObject == null)
                {
                    _listView.ClearData();
                    return;
                }

                var id = _objectSpace.GetObjectId(message.ObjectName, message.SelectedObject);

                FixedFilter = new BinaryOperator("ProjectId", id);

                BindListData();
            }
        }

    }
}
