using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using BLL;
namespace WebApplication3
{
    /// <summary>
    /// addstudent 的摘要说明
    /// </summary>
    public class addstudent : IHttpHandler
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
            string id = context.Request["id"];
            string sphone = context.Request["sphone"];
            string sbirth = context.Request["sbirth"];


            string state = new BLL.UserManage().select_statecode(statecode);
            int Sid = Convert.ToInt32(sgrade + new BLL.UserManage().judgeclass(sclass) + new BLL.UserManage().judgesystem(ssystem) + sid);
            if(new BLL.UserManage().select_sid_student(Sid)) { 
            if (state == "超级管理员" || state == "管理员" && sid != null && sname != null && sclass != null && sgrade != null && ssystem != null)
            {
                student_users us = new student_users();
                us.Sid1 = Sid;
                us.Sname1 = sname;
                us.Sclass1 = sclass;
                us.Sgrade1 = sgrade;
                us.Ssystem1 = ssystem;
                us.id1 = id;
                us.Sphone1 = sphone;
                    us.Sbirth1 = sbirth;

                    if (new BLL.UserManage().add_student(us))
                {
                    context.Response.Write("添加成功");
                }
            }
            }
            else
            {
                context.Response.Write("学号已存在");
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