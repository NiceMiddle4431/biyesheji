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
    class T_Base_Architecture
    {
        /// <summary>
        /// 唯一自增Id
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// 建筑名
        /// </summary>
        public string ArchitectureName { get; set; }
    }
}
