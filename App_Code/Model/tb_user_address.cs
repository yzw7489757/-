/**  版本信息模板在安装目录下，可自行修改。
* tb_user_address.cs
*
* 功 能： N/A
* 类 名： tb_user_address
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/5 星期四 下午 5:05:27   N/A    初版
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
	/// tb_user_address:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_user_address
	{
		public tb_user_address()
		{}
		#region Model
		private int _address_id;
		private string _name;
		private string _country;
		private string _address;
		private string _address2;
		private string _city;
		private string _province;
		private string _zipcode;
		private string _full_name;
		private string _phone;
		private string _email;
		private int? _user_id;
		private DateTime? _createtime;
		private DateTime? _updatetime;
		private int? _type;
		/// <summary>
		/// 地址ID
		/// </summary>
		public int address_id
		{
			set{ _address_id=value;}
			get{return _address_id;}
		}
		/// <summary>
		/// 地址名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 国家
		/// </summary>
		public string country
		{
			set{ _country=value;}
			get{return _country;}
		}
		/// <summary>
		/// 街道地址和编号、邮政信箱、转交方
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 公寓、套房、单元房、大厦、楼层等
		/// </summary>
		public string address2
		{
			set{ _address2=value;}
			get{return _address2;}
		}
		/// <summary>
		/// 市/镇
		/// </summary>
		public string city
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		///  州/地区/省
		/// </summary>
		public string province
		{
			set{ _province=value;}
			get{return _province;}
		}
		/// <summary>
		/// 邮编
		/// </summary>
		public string zipcode
		{
			set{ _zipcode=value;}
			get{return _zipcode;}
		}
		/// <summary>
		/// 联系人姓名
		/// </summary>
		public string full_name
		{
			set{ _full_name=value;}
			get{return _full_name;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 电子邮件地址
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
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
		/// <summary>
		/// 最后更新时间
		/// </summary>
		public DateTime? updatetime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 地址类型（1 一般地址 2 退货地址 3 配送地址）
		/// </summary>
		public int? type
		{
			set{ _type=value;}
			get{return _type;}
		}
		#endregion Model

	}
}

