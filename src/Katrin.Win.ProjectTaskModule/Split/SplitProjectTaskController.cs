using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Controls;
using DevExpress.Data.Filtering;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.Utils;
using DevExpress.XtraEditors;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.Data;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.Domain.Impl;
using Katrin.AppFramework.Metadata;
using ICSharpCode.Core;
using System.Windows.Forms;
using Katrin.AppFramework;
using Katrin.Win.ProjectTaskModule.Common;
namespace Katrin.Win.ProjectTaskModule.Split
{
    public class SplitProjectTaskController : ObjectDetailController
    {

        private ISplitProjectTaskView _projectTaskView;
        private ProjectTask newTaskOne;
        private ProjectTask newTaskTwo;
        private Guid _projectId = Guid.Empty;
        private int _defaultValue = 5;
        private int _minValue = 0;
        public override string ObjectName
        {
            get
            {
                return "SplitProjectTask";
            }
        }

        protected override bool OnSaving()
        {
            var sourceTask = (ProjectTask)ObjectEntity;
            if (newTaskOne.ActualWorkHours < sourceTask.Effort 
                || newTaskOne.QuoteWorkHours < sourceTask.ActualInput)
            {

                XtraMessageBox.Show(ResourceService.GetString("SplitTaskTip"),
                           ResourceService.GetString("Katrin"),
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information,
                           MessageBoxDefaultButton.Button1);
                return false;
            }
            var entityOne = (ProjectTask)_objectSpace.GetOrNew("ProjectTask", newTaskOne.TaskId,null);
            entityOne.TaskNumber = newTaskOne.TaskNumber;
            entityOne.ProjectIterationId = newTaskOne.ProjectIterationId;
            entityOne.QuoteWorkHours = newTaskOne.QuoteWorkHours;
            entityOne.ActualWorkHours = newTaskOne.ActualWorkHours;
            entityOne.Name = newTaskOne.Name;
            TaskOperator.UpdateTaskStatus(entityOne);
            
            bool needCopy = newTaskTwo.TaskId== Guid.Empty?true:false;
            var entityTwo = (ProjectTask)_objectSpace.GetOrNew("ProjectTask", newTaskTwo.TaskId, null);
            entityTwo.TaskNumber = newTaskTwo.TaskNumber;
            entityTwo.ProjectIterationId = newTaskTwo.ProjectIterationId;
            entityTwo.QuoteWorkHours = newTaskTwo.QuoteWorkHours;
            entityTwo.ActualWorkHours = newTaskTwo.ActualWorkHours;
            entityTwo.Name = newTaskTwo.Name;
            if (needCopy)
            {
                entityTwo.Description = entityOne.Description;
                entityTwo.EndDate = entityOne.EndDate;
                entityTwo.OwnerId = entityOne.OwnerId;
                entityTwo.PriorityCode = entityOne.PriorityCode;
                entityTwo.ProjectId = entityOne.ProjectId;
                entityTwo.ProjectModuleId = entityOne.ProjectModuleId;
                entityTwo.StartDate = entityOne.StartDate;
                entityTwo.TaskCategoryCode = entityOne.TaskCategoryCode;
                entityTwo.StatusCode = 1;
            }
            return base.OnSaving();
        }

        protected override void OnSaved()
        {
            EventAggregationManager.SendMessage(new ObjectSetChangedMessage { ObjectName = "ProjectTask" });
            base.OnSaved();
        }

        protected override object GetEntity()
        {
            var entity =  (ProjectTask)_objectSpace.GetOrNew("ProjectTask", ObjectId, "CreatedBy,ModifiedBy");
            entity.RemainderTime = Convert.ToDouble(entity.ActualWorkHours ?? 0) - Convert.ToDouble(entity.Effort ?? 0);
            newTaskOne = new ProjectTask();
            newTaskTwo = new ProjectTask();
            newTaskOne.Name = entity.Name ;
            newTaskTwo.Name = entity.Name + "(1)";
            newTaskOne.TaskId = entity.TaskId;
            newTaskOne.ProjectIterationId = entity.ProjectIterationId;
            newTaskTwo.ProjectIterationId = entity.ProjectIterationId;
            if (!string.IsNullOrEmpty(entity.TaskNumber))
            {
                newTaskOne.TaskNumber = entity.TaskNumber + "_1";
                newTaskTwo.TaskNumber = entity.TaskNumber + "_2";
            }
            if (entity.ActualWorkHours > 0)
            {
                double dValue = (entity.Effort ?? 0) / (entity.ActualWorkHours ?? 0);
                _minValue = (int)(dValue * 10);
                if (dValue * 10 > _minValue) _minValue = _minValue + 1;
                if (_minValue > _defaultValue) _defaultValue = _minValue;
            }
            _projectId = entity.ProjectId;
            SetWorkHours(entity, _defaultValue,0);
            return entity;
        }

        private void SetWorkHours(ProjectTask entity,int processValue,int splitType)
        {
            if (splitType == 0)
            {
                newTaskOne.ActualWorkHours = entity.Effort??0d;
                newTaskTwo.ActualWorkHours = entity.RemainderTime??0d;
                newTaskOne.QuoteWorkHours = entity.ActualInput > entity.QuoteWorkHours ? 
                    entity.QuoteWorkHours : entity.ActualInput;
                newTaskTwo.QuoteWorkHours = entity.QuoteWorkHours < newTaskOne.QuoteWorkHours ? 
                    0d : ((entity.QuoteWorkHours??0) - (newTaskOne.QuoteWorkHours??0));
            }
            else if (splitType == 1)
            {
                newTaskOne.ActualWorkHours = (processValue * 1.0 / 10) * (entity.ActualWorkHours??0);
                newTaskTwo.ActualWorkHours = (entity.ActualWorkHours??0) - (newTaskOne.ActualWorkHours??0);
                newTaskOne.QuoteWorkHours = (processValue * 1.0 / 10) * (entity.QuoteWorkHours??0);
                newTaskTwo.QuoteWorkHours = entity.QuoteWorkHours < newTaskOne.QuoteWorkHours?
                    0d : ((entity.QuoteWorkHours??0) - (newTaskOne.QuoteWorkHours??0));
            }
        }

        protected override void InitEditors()
        {
            var entityMetadata = MetadataRepository.Entities.First(e => e.TableName == "ProjectTask");
            _detailView.InitEditors(entityMetadata);
        }

        protected override void OnViewSet()
        {
            if(!(_detailView is ISplitProjectTaskView)) return;
            _projectTaskView = (ISplitProjectTaskView)_detailView;
            _projectTaskView.OnValueChanged += _projectTaskView_OnValueChanged;
            base.OnViewSet();
            HasChanges = true;
        }

        void _projectTaskView_OnValueChanged(object sender, EventArgs<int,int> e)
        {
            var task = (ProjectTask)ObjectEntity;
            SetWorkHours(task, e.Data1,e.Data2);
        }

        protected override void BindData(object objectInfo)
        {
  
            var task = (Katrin.Domain.Impl.ProjectTask)ObjectEntity;
            if (_projectId != Guid.Empty)
                task.ProjectId = _projectId;
            else
                _projectId = task.ProjectId;
            _projectTaskView.BindNewTask(_minValue,_defaultValue, _projectId, newTaskOne, newTaskTwo);
            base.BindData(objectInfo);
        }
    }
}
