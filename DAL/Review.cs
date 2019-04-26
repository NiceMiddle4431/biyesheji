using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QRCoder;
using System.Drawing;
using System.Net;
using System.Net.Mail;

namespace DAL
{
    public class Review
    {
        /// <summary>
        /// 审核处理
        /// </summary>
        /// <param name="ApplyId"></param>
        /// <param name="LectureId"></param>
        /// <param name="State"></param>
        /// <param name="Num"></param>
        /// <param name="Reason"></param>
        /// <returns></returns>
        public int Review_Updata(int ApplyId,int LectureId, int State, string Num, string ReviewNum, string Reason = "")
        {

            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "select State from T_Base_Lecture Where Id = " +LectureId ;
            int oldState = (int)cmd.ExecuteScalar();

            cmd.CommandText = "update T_Base_Lecture set State = "+State+" where T_Base_Lecture.Id = "+
                "(select LectureId from T_Base_Apply where T_Base_Apply.Id = "+ ApplyId + ")";
            int result = cmd.ExecuteNonQuery();
            if(State == 2)
            {
                cmd.CommandText = "insert into T_Base_Audit values('"+Num
                    +"',"+ LectureId + ",'"+Reason+"','"+DateTime.Now+"','"+ReviewNum+"')";
                result = cmd.ExecuteNonQuery();
            }
            if (State == 1)
            {
                //更新二维码
                QRCodeSave("" + LectureId);
                cmd.CommandText = "update T_Base_Lecture set QRCode = " + LectureId + " where Id = " + LectureId;
                cmd.ExecuteNonQuery();
                //更新处理人账号
                cmd.CommandText = "update T_Base_Apply set ReviewNum = '"+ReviewNum+"' where Id="+ApplyId;
                cmd.ExecuteNonQuery();
            }
            if(oldState == 3 && State == 1)
            {
                //通知报名人员
                cmd.CommandText = "select Subject,ExpectPeople,RealPeople from T_Base_Lecture where Id = " + LectureId;
                reader = cmd.ExecuteReader();
                reader.Read();
                string subject = Convert.ToString(reader["Subject"]);
                int expectPeople = Convert.ToInt16(reader["ExpectPeople"]);
                int realPeople = Convert.ToInt16(reader["RealPeople"]);
                reader.Close();

                //获取报名参加人员
                cmd.CommandText = "select Num from T_Base_Order where LectureId = " + LectureId;
                reader = cmd.ExecuteReader();
                List<Model.T_Base_Order> listOrder = new List<Model.T_Base_Order>();
                while (reader.Read())
                {
                    Model.T_Base_Order order = new Model.T_Base_Order();
                    Model.T_Base_User user = new DAL.T_Base_User().GetUser(Convert.ToString(reader["Num"]));
                    order.User = user;
                    listOrder.Add(order);
                }
                reader.Close();
                //发送消息
                for (int i = 0; i < listOrder.Count; i++)
                {
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("15211220142@stu.wzu.edu.cn");
                    mailMessage.To.Add(new MailAddress("15211220142@stu.wzu.edu.cn"));
                    //mailMessage.To.Add(listOrder[i].Num+"@stu.wzu.edu.cn");
                    mailMessage.Subject = subject + "地点变更通知";
                    mailMessage.Body = "您所报名参加的讲座" + subject + "信息发生变更，请注意查看";
                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.wzu.edu.cn";
                    client.EnableSsl = false;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("15211220142@stu.wzu.edu.cn", "b5ZF36PPMMmCF883");
                    client.Send(mailMessage);
                }
            }
            return result;
        }

        /// <summary>
        /// 二维码生成保存
        /// </summary>
        /// <param name="strQRCodeName"></param>
        private void QRCodeSave(string strQRCodeName)
        {
            string strCode = "http://212.64.18.220:1234/Statistic/Index?LectureId=" + strQRCodeName;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(strCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            Bitmap qrCodeImage = qrCode.GetGraphic(5, Color.Black, Color.White, null, 15, 6, false);
            qrCodeImage.Save("D:\\VS2015解决方案\\毕业设计\\bysj\\Web\\QRCode\\" + strQRCodeName + ".jpg");
        }
    }
}
