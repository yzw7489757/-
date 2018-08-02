using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using QGYHelper.DataBase;//Please add references
namespace QAMZN.DAL
{
    /// <summary>
    /// 数据访问类:tb_user_contacts
    /// </summary>
    public partial class tb_user_contacts
    {
        public tb_user_contacts()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int contact_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_user_contacts");
            strSql.Append(" where contact_id=@contact_id");
            SqlParameter[] parameters = {
					new SqlParameter("@contact_id", SqlDbType.Int,4)
			};
            parameters[0].Value = contact_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(QAMZN.Model.tb_user_contacts model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_user_contacts(");
            strSql.Append("name,email,phone,sms_mode,start_hour,end_hour,timezone,user_id,createtime)");
            strSql.Append(" values (");
            strSql.Append("@name,@email,@phone,@sms_mode,@start_hour,@end_hour,@timezone,@user_id,@createtime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@email", SqlDbType.VarChar,200),
					new SqlParameter("@phone", SqlDbType.VarChar,50),
					new SqlParameter("@sms_mode", SqlDbType.Int,4),
					new SqlParameter("@start_hour", SqlDbType.DateTime),
					new SqlParameter("@end_hour", SqlDbType.DateTime),
					new SqlParameter("@timezone", SqlDbType.VarChar,50),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.email;
            parameters[2].Value = model.phone;
            parameters[3].Value = model.sms_mode;
            parameters[4].Value = model.start_hour;
            parameters[5].Value = model.end_hour;
            parameters[6].Value = model.timezone;
            parameters[7].Value = model.user_id;
            parameters[8].Value = model.createtime;

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


        /// <summary>
        /// 初始化表数据（用户编号，名称，登录邮箱）
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="name">名称</param>
        /// <param name="email">登录邮箱</param>
        /// <returns></returns>
        public int AddUserContacts(int userid, string name, string email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_user_contacts(");
            strSql.Append("name,email,user_id,createtime)");
            strSql.Append(" values (");
            strSql.Append("@name,@email,@user_id,@createtime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@email", SqlDbType.VarChar,200),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime)};
            parameters[0].Value = name;
            parameters[1].Value = email;
            parameters[2].Value = userid;
            parameters[3].Value = DateTime.Now;

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

        


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(QAMZN.Model.tb_user_contacts model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user_contacts set ");
            strSql.Append("name=@name,");
            strSql.Append("email=@email,");
            strSql.Append("phone=@phone,");
            strSql.Append("sms_mode=@sms_mode,");
            strSql.Append("start_hour=@start_hour,");
            strSql.Append("end_hour=@end_hour,");
            strSql.Append("timezone=@timezone");
            strSql.Append(" where contact_id=@contact_id");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@email", SqlDbType.VarChar,200),
					new SqlParameter("@phone", SqlDbType.VarChar,50),
					new SqlParameter("@sms_mode", SqlDbType.Int,4),
					new SqlParameter("@start_hour", SqlDbType.DateTime),
					new SqlParameter("@end_hour", SqlDbType.DateTime),
					new SqlParameter("@timezone", SqlDbType.VarChar,50),
					new SqlParameter("@contact_id", SqlDbType.Int,4)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.email;
            parameters[2].Value = model.phone;
            parameters[3].Value = model.sms_mode;
            parameters[4].Value = model.start_hour;
            parameters[5].Value = model.end_hour;
            parameters[6].Value = model.timezone;
            parameters[7].Value = model.contact_id;
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int contact_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_user_contacts ");
            strSql.Append(" where contact_id=@contact_id");
            SqlParameter[] parameters = {
					new SqlParameter("@contact_id", SqlDbType.Int,4)
			};
            parameters[0].Value = contact_id;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string contact_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_user_contacts ");
            strSql.Append(" where contact_id in (" + contact_idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public QAMZN.Model.tb_user_contacts GetModel1(int userid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 contact_id,name,email,phone,sms_mode,start_hour,end_hour,timezone,user_id,createtime from tb_user_contacts ");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)
			};
            parameters[0].Value = userid;

            QAMZN.Model.tb_user_contacts model = new QAMZN.Model.tb_user_contacts();
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
        public QAMZN.Model.tb_user_contacts GetModel(int contact_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 contact_id,name,email,phone,sms_mode,start_hour,end_hour,timezone,user_id,createtime from tb_user_contacts ");
            strSql.Append(" where contact_id=@contact_id");
            SqlParameter[] parameters = {
					new SqlParameter("@contact_id", SqlDbType.Int,4)
			};
            parameters[0].Value = contact_id;

            QAMZN.Model.tb_user_contacts model = new QAMZN.Model.tb_user_contacts();
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
        public QAMZN.Model.tb_user_contacts DataRowToModel(DataRow row)
        {
            QAMZN.Model.tb_user_contacts model = new QAMZN.Model.tb_user_contacts();
            if (row != null)
            {
                if (row["contact_id"] != null && row["contact_id"].ToString() != "")
                {
                    model.contact_id = int.Parse(row["contact_id"].ToString());
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["email"] != null)
                {
                    model.email = row["email"].ToString();
                }
                if (row["phone"] != null)
                {
                    model.phone = row["phone"].ToString();
                }
                if (row["sms_mode"] != null && row["sms_mode"].ToString() != "")
                {
                    model.sms_mode = int.Parse(row["sms_mode"].ToString());
                }
                if (row["start_hour"] != null && row["start_hour"].ToString() != "")
                {
                    model.start_hour = DateTime.Parse(row["start_hour"].ToString());
                }
                if (row["end_hour"] != null && row["end_hour"].ToString() != "")
                {
                    model.end_hour = DateTime.Parse(row["end_hour"].ToString());
                }
                if (row["timezone"] != null)
                {
                    model.timezone = row["timezone"].ToString();
                }
                if (row["user_id"] != null && row["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(row["user_id"].ToString());
                }
                if (row["createtime"] != null && row["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(row["createtime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select contact_id,name,email,phone,sms_mode,start_hour,end_hour,timezone,user_id,createtime ");
            strSql.Append(" FROM tb_user_contacts ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" contact_id,name,email,phone,sms_mode,start_hour,end_hour,timezone,user_id,createtime ");
            strSql.Append(" FROM tb_user_contacts ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tb_user_contacts ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.contact_id desc");
            }
            strSql.Append(")AS Row, T.*  from tb_user_contacts T ");
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
            parameters[0].Value = "tb_user_contacts";
            parameters[1].Value = "contact_id";
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

