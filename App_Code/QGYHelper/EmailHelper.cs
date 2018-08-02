using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using QGYHelper.DataBase;
namespace QGYHelper
{

    public class EmailReturn
    {
        public string result { get; set; }
        public string error { get; set; }
    }
    public class EmailHelper
    {

        #region 判断邮箱账号是否存在

        /// <summary>
        /// 判断邮箱账号是否存在
        /// </summary>
        /// <param name="email">邮箱账号</param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static bool IsExist(string email, ref string error)
        {
            Hashtable ht = new Hashtable();  //Hashtable 为webservice所需要的参数集
            ht.Add("account", email);
            string xx = QGYHelper.WebServiceCaller.QueryPostWebService(QGYHelper.Config._emailAPI, "IsEmail1", ht);
            EmailReturn EmailReturn = new EmailReturn();
            EmailReturn = (EmailReturn)Newtonsoft.Json.JsonConvert.DeserializeObject(xx, typeof(EmailReturn));
            string result = EmailReturn.result;
            error = QGYHelper.FormatCode.FormatUrlDecode(EmailReturn.error);
            if (result == "0")
            {
                return false;
            }

            return true;
        }
        #endregion

        #region 发送邮件

        /// <summary>
        /// 店铺开通流程中发送确认邮箱的邮件
        /// </summary>
        /// <param name="userid">学生id</param>
        /// <param name="account">学生账户</param>
        /// <param name="trainingid">实训id</param>
        /// <param name="traintype">实训类型</param>
        /// <param name="store_model">店铺对象</param>
        /// <param name="error">错误信息</param>
        /// <returns></returns>
        public static bool SendEmail(string theme, string content, string toEmail, string fromEmail, ref string error)
        {
            Hashtable ht = new Hashtable();  //Hashtable 为webservice所需要的参数集
            ht.Add("theme", theme);
            ht.Add("content", content);
            ht.Add("toEmail", toEmail);
            ht.Add("fromEmail", fromEmail);
            string xx = QGYHelper.WebServiceCaller.QueryPostWebService(QGYHelper.Config._emailAPI, "Send", ht);

            EmailReturn EmailReturn = new EmailReturn();
            EmailReturn = (EmailReturn)Newtonsoft.Json.JsonConvert.DeserializeObject(xx, typeof(EmailReturn));
            string result = EmailReturn.result;
            error = QGYHelper.FormatCode.FormatUrlDecode(EmailReturn.error);
            if (result == "0")
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 找回密码邮件
        
        /// <summary>
        /// 找回密码邮件
        /// </summary>
        /// <param name="token">用户标识</param>
        /// <param name="toEmail">用户邮箱</param>
        /// <param name="error">返回错误信息</param>
        /// <returns></returns>
        public static bool FindPassword(string token,string toEmail, ref string error)
        {
            string content = "<p>我们收到了重设与此电子邮件地址关联的密码的请求。 如果是您提交的请求，请遵照下面的指示操作。</p>";

            content += "<p>单击下面的链接通过我们的安全服务器重新设置您的密码：</p>";

            content += "<p><a href=\"" + QGYHelper.Config._ApiUrl + "/create_new_password.html?token=" + token + "\" target=\"_blank\">" + QGYHelper.Config._ApiUrl + "/create_new_password.html?token=" + token + "</a></p>";
            content += "<p>如果您没有请求重设密码，则完全可以忽略此邮件。请放心，您的客户帐户是安全的。</p>";


            content += "<p>如果单击链接不起作用，可以将链接复制并粘贴到浏览器的地址窗口，或将地址重新键入地址窗口。在返回到 Amazon后，我们将提供如何重设密码的指示。</p>";

            content += "<p>Amazon.cn 在任何时候都不会给您发送电子邮件并要求您披露或核实您的  Amazon.cn 密码、信用卡，或银行帐号。如果您收到可疑的电子邮件并且其中包含更新帐户信息的链接，请不要点击该链接，相反，请将该电子邮件报告给 Amazon.cn 以便进行调查。感谢您访问 Amazon！ </p>";
            return SendEmail("Amazon.cn 密码帮助", content, toEmail, QGYHelper.Config._qamznEmail, ref error);
        }
        #endregion
    }
}