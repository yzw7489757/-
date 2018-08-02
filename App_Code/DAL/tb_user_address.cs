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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using QGYHelper.DataBase;
//Please add references
namespace QAMZN.DAL
{
	/// <summary>
	/// 数据访问类:tb_user_address
	/// </summary>
	public partial class tb_user_address
	{
		public tb_user_address()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("address_id", "tb_user_address"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int address_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_user_address");
			strSql.Append(" where address_id=@address_id");
			SqlParameter[] parameters = {
					new SqlParameter("@address_id", SqlDbType.Int,4)
			};
			parameters[0].Value = address_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(QAMZN.Model.tb_user_address model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_user_address(");
            strSql.Append("name,country,address,address2,city,province,zipcode,full_name,phone,email,user_id,createtime,updatetime,type)");
            strSql.Append(" values (");
            strSql.Append("@name,@country,@address,@address2,@city,@province,@zipcode,@full_name,@phone,@email,@user_id,@createtime,@updatetime,@type)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,100),
					new SqlParameter("@country", SqlDbType.VarChar,100),
					new SqlParameter("@address", SqlDbType.VarChar,100),
					new SqlParameter("@address2", SqlDbType.VarChar,100),
					new SqlParameter("@city", SqlDbType.VarChar,100),
					new SqlParameter("@province", SqlDbType.VarChar,100),
					new SqlParameter("@zipcode", SqlDbType.VarChar,10),
					new SqlParameter("@full_name", SqlDbType.VarChar,50),
					new SqlParameter("@phone", SqlDbType.VarChar,50),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@updatetime", SqlDbType.DateTime),
					new SqlParameter("@type", SqlDbType.Int,4)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.country;
            parameters[2].Value = model.address;
            parameters[3].Value = model.address2;
            parameters[4].Value = model.city;
            parameters[5].Value = model.province;
            parameters[6].Value = model.zipcode;
            parameters[7].Value = model.full_name;
            parameters[8].Value = model.phone;
            parameters[9].Value = model.email;
            parameters[10].Value = model.user_id;
            parameters[11].Value = model.createtime;
            parameters[12].Value = model.updatetime;
            parameters[13].Value = model.type;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        #region 商户注册之账单存款
        /// <summary>
        /// 商户注册之账单存款（返回信息{result:1 成功 0 失败}）
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="card_number">信用卡号</param>
        /// <param name="card_month">有效期限（月）</param>
        /// <param name="card_year">有效期限（年）</param>
        /// <param name="card_holder">持卡人姓名</param>
        /// <param name="addressid">账单地址ID</param>
        /// <param name="address">街道地址</param>
        /// <param name="city">市/镇</param>
        /// <param name="province">州/地区/省</param>
        /// <param name="country">国家/地区</param>
        /// <param name="zipcode">邮编</param>
        /// <param name="bank_location">银行地址</param>
        /// <param name="account_holder">账户持有人姓名</param>
        /// <param name="routing_number">9 位数的汇款路径号码</param>
        /// <param name="account_number">银行账号</param>
        public int Pro_initial_Charge_deposit(int userid, string card_number, int card_month, int card_year, string card_holder, int addressid, string address, string city, string province, string country, string zipcode, string bank_location, string account_holder, string routing_number, string account_number)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int,4),
					new SqlParameter("@card_number", SqlDbType.VarChar,100),
					new SqlParameter("@card_month", SqlDbType.Int,4),
					new SqlParameter("@card_year", SqlDbType.Int,4),
					new SqlParameter("@card_holder", SqlDbType.VarChar,100),
					new SqlParameter("@addressid", SqlDbType.Int,4),
					new SqlParameter("@address", SqlDbType.VarChar,100),
					new SqlParameter("@city", SqlDbType.VarChar,10),
					new SqlParameter("@province", SqlDbType.VarChar,50),
                    new SqlParameter("@country", SqlDbType.VarChar,100),
					new SqlParameter("@zipcode", SqlDbType.VarChar,100),
					new SqlParameter("@bank_location", SqlDbType.VarChar,100),
					new SqlParameter("@account_holder", SqlDbType.VarChar,100),
					new SqlParameter("@routing_number", SqlDbType.VarChar,10),
					new SqlParameter("@account_number", SqlDbType.VarChar,50),
                    new SqlParameter("@RES", SqlDbType.Int,4),
					};
            parameters[0].Value = userid;
            parameters[1].Value = card_number;
            parameters[2].Value = card_month;
            parameters[3].Value = card_year;
            parameters[4].Value = card_holder;
            parameters[5].Value = addressid;
            parameters[6].Value = address;
            parameters[7].Value = city;
            parameters[8].Value = province;
            parameters[9].Value = country;
            parameters[10].Value = zipcode;
            parameters[11].Value = bank_location;
            parameters[12].Value = account_holder;
            parameters[13].Value = routing_number;
            parameters[14].Value = account_number;
            parameters[15].Direction = ParameterDirection.Output;

            DbHelperSQL.RunProcedure("Pro_initial_Charge_deposit", parameters, out rowsAffected);
            return (int)parameters[15].Value;
        }
        #endregion


        #region 商户注册之账单存款
        /// <summary>
        /// 商户注册之账单存款（返回信息{result:1 成功 0 失败}）
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="card_number">信用卡号</param>
        /// <param name="card_month">有效期限（月）</param>
        /// <param name="card_year">有效期限（年）</param>
        /// <param name="card_holder">持卡人姓名</param>
        /// <param name="addressid">账单地址ID</param>
        /// <param name="address">街道地址</param>
        /// <param name="city">市/镇</param>
        /// <param name="province">州/地区/省</param>
        /// <param name="country">国家/地区</param>
        /// <param name="zipcode">邮编</param>
        /// <param name="bank_location">银行地址</param>
        /// <param name="account_holder">账户持有人姓名</param>
        /// <param name="routing_number">9 位数的汇款路径号码</param>
        /// <param name="account_number">银行账号</param>
        public int Proc_update_Charge_deposit(int userid, string card_number, int card_month, int card_year, string card_holder, int addressid, string address, string city, string province, string country, string zipcode, string bank_location, string account_holder, string routing_number, string account_number, int? chargeId, int? depositId)
        {  //int chargeId,ref int depositId
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int,4),
					new SqlParameter("@card_number", SqlDbType.VarChar,100),
					new SqlParameter("@card_month", SqlDbType.Int,4),
					new SqlParameter("@card_year", SqlDbType.Int,4),
					new SqlParameter("@card_holder", SqlDbType.VarChar,100),
					new SqlParameter("@addressid", SqlDbType.Int,4),
					new SqlParameter("@address", SqlDbType.VarChar,100),
					new SqlParameter("@city", SqlDbType.VarChar,10),
					new SqlParameter("@province", SqlDbType.VarChar,50),
                    new SqlParameter("@country", SqlDbType.VarChar,100),
					new SqlParameter("@zipcode", SqlDbType.VarChar,100),
					new SqlParameter("@bank_location", SqlDbType.VarChar,100),
					new SqlParameter("@account_holder", SqlDbType.VarChar,100),
					new SqlParameter("@routing_number", SqlDbType.VarChar,10),
					new SqlParameter("@account_number", SqlDbType.VarChar,50),
                    new SqlParameter("@chargeId", SqlDbType.Int,4),
                    new SqlParameter("@depositId", SqlDbType.Int,4),
                    new SqlParameter("@RES", SqlDbType.Int,4),

					};
            parameters[0].Value = userid;
            parameters[1].Value = card_number;
            parameters[2].Value = card_month;
            parameters[3].Value = card_year;
            parameters[4].Value = card_holder;
            parameters[5].Value = addressid;
            parameters[6].Value = address;
            parameters[7].Value = city;
            parameters[8].Value = province;
            parameters[9].Value = country;
            parameters[10].Value = zipcode;
            parameters[11].Value = bank_location;
            parameters[12].Value = account_holder;
            parameters[13].Value = routing_number;
            parameters[14].Value = account_number;
            parameters[15].Value = (int)chargeId;
            parameters[16].Value = (int)depositId;
            parameters[17].Direction = ParameterDirection.Output;


