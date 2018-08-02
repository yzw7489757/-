using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QAMZN.Model;
/// <summary>
///tb_user_authentication 的摘要说明
/// </summary>
namespace QAMZN.BLL
{
    public partial class tb_user_authentication
    {
        private readonly QAMZN.DAL.tb_user_authentication dal = new QAMZN.DAL.tb_user_authentication();
      //  private readonly QAMZN.Model.tb_user_authentication model = new QAMZN.DAL.tb_user_authentication();
        public tb_user_authentication()
        { }

        #region 卖家身份验证
        /// <summary>
        /// 卖家身份验证（返回信息{result:1 成功 0 失败}）
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="country">所在国家</param>
        /// <param name="identity">用户类型（1 个人 2 公司）</param>
        /// <param name="identity_file">用户身份相关文件</param>
        /// <param name="doc_type">对账单类型（1信用卡2银行账户）</param>
        /// <param name="doc_file">对账单文件</param>
        /// <param name="email">电子邮件地址</param>
        /// <param name="phone">联系电话</param>
        /// <param name="sign">提交方式（1 保存草稿 2 提交审核）</param>
        /// <returns></returns>
        public int Add_authentication(int userid, string country, int identity, string identity_file, int doc_type, string doc_file, string email, string phone, int sign)
        {
          return  dal.Add_authentication(userid, country, identity, identity_file, doc_type, doc_file, email, phone, sign);
        }
        #endregion
    }
}