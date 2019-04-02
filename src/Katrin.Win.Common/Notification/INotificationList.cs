using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Infrastructure;

namespace Katrin.Win.Common.Notification
{
    public interface INotificationList
    {
        void Bind(string entityName);
        void SetNotificationFilter();
        void InitEntityView(string entityName);
        void InitDeleteMenu();
        event EventHandler<EventArgs<object>> DeteleNotification;
    }
}
