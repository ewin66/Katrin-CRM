using Katrin.AppFramework;
using Katrin.AppFramework.WinForms;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms.Grid;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Views;
using DevExpress.Data.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.TimeTrackingModule
{
    public class TimeTrackingController : ListController, IObjectWidget, IListener<SelectedObjectChangedMessage>
    {
        public TimeTrackingController()
        {
            ObjectName  = "TimeTracking";
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
            if (parameters.ObjectId != Guid.Empty && parameters.ObjectName != string.Empty)
            {
                Guid objectId = parameters.ObjectId;
                string objectName = parameters.ObjectName;
                FixedFilter = new BinaryOperator("OpportunityId", objectId);
                BindListData();
            }
            var result = new PartialViewResult();
            result.View = _listView;
            return result;
        }

        void IListener<SelectedObjectChangedMessage>.Handle(SelectedObjectChangedMessage message)
        {
            if (message.WorkSpaceID != this.WorkSpaceID)
            {
                return;
            }
            if (message.ObjectName == ParentObjectName)
            {
                if (message.SelectedObject == null)
                {
                    _listView.ClearData();
                    return;
                }

                var id = _objectSpace.GetObjectId(message.ObjectName, message.SelectedObject);

                FixedFilter = new BinaryOperator("OpportunityId", id);

                BindListData();
            }
        }

        public override object SelectedObject
        {
            get { return _listView.SelectedObject; }
        }
    }
}
