using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class T_Base_Lecture
    {/// <summary>
     /// 获取全部讲座信息
     /// </summary>
     /// <param name="ArchitectureId"></param>
     /// <returns></returns>
        public List<Model.T_Base_Apply> GetAllLecture(string ParamLecture, int PageSize, int PageNumber)
        {
            return new DAL.T_Base_Lecture().GetAllLecture(ParamLecture, PageSize,  PageNumber);
        }


        /// <summary>
        /// 获取数据库内记录总数
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return new DAL.T_Base_Lecture().GetCount();
        }



        /// <summary>
        /// 保存添加的讲座信息
        /// </summary>
        /// <param name="place"></param>
        /// <returns></returns>
        public int AddSaveLecture(string AddNum, Model.T_Base_Lecture Lecture, int AddPlaceId)
        {
            int result = 1;
            result = new DAL.T_Base_Lecture().AddSaveLecture(AddNum, Lecture, AddPlaceId);
            return result;
        }



        /// <summary>
        /// 获取指定id的讲座
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<Model.T_Base_Apply> GetLecture(int Id)
        {
            return new DAL.T_Base_Lecture().GetLecture(Id);
        }


        /// <summary>
        /// 保存修改后的信息
        /// </summary>
        /// <param name="Lecture"></param>
        /// <returns></returns>
        public int EditSaveLecture(Model.T_Base_Lecture Lecture)
        {
            return new DAL.T_Base_Lecture().EditSaveLecture(Lecture);
        }


        /// <summary>
        /// 删除讲座
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Delete(string[] Ids)
        {
            //防止注入式漏洞
            string ids = string.Join(",", Ids);
            return new DAL.T_Base_Lecture().Delete(ids);
        }

    }
}
