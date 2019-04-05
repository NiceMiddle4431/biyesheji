using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class T_Base_Admin
    {
        public Model.T_Base_Admin GetAdmin(string Admin)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            Model.T_Base_Admin admin = new Model.T_Base_Admin();
            cmd.CommandText = "select * from T_Base_Admin where Admin = "+ Admin;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            admin.Id = Convert.ToInt32(reader["Id"]);
            admin.Admin = Convert.ToString(reader["Admin"]);
            admin.PassWord = Convert.ToString(reader["PassWord"]);
            admin.Role = Convert.ToInt32(reader["Role"]);
            config.Close();
            return admin;
        }
    }
}
