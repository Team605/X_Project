using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBPlugin;
using LogPlugin;
using EventHandlePlugin;
using OSGi.NET.Core;

namespace BundleServicesProvider
{
    public class BunderServicesProvider
    {
        public static IBundleContext Context { set; get; }

        public static IDBServices DBServices { set; get; }

        public static ILogService LogService { set; get; }

        public static IEventService EventService { set; get; }

        public static string TestString { set; get; }

        private IDBServices dBServices;
        private ILogService logService;
        private IEventService eventService;
        public string testString = "";

        static BunderServicesProvider bunderServicesProvider = new BunderServicesProvider();

        public BunderServicesProvider()
        {
            Console.WriteLine("New BunderServicesProvider");
        }

        public static BunderServicesProvider getInstance()
        {
            return bunderServicesProvider;
        }

        public void setDBServices(IDBServices dBServices)
        {
            this.dBServices = dBServices;
        }

        public IDBServices getDBServices()
        {
            return dBServices;
        }

        public void setLogServiecs(ILogService logService)
        {
            this.logService = logService;
        }

        public ILogService getLogServices()
        {
            return logService;
        }

        public void setEventService(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public IEventService getEventService()
        {
            return eventService;
        }

        public void SetDBServices(ref IDBServices dBServices)
        {
            dBServices = this.dBServices;
        }

        public void SetLogServiecs(ref ILogService logService)
        {
            logService = this.logService;
        }

        public void SetEventService(ref IEventService eventService)
        {
            eventService = this.eventService;
        }
    }
}
