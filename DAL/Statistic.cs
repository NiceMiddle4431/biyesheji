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
                    try
                    {
                        result = cmd.ExecuteNonQuery();
                        config.Close();
                        return 1;               //签到成功
                    }
                    catch
                    {
                        return -4;               //学号输入不正确或不存在该学号
                    }
                  
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


        /// <summary>
        /// 查询出席的讲座
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        public List<Model.T_Base_Statistic> GetAllAttendance(string Num,int State)
        {
            List<Model.T_Base_Statistic> list = new List<Model.T_Base_Statistic>();
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            if (State == 0)
            {
                cmd.CommandText = "select * from V_Lecture_Statistic where Num = '" + Num + "'";
            }else if (State == 1)
            {
                cmd.CommandText = "select * from V_Lecture_Statistic where Num = '" + Num + "' and EndTime <> '1900/1/1 0:00:00'";
            }

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Model.T_Base_Statistic statistic = new Model.T_Base_Statistic();
                Model.T_Base_Lecture lecture = new Model.T_Base_Lecture();
                lecture.Id = Convert.ToInt32(reader["Id"]);
                lecture.Subject = Convert.ToString(reader["Subject"]);
                lecture.Score = Convert.ToDouble(reader["Score"]);
                lecture.RealPeople = Convert.ToInt32(reader["RealPeople"]);
                lecture.LectureTime = Convert.ToDateTime(reader["LectureTime"]);

                statistic.Id = Convert.ToInt32(reader["StatisticId"]);
                statistic.Num = Convert.ToString(reader["Num"]);
                statistic.StartTime = Convert.ToDateTime(reader["StartTime"]);
                statistic.EndTime = Convert.ToDateTime(reader["EndTime"]);
                statistic.Lecture = lecture;

                list.Add(statistic);
            }
            reader.Close();
            config.Close();
            return list;
        }


        /// <summary>
        /// 获取总分
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        public double GetScore(string Num)
        {
            double result = 0;
            SqlConfig config = new DAL.SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select * from V_Excel where Num = '" + Num + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if(!(Convert.ToDateTime(reader["EndTime"]).ToString("yyyy/MM/dd HH:mm:ss").Equals("1900/01/01 00:00:00")))
                {
                    result += Convert.ToDouble(reader["Score"]);
                    string[] score = result.ToString().Split('.');
                    if (score[1]=="99")
                    {
                        result = Convert.ToDouble(score[0] + 1);
                    }
                }
            }
            reader.Close();
            config.Close();
            return result;
        }


        /// <summary>
        /// 查询参与讲座人员信息
        /// </summary>
        /// <param name="LectureId"></param>
        /// <returns></returns>
        public List<Model.T_Base_Statistic> SavePeopleExcel(int LectureId)
        {
            List<Model.T_Base_Statistic> list = new List<Model.T_Base_Statistic>();
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select * from V_Excel where LectureId = " + LectureId;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Model.T_Base_Statistic statistic = new Model.T_Base_Statistic();
                Model.T_Base_User user = new Model.T_Base_User();

                user.Num = Convert.ToString(reader["Num"]);
                user.Name = Convert.ToString(reader["Name"]);
                user.Sex = Convert.ToInt16(reader["Sex"]);
                user.PhoneNum = Convert.ToString(reader["PhoneNum"]);
                Model.T_Base_Architecture architecture = new Model.T_Base_Architecture();
                architecture.ArchitectureName = Convert.ToString(reader["ArchitectureName"]);
                Model.T_Base_MajorClass majorClass = new Model.T_Base_MajorClass();
                majorClass.Architecture = architecture;
                majorClass.MajorClassName = Convert.ToString(reader["MajorClassName"]);
                user.MajorClass = majorClass;

                statistic.StartTime = Convert.ToDateTime(reader["StartTime"]);
                statistic.EndTime = Convert.ToDateTime(reader["EndTime"]);

                statistic.User = user;
                list.Add(statistic);
            }

            reader.Close();
            config.Close();
            return list;
        }


        /// <summary>
        /// 查询是否有预报名
        /// </summary>
        /// <param name="Num"></param>
        /// <param name="LectureId"></param>
        /// <returns></returns>
        public int SelectOrder(string Num,int LectureId)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select count(1) from T_Base_Order where Num='"+Num+"' and LectureId="+LectureId;
            int result = (int)cmd.ExecuteScalar();
            config.Close();
            return result;
        }

    }
}
