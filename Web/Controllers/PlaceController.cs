using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class PlaceController : Controller
    {
        // GET: Place
        /// <summary>
        /// 显示建筑内讲座地点信息页面
        /// </summary>
        /// <param name="ArchitectureId"></param>
        /// <returns></returns>
        public ActionResult Index(int ArchitectureId)
        {
            ViewBag.ArchitectureId = ArchitectureId;
            return View();
        }

        /// <summary>
        /// 查询建筑内可举办讲座地点（Id,地点名称，容纳人数）
        /// </summary>
        /// <param name="ArchitectureId"></param>
        /// <returns></returns>
        public JsonResult GetPlace(int ArchitectureId)
        {
            return Json( new BLL.T_Base_Place().GetPlace(ArchitectureId));
        }
    }
}