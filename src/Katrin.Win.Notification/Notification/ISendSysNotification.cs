using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.Common.Notification
{
    public interface ISendSysNotification
    {
        event EventHandler OnSendSysMessage;
        void BindData(object dataSource);
        void CloseView();

        List<Guid> GetReceiverList();
    }
}
