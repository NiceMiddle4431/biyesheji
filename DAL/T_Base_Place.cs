using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class T_Base_Place
    {
        /// <summary>
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
        /// 查询建筑内可举办讲座地点（Id,地点名称，容纳人数）
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageNumber"></param>
        /// <param name="ArchitectureId"></param>
        /// <returns></returns>
        public List<Model.T_Base_Place> GetPlace(int ArchitectureId)
        {
            List<Model.T_Base_Place> list = new List<Model.T_Base_Place>();
            SqlConnection co = SqlServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "select * from T_Base_Place where ArchitectureId = "+ ArchitectureId;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Model.T_Base_Place place = new Model.T_Base_Place();
                place.Id = Convert.ToInt32(reader["Id"]);
                place.PlaceName = Convert.ToString(reader["PlaceName"]);
                place.PeopleNum = Convert.ToInt32(reader["PeopleNum"]);
                list.Add(place);
            }
            reader.Close();
            co.Close();
            return list;
        }



    }
}
