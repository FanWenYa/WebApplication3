using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Model;
using BLL;

namespace WebApplication3
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            string statecode = context.Request["statecode"];
            string system = context.Request["system"];
            string classs = context.Request["classs"];
            string grades = context.Request["grades"];
            string operation = context.Request["operation"];
            string JsonString = string.Empty;
            //查询系部信息
            if (system == null && classs == null && grades == null && operation == "查询系部信息")
            {
           
                JsonString = JsonConvert.SerializeObject(new BLL.UserManage().select_system_information());

                context.Response.Write(JsonString);
            //根据系部信息查询班级年级信息
            } else if (system != null && operation == "根据系部信息查询班级年级信息")
            {
                JsonString = JsonConvert.SerializeObject(new BLL.UserManage().select_system(system));

                context.Response.Write(JsonString);
            //根据班级年级信息查询学生信息
            } else if (classs != null && grades != null && operation == "根据系部班级年级信息查询学生信息")
            {
                Users user = new Users();
                user.sclass1 = classs;
                user.sgrade1 = grades;

                JsonString = JsonConvert.SerializeObject(new BLL.UserManage().select_student(user));

                context.Response.Write(JsonString);
            } else if (operation == "查询所有学生信息")
            {
                JsonString = JsonConvert.SerializeObject(new BLL.UserManage().select_whole_student());

                context.Response.Write(JsonString);
            }else if (operation == "根据系部信息查询学生信息" && system != null)
            {
                JsonString = JsonConvert.SerializeObject(new BLL.UserManage().select_system_student(system));
                context.Response.Write(JsonString);
            }else if (operation == "根据系部班级信息查询学生信息" && classs != null)
            {
                JsonString = JsonConvert.SerializeObject(new BLL.UserManage().select_sclass_student(classs));
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