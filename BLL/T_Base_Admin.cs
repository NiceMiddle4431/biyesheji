using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class T_Base_Admin
    {
        public Model.T_Base_Admin GetAdmin(string Admin)
        {
            return new DAL.T_Base_Admin().GetAdmin(Admin);
        }
    }
}
