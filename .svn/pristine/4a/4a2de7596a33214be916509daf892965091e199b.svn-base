using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.UI.WebControls;

namespace QGYHelper
{
    /// <summary>
    ///QGYPage 的摘要说明
    /// </summary>
    public class QGYPage : System.Web.UI.Page
    {
        public QGYPage()
        { }
        protected override void OnLoad(EventArgs e)
        {
            #region 试用来源判断
            
            if (QGYHelper.Config._TrialVerify)
            {
                if (Request.UrlReferrer == null || Request.UrlReferrer.Host != Request.Url.Host)
                {
                    Response.Write("非法访问！");
                    Response.End();
                }
            }
            #endregion

            if (!this.IsPostBack)
            {
                #region 页面头信息设置
                 
                QGYHelper.PageHelper.AddMetaName("robots", "all", this.Page);
                QGYHelper.PageHelper.AddMetaName("author", ConfigurationManager.AppSettings["SoftName"], this.Page);
                QGYHelper.PageHelper.AddMetaName("Copyright", "Copyright " + ConfigurationManager.AppSettings["Copyright"], this.Page);
                QGYHelper.PageHelper.AddMetaName("description", ConfigurationManager.AppSettings["SoftName"], this.Page);
                QGYHelper.PageHelper.AddMetaName("keywords", ConfigurationManager.AppSettings["SoftName"], this.Page);

                string favicon = QGYHelper.PageHelper.GetRootUrl() + @"/favicon.ico";
                QGYHelper.PageHelper.AddLink("bookmark", favicon, "image/x-icon", this.Page);
                QGYHelper.PageHelper.AddLink("icon", favicon, "image/x-icon", this.Page);
                QGYHelper.PageHelper.AddLink("Shortcut Icon", favicon, "image/x-icon", this.Page);


                QGYHelper.PageHelper.AddMetaHttpEquiv("X-UA-Compatible", "IE=EmulateIE7", this.Page);
                QGYHelper.PageHelper.AddMetaHttpEquiv("X-UA-Compatible", "IE=7", this.Page);

                #endregion
            }
            base.OnLoad(e);
        }
    }
}