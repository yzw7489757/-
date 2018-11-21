/**  版本信息模板在安装目录下，可自行修改。
* tb_users.cs
*
* 功 能： N/A
* 类 名： tb_users
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/4 星期三 上午 9:28:27   N/A    初版
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
	/// tb_users:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_users
	{
		public tb_users()
		{}
		#region Model
		private int _user_id;
		private int? _sell_plan;
		private int? _user_identity;
		private string _name;
		private string _email;
		private string _password;
		private string _paypwd;
		private string _legal_name;
		private int? _business_address;
		private int? _registered_address;
		private string _website;
		private string _telephone;
		private int? _chargemethod;
		private int? _depositmethod;
		private int? _is_product_upc;
		private int? _is_product_brand;
		private int? _product_list;
		private string _categories;
		private string _category_name;
		private int? _step;
		private DateTime? _createtime;
		private int? _selling_state;
		private DateTime? _selling_time;
		private string _token;
		private int? _is_prime;
        private int? _stu_id;
        private string _stu_account;
        private int? _stu_training_mode;
		/// <summary>
		/// 用户ID
		/// </summary>
		public int user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 销售计划（1 专业 2 个人）
		/// </summary>
		public int? sell_plan
		{
			set{ _sell_plan=value;}
			get{return _sell_plan;}
		}
		/// <summary>
		/// 用户身份（1 企业 2 个人）
		/// </summary>
		public int? user_identity
		{
			set{ _user_identity=value;}
			get{return _user_identity;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 电子邮箱
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 支付密码
		/// </summary>
		public string paypwd
		{
			set{ _paypwd=value;}
			get{return _paypwd;}
		}
		/// <summary>
		/// 法人
		/// </summary>
		public string legal_name
		{
			set{ _legal_name=value;}
			get{return _legal_name;}
		}
		/// <summary>
		/// 办公地址ID
		/// </summary>
		public int? business_address
		{
			set{ _business_address=value;}
			get{return _business_address;}
		}
		/// <summary>
		/// 正式注册地址ID
		/// </summary>
		public int? registered_address
		{
			set{ _registered_address=value;}
			get{return _registered_address;}
		}
		/// <summary>
		/// 在线销售商品网址
		/// </summary>
		public string website
		{
			set{ _website=value;}
			get{return _website;}
		}
		/// <summary>
		/// 电话号码
		/// </summary>
		public string telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 付费方式ID
		/// </summary>
		public int? chargemethod
		{
			set{ _chargemethod=value;}
			get{return _chargemethod;}
		}
		/// <summary>
		/// 存款方式ID
		/// </summary>
		public int? depositmethod
		{
			set{ _depositmethod=value;}
			get{return _depositmethod;}
		}
		/// <summary>
		/// 是否都有产品编码（1 是 0 否）
		/// </summary>
		public int? is_product_upc
		{
			set{ _is_product_upc=value;}
			get{return _is_product_upc;}
		}
		/// <summary>
		/// 是否所销售商品的制造商或品牌商（1 是 0 否）
		/// </summary>
		public int? is_product_brand
		{
			set{ _is_product_brand=value;}
			get{return _is_product_brand;}
		}
		/// <summary>
		/// 预计发布产品数量（1 1~10 2 11~100 3 101~500 4 500以上）
		/// </summary>
		public int? product_list
		{
			set{ _product_list=value;}
			get{return _product_list;}
		}
		/// <summary>
		/// 产品分类ID（用英文逗号隔开）
		/// </summary>
		public string categories
		{
			set{ _categories=value;}
			get{return _categories;}
		}
		/// <summary>
		/// 自定义分类
		/// </summary>
		public string category_name
		{
			set{ _category_name=value;}
			get{return _category_name;}
		}
		/// <summary>
		/// 注册步骤（1 卖家协议 2 卖家信息 3 账单/存款 4 税务信息 5 商品信息 6 完成注册）
		/// </summary>
		public int? step
		{
			set{ _step=value;}
			get{return _step;}
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
		/// 状态（1 已开放 0 未开放）
		/// </summary>
		public int? selling_state
		{
			set{ _selling_state=value;}
			get{return _selling_state;}
		}
		/// <summary>
		/// 开放销售权限时间
		/// </summary>
		public DateTime? selling_time
		{
			set{ _selling_time=value;}
			get{return _selling_time;}
		}
		/// <summary>
		/// 卖家标志
		/// </summary>
		public string token
		{
			set{ _token=value;}
			get{return _token;}
		}
		/// <summary>
		/// 是否Prime会员（1 是 0 否）
		/// </summary>
		public int? is_prime
		{
			set{ _is_prime=value;}
			get{return _is_prime;}
		}
        /// <summary>
        /// 学生ID
        /// </summary>
        public int? stu_id
        {
            set { _stu_id = value; }
            get { return _stu_id; }
        }
        /// <summary>
        /// 学生账号
        /// </summary>
        public string stu_account
        {
            set { _stu_account = value; }
            get { return _stu_account; }
        }
        /// <summary>
        /// 实训模式（1 单项 2 综合）
        /// </summary>
        public int? stu_training_mode
        {
            set { _stu_training_mode = value; }
            get { return _stu_training_mode; }
        }
		#endregion Model

	}
}

