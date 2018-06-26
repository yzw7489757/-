using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
//序列
using System.Web.Script.Serialization;//System.Web.Extensions 
using System.ServiceModel.Web;
using System.Runtime.Serialization.Json;
using System.IO;

namespace QGYHelper
{
    public class JsonHelper : System.Web.UI.Page
    {

        /// <summary>
        /// 返回JSON数据到请求的函数
        /// </summary>
        /// <param name="callback">回调参数</param>
        /// <param name="data">序列的JSON字符串</param>
        /// <param name="Response">与Page对象关联的HttpResponse对象</param>
        public static void ReturnJSON(string callback, string data, HttpResponse Response)
        {
            string result = string.Format("{0}({1})", callback, data);
            Response.Expires = -1;
            Response.Clear();
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "application/json";
            Response.Write(result);
            Response.Flush();
            Response.End();
        }
        /// <summary>
        /// 转换为JSON数据
        /// </summary>
        /// <param name="obj">要转换为JSON数据的对象</param>
        /// <returns>返回JSON字符串</returns>
        public static string ToJSON(object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }


        /// <summary>
        /// 返回JSON数据到请求的函数
        /// </summary>
        /// <param name="data">序列的JSON字符串</param>
        /// <param name="Response">与Page对象关联的HttpResponse对象</param>
        public static void ReturnJSON1(string callback, string data, HttpResponse Response)
        {
            string result = string.Format("{0}({1})", callback, data);
            Response.Expires = -1;
            Response.Clear();
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "application/json";
            Response.Write(result); 
        }
        public static string GetJson<T>(T obj)
        {

            DataContractJsonSerializer json = new DataContractJsonSerializer(obj.GetType());

            using (MemoryStream stream = new MemoryStream())
            {
                json.WriteObject(stream, obj);
                string szJson = Encoding.UTF8.GetString(stream.ToArray());
                return szJson;
            }

        }
        public static T JsonDeserialize<T>(string jsonString)
        {

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));

            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));

            T obj = (T)ser.ReadObject(ms);

            return obj;

        }


        #region 格式化Json数据

        /// <summary>
        /// 格式化Json数据
        /// </summary>
        /// <param name="jsonText"></param>
        /// <returns></returns>
        public static Dictionary<string, object> FormatJsonData(string jsonText)
        {

            System.Web.Script.Serialization.JavaScriptSerializer s = new System.Web.Script.Serialization.JavaScriptSerializer();
            Dictionary<string, object> JsonData = (Dictionary<string, object>)s.DeserializeObject(jsonText);
            return JsonData;
        }
        #endregion
    }
}