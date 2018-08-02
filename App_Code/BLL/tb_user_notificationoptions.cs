using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///tb_user_notificationoptions 的摘要说明
/// </summary>
namespace QAMZN.BLL
{
    public partial class tb_user_notificationoptions
    {
        public tb_user_notificationoptions()
        {
        }

        private readonly QAMZN.DAL.tb_user_notificationoptions dal = new QAMZN.DAL.tb_user_notificationoptions();
        QAMZN.Model.tb_user_notificationoptions model = new Model.tb_user_notificationoptions();

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <param name="email">电子邮箱</param>
        /// <returns></returns>
        public int AddNotice(int UserID, string email)
        {
           return dal.AddNotice(UserID, email);
        }
        #endregion

        #region 初始化通知首选项
        /// <summary>
        /// 初始化通知首选项
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="strInfo"></param>
        /// <returns></returns>
        public string GetNotification(int userid, ref string strInfo)
        {
            model = dal.GetModel(userid);
            if (model != null)
            {
                strInfo = "{\"order_sms_isopen\":\"" + model.order_sms_isopen
                    + "\",\"order_sms_contact\":\"" + model.order_sms_contact
                    + "\",\"order_isopen\":\"" + model.order_isopen 
                    + "\",\"order_email\":\"" + model.order_email 
                    + "\",\"shipping_isopen\":\"" + model.shipping_isopen
                    + "\",\"shipping_email\":\"" + model.shipping_email
                    + "\",\"multichannel_isopen\":\"" + model.multichannel_isopen
                    + "\",\"multichannel_email\":\"" + model.multichannel_email
                    + "\",\"shipment_isopen\":\"" + model.shipment_isopen
                    + "\",\"shipment_email\":\"" + model.shipment_email
                    + "\",\"problem_isopen\":\"" + model.problem_isopen
                    + "\",\"problem_email\":\"" + model.problem_email
                    
                    + "\",\"returns_isopen\":\"" + model.returns_isopen
                    + "\",\"returns_email\":\"" + model.returns_email
                    + "\",\"claims_isopen\":\"" + model.claims_isopen
                    + "\",\"claims_email\":\"" + model.claims_email
                    + "\",\"refund_isopen\":\"" + model.refund_isopen
                    + "\",\"refund_email\":\"" + model.refund_email

                    + "\",\"listing_created_isopen\":\"" + model.listing_created_isopen
                    + "\",\"listing_created_email\":\"" + model.listing_created_email
                    + "\",\"listing_closed_isopen\":\"" + model.listing_closed_isopen
                    + "\",\"listing_closed_email\":\"" + model.listing_closed_email

                    + "\",\"open_listings_isopen\":\"" + model.open_listings_isopen
                    + "\",\"open_listings_email\":\"" + model.open_listings_email
                    + "\",\"order_fulfillment_isopen\":\"" + model.order_fulfillment_isopen
                    + "\",\"order_fulfillment_email\":\"" + model.order_fulfillment_email
                    + "\",\"sold_listings_isopen\":\"" + model.sold_listings_isopen
                    + "\",\"sold_listings_email\":\"" + model.sold_listings_email
                    + "\",\"cancelled_listings_isopen\":\"" + model.cancelled_listings_isopen
                    + "\",\"cancelled_listings_email\":\"" + model.cancelled_listings_email

                    + "\",\"makeoffer_isopen\":\"" + model.makeoffer_isopen
                    + "\",\"makeoffer_email\":\"" + model.makeoffer_email

                    + "\",\"business_isopen\":\"" + model.business_isopen
                    + "\",\"business_email\":\"" + model.business_email
                    + "\",\"technical_isopen\":\"" + model.technical_isopen
                    + "\",\"technical_email\":\"" + model.technical_email

                    + "\",\"emergency_isopen\":\"" + model.emergency_isopen
                    + "\",\"emergency_phone\":\"" + model.emergency_phone

                    + "\",\"buyer_messages_isopen\":\"" + model.buyer_messages_isopen
                    + "\",\"buyer_messages_email\":\"" + model.buyer_messages_email
                    + "\",\"confirmation_isopen\":\"" + model.confirmation_isopen
                    + "\",\"confirmation_email\":\"" + model.confirmation_email
                    + "\",\"delivery_failures_isopen\":\"" + model.delivery_failures_isopen
                    + "\",\"delivery_failures_email\":\"" + model.delivery_failures_email
                    + "\",\"buyer_optout_isopen\":\"" + model.buyer_optout_isopen
                    + "\",\"buyer_optout_email\":\"" + model.buyer_optout_email 
                    + "\"}";
                return strInfo;
            }
            else
                return "";
        }
        #endregion

