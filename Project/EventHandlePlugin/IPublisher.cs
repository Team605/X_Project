using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlePlugin
{
    // 事件发布接口
    public interface IPublisher
    {
        Event getEvent(string from, object obj);

        void post(Event e);
    }
}
