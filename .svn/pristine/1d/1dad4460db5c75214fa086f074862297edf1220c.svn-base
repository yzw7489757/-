using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.Data.SqlClient;

namespace QGYHelper
{
    /// <summary>
    /// 公共访问类
    /// </summary>
    public class Common
    {

        public Common()
        { }

        #region 获得当前用户IP

        /// <summary>
        /// 获得当前用户IP
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            return System.Web.HttpContext.Current.Request.ServerVariables["Remote_Host"];
        }
        #endregion

        #region 获得根目录（相对路径）

        /// <summary>
        /// 获得根目录（相对路径）
        /// </summary>
        /// <returns></returns>
        public static string GetRootVirtualPath()
        {
            string AppPath = "";
            HttpContext HttpCurrent = HttpContext.Current;
            HttpRequest Req;
            if (HttpCurrent != null)
            {

                Req = HttpCurrent.Request;
                if (Req.ApplicationPath == null || Req.ApplicationPath == "/")
                {
                    //直接安装在Web站点 
                    AppPath = "";
                }

                else
                {
                    //安装在虚拟子目录下 
                    AppPath = Req.ApplicationPath;
                }

            }
            return AppPath;
        }
        #endregion

        #region 菜单截取

        /// <summary>
        /// 菜单截取
        /// </summary>
        /// <param name="oldStr"></param>
        /// <param name="maxLength"></param>
        /// <param name="endWith"></param>
        /// <returns></returns>
        public static string CutMenu(string oldStr, int maxLength, string endWith)
        {
            //判断原字符串是否为空  
            if (string.IsNullOrEmpty(oldStr))
                return oldStr + endWith;

            //返回字符串的长度必须大于1  
            if (maxLength < 1)
                throw new Exception("返回的字符串长度必须大于[0] ");

            //判断原字符串是否大于最大长度  
            if (oldStr.Length > maxLength)
            {
                //截取原字符串  
                string strTmp = oldStr.Substring(0, maxLength);


                //判断后缀是否为空  
                if (string.IsNullOrEmpty(endWith))
                    return strTmp;
                else
                    return strTmp + endWith;
            }
            return oldStr;
        }
        #endregion

        #region 提取摘要，是否清除HTML代码