            DbHelperSQL.RunProcedure("Proc_update_Charge_deposit", parameters, out rowsAffected);
            return (int)parameters[17].Value;
        }
        #endregion

        #region 新增地址
        /// <summary>
        /// 新增地址
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="address">街道地址</param>
        /// <param name="city">市/镇</param>
        /// <param name="province">州/地区/省</param>
        /// <param name="country">国家/地区</param>
        /// <param name="zipcode">邮编</param>
        /// <returns></returns>
        public int AddAddress(int userid, string address, string city, string province, string country, string zipcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_user_address(");
            strSql.Append("user_id,address,city,province,country,zipcode,createtime)");
            strSql.Append(" values (");
            strSql.Append("@user_id,@address,@city,@province,@country,@zipcode,@createtime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@address", SqlDbType.VarChar,100),
					new SqlParameter("@city", SqlDbType.VarChar,100),
					new SqlParameter("@province", SqlDbType.VarChar,100),
					new SqlParameter("@country", SqlDbType.VarChar,100),
					new SqlParameter("@zipcode", SqlDbType.VarChar,100),
					new SqlParameter("@createtime", SqlDbType.DateTime,50),
                                        };
            parameters[0].Value = userid;
            parameters[1].Value = address;
            parameters[2].Value = city;
            parameters[3].Value = province;
            parameters[4].Value = country;
            parameters[5].Value = zipcode;
            parameters[6].Value = DateTime.Now;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        #endregion

        #region 新增地址2
        /// <summary>
        /// 新增地址2
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="address">街道地址</param>
        /// <param name="address2">公寓、楼层</param>
        /// <param name="city">市/镇</param>
        /// <param name="province">州/地区/省</param>
        /// <param name="country">国家/地区</param>
        /// <param name="zipcode">邮编</param>
        /// <param name="name">地址名称</param>
        /// <param name="email">邮箱地址</param>
        /// <param name="phone">手机号</param>
        /// <param name="full_name">联系人姓名</param>
        /// <returns></returns>
        public int AddAddress2(int userid, string address, string address2, string city, string province, string country, string zipcode,int type)
        { 
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_user_address(");
            strSql.Append("user_id,address,address2,city,province,country,zipcode,createtime,type)");
            strSql.Append(" values (");
            strSql.Append("@user_id,@address,@address2,@city,@province,@country,@zipcode,@createtime,@type)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@address", SqlDbType.VarChar,100),
                    new SqlParameter("@address2", SqlDbType.VarChar,100),
					new SqlParameter("@city", SqlDbType.VarChar,100),
					new SqlParameter("@province", SqlDbType.VarChar,100),
					new SqlParameter("@country", SqlDbType.VarChar,100),
					new SqlParameter("@zipcode", SqlDbType.VarChar,100),
					new SqlParameter("@createtime", SqlDbType.DateTime,50),
                    new SqlParameter("@type", SqlDbType.Int,4),
                                        };
            parameters[0].Value = userid;
            parameters[1].Value = address;
            parameters[2].Value = address2;
            parameters[3].Value = city;
            parameters[4].Value = province;
            parameters[5].Value = country;
            parameters[6].Value = zipcode;
            parameters[7].Value = DateTime.Now;
            parameters[8].Value = type;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        #endregion 

        

        #region 新增地址3
        /// <summary>
        /// 新增地址3
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="address">街道地址</param>
        /// <param name="address2">公寓、楼层</param>
        /// <param name="city">市/镇</param>
        /// <param name="province">州/地区/省</param>
        /// <param name="country">国家/地区</param>
        /// <param name="zipcode">邮编</param>
        /// <param name="name">地址名称</param>
        /// <param name="email">邮箱地址</param>
        /// <param name="phone">手机号</param>
        /// <param name="full_name">联系人姓名</param>
        /// <returns></returns>
        public int AddAddressNew(int userid, string address, string address2, string city, string province, string country, string zipcode, int type, string name, string email, string phone, string full_name)
        { 
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_user_address(");
            strSql.Append("user_id,address,address2,city,province,country,zipcode,createtime,type,name,email,phone,full_name)");
            strSql.Append(" values (");
            strSql.Append("@user_id,@address,@address2,@city,@province,@country,@zipcode,@createtime,@type,@name,@email,@phone,@full_name)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@address", SqlDbType.VarChar,100),
                    new SqlParameter("@address2", SqlDbType.VarChar,100),
					new SqlParameter("@city", SqlDbType.VarChar,100),
					new SqlParameter("@province", SqlDbType.VarChar,100),
					new SqlParameter("@country", SqlDbType.VarChar,100),
					new SqlParameter("@zipcode", SqlDbType.VarChar,100),
					new SqlParameter("@createtime", SqlDbType.DateTime,50),
                    new SqlParameter("@type", SqlDbType.Int,4),
                    new SqlParameter("@name", SqlDbType.VarChar,100),
                    new SqlParameter("@email", SqlDbType.VarChar,100),
                    new SqlParameter("@phone", SqlDbType.VarChar,100),
                    new SqlParameter("@full_name", SqlDbType.VarChar,100)
                                        };
            parameters[0].Value = userid;
            parameters[1].Value = address;
            parameters[2].Value = address2;
            parameters[3].Value = city;
            parameters[4].Value = province;
            parameters[5].Value = country;
            parameters[6].Value = zipcode;
            parameters[7].Value = DateTime.Now;
            parameters[8].Value = type;
            parameters[9].Value = name;
            parameters[10].Value = email;
            parameters[11].Value = phone;
            parameters[12].Value = full_name;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        #endregion 


        #region  商户注册之卖家信息

        /// <summary>
        /// 商户注册之卖家信息(增加地址并初始化数据)
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="address">街道地址</param>
        /// <param name="city">市/镇</param>
        /// <param name="province">州/地区/省</param>
        /// <param name="country">国家/地区</param>
        /// <param name="zipcode">邮编</param>
        /// <param name="storename">店铺名称</param>
        /// <param name="website">商品网址</param>
        /// <param name="mobile">电话号码</param>
        public int Pro_initial_address(int userid, string address, string city, string province, string country, string zipcode, string storename, string website, string mobile)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@address", SqlDbType.VarChar,100),
					new SqlParameter("@city", SqlDbType.VarChar,100),
					new SqlParameter("@province", SqlDbType.VarChar,100),
					new SqlParameter("@country", SqlDbType.VarChar,100),
					new SqlParameter("@zipcode", SqlDbType.VarChar,100),
					new SqlParameter("@storename", SqlDbType.VarChar,100),
					new SqlParameter("@website", SqlDbType.VarChar,500),
					new SqlParameter("@mobile", SqlDbType.VarChar,50),
                    new SqlParameter("@res", SqlDbType.Int,4),
					};
            parameters[0].Value = userid;
            parameters[1].Value = address;
            parameters[2].Value = city;
            parameters[3].Value = province;
            parameters[4].Value = country;
            parameters[5].Value = zipcode;
            parameters[6].Value = storename;
            parameters[7].Value = website;
            parameters[8].Value = mobile;
            parameters[9].Direction = ParameterDirection.Output;

            DbHelperSQL.RunProcedure("Pro_initial_address", parameters, out rowsAffected);
            return  (int)parameters[9].Value;
        }
        #endregion

        #region  商户注册之卖家信息

        /// <summary>
        /// 商户注册之卖家信息(增加地址并初始化数据)
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="address">街道地址</param>
        /// <param name="city">市/镇</param>
        /// <param name="province">州/地区/省</param>
        /// <param name="country">国家/地区</param>
        /// <param name="zipcode">邮编</param>
        /// <param name="storename">店铺名称</param>
        /// <param name="website">商品网址</param>
        /// <param name="mobile">电话号码</param>
        public int Proc_Update_user_address(int userid, string address, string city, string province, string country, string zipcode, string storename, string website, string mobile, int address_id)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@address", SqlDbType.VarChar,100),
					new SqlParameter("@city", SqlDbType.VarChar,100),
					new SqlParameter("@province", SqlDbType.VarChar,100),
					new SqlParameter("@country", SqlDbType.VarChar,100),
					new SqlParameter("@zipcode", SqlDbType.VarChar,100),
					new SqlParameter("@storename", SqlDbType.VarChar,100),
					new SqlParameter("@website", SqlDbType.VarChar,500),
					new SqlParameter("@mobile", SqlDbType.VarChar,50),
                    new SqlParameter("@res", SqlDbType.Int,4),
                    new SqlParameter("@addressId", SqlDbType.Int,4),
					};
            parameters[0].Value = userid;
            parameters[1].Value = address;
            parameters[2].Value = city;
            parameters[3].Value = province;
            parameters[4].Value = country;
            parameters[5].Value = zipcode;
            parameters[6].Value = storename;
            parameters[7].Value = website;
            parameters[8].Value = mobile;
            parameters[9].Direction = ParameterDirection.Output;
            parameters[10].Value = address_id;

