using ConsoleDemo;
using DBPlugin;
using EventHandlePlugin;
using LogPlugin;
using OSGi.NET.Core.Root;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    class TestCommands : ICommand
    {
        private IFramework framework;

        public IDBServices DBservice { get; set; }
        public IEventService EventService { get; set; }
        public ILogService LogService { get; set; }

        public TestCommands(IFramework framework)
        {
            this.framework = framework;
        }

        public string ExecuteCommand(string commandLine)
        {
            var context = framework.GetBundleContext();
            DBservice = context.GetService<IDBServices>();
            EventService = context.GetService<IEventService>();
            LogService = context.GetService<ILogService>();
            return "hello! Test";
        }

        public string GetCommandName()
        {
            return "test";
        }

        public string GetDetailHelpText()
        {
            return "TEST";
        }

        public string GetHelpText()
        {
            return "TEST";
        }
    }
}
