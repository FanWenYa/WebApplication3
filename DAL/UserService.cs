using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class UserService
    {

        //连接数据库  
        public static SqlConnection connection;
        public static SqlConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    //远程连接数据库命令（前提远程数据库服务器已经配置好允许远程连接）  
                    //string strConn = @"Data Source=172.18.72.158;Initial Catalog=WebKuangjia;User ID=sa;Password=LIwei123;Persist Security Info=True";

                    //连接本地数据库命令  
                    string strConn = @"Data Source=.;Initial Catalog=Student_management;Integrated Security=True";

                    connection = new SqlConnection(strConn);
                    connection.Open();
                }
                else if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }

        //执行sql语句,返回被修改行数  增删改
        public static int ExecuteCommand(string commandText, SqlParameter[] para)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection;
            cmd.CommandText = commandText;
            try
            {
                if (para != null)
                {
                    cmd.Parameters.AddRange(para);
                }
                return cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }
        //执行sql语句,返回被修改行数  查
        public static object ExecuteCommand1(string commandText, SqlParameter[] para)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection;
            cmd.CommandText = commandText;
            try
            {
                if (para != null)
                {
                    cmd.Parameters.AddRange(para);
                }
                return cmd.ExecuteScalar();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }

        //执行sql语句,返回数据库表  
        public static DataTable GetDataTable(string commandText, CommandType commandType, SqlParameter[] para)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection;
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            try
            {
                if (para != null)
                {
                    cmd.Parameters.AddRange(para);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable temp = new DataTable();
                da.Fill(temp);
                return temp;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }


        //增加用户  account
        public static bool Addaccount(Users user)
        {
            string sql = "insert into account(username,password,statecode,state)" + "values(@username,@password,@statecode,@state)";//sql语句字符串  
            SqlParameter[] para = new SqlParameter[]//存储相应参数的容器  
            {
                new SqlParameter("@username",user.username1),
                new SqlParameter("@password",user.password1),
                new SqlParameter("@statecode",user.statecode1),
                new SqlParameter("@state",user.state1)
            };
            int count = ExecuteCommand(sql, para);//调用执行sql语句函数  
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        //增加用户  Student
        public static bool AddStudent(student_users user)
        {
            string sql = "insert into student_information(Sid,Sname,Sclass,Sgrade,Ssystem,id,Sphone,Sbirth)" + "values(@Sid,@Sname,@Sclass,@Sgrade,@Ssystem,@id,@Sphone,@Sbirth)";//sql语句字符串  
            SqlParameter[] para = new SqlParameter[]//存储相应参数的容器  
            {
                new SqlParameter("@Sid",user.Sid1),
                new SqlParameter("@Sname",user.Sname1),
                new SqlParameter("@Sclass",user.Sclass1),
                new SqlParameter("@Sgrade",user.Sgrade1),
                new SqlParameter("@Ssystem",user.Ssystem1),
                new SqlParameter("@id",user.id1),
                new SqlParameter("@Sphone",user.Sphone1),
                new SqlParameter("@Sbirth",user.Sbirth1),
            };
            int count = ExecuteCommand(sql, para);//调用执行sql语句函数  
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        //查询数据库表  
        public static DataTable Selecttable()
        {
            string sql = "select * from account";
            return GetDataTable(sql, CommandType.Text, null);
        }

        //删除用户  
        /****************删除用户返回影响行数*****************/
        public static bool DeleteStudentBySnumber(string username)
        {
            string sql = "delete from account where username=@username";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@username",username),
            };
            int count = ExecuteCommand(sql, para);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //删除学生信息
        public static bool DeleteStudentSid(int id)
        {
            string sql = "delete from student_information where Sid=@Sid";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Sid",id),
            };
            int count = ExecuteCommand(sql, para);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //修改用户  
        public static bool ModifyStudent(Users user)
        {
            string sql = "update account set password=@password where username=@username";
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@username",user.username1),
                new SqlParameter("@password",user.password1),
             };
            int count = ExecuteCommand(sql, para);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //修改学生信息
        public static bool ModifyStudent1(student_users user)
        {
            string sql = "update student_information set Sname = @Sname,Sclass = @Sclass,Sgrade = @Sgrade,Ssystem = @Ssystem where Sid = @Sid";
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@Sid",user.Sid1),
                new SqlParameter("@Sname",user.Sname1),
                new SqlParameter("@Sclass",user.Sclass1),
                new SqlParameter("@Sgrade",user.Sgrade1),
                new SqlParameter("@Ssystem",user.Ssystem1)
             };
            int count = ExecuteCommand(sql, para);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //修改账户权限
        public static bool Modifyaccount2(string username, string state)
        {
            string sql = "update account set username = @username,state = @state  where username = @username";
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@username",username),
                new SqlParameter("@state",state)
             };
            int count = ExecuteCommand(sql, para);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //查询用户帐号密码
        public static bool Queryaccount(Users user)
        {
            string sql = "select * from account where username=@username and password=@password";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@username",user.username1),
                new SqlParameter("@password",user.password1),
            };
            object count = ExecuteCommand1(sql, para);
            if (count == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //查询用户帐号  
        public static bool Queryaccount1(string userneme)
        {
            string sql = "select * from account where username=@username";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@username",userneme)
            };
            object count = ExecuteCommand1(sql, para);
            if (count == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //查询用户帐号返回数据
        public static DataTable Queryaccount2(string number)
        {
            string sql = "select username,statecode,state from account where username=@number";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@number",number),
            };
            return GetDataTable(sql, CommandType.Text, para);
        }

        //查找状态吗 判断
        public static string Queryaccount3(string statecode)
        {
            string sql = "select state,statecode from account where statecode=@statecode";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@statecode",statecode),
            };
            object count = ExecuteCommand1(sql, para);
            return count.ToString();
        }
        //查找账户权限信息
        public static DataTable selectaccount(string state)
        {
            string sql = "select username,state from account where state !=  @state";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@state",state)
            };
            return GetDataTable(sql, CommandType.Text, para);

        }
        //查找账户权限信息2
        public static DataTable selectaccount2(string state)
        {
            string sql = "select username,state from account where state =  @state";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@state",state)
            };
            return GetDataTable(sql, CommandType.Text, para);

        }
        //查询系部信息
        public static DataTable Queryaccount4()
        {
            string sql = "select system from system_information";
            return GetDataTable(sql, CommandType.Text, null);
        }
        //根据系部信息查询班级年级信息
        public static DataTable Queryaccount5(string system)
        {
            string sql = "select grade,class from system_information where system=@system";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@system",system),
            };
            return GetDataTable(sql, CommandType.Text, para);
        }
        //根据班级年级信息查询学生信息
        public static DataTable Querystudent_information(Users user)
        {
            string sql = "select * from student_information where sclass=@sclass and sgrade=@sgrade";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@sclass",user.sclass1),
                new SqlParameter("@sgrade",user.sgrade1)

            };
            return GetDataTable(sql, CommandType.Text, para);
        }
        //根据班级信息查询学生信息
        public static DataTable select_sclass_student(string sclass)
        {
            string sql = "select * from student_information where sclass=@sclass";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@sclass",sclass)

            };
            return GetDataTable(sql, CommandType.Text, para);
        }
        //查询所有学生信息
        public static DataTable whole_student_information()
        {
            string sql = "select * from student_information";
            return GetDataTable(sql, CommandType.Text, null);
        }
        //根据系部信息查询学生信息
        public static DataTable all_system_student(string system)
        {
            string sql = "select * from student_information where Ssystem = @system";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@system",system)
            };
            return GetDataTable(sql, CommandType.Text, para);
        }
        //查询学生学号
        public static bool Query_sid_student(int Sid)
        {
            string sql = "select * from student_information where Sid=@Sid";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Sid",Sid)
            };
            object count = ExecuteCommand1(sql, para);
            if (count == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}