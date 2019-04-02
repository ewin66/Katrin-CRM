using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Grid;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Views;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Base;
using ICSharpCode.Core;
using Katrin.AppFramework.WinForms.Workspaces;
using System.Windows.Forms;
using Katrin.AppFramework.WinForms.Doozers;
using DevExpress.XtraBars.Docking;
using DevExpress.Data.Filtering;
using System.Threading;
using Katrin.AppFramework.WinForms.Controls;

namespace Katrin.AppFramework.WinForms.Controller
{
    public class ListController : ObjectController, IListener<ObjectSetChangedMessage>,IListener<FilterChangedMessage>
    {
        protected IObjectListView _listView;
        protected CriteriaOperator FixedFilter { get; set; }
        protected CriteriaOperator _queryFilter { get; set; }

        public ListController()
        {
            EventAggregationManager.AddListener(this);
        }

        public override IActionResult Execute(ActionParameters parameters)
        {
            if (parameters.ContainsKey("FixedFilter"))
            {
                var filter = parameters.Get<CriteriaOperator>("FixedFilter");
                SetFixedFilter(filter);
            }
            _listView = CreateListView("DefaultListView");
            _listView.ObjectName = ObjectName;
            BindListData();
            var result = new PartialViewResult();
            result.View = _listView;
            return result;
        }

        protected void SetFixedFilter(CriteriaOperator fixedFilter)
        {
            if((object)FixedFilter == null)  FixedFilter = fixedFilter;
            else FixedFilter = FixedFilter & fixedFilter;
        }

        protected IObjectListView CreateListView(string viewName)
        {
            var listView = ViewFactory.CreateView(viewName) as IObjectListView;
            var viewDescripto = ViewFactory.GetDescriptor(viewName);
            string doubleClick = viewDescripto.Codon.Properties["DoubleClick"];
            if (!string.IsNullOrEmpty(doubleClick))
            {
                listView.DoubleClickCommand = (ICommand)viewDescripto.Codon.AddIn.CreateObject(doubleClick);
                listView.DoubleClickCommand.Owner = this;
            }
            listView.ObjectName = ObjectName;
            listView.ControllerId = ControllerId;
            return listView;
        }

        protected virtual void BindListData()
        {
            if (_listView != null)
            {
                var dataSource = GetListData();
                _listView.BindListData(dataSource);
            }
        }

        protected virtual object GetListData()
        {
            var filter = _queryFilter & FixedFilter;
            var dataSource = new ODataListSource(ObjectName, filter, IncludingPath);
            dataSource.AsyncRefreshDataSource();
          
            return dataSource;
        }

        #region Ribbon Enabled Valid

        protected virtual List<string> IncludingPath
        {
            get { return null; }
        }
        public bool RibbonEnabledValid()
        {
            bool initSatus = _listView.ObjectGridView.DataSource == null;// && _entityListView.Context.BindingSource.ToArrayList().Count > 0;
            initSatus = initSatus || (_listView.SelectedObject != null && ObjectGridView.RowCount != 0);
            return initSatus;
        }
        #endregion

        #region commands

        public virtual bool Delete()
        {
            bool result = MessageService.AskQuestion(ResourceService.GetString("LikeToDelete") + ResourceService.GetString(ObjectName) + ResourceService.GetString("QuestionMark"));
            if (result)
            {               
                _objectSpace.DeleteObject(ObjectName, _listView.SelectedObject);
                _objectSpace.SaveChanges();
                BindListData();
            }
            return result;
        }

        public virtual void ImportData()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.xls|*.xls|*.xlsx|*.xlsx";
            var dialogResult =  saveFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                if (saveFileDialog.FileName.EndsWith(".xls"))
                    _listView.ObjectGridView.ExportToXls(saveFileDialog.FileName);
                else if(saveFileDialog.FileName.EndsWith(".xlsx"))
                    _listView.ObjectGridView.ExportToXlsx(saveFileDialog.FileName);
            }
        }

        #endregion

        #region  Fetch View Info

        public override object SelectedObject
        {
            get { return _listView.SelectedObject; }
        }

        public ColumnView ObjectGridView
        {
            get { return _listView.ObjectGridView; }
        }

        #endregion

        public virtual void OnRecevieObjectSetChanged(ObjectSetChangedMessage message)
        {

        }
        public virtual bool CanRefresh(ObjectSetChangedMessage message)
        {
            return true;
        }
        void IListener<ObjectSetChangedMessage>.Handle(ObjectSetChangedMessage message)
        {
            //Update child class for project basecontroller.
            this.OnRecevieObjectSetChanged(message);
            //update main list.
            bool canRun = false;
            if (message.WorkSpaceID == Guid.Empty )
            {
                if(message.ObjectName == this.ObjectName)
                {
                    canRun = true;
                }
            }
            else if (message.WorkSpaceID == this.WorkSpaceID)
            {
                canRun = true;
            }            
            if (!canRun) return;
            if (!CanRefresh(message)) return;       
            BindListData();            
            
        }

        void IListener<FilterChangedMessage>.Handle(FilterChangedMessage message)
        {
            if (message.ObjectName == ObjectName)
            {
                _queryFilter = message.Filter;
                BindListData();
            }
        }

       
    }
}
