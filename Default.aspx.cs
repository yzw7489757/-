using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("TrainLoginTest.aspx");
    }
    private void Bind()
    {
        string strSql = "select id,name,name_en,mobile_name,mobile_name_en,parent_id_path from tb_goods_category";
        DataTable dt = QGYHelper.DataBase.DbHelperSQL.Query(strSql).Tables[0];
        System.Text.StringBuilder sbSql = new System.Text.StringBuilder();
        for (int j = 0; j < dt.Rows.Count; j++)
        {
            DataRow dr = dt.Rows[j];
            int id = (int)dr["id"];

            string[] arr = dr["parent_id_path"].ToString().Split(new char[] { ',' });
            string namePath = string.Empty, nameEnPath = string.Empty, nameMobilePath = string.Empty, nameMobileEnPath = string.Empty;
            foreach (string i in arr)
            {
                if (i.Trim() == "" || i.Trim() == "0")
                    continue;
                DataRow[] drs = dt.Select("id=" + i.Trim());
                if (drs.Length > 0)
                {
                    if (namePath == "")
                    {
                        namePath = drs[0]["name"].ToString();
                        nameEnPath = drs[0]["name_en"].ToString();
                        nameMobilePath = drs[0]["mobile_name"].ToString();
                        nameMobileEnPath = drs[0]["mobile_name_en"].ToString();
                    }
                    else
                    {
                        namePath = namePath + " > " + drs[0]["name"].ToString();
                        nameEnPath = nameEnPath + " > " + drs[0]["name_en"].ToString();
                        nameMobilePath = nameMobilePath + " > " + drs[0]["mobile_name"].ToString();
                        nameMobileEnPath = nameMobileEnPath + " > " + drs[0]["mobile_name_en"].ToString();
                    }
                }
            }
            string ext = (dr["parent_id_path"].ToString() == ",0,") ? "" : " > ";
            namePath = namePath + ext + dr["name"].ToString();
            nameEnPath = nameEnPath + ext + dr["name_en"].ToString();
            nameMobilePath = nameMobilePath + ext + dr["mobile_name"].ToString();
            nameMobileEnPath = nameMobileEnPath + ext + dr["mobile_name_en"].ToString();
            sbSql.Append("update tb_goods_category set name_path = '" + namePath.Replace("'", "''") + "',name_en_path = '" + nameEnPath.Replace("'", "''") + "',mobile_name_path = '" + nameMobilePath.Replace("'", "''") + "',mobile_name_en_path = '" + nameMobileEnPath.Replace("'", "''") + "' where id = " + id + ";");

            if (j > 0 && j % 50 == 0)
            {
                QGYHelper.DataBase.DbHelperSQL.ExecuteSql(sbSql.ToString());
                sbSql.Length = 0;
            }
        }
        if (sbSql.Length > 0)
            QGYHelper.DataBase.DbHelperSQL.ExecuteSql(sbSql.ToString());
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string theme = "您好";
        string content = "欢迎发送邮件";
        string toEmail = "201801@qgy.com", fromEmail="20180102@qgy.com", error=string.Empty;
        QGYHelper.EmailHelper.SendEmail(theme, content, toEmail, fromEmail, ref error);
        Response.Write(error);
    }
}