        #region   把用户联系人ID初始化到通知表里 UpdateContacts
        /// <summary>
        /// 把用户联系人ID初始化到通知表里 UpdateContacts
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="contact_id">用户联系人ID</param>
        public bool UpdateContacts(int userid, int contact_id)
        {
            return dal.UpdateContactId(userid, contact_id);
        }

        #endregion

        #region 更新订单通知  UpdateOrderNotification
        /// <summary>
        /// 更新订单通知
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="order_sms_isopen">卖家订单通知之短信通知</param>
        /// <param name="order_sms_contact">短信联系人ID</param>
        /// <param name="order_isopen">卖家订单通知之邮箱通知</param>
        /// <param name="order_email">电子邮件</param>
        /// <param name="shipping_isopen">亚马逊物流订单通知</param>
        /// <param name="shipping_email">电子邮件</param>
        /// <param name="multichannel_isopen">多渠道配送通知</param>
        /// <param name="multichannel_email">电子邮件</param>
        /// <param name="shipment_isopen">货件已到达通知</param>
        /// <param name="shipment_email">电子邮件</param>
        /// <param name="problem_isopen">入库货件问题通知</param>
        /// <param name="problem_email">电子邮件</param>
        public bool UpdateOrderNotification(int userid, int order_sms_isopen, int order_sms_contact, int order_isopen, string order_email, int shipping_isopen, string shipping_email, int multichannel_isopen, string multichannel_email, int shipment_isopen, string shipment_email, int problem_isopen, string problem_email)
        {
           return dal.UpdateOrderNotification(userid, order_sms_isopen, order_sms_contact, order_isopen, order_email, shipping_isopen, shipping_email, multichannel_isopen, multichannel_email, shipment_isopen, shipment_email, problem_isopen, problem_email);
        }
        #endregion

        #region  更新订货和索赔通知  UpdateOrderNotification2
        /// <summary>
        /// 更新订货和索赔通知
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="returns_isopen">待处理的退货</param>
        /// <param name="refund_email">电子邮件</param>
        /// <param name="claims_isopen">索赔通知</param>
        /// <param name="claims_email">电子邮件</param>
        /// <param name="refund_isopen">退款通知</param>
        /// <param name="returns_email">电子邮件</param>
        public bool UpdateOrderNotification2(int userid,int returns_isopen, string refund_email, int claims_isopen, string claims_email, int refund_isopen, string returns_email)
        {
           return dal.UpdateOrderNotification2(userid,returns_isopen, refund_email, claims_isopen, claims_email, refund_isopen, returns_email);
        }
        #endregion

        #region  更新商品通知 UpdateOrderNotification3
        /// <summary>
        /// 更新商品通知
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="listing_created_isopen">已创建“我的商品”</param>
        /// <param name="listing_created_email">电子邮件</param>
        /// <param name="listing_closed_isopen">已关闭“我的商品”</param>
        /// <param name="listing_closed_email">电子邮件</param>
        public bool UpdateOrderNotification3(int userid,int listing_created_isopen, string listing_created_email, int listing_closed_isopen, string listing_closed_email)
        {
            return dal.UpdateOrderNotification3(userid, listing_created_isopen, listing_created_email, listing_closed_isopen, listing_closed_email);
        }
        #endregion

