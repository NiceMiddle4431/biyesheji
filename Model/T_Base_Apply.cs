using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class T_Base_Apply
    {
        /// <summary>
        /// 申请记录Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 申请者学号
        /// </summary>
        public string Num { get; set; }

        /// <summary>
        /// 申请讲座Id
        /// </summary>
        public int LectureId { get; set; }

        /// <summary>
        /// 申请场地Id
        /// </summary>
        public int PlaceId { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime ApplyTime { get; set; }

        /// <summary>
        /// 申请者信息
        /// </summary>
        public Model.T_Base_User User { get; set; }

        /// <summary>
        /// 讲座信息
        /// </summary>
        public Model.T_Base_Lecture Lecture { get; set; }

        /// <summary>
        /// 场地信息
        /// </summary>
        public Model.T_Base_Place Place { get; set; }
    }
}
