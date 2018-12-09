using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class T_Base_Lecture
    { /// <summary>
      /// 连接到数据库
      /// </summary>
      /// <returns></returns>
        private SqlConnection SqlServerOpen()
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=212.64.18.220;uid=bysj;pwd=bysj;database=bysj";
            co.Open();
            return co;
        }


        /// <summary>
        /// 获取全部讲座信息
        /// </summary>
        /// <param name="ArchitectureId"></param>
        /// <returns></returns>
        public List<Model.T_Base_Apply> GetAllLecture()
        {
            SqlConnection co = SqlServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "select * from V_User_Lecture_Place";
            SqlDataReader reader = cmd.ExecuteReader();
            List<Model.T_Base_Apply> list = new List<Model.T_Base_Apply>();
            while (reader.Read())
            {
                Model.T_Base_Apply apply = new Model.T_Base_Apply();

                apply.Id = Convert.ToInt32(reader["Id"]);
                apply.Num = Convert.ToString(reader["Num"]);
                apply.LectureId = Convert.ToInt32(reader["LectureId"]);
                apply.PlaceId = Convert.ToInt32(reader["PlaceId"]);
                apply.ApplyTime = Convert.ToDateTime(reader["ApplyTime"]);

                Model.T_Base_User user = new Model.T_Base_User();
                user.Id = Convert.ToInt32(reader["Id"]);
                user.Num = Convert.ToString(reader["Num"]);
                user.Name = Convert.ToString(reader["Name"]);
                user.Sex = Convert.ToInt32(reader["Sex"]);
                user.MajorClassId = Convert.ToInt32(reader["MajorClassId"]);
                Model.T_Base_MajorClass majorClass = new Model.T_Base_MajorClass();
                majorClass.Id = Convert.ToInt32(reader["MajorClassId"]);
                majorClass.MajorClassName = Convert.ToString(reader["MajorClassName"]);
                user.MajorClass = majorClass;
                user.PhoneNum = Convert.ToString(reader["PhoneNum"]);
                user.Number = Convert.ToInt32(reader["Number"]);
                user.IsAdmin = Convert.ToInt32(reader["IsAdmin"]);
                apply.User = user;

                Model.T_Base_Lecture lecture = new Model.T_Base_Lecture();
                lecture.Id = Convert.ToInt32(reader["Id"]);
                lecture.Subject = Convert.ToString(reader["Subject"]);
                lecture.Summary = Convert.ToString(reader["Summary"]);
                lecture.State = Convert.ToInt32(reader["State"]);
                lecture.CRCodeStart = Convert.ToString(reader["CRCodeStart"]);
                lecture.CRCodeEnd = Convert.ToString(reader["CRCodeEnd"]);
                lecture.DeathLine = Convert.ToDateTime(reader["DeathLine"]);
                lecture.LectureTime = Convert.ToDateTime(reader["LectureTime"]);
                lecture.Span = Convert.ToInt32(reader["Span"]);
                lecture.ExpectPeople = Convert.ToInt32(reader["ExpectPeople"]);
                lecture.RealPeople = Convert.ToInt32(reader["RealPeople"]);
                lecture.Score = Convert.ToInt32(reader["Score"]);
                apply.Lecture = lecture;

                Model.T_Base_Place place = new Model.T_Base_Place();
                place.Id = Convert.ToInt32(reader["PlaceId"]);
                place.PlaceName = Convert.ToString(reader["PlaceName"]);
                place.PeopleNum = Convert.ToInt32(reader["PeopleNum"]);
                place.ArchitectureId = Convert.ToInt32(reader["ArchitectureId"]);
                Model.T_Base_Architecture architecture = new Model.T_Base_Architecture();
                architecture.Id = Convert.ToInt32(reader["ArchitectureId"]);
                architecture.ArchitectureName = Convert.ToString(reader["ArchitectureName"]);
                place.Architecture = architecture;
                apply.Place = place;

                list.Add(apply);
            }
            reader.Close();
            co.Close();
            return list;
        }


        /// <summary>
        /// 获取指定id的讲座
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Model.T_Base_Lecture GetLecture(int Id)
        {
            Model.T_Base_Lecture lecture = new Model.T_Base_Lecture();
            SqlConnection conn = SqlServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            lecture.Id = Convert.ToInt32(reader["Id"]);
            lecture.Subject = Convert.ToString(reader["Subject"]);
            lecture.Summary = Convert.ToString(reader["Summary"]);
            lecture.State = Convert.ToInt32(reader["State"]);
            lecture.CRCodeStart = Convert.ToString(reader["CRCodeStart"]);
            lecture.CRCodeEnd = Convert.ToString(reader["CRCodeEnd"]);
            lecture.DeathLine = Convert.ToDateTime(reader["DeathLine"]);
            lecture.LectureTime = Convert.ToDateTime(reader["LectureTime"]);
            lecture.Span = Convert.ToInt32(reader["Span"]);
            lecture.ExpectPeople = Convert.ToInt32(reader["ExpectPeople"]);
            lecture.RealPeople = Convert.ToInt32(reader["RealPeople"]);
            lecture.Score = Convert.ToInt32(reader["Score"]);
            conn.Close();
            return lecture;
        }


        /// <summary>
        /// 保存添加的讲座信息
        /// </summary>
        /// <param name="majorClass"></param>
        /// <returns></returns>
        public int AddSaveLecture(Model.T_Base_Lecture Lecture)
        {
            SqlConnection co = SqlServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "insert into T_Base_MajorClass values";
            int result = cmd.ExecuteNonQuery();
            co.Close();
            return result;
        }



        /// <summary>
        /// 保存修改后的信息
        /// </summary>
        /// <param name="Lecture"></param>
        /// <returns></returns>
        public int EditSaveLecture(Model.T_Base_Lecture Lecture)
        {
            SqlConnection co = SqlServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "update T_Base_MajorClass set ";
            int result = cmd.ExecuteNonQuery();
            co.Close();
            return result;
        }


        /// <summary>
        /// 删除讲座
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Delete(string Ids)
        {
            SqlConnection co = SqlServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "delete from T_Base_Lecture where Id in (" + Ids + ")";
            int result = cmd.ExecuteNonQuery();
            co.Close();
            return result;
        }

    }
}
