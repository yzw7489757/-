using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
///tb_virtual_shop 的摘要说明
/// </summary>
namespace QAMZN.BLL
{
    public partial class tb_virtual_shop
    {
        public tb_virtual_shop()
        {
        }
        private readonly QAMZN.DAL.tb_virtual_shop dal = new QAMZN.DAL.tb_virtual_shop();
        QAMZN.Model.tb_virtual_shop model = new QAMZN.Model.tb_virtual_shop();
        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="userID">用户编号</param>
        /// <param name="email">邮箱</param>
        /// <returns></returns>
        public bool AddShopInfo(int userID,string email)
        {
           return dal.AddShopInfo(userID, email);
        }

        #endregion

        #region 修改店铺名称电话
        /// <summary>
        /// 修改店铺名称电话
        /// </summary>
        /// <param name="userid">用户标识</param>
        /// <param name="storename">店铺名称</param>
        /// <param name="mobile">客服电话</param>
        /// <returns></returns>
        public bool UpdateShopName(int userid, string storename, string mobile)
        {
            return dal.UpdateShopName(userid, storename, mobile);
        }
        #endregion

        #region 商户注册（通过邮箱注册）
        /// <summary>
        /// 商户注册（通过邮箱注册）
        /// </summary>
        /// <param name="userID">用户编号</param>
        /// <param name="email">邮箱</param>
        /// <param name="pwd">密码</param>
        /// <param name="stuid">学生ID</param>
        /// <param name="stuaccount">学生账号</param>
        /// <param name="trainingmode">实训模式（1 单项 2 综合）</param>
        public int Pro_initial_shop(string name, string pwd, string email, string token, int stuid, string stuaccount, int trainingmode)
        {
            return dal.Pro_initial_shop(name, pwd, email, token, stuid, stuaccount, trainingmode);
        }
        #endregion

        #region  初始化商户注册之卖家信息(店铺名称)
        /// <summary>
        /// 初始化商户注册之卖家信息(店铺名称)
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="stroename">店铺名称</param>
        public void GetStorename(int userid, ref string stroename)
        {
            model = dal.GetStorename(userid);
            if (model != null)
            {
                stroename = model.shop_name;
            }
        }
        #endregion 

        #region 检查商店名称是否重复
        /// <summary>
        /// 检查商店名称是否重复
        /// </summary>
        /// <param name="shopname">店铺名称</param>
        /// <returns></returns>
        public bool GetShopName(int userid,string shopname)
        {
            return dal.Exists(userid, shopname);
        }
        #endregion

        #region 获取卖家详细资料
        /// <summary>
        /// 获取卖家详细资料
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="Str">查询条件</param>
        public string GetShopInfo(int userid,ref string Str)
        {
            model = dal.GetStorename(userid);
            if (model != null)
            {
                return "\"shop_name\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.shop_name)
                       + "\",\"shop_link\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.shop_link)
                       + "\",\"service_email\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.service_email)
                       + "\",\"service_phone\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.service_phone)
                       + "\",\"service_reply_email\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.service_reply_email)
                       + "\",\"vacation\":\"" + model.vacation
                       + "\"";
            }
            else return "";
        }
        #endregion

        #region 获取商品详情信息
        /// <summary>
        /// 获取商品详情信息
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="shop_name">店铺名称</param>
        /// <param name="shop_link">店铺地址</param>
        /// <returns></returns>
        public bool UpdateStoreDetails(int userid, string shop_name, string shop_link)
        {
            return dal.UpdateStoreDetails(userid, shop_name, shop_link);
        }
        #endregion

        #region 修改客户服务详细信息

        /// <summary>
        /// 修改客户服务详细信息
        /// </summary>
        /// <param name="userid">商户编号</param>
        /// <param name="service_email">客户服务电子邮件</param>
        /// <param name="service_phone">客服电话</param>
        /// <param name="service_reply_email">客服回复电子邮件</param>
        public bool ServiceDetails(int userid, string service_email, string service_phone, string service_reply_email)
        {
          return  dal.ServiceDetails(userid, service_email, service_phone, service_reply_email);
        }
        #endregion
    }
}