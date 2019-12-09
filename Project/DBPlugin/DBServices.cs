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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DBPlugin
{
    public class DBServices: IDBServices, IPublisher
    {
        private ILogService logService;
        private IEventService eventService;
        private static string jsonFilePath = @".\Bundles\DBPlugin\connection.json";
        private static StringBuilder SqlServerConnStringBuilder = new StringBuilder("");
        //private static string SqlServerConnString = @"Data Source=localhost;database=Test;uid=sa;pwd=zmy123456";
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

        //public bool Create<T>(T t)
        //{
        //    DBManager manager = new DBManager<t>();
        //    return manager.Create(t);
        //}

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
                post(getEvent("DBPlugin", model));
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
                using (System.IO.StreamReader file = System.IO.File.OpenText(jsonFilePath))
                {
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        JObject o = (JObject)JToken.ReadFrom(reader);
                        string url = o["url"].ToString();
                        string dataBase = o["data_base"].ToString();
                        string user_id = o["user_id"].ToString();
                        string password = o["password"].ToString();
                        SqlServerConnStringBuilder.Append("Data Source=").Append(url).Append(";")
                                                  .Append("database=").Append(dataBase).Append(";")
                                                  .Append("uid=").Append(user_id).Append(";")
                                                  .Append("pwd=").Append(password);
                    }
                }

                db = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = SqlServerConnStringBuilder.ToString(),
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
            catch(Exception e)
            {
                logger.Error(e.ToString());
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
