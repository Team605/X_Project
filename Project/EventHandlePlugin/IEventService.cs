using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlePlugin
{
    public interface IEventService
    {
        // 订阅服务
        void registListener(IListener listener);

        // 删除订阅者
        void removeListener(IListener listener);

        void postEvent(Event e);
    }
}
