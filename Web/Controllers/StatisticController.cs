using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Web.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistics
        public ActionResult Index(int LectureId)
        {
            ViewBag.LectureId = LectureId;
            return View();
        }

        public JsonResult AddSaveStatistic(string Num,int LectureId,string Ip)
        {
            int result = new BLL.Statistic().AddSaveStatistic(Num,LectureId, Ip);
            if(result == 1)
            {
                return Json("签到成功");
            }
            else if (result == 2)
            {
                return Json("签退成功");
            }
            else if (result == -2)
            {
                return Json("未签到");
            }
            else if (result == -3)
            {
                return Json("存在代签情况");
            }
            else if (result == -1)
            {
                return Json("签到失败");
            }
            else
            {
                return Json("");
            }
        }


        /// <summary>
        /// 出席讲座查询
        /// </summary>
        public ActionResult Attendance(string Num)
        {
            ViewBag.Num = Num;
            ViewBag.Score = new BLL.Statistic().GetScore(Num);
            return View();
        }

        /// <summary>
        /// 查询出席的讲座     State 0全部，1签到签退分数成功
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        public JsonResult GetAllAttendance(string Num,int State)
        {
            return Json(new BLL.Statistic().GetAllAttendance(Num, State));
        }


        /// <summary>
        /// 生成Excel文件并发给客户端
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        public FileResult SaveAllAttendanceExcel(string Num)
        {
            List<Model.T_Base_Statistic> list = new BLL.Statistic().GetAllAttendance(Num,0);
            HSSFWorkbook book = new HSSFWorkbook();             //创建Excel文件对象
            ISheet sheet = book.CreateSheet(Num+"参加讲座情况");//创建一个sheet页
            //给sheet1添加第一行的头部标题
            IRow row1 = sheet.CreateRow(0);
            row1.CreateCell(0).SetCellValue("讲座主题");
            row1.CreateCell(1).SetCellValue("讲座开始时间");
            row1.CreateCell(2).SetCellValue("持续时间");
            row1.CreateCell(3).SetCellValue("参与人数");
            row1.CreateCell(4).SetCellValue("可获学分");
            row1.CreateCell(5).SetCellValue("签到时间");
            row1.CreateCell(6).SetCellValue("签退时间");
            for (int i = 0; i < list.Count; i++)
            {
                IRow row = sheet.CreateRow(i+1);
                row.CreateCell(0).SetCellValue(list[i].Lecture.Subject);
                row.CreateCell(1).SetCellValue(list[i].Lecture.LectureTime.ToString("yyyy/MM/dd HH:mm:ss"));
                row.CreateCell(2).SetCellValue(list[i].Lecture.Span);
                row.CreateCell(3).SetCellValue(list[i].Lecture.RealPeople);
                row.CreateCell(4).SetCellValue(list[i].Lecture.Score);
                row.CreateCell(5).SetCellValue(list[i].StartTime.ToString("yyyy/MM/dd HH:mm:ss"));
                if (list[i].EndTime.ToString("yyyy/MM/dd HH:mm:ss").Equals("1900/01/01 00:00:00"))
                {
                    row.CreateCell(6).SetCellValue("未签退");
                }else
                {
                    row.CreateCell(6).SetCellValue(list[i].EndTime.ToString("yyyy/MM/dd HH:mm:ss"));
                }
            }
            sheet.SetColumnWidth(0, 30 * 256);
            sheet.SetColumnWidth(1, 23 * 256);
            sheet.SetColumnWidth(2, 8 * 256);
            sheet.SetColumnWidth(3, 8 * 256);
            sheet.SetColumnWidth(4, 8 * 256);
            sheet.SetColumnWidth(5, 23 * 256);
            sheet.SetColumnWidth(6, 23 * 256);

            MemoryStream ms = new MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            return File(ms, "application/vnd.ms-excel", Num+"参加讲座情况.xls");
        }


        /// <summary>
        /// 统计参与讲座人员信息 生成Excel文件并发给客户端
        /// </summary>
        /// <param name="LectureId"></param>
        /// <returns></returns>
        public FileResult SavePeopleExcel(int LectureIdExcel, string AllExcel = "", string NumExcel = "",
            string NameExcel = "", string SexExcel = "", string PhoneNumExcel = "", string MajorClassExcel = "",
            string ArchitectureExcel = "", string OrderExcel = "", string StartTimeExcel = "", string EndTimeExcel = "")
        {
            List<Model.T_Base_Statistic> list = new BLL.Statistic().SavePeopleExcel(LectureIdExcel);
            Model.T_Base_Lecture lecture = new BLL.T_Base_Lecture().GetLecture(LectureIdExcel, 1)[0].Lecture;
            HSSFWorkbook book = new HSSFWorkbook();             //创建Excel文件对象
            ISheet sheet = book.CreateSheet(lecture.Subject + "讲座情况");//创建一个sheet页
            //给sheet1添加第一行的头部标题
            IRow row1 = sheet.CreateRow(0);

            if(AllExcel == "*")
            {
                row1.CreateCell(0).SetCellValue("学号");
                row1.CreateCell(1).SetCellValue("姓名");
                row1.CreateCell(2).SetCellValue("性别");
                row1.CreateCell(3).SetCellValue("联系方式");
                row1.CreateCell(4).SetCellValue("班级");
                row1.CreateCell(5).SetCellValue("学院");
                row1.CreateCell(6).SetCellValue("是否有预报名");
                row1.CreateCell(7).SetCellValue("签到时间");
                row1.CreateCell(8).SetCellValue("签退时间");
                sheet.SetColumnWidth(0, 15 * 256);
                sheet.SetColumnWidth(1, 10 * 256);
                sheet.SetColumnWidth(2, 6 * 256);
                sheet.SetColumnWidth(3, 15 * 256);
                sheet.SetColumnWidth(4, 15 * 256);
                sheet.SetColumnWidth(5, 30 * 256);
                sheet.SetColumnWidth(6, 15 * 256);
                sheet.SetColumnWidth(7, 20 * 256);
                sheet.SetColumnWidth(8, 20 * 256);
                for (int i = 0; i < list.Count; i++)
                {
                    IRow row = sheet.CreateRow(i + 1);
                    row.CreateCell(0).SetCellValue(list[i].User.Num);
                    row.CreateCell(1).SetCellValue(list[i].User.Name);
                    list[i].Order = new BLL.Statistic().SelectOrder(list[i].Num, LectureIdExcel);
                    if (list[i].User.Sex == 0)
                    {
                        row.CreateCell(2).SetCellValue("女");
                    }
                    else if (list[i].User.Sex == 1)
                    {
                        row.CreateCell(2).SetCellValue("男");
                    }
                    row.CreateCell(3).SetCellValue(list[i].User.PhoneNum);
                    row.CreateCell(4).SetCellValue(list[i].User.MajorClass.MajorClassName);
                    row.CreateCell(5).SetCellValue(list[i].User.MajorClass.Architecture.ArchitectureName);
                    if (list[i].Order == 1)
                    {
                        row.CreateCell(6).SetCellValue("是");
                    }
                    else if (list[i].Order == 0)
                    {
                        row.CreateCell(6).SetCellValue("否");
                    }
                    row.CreateCell(7).SetCellValue(list[i].StartTime.ToString("yyyy/MM/dd HH:mm:ss"));
                    row.CreateCell(8).SetCellValue(list[i].StartTime.ToString("yyyy/MM/dd HH:mm:ss"));
                }
            }else if (AllExcel == "")
            {
                int count = 0;
                int num=-1,name=-1,sex=-1,phoneNum=-1,majorClass=-1,
                    architectureName=-1,order=-1,startTime=-1,endTime = -1;

                if (NumExcel == "Num")
                {
                    row1.CreateCell(count).SetCellValue("学号");
                    sheet.SetColumnWidth(count, 15 * 256);
                    num = count;
                    count++;
                }
                if (NameExcel == "Name")
                {
                    row1.CreateCell(count).SetCellValue("姓名");
                    sheet.SetColumnWidth(count, 10 * 256);
                    name = count;
                    count++;
                }
                if (SexExcel == "Sex")
                {
                    row1.CreateCell(count).SetCellValue("性别");
                    sheet.SetColumnWidth(count, 6 * 256);
                    sex = count;
                    count++;
                }
                if (PhoneNumExcel == "PhoneNum")
                {
                    row1.CreateCell(count).SetCellValue("联系方式");
                    sheet.SetColumnWidth(count, 15 * 256);
                    phoneNum = count;
                    count++;
                }
                if (MajorClassExcel == "MajorClass")
                {
                    row1.CreateCell(count).SetCellValue("班级");
                    sheet.SetColumnWidth(count, 15 * 256);
                    majorClass = count;
                    count++;
                }
                if (ArchitectureExcel == "Architecture")
                {
                    row1.CreateCell(count).SetCellValue("学院");
                    sheet.SetColumnWidth(count, 30 * 256);
                    architectureName = count;
                    count++;
                }
                if (OrderExcel == "Order")
                {
                    row1.CreateCell(count).SetCellValue("是否有预报名");
                    sheet.SetColumnWidth(count, 15 * 256);
                    order = count;
                    count++;
                }
                if (StartTimeExcel == "StartTime")
                {
                    row1.CreateCell(count).SetCellValue("到场时间");
                    sheet.SetColumnWidth(count, 20 * 256);
                    startTime = count;
                    count++;
                }
                if (EndTimeExcel == "EndTime")
                {
                    row1.CreateCell(count).SetCellValue("退场时间");
                    sheet.SetColumnWidth(count, 20 * 256);
                    endTime = count;
                    count++;
                }
                for (int i = 0; i < list.Count; i++)
                {
                    IRow row = sheet.CreateRow(i + 1);
                    if (num != -1)
                    {
                        row.CreateCell(num).SetCellValue(list[i].User.Num);
                    }
                    if (name != -1)
                    {
                        row.CreateCell(name).SetCellValue(list[i].User.Name);
                    }
                    if (sex != -1)
                    {
                        if (list[i].User.Sex == 0)
                        {
                            row.CreateCell(sex).SetCellValue("女");
                        }
                        else if (list[i].User.Sex == 1)
                        {
                            row.CreateCell(sex).SetCellValue("男");
                        }
                    }
                    if (phoneNum != -1)
                    {
                        row.CreateCell(phoneNum).SetCellValue(list[i].User.PhoneNum);
                    }
                    if (majorClass != -1)
                    {
                        row.CreateCell(majorClass).SetCellValue(list[i].User.MajorClass.MajorClassName);
                    }
                    if (architectureName != -1)
                    {
                        row.CreateCell(architectureName).SetCellValue(list[i].User.MajorClass.Architecture.ArchitectureName);
                    }
                    if (order != -1)
                    {
                        list[i].Order = new BLL.Statistic().SelectOrder(list[i].Num, LectureIdExcel);
                        if (list[i].Order == 1)
                        {
                            row.CreateCell(order).SetCellValue("是");
                        }
                        else if (list[i].Order == 0)
                        {
                            row.CreateCell(order).SetCellValue("否");
                        }
                    }
                    if (startTime != -1)
                    {
                        row.CreateCell(startTime).SetCellValue(list[i].StartTime.ToString("yyyy/MM/dd HH:mm:ss"));
                    }
                    if (endTime != -1)
                    {
                        row.CreateCell(endTime).SetCellValue(list[i].EndTime.ToString("yyyy/MM/dd HH:mm:ss"));
                    }
                }
            }

            MemoryStream ms = new MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            return File(ms, "application/vnd.ms-excel", lecture.Subject + "讲座情况.xls");
        }
    }
}