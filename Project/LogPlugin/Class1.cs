using OSGi.NET.Core;
using OSGi.NET.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
namespace LogPlugin
{
    public class Class1 : IBundleActivator
    {
        private IServiceRegistration serviceRegistration;
        private Logger logger;

        public void Start(IBundleContext context)
        {
            LogService logService = new LogService();
            serviceRegistration = context.RegisterService<ILogService>(logService);
            logger = logService.GetLogger();
            logger.Debug("LogPlugin Started!");
        }

        public void Stop(IBundleContext context)
        {
            logger.Debug("LogPlugin Stopped!");
        }
    }
}
