using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Practices.ObjectBuilder;
using Katrin.Win.Infrastructure;
using Katrin.Win.Common.MetadataServiceReference;
using System.Reflection;
using System.IO;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using Katrin.Win.Common.Core;
using Katrin.Win.MainModule.Properties;

namespace Katrin.Win.MainModule.Views.ProjectTask
{
    public partial class ProjectTaskChartView : Katrin.Win.Common.Core.View, IProjectTaskChartView
    {
        private ProjectTaskChartPresenter _presenter;
        public event EventHandler<EventArgs<object,int,int>> OnStatusCodeChange;
        public event EventHandler<EventArgs<object>> OnEditItem;
        public event EventHandler<EventArgs<object>> OnEditEffort;

        [CreateNew]
        public ProjectTaskChartPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        public ProjectTaskChartView()
        {
            InitializeComponent();
        }

        public void InitEditors()
        {
            
            List<LookupListItem<int>> tagList = new List<LookupListItem<int>>();
            tagList.Add(new LookupListItem<int> { DisplayName = "NotStarted", Value = 1 });
            tagList.Add(new LookupListItem<int> { DisplayName = "InProgress", Value = 2 });
            tagList.Add(new LookupListItem<int> { DisplayName = "Completed", Value = 3 });
            tagList.Add(new LookupListItem<int> { DisplayName = "Acceptance", Value = 4 });
            Assembly asm = this.GetType().Assembly;
            Stream stream = asm.GetManifestResourceStream("Katrin.Win.MainModule.DefaultLayout.ProjectTask.BoardColumn.xml");
            taskLookBoardByStage.CreateBoards(tagList, "StatusCode", stream);
            taskLookBoardByStage.OnStatusCodeChange += OnStatusCodeChange;
            taskLookBoardByStage.OnValidataStatus += OnValidataStatus;
            taskLookBoardByStage.OnCurrentChange += OnCurrentChange;
            taskLookBoardByStage.OnEditItem += OnEditItem;

        }

        void OnCurrentChange(object sender, EventArgs<object> e)
        {
            int postion = 0;
            foreach (var item in Context.BindingSource.ToArrayList())
            {
                if (item.AsDyanmic().TaskId == e.Data.AsDyanmic().TaskId)
                {
                    Context.BindingSource.Position = postion;
                    break;
                }
                postion++;
            }
        }

        private bool OnValidataStatus(object obj,int toStatus)
        {
            if (obj.AsDyanmic().StatusCode > toStatus && toStatus == 1)
            {
                return false;
            }
            return true;
        }

        protected override void BindData()
        {
            _presenter.UpdateContextFilters();
            _presenter.BindData();
        }

        void IProejctTaskFilter.BindData()
        {
            BindData();
        }

        public void BindTaskData(BindingList<object> taskList)
        {
            taskLookBoardByStage.BoardDataList = taskList;
        }

        private void BindLookUp(LookUpEdit lookUp, List<LookupListItem<Guid?>> dataSource)
        {
            lookUp.Properties.InitializeLookUpEdit(dataSource);
            lookUp.Properties.AllowNullInput = DefaultBoolean.True;
            lookUp.Properties.NullText = Resources.All;
        }

        public void BindProjectLookUp(List<LookupListItem<Guid?>> projectDataSource)
        {
            BindLookUp(ProjectSearchLookUpEdit, projectDataSource);
        }

        public void BindIterationLookUp(List<LookupListItem<Guid?>> iterationDataSource)
        {
            BindLookUp(ProjectIterationSearchLookUpEdit, iterationDataSource);
        }

        public void BindMemberLookUp(List<LookupListItem<Guid?>> memberDataSource)
        {
            BindLookUp(memberLookUp, memberDataSource);
        }

        private void ProjectSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            _presenter.OnProjectChanged(ProjectId);
            BindData();
        }

        private void ProjectIterationSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void memberLookUp_EditValueChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private Guid? GetValue(object value)
        {
            if (Convert.IsDBNull(value)) return null;
            return (Guid?)value;
        }

        public Guid? ProjectId
        {
            get
            {
                return GetValue(ProjectSearchLookUpEdit.EditValue);
            }
            set
            {
                ProjectSearchLookUpEdit.EditValue = value;
            }
        }

        public Guid? ProjectIterationId
        {
            get
            {
                return GetValue(ProjectIterationSearchLookUpEdit.EditValue);
            }
            set
            {
                ProjectIterationSearchLookUpEdit.EditValue = value;
            }
        }

        public Guid? MemberId
        {
            get
            {
                return GetValue(memberLookUp.EditValue);
            }
            set
            {
                memberLookUp.EditValue = value;
            }
        }


        public void InitFilters()
        {
            _presenter.InitFilters();
        }


        public void BeginUpdate()
        {
            this.ProjectSearchLookUpEdit.EditValueChanged -= new System.EventHandler(this.ProjectSearchLookUpEdit_EditValueChanged);
            this.ProjectIterationSearchLookUpEdit.EditValueChanged -= new System.EventHandler(this.ProjectIterationSearchLookUpEdit_EditValueChanged);
            this.memberLookUp.EditValueChanged -= new System.EventHandler(this.memberLookUp_EditValueChanged);
        }

        public void EndUpdate()
        {
            this.ProjectSearchLookUpEdit.EditValueChanged += new System.EventHandler(this.ProjectSearchLookUpEdit_EditValueChanged);
            this.ProjectIterationSearchLookUpEdit.EditValueChanged += new System.EventHandler(this.ProjectIterationSearchLookUpEdit_EditValueChanged);
            this.memberLookUp.EditValueChanged += new System.EventHandler(this.memberLookUp_EditValueChanged);
        }
    }
}
