using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace DAL
{
    public class T_Base_Lecture
    { 

        /// <summary>
        /// 获取全部讲座信息
        /// </summary>
        /// <param name="ArchitectureId"></param>
        /// <returns></returns>
        public List<Model.T_Base_Apply> GetAllLecture(string ParamLecture, int PageSize, int PageNumber,string State)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select top " + PageSize + " * from V_User_Lecture_Place" +
                " where Id not in (select top " + (PageSize * (PageNumber - 1)) +
                " Id from V_User_Lecture_Place where (V_User_Lecture_Place.Subject" +
                " like '%" + ParamLecture + "%' or V_User_Lecture_Place.Name like '%" +
                ParamLecture + "%') and V_User_Lecture_Place.State " + State+ ") and (V_User_Lecture_Place.Subject" +
                " like '%" + ParamLecture + "%' or V_User_Lecture_Place.Name like '%" +
                ParamLecture + "%') and State "+State;
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
                user.Id = Convert.ToInt32(reader["UserId"]);
                user.Num = Convert.ToString(reader["Num"]);
                user.Name = Convert.ToString(reader["Name"]);
                user.Sex = Convert.ToInt32(reader["Sex"]);
                user.MajorClassId = Convert.ToInt32(reader["MajorClassId"]);
                Model.T_Base_MajorClass majorClass = new Model.T_Base_MajorClass();
                majorClass.Id = Convert.ToInt32(reader["MajorClassId"]);
                majorClass.MajorClassName = Convert.ToString(reader["MajorClassName"]);
                user.MajorClass = majorClass;
                user.PhoneNum = Convert.ToString(reader["PhoneNum"]);
                apply.User = user;

                Model.T_Base_Lecture lecture = new Model.T_Base_Lecture();
                lecture.Id = Convert.ToInt32(reader["LectureId"]);
                lecture.Subject = Convert.ToString(reader["Subject"]);
                lecture.Summary = Convert.ToString(reader["Summary"]);
                lecture.State = Convert.ToInt32(reader["State"]);
                lecture.QRCode = Convert.ToString(reader["QRCode"]);

                lecture.DeathLine = Convert.ToDateTime(reader["DeathLine"]);
                lecture.LectureTime = Convert.ToDateTime(reader["LectureTime"]);
                lecture.Span = Convert.ToDouble(reader["Span"]);
                lecture.ExpectPeople = Convert.ToInt32(reader["ExpectPeople"]);
                lecture.RealPeople = Convert.ToInt32(reader["RealPeople"]);
                lecture.Score = Convert.ToDouble(reader["Score"]);
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
        public int GetCount(string State)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select count(1) from V_User_Lecture_Place where State "+State;
            int count = (int)cmd.ExecuteScalar();
            config.Close();
            return count;
        }


        /// <summary>
        /// 获取指定id的讲座
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<Model.T_Base_Apply> GetLecture(int LectureId,int State)
        {
            List<Model.T_Base_Apply> list = new List<Model.T_Base_Apply>();
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            if (State == 1)
            {
                cmd.CommandText = "select * from V_User_Lecture_Place where LectureId = " + LectureId;
            }
            else if(State == 2)
            {
                cmd.CommandText = "select * from V_User_Lecture_Place_Audit where LectureId = " + LectureId;
            }
            
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
                apply.User = user;

                Model.T_Base_Lecture lecture = new Model.T_Base_Lecture();
                lecture.Id = Convert.ToInt32(reader["LectureId"]);
                lecture.Subject = Convert.ToString(reader["Subject"]);
                lecture.Summary = Convert.ToString(reader["Summary"]);
                lecture.State = Convert.ToInt32(reader["State"]);
                lecture.QRCode = Convert.ToString(reader["QRCode"]);
                lecture.DeathLine = Convert.ToDateTime(reader["DeathLine"]);
                lecture.LectureTime = Convert.ToDateTime(reader["LectureTime"]);
                lecture.Span = Convert.ToDouble(reader["Span"]);
                lecture.ExpectPeople = Convert.ToInt32(reader["ExpectPeople"]);
                lecture.RealPeople = Convert.ToInt32(reader["RealPeople"]);
                lecture.Score = Convert.ToDouble(reader["Score"]);
                if (State == 2)
                {
                    if (reader["Reason"].Equals(DBNull.Value))
                    {
                        lecture.Reason = "";
                    }
                    else
                    {
                        lecture.Reason = Convert.ToString(reader["Reason"]);
                    }
                }
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
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            int result = -1;
            try
            {
                cmd.Transaction = config.getSqlConnection().BeginTransaction();
                if (CheckDateTime(Lecture.Id,Lecture.LectureTime, Lecture.Span, AddPlaceId))
                {
                    cmd.CommandText = "insert into T_Base_Lecture " +
                        "values('" + Lecture.Subject + "','" + Lecture.Summary + "',0,-1,'" + Lecture.DeathLine + "','" +
                        Lecture.LectureTime + "'," + Lecture.Span + "," + Lecture.ExpectPeople + ",0," + Lecture.Score + ",0)";
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        cmd.Transaction.Rollback();
                        return -3;          //请确保按照格式填入全部信息
                    }
                    cmd.CommandText = "select top 1 Id from T_Base_Lecture order by Id desc";
                    result = (int)cmd.ExecuteScalar();
                    cmd.CommandText = "insert into T_Base_Apply values('" +
                        AddNum + "'," + result + "," + AddPlaceId + ",'" + DateTime.Now + "','')";
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                }else
                {
                    cmd.Transaction.Rollback();
                    return -2;          //时间冲突
                }
            }
            catch
            {
                result = -1;
            }
            config.Close();
            return result;
        }

        /// <summary>
        /// 保存修改后的信息
        /// </summary>
        /// <param name="Lecture"></param>
        /// <returns></returns>
        public int EditSaveLecture(string EditNum, int EditApplyId, Model.T_Base_Lecture Lecture, int EditPlaceId)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            int result = -1;
            try
            {
                cmd.Transaction = config.getSqlConnection().BeginTransaction();
                if (CheckDateTime(Lecture.Id,Lecture.LectureTime, Lecture.Span, EditPlaceId))
                {
                    //修改地点信息
                    cmd.CommandText = "update T_Base_Lecture set " +
                        "Subject = '" + Lecture.Subject + "', Summary = '" + Lecture.Summary +
                        "',State = 3,DeathLine = '" + Lecture.DeathLine + "',LectureTime = '" + Lecture.LectureTime +
                        "',Span = " + Lecture.Span + ",ExpectPeople = " + Lecture.ExpectPeople +
                        ",Score = " + Lecture.Score+",AlertFlag = 1 where Id = "+Lecture.Id;
                    int result1 = cmd.ExecuteNonQuery();
                    cmd.CommandText = "update T_Base_Apply set " +
                        "PlaceId = " + EditPlaceId + "where Id = "+EditApplyId;
                    int result2 = cmd.ExecuteNonQuery();
                    if(result1 == -1 && result2 == -1)
                    {
                        cmd.Transaction.Rollback();
                        result = -3;  //没有任何更新变化
                    }else
                    {
                        cmd.Transaction.Commit();
                        result = 1;
                    }
                }else
                {
                    cmd.Transaction.Rollback();
                    return -2;
                }

            }
            catch
            {
                result = -1;
            }

            config.Close();
            return result;
        }


        /// <summary>
        /// 删除讲座
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>编辑
        public int Delete(string Ids)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "delete from T_Base_Apply where Id in (" + Ids + ")";
            int result = cmd.ExecuteNonQuery();
            config.Close();
            return result;
        }

        /// <summary>
        /// 获取个人所申请的全部讲座信息
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        public List<Model.T_Base_Apply> GetPersonalAllLecture(string Num,int Role)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            if (Role == 1 || Role == 2)
            {
                cmd.CommandText = "select * from V_User_Lecture_Place order by Id desc";
            }
            else if (Role == 3)
            {
                cmd.CommandText = "select * from V_User_Lecture_Place where Num = '" + Num + "' order by Id desc";
            }
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
                apply.User = user;

                Model.T_Base_Lecture lecture = new Model.T_Base_Lecture();
                lecture.Id = Convert.ToInt32(reader["LectureId"]);
                lecture.Subject = Convert.ToString(reader["Subject"]);
                lecture.Summary = Convert.ToString(reader["Summary"]);
                lecture.State = Convert.ToInt32(reader["State"]);
                lecture.QRCode = Convert.ToString(reader["QRCode"]);
                lecture.DeathLine = Convert.ToDateTime(reader["DeathLine"]);
                lecture.LectureTime = Convert.ToDateTime(reader["LectureTime"]);
                lecture.Span = Convert.ToDouble(reader["Span"]);
                lecture.ExpectPeople = Convert.ToInt32(reader["ExpectPeople"]);
                lecture.RealPeople = Convert.ToInt32(reader["RealPeople"]);
                lecture.Score = Convert.ToDouble(reader["Score"]);
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
        /// 时间冲突检测
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="Span"></param>
        /// <param name="PlaceId"></param>
        /// <returns></returns>
        public Boolean CheckDateTime(int LectureId,DateTime StartTime,double Span,int PlaceId)
        {
            DateTime EndTime = StartTime.AddHours(Span);

            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            if (LectureId == 0)
            {
                cmd.CommandText = "select * from V_User_Lecture_Place where PlaceId = " + PlaceId
                    + " and '" + StartTime.ToString("yyyy/MM/dd") + "' = FORMAT(LectureTime,'yyyy/MM/dd') and State = 1";
            }else
            {
                cmd.CommandText = "select * from V_User_Lecture_Place where PlaceId = " + PlaceId
                    + " and '" + StartTime.ToString("yyyy/MM/dd") 
                    + "' = FORMAT(LectureTime,'yyyy/MM/dd') and State = 1 and LectureId <> " + LectureId;
            }
            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                //以添加的场地时间
                DateTime checkStart = Convert.ToDateTime(reader["LectureTime"]);
                double checkSpan = Convert.ToDouble(reader["Span"]);
                DateTime checkEnd = checkStart.AddHours(checkSpan);

                if((checkStart<StartTime && StartTime<=checkEnd) ||     //起始时间位于上一场之中
                    (StartTime<=checkEnd && checkEnd<=EndTime)||        //待加入时间中以有一场
                    (checkStart<EndTime && EndTime<=checkEnd))
                {
                    config.Close();
                    return false;
                }
            }
            config.Close();
            return true;
        }

        /// <summary>
        /// 报名
        /// </summary>
        /// <param name="Num"></param>
        /// <param name="LectureId"></param>
        /// <returns></returns>
        public int Order(string Num, int LectureId)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.Transaction = config.getSqlConnection().BeginTransaction();
            int result = -1;
            cmd.CommandText = "select count(1) from T_Base_Order where Num = "+Num+
                " and LectureId = "+LectureId;
            result = (int)cmd.ExecuteScalar();
            if(result == 1)
            {
                cmd.Transaction.Rollback();
                config.Close();
                return -2;          //以报名
            }
            cmd.CommandText = "select ExpectPeople,RealPeople from T_Base_Lecture where Id = "+LectureId;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int ExpectPeople = Convert.ToInt32(reader["ExpectPeople"]);
            int RealPeople = Convert.ToInt32(reader["RealPeople"]);
            reader.Close();
            cmd.CommandText = "update T_Base_Lecture set RealPeoPle = " + (RealPeople + 1) +
                " where Id = " + LectureId;
            cmd.ExecuteNonQuery();
            if (RealPeople < ExpectPeople)
            {
                cmd.CommandText = "insert into T_Base_Order values('" +
                    Num + "'," + LectureId + ",'" + DateTime.Now + "',1,0)";      //报名成功
                result = cmd.ExecuteNonQuery();

            }
            else
            {
                cmd.CommandText = "insert into T_Base_Order values('" +
                    Num + "'," + LectureId + ",'" + DateTime.Now + "',2,0)";      //待处理
                result = cmd.ExecuteNonQuery();
                result = 2;

                //cmd.CommandText = "";

                //MailMessage mailMessage = new MailMessage();
                //mailMessage.From = new MailAddress("15211220142@stu.wzu.edu.cn");
                //mailMessage.To.Add(new MailAddress("15211220142@stu.wzu.edu.cn"));
                //mailMessage.Subject = "报名" + subject + "成功";
                //mailMessage.Body = "因前面预约人员取消报名，报名预约成功";
                //SmtpClient client = new SmtpClient();
                //client.Host = "smtp.wzu.edu.cn";
                //client.EnableSsl = false;
                //client.UseDefaultCredentials = false;
                //client.Credentials = new NetworkCredential("15211220142@stu.wzu.edu.cn", "b5ZF36PPMMmCF883");
                //client.Send(mailMessage);
            }
            cmd.Transaction.Commit();
            config.Close();
            return result;              
        }

        /// <summary>
        /// 报名功能显示（报名，以报名，截止报名
        /// </summary>
        /// <param name="Num"></param>
        /// <param name="LectureId"></param>
        /// <returns></returns>
        ///  0报名 1以报名 2人满未处理 3时间截止 
        public int OrderSelect(string Num, int LectureId)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            int result = -1;
            cmd.CommandText = "select DeathLine from T_Base_Lecture where Id = " + LectureId;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            DateTime DeathLine = Convert.ToDateTime(reader["DeathLine"]);
            reader.Close();
            if (DeathLine < DateTime.Now)
            {
                config.Close();
                return 3;           //报名已截止
            }
            cmd.CommandText = "select count(1) from T_Base_Order where Num = " + Num +
                " and LectureId = " + LectureId;
            result = (int)cmd.ExecuteScalar();
            if (result == 1)
            {
                cmd.CommandText = "select Result from T_Base_Order where Num = " + Num +
                " and LectureId = " + LectureId;
                result = (int)cmd.ExecuteScalar();
                if (result == 2)
                {
                    return 2;               //报名成功
                }else if(result == 3){
                    return 1;               //等后续通知
                }
            }
            config.Close();
            return result;
        }

        /// <summary>
        /// 取消报名
        /// </summary>
        /// <param name="Num"></param>
        /// <param name="LectureId"></param>
        /// <returns></returns>
        public int OrderDelete(string Num, int LectureId)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            int result = -1;
            result = OrderSelect(Num, LectureId);       //查询是否有报名
            if(result == 1)
            {
                cmd.Transaction = config.getSqlConnection().BeginTransaction();
                cmd.CommandText = "select Result from T_Base_Order where Num='" + Num + "' and LectureId=" + LectureId;
                int orderResult = (int)cmd.ExecuteScalar();     //报名者的状态
                cmd.CommandText = "delete from T_Base_Order where Num = "+Num+" and LectureId = "+LectureId;
                cmd.ExecuteNonQuery();
                cmd.CommandText = "select ExpectPeople,RealPeople,Subject from T_Base_Lecture where Id = " + LectureId;
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                int ExpectPeople = Convert.ToInt32(reader["ExpectPeople"]);
                int RealPeople = Convert.ToInt32(reader["RealPeople"]);
                string subject = Convert.ToString(reader["Subject"]);
                reader.Close();
                cmd.CommandText = "update T_Base_Lecture set RealPeople = "+(RealPeople-1)+" where Id = "+LectureId;
                result = cmd.ExecuteNonQuery();     //修改讲座当前人数
                if(result == 1)                     //取消者报名的状态为报名成功
                {
                    if (RealPeople>= ExpectPeople && orderResult==1)
                    {
                        cmd.CommandText = "update T_Base_Order set Result=3,MsgFlag=0 where LectureId=" + LectureId +
                            " and Result=2 and Num=(select top(1) Num from T_Base_Order where LectureId="+LectureId+" and Result=2 order by Id asc)";
                        cmd.ExecuteNonQuery();

                        MailMessage mailMessage = new MailMessage();
                        mailMessage.From = new MailAddress("15211220142@stu.wzu.edu.cn");
                        mailMessage.To.Add(new MailAddress("15211220142@stu.wzu.edu.cn"));
                        mailMessage.Subject = "报名" + subject + "成功";
                        mailMessage.Body = "因前面预约人员取消报名，报名预约成功";
                        SmtpClient client = new SmtpClient();
                        client.Host = "smtp.wzu.edu.cn";
                        client.EnableSsl = false;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential("15211220142@stu.wzu.edu.cn", "b5ZF36PPMMmCF883");
                        client.Send(mailMessage);
                    }
                    cmd.Transaction.Commit();
                    config.Close();
                    return 1;           //取消成功
                }else
                {
                    config.Close();
                    return -1;          //取消失败
                }
            }else
            {
                config.Close();
                return -2;      //取消失败，未报名
            }

        }
    }
}
