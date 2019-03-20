using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCoder;
using System.Drawing;

namespace DAL
{
    public class T_Base_Lecture
    { 

        /// <summary>
        /// 获取全部讲座信息
        /// </summary>
        /// <param name="ArchitectureId"></param>
        /// <returns></returns>
        public List<Model.T_Base_Apply> GetAllLecture(string ParamLecture, int PageSize, int PageNumber)
        {
            sqlConfig config = new sqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select top " + PageSize + " * from V_User_Lecture_Place" +
                " where Id not in (select top " + (PageSize * PageNumber) +
                " Id from V_User_Lecture_Place where V_User_Lecture_Place.Subject" +
                " like '%" + ParamLecture + "%' or V_User_Lecture_Place.Name like '%" +
                ParamLecture + "%') and V_User_Lecture_Place.Subject" +
                " like '%" + ParamLecture + "%' or V_User_Lecture_Place.Name like '%" +
                ParamLecture + "%' ";
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
            config.Close();
            return list;
        }


        /// <summary>
        /// 获取数据库内记录总数
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            sqlConfig config = new sqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            int count = (int)cmd.ExecuteScalar();
            config.Close();
            return count;
        }


        /// <summary>
        /// 获取指定id的讲座
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<Model.T_Base_Apply> GetLecture(int Id)
        {
            List<Model.T_Base_Apply> list = new List<Model.T_Base_Apply>();
            sqlConfig config = new sqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select * from V_User_Lecture_Place where Id = " + Id;
            SqlDataReader reader = cmd.ExecuteReader();
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
            config.Close();
            return list;
        }


        /// <summary>
        /// 保存添加的讲座信息
        /// </summary>
        /// <param name="majorClass"></param>
        /// <returns></returns>
        public int AddSaveLecture(string AddNum, Model.T_Base_Lecture Lecture, int AddPlaceId)
        {
            sqlConfig config = new sqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            int result = -1;
            try
            {
                cmd.Transaction = config.getSqlConnection().BeginTransaction();
                cmd.CommandText = "insert into T_Base_Lecture " +
                    "values('" + Lecture.Subject + "','" + Lecture.Summary + "',0,-1,-1,'" + Lecture.DeathLine + "','" +
                    Lecture.LectureTime + "'," + Lecture.Span + "," + Lecture.ExpectPeople + ",0," + Lecture.Score + ")";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "select top 1 Id from T_Base_Lecture order by Id desc";
                result = (int)cmd.ExecuteScalar();
                cmd.CommandText = "insert into T_Base_Apply values('" +
                    AddNum + "'," + result + "," + AddPlaceId + ",'" + DateTime.Now + "')";
                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
                QRCodeSave(result + "-1");  //开始    
                QRCodeSave(result + "-2");  //结束
                cmd.CommandText = "updata T_Base_Lecture set QRCodeStart = '" + result + "-1',QRCodeEnd = '" + result + "-2'"
                    + " where Id = " + result;
            }
            catch
            {
                result = -1;
            }
            config.Close();
            return result;
        }

        //二维码生成保存
        private void QRCodeSave(string strQRCodeName)
        {
            string strCode = "http://212.64.18.220:8080/SignIn/Index";
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(strCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            Bitmap qrCodeImage = qrCode.GetGraphic(5, Color.Black, Color.White, null, 15, 6, false);
            string strFilePath = Environment.CurrentDirectory;
            qrCodeImage.Save("D:\\VS2015解决方案\\毕业设计\\bysj\\Web\\QRCode\\" + strQRCodeName + ".jpg");
        }

        /// <summary>
        /// 保存修改后的信息
        /// </summary>
        /// <param name="Lecture"></param>
        /// <returns></returns>
        public int EditSaveLecture(Model.T_Base_Lecture Lecture)
        {
            sqlConfig config = new sqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "update T_Base_MajorClass set ";
            int result = cmd.ExecuteNonQuery();
            config.Close();
            return result;
        }


        /// <summary>
        /// 删除讲座
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Delete(string Ids)
        {
            sqlConfig config = new sqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "delete from T_Base_Lecture where Id in (" + Ids + ")";
            int result = cmd.ExecuteNonQuery();
            config.Close();
            return result;
        }

    }
}
