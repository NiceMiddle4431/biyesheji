using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class T_Base_RoleMenu
    {
        /// <summary>
        /// 唯一标识ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 角色功能说明
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 菜单Id
        /// </summary>
        public int MenuId { get; set; }

        /// <summary>
        /// 控制器名称
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// 页面
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Display { get; set; }
    }
}
