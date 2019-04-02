using Katrin.AppFramework.Data;
using Katrin.AppFramework.Services;
using Katrin.AppFramework.WinForms.Grid;
using ICSharpCode.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Services
{
    public class ServiceManager : ICSharpCode.Core.Services.ServiceManager
    {
        static ICSharpCode.Core.Services.ILoggingService loggingService = new CommonLoggingService();
        static ICSharpCode.Core.Services.IMessageService messageService = new WinFormMessageService();
        static INavigationService navigationService = new WinNavigationService();

        public override ILoggingService LoggingService
        {
            get { return loggingService; }
        }

        public override IMessageService MessageService
        {
            get { return messageService; }
        }

        public override object GetService(Type serviceType)
        {
            if (serviceType == typeof(ILoggingService))
                return loggingService;
            else if (serviceType == typeof(IMessageService))
                return messageService;
            else if (serviceType == typeof(INavigationService))
                return navigationService;
            else if (serviceType == typeof(IFieldProjectStrategy))
                return new ColumnFieldProjectStragegy();
            else
                throw new Exception("Service not Found :" + serviceType.ToString());
        }
    }
}
