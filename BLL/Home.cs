using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Home
    {
        public int Check(string Num,string Password)
        {
            return new DAL.Home().Check(Num,Password);
        }

        public List<Model.T_Base_RoleMenu> GetRoleMenu(int RoleId)
        {
            return new DAL.Home().GetRoleMenu(RoleId);
        }

    }
}
