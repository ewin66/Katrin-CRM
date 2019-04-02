using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Workspaces;
using ICSharpCode.Core;

namespace Katrin.Win.NotificationModule.Commands
{
    public class SendMessageCommand : AbstractCommand
    {
        public override void Run()
        {
            var parameters = new ActionParameters(string.Empty, Guid.Empty, ViewShowType.Show);
            App.Instance.Invoke("NotificationDetail", "NotificationAction", parameters);
        }
    }
}
