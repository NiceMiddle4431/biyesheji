using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class T_Base_Admin
    {
        /// <summary>
        /// 唯一自增Id
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// 登录账号
        /// </summary>
        public string Admin { get; set; }


        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }


    }
}
