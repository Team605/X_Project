using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace LogPlugin
{
    public interface ILogService
    {
        Logger GetLogger();

        void Debug(string debugMessage);

        void Info(string infoMessage);

        void Error(string errorMessage);

        void Warn(string warnMessage);
    }

    
}
