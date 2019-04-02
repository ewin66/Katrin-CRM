using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;
using System.IO;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.WinForms.Context;
using ICSharpCode.Core;
using Katrin.AppFramework;
using Katrin.AppFramework.Data;
using DevExpress.XtraLayout.Utils;

namespace Katrin.Win.ProjectTaskModule.Chart
{
    public partial class ProjectTaskChartView : Katrin.AppFramework.WinForms.Views.BaseView, IProjectTaskChartView
    {
        public event EventHandler<EventArgs<object,int,int>> OnStatusCodeChange;
        public event EventHandler<EventArgs<object>> OnEditItem;


        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int LockWindowUpdate(IntPtr hWnd);

        public void LockWindow()
        {
            LockWindowUpdate(this.Handle);
        }

        public void UnLockWindow()
        {
            LockWindowUpdate((IntPtr)0);
        }


        public ProjectTaskChartView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        public void InitEditors()
        {
            LockWindow();
            List<LookupListItem<int>> tagList = new List<LookupListItem<int>>();
            tagList.Add(new LookupListItem<int> { DisplayName = "NotStarted", Value = 1 });
            tagList.Add(new LookupListItem<int> { DisplayName = "InProgress", Value = 2 });
            tagList.Add(new LookupListItem<int> { DisplayName = "Completed", Value = 3 });
            tagList.Add(new LookupListItem<int> { DisplayName = "Acceptance", Value = 4 });
            Assembly asm = this.GetType().Assembly;
            Stream stream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "AddIns\\BoardColumn.xml", FileMode.Open);
            taskLookBoardByStage.CreateBoards(tagList, "StatusCode", stream);
            taskLookBoardByStage.OnStatusCodeChange += OnStatusCodeChange;
            taskLookBoardByStage.OnValidataStatus += OnValidataStatus;
            taskLookBoardByStage.OnCurrentChange += OnCurrentChange;
            taskLookBoardByStage.OnEditItem += OnEditItem;
            this.layoutControlItem3.Visibility = LayoutVisibility.Always;
            this.layoutControlItem2.Visibility = LayoutVisibility.Always;
            this.layoutControlItem1.Visibility = LayoutVisibility.Always;
            UnLockWindow();
        }

        void OnCurrentChange(object sender, EventArgs<object> e)
        {
            if (e.Data == null) return;
            int postion = 0;
            foreach (var item in taskFilterControl1.Context.BindingSource.ToArrayList())
            {
                var projectTask = ConvertData.Convert<Katrin.Domain.Impl.ProjectTask>(item);
                var boardProjectTask = ConvertData.Convert<Katrin.Domain.Impl.ProjectTask>(e.Data);
                if (projectTask.TaskId == boardProjectTask.TaskId)
                {
                    taskFilterControl1.Context.BindingSource.Position = postion;
                    break;
                }
                postion++;
            }
        }

        private bool OnValidataStatus(object obj,int toStatus)
        {
            var projectTask = ConvertData.Convert<Katrin.Domain.Impl.ProjectTask>(obj);
            if (projectTask.StatusCode > toStatus && toStatus == 1)
            {
                return false;
            }
            return true;
        }

        public void BindTaskData(BindingList<object> taskList)
        {
            taskLookBoardByStage.BoardDataList = taskList;
        }

        public IProejctTaskFilter TaskFilter
        {
            get { return this.taskFilterControl1; }
        }

        #region userless


        public DevExpress.XtraGrid.Views.Base.ColumnView ObjectGridView
        {
            get { throw new NotImplementedException(); }
        }

        public void BindListData(object listData)
        {
            throw new NotImplementedException();
        }

        public string ObjectName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public object SelectedObject
        {
            get { throw new NotImplementedException(); }
        }
        #endregion
    }
}
