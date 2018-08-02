/**  版本信息模板在安装目录下，可自行修改。
* tb_virtual_shop.cs
*
* 功 能： N/A
* 类 名： tb_virtual_shop
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/4 星期三 下午 4:13:15   N/A    初版
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
	/// 数据访问类:tb_virtual_shop
	/// </summary>
	public partial class tb_virtual_shop
	{
		public tb_virtual_shop()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("user_id", "tb_virtual_shop"); 
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="shopname">店铺名称</param>
        /// <returns></returns>
        public bool Exists(int userid,string shopname)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_virtual_shop");
            strSql.Append(" where shop_name=@shopname and user_id not in(@userid)");
			SqlParameter[] parameters = {
					new SqlParameter("@shopname", SqlDbType.NVarChar,50),
                     new SqlParameter("@userid", SqlDbType.Int,4)};
            parameters[0].Value = shopname;
            parameters[1].Value = userid;
			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(QAMZN.Model.tb_virtual_shop model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_virtual_shop(");
			strSql.Append("user_id,shop_name,shop_level,shop_intro,shop_logo,shop_link,service_email,service_phone,service_reply_email,vacation,about_seller,shipping_rates,shipping_policies,FAQ,privacy_policy)");
			strSql.Append(" values (");
			strSql.Append("@user_id,@shop_name,@shop_level,@shop_intro,@shop_logo,@shop_link,@service_email,@service_phone,@service_reply_email,@vacation,@about_seller,@shipping_rates,@shipping_policies,@FAQ,@privacy_policy)");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@shop_name", SqlDbType.VarChar,50),
					new SqlParameter("@shop_level", SqlDbType.Int,4),
					new SqlParameter("@shop_intro", SqlDbType.Text),
					new SqlParameter("@shop_logo", SqlDbType.VarChar,20),
					new SqlParameter("@shop_link", SqlDbType.VarChar,500),
					new SqlParameter("@service_email", SqlDbType.VarChar,50),
					new SqlParameter("@service_phone", SqlDbType.VarChar,50),
					new SqlParameter("@service_reply_email", SqlDbType.VarChar,50),
					new SqlParameter("@vacation", SqlDbType.Int,4),
					new SqlParameter("@about_seller", SqlDbType.Text),
					new SqlParameter("@shipping_rates", SqlDbType.Text),
					new SqlParameter("@shipping_policies", SqlDbType.Text),
					new SqlParameter("@FAQ", SqlDbType.Text),
					new SqlParameter("@privacy_policy", SqlDbType.Text)};
			parameters[0].Value = model.user_id;
			parameters[1].Value = model.shop_name;
			parameters[2].Value = model.shop_level;
			parameters[3].Value = model.shop_intro;
			parameters[4].Value = model.shop_logo;
			parameters[5].Value = model.shop_link;
			parameters[6].Value = model.service_email;
			parameters[7].Value = model.service_phone;
			parameters[8].Value = model.service_reply_email;
			parameters[9].Value = model.vacation;
			parameters[10].Value = model.about_seller;
			parameters[11].Value = model.shipping_rates;
			parameters[12].Value = model.shipping_policies;
			parameters[13].Value = model.FAQ;
			parameters[14].Value = model.privacy_policy;

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
        /// 增加一条数据
        /// </summary>
        /// <param name="userID">用户编号</param>
        /// <param name="email">邮箱</param>
        /// <returns></returns>
        public bool AddShopInfo(int userID,string email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_virtual_shop(");
            strSql.Append("user_id,shop_name,shop_level,shop_intro,shop_logo,shop_link,service_email,service_phone,service_reply_email,vacation,about_seller,shipping_rates,shipping_policies,FAQ,privacy_policy)");
            strSql.Append(" values (");
            strSql.Append("@user_id,@shop_name,@shop_level,@shop_intro,@shop_logo,@shop_link,@service_email,@service_phone,@service_reply_email,@vacation,@about_seller,@shipping_rates,@shipping_policies,@FAQ,@privacy_policy)");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@shop_name", SqlDbType.VarChar,50),
					new SqlParameter("@shop_level", SqlDbType.Int,4),
					new SqlParameter("@shop_intro", SqlDbType.Text),
					new SqlParameter("@shop_logo", SqlDbType.VarChar,20),
					new SqlParameter("@shop_link", SqlDbType.VarChar,500),
					new SqlParameter("@service_email", SqlDbType.VarChar,50),
					new SqlParameter("@service_phone", SqlDbType.VarChar,50),
					new SqlParameter("@service_reply_email", SqlDbType.VarChar,50),
					new SqlParameter("@vacation", SqlDbType.Int,4),
					new SqlParameter("@about_seller", SqlDbType.Text),
					new SqlParameter("@shipping_rates", SqlDbType.Text),
					new SqlParameter("@shipping_policies", SqlDbType.Text),
					new SqlParameter("@FAQ", SqlDbType.Text),
					new SqlParameter("@privacy_policy", SqlDbType.Text)};
            parameters[0].Value = userID;
            parameters[1].Value = string.Empty;
            parameters[2].Value = 1;
            parameters[3].Value = string.Empty;
            parameters[4].Value = string.Empty;
            parameters[5].Value = string.Empty;
            parameters[6].Value = email;
            parameters[7].Value = string.Empty;
            parameters[8].Value = email;
            parameters[9].Value = 1;
            parameters[10].Value = string.Empty;
            parameters[11].Value = string.Empty;
            parameters[12].Value = string.Empty;
            parameters[13].Value = string.Empty;
            parameters[14].Value = string.Empty;

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

        /// <summary>
        /// 商户注册（通过邮箱注册）
        /// </summary>
        /// <param name="name">商户名称</param>
        /// <param name="pwd">密码</param>
        /// <param name="email">邮箱</param>
        /// <param name="token">商户标志</param>
        /// <param name="stuid">学生ID</param>
        /// <param name="stuaccount">学生账号</param>
        /// <param name="trainingmode">实训类型</param>
        /// <returns></returns>
        public int Pro_initial_shop(string name, string pwd, string email, string token, int stuid, string stuaccount, int trainingmode)
        {
            int rowsAffected;
            int res = -1;
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,50),	
                    new SqlParameter("@pwd", SqlDbType.VarChar,50),	
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@token", SqlDbType.VarChar,50),
					new SqlParameter("@stu_id", SqlDbType.Int,4), 
                    new SqlParameter("@stu_account", SqlDbType.VarChar,50),
                    new SqlParameter("@stu_training_mode", SqlDbType.Int,4),
                    new SqlParameter("@res", SqlDbType.Int,4),
                                        };
            parameters[0].Value = name;
            parameters[1].Value = pwd;
            parameters[2].Value = email;
            parameters[3].Value = token;
            parameters[4].Value = stuid;
            parameters[5].Value = stuaccount;
            parameters[6].Value = trainingmode;
            parameters[7].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("Pro_initial_shop", parameters, out rowsAffected);
            res=(int)parameters[7].Value;
            return res;
        }



        /// <summary>
        /// 更新店铺名称
        /// </summary>
        /// <param name="userid">用户标识</param>
        /// <param name="storename">店铺名称</param>
        /// <param name="mobile">手机号</param>
        /// <returns></returns>
        public bool UpdateShopName(int userid, string storename, string mobile)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_virtual_shop set ");
            strSql.Append("shop_name=@shop_name,");
            strSql.Append("service_phone=@service_phone");
            strSql.Append(" where user_id=@userid ");
            SqlParameter[] parameters = {
					new SqlParameter("@shop_name", SqlDbType.VarChar,50),
					new SqlParameter("@service_phone", SqlDbType.VarChar,50),
					new SqlParameter("@userid", SqlDbType.Int,4)};
            parameters[0].Value = storename;
            parameters[1].Value = mobile;
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

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(QAMZN.Model.tb_virtual_shop model)
        {
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_virtual_shop set ");
			strSql.Append("shop_name=@shop_name,");
			strSql.Append("shop_level=@shop_level,");
			strSql.Append("shop_intro=@shop_intro,");
			strSql.Append("shop_logo=@shop_logo,");
			strSql.Append("shop_link=@shop_link,");
			strSql.Append("service_email=@service_email,");
			strSql.Append("service_phone=@service_phone,");
			strSql.Append("service_reply_email=@service_reply_email,");
			strSql.Append("vacation=@vacation,");
			strSql.Append("about_seller=@about_seller,");
			strSql.Append("shipping_rates=@shipping_rates,");
			strSql.Append("shipping_policies=@shipping_policies,");
			strSql.Append("FAQ=@FAQ,");
			strSql.Append("privacy_policy=@privacy_policy");
			strSql.Append(" where user_id=@user_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@shop_name", SqlDbType.VarChar,50),
					new SqlParameter("@shop_level", SqlDbType.Int,4),
					new SqlParameter("@shop_intro", SqlDbType.Text),
					new SqlParameter("@shop_logo", SqlDbType.VarChar,20),
					new SqlParameter("@shop_link", SqlDbType.VarChar,500),
					new SqlParameter("@service_email", SqlDbType.VarChar,50),
					new SqlParameter("@service_phone", SqlDbType.VarChar,50),
					new SqlParameter("@service_reply_email", SqlDbType.VarChar,50),
					new SqlParameter("@vacation", SqlDbType.Int,4),
					new SqlParameter("@about_seller", SqlDbType.Text),
					new SqlParameter("@shipping_rates", SqlDbType.Text),
					new SqlParameter("@shipping_policies", SqlDbType.Text),
					new SqlParameter("@FAQ", SqlDbType.Text),
					new SqlParameter("@privacy_policy", SqlDbType.Text),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
			parameters[0].Value = model.shop_name;
			parameters[1].Value = model.shop_level;
			parameters[2].Value = model.shop_intro;
			parameters[3].Value = model.shop_logo;
			parameters[4].Value = model.shop_link;
			parameters[5].Value = model.service_email;
			parameters[6].Value = model.service_phone;
			parameters[7].Value = model.service_reply_email;
			parameters[8].Value = model.vacation;
			parameters[9].Value = model.about_seller;
			parameters[10].Value = model.shipping_rates;
			parameters[11].Value = model.shipping_policies;
			parameters[12].Value = model.FAQ;
			parameters[13].Value = model.privacy_policy;
			parameters[14].Value = model.user_id;

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

        #region UpdateStoreDetails 修改商户详情
        /// <summary>
        /// 修改商户详情
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="shop_name">店铺名称</param>
        /// <param name="shop_link">店铺链接</param>
        /// <returns></returns>
        public bool UpdateStoreDetails(int userid, string shop_name, string shop_link)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_virtual_shop set ");
            strSql.Append("shop_name=@shop_name,");
            strSql.Append("shop_link=@shop_link");
            strSql.Append(" where user_id=@user_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@shop_name", SqlDbType.VarChar,50),
					new SqlParameter("@shop_link", SqlDbType.VarChar,500),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = shop_name;
            parameters[1].Value = shop_link;
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


        #region ServiceDetails 修改客户服务详细信息

        /// <summary>
        /// 修改客户服务详细信息
        /// </summary>
        /// <param name="userid">商户编号</param>
        /// <param name="service_email">客户服务电子邮件</param>
        /// <param name="service_phone">客服电话</param>
        /// <param name="service_reply_email">客服回复电子邮件</param>
        public bool ServiceDetails(int userid, string service_email, string service_phone, string service_reply_email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_virtual_shop set ");
            strSql.Append("service_email=@service_email,");
            strSql.Append("service_phone=@service_phone,");
            strSql.Append("service_reply_email=@service_reply_email ");
            strSql.Append(" where user_id=@user_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@service_email", SqlDbType.VarChar,50),
					new SqlParameter("@service_phone", SqlDbType.VarChar,50),
					new SqlParameter("@service_reply_email", SqlDbType.VarChar,50),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = service_email;
            parameters[1].Value = service_phone;
            parameters[2].Value = service_reply_email;
            parameters[3].Value = userid;

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
			strSql.Append("delete from tb_virtual_shop ");
			strSql.Append(" where user_id=@user_id ");
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
			strSql.Append("delete from tb_virtual_shop ");
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
        public QAMZN.Model.tb_virtual_shop GetStorename(int user_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 user_id,shop_name,shop_level,shop_intro,shop_logo,shop_link,service_email,service_phone,service_reply_email,vacation,about_seller,shipping_rates,shipping_policies,FAQ,privacy_policy from tb_virtual_shop ");
			strSql.Append(" where user_id=@user_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)
                                        };
			parameters[0].Value = user_id;

			QAMZN.Model.tb_virtual_shop model=new QAMZN.Model.tb_virtual_shop();
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
		public QAMZN.Model.tb_virtual_shop DataRowToModel(DataRow row)
		{
			QAMZN.Model.tb_virtual_shop model=new QAMZN.Model.tb_virtual_shop();
			if (row != null)
			{
				if(row["user_id"]!=null && row["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(row["user_id"].ToString());
				}
				if(row["shop_name"]!=null)
				{
					model.shop_name=row["shop_name"].ToString();
				}
				if(row["shop_level"]!=null && row["shop_level"].ToString()!="")
				{
					model.shop_level=int.Parse(row["shop_level"].ToString());
				}
				if(row["shop_intro"]!=null)
				{
					model.shop_intro=row["shop_intro"].ToString();
				}
				if(row["shop_logo"]!=null)
				{
					model.shop_logo=row["shop_logo"].ToString();
				}
				if(row["shop_link"]!=null)
				{
					model.shop_link=row["shop_link"].ToString();
				}
				if(row["service_email"]!=null)
				{
					model.service_email=row["service_email"].ToString();
				}
				if(row["service_phone"]!=null)
				{
					model.service_phone=row["service_phone"].ToString();
				}
				if(row["service_reply_email"]!=null)
				{
					model.service_reply_email=row["service_reply_email"].ToString();
				}
				if(row["vacation"]!=null && row["vacation"].ToString()!="")
				{
					model.vacation=int.Parse(row["vacation"].ToString());
				}
				if(row["about_seller"]!=null)
				{
					model.about_seller=row["about_seller"].ToString();
				}
				if(row["shipping_rates"]!=null)
				{
					model.shipping_rates=row["shipping_rates"].ToString();
				}
				if(row["shipping_policies"]!=null)
				{
					model.shipping_policies=row["shipping_policies"].ToString();
				}
				if(row["FAQ"]!=null)
				{
					model.FAQ=row["FAQ"].ToString();
				}
				if(row["privacy_policy"]!=null)
				{
					model.privacy_policy=row["privacy_policy"].ToString();
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
			strSql.Append("select user_id,shop_name,shop_level,shop_intro,shop_logo,shop_link,service_email,service_phone,service_reply_email,vacation,about_seller,shipping_rates,shipping_policies,FAQ,privacy_policy ");
			strSql.Append(" FROM tb_virtual_shop ");
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
			strSql.Append(" user_id,shop_name,shop_level,shop_intro,shop_logo,shop_link,service_email,service_phone,service_reply_email,vacation,about_seller,shipping_rates,shipping_policies,FAQ,privacy_policy ");
			strSql.Append(" FROM tb_virtual_shop ");
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
			strSql.Append("select count(1) FROM tb_virtual_shop ");
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
			strSql.Append(")AS Row, T.*  from tb_virtual_shop T ");
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
			parameters[0].Value = "tb_virtual_shop";
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

