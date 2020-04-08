using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Model;
namespace WebApplication3
{
    /// <summary>
    /// modifystudent 的摘要说明
    /// </summary>
    public class modifystudent : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string statecode = context.Request["statecode"];
            string sid = context.Request["sid"];
            string sname = context.Request["sname"];
            string sclass = context.Request["sclass"];
            string sgrade = context.Request["sgrade"];
            string ssystem = context.Request["ssystem"];


            string state = new BLL.UserManage().select_statecode(statecode);

            if (state == "超级管理员" || state == "管理员" && sid != null && sname != null && sclass != null && sgrade != null && ssystem != null)
            {
                student_users us = new student_users();
                us.Sid1 = Convert.ToInt32(sid);
                us.Sname1 = sname;
                us.Sclass1 = sclass;
                us.Sgrade1 = sgrade;
                us.Ssystem1 = ssystem;


                if (new BLL.UserManage().modify_student(us))
                {
                    context.Response.Write("修改成功");
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