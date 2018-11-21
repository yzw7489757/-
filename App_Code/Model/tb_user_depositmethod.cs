/**  版本信息模板在安装目录下，可自行修改。
* tb_user_depositmethod.cs
*
* 功 能： N/A
* 类 名： tb_user_depositmethod
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/6 星期五 下午 2:04:45   N/A    初版
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
	/// tb_user_depositmethod:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_user_depositmethod
	{
		public tb_user_depositmethod()
		{}
		#region Model
		private int _method_id;
		private string _bank_location;
		private string _account_name;
		private string _routing_number;
		private string _account_number;
		private int? _user_id;
		private DateTime? _createtime;
		/// <summary>
		/// 存款方式ID
		/// </summary>
		public int method_id
		{
			set{ _method_id=value;}
			get{return _method_id;}
		}
		/// <summary>
		/// 银行所在地
		/// </summary>
		public string bank_location
		{
			set{ _bank_location=value;}
			get{return _bank_location;}
		}
		/// <summary>
		/// 账户持有人姓名
		/// </summary>
		public string account_name
		{
			set{ _account_name=value;}
			get{return _account_name;}
		}
		/// <summary>
		/// 银行识别代码
		/// </summary>
		public string routing_number
		{
			set{ _routing_number=value;}
			get{return _routing_number;}
		}
		/// <summary>
		/// 银行账号
		/// </summary>
		public string account_number
		{
			set{ _account_number=value;}
			get{return _account_number;}
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

