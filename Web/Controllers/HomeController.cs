using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Web.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 获取全部的角色
        /// </summary>
        /// <returns></returns>
        public JsonResult GetRoleMenu(int RoleId)
        {
            BLL.Home bll = new BLL.Home();
            return Json(bll.GetRoleMenu(RoleId));
        }

        /// <summary>
        /// 检测账号密码
        /// </summary>
        /// <param name="Num"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public JsonResult Check(string Num,string Password)
        {
            int result = new BLL.Home().Check(Num, Password);
            int role = 0;
            if (result == -2 || result == -3)
            {
                if(result == -2)
                {
                    role = new BLL.T_Base_User().GetUser(Num).Role;
                }else if(result == -3)
                {
                    role = new BLL.T_Base_Admin().GetAdmin(Num).Role;
                }
                //记录票据
                FormsAuthentication.SetAuthCookie(Num, false);//简单授权
                var authTicket = new FormsAuthenticationTicket(
                    role,        //角色
                    "" + Num,          //登录用户Id
                    DateTime.Now,       //当前时间
                    DateTime.Now.AddDays(30),//保存时间
                    true,// 如果为 true，则创建持久 Cookie（跨浏览器会话保存的 Cookie）；否则为 false。
                    ""      //存储在票证中的用户特定的数据
                    );
                HttpCookie authCookie = new HttpCookie(
                    FormsAuthentication.FormsCookieName,
                    FormsAuthentication.Encrypt(authTicket));

                Response.Cookies.Add(authCookie);
            }
            return Json(role);
        }
    }
}