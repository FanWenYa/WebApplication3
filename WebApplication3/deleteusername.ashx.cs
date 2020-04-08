using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    /// <summary>
    /// deleteusername 的摘要说明
    /// </summary>
    public class deleteusername : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string username = context.Request["username"];
            string statecode = context.Request["statecode"];

            string state = new BLL.UserManage().select_statecode(statecode);
            if(state == "超级管理员"  && username != null)
            {
                if(new BLL.UserManage().delete(username))
                {
                    context.Response.Write("删除成功!");
                }
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