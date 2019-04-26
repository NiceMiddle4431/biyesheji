using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Review
    {
        public int Review_Updata(int ApplyId, int LectureId, int State, string Num, string ReviewNum, string Reason = "")
        {
            return new DAL.Review().Review_Updata(ApplyId,LectureId, State, Num, ReviewNum, Reason);
        }
    }
}
