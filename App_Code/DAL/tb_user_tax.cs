/**  版本信息模板在安装目录下，可自行修改。
* tb_user_tax.cs
*
* 功 能： N/A
* 类 名： tb_user_tax
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/6 星期五 下午 3:49:06   N/A    初版
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
	/// 数据访问类:tb_user_tax
	/// </summary>
	public partial class tb_user_tax
	{
		public tb_user_tax()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("tax_id", "tb_user_tax"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int tax_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_user_tax");
			strSql.Append(" where tax_id=@tax_id");
			SqlParameter[] parameters = {
					new SqlParameter("@tax_id", SqlDbType.Int,4)
			};
			parameters[0].Value = tax_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        #region 增加一条用户税务信息
        /// <summary>
        /// 增加一条用户税务信息
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="receive_income">获得收益人（1 企业 2 业务）</param>
        /// <param name="is_usperson">是否美国人（1 是 0 否）</param>
        /// <param name="company_name">法定公司名称</param>
        /// <param name="nationality">国籍</param>
        /// <param name="owner_type">收益所有人类型（1 个人 2 独资经营者 3 单一成员有限责任公司）</param>
        /// <param name="address_id">永久地址ID</param>
        /// <param name="mailing_address_id">邮寄地址ID</param>
        /// <param name="is_esignature">是否为IRS提供电子签名（1 是 0 否）</param>
        /// <returns></returns>
        public int AddUser_tax(int userid, int receive_income, int is_usperson, string company_name, string nationality, int owner_type, int address_id, int mailing_address_id, int is_esignature)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_user_tax(");
            strSql.Append("receive_income,is_usperson,company_name,nationality,owner_type,address_id,mailing_address_id,is_esignature,user_id,createtime)");
            strSql.Append(" values (");
            strSql.Append("@receive_income,@is_usperson,@company_name,@nationality,@owner_type,@address_id,@mailing_address_id,@is_esignature,@user_id,@createtime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@receive_income", SqlDbType.Int,4),
					new SqlParameter("@is_usperson", SqlDbType.Int,4),
					new SqlParameter("@company_name", SqlDbType.VarChar,100),
					new SqlParameter("@nationality", SqlDbType.VarChar,100),
					new SqlParameter("@owner_type", SqlDbType.Int,4),
					new SqlParameter("@address_id", SqlDbType.Int,4),
					new SqlParameter("@mailing_address_id", SqlDbType.Int,4),
					new SqlParameter("@is_esignature", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime)};
            parameters[0].Value = receive_income;
            parameters[1].Value = is_usperson;
            parameters[2].Value = company_name;
            parameters[3].Value = nationality;
            parameters[4].Value = owner_type;
            parameters[5].Value = address_id;
            parameters[6].Value = mailing_address_id;
            parameters[7].Value = is_esignature;
            parameters[8].Value = userid;
            parameters[9].Value = DateTime.Now.ToString("yyyy-MM-dd");

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
        /// 更新一条数据
        /// </summary>
        public bool Updatetax(QAMZN.Model.tb_user_tax model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_user_tax set ");
			strSql.Append("receive_income=@receive_income,");
			strSql.Append("is_usperson=@is_usperson,");
			strSql.Append("company_name=@company_name,");
			strSql.Append("nationality=@nationality,");
			strSql.Append("owner_type=@owner_type,");
			strSql.Append("address_id=@address_id,");
			strSql.Append("mailing_address_id=@mailing_address_id,");
			strSql.Append("is_esignature=@is_esignature,");
			strSql.Append("user_id=@user_id,");
			strSql.Append("createtime=@createtime,");
            strSql.Append("signature=@signature");
			strSql.Append(" where tax_id=@tax_id");
			SqlParameter[] parameters = {
					new SqlParameter("@receive_income", SqlDbType.Int,4),
					new SqlParameter("@is_usperson", SqlDbType.Int,4),
					new SqlParameter("@company_name", SqlDbType.VarChar,100),
					new SqlParameter("@nationality", SqlDbType.VarChar,100),
					new SqlParameter("@owner_type", SqlDbType.Int,4),
					new SqlParameter("@address_id", SqlDbType.Int,4),
					new SqlParameter("@mailing_address_id", SqlDbType.Int,4),
					new SqlParameter("@is_esignature", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime),
                    new SqlParameter("@signature", SqlDbType.VarChar,100),
					new SqlParameter("@tax_id", SqlDbType.Int,4)};
			parameters[0].Value = model.receive_income;
			parameters[1].Value = model.is_usperson;
			parameters[2].Value = model.company_name;
			parameters[3].Value = model.nationality;
			parameters[4].Value = model.owner_type;
			parameters[5].Value = model.address_id;
			parameters[6].Value = model.mailing_address_id;
			parameters[7].Value = model.is_esignature;
			parameters[8].Value = model.user_id;
			parameters[9].Value = DateTime.Now;
            parameters[10].Value = model.signature;
			parameters[11].Value = model.tax_id;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(QAMZN.Model.tb_user_tax model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_user_tax set ");
			strSql.Append("receive_income=@receive_income,");
			strSql.Append("is_usperson=@is_usperson,");
			strSql.Append("company_name=@company_name,");
			strSql.Append("nationality=@nationality,");
			strSql.Append("owner_type=@owner_type,");
			strSql.Append("address_id=@address_id,");
			strSql.Append("mailing_address_id=@mailing_address_id,");
			strSql.Append("is_esignature=@is_esignature,");
			strSql.Append("user_id=@user_id,");
			strSql.Append("createtime=@createtime");
			strSql.Append(" where tax_id=@tax_id");
			SqlParameter[] parameters = {
					new SqlParameter("@receive_income", SqlDbType.Int,4),
					new SqlParameter("@is_usperson", SqlDbType.Int,4),
					new SqlParameter("@company_name", SqlDbType.VarChar,100),
					new SqlParameter("@nationality", SqlDbType.VarChar,100),
					new SqlParameter("@owner_type", SqlDbType.Int,4),
					new SqlParameter("@address_id", SqlDbType.Int,4),
					new SqlParameter("@mailing_address_id", SqlDbType.Int,4),
					new SqlParameter("@is_esignature", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@tax_id", SqlDbType.Int,4)};
			parameters[0].Value = model.receive_income;
			parameters[1].Value = model.is_usperson;
			parameters[2].Value = model.company_name;
			parameters[3].Value = model.nationality;
			parameters[4].Value = model.owner_type;
			parameters[5].Value = model.address_id;
			parameters[6].Value = model.mailing_address_id;
			parameters[7].Value = model.is_esignature;
			parameters[8].Value = model.user_id;
			parameters[9].Value = model.createtime;
			parameters[10].Value = model.tax_id;

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
		public bool Delete(int tax_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_user_tax ");
			strSql.Append(" where tax_id=@tax_id");
			SqlParameter[] parameters = {
					new SqlParameter("@tax_id", SqlDbType.Int,4)
			};
			parameters[0].Value = tax_id;

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
		public bool DeleteList(string tax_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_user_tax ");
			strSql.Append(" where tax_id in ("+tax_idlist + ")  ");
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
        public QAMZN.Model.tb_user_tax GetTaxInfo(int userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 tax_id,receive_income,is_usperson,company_name,nationality,owner_type,address_id,mailing_address_id,is_esignature,user_id,createtime from tb_user_tax ");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)
			};
            parameters[0].Value = userid;

            QAMZN.Model.tb_user_tax model = new QAMZN.Model.tb_user_tax();
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

        /// <summary>
        /// 获取地址编号和法定公司名称
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public QAMZN.Model.tb_user_tax GetUerTaxInfo(int userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 tax_id,receive_income,is_usperson,company_name,nationality,owner_type,address_id,mailing_address_id,is_esignature,user_id,createtime from tb_user_tax ");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)
			};
            parameters[0].Value = userid;

            QAMZN.Model.tb_user_tax model = new QAMZN.Model.tb_user_tax();
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

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public QAMZN.Model.tb_user_tax GetModel(int tax_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 tax_id,receive_income,is_usperson,company_name,nationality,owner_type,address_id,mailing_address_id,is_esignature,user_id,createtime from tb_user_tax ");
			strSql.Append(" where tax_id=@tax_id");
			SqlParameter[] parameters = {
					new SqlParameter("@tax_id", SqlDbType.Int,4)
			};
			parameters[0].Value = tax_id;

			QAMZN.Model.tb_user_tax model=new QAMZN.Model.tb_user_tax();
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
		public QAMZN.Model.tb_user_tax DataRowToModel(DataRow row)
		{
			QAMZN.Model.tb_user_tax model=new QAMZN.Model.tb_user_tax();
			if (row != null)
			{
				if(row["tax_id"]!=null && row["tax_id"].ToString()!="")
				{
					model.tax_id=int.Parse(row["tax_id"].ToString());
				}
				if(row["receive_income"]!=null && row["receive_income"].ToString()!="")
				{
					model.receive_income=int.Parse(row["receive_income"].ToString());
				}
				if(row["is_usperson"]!=null && row["is_usperson"].ToString()!="")
				{
					model.is_usperson=int.Parse(row["is_usperson"].ToString());
				}
				if(row["company_name"]!=null)
				{
					model.company_name=row["company_name"].ToString();
				}
				if(row["nationality"]!=null)
				{
					model.nationality=row["nationality"].ToString();
				}
				if(row["owner_type"]!=null && row["owner_type"].ToString()!="")
				{
					model.owner_type=int.Parse(row["owner_type"].ToString());
				}
				if(row["address_id"]!=null && row["address_id"].ToString()!="")
				{
					model.address_id=int.Parse(row["address_id"].ToString());
				}
				if(row["mailing_address_id"]!=null && row["mailing_address_id"].ToString()!="")
				{
					model.mailing_address_id=int.Parse(row["mailing_address_id"].ToString());
				}
				if(row["is_esignature"]!=null && row["is_esignature"].ToString()!="")
				{
					model.is_esignature=int.Parse(row["is_esignature"].ToString());
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
			strSql.Append("select tax_id,receive_income,is_usperson,company_name,nationality,owner_type,address_id,mailing_address_id,is_esignature,user_id,createtime ");
			strSql.Append(" FROM tb_user_tax ");
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
			strSql.Append(" tax_id,receive_income,is_usperson,company_name,nationality,owner_type,address_id,mailing_address_id,is_esignature,user_id,createtime ");
			strSql.Append(" FROM tb_user_tax ");
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
			strSql.Append("select count(1) FROM tb_user_tax ");
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
				strSql.Append("order by T.tax_id desc");
			}
			strSql.Append(")AS Row, T.*  from tb_user_tax T ");
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
			parameters[0].Value = "tb_user_tax";
			parameters[1].Value = "tax_id";
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

