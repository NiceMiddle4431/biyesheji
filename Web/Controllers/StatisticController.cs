using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistics
        public ActionResult Index(int LectureId)
        {
            ViewBag.LectureId = LectureId;
            return View();
        }

        public JsonResult AddSaveStatistic(string Num,int LectureId,string Ip)
        {
            int result = new BLL.Statistic().AddSaveStatistic(Num,LectureId, Ip);
            if(result == 1)
            {
                return Json("签到成功");
            }
            else if (result == 2)
            {
                return Json("签退成功");
            }
            else if (result == -2)
            {
                return Json("未签到");
            }
            else if (result == -3)
            {
                return Json("存在代签情况");
            }
            else if (result == -1)
            {
                return Json("签到失败");
            }
            else
            {
                return Json("");
            }
        }
    }
}