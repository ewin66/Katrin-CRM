using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeUI.SmartParts;
using Katrin.Win.Common.Constants;
using Katrin.Win.Common.Core;

namespace Katrin.Win.MainModule
{
    public class MainModuleInit : ModuleInit
    {
        private readonly WorkItem workItem;

        [InjectionConstructor]
        public MainModuleInit([ServiceDependency] WorkItem workItem)
        {
            this.workItem = workItem;
        }

        public override void AddServices()
        {
            workItem.Services.Add<ISingleWorkItemService>(new SingleWorkItemService());
            base.AddServices();
        }

        public override void Load()
        {
            //Retrieve well known workspaces
            IWorkspace navbarWorkspace = workItem.Workspaces[WorkspaceNames.ShellNavBarWorkspace];
            IWorkspace contentWorkspace = workItem.Workspaces[WorkspaceNames.ShellContentWorkspace];

            MainWorkItem bankTellerWorkItem = workItem.WorkItems.AddNew<MainWorkItem>();
            bankTellerWorkItem.Show(navbarWorkspace, contentWorkspace);

            //IWorkspace dockWorkspace = workItem.Workspaces[WorkspaceNames.DockManagerWorkspace];
            //bankTellerWorkItem.Show(dockWorkspace);
        }
    }
}
