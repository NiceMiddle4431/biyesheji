using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 签到情况统计
    /// </summary>
    public class T_Base_Statistic
    {
        /// <summary>
        /// 唯一自增Id
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// 学号
        /// </summary>
        public string Num { get; set; }


        /// <summary>
        /// 讲座信息
        /// </summary>
        public int LectureId { get; set; }


        /// <summary>
        /// 签到记录  0表示未签到，1表示签到成功
        /// </summary>
        public DateTime StartTime { get; set; }


        /// <summary>
        /// 签退记录  0表示未签到，1表示签到成功
        /// </summary>
        public DateTime EndTime { get; set; }


        /// <summary>
        /// Ip信息记录
        /// </summary>
        public string Ip { get; set; }


        /// <summary>
        /// 记录讲座信息
        /// </summary>
        public Model.T_Base_Lecture Lecture { get; set; }
    }
}
