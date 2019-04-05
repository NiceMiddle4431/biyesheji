using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class Home
    {
        public int Check(string Num, string Password)
        {
            int result = -1;
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select count(1) from T_Base_User where Num = '" +
                Num + "' and Password = '" + Password + "'";
            result = (int)cmd.ExecuteScalar();
            if(result == 1)
            {
                config.Close();
                return -2;          //普通学生
            }
            cmd.CommandText = "select count(1) from T_Base_Admin where Admin = '" +
                Num + "' and Password = '" + Password + "'";
            result = (int)cmd.ExecuteScalar();
            if (result == 1)
            {
                config.Close(); 
                return -3;          //管理员
            }
            return result;
        }

        public List<Model.T_Base_RoleMenu> GetRoleMenu(int RoleId)
        {
            List<Model.T_Base_RoleMenu> list = new List<Model.T_Base_RoleMenu>();
            SqlConfig config = new DAL.SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select * from V_RoleMenu where RoleId = " + RoleId;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Model.T_Base_RoleMenu roleMenu = new Model.T_Base_RoleMenu();
                roleMenu.Id = Convert.ToInt32(reader["Id"]);
                roleMenu.RoleId = Convert.ToInt32(reader["RoleId"]);
                roleMenu.RoleName = Convert.ToString(reader["RoleName"]);
                roleMenu.Memo = Convert.ToString(reader["Memo"]);
                roleMenu.MenuId = Convert.ToInt32(reader["MenuId"]);
                roleMenu.Controller = Convert.ToString(reader["Controller"]);
                roleMenu.Action = Convert.ToString(reader["Action"]);
                roleMenu.Display = Convert.ToString(reader["Display"]);
                list.Add(roleMenu);
            }
            config.Close();
            return list;
        }
    }
}
