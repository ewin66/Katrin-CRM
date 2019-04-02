using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Infrastructure;

namespace Katrin.Win.Common.Notification
{
    public class NotificationPresenter : Presenter<INotificationList>
    {
        private string _entityName = "NotificationRecipient";
        protected override void OnViewSet()
        {
            base.OnViewSet();
            View.DeteleNotification += View_DeteleNotification;
            View.SetNotificationFilter();
            View.InitEntityView(_entityName);
            View.Bind(_entityName);
            View.InitDeleteMenu();
        }

        void View_DeteleNotification(object sender, EventArgs<object> e)
        {
            if (e.Data == null) return;
            DynamicDataServiceContext context = new DynamicDataServiceContext();
            context.DeleteObject(_entityName, e.Data);
            context.SaveChanges();
            View.Bind(_entityName);
        }
    }
}
