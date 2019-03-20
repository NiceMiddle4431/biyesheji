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
        /// 查询建筑内可举办讲座地点（Id,地点名称，容纳人数）
        /// </summary>
        /// <param name="ArchitectureId"></param>
        /// <returns></returns>
        public List<Model.T_Base_Place> GetAllPlace(int ArchitectureId)
        {
            List<Model.T_Base_Place> list = new List<Model.T_Base_Place>();
            sqlConfig config = new sqlConfig();
            SqlCommand cmd = config.getSqlCommand();
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
            config.Close();
            return list;
        }

        /// <summary>
        /// 保存新增地点信息
        /// </summary>
        /// <param name="place"></param>
        /// <returns></returns>
        public int AddSavePlace(Model.T_Base_Place Place)
        {
            sqlConfig config = new sqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "insert into T_Base_Place values('"+Place.PlaceName+"',"+
                Place.PeopleNum+","+Place.ArchitectureId+")";
            int result = cmd.ExecuteNonQuery();
            config.Close();
            return result;
        }

        /// <summary>
        /// 获取指定Id的地点信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Model.T_Base_Place GetPlace(int Id)
        {
            sqlConfig config = new sqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select * from V_Place_Architecture where Id = " + Id;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Model.T_Base_Place place = new Model.T_Base_Place();
            place.Id = Convert.ToInt32(reader["Id"]);
            place.PlaceName = Convert.ToString(reader["PlaceName"]);
            place.PeopleNum = Convert.ToInt32(reader["PeopleNum"]);
            place.ArchitectureId = Convert.ToInt32(reader["ArchitectureId"]);
            Model.T_Base_Architecture architecture = new Model.T_Base_Architecture();
            architecture.Id = Convert.ToInt32(reader["ArchitectureId"]);
            architecture.ArchitectureName = Convert.ToString(reader["ArchitectureName"]);
            place.Architecture = architecture;
            config.Close();
            return place;
        }

        /// <summary>
        /// 保存修改后的场地信息
        /// </summary>
        /// <param name="Place"></param>
        /// <returns></returns>
        public int EditSavePlace(Model.T_Base_Place Place)
        {
            sqlConfig config = new sqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "update T_Base_Place set PlaceName = '"+Place.PlaceName
                +"',PeopleNum = "+Place.PeopleNum+",ArchitectureId = "+Place.ArchitectureId
                +" where Id = "+Place.Id;
            int result = cmd.ExecuteNonQuery();
            config.Close();
            return result;
        }

        /// <summary>
        /// 删除场地
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Delete(string Ids)
        {
            sqlConfig config = new sqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "delete from T_Base_Place where Id in ("+Ids+")";
            int result = cmd.ExecuteNonQuery();
            config.Close();
            return result;
        }


    }
}
