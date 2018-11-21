using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
///tb_user_address 的摘要说明
/// </summary>
namespace QAMZN.BLL
{

    public partial class tb_user_address
    {
        public tb_user_address()
        {
        }
        private readonly QAMZN.DAL.tb_user_address dal = new QAMZN.DAL.tb_user_address();
        QAMZN.Model.tb_user_address model = new QAMZN.Model.tb_user_address();
        #region 新增地址
        /// <summary>
        /// 新增地址
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="address">街道地址</param>
        /// <param name="city">市/镇</param>
        /// <param name="province">州/地区/省</param>
        /// <param name="country">国家/地区</param>
        /// <param name="zipcode">邮编</param>
        /// <returns></returns>
        public int AddAddress(int userid, string address, string city, string province, string country, string zipcode)
        {
           return dal.AddAddress(userid, address, city, province, country, zipcode);
        }
        #endregion

        #region 商户注册之账单存款

        /// <summary>
        /// 商户注册之账单存款（返回信息{result:1 成功 0 失败}）
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="card_number">信用卡号</param>
        /// <param name="card_month">有效期限（月）</param>
        /// <param name="card_year">有效期限（年）</param>
        /// <param name="card_holder">持卡人姓名</param>
        /// <param name="addressid">账单地址ID</param>
        /// <param name="address">街道地址</param>
        /// <param name="city">市/镇</param>
        /// <param name="province">州/地区/省</param>
        /// <param name="country">国家/地区</param>
        /// <param name="zipcode">邮编</param>
        /// <param name="bank_location">银行地址</param>
        /// <param name="account_holder">账户持有人姓名</param>
        /// <param name="routing_number">9 位数的汇款路径号码</param>
        /// <param name="account_number">银行账号</param>
        public int Pro_initial_Charge_deposit(int userid, string card_number, int card_month, int card_year, string card_holder, int addressid, string address, string city, string province, string country, string zipcode, string bank_location, string account_holder, string routing_number, string account_number)
        {
            return dal.Pro_initial_Charge_deposit(userid, card_number, card_month, card_year, card_holder, addressid, address, city, province, country, zipcode, bank_location, account_holder, routing_number, account_number);
        }
        #endregion

        #region 商户注册之账单存款

        /// <summary>
        /// 商户注册之账单存款（返回信息{result:1 成功 0 失败}）
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="card_number">信用卡号</param>
        /// <param name="card_month">有效期限（月）</param>
        /// <param name="card_year">有效期限（年）</param>
        /// <param name="card_holder">持卡人姓名</param>
        /// <param name="addressid">账单地址ID</param>
        /// <param name="address">街道地址</param>
        /// <param name="city">市/镇</param>
        /// <param name="province">州/地区/省</param>
        /// <param name="country">国家/地区</param>
        /// <param name="zipcode">邮编</param>
        /// <param name="bank_location">银行地址</param>
        /// <param name="account_holder">账户持有人姓名</param>
        /// <param name="routing_number">9 位数的汇款路径号码</param>
        /// <param name="account_number">银行账号</param>
        public int Proc_update_Charge_deposit(int userid, string card_number, int card_month, int card_year, string card_holder, int addressid, string address, string city, string province, string country, string zipcode, string bank_location, string account_holder, string routing_number, string account_number, int? chargeId,  int? depositId)
        {
            return dal.Proc_update_Charge_deposit(userid, card_number, card_month, card_year, card_holder, addressid, address, city, province, country, zipcode, bank_location, account_holder, routing_number, account_number, chargeId, depositId);
        }
        #endregion

        #region 新增地址2
        /// <summary>
        /// 新增地址2
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="address">街道地址</param>
        /// <param name="address2">公寓/漏楼层</param>
        /// <param name="city">市/镇</param>
        /// <param name="province">州/地区/省</param>
        /// <param name="country">国家/地区</param>
        /// <param name="zipcode">邮编</param>
        /// <param name="addressid">地址编号</param>
        /// <param name="type">新增地址类型（1,一般地址2，收货地址3，邮寄地址）</param>
        /// <param name="name">地址名称</param>
        /// <param name="email">邮箱地址</param>
        /// <param name="phone">手机号</param>
        /// <param name="full_name">联系人姓名</param>
        /// <returns></returns>
        public int AddAddress2(int userid, string address, string address2, string city, string province, string country, string zipcode, ref int addressid, int type)
        {
            return dal.AddAddress2(userid, address, address2, city, province, country, zipcode, type);
        }
        #endregion


        #region 新增地址3
        /// <summary>
        /// 新增地址3
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="address">街道地址</param>
        /// <param name="address2">公寓/漏楼层</param>
        /// <param name="city">市/镇</param>
        /// <param name="province">州/地区/省</param>
        /// <param name="country">国家/地区</param>
        /// <param name="zipcode">邮编</param>
        /// <param name="addressid">地址编号</param>
        /// <param name="type">新增地址类型（1,一般地址2，收货地址3，邮寄地址）</param>
        /// <param name="name">地址名称</param>
        /// <param name="email">邮箱地址</param>
        /// <param name="phone">手机号</param>
        /// <param name="full_name">联系人姓名</param>
        /// <returns></returns>
        public int AddAddressNew(int userid, string address, string address2, string city, string province, string country, string zipcode, ref int addressid, int type, string name, string email, string phone, string full_name)
        {
            return dal.AddAddressNew(userid, address, address2, city, province, country, zipcode, type, name, email, phone, full_name);
        }
        #endregion

        

        #region  商户注册之卖家信息

