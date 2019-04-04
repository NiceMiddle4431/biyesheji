using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DAL
{
    public class Statistic
    {
        /// <summary>
        /// 签到
        /// </summary>
        /// <param name="Num"></param>
        /// <param name="LectureId"></param>
        /// <param name="Ip"></param>
        /// <returns></returns>
        public int AddSaveStatistic(string Num, int LectureId, string Ip)
        {
            int result = -1;
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();

            cmd.CommandText = "select LectureTime,Span from T_Base_Lecture where Id = " + LectureId;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            DateTime LectureTime = Convert.ToDateTime(reader["LectureTime"]);
            double Span = Convert.ToDouble(reader["Span"]);
            reader.Close();

            if (DateTime.Now >= LectureTime.AddMinutes(-30) && DateTime.Now <= LectureTime.AddMinutes(5))
            {
                //签到，提前三十分钟到开始五分钟区间内可签到
                cmd.CommandText = "select count(1) from T_Base_Statistic where LectureId = " + LectureId + " and Ip = '" + Ip + "'";
                result = (int)cmd.ExecuteScalar();
                if (result == 0)
                {
                    cmd.CommandText = "insert into T_Base_Statistic values('" +
                        Num + "'," + LectureId + ",'" + DateTime.Now + "','" + DBNull.Value + "','" + Ip + "')";
                    result = cmd.ExecuteNonQuery();
                    config.Close();
                    return 1;               //签到成功
                } else
                {
                    config.Close();
                    return -3;              //存在代签情况
                }

            }
            else if (DateTime.Now >= LectureTime.AddMinutes(Span * 60 * 0.8) && DateTime.Now <= LectureTime.AddMinutes(Span * 60 + 30))
            {
                //签退
                cmd.CommandText = "select count(1) from T_Base_Statistic where LectureId = " + LectureId + " and Ip = '" + Ip + "'";
                result = (int)cmd.ExecuteScalar();
                if (result <= 1)
                {
                    cmd.CommandText = "select count(1) from T_Base_Statistic where Num = '" + Num + "' and LectureId = " + LectureId;
                    result = (int)cmd.ExecuteScalar();
                    if (result < 1)
                    {
                        config.Close();
                        return -2;          //未签到
                    }
                    cmd.CommandText = "update T_Base_Statistic set EndTime = '" + DateTime.Now + "' where Num = '" + Num + "' and LectureId = " + LectureId;
                    result = cmd.ExecuteNonQuery();
                    config.Close();
                    return 2;               //签退成功
                }
                else
                {
                    config.Close();
                    return -3;              //存在代签情况
                }
            }
            config.Close();
            return -1;                  //签到失败
        }
    }
}
