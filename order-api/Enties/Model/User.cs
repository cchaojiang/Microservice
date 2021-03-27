using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enties
{
    [SugarTable("user")]
    public class User
    {
        [SugarColumn(IsPrimaryKey =true)]
        public string UserId { set; get; }
        public string UserName { set; get; }
        public int Age { set; get; }
    }
}
