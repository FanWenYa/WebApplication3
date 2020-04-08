using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Model;
using DAL;
namespace BLL
{
    public class JSONToString
    {
        // 从一个对象信息生成Json串  
        public static string ObjectToJson(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
        // 从一个Json串生成对象信息  
        public static object JsonToObject(string jsonString, object obj)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString, obj.GetType());
        }
    }
}
