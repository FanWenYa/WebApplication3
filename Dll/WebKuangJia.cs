using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;
using DAL;
namespace BLL
{
    public class UserManage
    {
        
        public  bool add(Users user)
        {
            return UserService.Addaccount(user);
        }
        public  bool delete(string username)
        {
            return UserService.DeleteStudentBySnumber(username);
        }

        public  bool modify(Users user)
        {
            return UserService.ModifyStudent(user);
        }

        public bool modify_student(student_users user)
        {
            return UserService.ModifyStudent1(user);
        }
        public bool modify_account(string username , string state)
        {
            return UserService.Modifyaccount2(username, state);
        }
        //
        public static bool select_username(string username)
        {
            return UserService.Queryaccount1(username);
        }
        //查询学生学号
        public  bool select_sid_student(int sid)
        {
            return UserService.Query_sid_student(sid);
        }
        //
        public static bool select_username_password(Users user)
        {
            return UserService.Queryaccount(user);
        }
        //查询所有学生
        public DataTable select_whole_student()
        {
            return UserService.whole_student_information();
        }
        //根据系部查询学生
        public DataTable select_system_student(string system)
        {
            return UserService.all_system_student(system);
        }
        // 根据系部班级查询学生
        public DataTable select_sclass_student(string sclass)
        {
            return UserService.select_sclass_student(sclass);
        }

        public string getStr(bool b, int n)//b：是否有复杂字符，n：生成的字符串长度

        {

            string str = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (b == true)
            {
                str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";//复杂字符
            }
            StringBuilder SB = new StringBuilder();
            Random rd = new Random();
            for (int i = 0; i < n; i++)
            {
                SB.Append(str.Substring(rd.Next(0, str.Length), 1));
            }
            return SB.ToString();

        }
        //获取用户信息
        public  DataTable select_username_teble(string number)
        {
            return UserService.Queryaccount2(number);
        }
        //查询账户权限
        public DataTable select_usernamestate_teble(string state)
        {
            return UserService.selectaccount(state);
        }
        //查询账户权限2
        public DataTable select_usernamestate2_teble(string state)
        {
            return UserService.selectaccount2(state);
        }
        public DataTable select_system_information()
        {
            return UserService.Queryaccount4();
        }
        public DataTable select_system(string system)
        {
            return UserService.Queryaccount5(system);
        }
        public string select_statecode(string statecode)
        {
            return UserService.Queryaccount3(statecode);
        }
        public DataTable select_student(Users user)
        {
            return UserService.Querystudent_information(user);
        }
        public bool add_student(student_users user)
        {
            return UserService.AddStudent(user);
        }

        public bool delect_student(int sid)
        {
            return UserService.DeleteStudentSid(sid);
        }

        public string judgeclass(string sclassid)
        {
            if (sclassid == "软件一班")
            {
                sclassid = "01";
            }
            else if (sclassid == "软件二班")
            {
               sclassid = "02";
            }
            else if (sclassid == "软件三班")
            {
               sclassid = "03";
            }
            else if (sclassid == "计应一班")
            {
                sclassid = "04";
            }
            else if (sclassid == "计应二班")
            {
                sclassid = "05";
            }
            else if (sclassid == "财经一班")
            {
                sclassid = "06";
            }
            else if (sclassid == "财经二班")
            {
                sclassid = "07";
            }
            return sclassid;
        }

        public string judgesystem(string ssystemid)
        {
            if (ssystemid == "计算机系")
            {
                ssystemid = "01";
            }
            else if (ssystemid == "财经系")
            {
                ssystemid = "02";
            }
            return ssystemid;
        }

        /*public List<Model.Users> table()
        {
            DataTable table= DAL.UserService.Selecttable();
            foreach (DataRow row in table.Rows) {
                Model.Users users = new Model.Users();
                users.Sid1 = (String)row["Sid"];
                users.username1 = (String)row["username"];
                users.password1 = (String)row["password"];

            }

        }*/


    }
}