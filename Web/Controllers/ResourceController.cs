using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ResourceController : Controller
    {
        // GET: Resource
        public ActionResult Index(int LectureId,string Num,int Role)
        {
            ViewBag.LectureId = LectureId;
            ViewBag.Num = Num;
            ViewBag.Role = Role;
            return View();
        }
        
        public JsonResult GetAllResource(int LectureId)
        {
            return Json(new BLL.T_Base_Resource().GetAllResource(LectureId));
        }


        public JsonResult Delete(string[] Ids)
        {
            int result = new BLL.T_Base_Resource().Delete(Ids);
            if (result <= 0)
            {
                return Json("删除失败");
            }
            else
            {
                return Json("删除" + result + "记录");
            }
        }


        public ActionResult AddIndex(int LectureId)
        {
            ViewBag.LectureId = LectureId;
            return View();
        }


        public JsonResult AddSaveResource(string AddNum,int AddLectureId,string AddContent)
        {
            Model.T_Base_Resource resource = new Model.T_Base_Resource();
            resource.Num = AddNum;
            resource.LectureId = AddLectureId;
            resource.Content = AddContent;

            //文件保存
            string fileName1 = "";
            string fileName2 = "";
            string fileName3 = "";
            string path = Server.MapPath("\\upLoad\\");
            var file1 = Request.Files["AddFilePosition1"];
            if(file1.ContentLength != 0)
            {

                string[] strfileName1 = file1.FileName.Split('.');
                string type1 = "."+strfileName1[strfileName1.Length - 1];
                for (int i = 0; i < strfileName1.Length-1; i++)
                {
                    if(i != strfileName1.Length - 2)
                    {
                        fileName1 += strfileName1[i] + ".";
                    }
                    else
                    {
                        fileName1 += strfileName1[i];
                    }
 
                }
                fileName1 += DateTime.Now.ToString("yyyyMMddHHmmssffff") + type1;
                file1.SaveAs(path + fileName1);
            }
            resource.FilePosition1 = fileName1;
            resource.FilePosition2 = fileName2;
            resource.FilePosition3 = fileName3;

            int result = new BLL.T_Base_Resource().AddSaveResource(resource);
            if (result == 1)
            {
                return Json("评论成功");
            }else
            {
                return Json("评论失败");
            }
            
        }

        /// <summary>
        /// 举报评论，隐藏内容
        /// </summary>
        /// <returns></returns>
        public JsonResult ResourceReport(int ResourceId)
        {
            return Json(new BLL.T_Base_Resource().ResourceReport(ResourceId));
        }

        /// <summary>
        /// 举报评论审核界面
        /// </summary>
        /// <returns></returns>
        public ViewResult ReportReview(string Num,int Role)
        {
            ViewBag.Num = Num;
            ViewBag.Role = Role;
            return View();
        }

        public JsonResult GetAllResourceReport()
        {
            return Json(new BLL.T_Base_Resource().GetAllResourceReport());
        }


        public JsonResult UpdateResource(string[] ResourceId)
        {
            return Json(new BLL.T_Base_Resource().UpdateResource(ResourceId));
        }

    }
}