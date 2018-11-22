using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 专业班级信息
    /// </summary>
    public class T_Base_MajorClass
    {
        /// <summary>
        /// 唯一自增Id
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// 专业班级名称
        /// </summary>
        public string MajorClassName { get; set; }


        /// <summary>
        /// 所属建筑
        /// </summary>
        public int ArchitectureId { get; set; }

    }
}
