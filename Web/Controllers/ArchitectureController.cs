using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ArchitectureController : Controller
    {
        // GET: Architecture
        /// <summary>
        /// 显示建筑信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取全部建筑
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllArchitecture()
        {
            return Json(new BLL.T_Base_Architecture().GetAllArchitecture());
        }

        /// <summary>
        /// 保存新增建筑信息
        /// </summary>
        /// <param name="Architecture"></param>
        /// <returns></returns>
        public JsonResult AddSaveArchitecture(string AddArchitectureName)
        {
            Model.T_Base_Architecture architecture = new Model.T_Base_Architecture();
            architecture.ArchitectureName = AddArchitectureName;
            int result = new BLL.T_Base_Architecture().AddSaveArchitecture(architecture);
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
        /// 根据Id获取指定建筑信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult GetArchitecture(int Id)
        {
            return Json(new BLL.T_Base_Architecture().GetArchitecture(Id));
        }

        /// <summary>
        /// 保存修改后建筑的信息
        /// </summary>
        /// <returns></returns>
        public JsonResult EditSaveArchitecture(int EditId, string EditArchitectureName)
        {
            Model.T_Base_Architecture architecture = new Model.T_Base_Architecture();
            architecture.Id = EditId;
            architecture.ArchitectureName = EditArchitectureName;

            int result = new BLL.T_Base_Architecture().EditSaveArchitecture(architecture);

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
            int result = new BLL.T_Base_Architecture().Delete(Ids);
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