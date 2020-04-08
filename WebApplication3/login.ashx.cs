using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Model;
using Newtonsoft.Json;
namespace WebApplication3
{
    /// <summary>
    /// login 的摘要说明
    /// </summary>
    public class login : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            string username = context.Request["username"];
            string password = context.Request["password"];

            Users us = new Users();
            us.username1 = username;
            us.password1 = password;

                if (BLL.UserManage.select_username_password(us))
            {
                context.Response.Write("");
            }
            else
            {
                string JsonString = string.Empty;
                JsonString = JsonConvert.SerializeObject(new BLL.UserManage().select_username_teble(username));
                context.Response.Write(JsonString);
                
            }
     
           

            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}