        /// <summary>
        /// 商户注册之卖家信息(增加地址并初始化数据)
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="address">街道地址</param>
        /// <param name="city">市/镇</param>
        /// <param name="province">州/地区/省</param>
        /// <param name="country">国家/地区</param>
        /// <param name="zipcode">邮编</param>
        /// <param name="storename">店铺名称</param>
        /// <param name="website">商品网址</param>
        /// <param name="mobile">电话号码</param>
        public void Pro_initial_address(int userid, string address, string city, string province, string country, string zipcode, string storename, string website, string mobile, ref int result, ref string error)
        {
            if (dal.Pro_initial_address(userid, address, city, province, country, zipcode, storename, website, mobile) == 0)
                result = 1;
            else
                error = "添加初始化失败";
        }
        #endregion

        #region  更新商户注册之卖家信息

        /// <summary>
        /// 更新商户注册之卖家信息(修改用户信息)
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="address">街道地址</param>
        /// <param name="city">市/镇</param>
        /// <param name="province">州/地区/省</param>
        /// <param name="country">国家/地区</param>
        /// <param name="zipcode">邮编</param>
        /// <param name="storename">店铺名称</param>
        /// <param name="website">商品网址</param>
        /// <param name="mobile">电话号码</param>
        public void Proc_Update_user_address(int userid, string address, string city, string province, string country, string zipcode, string storename, string website, string mobile, ref int result, ref string error, int address_id)
        {
            if (dal.Proc_Update_user_address(userid, address, city, province, country, zipcode, storename, website, mobile,address_id) == 0)
                result = 1;
            else
                error = "添加初始化失败";
        }
        #endregion

        #region 获得用户地址列表

        /// <summary>
        /// 获取用户地址列表
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="sign">地址类型</param>
        /// <returns></returns>
        public string GetList(int userid, int sign)
        {
            int result = 1;
            string error = "";
            string strWhere = string.Empty;
            string str = string.Empty;
            if (sign != 0)
            {
                strWhere = "user_id=" + userid + " and type=" + sign + "";
            }
            else 
            {
                strWhere = "user_id=" + userid;
            }
            DataSet ds= dal.GetList(strWhere);

            int a = ds.Tables[0].Rows.Count;//行数
            int b = ds.Tables[0].Columns.Count;//列数

            if (a > 0)
            {
                string[,] strarr = new string[a, b];
                for (int i = 0; i < a; i++) //遍历数据并赋值
                {
                    for (int j = 0; j < b; j++)
                    {
                        strarr[i, j] = ds.Tables[0].Rows[i][j].ToString();
                    }
                }
                str = "{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",\"List\":[";
                string strROW = "";
                for (int i = 0; i < a; i++)
                {
                    strROW = "{\"country\":\"" + QGYHelper.FormatCode.FormatUrlEncode(strarr[i, 2].ToString())
                        + "\",\"address\":\"" + QGYHelper.FormatCode.FormatUrlEncode(strarr[i, 3].ToString())
                        + "\",\"address2\":\"" + QGYHelper.FormatCode.FormatUrlEncode(strarr[i, 4].ToString())
                        + "\",\"city\":\"" + QGYHelper.FormatCode.FormatUrlEncode(strarr[i, 5].ToString())
                        + "\",\"province\":\"" + QGYHelper.FormatCode.FormatUrlEncode(strarr[i, 6].ToString())
                        + "\",\"zipcode\":\"" + strarr[i, 7].ToString()
                        + "\",\"fullname\":\"" + QGYHelper.FormatCode.FormatUrlEncode(strarr[i, 8].ToString())
                        + "\",\"phone\":\"" + strarr[i, 9].ToString()
                        + "\",\"email\":\"" + QGYHelper.FormatCode.FormatUrlEncode(strarr[i, 10].ToString())
                        + "\",\"name\":\"" + QGYHelper.FormatCode.FormatUrlEncode(strarr[i, 1].ToString())
                        + "\",\"address_id\":\"" + strarr[i, 0].ToString()
                        + "\"},";
                    str = str + strROW;
                }
                str = str.Remove(str.Length - 1);
               return str = str + "]}";
            }
            else
            {
                result = 0;
                error = "没有相应地址";
                return "";
            }
        }

        #endregion

        #region 公用 获取用户永久地址
        /// <summary>
        /// 公用(根据地址编号获取地址信息)
        /// </summary>
        /// <param name="address_id">用户编号</param>
        /// <returns></returns>
        public string GetAddress(int address_id)
        {
           model= dal.GetAddress(address_id);
           if (model != null)
           {
               return "\"address_id\":\"" + model.address_id + "\",\"address\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.address) + "\",\"address2\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.address2) + "\",\"city\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.city) + "\",\"province\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.province) + "\",\"country\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.country) + "\",\"zipcode\":\"" + model.zipcode + "\",\"phone\":\"" + model.phone + "\",\"name\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.name) + "\",\"email\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.email) + "\",\"full_name\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.full_name) + "\",\"type\":\"" + model.type + "\"";
           }
           return "";
        }
        #endregion 

        #region 公用 获取用户永久地址
        /// <summary>
        /// 公用(根据地址编号获取地址信息)
        /// </summary>
        /// <param name="address_id">用户编号</param>
        /// <returns></returns>
        public string GetAddress2(int address_id)
        {
            model = dal.GetAddress(address_id);
            if (model != null)
            {
                return  "" + QGYHelper.FormatCode.FormatUrlEncode(model.city) + " " + QGYHelper.FormatCode.FormatUrlEncode(model.address) + " " + QGYHelper.FormatCode.FormatUrlEncode(model.address2) + " " + QGYHelper.FormatCode.FormatUrlEncode(model.province) + " " + QGYHelper.FormatCode.FormatUrlEncode(model.country) + " " + model.zipcode + "";
            }
            return "";
        }
        #endregion 
    }
}