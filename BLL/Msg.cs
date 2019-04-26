using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Msg
    {
        public Model.Msg GetAllMsg(string Num)
        {
            Model.Msg msg = new Model.Msg();
            msg.Order = new DAL.Msg().GetOrderMsg(Num);
            msg.Resource = new DAL.Msg().GetResourceMsg();
            msg.Lecture = new DAL.Msg().GetLectureMsg(Num);
            return msg;
        }
    }
}
