using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 讲座可选择地点信息
    /// </summary>
    class T_Base_Place
    {
        /// <summary>
        /// 唯一自增Id
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// 场地名字
        /// </summary>
        public string PlaceName { get; set; }


        /// <summary>
        /// 容纳人数
        /// </summary>
        public int PeopleNum { get; set; }


        /// <summary>
        /// 所属建筑
        /// </summary>
        public int ArchitectureId { get; set; }

    }
}
