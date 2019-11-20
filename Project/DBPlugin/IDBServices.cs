using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelPlugin;

namespace DBPlugin
{
    
    public interface IDBServices
    {
        bool initDBServices();

        bool createOperation(Model model);

        bool deleteOperation(string sqlCommond);

        bool modifyOperation(string sqlCommond);

        object queryOperation(string sqlCommond);

        List<object> queryOperations(string sqlCommond);

        bool executeCommands(string sqlCommand);
    }
}
