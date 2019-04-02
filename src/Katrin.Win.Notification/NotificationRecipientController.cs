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
using System.Linq.Dynamic;
using System.Text;
using Katrin.AppFramework.Security;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using DevExpress.Utils;
using System.Data.Services.Client;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Katrin.AppFramework.WinForms.Workspaces;
using ICSharpCode.Core;
using DevExpress.XtraEditors;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.Win.Common.Notification;
using System.Threading;
namespace Katrin.Win.NotificationModule
{
    public class NotificationRecipientController : ListController
    {
        private CriteriaOperator _objectTypeFilter { get; set; }
        private string _objectTypeName { get; set; }
        FilterControl filterControl = null;
        public NotificationRecipientController()
        {
            BinaryOperator theOperator = new BinaryOperator();
            theOperator.OperatorType = BinaryOperatorType.Equal;
            theOperator.LeftOperand = ConstantValue.Parse("RecipientId");
            theOperator.RightOperand = AuthorizationManager.CurrentUserId;
            FixedFilter = theOperator;
            ObjectName = "Notification";
        }

        public override IActionResult Execute(ActionParameters parameters)
        {
            var result = base.Execute(parameters);
            InitNotificationState();
            return result;
        }

        private void InitNotificationState()
        {
            if (!(_listView.ObjectGridView is GridView)) return;
            GridView gridView = (GridView)_listView.ObjectGridView;
            var listView = (Katrin.Win.ListViewModule.ListViews.ListView)_listView;
           
            listView.Load += (sender, e) =>
                {
                    ImageList columnImageList = new ImageList();
                    columnImageList.Images.Add(WinFormsResourceService.GetBitmap("readcol"));
                    columnImageList.Images.Add(WinFormsResourceService.GetBitmap("readcol"));
                    columnImageList.Images.SetKeyName(0, "");
                    columnImageList.Images.SetKeyName(1, "");
                    gridView.Images = columnImageList;
                    listView.DoubleClickCommand = null;
                    foreach (GridColumn column in gridView.Columns)
                    {
                        if (column.FieldName == "NotificationStatus")
                        {
                            RepositoryItemImageComboBox imgCombox = new RepositoryItemImageComboBox();
                            ImageList imageList = new ImageList();
                            imageList.Images.Add(WinFormsResourceService.GetBitmap("notificationreaded"));
                            imageList.Images.Add(WinFormsResourceService.GetBitmap("notification"));
                            imageList.Images.SetKeyName(0, "");
                            imageList.Images.SetKeyName(1, "");
                            imgCombox.SmallImages = imageList;
                            ImageComboBoxItem boxItem = new ImageComboBoxItem();
                            boxItem.Value = 0;
                            boxItem.ImageIndex = 0;
                            imgCombox.Items.Add(boxItem);
                            ImageComboBoxItem boxItem2 = new ImageComboBoxItem();
                            boxItem2.Value = 1;
                            boxItem2.ImageIndex = 1;
                            imgCombox.Items.Add(boxItem2);
                            column.ColumnEdit = imgCombox;
                        }
                        else if (column.FieldName == "CreatedOn")
                        {
                            column.DisplayFormat.FormatType = FormatType.DateTime;
                            column.DisplayFormat.FormatString = "yyyy/M/d (dddd) HH:mm";
                        }
                    }
                    gridView.OptionsBehavior.AutoExpandAllGroups = true;
                    
                    Thread tread = new Thread(LoadData);
                    tread.Start();
                };
            
            gridView.DoubleClick += gridView_DoubleClick;
            AuthorizationManager.NotificationList.DataSourceChanged -= NotificationList_DataSourceChanged;
            AuthorizationManager.NotificationList.DataSourceChanged += NotificationList_DataSourceChanged; 
        }

        private void LoadData()
        {
            ReceiveNotification.timer_Elapsed(null, null);
        }

