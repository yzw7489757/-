/**  版本信息模板在安装目录下，可自行修改。
* tb_user_tax.cs
*
* 功 能： N/A
* 类 名： tb_user_tax
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/6 星期五 下午 3:49:06   N/A    初版
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
	/// tb_user_tax:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_user_tax
	{
		public tb_user_tax()
		{}
		#region Model
		private int _tax_id;
		private int? _receive_income;
		private int? _is_usperson;
		private string _company_name;
		private string _nationality;
		private int? _owner_type;
		private int? _address_id;
		private int? _mailing_address_id;
		private int? _is_esignature;
		private int? _user_id;
		private DateTime? _createtime;
        private string _signature;
		/// <summary>
		/// 税务信息ID
		/// </summary>
		public int tax_id
		{
			set{ _tax_id=value;}
			get{return _tax_id;}
		}
		/// <summary>
		/// 获得收益人（1 企业 2 业务）
		/// </summary>
		public int? receive_income
		{
			set{ _receive_income=value;}
			get{return _receive_income;}
		}
		/// <summary>
		/// 是否美国人（1 是 0 否）
		/// </summary>
		public int? is_usperson
		{
			set{ _is_usperson=value;}
			get{return _is_usperson;}
		}
		/// <summary>
		/// 法定公司名称
		/// </summary>
		public string company_name
		{
			set{ _company_name=value;}
			get{return _company_name;}
		}
		/// <summary>
		/// 国籍
		/// </summary>
		public string nationality
		{
			set{ _nationality=value;}
			get{return _nationality;}
		}
		/// <summary>
		/// 收益所有人类型（1 个人 2 独资经营者 3 单一成员有限责任公司）
		/// </summary>
		public int? owner_type
		{
			set{ _owner_type=value;}
			get{return _owner_type;}
		}
		/// <summary>
		/// 永久地址ID
		/// </summary>
		public int? address_id
		{
			set{ _address_id=value;}
			get{return _address_id;}
		}
		/// <summary>
		/// 邮寄地址ID
		/// </summary>
		public int? mailing_address_id
		{
			set{ _mailing_address_id=value;}
			get{return _mailing_address_id;}
		}
		/// <summary>
		/// 是否为IRS提供电子签名（1 是 0 否）
		/// </summary>
		public int? is_esignature
		{
			set{ _is_esignature=value;}
			get{return _is_esignature;}
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
        /// 签名
        /// </summary>
        public string signature
        {
            set { _signature = value; }
            get { return _signature; }
        }
		#endregion Model

	}
}

