using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QGYHelper
{
    /// <summary>
    ///配置文件
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 是否开启外网试用检测功能
        /// </summary>
        public readonly static bool _TrialVerify = false;
        /// <summary>
        /// 软件试用外部入口地址
        /// </summary>
        public readonly static string _TrialUrl = "http://soft.qiangeyuan.com";

         
        public readonly static string _wishpostUrl = System.Configuration.ConfigurationManager.AppSettings["WishpostUrl"];//Wish邮访问地址
        public readonly static string _paroneerUrl = System.Configuration.ConfigurationManager.AppSettings["ParoneerUrl"];//派安盈访问地址
        public readonly static string _emailUrl = System.Configuration.ConfigurationManager.AppSettings["EmailUrl"];//电子邮箱访问地址
        public readonly static string _emailAPI = System.Configuration.ConfigurationManager.AppSettings["EmailUrl"] + "/EmailService.asmx";//发送邮件请求接口地址
        public readonly static string _bankUrl = System.Configuration.ConfigurationManager.AppSettings["BankUrl"];//商业银行访问地址
        public readonly static string _QGYUrl = System.Configuration.ConfigurationManager.AppSettings["QGYUrl"];//商课游地址 
        public readonly static string _ApiUrl = System.Configuration.ConfigurationManager.AppSettings["ApiUrl"];//数据接口地址
        public readonly static string _softName = System.Configuration.ConfigurationManager.AppSettings["softName"]; //软件名称

        public readonly static string _qamznEmail = "qamzn@qgy.com"; //软件名称

    }
}