using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class MajorClassController : Controller
    {
        // GET: MajorClass
        public ActionResult Index(int ArchitectureId)
        {
            ViewBag.ArchitectureId = ArchitectureId;
            return View();
        }

        /// <summary>
        /// 获取指定学院的专业班级
        /// </summary>
        /// <param name="ArchitectureId"></param>
        /// <returns></returns>
        public JsonResult GetAllMajorClass(int ArchitectureId)
        {
            return Json(new BLL.T_Base_MajorClass().GetAllMajorClass(ArchitectureId));
        }

        /// <summary>
        /// 保存添加的专业班级信息
        /// </summary>
        /// <param name="AddMajorClassName"></param>
        /// <param name="AddArchitectureId"></param>
        /// <returns></returns>
        public JsonResult AddSaveMajorClass(string AddMajorClassName,int AddArchitectureId)
        {
            Model.T_Base_MajorClass majorClass = new Model.T_Base_MajorClass();
            majorClass.MajorClassName = AddMajorClassName;
            majorClass.ArchitectureId = AddArchitectureId;
            int result = new BLL.T_Base_MajorClass().AddSaveMajorClass(majorClass);
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
        /// 获取指定Id的地点信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult GetMajorClass(int Id)
        {
            return Json(new BLL.T_Base_MajorClass().GetMajorClass(Id));
        }

        /// <summary>
        /// 保存修改后的信息
        /// </summary>
        /// <param name="AddMajorClassName"></param>
        /// <param name="AddPeopleNum"></param>
        /// <param name="AddArchitectureId"></param>
        /// <returns></returns>
        public JsonResult EditSaveMajorClass(int EditId, string EditMajorClassName,int EditArchitectureId)
        {
            Model.T_Base_MajorClass majorClass = new Model.T_Base_MajorClass();
            majorClass.Id = EditId;
            majorClass.MajorClassName = EditMajorClassName;
            majorClass.ArchitectureId = EditArchitectureId;
            majorClass.ArchitectureId = EditArchitectureId;
            int result = new BLL.T_Base_MajorClass().EditSaveMajorClass(majorClass);
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
        /// 删除场地
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public JsonResult Delete(string[] Ids)
        {
            int result = new BLL.T_Base_MajorClass().Delete(Ids);
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