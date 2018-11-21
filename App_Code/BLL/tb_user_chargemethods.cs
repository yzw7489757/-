using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
///tb_user_chargemethods 的摘要说明
/// </summary>
namespace QAMZN.BLL
{
    public partial class tb_user_chargemethods
    {
        public tb_user_chargemethods()
        {
        }
        private readonly QAMZN.DAL.tb_user_chargemethods dal = new QAMZN.DAL.tb_user_chargemethods();
        QAMZN.Model.tb_user_chargemethods model = new Model.tb_user_chargemethods();

        #region 获取付款信息详情
        /// <summary>
        /// 获取付款信息详情
        /// </summary>
        /// <param name="chargeId">付款ID</param>
        /// <param name="addressID">账单ID</param>
        /// <returns></returns>
        public string GetChargeInfo(int? chargeId,ref string addressID)
        {
          model=  dal.GetModel((int)chargeId);
          if (model != null)
          {
              addressID = model.billing_address_id;
              return "\"chargeId\":\""+model.method_id+"\",\"card_number\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.card_number) + "\",\"valid_through_month\":\"" + model.valid_through_month + "\",\"valid_through_year\":\"" + model.valid_through_year + "\",\"card_holder_name\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.card_holder_name) + "\",\"billing_address_id\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.billing_address_id) + "\"";
          }
          else { return ""; }
        }
        #endregion

        #region 获取付款信息详情
        /// <summary>
        /// 获取付款信息详情
        /// </summary>
        /// <param name="chargeId">付费编号</param>
        /// <param name="billing_address_id">邮寄地址编号</param>
        public string GetChargeMethod_id(int? chargeId, ref string billing_address_id)
        {

            model = dal.GetModel((int)chargeId);
            string Str = string.Empty;
            if (model != null)
            {
                billing_address_id = model.billing_address_id;
                Str = "\"card_number\":\"" + model.card_number.Substring(model.card_number.Length-4)
                    + "\",\"valid_through_month\":\"" + model.valid_through_month
                    + "\",\"valid_through_year\":\"" + model.valid_through_year
                    + "\",\"card_holder_name\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.card_holder_name) + "\"";
                return Str;
            }
            else
                return Str;
        }
        #endregion

        #region  获取用户表里的用户收款地址ID
        /// <summary>
        /// 获取用户表里的用户收款地址
        /// </summary>
        /// <param name="chargeId">收款id</param>
        /// <param name="bilingAddressId">邮寄地址ID</param>
        public void GetBilingId(int? chargeId,ref string  bilingAddressId)
        {
           model = dal.GetModel((int)chargeId);
           if (model != null)
           {
               bilingAddressId = model.billing_address_id;
           }
        }
        #endregion

        #region 获取付款方式的邮寄地址
        /// <summary>
        /// 获取付款方式的邮寄地址
        /// </summary>
        /// <param name="chargeId">付款方式id</param>
        /// <returns></returns>
        public string GetChargeInfo(int? chargeId)
        {
            model = dal.GetModel((int)chargeId);
            if (model != null)
            {
                //method_id,card_number,valid_through_month,valid_through_year,card_holder_name,billing_address_id,user_id,createtime
                return "\"chargeId\":\"" + model.method_id + "\",\"card_number\":\"" + model.card_number + "\",\"valid_through_month\":\"" + model.valid_through_month + "\",\"valid_through_year\":\"" + model.valid_through_year + "\",\"card_holder_name\":\"" + model.card_holder_name + "\",\"billing_address_id\":\"" + model.billing_address_id + "\"";
            }
            else { return ""; }
        }
        #endregion
        
        #region   付费方式(初始化信用卡列表)  GetChargeInfoList
        /// <summary>
        /// 付费方式(初始化信用卡列表)
        /// </summary>
        /// <param name="userid">用户编号</param>
        public string GetChargeInfoList(int userid)
        {
            string strWhere = "user_id=" + userid + "";
            DataSet ds = dal.GetList(strWhere);
            int Row = ds.Tables[0].Rows.Count;//行数
            int Col = ds.Tables[0].Columns.Count;//列数
            string[,] strarr = new string[Row, Col];
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    strarr[i, j] = ds.Tables[0].Rows[i][j].ToString();
                }
            }
            string Str = string.Empty;
            string strROW = "";
            for (int i = 0; i < Row; i++)
            {
                string strSubstring = strarr[i, 1].ToString().Substring(strarr[i, 1].ToString().Length-4);
                Str = "{\"method_id\":\"" + strarr[i, 0].ToString()
                    + "\",\"card_number\":\"" + strSubstring//卡号
                    + "\",\"valid_through_month\":\"" + strarr[i, 2].ToString()//月份
                    + "\",\"valid_through_year\":\"" + strarr[i, 3].ToString()//年份
                    + "\",\"card_holder_name\":\"" + QGYHelper.FormatCode.FormatUrlEncode(strarr[i, 4].ToString())//持卡人姓名
                    + "\"}";
                strROW = strROW + Str + ",";
            }
            strROW = strROW.Remove(strROW.Length - 1);
            return strROW = strROW + "";
        }
        #endregion

        #region 新增信用卡
        /// <summary>
        /// 新增信用卡
        /// </summary>
        /// <param name="userid">用户信息</param>
        /// <param name="card_number">信用卡号</param>
        /// <param name="valid_through_month">有效期限（月）</param>
        /// <param name="valid_through_year">有效期限（年）</param>
        /// <param name="card_holder_name">持卡人姓名</param>
        /// <param name="billing_address_id">邮寄地址ID</param>
        public int AddChargeMethod(int userid, string card_number, int valid_through_month, int valid_through_year, string card_holder_name, int billing_address_id)
        {
            return dal.AddChargeMethod(userid, card_number, valid_through_month, valid_through_year, card_holder_name, billing_address_id);
        }
        #endregion 

        #region 修改信用卡邮寄地址
        /// <summary>
        /// 修改信用卡邮寄地址
        /// </summary>
        /// <param name="userid">用户信息</param>
        /// <param name="card_number">信用卡号</param>
        /// <param name="valid_through_month">有效期限（月）</param>
        /// <param name="valid_through_year">有效期限（年）</param>
        /// <param name="card_holder_name">持卡人姓名</param>
        /// <param name="billing_address_id">邮寄地址ID</param>
        public bool UpdateChargeInfo(int method_id,int userid, string card_number, int valid_through_month, int valid_through_year, string card_holder_name, int billing_address_id)
        {
            return dal.UpdateChargeInfo(method_id, userid, card_number, valid_through_month, valid_through_year, card_holder_name, billing_address_id);
        }
        #endregion
    }
}