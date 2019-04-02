using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katrin.AppFramework.Metadata;
using Katrin.AppFramework.MetadataServiceReference;
using Katrin.AppFramework.WinForms.Doozers;
using ICSharpCode.Core;

namespace Katrin.Win.TimeTrackingModule
{
    public class TimeTrackingDoozer : IDoozer
    {

        public bool HandleConditions
        {
            get
            {
                return true;
            }
        }

        public object BuildItem(BuildItemArgs args)
        {
            //string entityName = args.Codon.Properties["entityName"];

            string addinFileName = AppDomain.CurrentDomain.BaseDirectory + "AddIns\\" + "TimeTracking.AddIn";
            AddIn addin = AddIn.Load(addinFileName);

            ICSharpCode.Core.Properties properies = new ICSharpCode.Core.Properties();
            //properies.Set<string>("id", "TimeTracking");
            properies.Set<string>("label", "${res:TimeTracking}");
            properies.Set<string>("class", "Katrin.Win.TimeTrackingModule.TimeTracking.TimeTrackingListView");
            foreach (var codonPro in args.Codon.Properties.Elements)
            {
                if (codonPro == "label") continue;
                properies.Set<string>(codonPro, args.Codon.Properties[codonPro]);
            }
            Codon codon = new Codon(addin, "DockPanel", properies, args.Conditions.ToArray());
            return new DockPanelDescriptor(args.Caller, codon);
        }
    }
}
