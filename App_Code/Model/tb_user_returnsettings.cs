/**  版本信息模板在安装目录下，可自行修改。
* tb_user_returnsettings.cs
*
* 功 能： N/A
* 类 名： tb_user_returnsettings
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
	/// tb_user_returnsettings:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_user_returnsettings
	{
		public tb_user_returnsettings()
		{}
		#region Model
		private int _user_id;
		private DateTime? _createtime;
		private int? _email_format;
		private int? _return_rule;
		private int? _return_window;
		private int? _setting_number;
		private int? _address_id;
		/// <summary>
		/// 用户ID
		/// </summary>
		public int user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createtime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 是否接收退货申请电子邮件（1 是 0 否）
		/// </summary>
		public int? email_format
		{
			set{ _email_format=value;}
			get{return _email_format;}
		}
		/// <summary>
		/// 退货规则（1 用户自动批准 2 平台自动批准符合条件 3 平台批准所有申请）
		/// </summary>
		public int? return_rule
		{
			set{ _return_rule=value;}
			get{return _return_rule;}
		}
		/// <summary>
		/// 退货期限（天）
		/// </summary>
		public int? return_window
		{
			set{ _return_window=value;}
			get{return _return_window;}
		}
		/// <summary>
		/// 商品退货批准编号设置（1 自动生成 2 自定义）
		/// </summary>
		public int? setting_number
		{
			set{ _setting_number=value;}
			get{return _setting_number;}
		}
		/// <summary>
		/// 默认退货地址ID
		/// </summary>
		public int? address_id
		{
			set{ _address_id=value;}
			get{return _address_id;}
		}
		#endregion Model

	}
}

