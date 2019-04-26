using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class T_Base_Resource
    {
        public List<Model.T_Base_Resource> GetAllResource(int LectureId) {

            List<Model.T_Base_Resource> list = new List<Model.T_Base_Resource>();
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select * from T_Base_Resource where LectureId = "+ LectureId;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Model.T_Base_Resource resource = new Model.T_Base_Resource();
                resource.Id = Convert.ToInt32(reader["Id"]);
                resource.Num = Convert.ToString(reader["Num"]);
                resource.LectureId = Convert.ToInt32(reader["LectureId"]);
                resource.Content = Convert.ToString(reader["Content"]);

                if (reader["FilePosition1"].Equals(DBNull.Value))
                    resource.FilePosition1 = Convert.ToString(DBNull.Value);
                else
                    resource.FilePosition1 = Convert.ToString(reader["FilePosition1"]);

                if (reader["ResourceDate"].Equals(DBNull.Value))
                    resource.ResourceDate = Convert.ToDateTime(null);
                else
                    resource.ResourceDate = Convert.ToDateTime(reader["ResourceDate"]);

                resource.ReviewFlag = Convert.ToInt16(reader["ReviewFlag"]);

                list.Add(resource);
            }
            reader.Close();
            config.Close();
            return list;
        }


        public int Delete(string Ids)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "delete from T_Base_Resource where Id in (" + Ids + ")";
            int result = cmd.ExecuteNonQuery();
            config.Close();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Resource"></param>
        /// <returns></returns>
        public int AddSaveResource(Model.T_Base_Resource Resource)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "insert into T_Base_Resource values('"
                + Resource.Num + "'," + Resource.LectureId + ",'" + Resource.Content + "','" +
                Resource.FilePosition1 + "','" + Resource.FilePosition2 + "','" +
                Resource.FilePosition3 + "','" + DateTime.Now + "',0,0)";
            int result = cmd.ExecuteNonQuery();
            config.Close();
            return result;
        }

        /// <summary>
        /// 举报隐藏信息
        /// </summary>
        /// <param name="ResourceId"></param>
        /// <returns></returns>
        public int ResourceReport(int ResourceId)
        {
            int result = -1;
            SqlConfig config = new DAL.SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "update T_Base_Resource set ReViewFlag = 1";
            result = cmd.ExecuteNonQuery();
            config.Close();
            return result;
        }


        public List<Model.T_Base_Resource> GetAllResourceReport()
        {

            List<Model.T_Base_Resource> list = new List<Model.T_Base_Resource>();
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select * from T_Base_Resource where ReviewFlag =  1";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Model.T_Base_Resource resource = new Model.T_Base_Resource();
                resource.Id = Convert.ToInt32(reader["Id"]);
                resource.Num = Convert.ToString(reader["Num"]);
                resource.LectureId = Convert.ToInt32(reader["LectureId"]);
                resource.Content = Convert.ToString(reader["Content"]);

                if (reader["FilePosition1"].Equals(DBNull.Value))
                    resource.FilePosition1 = Convert.ToString(DBNull.Value);
                else
                    resource.FilePosition1 = Convert.ToString(reader["FilePosition1"]);

                if (reader["ResourceDate"].Equals(DBNull.Value))
                    resource.ResourceDate = Convert.ToDateTime(null);
                else
                    resource.ResourceDate = Convert.ToDateTime(reader["ResourceDate"]);

                resource.ReviewFlag = Convert.ToInt16(reader["ReviewFlag"]);

                list.Add(resource);
            }
            reader.Close();
            config.Close();
            return list;
        }


        public int UpdateResource(string Ids)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "update T_Base_Resource set ReviewFlag = 0 where Id in (" + Ids + ")";
            int result = cmd.ExecuteNonQuery();
            config.Close();
            return result;
        }
    }
}
