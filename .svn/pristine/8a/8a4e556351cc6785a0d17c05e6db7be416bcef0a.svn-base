using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace QGYHelper
{
    /// <summary>
    ///语言替换类
    /// </summary>
    public class LangHelper
    {
        public static void InitTemlate(ref string html,ref string title)
        {
            string fileName = System.Web.HttpContext.Current.Request.Url.ToString();
            fileName = fileName.Substring(fileName.LastIndexOf("/") + 1);
            fileName = fileName.Substring(0, fileName.IndexOf("."));
            string lang = QGYHelper.CookiesSessionHelper.ReadCookies("lang");
            if (lang == "")
                lang = "cn";
            html = QGYHelper.HtmlDataHelper.GetHtmlCode(QGYHelper.Config._ApiUrl + "/seller/" + fileName + ".html", System.Text.Encoding.UTF8);
            string js = QGYHelper.HtmlDataHelper.GetHtmlCode(QGYHelper.Config._ApiUrl + "/seller/lang/" + lang + "/" + fileName + ".js", System.Text.Encoding.UTF8);
            if (js != "")
            {
                Dictionary<string, object> json = FormatJsonData(js);
                string path = string.Empty;
                DGJson(json, path, ref html, ref title);
            }
        }

        private static void DGJson(Dictionary<string, object> json, string path, ref string html,ref string title)
        {
            string keyPath = path;
            foreach (object key in json)
            {
                KeyValuePair<string, object> child = (KeyValuePair<string, object>)key;
                path = keyPath + "_" + child.Key;
                if (path == "_head_title")
                    title = child.Value.ToString();

                if (child.Value.GetType().Name.ToLower() == "string")
                {
                    html = html.Replace("{{" + path + "}}", child.Value.ToString());
                }
                else
                {
                    Dictionary<string, object> childValue = (Dictionary<string, object>)child.Value;
                    DGJson(childValue, path, ref html, ref title);
                }
            }
        }
        /// <summary>
        /// 格式化Json数据
        /// </summary>
        /// <param name="jsonText"></param>
        /// <returns></returns>
        private static Dictionary<string, object> FormatJsonData(string jsonText)
        {
            JavaScriptSerializer s = new JavaScriptSerializer();
            Dictionary<string, object> JsonData = (Dictionary<string, object>)s.DeserializeObject(jsonText);
            return JsonData;
        }
    }
}