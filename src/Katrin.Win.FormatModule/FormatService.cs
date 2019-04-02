using Katrin.AppFramework;
using Katrin.AppFramework.WinForms.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.FormatModule
{
    /// <summary>
    /// Format Service
    /// author:hecq
    /// date:2012-11-13
    /// </summary>
    class FormatService : IListener<FormatRequestMessage>,IModuleService
    {
        public FormatService()
        {
            EventAggregationManager.AddListener(this);
        }
        public void Handle(FormatRequestMessage message)
        {
            FormatCondition.FormatConditionController controller = new FormatCondition.FormatConditionController();
            controller.Handle(message);
        }

        public string moduleName
        {
            get
            {
                return "Format";
            }
          
        }
    }
}
