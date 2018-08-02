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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using QGYHelper.DataBase;//Please add references
namespace QAMZN.DAL
{
	/// <summary>
	/// 数据访问类:tb_user_chargemethods
	/// </summary>
	public partial class tb_user_chargemethods
	{
		public tb_user_chargemethods()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("method_id", "tb_user_chargemethods"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int method_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_user_chargemethods");
			strSql.Append(" where method_id=@method_id");
			SqlParameter[] parameters = {
					new SqlParameter("@method_id", SqlDbType.Int,4)
			};
			parameters[0].Value = method_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(QAMZN.Model.tb_user_chargemethods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_user_chargemethods(");
			strSql.Append("card_number,valid_through_month,valid_through_year,card_holder_name,billing_address_id,user_id,createtime)");
			strSql.Append(" values (");
			strSql.Append("@card_number,@valid_through_month,@valid_through_year,@card_holder_name,@billing_address_id,@user_id,@createtime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@card_number", SqlDbType.VarChar,50),
					new SqlParameter("@valid_through_month", SqlDbType.Int,4),
					new SqlParameter("@valid_through_year", SqlDbType.Int,4),
					new SqlParameter("@card_holder_name", SqlDbType.VarChar,50),
					new SqlParameter("@billing_address_id", SqlDbType.VarChar,200),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime)};
			parameters[0].Value = model.card_number;
			parameters[1].Value = model.valid_through_month;
			parameters[2].Value = model.valid_through_year;
			parameters[3].Value = model.card_holder_name;
			parameters[4].Value = model.billing_address_id;
			parameters[5].Value = model.user_id;
			parameters[6].Value = model.createtime;

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

        #region 新增信用卡
        /// <summary>
        /// 新增信用卡
        /// </summary>
        /// <param name="userid">用户信息</param>
        /// <param name="card_number">信用卡号</param>
        /// <param name="valid_through_month">有效期限（月）</param>
        /// <param name="valid_through_year">有效期限（年）</param>
        /// <param name="card_holder_name">持卡人姓名</param>
        /// <param name="billing_address_id">邮寄地址ID</param>
        public int AddChargeMethod(int userid, string card_number, int valid_through_month, int valid_through_year, string card_holder_name, int billing_address_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_user_chargemethods(");
            strSql.Append("card_number,valid_through_month,valid_through_year,card_holder_name,billing_address_id,user_id,createtime)");
            strSql.Append(" values (");
            strSql.Append("@card_number,@valid_through_month,@valid_through_year,@card_holder_name,@billing_address_id,@user_id,@createtime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@card_number", SqlDbType.VarChar,50),
					new SqlParameter("@valid_through_month", SqlDbType.Int,4),
					new SqlParameter("@valid_through_year", SqlDbType.Int,4),
					new SqlParameter("@card_holder_name", SqlDbType.VarChar,50),
					new SqlParameter("@billing_address_id", SqlDbType.VarChar,200),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime)};
            parameters[0].Value = card_number;
            parameters[1].Value = valid_through_month;
            parameters[2].Value = valid_through_year;
            parameters[3].Value = card_holder_name;
            parameters[4].Value = billing_address_id;
            parameters[5].Value = userid;
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


        /// <summary>
        /// 修改信用卡邮寄地址
        /// </summary>
        public bool UpdateChargeInfo(int method_id, int userid, string card_number, int valid_through_month, int valid_through_year, string card_holder_name, int billing_address_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user_chargemethods set ");
            strSql.Append("card_number=@card_number,");
            strSql.Append("valid_through_month=@valid_through_month,");
            strSql.Append("valid_through_year=@valid_through_year,");
            strSql.Append("card_holder_name=@card_holder_name,");
            strSql.Append("billing_address_id=@billing_address_id,");
            strSql.Append("user_id=@user_id,");
            strSql.Append("createtime=@createtime");
            strSql.Append(" where method_id=@method_id");
            SqlParameter[] parameters = {
					new SqlParameter("@card_number", SqlDbType.VarChar,50),
					new SqlParameter("@valid_through_month", SqlDbType.Int,4),
					new SqlParameter("@valid_through_year", SqlDbType.Int,4),
					new SqlParameter("@card_holder_name", SqlDbType.VarChar,50),
					new SqlParameter("@billing_address_id", SqlDbType.VarChar,200),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@method_id", SqlDbType.Int,4)};
            parameters[0].Value = card_number;
            parameters[1].Value = valid_through_month;
            parameters[2].Value = valid_through_year;
            parameters[3].Value = card_holder_name;
            parameters[4].Value = billing_address_id;
            parameters[5].Value = userid;
            parameters[6].Value = DateTime.Now; ;
            parameters[7].Value = method_id;

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
		public bool Update(QAMZN.Model.tb_user_chargemethods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_user_chargemethods set ");
			strSql.Append("card_number=@card_number,");
			strSql.Append("valid_through_month=@valid_through_month,");
			strSql.Append("valid_through_year=@valid_through_year,");
			strSql.Append("card_holder_name=@card_holder_name,");
			strSql.Append("billing_address_id=@billing_address_id,");
			strSql.Append("user_id=@user_id,");
			strSql.Append("createtime=@createtime");
			strSql.Append(" where method_id=@method_id");
			SqlParameter[] parameters = {
					new SqlParameter("@card_number", SqlDbType.VarChar,50),
					new SqlParameter("@valid_through_month", SqlDbType.Int,4),
					new SqlParameter("@valid_through_year", SqlDbType.Int,4),
					new SqlParameter("@card_holder_name", SqlDbType.VarChar,50),
					new SqlParameter("@billing_address_id", SqlDbType.VarChar,200),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@method_id", SqlDbType.Int,4)};
			parameters[0].Value = model.card_number;
			parameters[1].Value = model.valid_through_month;
			parameters[2].Value = model.valid_through_year;
			parameters[3].Value = model.card_holder_name;
			parameters[4].Value = model.billing_address_id;
			parameters[5].Value = model.user_id;
			parameters[6].Value = model.createtime;
			parameters[7].Value = model.method_id;

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
		public bool Delete(int method_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_user_chargemethods ");
			strSql.Append(" where method_id=@method_id");
			SqlParameter[] parameters = {
					new SqlParameter("@method_id", SqlDbType.Int,4)
			};
			parameters[0].Value = method_id;

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
		public bool DeleteList(string method_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_user_chargemethods ");
			strSql.Append(" where method_id in ("+method_idlist + ")  ");
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
		public QAMZN.Model.tb_user_chargemethods GetModel(int method_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 method_id,card_number,valid_through_month,valid_through_year,card_holder_name,billing_address_id,user_id,createtime from tb_user_chargemethods ");
			strSql.Append(" where method_id=@method_id");
			SqlParameter[] parameters = {
					new SqlParameter("@method_id", SqlDbType.Int,4)
			};
			parameters[0].Value = method_id;

			QAMZN.Model.tb_user_chargemethods model=new QAMZN.Model.tb_user_chargemethods();
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
		public QAMZN.Model.tb_user_chargemethods DataRowToModel(DataRow row)
		{
			QAMZN.Model.tb_user_chargemethods model=new QAMZN.Model.tb_user_chargemethods();
			if (row != null)
			{
				if(row["method_id"]!=null && row["method_id"].ToString()!="")
				{
					model.method_id=int.Parse(row["method_id"].ToString());
				}
				if(row["card_number"]!=null)
				{
					model.card_number=row["card_number"].ToString();
				}
				if(row["valid_through_month"]!=null && row["valid_through_month"].ToString()!="")
				{
					model.valid_through_month=int.Parse(row["valid_through_month"].ToString());
				}
				if(row["valid_through_year"]!=null && row["valid_through_year"].ToString()!="")
				{
					model.valid_through_year=int.Parse(row["valid_through_year"].ToString());
				}
				if(row["card_holder_name"]!=null)
				{
					model.card_holder_name=row["card_holder_name"].ToString();
				}
				if(row["billing_address_id"]!=null)
				{
					model.billing_address_id=row["billing_address_id"].ToString();
				}
				if(row["user_id"]!=null && row["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(row["user_id"].ToString());
				}
				if(row["createtime"]!=null && row["createtime"].ToString()!="")
				{
					model.createtime=DateTime.Parse(row["createtime"].ToString());
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
			strSql.Append("select method_id,card_number,valid_through_month,valid_through_year,card_holder_name,billing_address_id,user_id,createtime ");
			strSql.Append(" FROM tb_user_chargemethods ");
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
			strSql.Append(" method_id,card_number,valid_through_month,valid_through_year,card_holder_name,billing_address_id,user_id,createtime ");
			strSql.Append(" FROM tb_user_chargemethods ");
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
			strSql.Append("select count(1) FROM tb_user_chargemethods ");
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
				strSql.Append("order by T.method_id desc");
			}
			strSql.Append(")AS Row, T.*  from tb_user_chargemethods T ");
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
			parameters[0].Value = "tb_user_chargemethods";
			parameters[1].Value = "method_id";
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

