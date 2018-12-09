using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class T_Base_MajorClass
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
        /// 获取全部讲座信息
        /// </summary>
        /// <param name="ArchitectureId"></param>
        /// <returns></returns>
        public List<Model.T_Base_MajorClass> GetAllMajorClass(int ArchitectureId)
        {
            SqlConnection co = SqlServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "select * from T_Base_MajorClass where ArchitectureId = "+ArchitectureId;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Model.T_Base_MajorClass> list = new List<Model.T_Base_MajorClass>();
            while (reader.Read())
            {
                Model.T_Base_MajorClass majorClass = new Model.T_Base_MajorClass();
                majorClass.Id = Convert.ToInt32(reader["Id"]);
                majorClass.MajorClassName = Convert.ToString(reader["MajorClassName"]);
                majorClass.ArchitectureId = Convert.ToInt32(reader["ArchitectureId"]);
                list.Add(majorClass);
            }
            reader.Close();
            co.Close();
            return list;
        }


        /// <summary>
        /// 保存添加的专业班级信息
        /// </summary>
        /// <param name="majorClass"></param>
        /// <returns></returns>
        public int AddSaveMajorClass(Model.T_Base_MajorClass MajorClass)
        {
            SqlConnection co = SqlServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "insert into T_Base_MajorClass values ('"+
                MajorClass.MajorClassName+"',"+MajorClass.ArchitectureId+")";
            int result = cmd.ExecuteNonQuery();
            co.Close();
            return result;
        }


        /// <summary>
        /// 获取指定Id的专业班级信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.T_Base_MajorClass GetMajorClass(int id)
        {
            SqlConnection co = SqlServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "select * from T_Base_MajorClass where Id = " + id;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            Model.T_Base_MajorClass majorClass = new Model.T_Base_MajorClass();
            majorClass.Id = Convert.ToInt32(reader["Id"]);
            majorClass.MajorClassName = Convert.ToString(reader["MajorClassName"]);
            majorClass.ArchitectureId = Convert.ToInt32(reader["ArchitectureId"]);

            reader.Close();
            co.Close();
            return majorClass;
        }


        /// <summary>
        /// 保存修改后的信息
        /// </summary>
        /// <param name="MajorClass"></param>
        /// <returns></returns>
        public int EditSaveMajorClass(Model.T_Base_MajorClass MajorClass)
        {
            SqlConnection co = SqlServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "update T_Base_MajorClass set majorClassName = '"+
                MajorClass.MajorClassName+"',ArchitectureId = "+MajorClass.ArchitectureId+
                " where Id = "+MajorClass.Id;
            int result = cmd.ExecuteNonQuery();
            co.Close();
            return result;
        }


        /// <summary>
        /// 删除讲座
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Delete(string Ids)
        {
            SqlConnection co = SqlServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "delete from T_Base_MajorClass where Id in (" + Ids + ")";
            int result = cmd.ExecuteNonQuery();
            co.Close();
            return result;
        }



    }
}
