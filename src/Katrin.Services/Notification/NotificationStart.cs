using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;

namespace Katrin.Services.Notification
{
    public class NotificationStart
    {
        public void RunJob()
        {
            StdSchedulerFactory scheduler = new StdSchedulerFactory();
            IScheduler sd = scheduler.GetScheduler();
            IJobDetail job = new JobDetailImpl("NotificationJob", "Jobs", typeof(NotificationJob));

            SimpleTriggerImpl trigger = new SimpleTriggerImpl("NofificationTrrigger");
            trigger.StartTimeUtc = SystemTime.UtcNow();
            trigger.EndTimeUtc = (null);
            trigger.RepeatCount = (SimpleTriggerImpl.RepeatIndefinitely);
            trigger.RepeatInterval = (TimeSpan.FromMinutes(1));
            sd.ScheduleJob(job, trigger);
            sd.Start();
        }

    }
}
