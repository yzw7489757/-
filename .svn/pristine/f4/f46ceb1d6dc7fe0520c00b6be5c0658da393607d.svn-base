using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;

public partial class seller_ToPage : System.Web.UI.Page
{
    public string _page = "register";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["page"]))
            this._page = Request.QueryString["page"];
        string lang = QGYHelper.CookiesSessionHelper.ReadCookies("lang");
        if (lang == "")
            lang = "cn";
        string html =QGYHelper.HtmlDataHelper.GetHtmlCode(QGYHelper.Config._ApiUrl+ "/seller/" + this._page + ".html", System.Text.Encoding.UTF8);
        string js = QGYHelper.HtmlDataHelper.GetHtmlCode(QGYHelper.Config._ApiUrl + "/seller/lang/" + lang + "/" + this._page + ".js", System.Text.Encoding.UTF8);
        if (js != "")
        {
            Dictionary<string, object> json = FormatJsonData(js);
            string path = string.Empty;
            DGJson(json, path, ref html);
        }
        Response.Write(html);
    }
    private void DGJson(Dictionary<string, object> json, string path, ref string html)
    {
        string keyPath = path;
        foreach (object key in json)
        {
            KeyValuePair<string, object> child = (KeyValuePair<string, object>)key;
            path = keyPath + "_" + child.Key;

            if (child.Value.GetType().Name.ToLower() == "string")
            {
                html = html.Replace("{{" + path + "}}", child.Value.ToString());
            }
            else
            {
                Dictionary<string, object> childValue = (Dictionary<string, object>)child.Value;
                DGJson(childValue, path, ref html);
            }
        }
    }
    #region 格式化Json数据

    /// <summary>
    /// 格式化Json数据
    /// </summary>
    /// <param name="jsonText"></param>
    /// <returns></returns>
    private Dictionary<string, object> FormatJsonData(string jsonText)
    {
        JavaScriptSerializer s = new JavaScriptSerializer();
        Dictionary<string, object> JsonData = (Dictionary<string, object>)s.DeserializeObject(jsonText);
        return JsonData;
    }
    #endregion
}