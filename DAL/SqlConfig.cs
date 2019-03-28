using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DAL
{
    public class SqlConfig
    {
        private SqlConnection co;
        private SqlCommand cmd;
        public SqlConfig()
        {
            co = new SqlConnection();
            co.ConnectionString = "server=212.64.18.220;uid=bysj;pwd=bysj;database=bysj";
            co.Open();
            cmd = new SqlCommand();
            cmd.Connection = co;
        }

        public SqlCommand getSqlCommand()
        {
            return cmd;
        }

        public SqlConnection getSqlConnection()
        {
            return co;
        }

        public void Close()
        {
            co.Close();
        }
    }
}
