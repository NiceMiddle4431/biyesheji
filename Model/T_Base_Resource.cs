using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 资源管理信息
    /// </summary>
    public class T_Base_Resource
    {
        /// <summary>
        /// 唯一自增Id
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// 上传者学号
        /// </summary>
        public string Num { get; set; }


        /// <summary>
        /// 讲座信息
        /// </summary>
        public int LectureId { get; set; }


        /// <summary>
        /// 心得内容，最多250个字
        /// </summary>
        public string Content { get; set; }


        /// <summary>
        /// 最多三个附件所处位置
        /// </summary>
        public string FilePositon1 { get; set; }
        public string FilePositon2 { get; set; }
        public string FilePositon3 { get; set; }
    }
}
