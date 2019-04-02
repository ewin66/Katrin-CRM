using Katrin.AppFramework;
using Katrin.AppFramework.WinForms;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms.Controls;
using Katrin.AppFramework.WinForms.Grid;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Views;
using DevExpress.Data.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.NoteModule
{
    public class NoteController : ListController, IObjectWidget,IListener<SelectedObjectChangedMessage>
    {
        public NoteController()
        {
            ObjectName = "Note";
        }

        public string ParentObjectName
        {
            get;
            set;
        }


        public override IActionResult Execute(ActionParameters parameters)
        {
            _listView = CreateListView("DefaultListView");
            _listView.ViewType = ListViewType.LayoutView;
            _listView.ObjectName = ObjectName;
            if (parameters.ObjectId != Guid.Empty)
            {
                var objectId = parameters.ObjectId;
                FixedFilter = new BinaryOperator("ObjectId", objectId);
                BindListData();
            }
            
            var result = new PartialViewResult();
            result.View = _listView;
            return result;
        }

        void IListener<SelectedObjectChangedMessage>.Handle(SelectedObjectChangedMessage message)
        {
            //only receive meseage from same workspace.
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

                FixedFilter = new BinaryOperator("ObjectId", id);

                BindListData();
            }
        }

        public override object SelectedObject
        {
            get { return _listView.SelectedObject; }
        }

        public override bool CanRefresh(ObjectSetChangedMessage message)
        {
            if (this.ParentObjectName != message.ParentObjectName)
            {
                return false;
            }
            return true;
        }
      
    }
}
