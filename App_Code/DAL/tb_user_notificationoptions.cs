/**  版本信息模板在安装目录下，可自行修改。
* tb_user_notificationoptions.cs
*
* 功 能： N/A
* 类 名： tb_user_notificationoptions
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/4 星期三 下午 4:13:13   N/A    初版
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
using QGYHelper.DataBase;//Please add references
namespace QAMZN.DAL
{
	/// <summary>
	/// 数据访问类:tb_user_notificationoptions
	/// </summary>
	public partial class tb_user_notificationoptions
	{
		public tb_user_notificationoptions()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("user_id", "tb_user_notificationoptions"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int user_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_user_notificationoptions");
			strSql.Append(" where user_id=@user_id");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)
			};
			parameters[0].Value = user_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(QAMZN.Model.tb_user_notificationoptions model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_user_notificationoptions(");
			strSql.Append("order_sms_isopen,order_sms_contact,order_isopen,order_email,shipping_isopen,shipping_email,multichannel_isopen,multichannel_email,shipment_isopen,shipment_email,problem_isopen,problem_email,returns_isopen,returns_email,claims_isopen,claims_email,refund_isopen,refund_email,listing_created_isopen,listing_created_email,listing_closed_isopen,listing_closed_email,open_listings_isopen,open_listings_email,order_fulfillment_isopen,order_fulfillment_email,sold_listings_isopen,sold_listings_email,cancelled_listings_isopen,cancelled_listings_email,makeoffer_isopen,makeoffer_email,business_isopen,business_email,technical_isopen,technical_email,emergency_isopen,emergency_phone,buyer_messages_isopen,buyer_messages_email,confirmation_isopen,confirmation_email,delivery_failures_isopen,delivery_failures_email,buyer_optout_isopen,buyer_optout_email)");
			strSql.Append(" values (");
			strSql.Append("@order_sms_isopen,@order_sms_contact,@order_isopen,@order_email,@shipping_isopen,@shipping_email,@multichannel_isopen,@multichannel_email,@shipment_isopen,@shipment_email,@problem_isopen,@problem_email,@returns_isopen,@returns_email,@claims_isopen,@claims_email,@refund_isopen,@refund_email,@listing_created_isopen,@listing_created_email,@listing_closed_isopen,@listing_closed_email,@open_listings_isopen,@open_listings_email,@order_fulfillment_isopen,@order_fulfillment_email,@sold_listings_isopen,@sold_listings_email,@cancelled_listings_isopen,@cancelled_listings_email,@makeoffer_isopen,@makeoffer_email,@business_isopen,@business_email,@technical_isopen,@technical_email,@emergency_isopen,@emergency_phone,@buyer_messages_isopen,@buyer_messages_email,@confirmation_isopen,@confirmation_email,@delivery_failures_isopen,@delivery_failures_email,@buyer_optout_isopen,@buyer_optout_email)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@order_sms_isopen", SqlDbType.Int,4),
					new SqlParameter("@order_sms_contact", SqlDbType.Int,4),
					new SqlParameter("@order_isopen", SqlDbType.Int,4),
					new SqlParameter("@order_email", SqlDbType.VarChar,50),
					new SqlParameter("@shipping_isopen", SqlDbType.Int,4),
					new SqlParameter("@shipping_email", SqlDbType.VarChar,50),
					new SqlParameter("@multichannel_isopen", SqlDbType.Int,4),
					new SqlParameter("@multichannel_email", SqlDbType.VarChar,50),
					new SqlParameter("@shipment_isopen", SqlDbType.Int,4),
					new SqlParameter("@shipment_email", SqlDbType.VarChar,50),
					new SqlParameter("@problem_isopen", SqlDbType.Int,4),
					new SqlParameter("@problem_email", SqlDbType.VarChar,50),
					new SqlParameter("@returns_isopen", SqlDbType.Int,4),
					new SqlParameter("@returns_email", SqlDbType.VarChar,50),
					new SqlParameter("@claims_isopen", SqlDbType.Int,4),
					new SqlParameter("@claims_email", SqlDbType.VarChar,50),
					new SqlParameter("@refund_isopen", SqlDbType.Int,4),
					new SqlParameter("@refund_email", SqlDbType.VarChar,50),
					new SqlParameter("@listing_created_isopen", SqlDbType.Int,4),
					new SqlParameter("@listing_created_email", SqlDbType.VarChar,50),
					new SqlParameter("@listing_closed_isopen", SqlDbType.Int,4),
					new SqlParameter("@listing_closed_email", SqlDbType.VarChar,50),
					new SqlParameter("@open_listings_isopen", SqlDbType.Int,4),
					new SqlParameter("@open_listings_email", SqlDbType.VarChar,50),
					new SqlParameter("@order_fulfillment_isopen", SqlDbType.Int,4),
					new SqlParameter("@order_fulfillment_email", SqlDbType.VarChar,50),
					new SqlParameter("@sold_listings_isopen", SqlDbType.Int,4),
					new SqlParameter("@sold_listings_email", SqlDbType.VarChar,50),
					new SqlParameter("@cancelled_listings_isopen", SqlDbType.Int,4),
					new SqlParameter("@cancelled_listings_email", SqlDbType.VarChar,50),
					new SqlParameter("@makeoffer_isopen", SqlDbType.Int,4),
					new SqlParameter("@makeoffer_email", SqlDbType.VarChar,50),
					new SqlParameter("@business_isopen", SqlDbType.Int,4),
					new SqlParameter("@business_email", SqlDbType.VarChar,50),
					new SqlParameter("@technical_isopen", SqlDbType.Int,4),
					new SqlParameter("@technical_email", SqlDbType.VarChar,50),
					new SqlParameter("@emergency_isopen", SqlDbType.Int,4),
					new SqlParameter("@emergency_phone", SqlDbType.VarChar,50),
					new SqlParameter("@buyer_messages_isopen", SqlDbType.Int,4),
					new SqlParameter("@buyer_messages_email", SqlDbType.VarChar,50),
					new SqlParameter("@confirmation_isopen", SqlDbType.Int,4),
					new SqlParameter("@confirmation_email", SqlDbType.VarChar,50),
					new SqlParameter("@delivery_failures_isopen", SqlDbType.Int,4),
					new SqlParameter("@delivery_failures_email", SqlDbType.VarChar,50),
					new SqlParameter("@buyer_optout_isopen", SqlDbType.Int,4),
					new SqlParameter("@buyer_optout_email", SqlDbType.VarChar,50)};
			parameters[0].Value = model.order_sms_isopen;
			parameters[1].Value = model.order_sms_contact;
			parameters[2].Value = model.order_isopen;
			parameters[3].Value = model.order_email;
			parameters[4].Value = model.shipping_isopen;
			parameters[5].Value = model.shipping_email;
			parameters[6].Value = model.multichannel_isopen;
			parameters[7].Value = model.multichannel_email;
			parameters[8].Value = model.shipment_isopen;
			parameters[9].Value = model.shipment_email;
			parameters[10].Value = model.problem_isopen;
			parameters[11].Value = model.problem_email;
			parameters[12].Value = model.returns_isopen;
			parameters[13].Value = model.returns_email;
			parameters[14].Value = model.claims_isopen;
			parameters[15].Value = model.claims_email;
			parameters[16].Value = model.refund_isopen;
			parameters[17].Value = model.refund_email;
			parameters[18].Value = model.listing_created_isopen;
			parameters[19].Value = model.listing_created_email;
			parameters[20].Value = model.listing_closed_isopen;
			parameters[21].Value = model.listing_closed_email;
			parameters[22].Value = model.open_listings_isopen;
			parameters[23].Value = model.open_listings_email;
			parameters[24].Value = model.order_fulfillment_isopen;
			parameters[25].Value = model.order_fulfillment_email;
			parameters[26].Value = model.sold_listings_isopen;
			parameters[27].Value = model.sold_listings_email;
			parameters[28].Value = model.cancelled_listings_isopen;
			parameters[29].Value = model.cancelled_listings_email;
			parameters[30].Value = model.makeoffer_isopen;
			parameters[31].Value = model.makeoffer_email;
			parameters[32].Value = model.business_isopen;
			parameters[33].Value = model.business_email;
			parameters[34].Value = model.technical_isopen;
			parameters[35].Value = model.technical_email;
			parameters[36].Value = model.emergency_isopen;
			parameters[37].Value = model.emergency_phone;
			parameters[38].Value = model.buyer_messages_isopen;
			parameters[39].Value = model.buyer_messages_email;
			parameters[40].Value = model.confirmation_isopen;
			parameters[41].Value = model.confirmation_email;
			parameters[42].Value = model.delivery_failures_isopen;
			parameters[43].Value = model.delivery_failures_email;
			parameters[44].Value = model.buyer_optout_isopen;
			parameters[45].Value = model.buyer_optout_email;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="userID">用户编号</param>
        /// <param name="email">邮箱</param>
        /// <returns></returns>
        public int AddNotice(int userID,string email)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_user_notificationoptions(");
			strSql.Append("user_id,order_sms_isopen,order_sms_contact,order_isopen,order_email,shipping_isopen,shipping_email,multichannel_isopen,multichannel_email,shipment_isopen,shipment_email,problem_isopen,problem_email,returns_isopen,returns_email,claims_isopen,claims_email,refund_isopen,refund_email,listing_created_isopen,listing_created_email,listing_closed_isopen,listing_closed_email,open_listings_isopen,open_listings_email,order_fulfillment_isopen,order_fulfillment_email,sold_listings_isopen,sold_listings_email,cancelled_listings_isopen,cancelled_listings_email,makeoffer_isopen,makeoffer_email,business_isopen,business_email,technical_isopen,technical_email,emergency_isopen,emergency_phone,buyer_messages_isopen,buyer_messages_email,confirmation_isopen,confirmation_email,delivery_failures_isopen,delivery_failures_email,buyer_optout_isopen,buyer_optout_email)");
			strSql.Append(" values (");
            strSql.Append("@user_id,@order_sms_isopen,@order_sms_contact,@order_isopen,@order_email,@shipping_isopen,@shipping_email,@multichannel_isopen,@multichannel_email,@shipment_isopen,@shipment_email,@problem_isopen,@problem_email,@returns_isopen,@returns_email,@claims_isopen,@claims_email,@refund_isopen,@refund_email,@listing_created_isopen,@listing_created_email,@listing_closed_isopen,@listing_closed_email,@open_listings_isopen,@open_listings_email,@order_fulfillment_isopen,@order_fulfillment_email,@sold_listings_isopen,@sold_listings_email,@cancelled_listings_isopen,@cancelled_listings_email,@makeoffer_isopen,@makeoffer_email,@business_isopen,@business_email,@technical_isopen,@technical_email,@emergency_isopen,@emergency_phone,@buyer_messages_isopen,@buyer_messages_email,@confirmation_isopen,@confirmation_email,@delivery_failures_isopen,@delivery_failures_email,@buyer_optout_isopen,@buyer_optout_email)");
			SqlParameter[] parameters = {
                    new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@order_sms_isopen", SqlDbType.Int,4),
					new SqlParameter("@order_sms_contact", SqlDbType.Int,4),
					new SqlParameter("@order_isopen", SqlDbType.Int,4),
					new SqlParameter("@order_email", SqlDbType.VarChar,50),
					new SqlParameter("@shipping_isopen", SqlDbType.Int,4),
					new SqlParameter("@shipping_email", SqlDbType.VarChar,50),
					new SqlParameter("@multichannel_isopen", SqlDbType.Int,4),
					new SqlParameter("@multichannel_email", SqlDbType.VarChar,50),
					new SqlParameter("@shipment_isopen", SqlDbType.Int,4),
					new SqlParameter("@shipment_email", SqlDbType.VarChar,50),
					new SqlParameter("@problem_isopen", SqlDbType.Int,4),
					new SqlParameter("@problem_email", SqlDbType.VarChar,50),
					new SqlParameter("@returns_isopen", SqlDbType.Int,4),
					new SqlParameter("@returns_email", SqlDbType.VarChar,50),
					new SqlParameter("@claims_isopen", SqlDbType.Int,4),
					new SqlParameter("@claims_email", SqlDbType.VarChar,50),
					new SqlParameter("@refund_isopen", SqlDbType.Int,4),
					new SqlParameter("@refund_email", SqlDbType.VarChar,50),
					new SqlParameter("@listing_created_isopen", SqlDbType.Int,4),
					new SqlParameter("@listing_created_email", SqlDbType.VarChar,50),
					new SqlParameter("@listing_closed_isopen", SqlDbType.Int,4),
					new SqlParameter("@listing_closed_email", SqlDbType.VarChar,50),
					new SqlParameter("@open_listings_isopen", SqlDbType.Int,4),
					new SqlParameter("@open_listings_email", SqlDbType.VarChar,50),
					new SqlParameter("@order_fulfillment_isopen", SqlDbType.Int,4),
					new SqlParameter("@order_fulfillment_email", SqlDbType.VarChar,50),
					new SqlParameter("@sold_listings_isopen", SqlDbType.Int,4),
					new SqlParameter("@sold_listings_email", SqlDbType.VarChar,50),
					new SqlParameter("@cancelled_listings_isopen", SqlDbType.Int,4),
					new SqlParameter("@cancelled_listings_email", SqlDbType.VarChar,50),
					new SqlParameter("@makeoffer_isopen", SqlDbType.Int,4),
					new SqlParameter("@makeoffer_email", SqlDbType.VarChar,50),
					new SqlParameter("@business_isopen", SqlDbType.Int,4),
					new SqlParameter("@business_email", SqlDbType.VarChar,50),
					new SqlParameter("@technical_isopen", SqlDbType.Int,4),
					new SqlParameter("@technical_email", SqlDbType.VarChar,50),
					new SqlParameter("@emergency_isopen", SqlDbType.Int,4),
					new SqlParameter("@emergency_phone", SqlDbType.VarChar,50),
					new SqlParameter("@buyer_messages_isopen", SqlDbType.Int,4),
					new SqlParameter("@buyer_messages_email", SqlDbType.VarChar,50),
					new SqlParameter("@confirmation_isopen", SqlDbType.Int,4),
					new SqlParameter("@confirmation_email", SqlDbType.VarChar,50),
					new SqlParameter("@delivery_failures_isopen", SqlDbType.Int,4),
					new SqlParameter("@delivery_failures_email", SqlDbType.VarChar,50),
					new SqlParameter("@buyer_optout_isopen", SqlDbType.Int,4),
					new SqlParameter("@buyer_optout_email", SqlDbType.VarChar,50)};
            parameters[0].Value = userID;
            parameters[1].Value = 0;
			parameters[2].Value = 0;
			parameters[3].Value = 0;
			parameters[4].Value = email;
			parameters[5].Value = 0;
			parameters[6].Value = email;
			parameters[7].Value = 0;
			parameters[8].Value = email;
			parameters[9].Value = 0;
			parameters[10].Value =0;
			parameters[11].Value =0;
			parameters[12].Value = email;
			parameters[13].Value = 0;
			parameters[14].Value = email;
			parameters[15].Value = 0;
			parameters[16].Value = email;
			parameters[17].Value = 0;
			parameters[18].Value = email;
			parameters[19].Value = 0;
			parameters[20].Value = email;
			parameters[21].Value = 0;
			parameters[22].Value = email;
			parameters[23].Value = 0;
			parameters[24].Value = email;
			parameters[25].Value = 0;
            parameters[26].Value = email;
			parameters[27].Value = 0;
            parameters[28].Value = email;
			parameters[29].Value = 0;
            parameters[30].Value = email;
			parameters[31].Value = 0;
            parameters[32].Value = email;
			parameters[33].Value = 0;
            parameters[34].Value = email;
			parameters[35].Value = 0;
            parameters[36].Value = email;
			parameters[37].Value = 0;
			parameters[38].Value = string.Empty;
			parameters[39].Value = 0;
            parameters[40].Value = email;
			parameters[41].Value = 0;
            parameters[42].Value = email;
			parameters[43].Value = 0;
            parameters[44].Value = email;
			parameters[45].Value = 0;
            parameters[46].Value = email;

			int obj = DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (obj > 0)
			{
				return 1;
			}
			else
			{
                return 0;
			}
		}
        #endregion


        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(QAMZN.Model.tb_user_notificationoptions model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_user_notificationoptions set ");
			strSql.Append("order_sms_isopen=@order_sms_isopen,");
			strSql.Append("order_sms_contact=@order_sms_contact,");
			strSql.Append("order_isopen=@order_isopen,");
			strSql.Append("order_email=@order_email,");
			strSql.Append("shipping_isopen=@shipping_isopen,");
			strSql.Append("shipping_email=@shipping_email,");
			strSql.Append("multichannel_isopen=@multichannel_isopen,");
			strSql.Append("multichannel_email=@multichannel_email,");
			strSql.Append("shipment_isopen=@shipment_isopen,");
			strSql.Append("shipment_email=@shipment_email,");
			strSql.Append("problem_isopen=@problem_isopen,");
			strSql.Append("problem_email=@problem_email,");
			strSql.Append("returns_isopen=@returns_isopen,");
			strSql.Append("returns_email=@returns_email,");
			strSql.Append("claims_isopen=@claims_isopen,");
			strSql.Append("claims_email=@claims_email,");
			strSql.Append("refund_isopen=@refund_isopen,");
			strSql.Append("refund_email=@refund_email,");
			strSql.Append("listing_created_isopen=@listing_created_isopen,");
			strSql.Append("listing_created_email=@listing_created_email,");
			strSql.Append("listing_closed_isopen=@listing_closed_isopen,");
			strSql.Append("listing_closed_email=@listing_closed_email,");
			strSql.Append("open_listings_isopen=@open_listings_isopen,");
			strSql.Append("open_listings_email=@open_listings_email,");
			strSql.Append("order_fulfillment_isopen=@order_fulfillment_isopen,");
			strSql.Append("order_fulfillment_email=@order_fulfillment_email,");
			strSql.Append("sold_listings_isopen=@sold_listings_isopen,");
			strSql.Append("sold_listings_email=@sold_listings_email,");
			strSql.Append("cancelled_listings_isopen=@cancelled_listings_isopen,");
			strSql.Append("cancelled_listings_email=@cancelled_listings_email,");
			strSql.Append("makeoffer_isopen=@makeoffer_isopen,");
			strSql.Append("makeoffer_email=@makeoffer_email,");
			strSql.Append("business_isopen=@business_isopen,");
			strSql.Append("business_email=@business_email,");
			strSql.Append("technical_isopen=@technical_isopen,");
			strSql.Append("technical_email=@technical_email,");
			strSql.Append("emergency_isopen=@emergency_isopen,");
			strSql.Append("emergency_phone=@emergency_phone,");
			strSql.Append("buyer_messages_isopen=@buyer_messages_isopen,");
			strSql.Append("buyer_messages_email=@buyer_messages_email,");
			strSql.Append("confirmation_isopen=@confirmation_isopen,");
			strSql.Append("confirmation_email=@confirmation_email,");
			strSql.Append("delivery_failures_isopen=@delivery_failures_isopen,");
			strSql.Append("delivery_failures_email=@delivery_failures_email,");
			strSql.Append("buyer_optout_isopen=@buyer_optout_isopen,");
			strSql.Append("buyer_optout_email=@buyer_optout_email");
			strSql.Append(" where user_id=@user_id");
			SqlParameter[] parameters = {
					new SqlParameter("@order_sms_isopen", SqlDbType.Int,4),
					new SqlParameter("@order_sms_contact", SqlDbType.Int,4),
					new SqlParameter("@order_isopen", SqlDbType.Int,4),
					new SqlParameter("@order_email", SqlDbType.VarChar,50),
					new SqlParameter("@shipping_isopen", SqlDbType.Int,4),
					new SqlParameter("@shipping_email", SqlDbType.VarChar,50),
					new SqlParameter("@multichannel_isopen", SqlDbType.Int,4),
					new SqlParameter("@multichannel_email", SqlDbType.VarChar,50),
					new SqlParameter("@shipment_isopen", SqlDbType.Int,4),
					new SqlParameter("@shipment_email", SqlDbType.VarChar,50),
					new SqlParameter("@problem_isopen", SqlDbType.Int,4),
					new SqlParameter("@problem_email", SqlDbType.VarChar,50),
					new SqlParameter("@returns_isopen", SqlDbType.Int,4),
					new SqlParameter("@returns_email", SqlDbType.VarChar,50),
					new SqlParameter("@claims_isopen", SqlDbType.Int,4),
					new SqlParameter("@claims_email", SqlDbType.VarChar,50),
					new SqlParameter("@refund_isopen", SqlDbType.Int,4),
					new SqlParameter("@refund_email", SqlDbType.VarChar,50),
					new SqlParameter("@listing_created_isopen", SqlDbType.Int,4),
					new SqlParameter("@listing_created_email", SqlDbType.VarChar,50),
					new SqlParameter("@listing_closed_isopen", SqlDbType.Int,4),
					new SqlParameter("@listing_closed_email", SqlDbType.VarChar,50),
					new SqlParameter("@open_listings_isopen", SqlDbType.Int,4),
					new SqlParameter("@open_listings_email", SqlDbType.VarChar,50),
					new SqlParameter("@order_fulfillment_isopen", SqlDbType.Int,4),
					new SqlParameter("@order_fulfillment_email", SqlDbType.VarChar,50),
					new SqlParameter("@sold_listings_isopen", SqlDbType.Int,4),
					new SqlParameter("@sold_listings_email", SqlDbType.VarChar,50),
					new SqlParameter("@cancelled_listings_isopen", SqlDbType.Int,4),
					new SqlParameter("@cancelled_listings_email", SqlDbType.VarChar,50),
					new SqlParameter("@makeoffer_isopen", SqlDbType.Int,4),
					new SqlParameter("@makeoffer_email", SqlDbType.VarChar,50),
					new SqlParameter("@business_isopen", SqlDbType.Int,4),
					new SqlParameter("@business_email", SqlDbType.VarChar,50),
					new SqlParameter("@technical_isopen", SqlDbType.Int,4),
					new SqlParameter("@technical_email", SqlDbType.VarChar,50),
					new SqlParameter("@emergency_isopen", SqlDbType.Int,4),
					new SqlParameter("@emergency_phone", SqlDbType.VarChar,50),
					new SqlParameter("@buyer_messages_isopen", SqlDbType.Int,4),
					new SqlParameter("@buyer_messages_email", SqlDbType.VarChar,50),
					new SqlParameter("@confirmation_isopen", SqlDbType.Int,4),
					new SqlParameter("@confirmation_email", SqlDbType.VarChar,50),
					new SqlParameter("@delivery_failures_isopen", SqlDbType.Int,4),
					new SqlParameter("@delivery_failures_email", SqlDbType.VarChar,50),
					new SqlParameter("@buyer_optout_isopen", SqlDbType.Int,4),
					new SqlParameter("@buyer_optout_email", SqlDbType.VarChar,50),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
			parameters[0].Value = model.order_sms_isopen;
			parameters[1].Value = model.order_sms_contact;
			parameters[2].Value = model.order_isopen;
			parameters[3].Value = model.order_email;
			parameters[4].Value = model.shipping_isopen;
			parameters[5].Value = model.shipping_email;
			parameters[6].Value = model.multichannel_isopen;
			parameters[7].Value = model.multichannel_email;
			parameters[8].Value = model.shipment_isopen;
			parameters[9].Value = model.shipment_email;
			parameters[10].Value = model.problem_isopen;
			parameters[11].Value = model.problem_email;
			parameters[12].Value = model.returns_isopen;
			parameters[13].Value = model.returns_email;
			parameters[14].Value = model.claims_isopen;
			parameters[15].Value = model.claims_email;
			parameters[16].Value = model.refund_isopen;
			parameters[17].Value = model.refund_email;
			parameters[18].Value = model.listing_created_isopen;
			parameters[19].Value = model.listing_created_email;
			parameters[20].Value = model.listing_closed_isopen;
			parameters[21].Value = model.listing_closed_email;
			parameters[22].Value = model.open_listings_isopen;
			parameters[23].Value = model.open_listings_email;
			parameters[24].Value = model.order_fulfillment_isopen;
			parameters[25].Value = model.order_fulfillment_email;
			parameters[26].Value = model.sold_listings_isopen;
			parameters[27].Value = model.sold_listings_email;
			parameters[28].Value = model.cancelled_listings_isopen;
			parameters[29].Value = model.cancelled_listings_email;
			parameters[30].Value = model.makeoffer_isopen;
			parameters[31].Value = model.makeoffer_email;
			parameters[32].Value = model.business_isopen;
			parameters[33].Value = model.business_email;
			parameters[34].Value = model.technical_isopen;
			parameters[35].Value = model.technical_email;
			parameters[36].Value = model.emergency_isopen;
			parameters[37].Value = model.emergency_phone;
			parameters[38].Value = model.buyer_messages_isopen;
			parameters[39].Value = model.buyer_messages_email;
			parameters[40].Value = model.confirmation_isopen;
			parameters[41].Value = model.confirmation_email;
			parameters[42].Value = model.delivery_failures_isopen;
			parameters[43].Value = model.delivery_failures_email;
			parameters[44].Value = model.buyer_optout_isopen;
			parameters[45].Value = model.buyer_optout_email;
			parameters[46].Value = model.user_id;

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

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateContactId(int userid, int contact_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user_notificationoptions set ");
            strSql.Append("order_sms_contact=@order_sms_contact ");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@order_sms_contact", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = contact_id;
            parameters[1].Value = userid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 更新订单通知
        /// <summary>
        /// 更新订单通知
        /// </summary>
        public bool UpdateOrderNotification(int userid, int order_sms_isopen, int order_sms_contact, int order_isopen, string order_email, int shipping_isopen, string shipping_email, int multichannel_isopen, string multichannel_email, int shipment_isopen, string shipment_email, int problem_isopen, string problem_email)
        {  
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user_notificationoptions set ");
            strSql.Append("order_sms_isopen=@order_sms_isopen,");
            strSql.Append("order_sms_contact=@order_sms_contact,");
            strSql.Append("order_isopen=@order_isopen,");
            strSql.Append("order_email=@order_email,");
            strSql.Append("shipping_isopen=@shipping_isopen,");
            strSql.Append("shipping_email=@shipping_email,");
            strSql.Append("multichannel_isopen=@multichannel_isopen,");
            strSql.Append("multichannel_email=@multichannel_email,");
            strSql.Append("shipment_isopen=@shipment_isopen,");
            strSql.Append("shipment_email=@shipment_email,");
            strSql.Append("problem_isopen=@problem_isopen,");
            strSql.Append("problem_email=@problem_email");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@order_sms_isopen", SqlDbType.Int,4),
					new SqlParameter("@order_sms_contact", SqlDbType.Int,4),
					new SqlParameter("@order_isopen", SqlDbType.Int,4),
					new SqlParameter("@order_email", SqlDbType.VarChar,50),
					new SqlParameter("@shipping_isopen", SqlDbType.Int,4),
					new SqlParameter("@shipping_email", SqlDbType.VarChar,50),
					new SqlParameter("@multichannel_isopen", SqlDbType.Int,4),
					new SqlParameter("@multichannel_email", SqlDbType.VarChar,50),
					new SqlParameter("@shipment_isopen", SqlDbType.Int,4),
					new SqlParameter("@shipment_email", SqlDbType.VarChar,50),
					new SqlParameter("@problem_isopen", SqlDbType.Int,4),
					new SqlParameter("@problem_email", SqlDbType.VarChar,50),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = order_sms_isopen;
            parameters[1].Value = order_sms_contact;
            parameters[2].Value = order_isopen;
            parameters[3].Value = order_email;
            parameters[4].Value = shipping_isopen;
            parameters[5].Value = shipping_email;
            parameters[6].Value = multichannel_isopen;
            parameters[7].Value = multichannel_email;
            parameters[8].Value = shipment_isopen;
            parameters[9].Value = shipment_email;
            parameters[10].Value = problem_isopen;
            parameters[11].Value = problem_email;
            parameters[12].Value = userid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 更新订货和索赔通知
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateOrderNotification2(int userid, int returns_isopen, string refund_email, int claims_isopen, string claims_email, int refund_isopen, string returns_email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user_notificationoptions set ");
            strSql.Append("returns_isopen=@returns_isopen,");
            strSql.Append("returns_email=@returns_email,");
            strSql.Append("claims_isopen=@claims_isopen,");
            strSql.Append("claims_email=@claims_email,");
            strSql.Append("refund_isopen=@refund_isopen,");
            strSql.Append("refund_email=@refund_email");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@returns_isopen", SqlDbType.Int,4),
					new SqlParameter("@returns_email", SqlDbType.VarChar,50),
					new SqlParameter("@claims_isopen", SqlDbType.Int,4),
					new SqlParameter("@claims_email", SqlDbType.VarChar,50),
					new SqlParameter("@refund_isopen", SqlDbType.Int,4),
					new SqlParameter("@refund_email", SqlDbType.VarChar,50),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = returns_isopen;
            parameters[1].Value = returns_email;
            parameters[2].Value = claims_isopen;
            parameters[3].Value = claims_email;
            parameters[4].Value = refund_isopen;
            parameters[5].Value = refund_email;
            parameters[6].Value = userid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region   更新商品通知
        public bool UpdateOrderNotification3(int userid, int listing_created_isopen, string listing_created_email, int listing_closed_isopen, string listing_closed_email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user_notificationoptions set ");
            strSql.Append("listing_created_isopen=@listing_created_isopen,");
            strSql.Append("listing_created_email=@listing_created_email,");
            strSql.Append("listing_closed_isopen=@listing_closed_isopen,");
            strSql.Append("listing_closed_email=@listing_closed_email");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@listing_created_isopen", SqlDbType.Int,4),
					new SqlParameter("@listing_created_email", SqlDbType.VarChar,50),
					new SqlParameter("@listing_closed_isopen", SqlDbType.Int,4),
					new SqlParameter("@listing_closed_email", SqlDbType.VarChar,50),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = listing_created_isopen;
            parameters[1].Value = listing_created_email;
            parameters[2].Value = listing_closed_isopen;
            parameters[3].Value = listing_closed_email;
            parameters[4].Value = userid;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 更新报告 UpdateOrderNotification4
        public bool UpdateOrderNotification4(int userid,int open_listings_isopen, string open_listings_email, int order_fulfillment_isopen, string order_fulfillment_email, int sold_listings_isopen, string sold_listings_email, int cancelled_listings_isopen, string cancelled_listings_email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user_notificationoptions set ");

            strSql.Append("open_listings_isopen=@open_listings_isopen,");
            strSql.Append("open_listings_email=@open_listings_email,");
            strSql.Append("order_fulfillment_isopen=@order_fulfillment_isopen,");
            strSql.Append("order_fulfillment_email=@order_fulfillment_email,");
            strSql.Append("sold_listings_isopen=@sold_listings_isopen,");
            strSql.Append("sold_listings_email=@sold_listings_email,");
            strSql.Append("cancelled_listings_isopen=@cancelled_listings_isopen,");
            strSql.Append("cancelled_listings_email=@cancelled_listings_email");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@open_listings_isopen", SqlDbType.Int,4),
					new SqlParameter("@open_listings_email", SqlDbType.VarChar,50),
					new SqlParameter("@order_fulfillment_isopen", SqlDbType.Int,4),
					new SqlParameter("@order_fulfillment_email", SqlDbType.VarChar,50),
					new SqlParameter("@sold_listings_isopen", SqlDbType.Int,4),
					new SqlParameter("@sold_listings_email", SqlDbType.VarChar,50),
					new SqlParameter("@cancelled_listings_isopen", SqlDbType.Int,4),
					new SqlParameter("@cancelled_listings_email", SqlDbType.VarChar,50),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = open_listings_isopen;
            parameters[1].Value = open_listings_email;
            parameters[2].Value = order_fulfillment_isopen;
            parameters[3].Value = order_fulfillment_email;
            parameters[4].Value = sold_listings_isopen;
            parameters[5].Value = sold_listings_email;
            parameters[6].Value = cancelled_listings_isopen;
            parameters[7].Value = cancelled_listings_email;
            parameters[8].Value = userid;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region  更新出价通知 UpdateOrderNotification5
        public bool UpdateOrderNotification5(int userid, int makeoffer_isopen, string makeoffer_email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user_notificationoptions set ");
            strSql.Append("makeoffer_isopen=@makeoffer_isopen,");
            strSql.Append("makeoffer_email=@makeoffer_email");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@makeoffer_isopen", SqlDbType.Int,4),
					new SqlParameter("@makeoffer_email", SqlDbType.VarChar,50),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = makeoffer_isopen;
            parameters[1].Value = makeoffer_email;
            parameters[2].Value = userid;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region UpdateOrderNotification6
        public bool UpdateOrderNotification6(int userid, int business_isopen, string business_email, int technical_isopen, string technical_email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user_notificationoptions set ");
            strSql.Append("business_isopen=@business_isopen,");
            strSql.Append("business_email=@business_email,");
            strSql.Append("technical_isopen=@technical_isopen,");
            strSql.Append("technical_email=@technical_email");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@business_isopen", SqlDbType.Int,4),
					new SqlParameter("@business_email", SqlDbType.VarChar,50),
					new SqlParameter("@technical_isopen", SqlDbType.Int,4),
					new SqlParameter("@technical_email", SqlDbType.VarChar,50),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = business_isopen;
            parameters[1].Value = business_email;
            parameters[2].Value = technical_isopen;
            parameters[3].Value = technical_email;
            parameters[4].Value = userid;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 更新紧急通知
        /// <summary>
        /// 更新紧急通知
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="emergency_isopen"></param>
        /// <param name="emergency_phone"></param>
        /// <returns></returns>
        public bool UpdateOrderNotification7(int userid, int emergency_isopen, string emergency_phone)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user_notificationoptions set ");
            strSql.Append("emergency_isopen=@emergency_isopen,");
            strSql.Append("emergency_phone=@emergency_phone");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@emergency_isopen", SqlDbType.Int,4),
					new SqlParameter("@emergency_phone", SqlDbType.VarChar,50),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = emergency_isopen;
            parameters[1].Value = emergency_phone;
            parameters[2].Value = userid;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 更新消息通知
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateOrderNotification8(int userid, int buyer_messages_isopen, string buyer_messages_email, int confirmation_isopen, string confirmation_email, int delivery_failures_isopen, string delivery_failures_email, int buyer_optout_isopen, string buyer_optout_email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user_notificationoptions set ");
            strSql.Append("buyer_messages_isopen=@buyer_messages_isopen,");
            strSql.Append("buyer_messages_email=@buyer_messages_email,");
            strSql.Append("confirmation_isopen=@confirmation_isopen,");
            strSql.Append("confirmation_email=@confirmation_email,");
            strSql.Append("delivery_failures_isopen=@delivery_failures_isopen,");
            strSql.Append("delivery_failures_email=@delivery_failures_email,");
            strSql.Append("buyer_optout_isopen=@buyer_optout_isopen,");
            strSql.Append("buyer_optout_email=@buyer_optout_email");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@buyer_messages_isopen", SqlDbType.Int,4),
					new SqlParameter("@buyer_messages_email", SqlDbType.VarChar,50),
					new SqlParameter("@confirmation_isopen", SqlDbType.Int,4),
					new SqlParameter("@confirmation_email", SqlDbType.VarChar,50),
					new SqlParameter("@delivery_failures_isopen", SqlDbType.Int,4),
					new SqlParameter("@delivery_failures_email", SqlDbType.VarChar,50),
					new SqlParameter("@buyer_optout_isopen", SqlDbType.Int,4),
					new SqlParameter("@buyer_optout_email", SqlDbType.VarChar,50),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = buyer_messages_isopen;
            parameters[1].Value = buyer_messages_email;
            parameters[2].Value = confirmation_isopen;
            parameters[3].Value = confirmation_email;
            parameters[4].Value = delivery_failures_isopen;
            parameters[5].Value = delivery_failures_email;
            parameters[6].Value = buyer_optout_isopen;
            parameters[7].Value = buyer_optout_email;
            parameters[8].Value = userid;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        /// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int user_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_user_notificationoptions ");
			strSql.Append(" where user_id=@user_id");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)
			};
			parameters[0].Value = user_id;

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
		public bool DeleteList(string user_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_user_notificationoptions ");
			strSql.Append(" where user_id in ("+user_idlist + ")  ");
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


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public QAMZN.Model.tb_user_notificationoptions GetModel(int user_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 user_id,order_sms_isopen,order_sms_contact,order_isopen,order_email,shipping_isopen,shipping_email,multichannel_isopen,multichannel_email,shipment_isopen,shipment_email,problem_isopen,problem_email,returns_isopen,returns_email,claims_isopen,claims_email,refund_isopen,refund_email,listing_created_isopen,listing_created_email,listing_closed_isopen,listing_closed_email,open_listings_isopen,open_listings_email,order_fulfillment_isopen,order_fulfillment_email,sold_listings_isopen,sold_listings_email,cancelled_listings_isopen,cancelled_listings_email,makeoffer_isopen,makeoffer_email,business_isopen,business_email,technical_isopen,technical_email,emergency_isopen,emergency_phone,buyer_messages_isopen,buyer_messages_email,confirmation_isopen,confirmation_email,delivery_failures_isopen,delivery_failures_email,buyer_optout_isopen,buyer_optout_email from tb_user_notificationoptions ");
			strSql.Append(" where user_id=@user_id");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)
			};
			parameters[0].Value = user_id;

			QAMZN.Model.tb_user_notificationoptions model=new QAMZN.Model.tb_user_notificationoptions();
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


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public QAMZN.Model.tb_user_notificationoptions DataRowToModel(DataRow row)
		{
			QAMZN.Model.tb_user_notificationoptions model=new QAMZN.Model.tb_user_notificationoptions();
			if (row != null)
			{
				if(row["user_id"]!=null && row["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(row["user_id"].ToString());
				}
				if(row["order_sms_isopen"]!=null && row["order_sms_isopen"].ToString()!="")
				{
					model.order_sms_isopen=int.Parse(row["order_sms_isopen"].ToString());
				}
				if(row["order_sms_contact"]!=null && row["order_sms_contact"].ToString()!="")
				{
					model.order_sms_contact=int.Parse(row["order_sms_contact"].ToString());
				}
				if(row["order_isopen"]!=null && row["order_isopen"].ToString()!="")
				{
					model.order_isopen=int.Parse(row["order_isopen"].ToString());
				}
				if(row["order_email"]!=null)
				{
					model.order_email=row["order_email"].ToString();
				}
				if(row["shipping_isopen"]!=null && row["shipping_isopen"].ToString()!="")
				{
					model.shipping_isopen=int.Parse(row["shipping_isopen"].ToString());
				}
				if(row["shipping_email"]!=null)
				{
					model.shipping_email=row["shipping_email"].ToString();
				}
				if(row["multichannel_isopen"]!=null && row["multichannel_isopen"].ToString()!="")
				{
					model.multichannel_isopen=int.Parse(row["multichannel_isopen"].ToString());
				}
				if(row["multichannel_email"]!=null)
				{
					model.multichannel_email=row["multichannel_email"].ToString();
				}
				if(row["shipment_isopen"]!=null && row["shipment_isopen"].ToString()!="")
				{
					model.shipment_isopen=int.Parse(row["shipment_isopen"].ToString());
				}
				if(row["shipment_email"]!=null)
				{
					model.shipment_email=row["shipment_email"].ToString();
				}
				if(row["problem_isopen"]!=null && row["problem_isopen"].ToString()!="")
				{
					model.problem_isopen=int.Parse(row["problem_isopen"].ToString());
				}
				if(row["problem_email"]!=null)
				{
					model.problem_email=row["problem_email"].ToString();
				}
				if(row["returns_isopen"]!=null && row["returns_isopen"].ToString()!="")
				{
					model.returns_isopen=int.Parse(row["returns_isopen"].ToString());
				}
				if(row["returns_email"]!=null)
				{
					model.returns_email=row["returns_email"].ToString();
				}
				if(row["claims_isopen"]!=null && row["claims_isopen"].ToString()!="")
				{
					model.claims_isopen=int.Parse(row["claims_isopen"].ToString());
				}
				if(row["claims_email"]!=null)
				{
					model.claims_email=row["claims_email"].ToString();
				}
				if(row["refund_isopen"]!=null && row["refund_isopen"].ToString()!="")
				{
					model.refund_isopen=int.Parse(row["refund_isopen"].ToString());
				}
				if(row["refund_email"]!=null)
				{
					model.refund_email=row["refund_email"].ToString();
				}
				if(row["listing_created_isopen"]!=null && row["listing_created_isopen"].ToString()!="")
				{
					model.listing_created_isopen=int.Parse(row["listing_created_isopen"].ToString());
				}
				if(row["listing_created_email"]!=null)
				{
					model.listing_created_email=row["listing_created_email"].ToString();
				}
				if(row["listing_closed_isopen"]!=null && row["listing_closed_isopen"].ToString()!="")
				{
					model.listing_closed_isopen=int.Parse(row["listing_closed_isopen"].ToString());
				}
				if(row["listing_closed_email"]!=null)
				{
					model.listing_closed_email=row["listing_closed_email"].ToString();
				}
				if(row["open_listings_isopen"]!=null && row["open_listings_isopen"].ToString()!="")
				{
					model.open_listings_isopen=int.Parse(row["open_listings_isopen"].ToString());
				}
				if(row["open_listings_email"]!=null)
				{
					model.open_listings_email=row["open_listings_email"].ToString();
				}
				if(row["order_fulfillment_isopen"]!=null && row["order_fulfillment_isopen"].ToString()!="")
				{
					model.order_fulfillment_isopen=int.Parse(row["order_fulfillment_isopen"].ToString());
				}
				if(row["order_fulfillment_email"]!=null)
				{
					model.order_fulfillment_email=row["order_fulfillment_email"].ToString();
				}
				if(row["sold_listings_isopen"]!=null && row["sold_listings_isopen"].ToString()!="")
				{
					model.sold_listings_isopen=int.Parse(row["sold_listings_isopen"].ToString());
				}
				if(row["sold_listings_email"]!=null)
				{
					model.sold_listings_email=row["sold_listings_email"].ToString();
				}
				if(row["cancelled_listings_isopen"]!=null && row["cancelled_listings_isopen"].ToString()!="")
				{
					model.cancelled_listings_isopen=int.Parse(row["cancelled_listings_isopen"].ToString());
				}
				if(row["cancelled_listings_email"]!=null)
				{
					model.cancelled_listings_email=row["cancelled_listings_email"].ToString();
				}
				if(row["makeoffer_isopen"]!=null && row["makeoffer_isopen"].ToString()!="")
				{
					model.makeoffer_isopen=int.Parse(row["makeoffer_isopen"].ToString());
				}
				if(row["makeoffer_email"]!=null)
				{
					model.makeoffer_email=row["makeoffer_email"].ToString();
				}
				if(row["business_isopen"]!=null && row["business_isopen"].ToString()!="")
				{
					model.business_isopen=int.Parse(row["business_isopen"].ToString());
				}
				if(row["business_email"]!=null)
				{
					model.business_email=row["business_email"].ToString();
				}
				if(row["technical_isopen"]!=null && row["technical_isopen"].ToString()!="")
				{
					model.technical_isopen=int.Parse(row["technical_isopen"].ToString());
				}
				if(row["technical_email"]!=null)
				{
					model.technical_email=row["technical_email"].ToString();
				}
				if(row["emergency_isopen"]!=null && row["emergency_isopen"].ToString()!="")
				{
					model.emergency_isopen=int.Parse(row["emergency_isopen"].ToString());
				}
				if(row["emergency_phone"]!=null)
				{
					model.emergency_phone=row["emergency_phone"].ToString();
				}
				if(row["buyer_messages_isopen"]!=null && row["buyer_messages_isopen"].ToString()!="")
				{
					model.buyer_messages_isopen=int.Parse(row["buyer_messages_isopen"].ToString());
				}
				if(row["buyer_messages_email"]!=null)
				{
					model.buyer_messages_email=row["buyer_messages_email"].ToString();
				}
				if(row["confirmation_isopen"]!=null && row["confirmation_isopen"].ToString()!="")
				{
					model.confirmation_isopen=int.Parse(row["confirmation_isopen"].ToString());
				}
				if(row["confirmation_email"]!=null)
				{
					model.confirmation_email=row["confirmation_email"].ToString();
				}
				if(row["delivery_failures_isopen"]!=null && row["delivery_failures_isopen"].ToString()!="")
				{
					model.delivery_failures_isopen=int.Parse(row["delivery_failures_isopen"].ToString());
				}
				if(row["delivery_failures_email"]!=null)
				{
					model.delivery_failures_email=row["delivery_failures_email"].ToString();
				}
				if(row["buyer_optout_isopen"]!=null && row["buyer_optout_isopen"].ToString()!="")
				{
					model.buyer_optout_isopen=int.Parse(row["buyer_optout_isopen"].ToString());
				}
				if(row["buyer_optout_email"]!=null)
				{
					model.buyer_optout_email=row["buyer_optout_email"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select user_id,order_sms_isopen,order_sms_contact,order_isopen,order_email,shipping_isopen,shipping_email,multichannel_isopen,multichannel_email,shipment_isopen,shipment_email,problem_isopen,problem_email,returns_isopen,returns_email,claims_isopen,claims_email,refund_isopen,refund_email,listing_created_isopen,listing_created_email,listing_closed_isopen,listing_closed_email,open_listings_isopen,open_listings_email,order_fulfillment_isopen,order_fulfillment_email,sold_listings_isopen,sold_listings_email,cancelled_listings_isopen,cancelled_listings_email,makeoffer_isopen,makeoffer_email,business_isopen,business_email,technical_isopen,technical_email,emergency_isopen,emergency_phone,buyer_messages_isopen,buyer_messages_email,confirmation_isopen,confirmation_email,delivery_failures_isopen,delivery_failures_email,buyer_optout_isopen,buyer_optout_email ");
			strSql.Append(" FROM tb_user_notificationoptions ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

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
			strSql.Append(" user_id,order_sms_isopen,order_sms_contact,order_isopen,order_email,shipping_isopen,shipping_email,multichannel_isopen,multichannel_email,shipment_isopen,shipment_email,problem_isopen,problem_email,returns_isopen,returns_email,claims_isopen,claims_email,refund_isopen,refund_email,listing_created_isopen,listing_created_email,listing_closed_isopen,listing_closed_email,open_listings_isopen,open_listings_email,order_fulfillment_isopen,order_fulfillment_email,sold_listings_isopen,sold_listings_email,cancelled_listings_isopen,cancelled_listings_email,makeoffer_isopen,makeoffer_email,business_isopen,business_email,technical_isopen,technical_email,emergency_isopen,emergency_phone,buyer_messages_isopen,buyer_messages_email,confirmation_isopen,confirmation_email,delivery_failures_isopen,delivery_failures_email,buyer_optout_isopen,buyer_optout_email ");
			strSql.Append(" FROM tb_user_notificationoptions ");
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
			strSql.Append("select count(1) FROM tb_user_notificationoptions ");
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
				strSql.Append("order by T.user_id desc");
			}
			strSql.Append(")AS Row, T.*  from tb_user_notificationoptions T ");
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
			parameters[0].Value = "tb_user_notificationoptions";
			parameters[1].Value = "user_id";
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

