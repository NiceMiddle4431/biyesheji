using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class T_Base_Architecture
    {
        /// <summary>
        /// 获取全部建筑
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageNumber"></param>
        /// <returns></returns>
        public List<Model.T_Base_Architecture> GetAllArchitecture()
        {
            List<Model.T_Base_Architecture> list = new List<Model.T_Base_Architecture>();
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select * from T_Base_Architecture";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Model.T_Base_Architecture architecture = new Model.T_Base_Architecture();
                architecture.Id = Convert.ToInt32(reader["Id"]);
                architecture.ArchitectureName = Convert.ToString(reader["ArchitectureName"]);
                architecture.IsCollege = Convert.ToInt32(reader["IsCollege"]);
                list.Add(architecture);
            }
            reader.Close();
            config.Close();
            return list;
        }


        /// <summary>
        /// 保存新增地点信息
        /// </summary>
        /// <param name="Architecture"></param>
        /// <returns></returns>
        public int AddSaveArchitecture(Model.T_Base_Architecture Architecture)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "insert into T_Base_Architecture values('" 
                + Architecture.ArchitectureName + "',"+Architecture.IsCollege+")";
            int result = cmd.ExecuteNonQuery();
            config.Close();
            return result;
        }

        /// <summary>
        /// 根据Id获取指定建筑信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Model.T_Base_Architecture GetArchitecture(int Id)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select * from T_Base_Architecture where Id = "+Id;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Model.T_Base_Architecture architecture = new Model.T_Base_Architecture();
            architecture.Id = Convert.ToInt32(reader["Id"]);
            architecture.ArchitectureName = Convert.ToString(reader["ArchitectureName"]);
            architecture.IsCollege = Convert.ToInt32(reader["IsCollege"]);
            reader.Close();
            config.Close();
            return architecture;
        }

        /// <summary>
        /// 保存修改后建筑的信息
        /// </summary>
        /// <param name="Architecture"></param>
        /// <returns></returns>
        public int EditSaveArchitecture(Model.T_Base_Architecture Architecture)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "update T_Base_Architecture set ArchitectureName = '" 
                + Architecture.ArchitectureName+"',IsCollege = "+Architecture.IsCollege+
                " where Id = "+Architecture.Id;
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
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "delete from T_Base_Place where ArchitectureId in (" + Ids + ")";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "delete from T_Base_Architecture where id in (" + Ids + ")";
            int result = cmd.ExecuteNonQuery();
            config.Close();
            return result;
        }

        /// <summary>
        /// 获取学院下全部学生
        /// </summary>
        /// <param name="ArchitectureId"></param>
        /// <returns></returns>
        public List<Model.T_Base_User> GetAllUser(int ArchitectureId)
        {
            List<Model.T_Base_User> list = new List<Model.T_Base_User>();
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select * from V_User_MajorClass_Architecture where ArchitectureId = " + ArchitectureId+ " order by MajorClassName";
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
