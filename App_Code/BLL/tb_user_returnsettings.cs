using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///tb_user_returnsettings 的摘要说明
/// </summary>
namespace QAMZN.BLL
{
    public partial class tb_user_returnsettings
    {
        public tb_user_returnsettings()
        {
        }
        private readonly QAMZN.DAL.tb_user_returnsettings dal = new QAMZN.DAL.tb_user_returnsettings();
        QAMZN.Model.tb_user_returnsettings model = new QAMZN.Model.tb_user_returnsettings();

        #region  增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="userID">用户编号</param>
        /// <param name="result">返回值（1，0）</param>
        /// <returns></returns>
        public bool AddReturn(int userID)
        {
            return dal.AddReturn(userID);
        }
        #endregion

        #region GetReturnSetting 初始化常规设置
        /// <summary>
        /// 初始化常规设置
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="strReturnSettingInfo">返回的数据</param>
        /// <returns></returns>
        public string GetReturnSetting(int userid, ref string strReturnSettingInfo)
        {
            model = dal.GetModel(userid);
            if (model != null)
                return strReturnSettingInfo = "\"email_format\":\"" + model.email_format + "\",\"return_rule\":\"" + model.return_rule + "\",\"return_window\":\"" + model.return_window + "\",\"setting_number\":\"" + model.setting_number + "\",\"address_id\":\"" + model.address_id + "\"";
            else
                return "";
        }
        #endregion


        #region SelectAddressId  查询退货表里的默认地址编号
        /// <summary>
        /// 常规设置（查询退货表里的默认地址编号）
        /// </summary>
        /// <param name="userid">用户编号</param>
        public void SelectAddressId(int userid, ref int? addressId)
        {
            model = dal.GetModel(userid);
            if (model != null)
            {
                addressId = model.address_id;
            }
        }
        #endregion

        #region UpdateReturnsettings更新退货数据

        /// <summary>
        /// 常规设置（更新常规设置）
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="email_format">是否接收退货申请电子邮件（1 是 0 否）</param>
        /// <param name="return_rule">退货规则（1 用户自动批准 2 平台自动批准符合条件 3 平台批准所有申请）</param>
        /// <param name="return_window">退货期限（天）</param>
        /// <param name="setting_number">商品退货批准编号设置（1 自动生成 2 自定义）</param>
        public void UpdateReturnsettings(int userid, int email_format, int return_rule, int return_window, int setting_number)
        {
            model.user_id = userid;
            model.email_format = email_format;
            model.return_rule = return_rule;
            model.return_window = return_window;
            model.setting_number = setting_number;
            dal.UpdateInfo(model);
        }
        #endregion

        #region SetDefaultAddress 更新默认地址
        /// <summary>
        /// 更新默认地址
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="addressId">地址编号</param>
        public bool SetDefaultAddress(int userid,int addressId)
        {
            model.address_id = addressId;
            model.user_id = userid;
            return dal.Update(model);
        }
        #endregion 
    }
}