using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelPlugin
{
    [SugarTable("student")]
    public class Student: Model
    {
        [SugarColumn(ColumnName = "sno")]
        public string Sno { get; set; }

        [SugarColumn(ColumnName = "sname")]
        public string SName { get; set; }

        [SugarColumn(ColumnName = "age")]
        public string SAge { get; set; }
    }
}
