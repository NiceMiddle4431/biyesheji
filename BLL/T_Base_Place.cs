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
        public List<Model.T_Base_Place> GetAllPlace(int ArchitectureId)
        {
            List<Model.T_Base_Place> list = new DAL.T_Base_Place().GetAllPlace(ArchitectureId);
            return list;
        }

        /// <summary>
        /// 保存新增地点信息
        /// </summary>
        /// <param name="place"></param>
        /// <returns></returns>
        public int AddSavePlace(Model.T_Base_Place Place)
        {
            return new DAL.T_Base_Place().AddSavePlace(Place);
        }

        /// <summary>
        /// 获取指定Id的地点信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Model.T_Base_Place GetPlace(int Id)
        {
            return new DAL.T_Base_Place().GetPlace(Id);
        }

        /// <summary>
        /// 保存修改后的场地信息
        /// </summary>
        /// <param name="Place"></param>
        /// <returns></returns>
        public int EditSavePlace(Model.T_Base_Place Place)
        {
            return new DAL.T_Base_Place().EditSavePlace(Place);
        }


        /// <summary>
        /// 删除场地
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Delete(string[] Ids)
        {
            //防止注入式漏洞
            string ids = string.Join(",", Ids);
            return new DAL.T_Base_Place().Delete(ids);
        }

    }
}
