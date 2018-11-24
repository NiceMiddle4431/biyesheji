using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 师生信息
    /// </summary>
    public class T_Base_User
    {
        /// <summary>
        /// 唯一自增id
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// 学号或教工号
        /// </summary>
        public string Num { get; set; }


        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 0表示女   1表示男
        /// </summary>
        public int Sex { get; set; }


        /// <summary>
        /// 所在专业班级
        /// </summary>
        public int MajorClassId { get; set; }


        /// <summary>
        /// 联系方式
        /// </summary>
        public string PhoneNum { get; set; }


        /// <summary>
        /// 登录密码（默认学号
        /// </summary>
        public string PassWord { get; set; }


        /// <summary>
        /// 预定未到次数
        /// </summary>
        public int Number { get; set; }


        /// <summary>
        /// 是否管理员   0表示不是管理员   1表示是管理员
        /// </summary>
        public int IsAdmin { get; set; }


        /// <summary>
        /// 所属专业班级信息
        /// </summary>
        public Model.T_Base_MajorClass MajorClass { get; set; }


    }
}
