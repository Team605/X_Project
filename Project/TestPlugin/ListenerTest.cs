using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventHandlePlugin;
using LogPlugin;
using DBPlugin;
using ModelPlugin;
using NLog;
namespace TestPlugin
{
    class ListenerTest : IListener
    {
        private IEventService eventService;
        private ILogService logService;
        private IDBServices dBServices;
        private ILogger logger;

        public ListenerTest(IEventService eventService, ILogService logService, IDBServices dBServices)
        {
            this.eventService = eventService;
            this.logService = logService;
            this.dBServices = dBServices;
            logger = logService.GetLogger();
            eventService.registListener(this);
        }

        public void notify(Event e)
        {
            EventMessage message = e.getMessage();

            
            if (message != null)
            {
                logger.Info("recieve message!");
            }
            else
            {
                logger.Info("unable to recieve message!");
            }
        }
    }
}
