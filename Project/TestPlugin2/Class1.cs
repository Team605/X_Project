using DBPlugin;
using EventHandlePlugin;
using LogPlugin;
using NLog;
using OSGi.NET.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlugin2
{
    public class Class1:IBundleActivator
    {
        private IEventService eventService;
        private ILogService logService;
        private IDBServices dBServices;
        private ILogger logger;

        public void Start(IBundleContext context)
        {
            var eventServiceReference = context.GetServiceReference<IEventService>();
            eventService = context.GetService<IEventService>(eventServiceReference);

            var dbServiceReference = context.GetServiceReference<IDBServices>();
            dBServices = context.GetService<IDBServices>(dbServiceReference);

            var logServiceReference = context.GetServiceReference<ILogService>();
            logService = context.GetService<ILogService>(logServiceReference);
            logger = logService.GetLogger();
            ListenerTest listener = new ListenerTest(eventService, logService, dBServices);
            logger.Debug("TestPlugin2 Started!");
        }

        public void Stop(IBundleContext context)
        {
            logger.Debug("TestPlugin2 Stopped!");
        }
    }
}
