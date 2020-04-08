using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    /// <summary>
    /// modifyjurisdiction 的摘要说明
    /// </summary>
    public class modifyjurisdiction : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string statecode = context.Request["statecode"];
            string username = context.Request["username"];
            string stateget = context.Request["stateget"];

            string state = new BLL.UserManage().select_statecode(statecode);

            if (state == "超级管理员" && username != null && stateget != null)
            {
                if (new BLL.UserManage().modify_account(username, stateget))
                {
                    context.Response.Write("修改成功");
                }
            }
            else
            {
                context.Response.Write("修改失败");
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