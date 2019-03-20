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
        /// 根据指定建筑Id获取学院专业
        /// </summary>
        /// <returns></returns>
        public List<Model.T_Base_MajorClass> GetMajorClass(int ArchitectureId)
        {
            return new DAL.T_Base_User().GetMajorClass(ArchitectureId);
        }


        /// <summary>
        /// 保存添加的用户信息
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public int AddSaveUser(Model.T_Base_User User)
        {
            return new DAL.T_Base_User().AddSaveUser(User);
        }


        /// <summary>
        /// 重置用户密码
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public int ResetPassword(int UserId)
        {
            return new DAL.T_Base_User().ResetPassword(UserId);
        }

        /// <summary>
        /// 获取指定Id的用户信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public Model.T_Base_User GetUser(int UserId)
        {
            return new DAL.T_Base_User().GetUser(UserId);
        }

        /// <summary>
        /// 保存修改后的用户信息
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public int EditSaveUser(Model.T_Base_User User)
        {
            return new DAL.T_Base_User().EditSaveUser(User);
        }

        /// <summary>
        /// 删除学生
        /// </summary>
        /// <returns></returns>
        public int Delete(string[] Ids)
        {
            //防止注入式漏洞
            string ids = string.Join(",", Ids);
            return new DAL.T_Base_User().Delete(ids);
        }


        //public Model.T_Base_User CheckUser(string LoginName,string Password)
        //{
        //    return new DAL.T_Base_User().CheckUser(LoginName, Password);
        //}

    }
}
