using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class T_Base_User
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
        /// 按查询信息给出分页学生信息
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageNumber"></param>
        /// <param name="StudentNum"></param>
        /// <param name="StudentName"></param>
        /// <param name="ClassName"></param>
        /// <returns></returns>
        public List<Model.T_Base_User> GetAllUser(int PageSize, int PageNumber,
            string Num, string Name, string MajorClassName)
        {
            Num = "'%" + Num + "%'";
            Name = "'%" + Name + "%'";
            MajorClassName = "'%" + MajorClassName + "%'";

            SqlConnection co = SqlServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "select top " + PageSize +
                " * from [V_User_MajorClass_Architecture] where Id not in (select top " + (PageNumber - 1) * PageSize +
                " Id from [V_User_MajorClass_Architecture] where MajorClassName like " + MajorClassName + 
                " and Num like " + Num + " and Name like " + Name +
                ")and MajorClassName like " + MajorClassName + " and Num like " + Num + 
                " and Name like " + Name;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Model.T_Base_User> list = new List<Model.T_Base_User>();
            while (reader.Read())
            {
                Model.T_Base_User user = new Model.T_Base_User();
                Model.T_Base_MajorClass majorClass = new Model.T_Base_MajorClass();
                Model.T_Base_Architecture architecture = new Model.T_Base_Architecture();

                user.Id = Convert.ToInt32(reader["Id"]);
                user.Num = Convert.ToString(reader["Num"]);
                user.Name = Convert.ToString(reader["Name"]);
                user.Sex = Convert.ToInt32(reader["Sex"]);
                user.MajorClassId = Convert.ToInt32(reader["MajorClassId"]);
                
                majorClass.Id = Convert.ToInt32(reader["MajorClassId"]);
                majorClass.MajorClassName = Convert.ToString(reader["MajorClassName"]);
                majorClass.ArchitectureId = Convert.ToInt32(reader["ArchitectureId"]);
                architecture.Id = Convert.ToInt32(reader["ArchitectureId"]);
                architecture.ArchitectureName = Convert.ToString(reader["ArchitectureName"]);
                majorClass.Architecture = architecture;
                user.MajorClass = majorClass;
               
                user.PhoneNum =Convert.ToString(reader["PhoneNum"]);
                user.PassWord = Convert.ToString(reader["PassWord"]);
                user.Number = Convert.ToInt32(reader["Number"]);
                user.IsAdmin = Convert.ToInt32(reader["IsAdmin"]);
                list.Add(user);
            }

            reader.Close();
            co.Close();
            return list;
        }


        /// <summary>
        /// 获取学生总数
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            SqlConnection co = SqlServerOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "select count(1) from T_Base_User";
            int count = (int)cmd.ExecuteScalar();
            return count;
        }

        /// <summary>
        /// 获取指定学院下全部专业班级
        /// </summary>
        /// <returns></returns>
        public List<Model.T_Base_MajorClass> GetMajorClass(int ArchitectureId)
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


    }
}
