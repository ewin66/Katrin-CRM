using System;
using System.Windows.Forms;
using Katrin.Win.Common.Constants;
using Katrin.Win.Common.Controls;
using Katrin.Win.Infrastructure;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Layout;
using Microsoft.Practices.CompositeUI;
using DevExpress.XtraGrid.Views.Base;
using Katrin.Win.Infrastructure.Services;
using DevExpress.XtraBars.Docking;
using System.IO;
using DevExpress.Utils.Serializing;
using Microsoft.Practices.CompositeUI.EventBroker;
using System.Xml.Serialization;
using System.Collections.Generic;
using DevExpress.Data.Filtering;
using Katrin.Win.WcfServerMode;
using System.Collections;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.Security;

namespace Katrin.Win.Common.Notification
{
    [SmartPart]
    public partial class NotificationList : RecordListView, INotificationList
    {
        private NotificationPresenter _presenter;
        public event EventHandler<EventArgs<object>> DeteleNotification;

        [CreateNew]
        public NotificationPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        public void SetNotificationFilter()
        {
            BinaryOperator theOperator = new BinaryOperator();
            theOperator.OperatorType = BinaryOperatorType.Equal;
            theOperator.LeftOperand = ConstantValue.Parse("RecipientId");
            theOperator.RightOperand = AuthorizationManager.CurrentUserId;
            Context.SetFilter("NotificationFilter", theOperator);
        }

        public void InitDeleteMenu()
        {
            RegisterPoupMenuItem("DeleteNotification", "Delete", notification =>
                {
                    if (DeteleNotification != null)
                        DeteleNotification(this, new EventArgs<object>(notification));
                });
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.TopPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.Size = new System.Drawing.Size(952, 29);
            // 
            // AttentionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Name = "NotificationList";
            this.Size = new System.Drawing.Size(952, 381);
            ((System.ComponentModel.ISupportInitialize)(this.TopPanel)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
