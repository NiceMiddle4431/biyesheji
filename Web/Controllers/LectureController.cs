using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class LectureController : Controller
    {
        // GET: Lecture
        public ActionResult Index()
        {

            return View();
        }


        /// <summary>
        /// 获取全部讲座信息
        /// </summary>
        /// <param name="ArchitectureId"></param>
        /// <returns></returns>
        public JsonResult GetAllLecture(string ParamLecture,int PageSize,int PageNumber)
        {
            return Json(new {
                total = new BLL.T_Base_Lecture().GetCount() ,
                rows = new BLL.T_Base_Lecture().GetAllLecture(ParamLecture, PageSize, PageNumber)
                });
        }

        /// <summary>
        /// 保存添加的讲座信息
        /// </summary>
        /// <param name="AddLectureName"></param>
        /// <param name="AddArchitectureId"></param>
        /// <returns></returns>
        public JsonResult AddSaveLecture(string AddNum,string AddSubject,string AddSummary,
            DateTime AddLectureTime,DateTime AddDeathLine,float AddSpan,int AddExpectPeople,
            int AddArchitectureId,int AddPlaceId, decimal AddScore)
        {
            Model.T_Base_Lecture lecture = new Model.T_Base_Lecture();
            lecture.Subject = AddSubject;
            lecture.Summary = AddSummary;
            lecture.LectureTime = AddLectureTime;
            lecture.DeathLine = AddDeathLine;
            lecture.Span = AddSpan;
            lecture.ExpectPeople = AddExpectPeople;
            lecture.Score = AddScore;
            int result = new BLL.T_Base_Lecture().AddSaveLecture(AddNum,lecture,AddPlaceId);
            if (result != -1)
            {
                return Json("添加成功");
            }
            else
            {
                return Json("添加失败");
            }
        }


        /// <summary>
        /// 获取指定id的讲座
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult GetLecture(int Id)
        {
            return Json(new BLL.T_Base_Lecture().GetLecture(Id));
        }


        /// <summary>
        /// 保存修改后的信息
        /// </summary>
        /// <param name="AddLectureName"></param>
        /// <param name="AddPeopleNum"></param>
        /// <param name="AddArchitectureId"></param>
        /// <returns></returns>
        public JsonResult EditSaveLecture(int EditId)
        {
            Model.T_Base_Lecture lecture = new Model.T_Base_Lecture();
            lecture.Id = EditId;
            int result = new BLL.T_Base_Lecture().EditSaveLecture(lecture);
            if (result == 1)
            {
                return Json("修改成功");
            }
            else
            {
                return Json("修改失败");
            }
        }

        /// <summary>
        /// 删除讲座
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public JsonResult Delete(string[] Ids)
        {
            int result = new BLL.T_Base_Lecture().Delete(Ids);
            if (result <= 0)
            {
                return Json("删除失败");
            }
            else
            {
                return Json("删除" + result + "记录");
            }
        }

        //获取容纳人数
        public JsonResult GetRoomNum()
        {
            return Json(Model.Config.roomNum);
        }
        //获取持续时间
        public JsonResult GetSpanTime()
        {
            return Json(Model.Config.spanTime);
        }
        //获取讲座学分
        public JsonResult GetScore()
        {
            return Json(Model.Config.score);
        }
    }
}