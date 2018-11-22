using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class T_Base_Place
    {

        private SqlConnection SqlServerOpen()
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=212.64.18.220;uid=bysj;pwd=bysj;databass=bysj;";
            return co;
        }

        public List<Model.T_Base_Architecture> GetArchitecture()
        {
            List<Model.T_Base_Architecture> list = new List<Model.T_Base_Architecture>();



            return list;
        }

    }
}
