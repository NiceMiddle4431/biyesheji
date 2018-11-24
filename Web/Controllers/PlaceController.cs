using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class PlaceController : Controller
    {
        // GET: Place
        /// <summary>
        /// 显示建筑内讲座地点信息页面
        /// </summary>
        /// <param name="ArchitectureId"></param>
        /// <returns></returns>
        public ActionResult Index(int ArchitectureId)
        {
            ViewBag.ArchitectureId = ArchitectureId;
            return View();
        }

        /// <summary>
        /// 查询建筑内可举办讲座地点（Id,地点名称，容纳人数）
        /// </summary>
        /// <param name="ArchitectureId"></param>
        /// <returns></returns>
        public JsonResult GetAllPlace(int ArchitectureId)
        {
            return Json( new BLL.T_Base_Place().GetAllPlace(ArchitectureId));
        }

        /// <summary>
        /// 保存新增地点信息
        /// </summary>
        /// <param name="AddPlaceName"></param>
        /// <param name="AddPeopleNum"></param>
        /// <param name="AddArchitectureId"></param>
        /// <returns></returns>
        public JsonResult AddSavePlace(string AddPlaceName, int AddPeopleNum,int AddArchitectureId)
        {
            Model.T_Base_Place place = new Model.T_Base_Place();
            place.PlaceName = AddPlaceName;
            place.PeopleNum = AddPeopleNum;
            place.ArchitectureId = AddArchitectureId;
            int result = new BLL.T_Base_Place().AddSavePlace(place);
            if (result == 1)
            {
                return Json("添加成功");
            }
            else
            {
                return Json("添加失败");
            }
        }

        /// <summary>
        /// 获取指定Id的地点信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult GetPlace(int Id)
        {
            return Json(new BLL.T_Base_Place().GetPlace(Id));
        }

        /// <summary>
        /// 保存修改后的信息
        /// </summary>
        /// <param name="AddPlaceName"></param>
        /// <param name="AddPeopleNum"></param>
        /// <param name="AddArchitectureId"></param>
        /// <returns></returns>
        public JsonResult EditSavePlace(int EditId,string EditPlaceName, int EditPeopleNum, int EditArchitectureId)
        {
            Model.T_Base_Place place = new Model.T_Base_Place();
            place.Id = EditId;
            place.PlaceName = EditPlaceName;
            place.PeopleNum = EditPeopleNum;
            place.ArchitectureId = EditArchitectureId;
            int result = new BLL.T_Base_Place().EditSavePlace(place);
            if (result == 1)
            {
                return Json("修改成功");
            }
            else
            {
                return Json("修改失败");
            }
        }
    }
}