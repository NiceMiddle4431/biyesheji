using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index(string Num)
        {
            ViewBag.Num = Num;
            return View();
        }

        public JsonResult GetAllLecture(string ParamLecture, int PageSize, int PageNumber)
        {
            return Json(new
            {
                total = new BLL.T_Base_Lecture().GetCount(" in (0,3)"),
                rows = new BLL.T_Base_Lecture().GetAllLecture(ParamLecture, PageSize, PageNumber, " in (0,3)")
            });
        }

        public JsonResult Review(int ApplyId,int LectureId,int State,string Num,string ReviewNum,string Reason="")
        {
            int result = new BLL.Review().Review_Updata(ApplyId, LectureId, State,Num, ReviewNum, Reason);
            if(result == 1 && State == 1)
            {
                return Json("同意成功");
            }else if(result == 1 && State == 2)
            {
                return Json("拒绝成功");
            }else
            {
                return Json("操作失败，请联系管理员");
            }
            
        }
    }
}