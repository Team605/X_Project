using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace LogPlugin
{
    class LogService : ILogService
    {
        private Logger logger;

        public LogService()
        {
            this.logger = LogManager.GetCurrentClassLogger();
        }

        public void Debug(string debugMessage)
        {
            
        }

        public void Error(string errorMessage)
        {
            
        }

        public Logger GetLogger()
        {
            return LogManager.GetCurrentClassLogger();         
        }

        public void Info(string infoMessage)
        {
            
        }

        public void Warn(string warnMessage)
        {
            
        }
    }
}
