using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
namespace QGYHelper
{
    /// <summary>
    ///分页控件
    /// </summary>
    public class TPaginator
    {
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static string PaginatorBind(System.Web.UI.WebControls.Repeater rp, string strSql, string strSqlNum, string orderby, int pageSize, string url)
        {
            int currentPage = (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["page"])) ? 1 : int.Parse(HttpContext.Current.Request.QueryString["page"]);
            int totalRecords = int.Parse(QGYHelper.DataBase.DbHelperSQL.GetSingle(strSqlNum).ToString());
            int totalPages = (int)Math.Ceiling((double)totalRecords / (double)pageSize);
            int startIndex = (currentPage - 1) * pageSize + 1;
            int endIndex = currentPage * pageSize;
            endIndex = (endIndex > totalRecords) ? totalRecords : endIndex;

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT * FROM ( ");
            sbSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                sbSql.Append("order by " + orderby);
            }
            sbSql.Append(")AS Row,");
            sbSql.Append(strSql);
            sbSql.Append(" ) TT");
            sbSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            rp.DataSource = QGYHelper.DataBase.DbHelperSQL.Query(sbSql.ToString()).Tables[0];
            rp.DataBind();

            System.Text.StringBuilder sbPaginator = new StringBuilder();
            if (totalPages > 1)
            {
                sbPaginator.Append("<ul id=\"pages\">");
                string active = string.Empty;
                int step = 5;
                if (totalPages <= 2)
                {
                    for (int i = 1; i <= totalPages; i++)
                    {
                        active = (currentPage == i) ? "class=\"page-1\"" : "class=\"page-2\"";
                        sbPaginator.Append("<li " + active + "><a href=\"" + url + "page=" + i + "\"><span>" + i + "</span></a></li>"); 
                    }
                }
                else
                {
                    active = (currentPage == 1) ? "class=\"active\"" : "";

                    sbPaginator.Append("<li><a href=\"" + url + "page=1\"><img src=\"/static/Themes/default/images/page4.png\"></a></li>"); 
                    int prev = (currentPage - step / 2) < 1 ? 1 : (currentPage - step / 2);
                    int next = (prev + step-1) > totalPages ? totalPages : (prev + step-1);
                    prev = (next - prev+1 < step) ? next - step+1 : prev;
                    prev = (prev < 1) ? 1 : prev;

                    for (int i = prev; i <= next; i++)
                    {
                        active = (currentPage == i) ? "class=\"page-1\"" : "class=\"page-2\"";
                        sbPaginator.Append("<li " + active + "><a href=\"" + url + "page=" + i + "\"><span>" + i + "</span></a></li>");  
                    }

                    active = (currentPage == totalPages) ? "class=\"active\"" : "";
                    sbPaginator.Append("<li><a href=\"" + url + "page=" + totalPages + "\"><img src=\"/static/Themes/default/images/page3.png\"></a></li>");  
                } 
                sbPaginator.Append("</ul>");
            }

            return sbPaginator.ToString();
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static string PaginatorBindAjax(string strSql, string strSqlNum, string orderby,int currentPage, int pageSize,ref DataTable dt)
        { 
            int totalRecords = int.Parse(QGYHelper.DataBase.DbHelperSQL.GetSingle(strSqlNum).ToString());
            int totalPages = (int)Math.Ceiling((double)totalRecords / (double)pageSize);
            int startIndex = (currentPage - 1) * pageSize + 1;
            int endIndex = currentPage * pageSize;
            endIndex = (endIndex > totalRecords) ? totalRecords : endIndex;

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT * FROM ( ");
            sbSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                sbSql.Append("order by " + orderby);
            }
            sbSql.Append(")AS Row,");
            sbSql.Append(strSql);
            sbSql.Append(" ) TT");
            sbSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            dt= QGYHelper.DataBase.DbHelperSQL.Query(sbSql.ToString()).Tables[0];

            System.Text.StringBuilder sbPaginator = new StringBuilder();
            if (totalPages > 1)
            {
                string active = string.Empty;
                int step = 5;
                if (totalPages <= step)
                {
                    for (int i = 1; i <= totalPages; i++)
                    {
                        active = (currentPage == i) ? "class=\"active\"" : "";
                        sbPaginator.Append("<a href=\"javascript:pageClick(" + i + ");\" data-page=" + i + " " + active + ">" + i + "</a>");
                    }
                }
                else
                {
                    active = (currentPage == 1) ? "class=\"active\"" : "";
                    sbPaginator.Append("<a " + active + " href=\"javascript:pageClick(1);\" data-page=1\">首页</a>");

                    int prev = (currentPage - step / 2) < 1 ? 1 : (currentPage - step / 2);
                    int next = (prev + step - 1) > totalPages ? totalPages : (prev + step - 1);
                    prev = (next - prev + 1 < step) ? next - step + 1 : prev;
                    prev = (prev < 1) ? 1 : prev;

                    for (int i = prev; i <= next; i++)
                    {
                        active = (currentPage == i) ? "class=\"active\"" : "";
                        sbPaginator.Append("<a " + active + " href=\"javascript:pageClick(" + i + ");\" data-page=" + i + ">" + i + "</a>");
                    }

                    active = (currentPage == totalPages) ? "class=\"active\"" : "";
                    sbPaginator.Append("<a " + active + " href=\"javascript:pageClick(" + totalPages + ");\" data-page=" + totalPages + "\">尾页</a>");
                }
            }
            return sbPaginator.ToString();
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable PaginatorData(string strSql, string strSqlNum, string orderby, int currentPage, int pageSize)
        {
            int totalRecords = int.Parse(QGYHelper.DataBase.DbHelperSQL.GetSingle(strSqlNum).ToString());
            int totalPages = (int)Math.Ceiling((double)totalRecords / (double)pageSize);
            int startIndex = (currentPage - 1) * pageSize + 1;
            int endIndex = currentPage * pageSize;
            endIndex = (endIndex > totalRecords) ? totalRecords : endIndex;

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT * FROM ( ");
            sbSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                sbSql.Append("order by " + orderby);
            }
            sbSql.Append(")AS Row,");
            sbSql.Append(strSql);
            sbSql.Append(" ) TT");
            sbSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return QGYHelper.DataBase.DbHelperSQL.Query(sbSql.ToString()).Tables[0]; 
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataTable PaginatorData(string strSql, string strSqlNum, string orderby, int currentPage, int pageSize, ref int totalRecords)
        {
            totalRecords = int.Parse(QGYHelper.DataBase.DbHelperSQL.GetSingle(strSqlNum).ToString());
            int totalPages = (int)Math.Ceiling((double)totalRecords / (double)pageSize);
            int startIndex = (currentPage - 1) * pageSize + 1;
            int endIndex = currentPage * pageSize;
            endIndex = (endIndex > totalRecords) ? totalRecords : endIndex;

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT * FROM ( ");
            sbSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                sbSql.Append("order by " + orderby);
            }
            sbSql.Append(")AS Row,");
            sbSql.Append(strSql);
            sbSql.Append(" ) TT");
            sbSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return QGYHelper.DataBase.DbHelperSQL.Query(sbSql.ToString()).Tables[0];
        }
    }
}