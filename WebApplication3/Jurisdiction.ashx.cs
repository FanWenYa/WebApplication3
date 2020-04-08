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
    /// Jurisdiction 的摘要说明
    /// </summary>
    public class Jurisdiction : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            string state = context.Request["state"];
            string statecode = context.Request["statecode"];


            string state_select = new BLL.UserManage().select_statecode(statecode);
            string JsonString = string.Empty;

            if (state_select == "超级管理员" && state == null)
            {
                JsonString = JsonConvert.SerializeObject(new BLL.UserManage().select_usernamestate_teble("超级管理员"));
                context.Response.Write(JsonString);
            }else if (state_select == "超级管理员" && state != null )
            {
                JsonString = JsonConvert.SerializeObject(new BLL.UserManage().select_usernamestate2_teble(state));
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