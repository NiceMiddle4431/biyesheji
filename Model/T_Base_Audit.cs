using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 审核信息
    /// </summary>
    class T_Base_Audit
    {
        /// <summary>
        /// 唯一自增Id
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// 学号或教工号
        /// </summary>
        public string Num { get; set; }


        /// <summary>
        /// 讲座Id
        /// </summary>
        public int LectureId { get; set; }


        /// <summary>
        /// 审核理由
        /// </summary>
        public string Reason { get; set; }


    }
}
