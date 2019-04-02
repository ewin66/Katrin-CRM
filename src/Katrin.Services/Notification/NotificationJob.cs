using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace Katrin.Services.Notification
{
    public class NotificationJob:IJob
    {

        public void Execute(IJobExecutionContext context)
        {
            CreateNotification.StartCreateCommonAttention();
        }
    }
}
