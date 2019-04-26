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
        /// 讲座状态   0代表待审核   1是审核通过   2是被审核不通过   3是编辑后待审核
        /// </summary>
        public int State { get; set; }


        /// <summary>
        /// 讲座二维码保存
        /// </summary>
        public string QRCode { get; set; }


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
        public double Span { get; set; }


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
        public double Score { get; set; }


        /// <summary>
        /// 拒绝时间
        /// </summary>
        public DateTime AuditTIme { get; set; }

        /// <summary>
        /// 拒绝理由
        /// </summary>
        public string Reason { get; set; }


        /// <summary>
        /// 修改标识 0未修改过，1修改过
        /// </summary>
        public int AlertFlag { get; set; }
    }
}
