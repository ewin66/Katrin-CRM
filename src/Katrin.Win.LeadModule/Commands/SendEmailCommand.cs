using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.Core;
using Outlook = NetOffice.OutlookApi;
using NetOffice.OutlookApi.Enums;
using Katrin.Win.LeadModule.Detail;
namespace Katrin.Win.LeadModule.Commands
{
    public class SendEmailCommand : AbstractCommand
    {
        public override void Run()
        {
            try
            {
                if (!(this.Owner is LeadDetailController)) return;
                LeadDetailController leadPresenter = (LeadDetailController)this.Owner;
                LateBindingApi.Core.Factory.Initialize();
                Outlook.Application outlookApplication = new Outlook.Application();
                Outlook.MailItem KatrinEmal = outlookApplication.CreateItem(OlItemType.olMailItem) as Outlook.MailItem;
                object emailToObject = leadPresenter.ObjectEntity.GetType().GetProperty("EmailAddress").GetValue(leadPresenter.ObjectEntity, null);
                string emailTo = emailToObject == null ? string.Empty : emailToObject.ToString();
                if (!string.IsNullOrEmpty(emailTo))
                    KatrinEmal.Recipients.Add(emailTo);
                KatrinEmal.Importance = OlImportance.olImportanceNormal;
                KatrinEmal.Display();
            }
            catch (Exception ex)
            {
                MessageService.ShowException(ex, ResourceService.GetString("EmailExceptionTip"));
            }

        }
    }
}
