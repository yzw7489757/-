/**  版本信息模板在安装目录下，可自行修改。
* tb_virtual_shop.cs
*
* 功 能： N/A
* 类 名： tb_virtual_shop
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/4 星期三 下午 4:13:14   N/A    初版
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
	/// tb_virtual_shop:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_virtual_shop
	{
		public tb_virtual_shop()
		{}
		#region Model
		private int _user_id;
		private string _shop_name;
		private int? _shop_level;
		private string _shop_intro;
		private string _shop_logo;
		private string _shop_link;
		private string _service_email;
		private string _service_phone;
		private string _service_reply_email;
		private int? _vacation;
		private string _about_seller;
		private string _shipping_rates;
		private string _shipping_policies;
		private string _faq;
		private string _privacy_policy;
		/// <summary>
		/// 用户ID
		/// </summary>
		public int user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 店铺名称
		/// </summary>
		public string shop_name
		{
			set{ _shop_name=value;}
			get{return _shop_name;}
		}
		/// <summary>
		/// 店铺等级
		/// </summary>
		public int? shop_level
		{
			set{ _shop_level=value;}
			get{return _shop_level;}
		}
		/// <summary>
		/// 店铺介绍
		/// </summary>
		public string shop_intro
		{
			set{ _shop_intro=value;}
			get{return _shop_intro;}
		}
		/// <summary>
		/// 店铺logo
		/// </summary>
		public string shop_logo
		{
			set{ _shop_logo=value;}
			get{return _shop_logo;}
		}
		/// <summary>
		/// 店铺链接
		/// </summary>
		public string shop_link
		{
			set{ _shop_link=value;}
			get{return _shop_link;}
		}
		/// <summary>
		/// 客户服务电子邮件
		/// </summary>
		public string service_email
		{
			set{ _service_email=value;}
			get{return _service_email;}
		}
		/// <summary>
		/// 客服电话
		/// </summary>
		public string service_phone
		{
			set{ _service_phone=value;}
			get{return _service_phone;}
		}
		/// <summary>
		/// 客服回复电子邮件
		/// </summary>
		public string service_reply_email
		{
			set{ _service_reply_email=value;}
			get{return _service_reply_email;}
		}
		/// <summary>
		/// 假期设置（1 在售 0 停售）
		/// </summary>
		public int? vacation
		{
			set{ _vacation=value;}
			get{return _vacation;}
		}
		/// <summary>
		/// 关于卖家
		/// </summary>
		public string about_seller
		{
			set{ _about_seller=value;}
			get{return _about_seller;}
		}
		/// <summary>
		/// 送货费用
		/// </summary>
		public string shipping_rates
		{
			set{ _shipping_rates=value;}
			get{return _shipping_rates;}
		}
		/// <summary>
		/// 送货政策
		/// </summary>
		public string shipping_policies
		{
			set{ _shipping_policies=value;}
			get{return _shipping_policies;}
		}
		/// <summary>
		/// 常见问题
		/// </summary>
		public string FAQ
		{
			set{ _faq=value;}
			get{return _faq;}
		}
		/// <summary>
		/// 隐私政策
		/// </summary>
		public string privacy_policy
		{
			set{ _privacy_policy=value;}
			get{return _privacy_policy;}
		}
		#endregion Model

	}
}

