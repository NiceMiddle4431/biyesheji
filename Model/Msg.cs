using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Msg
    {
        /// <summary>
        /// 实际人数超出预期人数的讲座个数
        /// </summary>
        public List<Model.T_Base_Lecture> Lecture { get; set; }

        /// <summary>
        /// 讲座出现变更通知
        /// </summary>
        public List<Model.T_Base_Order> Order { get; set; }

        /// <summary>
        /// 待处理的评论数
        /// </summary>
        public List<Model.T_Base_Resource> Resource { get; set; }


        /// <summary>
        /// 用户信息
        /// </summary>
        public List<Model.T_Base_User> User { get; set; }
    }
}
