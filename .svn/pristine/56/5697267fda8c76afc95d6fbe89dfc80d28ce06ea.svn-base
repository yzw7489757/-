using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QGYHelper
{
    /// <summary>
    ///SessionCookieConfig 的摘要说明
    /// </summary>
    public class LoginHelper
    {

        #region 平台Session和Cookie值

        #region 获得Session值

        /// <summary>
        /// 获得Session值
        /// </summary>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        public static string GetInSessionValue(string key)
        {

            string sessionKey = key + "Session";
            string cookieKey = key + "Cookie";
            if (QGYHelper.CookiesSessionHelper.IsExistSession(sessionKey))
                return QGYHelper.CookiesSessionHelper.ReadSession(sessionKey);
            else if (QGYHelper.CookiesSessionHelper.IsExistCookie(cookieKey))
            {
                QGYHelper.CookiesSessionHelper.WriteSession(sessionKey, QGYHelper.CookiesSessionHelper.ReadCookies(cookieKey));
                return QGYHelper.CookiesSessionHelper.ReadSession(sessionKey);
            }
            return "0";
        }
        /// <summary>
        /// 获得Session值
        /// </summary>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        public static string GetInCookieValue(string key)
        {
            string cookieKey = key + "Cookie";
            if (QGYHelper.CookiesSessionHelper.IsExistCookie(cookieKey))
            {
                return QGYHelper.CookiesSessionHelper.ReadCookies(cookieKey);
            }
            return "0";
        }
        #endregion

        #region 设置Session和Cookie值

        /// <summary>
        /// 设置Session和Cookie值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void SetSessionAndCookie(string key, string value)
        {
            QGYHelper.CookiesSessionHelper.WriteSession(key + "Session", value);
            QGYHelper.CookiesSessionHelper.WriteCookies(key + "Cookie", value);
        }
        /// <summary>
        /// 设置Session和Cookie值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void SetCookie(string key, string value)
        {
            QGYHelper.CookiesSessionHelper.WriteCookies(key + "Cookie", value);
        }
        #endregion

        #region 删除Session和Cookie

        /// <summary>
        /// 设置Session和Cookie值
        /// </summary>
        /// <param name="key">键</param> 
        public static void DelSessionAndCookie(string key)
        {
            QGYHelper.CookiesSessionHelper.DeleteSession(key + "Session");
            QGYHelper.CookiesSessionHelper.DeleteCookies(key + "Cookie");
        }

        /// <summary>
        /// 设置Session和Cookie值
        /// </summary>
        /// <param name="key">键</param> 
        public static void DelCookie(string key)
        {
            QGYHelper.CookiesSessionHelper.DeleteCookies(key + "Cookie");
        }
        #endregion

        #region 是否存在某Session和Cookie值

        /// <summary>
        /// 是否存在某Session和Cookie值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static bool IsExitSessionOrCookie(string key)
        {
            string sessionKey = key + "Session";
            string cookieKey = key + "Cookie";
            if (!QGYHelper.CookiesSessionHelper.IsExistSession(sessionKey))
            {
                if (!QGYHelper.CookiesSessionHelper.IsExistCookie(cookieKey))
                {
                    return false;
                }
                else
                    return true;
            }
            else
                return true;
        }
        #endregion

        #endregion         

        #region 商户账号

        /// <summary>
        /// 保存或获取商户账号ID
        /// </summary>
        public static int LoginAccountIDCookie
        {
            set { SetSessionAndCookie("LOGINACCOUNTID", value.ToString()); }
            get { return (IsExitSessionOrCookie("LOGINACCOUNTID")) ? int.Parse(GetInSessionValue("LOGINACCOUNTID")) : 0; }
        } 

        /// <summary>
        /// 保存或获取商户账号
        /// </summary>
        public static string LoginAccountCookie
        {
            set { SetSessionAndCookie("LOGINACCOUNT", value); }
            get { return (IsExitSessionOrCookie("LOGINACCOUNT")) ? GetInSessionValue("LOGINACCOUNT") : null; }
        } 
        #endregion

        #region 清除管理员/教师/学生登录信息

        /// <summary>
        /// 清除登录信息
        /// </summary>
        public static void ClearLoginSession()
        {
            LoginHelper.LoginAccountIDCookie = 0; 
            LoginHelper.LoginAccountCookie = string.Empty;
        }
        #endregion
         
    } 
}