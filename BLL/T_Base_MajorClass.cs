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
        /// 获取全部专业班级
        /// </summary>
        /// <param name="ArchitectureId"></param>
        /// <returns></returns>
        public List<Model.T_Base_MajorClass> GetAllMajorClass(int ArchitectureId)
        {
            return new DAL.T_Base_MajorClass().GetAllMajorClass(ArchitectureId);
        }


        /// <summary>
        /// 保存添加的专业班级
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
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.T_Base_MajorClass GetMajorClass(int id)
        {
            return new DAL.T_Base_MajorClass().GetMajorClass(id);
        }


        /// <summary>
        /// 保存修改后的信息
        /// </summary>
        /// <param name="Lecture"></param>
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

        public List<Model.T_Base_User> GetAllUser(int MajorClassId)
        {
            return new DAL.T_Base_MajorClass().GetAllUser(MajorClassId);
        }
    }
}
