using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class T_Base_Architecture
    {
        /// <summary>
        /// 获取全部建筑
        /// </summary>
        /// <returns></returns>
        public List<Model.T_Base_Architecture> GetAllArchitecture()
        {
            List<Model.T_Base_Architecture> list = new DAL.T_Base_Architecture().GetAllArchitecture();
            return list;
        }

        /// <summary>
        /// 保存新增地点信息
        /// </summary>
        /// <param name="Architecture"></param>
        /// <returns></returns>
        public int AddSaveArchitecture(Model.T_Base_Architecture Architecture)
        {
            return new DAL.T_Base_Architecture().AddSaveArchitecture(Architecture);
        }

        /// <summary>
        /// 根据Id获取指定建筑信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Model.T_Base_Architecture GetArchitecture(int Id)
        {
            return new DAL.T_Base_Architecture().GetArchitecture(Id);
        }


        /// <summary>
        /// 保存修改后建筑的信息
        /// </summary>
        /// <param name="Architecture"></param>
        /// <returns></returns>
        public int EditSaveArchitecture(Model.T_Base_Architecture Architecture)
        {
            return new DAL.T_Base_Architecture().EditSaveArchitecture(Architecture);
        }


    }
}
