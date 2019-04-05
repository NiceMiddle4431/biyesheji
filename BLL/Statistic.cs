using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Statistic
    {
        public int AddSaveStatistic(string Num, int LectureId, string Ip)
        {
            return new DAL.Statistic().AddSaveStatistic(Num,LectureId,Ip);
        }

        public List<Model.T_Base_Statistic> GetAllAttendance(string Num)
        {
            return new DAL.Statistic().GetAllAttendance(Num);
        }
    }
}