        void filterControl_OnObjectFilterChange(object sender, AppFramework.Utils.EventArgs<string,string> e)
        {
            _objectTypeFilter = CriteriaOperator.TryParse(e.Data1);
            _objectTypeName = e.Data2;
            SetFilter();
        }

        void NotificationList_DataSourceChanged(object sender, EventArgs e)
        {
            GridView gridView = (GridView)_listView.ObjectGridView;
            
            AuthorizationManager.NotificationList.DataSourceChanged -= NotificationList_DataSourceChanged; 
            if (_listView == null) return;
            
            if (gridView.GridControl == null) return;
            ReBindListDataDelegate d = new ReBindListDataDelegate(ReBindListData);
            gridView.GridControl.Invoke(d);
            AuthorizationManager.NotificationList.DataSourceChanged += NotificationList_DataSourceChanged; 
        }

        private delegate void ReBindListDataDelegate();
        private void ReBindListData()
        {
            if (_listView is XtraUserControl && filterControl == null)
            {
                var listControl = _listView as XtraUserControl;
                filterControl = new FilterControl();
                filterControl.Dock = DockStyle.Left;
                filterControl.OnObjectFilterChange -= filterControl_OnObjectFilterChange;
                filterControl.OnObjectFilterChange += filterControl_OnObjectFilterChange;
                listControl.Controls.Add(filterControl);
            }
            if (!(_listView.ObjectGridView is GridView)) return;
            GridView gridView = (GridView)_listView.ObjectGridView;
            if (filterControl != null) filterControl.InitData(_objectTypeName);
            BindingSource targetData = (BindingSource)gridView.GridControl.DataSource;
            var sourceList = (List<NotificationDTO>)((ODataListSource)GetListData()).DataSource;
            if (((ODataListSource)targetData.DataSource).DataSource == null)
            {
                ((ODataListSource)targetData.DataSource).DataSource = sourceList;
                return;
            }
            var targetList = (List<NotificationDTO>)((ODataListSource)targetData.DataSource).DataSource;
            bool refresh = false;
            var addList = sourceList.Where(c => !targetList.Select(d => d.NotificationRecipientId).Contains(c.NotificationRecipientId));
            if (addList.Count() > 0)
            {
                targetList.AddRange(addList);
                refresh = true;
            }
            var removeList = targetList.Where(c => !sourceList.Select(d => d.NotificationRecipientId).Contains(c.NotificationRecipientId)).ToList();

            for (int i = 0; i < removeList.Count(); i++)
            {
                targetList.Remove(removeList[i]);
                refresh = true;
            }
            if (refresh)
            {
                gridView.RefreshData();
            }
        }

