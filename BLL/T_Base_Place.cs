using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class T_Base_Place
    {
        
        /// <summary>
        /// 查询建筑内可举办讲座地点（Id,地点名称，容纳人数）
        /// </summary>
        /// <param name="ArchitectureId"></param>
        /// <returns></returns>
        public List<Model.T_Base_Place> GetPlace(int ArchitectureId)
        {
            List<Model.T_Base_Place> list = new DAL.T_Base_Place().GetPlace(ArchitectureId);
            return list;
        }



    }
}
