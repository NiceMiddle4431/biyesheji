using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class Msg
    {
        /// <summary>
        /// 讲座出现变更通知
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        public List<Model.T_Base_Order> GetOrderMsg(string Num)
        {
            List<Model.T_Base_Order> list = new List<Model.T_Base_Order>();
            SqlConfig config = new DAL.SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select * from V_Lecture_Order where Num='" + Num + "' and State = 1 and AlertFlag = 1 and  MsgFlag = 0";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Model.T_Base_Order order = new Model.T_Base_Order();
                order.Lecture = new Model.T_Base_Lecture();
                order.LectureId = Convert.ToInt32(reader["LectureId"]);
                order.Lecture.Subject = Convert.ToString(reader["Subject"]);
                list.Add(order);
            }
            reader.Close();
            cmd.CommandText = "select * from V_Lecture_Order where Num = '"+Num+"' and MsgFlag = 0 and result = 3";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Model.T_Base_Order order = new Model.T_Base_Order();
                order.Lecture = new Model.T_Base_Lecture();
                order.LectureId = Convert.ToInt32(reader["LectureId"]);
                order.Lecture.Subject = Convert.ToString(reader["Subject"]);
                order.Result = Convert.ToInt16(reader["Result"]);
                list.Add(order);
            }
            reader.Close();
            config.Close();
            return list;
        }

        //public int GetOrderCount(string Num)
        //{
        //    SqlConfig config = new DAL.SqlConfig();
        //    SqlCommand cmd = config.getSqlCommand();
        //    cmd.CommandText = "select count(*) from V_Lecture_Order where Num='" + Num + "' and MsgFlag=1";

        //    int result = (int)cmd.ExecuteScalar();
        //    config.Close();
        //    return result;
        //}


        /// <summary>
        /// 实际人数超出预期人数的讲座个数
        /// </summary>
        /// <param name="LcetureId"></param>
        /// <returns></returns>
        public List<Model.T_Base_Lecture> GetLectureMsg(string Num)
        {
            List<Model.T_Base_Lecture> list = new List<Model.T_Base_Lecture>();

            SqlConfig config = new DAL.SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select Id, Subject from T_Base_Lecture where Id in" +
                "(select LectureId from T_Base_Apply where Num = '" + Num + "') and " +
                "RealPeople > ExpectPeople";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Model.T_Base_Lecture lecture = new Model.T_Base_Lecture();
                lecture.Id = Convert.ToInt32(reader["Id"]);
                lecture.Subject = Convert.ToString(reader["Subject"]);
                list.Add(lecture);
            }
            reader.Close();
            config.Close();
            return list;
        }


        /// <summary>
        /// 审核评论
        /// </summary>
        /// <returns></returns>
        public List<Model.T_Base_Resource> GetResourceMsg()
        {
            List<Model.T_Base_Resource> list = new List<Model.T_Base_Resource>();

            SqlConfig config = new DAL.SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select Id,LectureId,Content from T_Base_Resource where ReViewFlag = 1 and MsgFlag = 0";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Model.T_Base_Resource resource = new Model.T_Base_Resource();
                resource.Id = Convert.ToInt32(reader["Id"]);
                resource.LectureId = Convert.ToInt32(reader["LectureId"]);
                resource.Content = Convert.ToString(reader["Content"]);
                list.Add(resource);
            }
            reader.Close();
            config.Close();
            return list;
        }

    }
}
