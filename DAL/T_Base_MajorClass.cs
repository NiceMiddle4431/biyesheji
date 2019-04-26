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
        /// 获取全部讲座信息
        /// </summary>
        /// <param name="ArchitectureId"></param>
        /// <returns></returns>
        public List<Model.T_Base_MajorClass> GetAllMajorClass(int ArchitectureId)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
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
            config.Close();
            return list;
        }


        /// <summary>
        /// 保存添加的专业班级信息
        /// </summary>
        /// <param name="majorClass"></param>
        /// <returns></returns>
        public int AddSaveMajorClass(Model.T_Base_MajorClass MajorClass)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "insert into T_Base_MajorClass values ('"+
                MajorClass.MajorClassName+"',"+MajorClass.ArchitectureId+")";
            int result = cmd.ExecuteNonQuery();
            config.Close();
            return result;
        }


        /// <summary>
        /// 获取指定Id的专业班级信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.T_Base_MajorClass GetMajorClass(int id)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select * from T_Base_MajorClass where Id = " + id;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            Model.T_Base_MajorClass majorClass = new Model.T_Base_MajorClass();
            majorClass.Id = Convert.ToInt32(reader["Id"]);
            majorClass.MajorClassName = Convert.ToString(reader["MajorClassName"]);
            majorClass.ArchitectureId = Convert.ToInt32(reader["ArchitectureId"]);

            reader.Close();
            config.Close();
            return majorClass;
        }


        /// <summary>
        /// 保存修改后的信息
        /// </summary>
        /// <param name="MajorClass"></param>
        /// <returns></returns>
        public int EditSaveMajorClass(Model.T_Base_MajorClass MajorClass)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "update T_Base_MajorClass set majorClassName = '"+
                MajorClass.MajorClassName+"',ArchitectureId = "+MajorClass.ArchitectureId+
                " where Id = "+MajorClass.Id;
            int result = cmd.ExecuteNonQuery();
            config.Close();
            return result;
        }


        /// <summary>
        /// 删除讲座
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Delete(string Ids)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "delete from T_Base_MajorClass where Id in (" + Ids + ")";
            int result = cmd.ExecuteNonQuery();
            config.Close();
            return result;
        }


        /// <summary>
        /// 获取该班级全部学生
        /// </summary>
        /// <param name="MajorClssId"></param>
        /// <returns></returns>
        public List<Model.T_Base_User> GetAllUser(int MajorClassId)
        {
            List<Model.T_Base_User> list = new List<Model.T_Base_User>();
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select * from V_User_MajorClass_Architecture where MajorClassId = " + MajorClassId + " order by Num";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Model.T_Base_User user = new Model.T_Base_User();
                user.Num = Convert.ToString(reader["Num"]);
                user.Name = Convert.ToString(reader["Name"]);
                user.Sex = Convert.ToInt16(reader["Sex"]);
                user.PhoneNum = Convert.ToString(reader["PhoneNum"]);

                Model.T_Base_MajorClass majorClass = new Model.T_Base_MajorClass();
                majorClass.MajorClassName = Convert.ToString(reader["MajorClassName"]);

                Model.T_Base_Architecture architecture = new Model.T_Base_Architecture();
                architecture.ArchitectureName = Convert.ToString(reader["ArchitectureName"]);

                majorClass.Architecture = architecture;
                user.MajorClass = majorClass;
                list.Add(user);
            }
            reader.Close();
            config.Close();
            return list;
        }
    }
}
