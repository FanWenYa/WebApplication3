using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Users1
    {
        private string Sid;//字段类型和字段名要与数据库对应  

        public string Sid1//封装后的字段  
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
        private string statecode;

        public string statecode1
        {
            get { return statecode; }
            set { statecode = value; }
        }
    }
}
