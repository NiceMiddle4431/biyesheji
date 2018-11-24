using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        /// <summary>
        /// 主界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 按查询信息给出分页学生信息
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageNumber"></param>
        /// <param name="Num"></param>
        /// <param name="Name"></param>
        /// <param name="MajorClassName"></param>
        /// <returns></returns>
        public JsonResult GetAllUser(int PageSize, int PageNumber,
            string Num, string Name, string MajorClassName)
        {
            return Json(new
            {
                total = new BLL.T_Base_User().GetCount(),
                rows = new BLL.T_Base_User().GetAllUser(PageSize, PageNumber, Num, Name, MajorClassName)
            });
        }


        public JsonResult GetMajorClass(int ArchitectureId)
        {
            return Json(new BLL.T_Base_User().GetMajorClass(ArchitectureId));
        }


    }
}