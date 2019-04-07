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
        public List<Model.T_Base_Apply> GetAllLecture(string ParamLecture, int PageSize, int PageNumber,string State)
        {
            return new DAL.T_Base_Lecture().GetAllLecture(ParamLecture, PageSize,  PageNumber,State);
        }


        /// <summary>
        /// 获取数据库内记录总数
        /// </summary>
        /// <returns></returns>
        public int GetCount(string State)
        {
            return new DAL.T_Base_Lecture().GetCount(State);
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
        public List<Model.T_Base_Apply> GetLecture(int LectureId,int State)
        {
            return new DAL.T_Base_Lecture().GetLecture(LectureId, State);
        }


        /// <summary>
        /// 保存修改后的信息
        /// </summary>
        /// <param name="Lecture"></param>
        /// <returns></returns>
        public int EditSaveLecture(string EditNum, int EditApplyId, Model.T_Base_Lecture Lecture, int EditPlaceId)
        {
            return new DAL.T_Base_Lecture().EditSaveLecture(EditNum, EditApplyId, Lecture, EditPlaceId);
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


        public List<Model.T_Base_Apply> GetPersonalAllLecture(string Num)
        {
            return new DAL.T_Base_Lecture().GetPersonalAllLecture(Num);
        }


        public int Order(string Num, int LectureId)
        {
            return new DAL.T_Base_Lecture().Order(Num,LectureId);
        }


        /// <summary>
        /// 报名功能显示（报名，以报名，截止报名
        /// </summary>
        /// <param name="Num"></param>
        /// <param name="LectureId"></param>
        /// <returns></returns>
        public int OrderSelect(string Num, int LectureId)
        {
            return new DAL.T_Base_Lecture().OrderSelect(Num,LectureId);
        }


        public int OrderDelete(string Num, int LectureId)
        {
            return new DAL.T_Base_Lecture().OrderDelete(Num,LectureId);
        }
    }
}
