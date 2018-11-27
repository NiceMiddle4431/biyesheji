using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class T_Base_MajorClass
    {
        /// <summary>
        /// 获取指定学院的专业班级
        /// </summary>
        /// <param name="ArchitectureId"></param>
        /// <returns></returns>
        public List<Model.T_Base_MajorClass> GetAllMajorClass(int ArchitectureId)
        {
            return new DAL.T_Base_MajorClass().GetAllMajorClass(ArchitectureId);
        }


        /// <summary>
        /// 保存新增专业班级信息
        /// </summary>
        /// <param name="place"></param>
        /// <returns></returns>
        public int AddSaveMajorClass(Model.T_Base_MajorClass MajorClass)
        {
            return new DAL.T_Base_MajorClass().AddSaveMajorClass(MajorClass);
        }

        /// <summary>
        /// 获取指定Id的专业班级信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Model.T_Base_MajorClass GetMajorClass(int Id)
        {
            return new DAL.T_Base_MajorClass().GetMajorClass(Id);
        }

        /// <summary>
        /// 保存修改后的专业班级信息
        /// </summary>
        /// <param name="MajorClass"></param>
        /// <returns></returns>
        public int EditSaveMajorClass(Model.T_Base_MajorClass MajorClass)
        {
            return new DAL.T_Base_MajorClass().EditSaveMajorClass(MajorClass);
        }


        /// <summary>
        /// 删除专业班级
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Delete(string[] Ids)
        {
            //防止注入式漏洞
            string ids = string.Join(",", Ids);
            return new DAL.T_Base_MajorClass().Delete(ids);
        }
    }
}