        /// <summary> 
        /// 提取摘要，是否清除HTML代码 
        /// </summary> 
        /// <param name="content"></param> 
        /// <param name="length"></param> 
        /// <param name="StripHTML"></param> 
        /// <returns></returns> 
        public static string GetContentSummary(string content, int length, bool StripHTML)
        {
            if (string.IsNullOrEmpty(content) || length == 0)
                return "";
            if (StripHTML)
            {
                System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex("<[^>]*>");
                content = re.Replace(content, "");
                content = content.Replace("　", "").Replace(" ", "");
                if (content.Length <= length)
                    return content;
                else return content.Substring(0, length) + "……";
            }
            else
            {
                if (content.Length <= length)
                    return content;
                int pos = 0, npos = 0, size = 0;
                bool firststop = false, notr = false, noli = false;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                while (true)
                {
                    if (pos >= content.Length)
                        break;
                    string cur = content.Substring(pos, 1);
                    if (cur == "<")
                    {
                        string next = content.Substring(pos + 1, 3).ToLower();
                        if (next.IndexOf("p") == 0 && next.IndexOf("pre") != 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                        }
                        else if (next.IndexOf("/p") == 0 && next.IndexOf("/pr") != 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length) sb.Append("<br/>");
                        }
                        else if (next.IndexOf("br") == 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length)
                                sb.Append("<br/>");
                        }
                        else if (next.IndexOf("img") == 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length)
                            {
                                sb.Append(content.Substring(pos, npos - pos));
                                size += npos - pos + 1;
                            }
                        }
                        else if (next.IndexOf("li") == 0 || next.IndexOf("/li") == 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length)
                            {
                                sb.Append(content.Substring(pos, npos - pos));
                            }
                            else
                            {
                                if (!noli && next.IndexOf("/li") == 0)
                                {
                                    sb.Append(content.Substring(pos, npos - pos)); noli = true;
                                }
                            }
                        }
                        else if (next.IndexOf("tr") == 0 || next.IndexOf("/tr") == 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length)
                            {
                                sb.Append(content.Substring(pos, npos - pos));
                            }
                            else
                            {
                                if (!notr && next.IndexOf("/tr") == 0)
                                {
                                    sb.Append(content.Substring(pos, npos - pos)); notr = true;
                                }
                            }
                        }
                        else if (next.IndexOf("td") == 0 || next.IndexOf("/td") == 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length)
                            {
                                sb.Append(content.Substring(pos, npos - pos));
                            }
                            else
                            {
                                if (!notr)
                                {
                                    sb.Append(content.Substring(pos, npos - pos));
                                }
                            }
                        }
                        else
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            sb.Append(content.Substring(pos, npos - pos));
                        }
                        if (npos <= pos)
                            npos = pos + 1;
                        pos = npos;
                    }
                    else
                    {
                        if (size < length)
                        {
                            sb.Append(cur); size++;
                        }
                        else
                        {
                            if (!firststop)
                            {
                                sb.Append("……");
                                firststop = true;
                            }
                        }
                        pos++;
                    }
                }
                return sb.ToString();
            }
        }

        #endregion 

        #region 格式化学习时间

        /// <summary>
        /// 格式化学习时间
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static string FormatSecond(int seconds)
        {
            TimeSpan ts = new TimeSpan(0, 0, seconds);
            string strTime = string.Empty;
            if (ts.Hours > 0)
                strTime += ts.Hours + " 小时 ";
            if (ts.Minutes > 0)
                strTime += ts.Minutes + " 分钟 ";
            if (strTime == "" && ts.Seconds == 0)
                strTime = "0 秒";
            else if(ts.Seconds > 0)
                strTime += ts.Seconds + " 秒";
            return strTime;
        }
        #endregion

        #region 获得时长

        /// <summary>
        /// 获得时长
        /// </summary>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">结束时间</param>
        /// <returns>返回(秒)单位，比如: 0.00239秒</returns>
        public static int ExecDateDiff(DateTime dateBegin, DateTime dateEnd)
        {
            TimeSpan ts1 = new TimeSpan(dateBegin.Ticks);
            TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
            TimeSpan ts3 = ts1.Subtract(ts2).Duration();
            //你想转的格式
            return (int)Math.Ceiling(ts3.TotalMilliseconds / 1000);
        }
        #endregion

        #region 获得时长

        /// <summary>
        /// 获得时长
        /// </summary>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">结束时间</param> 
        public static string GetDateDiff(DateTime dateBegin, DateTime dateEnd)
        {
            return FormatSecond(ExecDateDiff(dateBegin, dateEnd));
        }
        #endregion

        #region 读取xml数据


        #region 读取XML数据例：<resourceclassify><field id="0"><name>天问</name><sex>男</sex></field></resourceclassify>

        /// <summary>
        /// 读取XML数据
        /// </summary>
        /// <param name="xmlFile">虚拟路径</param>
        /// <param name="rootName">节点路径（例：/root/resourceclassify）</param>
        /// <param name="keyFiledName">主属性名称</param>
        /// <param name="arrFiledName">子节点名称数组</param>
        /// <returns></returns>
        public static DataTable GetXMLData(string xmlFile, string rootName, string keyFiledName, string[] arrFiledName)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(keyFiledName, typeof(string));
            foreach (string filed in arrFiledName)
            {
                dt.Columns.Add(filed, typeof(string));
            }

            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            System.Xml.XmlReaderSettings settings = new System.Xml.XmlReaderSettings();
            settings.IgnoreComments = true;//忽略文档里面的注释 

            System.Xml.XmlReader reader = System.Xml.XmlReader.Create(xmlFile, settings);
            xmlDoc.Load(reader);  //加载Xml文件  

            System.Xml.XmlNode xn = xmlDoc.SelectSingleNode(rootName);  //获取根节点  

            System.Xml.XmlNodeList xnl = xn.ChildNodes;  //得到根节点的所有子节点
            DataRow dr;
            foreach (System.Xml.XmlNode xn1 in xnl)
            {
                // 将节点转换为元素，便于得到节点的属性值
                System.Xml.XmlElement xe = (System.Xml.XmlElement)xn1;


                dr = dt.NewRow();

                //得到keyFiledName属性的属性值
                dr[keyFiledName] = xe.GetAttribute(keyFiledName).ToString();

                //得到Book节点的所有子节点
                System.Xml.XmlNodeList xnl0 = xe.ChildNodes;
                foreach (System.Xml.XmlNode xn2 in xnl0)
                {
                    foreach (string filed in arrFiledName)
                    {
                        if (xn2.Name == filed)
                        {
                            dr[filed] = xn2.InnerXml;
                            break;
                        }
                    }
                }
                dt.Rows.Add(dr);
            }
            reader.Close();
            return dt;
        }

        #endregion

        #region 读取XML数据（无注释）例：<resourceclassify><field id="0"><name>天问</name><sex>男</sex></field></resourceclassify>

        /// <summary>
        /// 读取XML数据（无注释）
        /// </summary>
        /// <param name="xmlFile">虚拟路径</param>
        /// <param name="rootName">节点路径（例：/root/resourceclassify）</param>
        /// <param name="keyFiledName">主属性名称</param>
        /// <param name="arrFiledName">子节点名称数组</param>
        /// <returns></returns>
        public static DataTable GetXMLDataNoAn(string xmlFile, string rootName, string keyFiledName, string[] arrFiledName)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(keyFiledName, typeof(string));
            foreach (string filed in arrFiledName)
            {
                dt.Columns.Add(filed, typeof(string));
            }

            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(xmlFile);  //加载Xml文件  

            System.Xml.XmlNode xn = xmlDoc.SelectSingleNode(rootName);  //获取根节点
            System.Xml.XmlNodeList xnl = xn.ChildNodes;  //得到根节点的所有子节点
            DataRow dr;
            foreach (System.Xml.XmlNode xn1 in xnl)
            {
                // 将节点转换为元素，便于得到节点的属性值
                System.Xml.XmlElement xe = (System.Xml.XmlElement)xn1;


                dr = dt.NewRow();

                //得到keyFiledName属性的属性值
                dr[keyFiledName] = xe.GetAttribute(keyFiledName).ToString();

                //得到Book节点的所有子节点
                System.Xml.XmlNodeList xnl0 = xe.ChildNodes;
                foreach (System.Xml.XmlNode xn2 in xnl0)
                {
                    foreach (string filed in arrFiledName)
                    {
                        if (xn2.Name == filed)
                        {
                            dr[filed] = xn2.InnerXml;
                            break;
                        }
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        #endregion

        #region 读取XML数据（无注释）例：<school><phone>0578-3123592</phone><email>sales@qiangeyuan.com</email></school>

        /// <summary>
        /// 读取XML数据（无注释）
        /// </summary>
        /// <param name="xmlFile">虚拟路径</param>
        /// <param name="rootName">节点路径（例：/root/resourceclassify）</param>
        /// <param name="arrFiledName">子节点名称数组</param>
        /// <returns></returns>
        public static DataTable GetXMLDataNoAn(string xmlFile, string rootName, string[] arrFiledName)
        {
            DataTable dt = new DataTable();
            foreach (string filed in arrFiledName)
            {
                dt.Columns.Add(filed, typeof(string));
            }

            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(xmlFile);  //加载Xml文件  

            System.Xml.XmlNode xn = xmlDoc.SelectSingleNode(rootName);  //获取根节点 
            System.Xml.XmlNodeList xnl = xn.ChildNodes;  //得到根节点的所有子节点
            DataRow dr = dt.NewRow();
            foreach (System.Xml.XmlNode xn1 in xnl)
            {
                foreach (string filed in arrFiledName)
                {
                    if (xn1.Name == filed)
                    {
                        dr[filed] = xn1.InnerXml;
                        break;
                    }
                }
            }
            dt.Rows.Add(dr);
            return dt;
        }

        #endregion

        #endregion

        #region 从Excle中获得数据

        /// <summary>
        /// 从Excle中获得数据
        /// </summary>
        /// <param name="filePath">Excel文件路径</param> 
        /// <returns></returns>
        public static DataTable GetDataFromExcel(string filePath)
        {
            string strExt = System.IO.Path.GetExtension(filePath).ToLower().Trim();
            string strCon = string.Empty;
            if (strExt == ".xls")// 2003格式 
                strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;IMEX=1';Persist Security Info=True";
            else if (strExt == ".xlsx")  //2007或以上格式 
                strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0;IMEX=1';Persist Security Info=True";
            else
                return null;

            System.Data.OleDb.OleDbConnection Conn = new System.Data.OleDb.OleDbConnection(strCon);
            try
            {
                Conn.Open();
                string strCom = "SELECT * FROM [Sheet1$]";
                System.Data.OleDb.OleDbDataAdapter myCommand = new System.Data.OleDb.OleDbDataAdapter(strCom, Conn);
                DataSet ds = new DataSet();
                myCommand.Fill(ds, "[Sheet1$]");
                return ds.Tables[0];
            }
            catch (Exception ex)
            { 
            }
            finally
            {
                Conn.Close();
            }
            return null;
        }

        /// <summary>
        /// 从Excle中获得数据
        /// </summary>
        /// <param name="filePath">Excel文件路径</param> 
        /// <param name="sheetName">sheet名称</param>
        /// <returns></returns>
        public static DataTable GetDataFromExcel(string filePath, string sheetName)
        {
            string strExt = System.IO.Path.GetExtension(filePath).ToLower().Trim();
            string strCon = string.Empty;
            if (strExt == ".xls")// 2003格式 
                strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;IMEX=1';Persist Security Info=True";
            else if (strExt == ".xlsx")  //2007或以上格式 
                strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0;IMEX=1';Persist Security Info=True";
            else
                return null;

            System.Data.OleDb.OleDbConnection Conn = new System.Data.OleDb.OleDbConnection(strCon);
            try
            {
                Conn.Open();
                string strCom = "SELECT * FROM [" + sheetName + "]";
                System.Data.OleDb.OleDbDataAdapter myCommand = new System.Data.OleDb.OleDbDataAdapter(strCom, Conn);
                DataSet ds = new DataSet();
                myCommand.Fill(ds, "[Sheet1$]");
                return ds.Tables[0];
            }
            catch (Exception ex)
            { 
            }
            finally
            {
                Conn.Close();
            }
            return null;
        }

        /// <summary>
        /// 获得Excel的Sheet名称
        /// </summary>
        /// <param name="excelFilename"></param>
        /// <returns></returns>
        public static DataTable GetExcelTable(string excelFilename)
        {
            string strExt = System.IO.Path.GetExtension(excelFilename).ToLower().Trim();
            string connectionString = string.Empty;
            if (strExt == ".xls")// 2003格式 
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelFilename + ";Extended Properties='Excel 8.0;IMEX=1';Persist Security Info=True";
            else if (strExt == ".xlsx")  //2007或以上格式 
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFilename + ";Extended Properties='Excel 12.0;IMEX=1';Persist Security Info=True";
            else
                return null;

            DataTable table = new DataTable();
            using (System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection(connectionString))
            {
                connection.Open();
                table = connection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
                connection.Close();
            }
            return table;
        }

        #region 获得Excel的第一个的数据

        /// <summary>
        /// 获得Excel的第一个的数据
        /// </summary>
        /// <param name="excelFilename"></param>
        /// <returns></returns>
        public static DataTable GetExcelFirstSheetData(string excelFilename)
        {
            string strExt = System.IO.Path.GetExtension(excelFilename).ToLower().Trim();
            string connectionString = string.Empty;
            if (strExt == ".xls")// 2003格式 
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelFilename + ";Extended Properties='Excel 8.0;IMEX=1';Persist Security Info=True";
            else if (strExt == ".xlsx")  //2007或以上格式 
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFilename + ";Extended Properties='Excel 12.0;IMEX=1';Persist Security Info=True";
            else
                return null;

            DataSet ds = new DataSet();
            string tableName;
            using (System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection(connectionString))
            {
                connection.Open();
                DataTable table = connection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
                tableName = table.Rows[0]["Table_Name"].ToString();
                string strExcel = "select * from " + "[" + tableName + "]";
                System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(strExcel, connectionString);
                adapter.Fill(ds, tableName);
                connection.Close();
            }
            return ds.Tables[tableName];
        }
        #endregion

        #endregion

        #region 使用C#把发表的时间改为几个月,几天前,几小时前,几分钟前,或几秒前

        /// <summary>
        /// 使用C#把发表的时间改为几个月,几天前,几小时前,几分钟前,或几秒前
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DateStringFromNow(DateTime dt)
        {
            TimeSpan span = DateTime.Now - dt;
            if (span.TotalDays > 60)
            {
                return dt.ToShortDateString();
            }
            else
            {
                if (span.TotalDays > 30)
                {
                    return
                    "1个月前";
                }
                else
                {
                    if (span.TotalDays > 14)
                    {
                        return
                        "2周前";
                    }
                    else
                    {
                        if (span.TotalDays > 7)
                        {
                            return
                            "1周前";
                        }
                        else
                        {
                            if (span.TotalDays > 1)
                            {
                                return
                                string.Format("{0}天前", (int)Math.Floor(span.TotalDays));
                            }
                            else
                            {
                                if (span.TotalHours > 1)
                                {
                                    return
                                    string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
                                }
                                else
                                {
                                    if (span.TotalMinutes > 1)
                                    {
                                        return
                                        string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
                                    }
                                    else
                                    {
                                        if (span.TotalSeconds >= 1)
                                        {
                                            return
                                            string.Format("{0}秒前", (int)Math.Floor(span.TotalSeconds));
                                        }
                                        else
                                        {
                                            return
                                            "1秒前";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region 格式化文件大小

        /// <summary>
        /// 格式化文件大小
        /// </summary>
        /// <param name="fileSize"></param>
        /// <returns></returns>
        public static String FormatFileSize(Int64 fileSize)
        {
            if (fileSize < 0)
            {
                throw new ArgumentOutOfRangeException("fileSize");
            }
            else if (fileSize >= 1024 * 1024 * 1024)
            {
                return string.Format("{0:########0.00} GB", ((Double)fileSize) / (1024 * 1024 * 1024));
            }
            else if (fileSize >= 1024 * 1024)
            {
                return string.Format("{0:####0.00} MB", ((Double)fileSize) / (1024 * 1024));
            }
            else if (fileSize >= 1024)
            {
                return string.Format("{0:####0.00} KB", ((Double)fileSize) / 1024);
            }
            else
            {
                return string.Format("{0} bytes", fileSize);
            }
        }
        #endregion

        #region 获得当前时间

        /// <summary>
        /// 获得当前时间
        /// </summary>
        /// <returns></returns>
        public static DateTime DateTimeNow()
        {
            return DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        #endregion

        #region 判断是否是图片
        public static bool isImg(string FileName)
        {
            string[] extendFileName = { ".psd", ".jpg", ".gif", ".bmp", ".BMP", ".PSD", ".JPG", ".GIF" };

            string[] arr = FileName.Split('.');
            if (arr.Length == 0)
                return false;
            string cjm = "." + arr[arr.Length - 1];
            bool isimg = false;
            if (arr.Length == 2)
                for (int j = 0; j < extendFileName.Length && !isimg; j++)
                {
                    if (cjm == extendFileName[j])
                        isimg = true;
                }
            return isimg;
        }
        #endregion
    }
}