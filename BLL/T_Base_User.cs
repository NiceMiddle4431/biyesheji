using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class T_Base_User
    {

        /// <summary>
        /// 按查询信息给出分页学生信息
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageNumber"></param>
        /// <param name="StudentNum"></param>
        /// <param name="StudentName"></param>
        /// <param name="MajorClassName"></param>
        /// <returns></returns>
        public List<Model.T_Base_User> GetAllUser(int PageSize, int PageNumber,
            string Num, string Name, string MajorClassName)
        {
            return new DAL.T_Base_User().GetAllUser
                (PageSize,PageNumber,Num,Name,MajorClassName);
        }


        /// <summary>
        /// 获取学生总数
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return new DAL.T_Base_User().GetCount();
        }


        /// <summary>
        /// 获取全部专业班级
        /// </summary>
        /// <returns></returns>
        public List<Model.T_Base_MajorClass> GetMajorClass(int ArchitectureId)
        {
            return new DAL.T_Base_User().GetMajorClass(ArchitectureId);
        }

    }
}
