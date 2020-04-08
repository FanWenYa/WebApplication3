using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Users
    {
        private int Sid;//字段类型和字段名要与数据库对应  

        public int Sid1//封装后的字段  
        {
            get { return Sid; }
            set { Sid = value; }
        }

        private string username;

        public string username1
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string password1
        {
            get { return password; }
            set { password = value; }
        }

        private string number;
 
        public string number1
        {
            get { return number; }
            set { number = value; }
        }

        private string state;

        public string state1
        {
            get { return state; }
            set { state = value; }
        }

        private string statecode;

        public string statecode1
        {
            get { return statecode; }
            set { statecode = value; }
        }

        private string sclass;

        public string sclass1
        {
            get { return sclass; }
            set { sclass = value; }
        }
        private string sgrade;

        public string sgrade1
        {
            get { return sgrade; }
            set { sgrade = value; }
        }
    }
}
