using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlePlugin
{
    class EventService : IEventService
    {
        List<IListener> listeners = new List<IListener>();

        // 分发事件给相应订阅者
        public void postEvent(Event e)
        {
            foreach(IListener listener in listeners)
            {
                listener.notify(e);
            }
        }

        public void registListener(IListener listener)
        {
            listeners.Add(listener);
        }

        public void removeListener(IListener listener)
        {
            listeners.Remove(listener);
        }


    }
}
