using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SqlSugar;
using NLog;

namespace DBPlugin
{
    class DBManager<T> where T : class, new()
    {
        private static string jsonFilePath = @".\Bundles\DBPlugins\connection.json";
        private static StringBuilder SqlServerConnStringBuilder = new StringBuilder("");
        private static ILogger Logger = null;
        private SqlSugarClient db;

        public DBManager()
        {
            initDB();
        }

        public DBManager(ILogger logger)
        {
            Logger = logger;
        }

        public bool initDB()
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
                        SqlServerConnStringBuilder.Append("Data Source=").Append(url)
                                                  .Append("database=").Append(dataBase)
                                                  .Append("uid=").Append(user_id)
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
            catch (Exception e)
            {
                Logger.Error(e.ToString());
                return false;
            }

            return true;
        }


        //ILogger Logger { get; set; }

        SimpleClient<T> DB { get { return new SimpleClient<T>(db); } }

        // 创建
        public virtual bool Create(T t)
        {
            try
            {
                DB.Insert(t);
                return true;
            }
            catch(Exception e)
            {
                Logger.Error(e.ToString());
                return false;
            }
            
        }
        // 删除
        public virtual bool Delete(T t)
        {
            try
            {
                DB.Delete(t);
                return true;
            }
            catch(Exception e)
            {
                Logger.Error(e.ToString());
                return false;
            }
        }


        // 更新
        public virtual bool Update(T t)
        {
            try
            {
                DB.Update(t);
                return true;
            }
            catch(Exception e)
            {
                Logger.Error(e.ToString());
                return false;
            }
        }

        // 查询
        public virtual List<T> GetList()
        {
            return DB.GetList();
        }

        // 条件查询
    }
}
