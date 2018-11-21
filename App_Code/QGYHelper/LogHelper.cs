using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace QGYHelper
{
    /// <summary>
    ///Excel操作类
    /// </summary>
    public class LogHelper
    { 

        /// <summary>
        /// 写入系统操作日志
        /// </summary>
        /// <param name="userid">操作人ID</param>
        /// <param name="modulename">模块名称</param>
        /// <param name="pagename">页面名称</param>
        /// <param name="optype">操作类型</param>
        /// <param name="opcontent">操作内容</param>
        /// <param name="opstate">操作状态</param>
        public static void WriteLog(string userid, string modulename, string pagename, string optype, string opcontent, string opstate)
        {
            //opcontent = opcontent.Replace("'", "''");
            //string sql = "insert into TB_Log(FLD_Employeeid,FLD_Modulename,FLD_Pagename,FLD_Type,FLD_State,FLD_Describe,FLD_Datetime) values('" + employeeid + "','" + modulename + "','" + pagename + "','" + optype + "','" + opstate + "','" + opcontent + "',getdate()) ";
            //QGYHelper.DataBase.DbHelperSQL.ExecuteSql(sql);
        }
    }
}