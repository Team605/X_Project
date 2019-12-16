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
using TestPlugin2;
using System.Threading;

namespace TestPlugin
{
    class ListenerTest : IListener, IPublisher
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

        public Event getEvent(string from, object obj)
        {
            TestPluginEvent testPluginEvent = new TestPluginEvent();
            testPluginEvent.from = from;
            testPluginEvent.obj = obj;
            return testPluginEvent;
        }

        public void notify(Event e)
        {
            string from = e.from;
            if (from != null && from.Equals("DBPlugin"))
            {
                object obj = e.obj;                              
                logger.Info("recieve message from !" + from);
                post(getEvent("TestPlugin", obj));
            }
            
        }

        public void post(object o)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(eventService.postEvent));
            thread.Start(o);
        }
    }
}
