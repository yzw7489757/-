using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///tb_user_tax 的摘要说明
/// </summary>
namespace QAMZN.BLL
{
    public partial class tb_user_tax
    {
        private readonly QAMZN.DAL.tb_user_tax dal = new QAMZN.DAL.tb_user_tax();
        QAMZN.Model.tb_user_tax model = new Model.tb_user_tax();
        public tb_user_tax()
        {
        }

        #region 增加一条用户税务信息
        /// <summary>
        /// 增加一条用户税务信息
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="receive_income">获得收益人（1 企业 2 业务）</param>
        /// <param name="is_usperson">是否美国人（1 是 0 否）</param>
        /// <param name="company_name">法定公司名称</param>
        /// <param name="nationality">国籍</param>
        /// <param name="owner_type">收益所有人类型（1 个人 2 独资经营者 3 单一成员有限责任公司）</param>
        /// <param name="address_id">永久地址ID</param>
        /// <param name="mailing_address_id">邮寄地址ID</param>
        /// <param name="is_esignature">是否为IRS提供电子签名（1 是 0 否）</param>
        /// <returns></returns>
        public int AddUser_tax(int userid, int receive_income, int is_usperson, string company_name, string nationality, int owner_type, int address_id, int mailing_address_id, int is_esignature)
        {
            return dal.AddUser_tax(userid, receive_income, is_usperson, company_name, nationality, owner_type, address_id, mailing_address_id, is_esignature);
        }
        #endregion

        #region 初始化税务信息
        /// <summary>
        /// 初始化税务信息
        /// </summary>
        /// <param name="registered_address">永久地址ID</param>
        /// /// <param name="mailing_address_id">邮寄地址ID</param>
        /// <param name="strTax">字符串</param>
        public void GetTaxInfo(int userid, ref string strTax ,ref int? address_id, ref int? mailing_address_id)
        {
            model = dal.GetTaxInfo(userid);
          if (model != null)
          {
              address_id = model.address_id;
              mailing_address_id = model.mailing_address_id;
              //tax_id,receive_income,is_usperson,company_name,nationality,owner_type,address_id,mailing_address_id,is_esignature,user_id
              strTax = "\"tax_id\":\""+model.tax_id+"\",\"receive_income\":\""
                  + model.receive_income + "\",\"is_usperson\":\""
                  + model.is_usperson + "\",\"company_name\":\""
                  + model.company_name + "\",\"nationality\":\""
                  + model.nationality + "\",\"owner_type\":\""
                  + model.owner_type + "\",\"is_esignature\":\""
                  + model.is_esignature + "\",\"signature\":\""
                  + model.signature + "\"";
          }
          else
          {
              strTax = "";
          }

        }

        #endregion

        #region 更新用户税务信息

        /// <summary>
        /// 更新商户注册之税务信息
        /// </summary>
        /// <param name="tax_id">税务信息ID</param>
        /// <param name="receive_income">获得收益人（1 企业 2 业务）</param>
        /// <param name="is_usperson">是否美国人（1 是 0 否）</param>
        /// <param name="company_name">法定公司名称</param>
        /// <param name="nationality">国籍</param>
        /// <param name="owner_type">收益所有人类型（1 个人 2 独资经营者 3 单一成员有限责任公司）</param>
        /// <param name="address_id">永久地址ID</param>
        /// <param name="mailing_address_id">邮寄地址ID</param>
        /// <param name="is_esignature">是否为IRS提供电子签名（1 是 0 否）</param>
        /// <param name="user_id">用户ID</param>
        public bool Updatetax(int tax_id, int receive_income, int is_usperson, string company_name, string nationality, int owner_type, int address_id, int mailing_address_id, int is_esignature, int user_id,string signature)
        {
            model.tax_id = tax_id;
            model.receive_income = receive_income;
            model.is_usperson = is_usperson;
            model.company_name = company_name;
            model.nationality = nationality;
            model.owner_type = owner_type;
            model.address_id = address_id;
            model.mailing_address_id = mailing_address_id;
            model.is_esignature = is_esignature;
            model.user_id = user_id; 
            model.signature = signature;
           return  dal.Updatetax(model);
        }
        #endregion


        /// <summary>
        /// 获取地址编号和法定公司名称
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="address_id"></param>
        /// <param name="company_name"></param>
        public void GetUerTaxInfo(int userid, ref int address_id, ref string company_name,ref int tax_id)
        {
            model = dal.GetUerTaxInfo(userid);
            if(model!=null)
            {
                address_id = (int)model.address_id;
                company_name = model.company_name;
                tax_id = model.tax_id;
            }
        }
    }
}