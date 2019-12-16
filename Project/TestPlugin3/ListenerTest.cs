using DBPlugin;
using EventHandlePlugin;
using LogPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using ModelPlugin;
using System.Threading;

namespace TestPlugin3
{
    class ListenerTest: IListener, IPublisher
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
            Test3PluginEvent test3PluginEvent = new Test3PluginEvent();
            test3PluginEvent.from = from;
            test3PluginEvent.obj = obj;
            return test3PluginEvent;
        }

        public void notify(Event e)
        {
            string from = e.from;
            if (from != null && from.Equals("TestPlugin"))
            {
                logger.Info("recieve message!");
                Student student = e.obj as Student;
                // 每次进行进行传播， 并且需要修改事件中的数据时进行克隆
                Student _student = Student.CloneObject(student) as Student;
                _student.SAge = (int.Parse(_student.SAge) + 5).ToString();
                post(getEvent("TestPlugin3", _student));
            }

        }

        public void post(object o)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(eventService.postEvent));            
            thread.Start(o);
        }
    }
}
