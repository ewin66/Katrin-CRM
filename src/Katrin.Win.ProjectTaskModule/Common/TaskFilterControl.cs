using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.Utils;
using DevExpress.Utils;
using ICSharpCode.Core;
using Katrin.Win.ProjectTaskModule.Chart;
using Katrin.AppFramework.WinForms.Context;
using Katrin.AppFramework.ConfigService;
using DevExpress.Data.Filtering;

namespace Katrin.Win.ProjectTaskModule.Common
{
    public partial class TaskFilterControl : Katrin.AppFramework.WinForms.Views.BaseView, IProejctTaskFilter
    {
        private const string ProjectConfigId = "FilterProjectConfigId";
        private const string IterationConfigId = "FilterIterationConfigId";
        private const string MemberConfigId = "FilterMemberConfigId";
        IConfigService _config;
        public TaskFilterControl()
        {
            InitializeComponent();
            _config = new ConfigService();
            this.Disposed += TaskFilterControl_Closed;
        }

       

        public event EventHandler UpdateContextFilters;
        public event EventHandler<EventArgs<Guid?>> OnProjectChanged;
        public event EventHandler InitProjectTaskFilters;
        //public event EventHandler Closed;
        private IActionContext _context;
        public IActionContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new ActionContext();
                  
                              
                }
                return _context;
            }
            set
            {
                _context = value;
                
            }
        }
        private void ReadFilter()
        {
            if (string.IsNullOrEmpty(this.ObjectName))
            {
                throw new Exception("ObjectName is empty in filter");
            }
            CriteriaOperator projectOperator = CriteriaOperator.TryParse(_config.Get<string>(this.ObjectName + ProjectConfigId, null));
            CriteriaOperator iterationOperator = CriteriaOperator.TryParse(_config.Get<string>(this.ObjectName + IterationConfigId, null));
            CriteriaOperator memberOperator = CriteriaOperator.TryParse(_config.Get<string>(this.ObjectName + MemberConfigId, null));
            this.Context.SetFilter("ProjectId", projectOperator);
            Context.SetFilter("ProjectIterationId", iterationOperator);
            Context.SetFilter("MemberId", memberOperator);        
        }

        private void SaveFilter()
        {
            if (string.IsNullOrEmpty(this.ObjectName))
            {
                throw new Exception("ObjectName is empty in filter");
            }
            CriteriaOperator projectOperator = Context.GetFilter("ProjectId");
            CriteriaOperator iterationOperator = Context.GetFilter("ProjectIterationId");
            CriteriaOperator memberOperator = Context.GetFilter("MemberId");

            if (projectOperator != null)
                _config.Set<string>(projectOperator.ToString(), this.ObjectName + ProjectConfigId);
            if (iterationOperator != null)
                _config.Set<string>(iterationOperator.ToString(), this.ObjectName + IterationConfigId);
            if (memberOperator != null)
                _config.Set<string>(memberOperator.ToString(), this.ObjectName + MemberConfigId);
        }
        public void ReadFilterConfig()
        {
            this.ReadFilter();
        }
        void TaskFilterControl_Closed(object sender, EventArgs e)
        {

            this.SaveFilter();
        }

        public void BindData()
        {
            if (UpdateContextFilters != null) UpdateContextFilters(null, null);
        }

        private void BindLookUp(LookUpEdit lookUp, List<LookupListItem<Guid?>> dataSource)
        {
            lookUp.Properties.InitializeLookUpEdit(dataSource);
            lookUp.Properties.AllowNullInput = DefaultBoolean.True;
            lookUp.Properties.NullText = StringParser.Parse("${res:All}");
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
            if (OnProjectChanged != null) OnProjectChanged(this, new EventArgs<Guid?>(ProjectId));
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
            if (InitProjectTaskFilters != null) InitProjectTaskFilters(null, null);
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

        #region userless


        public DevExpress.XtraGrid.Views.Base.ColumnView ObjectGridView
        {
            get { return null; }
        }

        public void BindListData(object listData)
        {
            
        }

        public string ObjectName
        {
            get;
            set;
        }

        public object SelectedObject
        {
            get { return null; }
        }
        #endregion





       
    }
}
