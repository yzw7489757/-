/**  版本信息模板在安装目录下，可自行修改。
* tb_user_notificationoptions.cs
*
* 功 能： N/A
* 类 名： tb_user_notificationoptions
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/4 星期三 下午 4:13:13   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace QAMZN.Model
{
	/// <summary>
	/// tb_user_notificationoptions:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_user_notificationoptions
	{
		public tb_user_notificationoptions()
		{}
		#region Model
		private int _user_id;
		private int? _order_sms_isopen;
		private int? _order_sms_contact;
		private int? _order_isopen;
		private string _order_email;
		private int? _shipping_isopen;
		private string _shipping_email;
		private int? _multichannel_isopen;
		private string _multichannel_email;
		private int? _shipment_isopen;
		private string _shipment_email;
		private int? _problem_isopen;
		private string _problem_email;
		private int? _returns_isopen;
		private string _returns_email;
		private int? _claims_isopen;
		private string _claims_email;
		private int? _refund_isopen;
		private string _refund_email;
		private int? _listing_created_isopen;
		private string _listing_created_email;
		private int? _listing_closed_isopen;
		private string _listing_closed_email;
		private int? _open_listings_isopen;
		private string _open_listings_email;
		private int? _order_fulfillment_isopen;
		private string _order_fulfillment_email;
		private int? _sold_listings_isopen;
		private string _sold_listings_email;
		private int? _cancelled_listings_isopen;
		private string _cancelled_listings_email;
		private int? _makeoffer_isopen;
		private string _makeoffer_email;
		private int? _business_isopen;
		private string _business_email;
		private int? _technical_isopen;
		private string _technical_email;
		private int? _emergency_isopen;
		private string _emergency_phone;
		private int? _buyer_messages_isopen;
		private string _buyer_messages_email;
		private int? _confirmation_isopen;
		private string _confirmation_email;
		private int? _delivery_failures_isopen;
		private string _delivery_failures_email;
		private int? _buyer_optout_isopen;
		private string _buyer_optout_email;
		/// <summary>
		/// 用户ID
		/// </summary>
		public int user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 卖家订单通知之短信通知
		/// </summary>
		public int? order_sms_isopen
		{
			set{ _order_sms_isopen=value;}
			get{return _order_sms_isopen;}
		}
		/// <summary>
		/// 短信联系人ID
		/// </summary>
		public int? order_sms_contact
		{
			set{ _order_sms_contact=value;}
			get{return _order_sms_contact;}
		}
		/// <summary>
		/// 卖家订单通知之邮箱通知
		/// </summary>
		public int? order_isopen
		{
			set{ _order_isopen=value;}
			get{return _order_isopen;}
		}
		/// <summary>
		/// 电子邮件
		/// </summary>
		public string order_email
		{
			set{ _order_email=value;}
			get{return _order_email;}
		}
		/// <summary>
		/// 亚马逊物流订单通知
		/// </summary>
		public int? shipping_isopen
		{
			set{ _shipping_isopen=value;}
			get{return _shipping_isopen;}
		}
		/// <summary>
		/// 电子邮件
		/// </summary>
		public string shipping_email
		{
			set{ _shipping_email=value;}
			get{return _shipping_email;}
		}
		/// <summary>
		/// 多渠道配送通知
		/// </summary>
		public int? multichannel_isopen
		{
			set{ _multichannel_isopen=value;}
			get{return _multichannel_isopen;}
		}
		/// <summary>
		/// 电子邮件
		/// </summary>
		public string multichannel_email
		{
			set{ _multichannel_email=value;}
			get{return _multichannel_email;}
		}
		/// <summary>
		/// 货件已到达通知
		/// </summary>
		public int? shipment_isopen
		{
			set{ _shipment_isopen=value;}
			get{return _shipment_isopen;}
		}
		/// <summary>
		/// 电子邮件
		/// </summary>
		public string shipment_email
		{
			set{ _shipment_email=value;}
			get{return _shipment_email;}
		}
		/// <summary>
		/// 入库货件问题通知
		/// </summary>
		public int? problem_isopen
		{
			set{ _problem_isopen=value;}
			get{return _problem_isopen;}
		}
		/// <summary>
		/// 电子邮件
		/// </summary>
		public string problem_email
		{
			set{ _problem_email=value;}
			get{return _problem_email;}
		}
		/// <summary>
		/// 待处理的退货
		/// </summary>
		public int? returns_isopen
		{
			set{ _returns_isopen=value;}
			get{return _returns_isopen;}
		}
		/// <summary>
		/// 电子邮件
		/// </summary>
		public string returns_email
		{
			set{ _returns_email=value;}
			get{return _returns_email;}
		}
		/// <summary>
		/// 索赔通知
		/// </summary>
		public int? claims_isopen
		{
			set{ _claims_isopen=value;}
			get{return _claims_isopen;}
		}
		/// <summary>
		/// 电子邮件
		/// </summary>
		public string claims_email
		{
			set{ _claims_email=value;}
			get{return _claims_email;}
		}
		/// <summary>
		/// 退款通知
		/// </summary>
		public int? refund_isopen
		{
			set{ _refund_isopen=value;}
			get{return _refund_isopen;}
		}
		/// <summary>
		/// 电子邮件
		/// </summary>
		public string refund_email
		{
			set{ _refund_email=value;}
			get{return _refund_email;}
		}
		/// <summary>
		/// 已创建“我的商品”
		/// </summary>
		public int? listing_created_isopen
		{
			set{ _listing_created_isopen=value;}
			get{return _listing_created_isopen;}
		}
		/// <summary>
		/// 电子邮件
		/// </summary>
		public string listing_created_email
		{
			set{ _listing_created_email=value;}
			get{return _listing_created_email;}
		}
		/// <summary>
		/// 已关闭“我的商品”
		/// </summary>
		public int? listing_closed_isopen
		{
			set{ _listing_closed_isopen=value;}
			get{return _listing_closed_isopen;}
		}
		/// <summary>
		/// 电子邮件
		/// </summary>
		public string listing_closed_email
		{
			set{ _listing_closed_email=value;}
			get{return _listing_closed_email;}
		}
		/// <summary>
		/// 可售商品报告
		/// </summary>
		public int? open_listings_isopen
		{
			set{ _open_listings_isopen=value;}
			get{return _open_listings_isopen;}
		}
		/// <summary>
		/// 电子邮件
		/// </summary>
		public string open_listings_email
		{
			set{ _open_listings_email=value;}
			get{return _open_listings_email;}
		}
		/// <summary>
		/// 订单履行报告
		/// </summary>
		public int? order_fulfillment_isopen
		{
			set{ _order_fulfillment_isopen=value;}
			get{return _order_fulfillment_isopen;}
		}
		/// <summary>
		/// 电子邮件
		/// </summary>
		public string order_fulfillment_email
		{
			set{ _order_fulfillment_email=value;}
			get{return _order_fulfillment_email;}
		}
		/// <summary>
		/// 已售出商品报告
		/// </summary>
		public int? sold_listings_isopen
		{
			set{ _sold_listings_isopen=value;}
			get{return _sold_listings_isopen;}
		}
		/// <summary>
		/// 电子邮件
		/// </summary>
		public string sold_listings_email
		{
			set{ _sold_listings_email=value;}
			get{return _sold_listings_email;}
		}
		/// <summary>
		/// 已取消的商品报告
		/// </summary>
		public int? cancelled_listings_isopen
		{
			set{ _cancelled_listings_isopen=value;}
			get{return _cancelled_listings_isopen;}
		}
		/// <summary>
		/// 电子邮件
		/// </summary>
		public string cancelled_listings_email
		{
			set{ _cancelled_listings_email=value;}
			get{return _cancelled_listings_email;}
		}
		/// <summary>
		/// 出价通知
		/// </summary>
		public int? makeoffer_isopen
		{
			set{ _makeoffer_isopen=value;}
			get{return _makeoffer_isopen;}
		}
		/// <summary>
		/// 电子邮件
		/// </summary>
		public string makeoffer_email
		{
			set{ _makeoffer_email=value;}
			get{return _makeoffer_email;}
		}
		/// <summary>
		/// 公司最新信息
		/// </summary>
		public int? business_isopen
		{
			set{ _business_isopen=value;}
			get{return _business_isopen;}
		}
		/// <summary>
		/// 电子邮件
		/// </summary>
		public string business_email
		{
			set{ _business_email=value;}
			get{return _business_email;}
		}
		/// <summary>
		/// 技术通知
		/// </summary>
		public int? technical_isopen
		{
			set{ _technical_isopen=value;}
			get{return _technical_isopen;}
		}
		/// <summary>
		/// 电子邮件
		/// </summary>
		public string technical_email
		{
			set{ _technical_email=value;}
			get{return _technical_email;}
		}
		/// <summary>
		/// 紧急通知
		/// </summary>
		public int? emergency_isopen
		{
			set{ _emergency_isopen=value;}
			get{return _emergency_isopen;}
		}
		/// <summary>
		/// 紧急电话
		/// </summary>
		public string emergency_phone
		{
			set{ _emergency_phone=value;}
			get{return _emergency_phone;}
		}
		/// <summary>
		/// 买家消息
		/// </summary>
		public int? buyer_messages_isopen
		{
			set{ _buyer_messages_isopen=value;}
			get{return _buyer_messages_isopen;}
		}
		/// <summary>
		/// 电子邮件
		/// </summary>
		public string buyer_messages_email
		{
			set{ _buyer_messages_email=value;}
			get{return _buyer_messages_email;}
		}
		/// <summary>
		/// 确认通知
		/// </summary>
		public int? confirmation_isopen
		{
			set{ _confirmation_isopen=value;}
			get{return _confirmation_isopen;}
		}
		/// <summary>
		/// 电子邮件
		/// </summary>
		public string confirmation_email
		{
			set{ _confirmation_email=value;}
			get{return _confirmation_email;}
		}
		/// <summary>
		/// 配送失败
		/// </summary>
		public int? delivery_failures_isopen
		{
			set{ _delivery_failures_isopen=value;}
			get{return _delivery_failures_isopen;}
		}
		/// <summary>
		/// 电子邮件
		/// </summary>
		public string delivery_failures_email
		{
			set{ _delivery_failures_email=value;}
			get{return _delivery_failures_email;}
		}
		/// <summary>
		/// 买家退出
		/// </summary>
		public int? buyer_optout_isopen
		{
			set{ _buyer_optout_isopen=value;}
			get{return _buyer_optout_isopen;}
		}
		/// <summary>
		/// 电子邮件
		/// </summary>
		public string buyer_optout_email
		{
			set{ _buyer_optout_email=value;}
			get{return _buyer_optout_email;}
		}
		#endregion Model

	}
}

