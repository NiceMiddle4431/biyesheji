using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class T_Base_Resource
    {
        public List<Model.T_Base_Resource> GetAllResource(int LectureId)
        {
            return new DAL.T_Base_Resource().GetAllResource(LectureId);
        }

        public int Delete(string[] Ids)
        {
            //防止注入式漏洞
            string ids = string.Join(",", Ids);
            return new DAL.T_Base_Resource().Delete(ids);
        }

        public int AddSaveResource(Model.T_Base_Resource Resource)
        {
            return new DAL.T_Base_Resource().AddSaveResource(Resource);
        }
    }
}
