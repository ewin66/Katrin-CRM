using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Katrin.Win.Common.Controls;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.WinForms.MVC;
using DevExpress.Data.Filtering;
using Katrin.AppFramework.Security;
namespace Katrin.Win.Common.Notification
{
    public partial class SendSysNotification : XtraForm, ISendSysNotification, IView
    {

        //private SendSysNotificationPresenter _presenter;
        public event EventHandler OnSendSysMessage;

        //[CreateNew]
        //public SendSysNotificationPresenter Presenter
        //{
        //    set
        //    {
        //        _presenter = value;
        //        _presenter.View = this;
        //    }
        //}

        public SendSysNotification()
        {
            InitializeComponent();
            dxValidationProvider.SetValidationRule(ReceiverPopupContainerEdit, ValidationRules.IsNotBlankRule(ItemForReceiver.Text));
            dxValidationProvider.SetValidationRule(subjectEdit, ValidationRules.IsNotBlankRule(itemForSubject.Text));
       }

        public  bool ValidateData()
        {
            var result = dxValidationProvider.Validate();
            return result;
        }

        public void BindData(object dataSource)
        {
            EntityBindingSource.DataSource = dataSource;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;
            subjectEdit.Focus();
            if (OnSendSysMessage != null)
                OnSendSysMessage(this, new EventArgs());
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CloseView();
        }


        public void CloseView()
        {
            this.Close();
        }

        private void SendSysNotification_Load(object sender, EventArgs e)
        {
            this.FindForm().AcceptButton = saveButton;
            this.FindForm().CancelButton = cancelButton;
            ReceiverPopupContainerEdit.InitEdit("User", "Department", true, new BinaryOperator("UserId", AuthorizationManager.CurrentUserId, BinaryOperatorType.NotEqual));
            ReceiverPopupContainerEdit.DataBindings.Clear();
        }
        public List<Guid> GetReceiverList()
        {
            return ReceiverPopupContainerEdit.GetSelection();
        }

        public DevExpress.XtraBars.Ribbon.RibbonControl GetRibbon()
        {
            return null;
        }

        public IControllerManager ControllerManager
        {
            get;
            set;
        }

        public bool IsChildForm
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        public object Model
        {
            get;
            set;
        }

        public string ViewName
        {
            get;
            set;
        }

        public void BindDataToView()
        {

        }

        public void ShowView()
        {

        }

        public void HideView()
        {

        }


        public void ActiveView()
        {

        }

        public string ViewType
        {
            get;
            set;
        }


        public Guid WorkSpaceID
        {
            get;
            set;
        }


        public AppFramework.WinForms.Context.IWorkSpaceContext Context
        {
            get;
            set;
        }
    }
}
