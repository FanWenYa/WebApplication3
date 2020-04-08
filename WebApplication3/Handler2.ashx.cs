using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    /// <summary>
    /// Handler2 的摘要说明
    /// </summary>
    public class Handler2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpPostedFile hpf = HttpContext.Current.Request.Files[0];
            string ss = context.Request["ss"];

            string savepath = context.Server.MapPath("~/www/imges/" + hpf.FileName);//路径,相对于服务器当前的路径
            hpf.SaveAs(savepath);//保存
            context.Response.Write("保存成功" + hpf.FileName);

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