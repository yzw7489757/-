/**  版本信息模板在安装目录下，可自行修改。
* tb_user_shippingsettings.cs
*
* 功 能： N/A
* 类 名： tb_user_shippingsettings
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
	/// tb_user_shippingsettings:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_user_shippingsettings
	{
		public tb_user_shippingsettings()
		{}
		#region Model
		private int _user_id;
		private DateTime? _createtime;
		private int? _address_id;
		private int? _standard_one;
		private int? _standard_two;
		private int? _expedited_one;
		private int? _expedited_two;
		private int? _twoday;
		private int? _oneday;
		private int? _international;
		private int? _expedited;
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
		/// 默认配送地址
		/// </summary>
		public int? address_id
		{
			set{ _address_id=value;}
			get{return _address_id;}
		}
		/// <summary>
		/// 标准（17-28工作日）
		/// </summary>
		public int? standard_one
		{
			set{ _standard_one=value;}
			get{return _standard_one;}
		}
		/// <summary>
		/// 标准（3-5工作日）
		/// </summary>
		public int? standard_two
		{
			set{ _standard_two=value;}
			get{return _standard_two;}
		}
		/// <summary>
		/// 快速配送（2-6工作日）
		/// </summary>
		public int? expedited_one
		{
			set{ _expedited_one=value;}
			get{return _expedited_one;}
		}
		/// <summary>
		/// 快速配送（1-3工作日）
		/// </summary>
		public int? expedited_two
		{
			set{ _expedited_two=value;}
			get{return _expedited_two;}
		}
		/// <summary>
		/// 两日送达
		/// </summary>
		public int? twoday
		{
			set{ _twoday=value;}
			get{return _twoday;}
		}
		/// <summary>
		/// 一日送达
		/// </summary>
		public int? oneday
		{
			set{ _oneday=value;}
			get{return _oneday;}
		}
		/// <summary>
		/// 国际配送
		/// </summary>
		public int? international
		{
			set{ _international=value;}
			get{return _international;}
		}
		/// <summary>
		/// 国际加急
		/// </summary>
		public int? expedited
		{
			set{ _expedited=value;}
			get{return _expedited;}
		}
		#endregion Model

	}
}

