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
        public ActionResult Index(int LectureId)
        {
            ViewBag.LectureId = LectureId;
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
            var file2 = Request.Files["AddFilePosition2"];
            if (file2.ContentLength != 0)
            {

                string[] strfileName2 = file2.FileName.Split('.');
                string type2 = "." + strfileName2[strfileName2.Length - 1];
                for (int i = 0; i < strfileName2.Length - 1; i++)
                {
                    if (i != strfileName2.Length - 2)
                    {
                        fileName2 += strfileName2[i] + ".";
                    }
                    else
                    {
                        fileName2 += strfileName2[i];
                    }

                }
                fileName2 += DateTime.Now.ToString("yyyyMMddHHmmssffff") + type2;
                file2.SaveAs(path + fileName2);
            }
            var file3 = Request.Files["AddFilePosition3"];
            if (file3.ContentLength != 0)
            {

                string[] strfileName3 = file3.FileName.Split('.');
                string type3 = "." + strfileName3[strfileName3.Length - 1];
                for (int i = 0; i < strfileName3.Length - 1; i++)
                {
                    if (i != strfileName3.Length - 2)
                    {
                        fileName3 += strfileName3[i] + ".";
                    }
                    else
                    {
                        fileName3 += strfileName3[i];
                    }

                }
                fileName3 += DateTime.Now.ToString("yyyyMMddHHmmssffff") + type3;
                file3.SaveAs(path + fileName3);
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
    }
}