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
            int AddMajorClassId,string AddPhoneNum,int AddIsAdmin)
        {
            Model.T_Base_User user = new Model.T_Base_User();
            user.Num = AddNum;
            user.Name = AddName;
            user.Sex = AddSex;
            user.MajorClassId = AddMajorClassId;
            user.PhoneNum = AddPhoneNum;
            user.IsAdmin = AddIsAdmin;
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
            int EditMajorClassId,string EditPhoneNum,int EditIsAdmin)
        {
            Model.T_Base_User user = new Model.T_Base_User();
            user.Id = EditId;
            user.Num = EditNum;
            user.Name = EditName;
            user.Sex = EditSex;
            user.MajorClassId = EditMajorClassId;
            user.PhoneNum = EditPhoneNum;
            user.IsAdmin = EditIsAdmin;

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
    }
}