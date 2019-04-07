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

        public List<Model.T_Base_Statistic> GetAllAttendance(string Num,int State)
        {
            return new DAL.Statistic().GetAllAttendance(Num, State);
        }

        public double GetScore(string Num)
        {
            return new DAL.Statistic().GetScore(Num);
        }

        public List<Model.T_Base_Statistic> SavePeopleExcel(int LectureId)
        {
            return new DAL.Statistic().SavePeopleExcel(LectureId);
        }


        public int SelectOrder(string Num, int LectureId)
        {
            return new DAL.Statistic().SelectOrder(Num,LectureId);
        }

    }
}
