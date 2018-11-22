using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 讲座信息
    /// </summary>
    public class T_Base_Lecture
    {
        /// <summary>
        /// 唯一自增Id
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// 讲座主题   最多100个字符
        /// </summary>
        public string Subject { get; set; }


        /// <summary>
        /// 讲座简介   最多250个字符
        /// </summary>
        public string Summary { get; set; }


        /// <summary>
        /// 讲座状态   0代表待审核   1是审核通过   2是被审核不通过
        /// </summary>
        public int State { get; set; }


        /// <summary>
        /// 讲座签到二维码保存
        /// </summary>
        public string CRCodeStart { get; set; }


        /// <summary>
        /// 讲座签退二维码保存
        /// </summary>
        public string CRCodeEnd { get; set; }


        /// <summary>
        /// 报名截止日期
        /// </summary>
        public DateTime DeathLine { get; set; }


        /// <summary>
        /// 讲座开始时间
        /// </summary>
        public DateTime LectureTime { get; set; }


        /// <summary>
        /// 持续时间
        /// </summary>
        public float Span { get; set; }


        /// <summary>
        /// 预计人数
        /// </summary>
        public int ExpectPeople { get; set; }


        /// <summary>
        /// 报名人数
        /// </summary>
        public int RealPeople { get; set; }


        /// <summary>
        /// 讲座分数
        /// </summary>
        public decimal Score { get; set; }


    }
}
