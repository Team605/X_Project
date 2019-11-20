using EventHandlePlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPlugin
{
    class DBEvent : Event
    {
        private EventMessage message;
        public DBEvent(EventMessage message)
        {
            this.message = message;
        }

        public override EventMessage getMessage()
        {
            return this.message;
        }
    }
}
