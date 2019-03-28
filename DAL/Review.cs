using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class Review
    {
        public int Review_Updata(int ApplyId,int LectureId, int State, string Num,string Reason = "")
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "update T_Base_Lecture set State = "+State+" where T_Base_Lecture.Id = "+
                "(select LectureId from T_Base_Apply where T_Base_Apply.Id = "+ ApplyId + ")";
            int result = cmd.ExecuteNonQuery();
            if(State == 2)
            {
                cmd.CommandText = "insert into T_Base_Audit values('"+Num
                    +"',"+ LectureId + ",'"+Reason+"','"+DateTime.Now+"')";
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }
    }
}
