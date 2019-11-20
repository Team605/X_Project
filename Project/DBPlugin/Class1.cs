using NLog;
using LogPlugin;
using OSGi.NET.Core;
using OSGi.NET.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventHandlePlugin;
namespace DBPlugin
{
    public class Class1 : IBundleActivator
    {
        private IServiceRegistration serviceRegistration;
        private ILogService logService;
        private IEventService eventService;
        private ILogger logger;        

        public void Start(IBundleContext context)
        {
            // 获取服务
            var logServiceReference = context.GetServiceReference<ILogService>();
            logService = context.GetService<ILogService>(logServiceReference);
            
            var eventServiceReference = context.GetServiceReference<IEventService>();
            eventService = context.GetService<IEventService>(eventServiceReference);

            logger = logService.GetLogger();

            // 注册服务
            serviceRegistration = context.RegisterService<IDBServices>(new DBServices(logService, eventService));

            logger.Debug("DBPlugin Started!");
        }

        public void Stop(IBundleContext context)
        {           
            logger.Debug("DBPlugin Stopped!");
        }
    }
}
