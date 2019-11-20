using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlePlugin
{
    public class EventMessage
    {
        private string eventName;

        public string EventName {
            get
            {
                return eventName;
            }
            set
            {
                eventName = value;
            }
        }

        private object MessageDetial { get; set; }
    }
}
