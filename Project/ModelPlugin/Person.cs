using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelPlugin
{
    // 测试实体
    [SugarTable("Person")]
    public class Person: Model
    {
        [SugarColumn(ColumnName = "age")]
        public int Age { get; set; }

        [SugarColumn(ColumnName = "name")]
        public string name { get; set; }
    }
}
