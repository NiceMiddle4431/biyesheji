using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 建筑信息
    /// </summary>
    public class T_Base_Architecture
    {
        /// <summary>
        /// 唯一自增Id
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// 建筑名
        /// </summary>
        public string ArchitectureName { get; set; }


        /// <summary>
        /// 是否是学院 0表示公共建筑（图书馆，大学生活动中心） 1表示是学院
        /// </summary>
        public int IsCollege { get; set; }
    }
}
