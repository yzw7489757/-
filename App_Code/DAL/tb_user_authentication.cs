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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using QGYHelper.DataBase; //Please add references
namespace QAMZN.DAL
{
	/// <summary>
	/// 数据访问类:tb_user_authentication
	/// </summary>
	public partial class tb_user_authentication
	{
		public tb_user_authentication()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("user_id", "tb_user_authentication"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int user_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_user_authentication");
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
		public int Add(QAMZN.Model.tb_user_authentication model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_user_authentication(");
			strSql.Append("country,identity,identity_file,remark,statement_type,statement_file,email,telephone,is_submit,state,createtime,submittime,statetime,reason)");
			strSql.Append(" values (");
			strSql.Append("@country,@identity,@identity_file,@remark,@statement_type,@statement_file,@email,@telephone,@is_submit,@state,@createtime,@submittime,@statetime,@reason)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@country", SqlDbType.VarChar,100),
					new SqlParameter("@identity", SqlDbType.Int,4),
					new SqlParameter("@identity_file", SqlDbType.VarChar,200),
					new SqlParameter("@remark", SqlDbType.VarChar,200),
					new SqlParameter("@statement_type", SqlDbType.Int,4),
					new SqlParameter("@statement_file", SqlDbType.VarChar,200),
					new SqlParameter("@email", SqlDbType.VarChar,200),
					new SqlParameter("@telephone", SqlDbType.VarChar,20),
					new SqlParameter("@is_submit", SqlDbType.Int,4),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@submittime", SqlDbType.DateTime),
					new SqlParameter("@statetime", SqlDbType.DateTime),
					new SqlParameter("@reason", SqlDbType.VarChar,200)};
			parameters[0].Value = model.country;
			parameters[1].Value = model.identity;
			parameters[2].Value = model.identity_file;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.statement_type;
			parameters[5].Value = model.statement_file;
			parameters[6].Value = model.email;
			parameters[7].Value = model.telephone;
			parameters[8].Value = model.is_submit;
			parameters[9].Value = model.state;
			parameters[10].Value = model.createtime;
			parameters[11].Value = model.submittime;
			parameters[12].Value = model.statetime;
			parameters[13].Value = model.reason;

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

        /// <summary>
        /// 卖家身份验证（返回信息{result:1 成功 0 失败}）
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="country">所在国家</param>
        /// <param name="identity">用户类型（1 个人 2 公司）</param>
        /// <param name="identity_file">用户身份相关文件</param>
        /// <param name="doc_type">对账单类型（1信用卡2银行账户）</param>
        /// <param name="doc_file">对账单文件</param>
        /// <param name="email">电子邮件地址</param>
        /// <param name="phone">联系电话</param>
        /// <param name="sign">提交方式（1 保存草稿 2 提交审核）</param>
        public int Add_authentication(int userid, string country, int identity, string identity_file, int doc_type, string doc_file, string email, string phone, int sign)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_user_authentication(");
            strSql.Append("user_id,country,[identity],identity_file,statement_type,statement_file,email,telephone,is_submit,createtime)");
			strSql.Append(" values (");
            strSql.Append("@user_id,@country,@identity,@identity_file,@statement_type,@statement_file,@email,@telephone,@is_submit,@createtime)");
			strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@country", SqlDbType.VarChar,100),
					new SqlParameter("@identity", SqlDbType.Int,4),
					new SqlParameter("@identity_file", SqlDbType.VarChar,200),
					new SqlParameter("@statement_type", SqlDbType.Int,4),
					new SqlParameter("@statement_file", SqlDbType.VarChar,200),
					new SqlParameter("@email", SqlDbType.VarChar,200),
					new SqlParameter("@telephone", SqlDbType.VarChar,20),
					new SqlParameter("@is_submit", SqlDbType.Int,4),
                    new SqlParameter("@createtime", SqlDbType.DateTime,50),
					                    };
            parameters[0].Value = userid;
            parameters[1].Value = country;
            parameters[2].Value = identity;
            parameters[3].Value = identity_file;
            parameters[4].Value = doc_type;
            parameters[5].Value = doc_file;
            parameters[6].Value = email;
            parameters[7].Value = phone;
            parameters[8].Value = sign;
            parameters[9].Value = DateTime.Now;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
			{
				return 1;
			}
			else
			{
                return 0;
			}
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(QAMZN.Model.tb_user_authentication model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_user_authentication set ");
			strSql.Append("country=@country,");
			strSql.Append("identity=@identity,");
			strSql.Append("identity_file=@identity_file,");
			strSql.Append("remark=@remark,");
			strSql.Append("statement_type=@statement_type,");
			strSql.Append("statement_file=@statement_file,");
			strSql.Append("email=@email,");
			strSql.Append("telephone=@telephone,");
			strSql.Append("is_submit=@is_submit,");
			strSql.Append("state=@state,");
			strSql.Append("createtime=@createtime,");
			strSql.Append("submittime=@submittime,");
			strSql.Append("statetime=@statetime,");
			strSql.Append("reason=@reason");
			strSql.Append(" where user_id=@user_id");
			SqlParameter[] parameters = {
					new SqlParameter("@country", SqlDbType.VarChar,100),
					new SqlParameter("@identity", SqlDbType.Int,4),
					new SqlParameter("@identity_file", SqlDbType.VarChar,200),
					new SqlParameter("@remark", SqlDbType.VarChar,200),
					new SqlParameter("@statement_type", SqlDbType.Int,4),
					new SqlParameter("@statement_file", SqlDbType.VarChar,200),
					new SqlParameter("@email", SqlDbType.VarChar,200),
					new SqlParameter("@telephone", SqlDbType.VarChar,20),
					new SqlParameter("@is_submit", SqlDbType.Int,4),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@submittime", SqlDbType.DateTime),
					new SqlParameter("@statetime", SqlDbType.DateTime),
					new SqlParameter("@reason", SqlDbType.VarChar,200),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
			parameters[0].Value = model.country;
			parameters[1].Value = model.identity;
			parameters[2].Value = model.identity_file;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.statement_type;
			parameters[5].Value = model.statement_file;
			parameters[6].Value = model.email;
			parameters[7].Value = model.telephone;
			parameters[8].Value = model.is_submit;
			parameters[9].Value = model.state;
			parameters[10].Value = model.createtime;
			parameters[11].Value = model.submittime;
			parameters[12].Value = model.statetime;
			parameters[13].Value = model.reason;
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

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int user_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_user_authentication ");
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
			strSql.Append("delete from tb_user_authentication ");
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
		public QAMZN.Model.tb_user_authentication GetModel(int user_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 user_id,country,identity,identity_file,remark,statement_type,statement_file,email,telephone,is_submit,state,createtime,submittime,statetime,reason from tb_user_authentication ");
			strSql.Append(" where user_id=@user_id");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)
			};
			parameters[0].Value = user_id;

			QAMZN.Model.tb_user_authentication model=new QAMZN.Model.tb_user_authentication();
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
		public QAMZN.Model.tb_user_authentication DataRowToModel(DataRow row)
		{
			QAMZN.Model.tb_user_authentication model=new QAMZN.Model.tb_user_authentication();
			if (row != null)
			{
				if(row["user_id"]!=null && row["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(row["user_id"].ToString());
				}
				if(row["country"]!=null)
				{
					model.country=row["country"].ToString();
				}
				if(row["identity"]!=null && row["identity"].ToString()!="")
				{
					model.identity=int.Parse(row["identity"].ToString());
				}
				if(row["identity_file"]!=null)
				{
					model.identity_file=row["identity_file"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["statement_type"]!=null && row["statement_type"].ToString()!="")
				{
					model.statement_type=int.Parse(row["statement_type"].ToString());
				}
				if(row["statement_file"]!=null)
				{
					model.statement_file=row["statement_file"].ToString();
				}
				if(row["email"]!=null)
				{
					model.email=row["email"].ToString();
				}
				if(row["telephone"]!=null)
				{
					model.telephone=row["telephone"].ToString();
				}
				if(row["is_submit"]!=null && row["is_submit"].ToString()!="")
				{
					model.is_submit=int.Parse(row["is_submit"].ToString());
				}
				if(row["state"]!=null && row["state"].ToString()!="")
				{
					model.state=int.Parse(row["state"].ToString());
				}
				if(row["createtime"]!=null && row["createtime"].ToString()!="")
				{
					model.createtime=DateTime.Parse(row["createtime"].ToString());
				}
				if(row["submittime"]!=null && row["submittime"].ToString()!="")
				{
					model.submittime=DateTime.Parse(row["submittime"].ToString());
				}
				if(row["statetime"]!=null && row["statetime"].ToString()!="")
				{
					model.statetime=DateTime.Parse(row["statetime"].ToString());
				}
				if(row["reason"]!=null)
				{
					model.reason=row["reason"].ToString();
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
			strSql.Append("select user_id,country,identity,identity_file,remark,statement_type,statement_file,email,telephone,is_submit,state,createtime,submittime,statetime,reason ");
			strSql.Append(" FROM tb_user_authentication ");
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
			strSql.Append(" user_id,country,identity,identity_file,remark,statement_type,statement_file,email,telephone,is_submit,state,createtime,submittime,statetime,reason ");
			strSql.Append(" FROM tb_user_authentication ");
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
			strSql.Append("select count(1) FROM tb_user_authentication ");
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
			strSql.Append(")AS Row, T.*  from tb_user_authentication T ");
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
			parameters[0].Value = "tb_user_authentication";
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