        void gridView_DoubleClick(object sender, EventArgs e)
        {
            if (_listView.SelectedObject == null) return;
            if (ObjectGridView is GridView)
            {
                var mPoint = ObjectGridView.GridControl.PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
                if (((GridView)ObjectGridView).CalcHitInfo(mPoint).RowHandle < 0) return;
                if (!((GridView)ObjectGridView).CalcHitInfo(mPoint).InRow)
                    return;
            }
            SetReaded(true);

            NotificationDTO data = (NotificationDTO)_listView.SelectedObject;
            if (data.NotificationUrl == null) return;
            if (string.IsNullOrEmpty(data.NotificationUrl)) return;
            string[] notificationInfo = data.NotificationUrl.Split(new char[] { '#' });
            string relationObjectName = notificationInfo[0];
            Guid relationOjectId = Guid.Parse(notificationInfo[1]);
            var relationEntity = _objectSpace.GetOrNew(relationObjectName, relationOjectId, null);
            if (relationEntity == null)
            {
                XtraMessageBox.Show(ResourceService.GetString("DataDeletedTip"),
                            ResourceService.GetString("Katrin"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                return;
            }
            ActionParameters parameters = new ActionParameters(relationObjectName, relationOjectId, ViewShowType.Show)
                    {
                        {"WorkingMode",EntityDetailWorkingMode.View}
                    };
            App.Instance.Invoke(notificationInfo[0], "Detail", parameters);
        }

        public void SetReaded(bool isDoubleClick)
        {
            NotificationDTO data = (NotificationDTO)_listView.SelectedObject;
            var notificationUser = (Katrin.Domain.Impl.NotificationRecipient)_objectSpace.GetOrNew("NotificationRecipient", data.NotificationRecipientId, null);
            if (data.NotificationStatusName != "Readed")
            {
                notificationUser.NotificationStatus = "Readed";
                notificationUser.ReadedOn = DateTime.Now;
                _objectSpace.SaveChanges();
                data.NotificationStatus = 0;
                data.NotificationStatusName = "Readed";
                GridView gridView = (GridView)_listView.ObjectGridView;
                gridView.LayoutChanged();
                ReceiveNotification.timer_Elapsed(null, null);
            }
            else if(!isDoubleClick)
            {
                notificationUser.NotificationStatus = "Opened";
                notificationUser.ReadedOn = DateTime.Now;
                _objectSpace.SaveChanges();
                data.NotificationStatus = 1;
                data.NotificationStatusName = "Opened";
                GridView gridView = (GridView)_listView.ObjectGridView;
                gridView.LayoutChanged();
                ReceiveNotification.timer_Elapsed(null, null);
            }
            
        }

        public void ClearAllData(bool isClearAll)
        {
            GridView gridView = (GridView)_listView.ObjectGridView;
            if (isClearAll)
            {
                string message = ResourceService.GetString("ClearNotificationConfirm");
                var result = XtraMessageBox.Show(message, StringParser.Parse("Katrin"), MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {
                    var list = ((BindingSource)gridView.GridControl.DataSource).List;
                    foreach (var item in list)
                    {
                        DeleteOneItem((NotificationDTO)item);
                    }
                    ((BindingSource)gridView.GridControl.DataSource).Clear();
                    _objectSpace.SaveChanges();
                }
            }
            else
            {
                bool result = MessageService.AskQuestion(ResourceService.GetString("DeleteItemTip"));
                if (result)
                {
                    var deleteRow = _listView.SelectedObject;

                    gridView.DeleteSelectedRows();
                    AuthorizationManager.NotificationList.Remove(deleteRow);
                    DeleteOneItem((NotificationDTO)deleteRow);
                    _objectSpace.SaveChanges();
                }
            }
            
        }

        private void DeleteOneItem(NotificationDTO notification)
        {
            var recipent = _objectSpace.GetOrNew("NotificationRecipient", notification.NotificationRecipientId, null);
            if (recipent == null) return;
            _objectSpace.DeleteObject("NotificationRecipient", recipent);
        }


        private void SetFilter()
        {
            GridView gridView = (GridView)_listView.ObjectGridView;
            CriteriaOperator queryFilter = _queryFilter;
            if ((object)queryFilter != null && (object)_objectTypeFilter != null)
                queryFilter &= _objectTypeFilter;
            else if ((object)_objectTypeFilter != null)
                queryFilter = _objectTypeFilter;
            if ((object)queryFilter != null)
            {
                gridView.ActiveFilterString = queryFilter.LegacyToString();
            }
            else
            {
                gridView.ActiveFilterString = string.Empty;
            }
        }

        protected override object GetListData()
        {
            if (filterControl == null) return new ODataListSource();
            List<NotificationDTO> arrData = new List<NotificationDTO>() ; 
            foreach(var item  in AuthorizationManager.NotificationList.List)
            {
                arrData.Add((NotificationDTO)item);
            }
            arrData = arrData.AsQueryable().OrderBy("CreatedOn desc").ToList();
            ODataListSource dataSource = new ODataListSource();
            dataSource.DataSource = arrData;
            SetFilter();
            return dataSource;
        }
    }
}
