using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        /// <summary>
        /// 主界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string Num,int Role)
        {
            ViewBag.Num = Num;
            ViewBag.Role = Role;
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


        /// <summary>
        /// 根据指定建筑Id获取学院专业
        /// </summary>
        /// <param name="ArchitectureId"></param>
        /// <returns></returns>
        public JsonResult GetMajorClass(int ArchitectureId)
        {
            return Json(new BLL.T_Base_User().GetMajorClass(ArchitectureId));
        }

        /// <summary>
        /// 保存添加的用户信息
        /// </summary>
        /// <param name="AddNum"></param>
        /// <param name="AddName"></param>
        /// <param name="AddSex"></param>
        /// <param name="AddMajorClassId"></param>
        /// <param name="AddPhoneNum"></param>
        /// <param name="AddIsAdmin"></param>
        /// <returns></returns>
        public JsonResult AddSaveUser(string AddNum,string AddName,int AddSex,
            int AddMajorClassId,string AddPhoneNum,int AddRole= 3)
        {
            Model.T_Base_User user = new Model.T_Base_User();
            user.Id = 0;
            user.Num = AddNum;
            user.Name = AddName;
            user.Sex = AddSex;
            user.MajorClassId = AddMajorClassId;
            user.PhoneNum = AddPhoneNum;
            user.Role = AddRole;
            int result = new BLL.T_Base_User().AddSaveUser(user);
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
        /// 重置用户密码
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public JsonResult ResetPassWord(int UserId)
        {
            int result = new BLL.T_Base_User().ResetPassWord(UserId);
            if (result == 1)
            {
                return Json("重置成功");
            }
            else
            {
                return Json("重置失败");
            }
        }

        /// <summary>
        /// 获取指定Id的用户信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public JsonResult GetUser(int UserId)
        {
            return Json(new BLL.T_Base_User().GetUser(UserId));
        }

        /// <summary>
        /// 保存修改后的用户信息
        /// </summary>
        /// <param name="EditId"></param>
        /// <param name="EditNum"></param>
        /// <param name="EditName"></param>
        /// <param name="EditSex"></param>
        /// <param name="EditMajorClassId"></param>
        /// <param name="EditPhoneNum"></param>
        /// <param name="EditIsAdmin0"></param>
        /// <returns></returns>
        public JsonResult EditSaveUser(int EditId,string EditNum,string EditName,int EditSex,
            int EditMajorClassId,string EditPhoneNum,string EditPassWord,int EditRole)
        {
            Model.T_Base_User user = new Model.T_Base_User();
            user.Id = EditId;
            user.Num = EditNum;
            user.Name = EditName;
            user.Sex = EditSex;
            user.MajorClassId = EditMajorClassId;
            user.PhoneNum = EditPhoneNum;
            user.Role = EditRole;
            user.PassWord = EditPassWord;
            int result = new BLL.T_Base_User().EditSaveUser(user);
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
        /// 删除学生
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public JsonResult Delete(string[] Ids)
        {
            int result = new BLL.T_Base_User().Delete(Ids);
            if (result <= 0)
            {
                return Json("删除失败");
            }
            else
            {
                return Json("删除" + result + "记录");
            }
        }


        public ActionResult ExcelIndex() {

            return View();
        } 

        public JsonResult SaveExcelUser()
        {
            var file = Request.Files["AddFile"];
            if (file.ContentLength == 0)
            {
                return Json("请添加文件");
            }
            string path = Server.MapPath("\\upLoad\\");
            string[] strfile = file.FileName.Split('.');
            string type = "."+strfile[strfile.Length - 1];
            string fileName = "";
            for (int i = 0; i < strfile.Length-1; i++)
            {
                fileName += strfile[i];
            }
            fileName += DateTime.Now.ToString("yyyyMMddHHmmssffff") + type;
            file.SaveAs(path + fileName);
            
            FileStream fs = new FileStream(path+fileName, FileMode.Open);
            if (fs.Length == 0)
            {
                return Json("文件不存在");
            }
            HSSFWorkbook wk = new HSSFWorkbook(fs);
            ISheet sheet = wk.GetSheetAt(0);

            List<Model.T_Base_User> list = new List<Model.T_Base_User>();
            for (int i = 1; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                if(row != null)
                {
                    for(int j = 0; j < row.LastCellNum; j++)
                    {
                        ICell cell = row.GetCell(j);
                        if(cell == null)
                        {
                            return Json("第" + (i + 1) + "行" + (j + 1) + "列单元格内缺失内容");
                        }
                    }
                    Model.T_Base_User user = new Model.T_Base_User();
                    Model.T_Base_MajorClass majorClass = new Model.T_Base_MajorClass();
                    Model.T_Base_Architecture architecture = new Model.T_Base_Architecture();
                    user.Num = row.GetCell(0).ToString();
                    user.Name = row.GetCell(1).ToString();
                    if (row.GetCell(2).ToString() == "女")
                    {
                        user.Sex = 0;
                    }
                    else if (row.GetCell(2).ToString() == "男")
                    {
                        user.Sex = 1;
                    }
                    majorClass.MajorClassName = row.GetCell(3).ToString();
                    architecture.ArchitectureName = row.GetCell(4).ToString();
                    user.PhoneNum = row.GetCell(5).ToString();
                    majorClass.Architecture = architecture;
                    user.MajorClass = majorClass;
                    list.Add(user);
                }
            }

            int result = new BLL.T_Base_User().SaveExcelUser(list);

            return Json("");
        }
    }
}