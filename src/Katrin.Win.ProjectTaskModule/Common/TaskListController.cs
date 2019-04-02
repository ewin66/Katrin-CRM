using DevExpress.Data.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Katrin.Win.Common;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.Win.ProjectTaskModule.Common;
using Katrin.AppFramework.WinForms.Context;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.Security;
using Katrin.AppFramework.WinForms.Extensions;
using ICSharpCode.Core;
using Katrin.AppFramework;
using Katrin.Win.ProjectTaskModule.Chart;
using Katrin.AppFramework.Data;
using System.Collections;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.MVC;
using System.Windows.Forms;
namespace Katrin.Win.MainModule.Views.ProjectTask
{
    public class TaskListController : ListController
    {
        public IEnumerable<LookupListItem<Guid?>> GetProjectMembersForMemu(Guid? projectId)
        {
            List<LookupListItem<Guid?>> result = new List<LookupListItem<Guid?>>();
            if (projectId == null) return result;
            Dictionary<string, string> additonProperty = new Dictionary<string, string>();
            additonProperty["Member"] = "Member";

            CriteriaOperator filter = new BinaryOperator("ProjectId", projectId);
            var memberList = _objectSpace.GetObjects("ProjectMember", filter, additonProperty);
            Katrin.Domain.Impl.ProjectTask task = this.GetSelectedEntity();
            //add unassign
            string unassignCaption = ResourceService.GetString("Unassigned");
            LookupListItem<Guid?> itemUnassign = new LookupListItem<Guid?>();
            itemUnassign.DisplayName = unassignCaption;
            itemUnassign.Value = null;
            itemUnassign.IsDeafult = task.OwnerId == null;
            result.Add(itemUnassign);

            foreach (var member in memberList)
            {
                var projectMemeber = ConvertData.Convert<Katrin.Domain.Impl.ProjectMember>(member);
                LookupListItem<Guid?> item = new LookupListItem<Guid?>();
                item.Value = projectMemeber.Member.UserId;
                item.IsDeafult = task.OwnerId == item.Value;
                item.DisplayName = projectMemeber.Member.FullName;
                result.Add(item);
            }
            return result;
        }

        public IEnumerable<LookupListItem<Guid?>> GetProjectIterationsForMenu(Guid? projectId)
        {
            List<LookupListItem<Guid?>> result = new List<LookupListItem<Guid?>>();

            if (projectId == null) return result;


            Dictionary<string, string> additonProperty = new Dictionary<string, string>();
            additonProperty["IterationNameAndTime"] = "null";
            CriteriaOperator filter = new BinaryOperator("ProjectId", projectId);
            var iterationList = _objectSpace.GetObjects("ProjectIteration", filter, additonProperty)
                .AsQueryable().OrderBy("StartDate desc");

            Katrin.Domain.Impl.ProjectTask task = this.GetSelectedEntity();
            Guid? defaultIterationId = task.ProjectIterationId;
            var displayNameFormat = "{0} ({1:yy/MM/dd} - {2:yy/MM/dd})";

            string unassignCaption = ResourceService.GetString("Unassigned");
            LookupListItem<Guid?> itemUnassign = new LookupListItem<Guid?>();
            itemUnassign.DisplayName = unassignCaption;
            itemUnassign.Value = null;
            itemUnassign.IsDeafult = task.ProjectIterationId == null;
            result.Add(itemUnassign);

            foreach (var iterationObj in iterationList)
            {
                var iteration = ConvertData.Convert<Katrin.Domain.Impl.ProjectIteration>(iterationObj);
                Guid projectIterationId = iteration.ProjectIterationId;
                bool isDefault = projectIterationId == defaultIterationId;
                LookupListItem<Guid?> item = new LookupListItem<Guid?>();
                item.Value = projectIterationId;
                item.IsDeafult = isDefault;
                item.DisplayName = string.Format(displayNameFormat, iteration.Name, iteration.StartDate, iteration.Deadline);
                result.Add(item);
            }
            return result;
        }

        protected Katrin.Domain.Impl.ProjectTask GetSelectedEntity()
        {
            Guid projectTaskId = this._objectSpace.GetObjectId(this.ObjectName, this.SelectedObject);
            object projectTask = this._objectSpace.GetOrNew(this.ObjectName, projectTaskId, null);
            Katrin.Domain.Impl.ProjectTask task = projectTask as Katrin.Domain.Impl.ProjectTask;
            return task;
        }
    }
}
