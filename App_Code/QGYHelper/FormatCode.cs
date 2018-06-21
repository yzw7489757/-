using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QGYHelper
{
    public class FormatCode
    {
        /// <summary>
        /// 对应encodeURIComponent编码
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string FormatUrlEncode(string content)
        { 
            return HttpUtility.UrlEncode(content).Replace("+", "%20");
        }

        /// <summary>
        /// encodeURIComponent对应解码
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string FormatUrlDecode(string content)
        {
            return HttpUtility.UrlDecode(content);
        } 
    }
}