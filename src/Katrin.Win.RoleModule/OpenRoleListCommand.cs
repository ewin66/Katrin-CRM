using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.Win.RoleModule.Detail;
namespace Katrin.Win.RoleModule
{
    public class OpenRoleListCommand : AbstractCommand
    {
        public override void Run()
        {
            var message = new ShowScreenMessage("/Role/List", "Role");
            EventAggregationManager.SendMessage(message);
        }
    }
}
