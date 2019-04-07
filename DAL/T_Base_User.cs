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
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
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
                user.Number = Convert.ToInt32(reader["Number"]);
                user.IsAdmin = Convert.ToInt32(reader["IsAdmin"]);
                list.Add(user);
            }

            reader.Close();
            config.Close();
            return list;
        }


        /// <summary>
        /// 获取学生总数
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select count(1) from T_Base_User";
            int count = (int)cmd.ExecuteScalar();
            config.Close();
            return count;
        }

        /// <summary>
        /// 根据指定建筑Id获取学院专业
        /// </summary>
        /// <returns></returns>
        public List<Model.T_Base_MajorClass> GetMajorClass(int ArchitectureId)
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
        /// 保存添加的用户信息
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public int AddSaveUser(Model.T_Base_User User)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "insert into T_Base_User values('" + User.Num + 
                "','"+User.Name+"',"+User.Sex+","+User.MajorClassId+",'"+User.PhoneNum
                +"','"+User.Num+"',0,"+User.IsAdmin+",3)";
            int result = cmd.ExecuteNonQuery();
            config.Close();
            return result;
        }


        /// <summary>
        /// 重置用户密码
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public int ResetPassWord(int UserId)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "update T_Base_User set PassWord = "+
                "(select Num from T_Base_User where Id = "+UserId+") where Id = "+UserId;
            int result = cmd.ExecuteNonQuery();
            config.Close();
            return result;
        }

        /// <summary>
        /// 获取指定Id的用户信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public Model.T_Base_User GetUser(int UserId)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select * from V_User_MajorClass_Architecture where Id = " + UserId;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            //所属学院信息
            Model.T_Base_Architecture architecture = new Model.T_Base_Architecture();
            architecture.Id = Convert.ToInt32(reader["ArchitectureId"]);
            architecture.ArchitectureName = Convert.ToString(reader["ArchitectureName"]);
            //所属专业班级信息
            Model.T_Base_MajorClass majorClass = new Model.T_Base_MajorClass();
            majorClass.Id = Convert.ToInt32(reader["MajorClassId"]);
            majorClass.MajorClassName = Convert.ToString(reader["MajorClassName"]);
            majorClass.ArchitectureId = Convert.ToInt32(reader["ArchitectureId"]);
            majorClass.Architecture = architecture;
            //用户信息
            Model.T_Base_User user = new Model.T_Base_User();
            user.Id = Convert.ToInt32(reader["Id"]);
            user.Num = Convert.ToString(reader["Num"]);
            user.Name = Convert.ToString(reader["Name"]);
            user.Sex = Convert.ToInt32(reader["Sex"]);
            user.MajorClassId = Convert.ToInt32(reader["MajorClassId"]);
            user.PhoneNum = Convert.ToString(reader["PhoneNum"]);
            user.PassWord = Convert.ToString(reader["PassWord"]);
            user.Number = Convert.ToInt16(reader["Number"]);
            user.IsAdmin = Convert.ToInt16(reader["IsAdmin"]);
            user.MajorClass = majorClass;

            reader.Close();
            config.Close();
            return user;
        }

        /// <summary>
        /// 获取指定Num的用户信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public Model.T_Base_User GetUser(string Num)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select * from V_User_MajorClass_Architecture where Num = '" + Num+"'";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            //所属学院信息
            Model.T_Base_Architecture architecture = new Model.T_Base_Architecture();
            architecture.Id = Convert.ToInt32(reader["ArchitectureId"]);
            architecture.ArchitectureName = Convert.ToString(reader["ArchitectureName"]);
            //所属专业班级信息
            Model.T_Base_MajorClass majorClass = new Model.T_Base_MajorClass();
            majorClass.Id = Convert.ToInt32(reader["MajorClassId"]);
            majorClass.MajorClassName = Convert.ToString(reader["MajorClassName"]);
            majorClass.ArchitectureId = Convert.ToInt32(reader["ArchitectureId"]);
            majorClass.Architecture = architecture;
            //用户信息
            Model.T_Base_User user = new Model.T_Base_User();
            user.Id = Convert.ToInt32(reader["Id"]);
            user.Num = Convert.ToString(reader["Num"]);
            user.Name = Convert.ToString(reader["Name"]);
            user.Sex = Convert.ToInt32(reader["Sex"]);
            user.MajorClassId = Convert.ToInt32(reader["MajorClassId"]);
            user.PhoneNum = Convert.ToString(reader["PhoneNum"]);
            user.PassWord = Convert.ToString(reader["PassWord"]);
            user.Number = Convert.ToInt16(reader["Number"]);
            user.IsAdmin = Convert.ToInt16(reader["IsAdmin"]);
            user.MajorClass = majorClass;
            user.Role = Convert.ToInt32(reader["Role"]);

            reader.Close();
            config.Close();
            return user;
        }

        /// <summary>
        /// 保存修改后的用户信息
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public int EditSaveUser(Model.T_Base_User User)
        {
            DAL.SqlConfig config = new SqlConfig();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update T_Base_User set Num = '"+User.Num+
                "',Name = '"+User.Name+"',Sex = "+User.Sex+ ",MajorClassId = "
                + User.MajorClassId+",PhoneNum = "+User.PhoneNum
                +",IsAdmin = "+User.IsAdmin+" where Id = "+User.Id;
            int result = cmd.ExecuteNonQuery();

            config.Close();
            return result;
        }

        /// <summary>
        /// 删除学生
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Delete(string Ids)
        {
            DAL.SqlConfig config = new SqlConfig(); ;
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "delete from T_Base_User where Id in (" + Ids + ")";
            int result = cmd.ExecuteNonQuery();
            config.Close();
            return result;
        }

        /// <summary>
        /// 检查用户账号密码
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public Model.T_Base_User CheckUser(string LoginName, string PassWord)
        {
            Model.T_Base_User user = new Model.T_Base_User();
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.CommandText = "select * from T_Base_User where Num = '"+LoginName
                +"' and PassWord = '"+PassWord+"'";
            int result = cmd.ExecuteNonQuery();
            if(result == 1)
            {
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                user.Id = Convert.ToInt32(reader["Id"]);
                user.Num = Convert.ToString(reader["Num"]);
                user.Name = Convert.ToString(reader["Name"]);
                user.Sex = Convert.ToInt32(reader["Sex"]);
                user.MajorClassId = Convert.ToInt32(reader["MajorClassId"]);
                user.PhoneNum = Convert.ToString(reader["PhoneNum"]);
                user.PassWord = Convert.ToString(reader["PassWord"]);
                user.Number = Convert.ToInt32(reader["Number"]);
                user.IsAdmin = Convert.ToInt32(reader["IsAdmin"]);
                reader.Close();
            }
            else
            {
                user = null;
            }
            config.Close();
            return user;
        }


        public int SaveExcelUser(List<Model.T_Base_User> User)
        {
            SqlConfig config = new SqlConfig();
            SqlCommand cmd = config.getSqlCommand();
            cmd.Transaction = config.getSqlConnection().BeginTransaction();
            int result = 0; //添加的学生数
            for (int i = 0; i < User.Count; i++)
            {
                //判断该生是否存在
                cmd.CommandText = "select count(1) from T_Base_User where Num='" + User[i].Num + "'";
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    continue;
                }
                //判断学院是否存在
                cmd.CommandText = "select count(1) from T_Base_Architecture where ArchitectureName='" + User[i].MajorClass.Architecture.ArchitectureName + "'";
                if ((int)cmd.ExecuteScalar() == 0)
                {
                    cmd.CommandText = "insert into T_Base_Architecture values('" + User[i].MajorClass.Architecture.ArchitectureName + "',1)";
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = "select Id from T_Base_Architecture where ArchitectureName='" + User[i].MajorClass.Architecture.ArchitectureName + "'";
                int architectureId = (int)cmd.ExecuteScalar();
                //判断班级是否存在
                cmd.CommandText = "select count(1) from T_Base_MajorClass where MajorClassName='" + User[i].MajorClass.MajorClassName + "'";
                if ((int)cmd.ExecuteScalar() == 0)
                {
                    cmd.CommandText = "insert into T_Base_MajorClass values('" + User[i].MajorClass.MajorClassName + "'," + architectureId + ")";
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = "select Id from T_Base_MajorClass where MajorClassName='" + User[i].MajorClass.MajorClassName + "'";
                int majorClassId = (int)cmd.ExecuteScalar();
                //添加用户
                cmd.CommandText = "insert into T_Base_User values('" + User[i].Num + "','" + User[i].Name + "'," + User[i].Sex +
                    "," + majorClassId + ",'" + User[i].PhoneNum + "','" + User[i].Num + "',0,0,3)";
                result += cmd.ExecuteNonQuery();
            }
            cmd.Transaction.Commit();
            config.Close();
            return result;
        }

    }
}
