using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBPlugin;
using LogPlugin;
using EventHandlePlugin;
using System.Threading;
using NLog;
using OSGi.NET.Core;

namespace BundleServicesProvider
{
    public class Class1: IBundleActivator
    {
        private IDBServices dBServices;
        private ILogService logService;
        private IEventService eventService;
        private ILogger logger;
        public void Start(IBundleContext context)
        {
            string fullName = typeof(IDBServices).Assembly.FullName;
            dBServices = (DBServices)context.GetService<IDBServices>();
            logService = context.GetService<ILogService>();
            eventService = context.GetService<IEventService>();
            //BunderServicesProvider.Context = context;
            BunderServicesProvider.DBServices = dBServices;
            BunderServicesProvider.LogService = logService;
            BunderServicesProvider.EventService = eventService;
            //BunderServicesProvider.TestString = "mihao";
            BunderServicesProvider instance = BunderServicesProvider.getInstance();
            instance.setDBServices(dBServices);
            instance.setEventService(eventService);
            instance.setLogServiecs(logService);
            logger = logService.GetLogger();

            logger.Info("BundleServicesProvider Started!");


        }



        public void Stop(IBundleContext context)
        {
            logger.Info("BundleServicesProvider Stopped!");
        }
    }
}
