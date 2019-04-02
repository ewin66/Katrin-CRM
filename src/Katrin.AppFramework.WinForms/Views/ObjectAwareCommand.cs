using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.MVC;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Views
{
    public abstract class ObjectAwareCommand : AbstractCommand
    {
        public virtual object Owner
        {
            get
            {
                return base.Owner;
            }
            set
            {
                Guard.ObjectIsInstanceOfType(value, typeof(IObjectAware), "owner");
                base.Owner = value;
            }
        }

        protected IObjectAware Object
        {
            get
            {
                return (IObjectAware)Owner;
            }
        }
        

        protected void SendMessage(string itemName)
        {
            Guard.ArgumentNotNull(Object, "Owner");
            IController controller = this.Owner as IController;
           // var message = new UpdateRibbonItemMessage { ItemName = itemName, ObjectName = Object.ObjectName };
            var message = new UpdateRibbonItemMessage(controller.Context.WorkSpace.ID, Object.ObjectName,itemName);
           
            EventAggregationManager.SendMessage(message);
        }

    }
}
