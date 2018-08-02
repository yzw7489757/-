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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using QGYHelper.DataBase;//Please add references
namespace QAMZN.DAL
{
	/// <summary>
	/// 数据访问类:tb_user_shippingsettings
	/// </summary>
	public partial class tb_user_shippingsettings
	{
		public tb_user_shippingsettings()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("user_id", "tb_user_shippingsettings"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int user_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_user_shippingsettings");
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
		public int Add(QAMZN.Model.tb_user_shippingsettings model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_user_shippingsettings(");
			strSql.Append("createtime,address_id,standard_one,standard_two,expedited_one,expedited_two,twoday,oneday,international,expedited)");
			strSql.Append(" values (");
			strSql.Append("@createtime,@address_id,@standard_one,@standard_two,@expedited_one,@expedited_two,@twoday,@oneday,@international,@expedited)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@address_id", SqlDbType.Int,4),
					new SqlParameter("@standard_one", SqlDbType.Int,4),
					new SqlParameter("@standard_two", SqlDbType.Int,4),
					new SqlParameter("@expedited_one", SqlDbType.Int,4),
					new SqlParameter("@expedited_two", SqlDbType.Int,4),
					new SqlParameter("@twoday", SqlDbType.Int,4),
					new SqlParameter("@oneday", SqlDbType.Int,4),
					new SqlParameter("@international", SqlDbType.Int,4),
					new SqlParameter("@expedited", SqlDbType.Int,4)};
			parameters[0].Value = model.createtime;
			parameters[1].Value = model.address_id;
			parameters[2].Value = model.standard_one;
			parameters[3].Value = model.standard_two;
			parameters[4].Value = model.expedited_one;
			parameters[5].Value = model.expedited_two;
			parameters[6].Value = model.twoday;
			parameters[7].Value = model.oneday;
			parameters[8].Value = model.international;
			parameters[9].Value = model.expedited;

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
        /// <returns></returns>
        public int AddShipping(int userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_user_shippingsettings(");
            strSql.Append("user_id,createtime,address_id,standard_one,standard_two,expedited_one,expedited_two,twoday,oneday,international,expedited)");
            strSql.Append(" values (");
            strSql.Append("@user_id,@createtime,@address_id,@standard_one,@standard_two,@expedited_one,@expedited_two,@twoday,@oneday,@international,@expedited)");
            SqlParameter[] parameters = {
                    new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime,50),
					new SqlParameter("@address_id", SqlDbType.Int,4),
					new SqlParameter("@standard_one", SqlDbType.Int,4),
					new SqlParameter("@standard_two", SqlDbType.Int,4),
					new SqlParameter("@expedited_one", SqlDbType.Int,4),
					new SqlParameter("@expedited_two", SqlDbType.Int,4),
					new SqlParameter("@twoday", SqlDbType.Int,4),
					new SqlParameter("@oneday", SqlDbType.Int,4),
					new SqlParameter("@international", SqlDbType.Int,4),
					new SqlParameter("@expedited", SqlDbType.Int,4)
                                        };
            parameters[0].Value = userID;
            parameters[1].Value = DateTime.Now.ToString("yyyy-MM-dd");
            parameters[2].Value = 0;
            parameters[3].Value = 17;
            parameters[4].Value = 3;
            parameters[5].Value = 2;
            parameters[6].Value = 1;
            parameters[7].Value = 2;
            parameters[8].Value = 1;
            parameters[9].Value = 0;
            parameters[10].Value = 0;

            int obj = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 更新配送信息详情
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="standard_one">标准（17-28工作日）</param>
        /// <param name="standard_two">标准（3-5工作日）</param>
        /// <param name="expedited_one">快速配送（2-6工作日）</param>
        /// <param name="expedited_two">快速配送（1-3工作日）</param>
        /// <param name="twoday">两日送达</param>
        /// <param name="oneday">一日送达</param>
        /// <param name="international">国际配送</param>
        /// <param name="expedited">国际加急</param>
        /// <returns></returns>
        public bool UpdateShippingSetting(int userid, int standard_one, int standard_two, int expedited_one, int expedited_two, int twoday, int oneday, int international, int expedited)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user_shippingsettings set ");
            strSql.Append("standard_one=@standard_one,");
            strSql.Append("standard_two=@standard_two,");
            strSql.Append("expedited_one=@expedited_one,");
            strSql.Append("expedited_two=@expedited_two,");
            strSql.Append("twoday=@twoday,");
            strSql.Append("oneday=@oneday,");
            strSql.Append("international=@international,");
            strSql.Append("expedited=@expedited");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@standard_one", SqlDbType.Int,4),
					new SqlParameter("@standard_two", SqlDbType.Int,4),
					new SqlParameter("@expedited_one", SqlDbType.Int,4),
					new SqlParameter("@expedited_two", SqlDbType.Int,4),
					new SqlParameter("@twoday", SqlDbType.Int,4),
					new SqlParameter("@oneday", SqlDbType.Int,4),
					new SqlParameter("@international", SqlDbType.Int,4),
					new SqlParameter("@expedited", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[2].Value = standard_one;
            parameters[3].Value = standard_two;
            parameters[4].Value = expedited_one;
            parameters[5].Value = expedited_two;
            parameters[6].Value = twoday;
            parameters[7].Value = oneday;
            parameters[8].Value = international;
            parameters[9].Value = expedited;
            parameters[10].Value = userid;

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
		public bool Update(QAMZN.Model.tb_user_shippingsettings model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_user_shippingsettings set ");
			strSql.Append("createtime=@createtime,");
			strSql.Append("address_id=@address_id,");
			strSql.Append("standard_one=@standard_one,");
			strSql.Append("standard_two=@standard_two,");
			strSql.Append("expedited_one=@expedited_one,");
			strSql.Append("expedited_two=@expedited_two,");
			strSql.Append("twoday=@twoday,");
			strSql.Append("oneday=@oneday,");
			strSql.Append("international=@international,");
			strSql.Append("expedited=@expedited");
			strSql.Append(" where user_id=@user_id");
			SqlParameter[] parameters = {
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@address_id", SqlDbType.Int,4),
					new SqlParameter("@standard_one", SqlDbType.Int,4),
					new SqlParameter("@standard_two", SqlDbType.Int,4),
					new SqlParameter("@expedited_one", SqlDbType.Int,4),
					new SqlParameter("@expedited_two", SqlDbType.Int,4),
					new SqlParameter("@twoday", SqlDbType.Int,4),
					new SqlParameter("@oneday", SqlDbType.Int,4),
					new SqlParameter("@international", SqlDbType.Int,4),
					new SqlParameter("@expedited", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
			parameters[0].Value = model.createtime;
			parameters[1].Value = model.address_id;
			parameters[2].Value = model.standard_one;
			parameters[3].Value = model.standard_two;
			parameters[4].Value = model.expedited_one;
			parameters[5].Value = model.expedited_two;
			parameters[6].Value = model.twoday;
			parameters[7].Value = model.oneday;
			parameters[8].Value = model.international;
			parameters[9].Value = model.expedited;
			parameters[10].Value = model.user_id;

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
        /// 更新默认地址
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SetAddressDefault(QAMZN.Model.tb_user_shippingsettings model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_user_shippingsettings set ");
			strSql.Append("address_id=@address_id");
			strSql.Append(" where user_id=@user_id");
			SqlParameter[] parameters = {
					new SqlParameter("@address_id", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
			parameters[0].Value = model.address_id;
			parameters[1].Value = model.user_id;

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
			strSql.Append("delete from tb_user_shippingsettings ");
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
			strSql.Append("delete from tb_user_shippingsettings ");
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
		public QAMZN.Model.tb_user_shippingsettings GetModel(int user_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 user_id,createtime,address_id,standard_one,standard_two,expedited_one,expedited_two,twoday,oneday,international,expedited from tb_user_shippingsettings ");
			strSql.Append(" where user_id=@user_id");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)
			};
			parameters[0].Value = user_id;

			QAMZN.Model.tb_user_shippingsettings model=new QAMZN.Model.tb_user_shippingsettings();
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
		public QAMZN.Model.tb_user_shippingsettings DataRowToModel(DataRow row)
		{
			QAMZN.Model.tb_user_shippingsettings model=new QAMZN.Model.tb_user_shippingsettings();
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
				if(row["address_id"]!=null && row["address_id"].ToString()!="")
				{
					model.address_id=int.Parse(row["address_id"].ToString());
				}
				if(row["standard_one"]!=null && row["standard_one"].ToString()!="")
				{
					model.standard_one=int.Parse(row["standard_one"].ToString());
				}
				if(row["standard_two"]!=null && row["standard_two"].ToString()!="")
				{
					model.standard_two=int.Parse(row["standard_two"].ToString());
				}
				if(row["expedited_one"]!=null && row["expedited_one"].ToString()!="")
				{
					model.expedited_one=int.Parse(row["expedited_one"].ToString());
				}
				if(row["expedited_two"]!=null && row["expedited_two"].ToString()!="")
				{
					model.expedited_two=int.Parse(row["expedited_two"].ToString());
				}
				if(row["twoday"]!=null && row["twoday"].ToString()!="")
				{
					model.twoday=int.Parse(row["twoday"].ToString());
				}
				if(row["oneday"]!=null && row["oneday"].ToString()!="")
				{
					model.oneday=int.Parse(row["oneday"].ToString());
				}
				if(row["international"]!=null && row["international"].ToString()!="")
				{
					model.international=int.Parse(row["international"].ToString());
				}
				if(row["expedited"]!=null && row["expedited"].ToString()!="")
				{
					model.expedited=int.Parse(row["expedited"].ToString());
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
			strSql.Append("select user_id,createtime,address_id,standard_one,standard_two,expedited_one,expedited_two,twoday,oneday,international,expedited ");
			strSql.Append(" FROM tb_user_shippingsettings ");
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
			strSql.Append(" user_id,createtime,address_id,standard_one,standard_two,expedited_one,expedited_two,twoday,oneday,international,expedited ");
			strSql.Append(" FROM tb_user_shippingsettings ");
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
			strSql.Append("select count(1) FROM tb_user_shippingsettings ");
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
			strSql.Append(")AS Row, T.*  from tb_user_shippingsettings T ");
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
			parameters[0].Value = "tb_user_shippingsettings";
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

