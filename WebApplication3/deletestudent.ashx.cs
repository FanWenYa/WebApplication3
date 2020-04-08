using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using BLL;
namespace WebApplication3
{
    /// <summary>
    /// deletestudent 的摘要说明
    /// </summary>
    public class deletestudent : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string sid = context.Request["sid"];
            string statecode = context.Request["statecode"];

            string state = new BLL.UserManage().select_statecode(statecode);

            if (state == "超级管理员" || state == "管理员" && sid != null)
            {

                if (new BLL.UserManage().delect_student(Convert.ToInt32(sid)))
                {
                    context.Response.Write("删除成功");
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