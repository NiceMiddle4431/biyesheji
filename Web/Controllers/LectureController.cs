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
        public JsonResult GetAllLecture()
        {
            return Json(new BLL.T_Base_Lecture().GetAllLecture());
        }

        /// <summary>
        /// 保存添加的讲座信息
        /// </summary>
        /// <param name="AddLectureName"></param>
        /// <param name="AddArchitectureId"></param>
        /// <returns></returns>
        public JsonResult AddSaveLecture(string AddLectureName, int AddArchitectureId)
        {
            Model.T_Base_Lecture lecture = new Model.T_Base_Lecture();

            int result = new BLL.T_Base_Lecture().AddSaveLecture(lecture);
            if (result == 1)
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


    }
}