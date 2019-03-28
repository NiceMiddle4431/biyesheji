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
        public JsonResult GetAllLecture(string ParamLecture, int PageSize, int PageNumber)
        {
            return Json(new
            {
                total = new BLL.T_Base_Lecture().GetCount(" = 1"),
                rows = new BLL.T_Base_Lecture().GetAllLecture(ParamLecture, PageSize, PageNumber, " = 1")
            });
        }

        /// <summary>
        /// 保存添加的讲座信息
        /// </summary>
        /// <param name="AddLectureName"></param>
        /// <param name="AddArchitectureId"></param>
        /// <returns></returns>
        public JsonResult AddSaveLecture(string AddNum, string AddSubject, string AddSummary,
            DateTime AddLectureTime, DateTime AddDeathLine, float AddSpan, int AddExpectPeople,
            int AddArchitectureId, int AddPlaceId, double AddScore)
        {
            Model.T_Base_Lecture lecture = new Model.T_Base_Lecture();
            lecture.Subject = AddSubject;
            lecture.Summary = AddSummary;
            lecture.LectureTime = AddLectureTime;
            lecture.DeathLine = AddDeathLine;
            lecture.Span = AddSpan;
            lecture.ExpectPeople = AddExpectPeople;
            lecture.Score = AddScore;
            int result = new BLL.T_Base_Lecture().AddSaveLecture(AddNum, lecture, AddPlaceId);
            if (result > -1)
            {
                return Json("添加成功");
            }
            else if (result == -1)
            {
                return Json("添加失败");
            }
            else if (result == -2)
            {
                return Json("该时间段内存在其他讲座");
            }
            else
            {
                return Json("请联系管理员上报错误");
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

        /// <summary>
        /// 获取配置值
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public JsonResult GetConfig(string Name)
        {
            if (Name == "RoomNum")
            {
                return Json(Model.Config.roomNum);
            }
            else if (Name == "SpanTime")
            {
                return Json(Model.Config.spanTime);
            }
            else if (Name == "Score")
            {
                return Json(Model.Config.score);
            }
            else
            {
                return Json("初始值未设定，请联系管理员设定初值");
            }

        }

        /// <summary>
        /// 个人申请讲座管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Personal()
        {
            return View();
        }

        /// <summary>
        /// 获取个人申请的全部讲座信息
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        public JsonResult GetPersonalAllLecture(string Num)
        {
            return Json(new BLL.T_Base_Lecture().GetPersonalAllLecture(Num));
        }

        /// <summary>
        /// 保存修改后的信息
        /// </summary>
        /// <param name="EditNum"></param>
        /// <param name="EditId"></param>
        /// <param name="EditSubject"></param>
        /// <param name="EditSummary"></param>
        /// <param name="EditLectureTime"></param>
        /// <param name="EditDeathLine"></param>
        /// <param name="EditSpan"></param>
        /// <param name="EditExpectPeople"></param>
        /// <param name="EditArchitectureId"></param>
        /// <param name="EditPlaceId"></param>
        /// <param name="EditScore"></param>
        /// <returns></returns>
        public JsonResult EditSaveLecture(string EditNum, int EditApplyId,int EditLectureId, string EditSubject, string EditSummary,
            DateTime EditLectureTime, DateTime EditDeathLine, float EditSpan, int EditExpectPeople,
            int EditArchitectureId, int EditPlaceId, double EditScore)
        {
            Model.T_Base_Lecture lecture = new Model.T_Base_Lecture();
            lecture.Id = EditLectureId;
            lecture.Subject = EditSubject;
            lecture.Summary = EditSummary;
            lecture.LectureTime = EditLectureTime;
            lecture.DeathLine = EditDeathLine;
            lecture.Span = EditSpan;
            lecture.ExpectPeople = EditExpectPeople;
            lecture.Score = EditScore;
            int result = new BLL.T_Base_Lecture().EditSaveLecture(EditNum, EditApplyId, lecture, EditPlaceId);
            if (result > -1)
            {
                return Json("修改成功");
            }
            else if (result == -1)
            {
                return Json("修改失败");
            }
            else if (result == -2)
            {
                return Json("该时间段内存在其他讲座");
            }
            else if (result == -3)
            {
                return Json("未进行信息的修改");
            }
            else
            {
                return Json("请联系管理员上报错误");
            }
        }
       
        /// <summary>
        /// 报名
        /// </summary>
        /// <param name="Num"></param>
        /// <param name="LectureId"></param>
        /// <returns></returns>
        public JsonResult Order(string Num,int LectureId)
        {
            int result = new BLL.T_Base_Lecture().Order(Num, LectureId);
            switch(result){
                case -1:
                    return Json("报名失败");
                case -2:
                    return Json("以报名");
                case 0:
                    return Json("报名失败");
                case 1:
                    return Json("报名成功");
                case 2:
                    return Json("人满待审核");
                default:
                    return Json("报名失败");
            }
        }

        /// <summary>
        /// 报名功能显示（报名，以报名，截止报名
        /// </summary>
        /// <param name="Num"></param>
        /// <param name="LectureId"></param>
        /// <returns></returns>
        public JsonResult OrderSelect(string Num, int LectureId) {
            return Json(new BLL.T_Base_Lecture().OrderSelect(Num,LectureId));
        }

        /// <summary>
        /// 取消报名
        /// </summary>
        /// <param name="Num"></param>
        /// <param name="LectureId"></param>
        /// <returns></returns>
        public JsonResult OrderDelete(string Num,int LectureId)
        {
            int result = new BLL.T_Base_Lecture().OrderDelete(Num, LectureId);
            if(result == 1)
            {
                return Json("取消成功");
            }else if (result == -1)
            {
                return Json("取消失败");
            }else if (result == -2)
            {
                return Json("取消失败，未报名");
            }else
            {
                return Json("取消失败");
            }
        }


        public JsonResult OrderMessage(int RoleId,string Num="")
        {

        }
    }
}