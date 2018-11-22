using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 预定报名信息
    /// </summary>
    class T_Base_Order
    {
        /// <summary>
        /// 唯一自增Id
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// 预定学生学号
        /// </summary>
        public string Num { get; set; }


        /// <summary>
        /// 预定讲座信息
        /// </summary>
        public int LectureId { get; set; }


        /// <summary>
        /// 预定时间
        /// </summary>
        public DateTime OrderTime { get; set; }


        /// <summary>
        /// 0表示预定失败，1表示预定成功，2表示待通知
        /// </summary>
        public int Result { get; set; }
    }
}
