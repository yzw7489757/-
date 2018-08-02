/**  版本信息模板在安装目录下，可自行修改。
* tb_user_returnsettings.cs
*
* 功 能： N/A
* 类 名： tb_user_returnsettings
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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using QGYHelper.DataBase;//Please add references
namespace QAMZN.DAL
{
	/// <summary>
	/// 数据访问类:tb_user_returnsettings
	/// </summary>
	public partial class tb_user_returnsettings
	{
		public tb_user_returnsettings()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("user_id", "tb_user_returnsettings"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int user_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_user_returnsettings");
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
		public int Add(QAMZN.Model.tb_user_returnsettings model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_user_returnsettings(");
			strSql.Append("createtime,email_format,return_rule,return_window,setting_number,address_id)");
			strSql.Append(" values (");
			strSql.Append("@createtime,@email_format,@return_rule,@return_window,@setting_number,@address_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@email_format", SqlDbType.Int,4),
					new SqlParameter("@return_rule", SqlDbType.Int,4),
					new SqlParameter("@return_window", SqlDbType.Int,4),
					new SqlParameter("@setting_number", SqlDbType.Int,4),
					new SqlParameter("@address_id", SqlDbType.Int,4)};
			parameters[0].Value = model.createtime;
			parameters[1].Value = model.email_format;
			parameters[2].Value = model.return_rule;
			parameters[3].Value = model.return_window;
			parameters[4].Value = model.setting_number;
			parameters[5].Value = model.address_id;

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

        #region 增加数据
        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="userID">用户编号</param>
        /// <returns></returns>
        public bool AddReturn(int userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_user_returnsettings(");
            strSql.Append("user_id,createtime,email_format,return_rule,return_window,setting_number,address_id)");
            strSql.Append(" values (");
            strSql.Append("@user_id,@createtime,@email_format,@return_rule,@return_window,@setting_number,@address_id)");
            SqlParameter[] parameters = {
                    new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@email_format", SqlDbType.Int,4),
					new SqlParameter("@return_rule", SqlDbType.Int,4),
					new SqlParameter("@return_window", SqlDbType.Int,4),
					new SqlParameter("@setting_number", SqlDbType.Int,4),
					new SqlParameter("@address_id", SqlDbType.Int,4)};
            parameters[0].Value = userID;
            parameters[1].Value = DateTime.Now;
            parameters[2].Value = 1;
            parameters[3].Value = 1;
            parameters[5].Value = 0;
            parameters[5].Value = 1;
            parameters[6].Value = 0;

            int obj = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (obj > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 常规设置（更新常规设置）
        /// <summary>
        /// 常规设置（更新常规设置）
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public bool UpdateInfo(QAMZN.Model.tb_user_returnsettings model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user_returnsettings set ");
            strSql.Append("createtime=@createtime,");
            strSql.Append("email_format=@email_format,");
            strSql.Append("return_rule=@return_rule,");
            strSql.Append("return_window=@return_window,");
            strSql.Append("setting_number=@setting_number ");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@email_format", SqlDbType.Int,4),
					new SqlParameter("@return_rule", SqlDbType.Int,4),
					new SqlParameter("@return_window", SqlDbType.Int,4),
					new SqlParameter("@setting_number", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = DateTime.Now;
            parameters[1].Value = model.email_format;
            parameters[2].Value = model.return_rule;
            parameters[3].Value = model.return_window;
            parameters[4].Value = model.setting_number;
            parameters[5].Value = model.user_id;

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

        #region 常规设置(设置默认地址）
        /// <summary>
        /// 常规设置(设置默认地址）
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public bool Update(QAMZN.Model.tb_user_returnsettings model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user_returnsettings set ");
            strSql.Append("createtime=@createtime,");
            strSql.Append("address_id=@address_id");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@address_id", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = model.createtime; ;
            parameters[1].Value = model.address_id;
            parameters[2].Value = model.user_id;

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
			strSql.Append("delete from tb_user_returnsettings ");
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
			strSql.Append("delete from tb_user_returnsettings ");
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
		public QAMZN.Model.tb_user_returnsettings GetModel(int user_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 user_id,createtime,email_format,return_rule,return_window,setting_number,address_id from tb_user_returnsettings ");
			strSql.Append(" where user_id=@user_id");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)
			};
			parameters[0].Value = user_id;

			QAMZN.Model.tb_user_returnsettings model=new QAMZN.Model.tb_user_returnsettings();
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
		public QAMZN.Model.tb_user_returnsettings DataRowToModel(DataRow row)
		{
			QAMZN.Model.tb_user_returnsettings model=new QAMZN.Model.tb_user_returnsettings();
			if (row != null)
			{
				if(row["user_id"]!=null && row["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(row["user_id"].ToString());
				}
				if(row["createtime"]!=null && row["createtime"].ToString()!="")
				{
					model.createtime=DateTime.Parse(row["createtime"].ToString());
				}
				if(row["email_format"]!=null && row["email_format"].ToString()!="")
				{
					model.email_format=int.Parse(row["email_format"].ToString());
				}
				if(row["return_rule"]!=null && row["return_rule"].ToString()!="")
				{
					model.return_rule=int.Parse(row["return_rule"].ToString());
				}
				if(row["return_window"]!=null && row["return_window"].ToString()!="")
				{
					model.return_window=int.Parse(row["return_window"].ToString());
				}
				if(row["setting_number"]!=null && row["setting_number"].ToString()!="")
				{
					model.setting_number=int.Parse(row["setting_number"].ToString());
				}
				if(row["address_id"]!=null && row["address_id"].ToString()!="")
				{
					model.address_id=int.Parse(row["address_id"].ToString());
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
			strSql.Append("select user_id,createtime,email_format,return_rule,return_window,setting_number,address_id ");
			strSql.Append(" FROM tb_user_returnsettings ");
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
			strSql.Append(" user_id,createtime,email_format,return_rule,return_window,setting_number,address_id ");
			strSql.Append(" FROM tb_user_returnsettings ");
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
			strSql.Append("select count(1) FROM tb_user_returnsettings ");
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
			strSql.Append(")AS Row, T.*  from tb_user_returnsettings T ");
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
			parameters[0].Value = "tb_user_returnsettings";
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

