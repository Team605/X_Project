using EventHandlePlugin;
using LogPlugin;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelPlugin;
using NLog;

namespace DBPlugin
{
    [Serializable]
    public class DBServices: IDBServices, IPublisher
    {
        private ILogService logService;
        private IEventService eventService;
        private static string SqlServerConnString = @"Data Source=10.3.192.93;database=Test;uid=sa;pwd=zmy123456";
        private static string windowsServerConnString = @"Server=CUMT-A-506;Database=Test;Trusted_Connection=SSPI";
        private SqlSugarClient db;

        private ILogger logger;
        // 数据库是否连接
        private bool connected = true;
        public DBServices()
        {
            
        }

        public DBServices(ILogService logService, IEventService eventService)
        {
            this.logService = logService;
            this.eventService = eventService;
            logger = logService.GetLogger();
            if (!initDBServices())
            {
                logger.Warn("数据库连接失败！");
                connected = false;
            }
            
        }

        public bool createOperation(Model model)
        {
            if (connected == false)
            {
                return false;
            }
            try
            {
                // 数据库添加一条数据， 并告诉相关订阅者；
                Student student = model as Student;
                db.Insertable(student).ExecuteCommand();
                post(getEvent("DBPlugin", student));
            }
            catch (Exception e)
            {
                logger.Error(e);               
                return false;
            }
            
                return true;
        }
       


        public bool deleteOperation(string sqlCommond)
        {
            return false;
        }

        public bool executeCommands(string sqlCommand)
        {
            return false;
        }


        public bool modifyOperation(string sqlCommond)
        {
            return false;
        }

        public object queryOperation(string sqlCommond)
        {
            return null;
        }

        public List<object> queryOperations(string sqlCommond)
        {
            return null;
        }

        public bool initDBServices()
        {
            try
            {
                db = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = SqlServerConnString,
                    DbType = DbType.SqlServer,
                    IsAutoCloseConnection = true,
                    InitKeyType = InitKeyType.Attribute
                }
            );

                db.Aop.OnLogExecuting = (sql, pars) =>
                {
                    Console.WriteLine(sql + "\r\n" +
                    db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                    Console.WriteLine();
                };
            }
            catch
            {
                return false;
            }

            return true;
        }

        public void post(Event e) 
        {           
            eventService.postEvent(e);
        }

        public Event getEvent(string from, object obj)
        {
            DBEvent dBEvent = new DBEvent();
            dBEvent.from = from;
            dBEvent.obj = obj;
            return dBEvent;
        }
    }
}
