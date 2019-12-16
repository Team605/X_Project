using OSGi.NET.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogPlugin;
using NLog;
namespace CachePlugin
{

    public class Class1 : IBundleActivator
    {
        private ILogService logService;
        private ILogger logger;
        public void Start(IBundleContext context)
        {
            
            var serviceReference = context.GetServiceReference<ILogService>();
            logService = context.GetService<ILogService>(serviceReference);
            logger = logService.GetLogger();
            logger.Debug("CachePlugin Started!");
        }

        public void Stop(IBundleContext context)
        {

            logger.Debug("CachePlugin Stopped!");
        }
    }
}
