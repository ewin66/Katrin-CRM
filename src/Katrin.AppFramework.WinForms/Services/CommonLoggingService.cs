using Common.Logging;
using ICSharpCode.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Services
{
    class CommonLoggingService : ILoggingService
    {
        private static ILog log = LogManager.GetCurrentClassLogger();

        public void Debug(object message)
        {
            log.Debug(message);
        }

        public void DebugFormatted(string format, params object[] args)
        {
            log.DebugFormat(format, args);
        }

        public void Info(object message)
        {
            log.Info(message);
        }

        public void InfoFormatted(string format, params object[] args)
        {
            log.InfoFormat(format, args);
        }

        public void Warn(object message)
        {
            log.Warn(message);
        }

        public void Warn(object message, Exception exception)
        {
            log.Warn(message, exception);
        }

        public void WarnFormatted(string format, params object[] args)
        {
            log.WarnFormat(format, args);
        }

        public void Error(object message)
        {
            log.Error(message);
        }

        public void Error(object message, Exception exception)
        {
            log.Error(message, exception);
        }

        public void ErrorFormatted(string format, params object[] args)
        {
            log.ErrorFormat(format, args);
        }

        public void Fatal(object message)
        {
            log.Fatal(message);
        }

        public void Fatal(object message, Exception exception)
        {
            log.Fatal(message, exception);
        }

        public void FatalFormatted(string format, params object[] args)
        {
            log.FatalFormat(format, args);
        }

        public bool IsDebugEnabled
        {
            get { return log.IsDebugEnabled; }
        }

        public bool IsInfoEnabled
        {
            get { return log.IsInfoEnabled; }
        }

        public bool IsWarnEnabled
        {
            get { return log.IsWarnEnabled; }
        }

        public bool IsErrorEnabled
        {
            get { return log.IsErrorEnabled; }
        }

        public bool IsFatalEnabled
        {
            get { return log.IsFatalEnabled; }
        }
    }
}
