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
            return View();
        }

        /// <summary>
        /// 查询出席的讲座
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        public JsonResult GetAllAttendance(string Num)
        {
            return Json(new BLL.Statistic().GetAllAttendance(Num));
        }


        public FileResult SaveAllAttendanceExcel(string Num)
        {
            List<Model.T_Base_Statistic> list = new BLL.Statistic().GetAllAttendance(Num);
            HSSFWorkbook book = new HSSFWorkbook();             //创建Excel文件对象
            ISheet sheet = book.CreateSheet(Num+"参加讲座情况");//创建一个sheet页
            //给sheet1添加第一行的头部标题
            IRow row1 = sheet.CreateRow(0);
            row1.CreateCell(0).SetCellValue("讲座主题");
            row1.CreateCell(1).SetCellValue("讲座开始时间");
            row1.CreateCell(2).SetCellValue("持续时间");
            row1.CreateCell(3).SetCellValue("参与人数");
            row1.CreateCell(4).SetCellValue("学分");
            row1.CreateCell(5).SetCellValue("签到时间");
            row1.CreateCell(6).SetCellValue("签退时间");
            for (int i = 0; i < list.Count; i++)
            {
                IRow row = sheet.CreateRow(i+1);
                row.CreateCell(0).SetCellValue(list[i].Lecture.Subject);
                row.CreateCell(1).SetCellValue(list[i].Lecture.LectureTime);
                row.CreateCell(2).SetCellValue(list[i].Lecture.Span);
                row.CreateCell(3).SetCellValue(list[i].Lecture.RealPeople);
                row.CreateCell(4).SetCellValue(list[i].Lecture.Score);
                row.CreateCell(5).SetCellValue(list[i].StartTime);
                if (list[i].EndTime.Equals(("1900/1/1 0:00:00")))
                {
                    row.CreateCell(6).SetCellValue("未签到");
                }else
                {
                    row.CreateCell(6).SetCellValue(list[i].EndTime);
                }
            }
            MemoryStream ms = new MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            return File(ms, "application/vnd.ms-excel", Num+"参加讲座情况.xlsx");
        }
    }
}