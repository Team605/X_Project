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
using System.Threading;

namespace TestPlugin2
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
            Test2PluginEvent test2PluginEvent = new Test2PluginEvent();
            test2PluginEvent.from = from;
            test2PluginEvent.obj = obj;
            return test2PluginEvent;
        }

        public void notify(Event e)
        {
            string from = e.from;           
            if (from != null && from.Equals("TestPlugin"))
            {
                logger.Info("recieve message!");
                Student student = e.obj as Student;
                
                Student _student = Student.CloneObject(student) as Student;
                _student.SAge = (int.Parse(_student.SAge) + 5).ToString();
                post(getEvent("TestPlugin2", _student));
            }
            
        }

        public void post(object o)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(eventService.postEvent));
            thread.Start(o);
        }
    }
}