        #region 更新报告 UpdateOrderNotification4
        /// <summary>
        /// 更新报告
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="open_listings_isopen">可售商品报告</param>
        /// <param name="open_listings_email">电子邮件</param>
        /// <param name="order_fulfillment_isopen">订单履行报告</param>
        /// <param name="order_fulfillment_email">电子邮件</param>
        /// <param name="sold_listings_isopen">已售出商品报告</param>
        /// <param name="sold_listings_email">电子邮件</param>
        /// <param name="cancelled_listings_isopen">已取消的商品报告</param>
        /// <param name="cancelled_listings_email">电子邮件</param>
        public bool UpdateOrderNotification4(int userid,int open_listings_isopen, string open_listings_email, int order_fulfillment_isopen, string order_fulfillment_email, int sold_listings_isopen, string sold_listings_email, int cancelled_listings_isopen, string cancelled_listings_email)
        {
           return dal.UpdateOrderNotification4( userid, open_listings_isopen,  open_listings_email,  order_fulfillment_isopen,  order_fulfillment_email,  sold_listings_isopen,  sold_listings_email,  cancelled_listings_isopen, cancelled_listings_email);
        }
        #endregion

        #region 更新出价通知 UpdateOrderNotification5
        /// <summary>
        /// 更新出价通知
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="makeoffer_isopen">出价通知</param>
        /// <param name="makeoffer_email">电子邮件</param>
        public bool UpdateOrderNotification5(int userid, int makeoffer_isopen, string makeoffer_email)
        {
            return dal.UpdateOrderNotification5(userid, makeoffer_isopen, makeoffer_email);
        }
        #endregion

        #region 更新账户通知 UpdateOrderNotification6
        /// <summary>
        /// 更新账户通知
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="business_isopen">公司最新信息</param>
        /// <param name="business_email">电子邮件</param>
        /// <param name="technical_isopen">技术通知</param>
        /// <param name="technical_email">电子邮件</param>
        public bool UpdateOrderNotification6(int userid, int business_isopen, string business_email, int technical_isopen, string technical_email)
        {
            return dal.UpdateOrderNotification6(userid, business_isopen, business_email, technical_isopen, technical_email);
        }
        #endregion

        #region 更新紧急通知 UpdateOrderNotification7
        /// <summary>
        /// 更新紧急通知
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="emergency_isopen">紧急通知</param>
        /// <param name="emergency_phone">紧急电话</param>
        /// <returns></returns>
        public bool UpdateOrderNotification7(int userid, int emergency_isopen, string emergency_phone)
        {
            return dal.UpdateOrderNotification7(userid, emergency_isopen, emergency_phone);
        }
        #endregion

        #region  更新消息通知 UpdateOrderNotification8
        /// <summary>
        /// 更新消息通知
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="buyer_messages_isopen">买家消息</param>
        /// <param name="buyer_messages_email">电子邮件</param>
        /// <param name="confirmation_isopen">确认通知</param>
        /// <param name="confirmation_email">电子邮件</param>
        /// <param name="delivery_failures_isopen">配送失败</param>
        /// <param name="delivery_failures_email">电子邮件</param>
        /// <param name="buyer_optout_isopen">买家退出</param>
        /// <param name="buyer_optout_email">电子邮件</param>
        public bool UpdateOrderNotification8(int userid, int buyer_messages_isopen, string buyer_messages_email, int confirmation_isopen, string confirmation_email, int delivery_failures_isopen, string delivery_failures_email, int buyer_optout_isopen, string buyer_optout_email)
        {
            return dal.UpdateOrderNotification8(userid, buyer_messages_isopen, buyer_messages_email, confirmation_isopen, confirmation_email, delivery_failures_isopen, delivery_failures_email, buyer_optout_isopen, buyer_optout_email);
        }
        #endregion
    }
}