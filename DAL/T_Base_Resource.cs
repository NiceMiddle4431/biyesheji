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

                if (reader["FilePosition2"].Equals(DBNull.Value))
                    resource.FilePosition2 = Convert.ToString(DBNull.Value);
                else
                    resource.FilePosition2 = Convert.ToString(reader["FilePosition2"]);

                if (reader["FilePosition3"].Equals(DBNull.Value))
                    resource.FilePosition3 = Convert.ToString(DBNull.Value);
                else
                    resource.FilePosition3 = Convert.ToString(reader["FilePosition3"]);

                if (reader["ResourceDate"].Equals(DBNull.Value))
                    resource.ResourceDate = Convert.ToDateTime(null);
                else
                    resource.ResourceDate = Convert.ToDateTime(reader["ResourceDate"]);

                list.Add(resource);
            }
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


        public int AddSaveResource(Model.T_Base_Resource Resource)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "insert into T_Base_Resource values('"
                + Resource.Num + "'," + Resource.LectureId + ",'" + Resource.Content + "','" +
                Resource.FilePosition1 + "','" + Resource.FilePosition2 + "','" +
                Resource.FilePosition3 + "','" + DateTime.Now + "')";
            int result = cmd.ExecuteNonQuery();
            config.Close();
            return result;
        }
    }
}
