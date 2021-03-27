using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace DataBaseService
{
    public class DbContext<T> where T : class, new()
    {
        public SqlSugarClient db_client;
        public SimpleClient<T> current_db
        {
            get
            {
                return new SimpleClient<T>(db_client);
            }
        }
        public DbContext()
        {
            db_client = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "server=127.0.0.1;user id=root;password=123456;database=test",
                DbType = DbType.MySql,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = true
            });
            db_client.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + db_client.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
        }
    }
}
