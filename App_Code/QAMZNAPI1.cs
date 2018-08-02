using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using System.Data;
using System.Collections;
using Newtonsoft.Json;

/// <summary>
///亚马逊接口
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class QAMZNAPI1 : System.Web.Services.WebService, IRequiresSessionState
{ 
    
    #region 基础

    public QAMZNAPI1()
    {
    }
    /// <summary>
    /// 回调函数
    /// </summary>
    /// <param name="result"></param>
    [WebMethod(EnableSession = true)]
    private void Callback(string result)
    {
        Context.Response.Write(result);
        Context.Response.End();
    }
    #endregion

    #region 卖家导航信息

    [WebMethod(EnableSession = true)]
    public void InitSellerNav(int amazon_userid)
    {
        string strSql = "select shop_name from tb_virtual_shop where user_id = " + amazon_userid;
        DataTable dt = QGYHelper.DataBase.DbHelperSQL.Query(strSql).Tables[0];
        int result = 0;
        string error = string.Empty, shop_name = string.Empty;
        if (dt.Rows.Count > 0)
        {
            result = 1;
            shop_name = dt.Rows[0]["shop_name"].ToString();
        }
        else
        {
            error = "卖家账号不存在";
        }
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",\"shop_name\":\"" + QGYHelper.FormatCode.FormatUrlEncode(shop_name) + "\"}");
    }


    #endregion

    #region 商品类目搜索

    /// <summary>
    /// 商品类目搜索
    /// </summary>  
    /// <param name="lang">语言</param>
    /// <param name="port">终端：pc 其他</param>
    /// <param name="key">关键字</param>
    [WebMethod(EnableSession = true)]
    public void SearchCategoryByKey(string lang, string port, string key)
    {
        int result = 0;
        string error = string.Empty;
        string name = "", name_path = "";
        if (lang == "zh")
        {
            if (port == "pc")
            {
                name = "name";
                name_path = "name_path";
            }
            else
            {
                name = "mobile_name";
                name_path = "mobile_name_path";
            }
        }
        else if (lang == "en")
        {
            if (port == "pc")
            {
                name = "name_en";
                name_path = "name_en_path";
            }
            else
            {
                name = "mobile_name_en";
                name_path = "mobile_name_en_path";
            }
        }
        else
        {
            error = lang + "语言不存在";
            Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
        }
        string strSql = "select id," + name + "," + name_path + ",parent_id_path from tb_goods_category where " + name + " like '%" + key + "%' order by " + name;
        DataTable dt = QGYHelper.DataBase.DbHelperSQL.Query(strSql).Tables[0];
        Hashtable ht = new Hashtable();
        if (dt.Rows.Count > 0)
        {
            strSql = "select id," + name + " from tb_goods_category where parent_id = 0";
            DataTable dtGate = QGYHelper.DataBase.DbHelperSQL.Query(strSql).Tables[0];

            System.Text.StringBuilder sbHtml = new System.Text.StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            { 
                string pathid = dt.Rows[i]["parent_id_path"].ToString();
                pathid = pathid.Substring(1).TrimEnd(new char[] { ',' });
                string[] arr = pathid.Split(new char[] { ',' });
                int pid = (arr.Length == 1) ? int.Parse(dt.Rows[i]["id"].ToString()) : int.Parse(arr[arr.Length - 2]);
                DataRow[] drs = dtGate.Select("id=" + pid);
                string pname = string.Empty;
                if (drs.Length > 0)
                    pname =  drs[0][name].ToString();
                string htkey = pid + "|" + pname;
                if (!ht.ContainsKey(htkey))
                {
                    ht.Add(htkey, 1);
                }
                else
                {
                    ht[htkey] = int.Parse(ht[htkey].ToString()) + 1;
                }
            }
            result = 1;
        }
        else
            error = key+"关键字类目不存在";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",\"type\":" + QGYHelper.JsonHelper.ToJSON(ht) + ",\"list\":" + JsonConvert.SerializeObject(dt) + "}");
    }

    /// <summary>
    /// 商品类目搜索
    /// </summary>  
    /// <param name="lang">语言</param>
    /// <param name="port">终端：pc 其他</param>
    /// <param name="key">关键字</param>
    /// <param name="pid">父ID</param>
    [WebMethod(EnableSession = true)]
    public void SearchCategoryByPID(string lang, string port,string key, string pid)
    {
        int result = 0;
        string error = string.Empty;
        string name = "", name_path = "";
        if (lang == "zh")
        {
            if (port == "pc")
            {
                name = "name";
                name_path = "name_path";
            }
            else
            {
                name = "mobile_name";
                name_path = "mobile_name_path";
            }
        }
        else if (lang == "en")
        {
            if (port == "pc")
            {
                name = "name_en";
                name_path = "name_en_path";
            }
            else
            {
                name = "mobile_name_en";
                name_path = "mobile_name_en_path";
            }
        }
        else
        {
            error = lang + "语言不存在";
            Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
        }
        string strSql = "select id," + name + "," + name_path + " from tb_goods_category where parent_id_path like '%," + pid + ",%' and " + name + " like '%" + key + "%' order by " + name;
        DataTable dt = QGYHelper.DataBase.DbHelperSQL.Query(strSql).Tables[0];
        if (dt.Rows.Count > 0)
            result = 1;
        else
            error = "子类目不存在";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",\"list\":" + JsonConvert.SerializeObject(dt) + "}");
    }

    #endregion
}
