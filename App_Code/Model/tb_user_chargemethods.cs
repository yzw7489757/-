/**  版本信息模板在安装目录下，可自行修改。
* tb_user_chargemethods.cs
*
* 功 能： N/A
* 类 名： tb_user_chargemethods
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/6 星期五 下午 2:04:44   N/A    初版
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
	/// tb_user_chargemethods:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_user_chargemethods
	{
		public tb_user_chargemethods()
		{}
		#region Model
		private int _method_id;
		private string _card_number;
		private int? _valid_through_month;
		private int? _valid_through_year;
		private string _card_holder_name;
		private string _billing_address_id;
		private int? _user_id;
		private DateTime? _createtime;
		/// <summary>
		/// 付费方式ID
		/// </summary>
		public int method_id
		{
			set{ _method_id=value;}
			get{return _method_id;}
		}
		/// <summary>
		/// 信用卡号
		/// </summary>
		public string card_number
		{
			set{ _card_number=value;}
			get{return _card_number;}
		}
		/// <summary>
		/// 有效期限（月）
		/// </summary>
		public int? valid_through_month
		{
			set{ _valid_through_month=value;}
			get{return _valid_through_month;}
		}
		/// <summary>
		/// 有效期限（年）
		/// </summary>
		public int? valid_through_year
		{
			set{ _valid_through_year=value;}
			get{return _valid_through_year;}
		}
		/// <summary>
		/// 持卡人姓名
		/// </summary>
		public string card_holder_name
		{
			set{ _card_holder_name=value;}
			get{return _card_holder_name;}
		}
		/// <summary>
		/// 信用卡账单地址
		/// </summary>
		public string billing_address_id
		{
			set{ _billing_address_id=value;}
			get{return _billing_address_id;}
		}
		/// <summary>
		/// 用户ID
		/// </summary>
		public int? user_id
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
		#endregion Model
    }
}