            DbHelperSQL.RunProcedure("Proc_Update_user_address", parameters, out rowsAffected);
            return (int)parameters[9].Value;
        }
        #endregion




        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(QAMZN.Model.tb_user_address model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_user_address set ");
			strSql.Append("name=@name,");
			strSql.Append("country=@country,");
			strSql.Append("address=@address,");
			strSql.Append("address2=@address2,");
			strSql.Append("city=@city,");
			strSql.Append("province=@province,");
			strSql.Append("zipcode=@zipcode,");
			strSql.Append("full_name=@full_name,");
			strSql.Append("phone=@phone,");
			strSql.Append("email=@email,");
			strSql.Append("user_id=@user_id,");
			strSql.Append("createtime=@createtime,");
			strSql.Append("updatetime=@updatetime,");
			strSql.Append("type=@type");
			strSql.Append(" where address_id=@address_id");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,100),
					new SqlParameter("@country", SqlDbType.VarChar,100),
					new SqlParameter("@address", SqlDbType.VarChar,100),
					new SqlParameter("@address2", SqlDbType.VarChar,100),
					new SqlParameter("@city", SqlDbType.VarChar,100),
					new SqlParameter("@province", SqlDbType.VarChar,100),
					new SqlParameter("@zipcode", SqlDbType.VarChar,10),
					new SqlParameter("@full_name", SqlDbType.VarChar,50),
					new SqlParameter("@phone", SqlDbType.VarChar,50),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@updatetime", SqlDbType.DateTime),
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@address_id", SqlDbType.Int,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.country;
			parameters[2].Value = model.address;
			parameters[3].Value = model.address2;
			parameters[4].Value = model.city;
			parameters[5].Value = model.province;
			parameters[6].Value = model.zipcode;
			parameters[7].Value = model.full_name;
			parameters[8].Value = model.phone;
			parameters[9].Value = model.email;
			parameters[10].Value = model.user_id;
			parameters[11].Value = model.createtime;
			parameters[12].Value = model.updatetime;
			parameters[13].Value = model.type;
			parameters[14].Value = model.address_id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int address_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_user_address ");
			strSql.Append(" where address_id=@address_id");
			SqlParameter[] parameters = {
					new SqlParameter("@address_id", SqlDbType.Int,4)
			};
			parameters[0].Value = address_id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string address_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_user_address ");
			strSql.Append(" where address_id in ("+address_idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
        #region GetAddress
        /// <summary>
        /// 公用获取永久地址
        /// </summary>
        /// <param name="address_id">用户编号</param>
        /// <returns></returns>
        public QAMZN.Model.tb_user_address GetAddress(int address_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 address_id,name,country,address,address2,city,province,zipcode,full_name,phone,email,user_id,createtime,updatetime,type from tb_user_address ");
            strSql.Append(" where address_id=@address_id");
            SqlParameter[] parameters = {
					new SqlParameter("@address_id", SqlDbType.Int,4)
			};
            parameters[0].Value = address_id;

            QAMZN.Model.tb_user_address model = new QAMZN.Model.tb_user_address();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        #endregion

        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public QAMZN.Model.tb_user_address GetModel(int address_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 address_id,name,country,address,address2,city,province,zipcode,full_name,phone,email,user_id,createtime,updatetime,type from tb_user_address ");
			strSql.Append(" where address_id=@address_id");
			SqlParameter[] parameters = {
					new SqlParameter("@address_id", SqlDbType.Int,4)
			};
			parameters[0].Value = address_id;

			QAMZN.Model.tb_user_address model=new QAMZN.Model.tb_user_address();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

        #region 得到一个对象实体
        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public QAMZN.Model.tb_user_address DataRowToModel(DataRow row)
		{
			QAMZN.Model.tb_user_address model=new QAMZN.Model.tb_user_address();
			if (row != null)
			{
				if(row["address_id"]!=null && row["address_id"].ToString()!="")
				{
					model.address_id=int.Parse(row["address_id"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["country"]!=null)
				{
					model.country=row["country"].ToString();
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["address2"]!=null)
				{
					model.address2=row["address2"].ToString();
				}
				if(row["city"]!=null)
				{
					model.city=row["city"].ToString();
				}
				if(row["province"]!=null)
				{
					model.province=row["province"].ToString();
				}
				if(row["zipcode"]!=null)
				{
					model.zipcode=row["zipcode"].ToString();
				}
				if(row["full_name"]!=null)
				{
					model.full_name=row["full_name"].ToString();
				}
				if(row["phone"]!=null)
				{
					model.phone=row["phone"].ToString();
				}
				if(row["email"]!=null)
				{
					model.email=row["email"].ToString();
				}
				if(row["user_id"]!=null && row["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(row["user_id"].ToString());
				}
				if(row["createtime"]!=null && row["createtime"].ToString()!="")
				{
					model.createtime=DateTime.Parse(row["createtime"].ToString());
				}
				if(row["updatetime"]!=null && row["updatetime"].ToString()!="")
				{
					model.updatetime=DateTime.Parse(row["updatetime"].ToString());
				}
				if(row["type"]!=null && row["type"].ToString()!="")
				{
					model.type=int.Parse(row["type"].ToString());
				}
			}
			return model;
		}
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">SQL条件参数</param>
        /// <returns></returns>
        public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select address_id,name,country,address,address2,city,province,zipcode,full_name,phone,email,user_id,createtime,updatetime,type ");
			strSql.Append(" FROM tb_user_address ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds;
		}
        #endregion

        /// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" address_id,name,country,address,address2,city,province,zipcode,full_name,phone,email,user_id,createtime,updatetime,type ");
			strSql.Append(" FROM tb_user_address ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tb_user_address ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.address_id desc");
			}
			strSql.Append(")AS Row, T.*  from tb_user_address T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tb_user_address";
			parameters[1].Value = "address_id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

