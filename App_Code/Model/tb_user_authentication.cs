/**  版本信息模板在安装目录下，可自行修改。
* tb_user_authentication.cs
*
* 功 能： N/A
* 类 名： tb_user_authentication
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/10 星期二 下午 4:55:34   N/A    初版
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
	/// tb_user_authentication:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_user_authentication
	{
		public tb_user_authentication()
		{}
		#region Model
		private int _user_id;
		private string _country;
		private int? _identity;
		private string _identity_file;
		private string _remark;
		private int? _statement_type;
		private string _statement_file;
		private string _email;
		private string _telephone;
		private int? _is_submit;
		private int? _state;
		private DateTime? _createtime;
		private DateTime? _submittime;
		private DateTime? _statetime;
		private string _reason;
		/// <summary>
		/// 用户ID
		/// </summary>
		public int user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 所在国家/地区
		/// </summary>
		public string country
		{
			set{ _country=value;}
			get{return _country;}
		}
		/// <summary>
		/// 身份（1 个人 2 公司）
		/// </summary>
		public int? identity
		{
			set{ _identity=value;}
			get{return _identity;}
		}
		/// <summary>
		/// 身份证明上传文件
		/// </summary>
		public string identity_file
		{
			set{ _identity_file=value;}
			get{return _identity_file;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 对账单类型（1 信用卡 2 银行账户）
		/// </summary>
		public int? statement_type
		{
			set{ _statement_type=value;}
			get{return _statement_type;}
		}
		/// <summary>
		/// 对账单上传文件
		/// </summary>
		public string statement_file
		{
			set{ _statement_file=value;}
			get{return _statement_file;}
		}
		/// <summary>
		/// 电子邮件（多个逗号分隔）
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 是否提交（1 是 0 否 ）
		/// </summary>
		public int? is_submit
		{
			set{ _is_submit=value;}
			get{return _is_submit;}
		}
		/// <summary>
		/// 审核状态（1 未审核 2 审核通过 3 审核不通过）
		/// </summary>
		public int? state
		{
			set{ _state=value;}
			get{return _state;}
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
		/// 提交时间
		/// </summary>
		public DateTime? submittime
		{
			set{ _submittime=value;}
			get{return _submittime;}
		}
		/// <summary>
		/// 审核时间
		/// </summary>
		public DateTime? statetime
		{
			set{ _statetime=value;}
			get{return _statetime;}
		}
		/// <summary>
		/// 审核不通过原因
		/// </summary>
		public string reason
		{
			set{ _reason=value;}
			get{return _reason;}
		}
		#endregion Model

	}
}

