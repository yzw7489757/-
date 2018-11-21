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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using QGYHelper.DataBase;
namespace QAMZN.DAL
{
	/// <summary>
	/// 数据访问类:tb_users
	/// </summary>
	public partial class tb_users
	{
		public tb_users()
		{}
		#region  BasicMethod
        #region 得到最大
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("user_id", "tb_users");
        }
        #endregion

        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int user_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_users");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)
			};
            parameters[0].Value = user_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(QAMZN.Model.tb_users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_users(");
            strSql.Append("sell_plan,user_identity,name,email,password,paypwd,legal_name,business_address,registered_address,website,telephone,chargemethod,depositmethod,is_product_upc,is_product_brand,product_list,categories,category_name,step,createtime,selling_state,selling_time,token,is_prime)");
            strSql.Append(" values (");
            strSql.Append("@sell_plan,@user_identity,@name,@email,@password,@paypwd,@legal_name,@business_address,@registered_address,@website,@telephone,@chargemethod,@depositmethod,@is_product_upc,@is_product_brand,@product_list,@categories,@category_name,@step,@createtime,@selling_state,@selling_time,@token,@is_prime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sell_plan", SqlDbType.Int,4),
					new SqlParameter("@user_identity", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@password", SqlDbType.VarChar,50),
					new SqlParameter("@paypwd", SqlDbType.VarChar,50),
					new SqlParameter("@legal_name", SqlDbType.VarChar,200),
					new SqlParameter("@business_address", SqlDbType.Int,4),
					new SqlParameter("@registered_address", SqlDbType.Int,4),
					new SqlParameter("@website", SqlDbType.VarChar,500),
					new SqlParameter("@telephone", SqlDbType.VarChar,50),
					new SqlParameter("@chargemethod", SqlDbType.Int,4),
					new SqlParameter("@depositmethod", SqlDbType.Int,4),
					new SqlParameter("@is_product_upc", SqlDbType.Int,4),
					new SqlParameter("@is_product_brand", SqlDbType.Int,4),
					new SqlParameter("@product_list", SqlDbType.Int,4),
					new SqlParameter("@categories", SqlDbType.VarChar,2000),
					new SqlParameter("@category_name", SqlDbType.VarChar,50),
					new SqlParameter("@step", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@selling_state", SqlDbType.Int,4),
					new SqlParameter("@selling_time", SqlDbType.DateTime),
					new SqlParameter("@token", SqlDbType.VarChar,14),
					new SqlParameter("@is_prime", SqlDbType.Int,4)};
            parameters[0].Value = model.sell_plan;
            parameters[1].Value = model.user_identity;
            parameters[2].Value = model.name;
            parameters[3].Value = model.email;
            parameters[4].Value = model.password;
            parameters[5].Value = model.paypwd;
            parameters[6].Value = model.legal_name;
            parameters[7].Value = model.business_address;
            parameters[8].Value = model.registered_address;
            parameters[9].Value = model.website;
            parameters[10].Value = model.telephone;
            parameters[11].Value = model.chargemethod;
            parameters[12].Value = model.depositmethod;
            parameters[13].Value = model.is_product_upc;
            parameters[14].Value = model.is_product_brand;
            parameters[15].Value = model.product_list;
            parameters[16].Value = model.categories;
            parameters[17].Value = model.category_name;
            parameters[18].Value = model.step;
            parameters[19].Value = model.createtime;
            parameters[20].Value = model.selling_state;
            parameters[21].Value = model.selling_time;
            parameters[22].Value = model.token;
            parameters[23].Value = model.is_prime;

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

        #region 更新网站地址
        /// <summary>
        /// 更新网站地址
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="id">用户的办公地址ID、正式注册地址ID</param>
        /// <param name="website">网站地址</param>
        /// <returns></returns>
        public bool UpdateUserWebsite(int userid, int id, string website)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_users set ");
            strSql.Append("business_address=@business_address,");
            strSql.Append("registered_address=@registered_address,");
            strSql.Append("website=@website,");
            strSql.Append("step=@step");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@business_address", SqlDbType.Int,4),
					new SqlParameter("@registered_address", SqlDbType.Int,4),
					new SqlParameter("@website", SqlDbType.VarChar,500),
              		new SqlParameter("@step", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4)
                                        };
            parameters[0].Value = id;
            parameters[1].Value = id;
            parameters[2].Value = website;
            parameters[3].Value = 3;
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

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int user_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_users ");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)
			};
            parameters[0].Value = user_id;

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

        #region 批量删除数据
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string user_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_users ");
            strSql.Append(" where user_id in (" + user_idlist + ")  ");
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
        #endregion

        #region 初始化卖家协议（返回法人）
        /// <summary>
        /// 初始化卖家协议（返回法人）
        /// </summary>
        public QAMZN.Model.tb_users GetUserLegal_Name(int user_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 user_id,sell_plan,user_identity,name,email,password,paypwd,legal_name,business_address,registered_address,website,telephone,chargemethod,depositmethod,is_product_upc,is_product_brand,product_list,categories,category_name,step,createtime,selling_state,selling_time,token,is_prime,stu_id,stu_account,stu_training_mode from tb_users  ");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)
			};
            parameters[0].Value = user_id;

            QAMZN.Model.tb_users model = new QAMZN.Model.tb_users();
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

        #region 得到一个Email对象实体
        /// <summary>
        /// 得到一个Email对象实体
        /// </summary>
        /// <param name="account">邮箱</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public QAMZN.Model.tb_users GetModelEmail(string account)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 user_id,sell_plan,user_identity,name,email,password,paypwd,legal_name,business_address,registered_address,website,telephone,chargemethod,depositmethod,is_product_upc,is_product_brand,product_list,categories,category_name,step,createtime,selling_state,selling_time,token,is_prime,stu_id,stu_account,stu_training_mode from tb_users ");
            strSql.Append(" where email=@account");
            SqlParameter[] parameters = {
					new SqlParameter("@account", SqlDbType.NVarChar,50),
			};
            parameters[0].Value = account;
        
            QAMZN.Model.tb_users model = new QAMZN.Model.tb_users();
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

        #region 商户登录(得到一个Telephone对象实体)
        /// <summary>
        /// 商户登录(得到一个Telephone对象实体)
        /// </summary>
        /// <param name="account">s邮箱</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public QAMZN.Model.tb_users GetModelTelephone(string account)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 user_id,sell_plan,user_identity,name,email,password,paypwd,legal_name,business_address,registered_address,website,telephone,chargemethod,depositmethod,is_product_upc,is_product_brand,product_list,categories,category_name,step,createtime,selling_state,selling_time,token,is_prime,stu_id,stu_account,stu_training_mode from tb_users  ");
            strSql.Append(" where telephone=@account");
            SqlParameter[] parameters = {
					new SqlParameter("@account", SqlDbType.NVarChar,50),
			};
            parameters[0].Value = account;

            QAMZN.Model.tb_users model = new QAMZN.Model.tb_users();
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

        #region 通过邮箱获取用户信息
        /// <summary>
        /// 通过邮箱获取用户信息
        /// </summary>
        /// <param name="account">邮箱</param>
        /// <returns></returns>
        public QAMZN.Model.tb_users AdoptEmail(string account)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 token,email,stu_id,stu_training_mode from tb_users ");
            strSql.Append(" where email=@account");

            SqlParameter[] parameters = {
					new SqlParameter("@account", SqlDbType.NVarChar,50),
			};
            parameters[0].Value = account;

            QAMZN.Model.tb_users model = new QAMZN.Model.tb_users();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel1(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 通过手机号获取用户信息
        /// <summary>
        /// 通过手机号获取用户信息
        /// </summary>
        /// <param name="account">手机号</param>
        /// <returns></returns>
        public QAMZN.Model.tb_users AdoptTelephone(string account)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 token,email,stu_id,stu_training_mode from tb_users ");
            strSql.Append(" where telephone=@account");

            SqlParameter[] parameters = {
					new SqlParameter("@account", SqlDbType.NVarChar,50),
			};
            parameters[0].Value = account;

            QAMZN.Model.tb_users model = new QAMZN.Model.tb_users();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel1(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 根据token修改密码
        /// <summary>
        /// 根据token修改密码
        /// </summary>
        /// <param name="token">商家标识</param>
        /// <param name="pwd">用户密码</param>
        /// <returns></returns>
        public bool UpdatePwd(string token, string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_users set ");
            strSql.Append("password=@pwd ");
            strSql.Append("where token=@token");
            SqlParameter[] parameters = {
					new SqlParameter("@pwd", SqlDbType.NVarChar,50),
                    new SqlParameter("@token", SqlDbType.NVarChar,50),
                                        };
            parameters[0].Value = pwd;
            parameters[1].Value = token;

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

        #region  用户注册

        /// <summary>
        /// 通过邮箱获取用户信息
        /// </summary>
        /// <param name="account">邮箱</param>
        /// <returns></returns>
        public bool AdoptEmail2(string account)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 token,email from tb_users ");
            strSql.Append(" where email=@account");

            SqlParameter[] parameters = {
					new SqlParameter("@account", SqlDbType.NVarChar,50),
			};
            parameters[0].Value = account;

            QAMZN.Model.tb_users model = new QAMZN.Model.tb_users();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool AdoptEmail3(string account, int stuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 token,email from tb_users ");
            strSql.Append(" where email=@account or stu_id=@stu_id");

            SqlParameter[] parameters = {
					new SqlParameter("@account", SqlDbType.NVarChar,50),
                    new SqlParameter("@stu_id", SqlDbType.Int,4),
			};
            parameters[0].Value = account;
            parameters[1].Value = stuid;

            QAMZN.Model.tb_users model = new QAMZN.Model.tb_users();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        
        /// <summary>
        /// 用户注册(增加一条数据)
        /// </summary>
        /// <param name="name">用户名称</param>
        /// <param name="pwd">密码</param>
        /// <param name="email">电子邮件</param>
        /// <param name="token">商家标识</param>
        /// <returns></returns>
        public int AddUserInfo(string name, string pwd, string email, string token, int stuid, string stuaccount, int trainingmode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_users(");
            strSql.Append("name,email,password,token,createtime,step,stu_id,stu_account,stu_training_mode)");
            strSql.Append(" values (");
            strSql.Append("@name,@email,@pwd,@token,@createtime,@step,@stu_id,@stu_account,@stu_training_mode)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@email", SqlDbType.NVarChar,50),
                    new SqlParameter("@pwd", SqlDbType.NVarChar,50),
                    new SqlParameter("@token", SqlDbType.NVarChar,50),
                    new SqlParameter("@createtime", SqlDbType.DateTime,50),
                    new SqlParameter("@step", SqlDbType.Int,4),
                    new SqlParameter("@stu_id", SqlDbType.Int,4),
                    new SqlParameter("@stu_account", SqlDbType.NVarChar,50),
                    new SqlParameter("@stu_training_mode", SqlDbType.Int,4),
                                        };
            parameters[0].Value = name;
            parameters[1].Value = email;
            parameters[2].Value = pwd;
            parameters[3].Value = token;
            parameters[4].Value = DateTime.Now.ToString("yyyy-MM-dd");
            parameters[5].Value = 0;
            parameters[6].Value = stuid;
            parameters[7].Value = stuaccount;
            parameters[8].Value = trainingmode;

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
        /// 注册用户时获取用户user_id
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <returns></returns>
        //public QAMZN.Model.tb_users SelectUserID(string email)
        //{

        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select  top 1 user_id from tb_users ");
        //    strSql.Append(" where email=@email");

        //    SqlParameter[] parameters = {
        //            new SqlParameter("@email", SqlDbType.NVarChar,50),
        //    };
        //    parameters[0].Value = email;

        //    QAMZN.Model.tb_users model = new QAMZN.Model.tb_users();
        //    DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        return DataRowToModel(ds.Tables[0].Rows[0]);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        #endregion

        #region 初始化卖家信息（website） 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public QAMZN.Model.tb_users GetWebsite(int user_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 user_id,sell_plan,user_identity,name,email,password,paypwd,legal_name,business_address,registered_address,website,telephone,chargemethod,depositmethod,is_product_upc,is_product_brand,product_list,categories,category_name,step,createtime,selling_state,selling_time,token,is_prime,stu_id,stu_account,stu_training_mode from tb_users ");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)
			};
            parameters[0].Value = user_id;

            QAMZN.Model.tb_users model = new QAMZN.Model.tb_users();
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

        #region 更新法人和商户注册步骤
        /// <summary>
        /// 更新法人和商户注册步骤
        /// </summary>
        /// <param name="userID">商户编号</param>
        /// <param name="legalname">法人</param>
        /// <returns></returns>
        public bool Updatelegalname(int userID, string legalname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_users set ");
            strSql.Append("legal_name=@legalname,");
            strSql.Append("step=@step");
            strSql.Append(" where user_id=@userID");
            SqlParameter[] parameters = {
					new SqlParameter("@legalname", SqlDbType.VarChar,200),
					new SqlParameter("@step", SqlDbType.Int,4),
					new SqlParameter("@userID", SqlDbType.Int,4)
                                        };
            parameters[0].Value = legalname;
            parameters[1].Value = 2;
            parameters[2].Value = userID;
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

        #region 更新商户注册之卖家信息
        /// <summary>
        /// 更新商户注册之卖家信息
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        public QAMZN.Model.tb_users GetUserInfo4(int userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 business_address,registered_address from tb_users ");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)
			};
            parameters[0].Value = userid;

            QAMZN.Model.tb_users model = new QAMZN.Model.tb_users();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToMode4(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 更新用户税务信息步骤
        /// <summary>
        /// 更新用户税务信息步骤
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        public bool UpadteUser_tax(int userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_users set ");
            strSql.Append("step=@step");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
              		new SqlParameter("@step", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4)
                                        };
            parameters[0].Value = 5;
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

        #region 初始化商户注册之账单存款(获取存款，收款，永久地址ID)
        /// <summary>
        /// 初始化商户注册之账单存款(获取存款，收款，永久地址ID)
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        public QAMZN.Model.tb_users GetMethonId(int userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 user_id,sell_plan,user_identity,name,email,password,paypwd,legal_name,business_address,registered_address,website,telephone,chargemethod,depositmethod,is_product_upc,is_product_brand,product_list,categories,category_name,step,createtime,selling_state,selling_time,token,is_prime,stu_id,stu_account,stu_training_mode from tb_users ");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)
			};
            parameters[0].Value = userid;

            QAMZN.Model.tb_users model = new QAMZN.Model.tb_users();
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
        
        #region 修改商品信息

        /// <summary>
        /// 商户注册之商品信息（返回信息{result:1 成功 0 失败}）
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="is_product_upc">是否都有产品编码（1 是 0 否）</param>
        /// <param name="is_product_brand">是否所销售商品的制造商或品牌商（1 是 0 否）</param>
        /// <param name="product_list">预计发布产品数量（1 1~10 2 11~100 3 101~500 4 500以上）</param>
        /// <param name="result">是否成功（1,0）</param>
        public bool UpdateCommodityInfo(int userid, int is_product_upc, int is_product_brand, int product_list)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_users set ");
            strSql.Append("is_product_upc=@is_product_upc,");
            strSql.Append("is_product_brand=@is_product_brand,");
            strSql.Append("product_list=@product_list");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@is_product_upc", SqlDbType.Int,4),
					new SqlParameter("@is_product_brand", SqlDbType.Int,4),
					new SqlParameter("@product_list", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4)};

            parameters[0].Value = is_product_upc;
            parameters[1].Value = is_product_brand;
            parameters[2].Value = product_list;
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

        #region 初始化商品信息
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public QAMZN.Model.tb_users GetModel(int user_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 user_id,sell_plan,user_identity,name,email,password,paypwd,legal_name,business_address,registered_address,website,telephone,chargemethod,depositmethod,is_product_upc,is_product_brand,product_list,categories,category_name,step,createtime,selling_state,selling_time,token,is_prime,stu_id,stu_account,stu_training_mode from tb_users ");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)
			};
            parameters[0].Value = user_id;

            QAMZN.Model.tb_users model = new QAMZN.Model.tb_users();
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

        #region 修改商品分类
        /// <summary>
        /// 商户注册之提交完成（返回信息{result:1 成功 0 失败}）
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="categories">选择的分类ID（用英文逗号分隔开）</param>
        /// <param name="categoryname">自定义分类名称</param>
        /// <returns></returns>
        public bool UpdateCategory(int userid, string categories, string categoryname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_users set ");
            strSql.Append("categories=@categories,");
            strSql.Append("category_name=@category_name,");
            strSql.Append("step=@step");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@categories", SqlDbType.VarChar,2000),
					new SqlParameter("@category_name", SqlDbType.VarChar,50),
					new SqlParameter("@step", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4)
                                        };
            parameters[0].Value = categories;
            parameters[1].Value = categoryname;
            parameters[2].Value = 6;
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

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public QAMZN.Model.tb_users DataRowToModel(DataRow row)
        {
            QAMZN.Model.tb_users model = new QAMZN.Model.tb_users();
            if (row != null)
            {
                if (row["user_id"] != null && row["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(row["user_id"].ToString());
                }
                if (row["password"] != null)
                {
                    model.password = row["password"].ToString();
                }
                if (row["step"] != null && row["step"].ToString() != "")
                {
                    model.step = int.Parse(row["step"].ToString());
                }
                if (row["stu_id"] != null && row["stu_id"].ToString() != "")
                {
                    model.stu_id = int.Parse(row["stu_id"].ToString());
                }
                if (row["stu_training_mode"] != null && row["stu_training_mode"].ToString() != "")
                {
                    model.stu_training_mode = int.Parse(row["stu_training_mode"].ToString());
                }
                if (row["sell_plan"] != null && row["sell_plan"].ToString() != "")
                {
                    model.sell_plan = int.Parse(row["sell_plan"].ToString());
                }
                if (row["user_identity"] != null && row["user_identity"].ToString() != "")
                {
                    model.user_identity = int.Parse(row["user_identity"].ToString());
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["email"] != null)
                {
                    model.email = row["email"].ToString();
                }
                if (row["password"] != null)
                {
                    model.password = row["password"].ToString();
                }
                if (row["paypwd"] != null)
                {
                    model.paypwd = row["paypwd"].ToString();
                }
                if (row["legal_name"] != null)
                {
                    model.legal_name = row["legal_name"].ToString();
                }
                if (row["business_address"] != null && row["business_address"].ToString() != "")
                {
                    model.business_address = int.Parse(row["business_address"].ToString());
                }
                if (row["registered_address"] != null && row["registered_address"].ToString() != "")
                {
                    model.registered_address = int.Parse(row["registered_address"].ToString());
                }
                if (row["website"] != null)
                {
                    model.website = row["website"].ToString();
                }
                if (row["telephone"] != null)
                {
                    model.telephone = row["telephone"].ToString();
                }
                if (row["chargemethod"] != null && row["chargemethod"].ToString() != "")
                {
                    model.chargemethod = int.Parse(row["chargemethod"].ToString());
                }
                if (row["depositmethod"] != null && row["depositmethod"].ToString() != "")
                {
                    model.depositmethod = int.Parse(row["depositmethod"].ToString());
                }
                if (row["is_product_upc"] != null && row["is_product_upc"].ToString() != "")
                {
                    model.is_product_upc = int.Parse(row["is_product_upc"].ToString());
                }
                if (row["is_product_brand"] != null && row["is_product_brand"].ToString() != "")
                {
                    model.is_product_brand = int.Parse(row["is_product_brand"].ToString());
                }
                if (row["product_list"] != null && row["product_list"].ToString() != "")
                {
                    model.product_list = int.Parse(row["product_list"].ToString());
                }
                if (row["categories"] != null)
                {
                    model.categories = row["categories"].ToString();
                }
                if (row["category_name"] != null)
                {
                    model.category_name = row["category_name"].ToString();
                }
                if (row["step"] != null && row["step"].ToString() != "")
                {
                    model.step = int.Parse(row["step"].ToString());
                }
                if (row["createtime"] != null && row["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(row["createtime"].ToString());
                }
                if (row["selling_state"] != null && row["selling_state"].ToString() != "")
                {
                    model.selling_state = int.Parse(row["selling_state"].ToString());
                }
                if (row["selling_time"] != null && row["selling_time"].ToString() != "")
                {
                    model.selling_time = DateTime.Parse(row["selling_time"].ToString());
                }
                if (row["token"] != null)
                {
                    model.token = row["token"].ToString();
                }
                if (row["is_prime"] != null && row["is_prime"].ToString() != "")
                {
                    model.is_prime = int.Parse(row["is_prime"].ToString());
                }
            }
            return model;
        }
        #endregion

        #region 得到一个实体（手机号\邮箱）
        /// <summary>
        /// 得到一个实体（手机号\邮箱）
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public QAMZN.Model.tb_users DataRowToModel1(DataRow row)
        {
            QAMZN.Model.tb_users model = new QAMZN.Model.tb_users();
            if (row != null)
            {
                if (row["email"] != null)
                {
                    model.email = row["email"].ToString();
                }
                if (row["token"] != null)
                {
                    model.token = row["token"].ToString();
                }
                if (row["stu_id"] != null && row["stu_id"].ToString()!="")
                {
                    model.stu_id = int.Parse(row["stu_id"].ToString());
                }
                if (row["stu_training_mode"] != null && row["stu_training_mode"].ToString() != "")
                {
                    model.stu_training_mode = int.Parse(row["stu_training_mode"].ToString());
                }
            }
            return model;
        }
        #endregion

        #region 得到一个实体（手机号\邮箱）
        /// <summary>
        /// 得到一个实体（手机号\邮箱）
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public QAMZN.Model.tb_users GetUserID_DataRowToModel(DataRow row)
        {
            QAMZN.Model.tb_users model = new QAMZN.Model.tb_users();
            if (row != null)
            {
                if (row["user_id"] != null && row["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(row["user_id"].ToString());
                }
                if (row["step"] != null && row["step"].ToString() != "")
                {
                    model.step = int.Parse(row["step"].ToString());
                }
            }
            return model;
        }
        #endregion 

        #region 得到一个对象实体4
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public QAMZN.Model.tb_users DataRowToMode4(DataRow row)
        {
            QAMZN.Model.tb_users model = new QAMZN.Model.tb_users();
            if (row != null)
            {
                if (row["business_address"] != null && row["business_address"].ToString() != "")
                {
                    model.business_address = int.Parse(row["business_address"].ToString());
                }
                if (row["registered_address"] != null && row["registered_address"].ToString() != "")
                {
                    model.registered_address = int.Parse(row["registered_address"].ToString());
                }
            }
            return model;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select user_id,sell_plan,user_identity,name,email,password,paypwd,legal_name,business_address,registered_address,website,telephone,chargemethod,depositmethod,is_product_upc,is_product_brand,product_list,categories,category_name,step,createtime,selling_state,selling_time,token,is_prime ");
            strSql.Append(" FROM tb_users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 获得前几行数据
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
            strSql.Append(" user_id,sell_plan,user_identity,name,email,password,paypwd,legal_name,business_address,registered_address,website,telephone,chargemethod,depositmethod,is_product_upc,is_product_brand,product_list,categories,category_name,step,createtime,selling_state,selling_time,token,is_prime ");
            strSql.Append(" FROM tb_users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 获取记录总数
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tb_users ");
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
        #endregion

        #region 分页获取数据列表
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
                strSql.Append("order by T.user_id desc");
            }
            strSql.Append(")AS Row, T.*  from tb_users T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 分页获取数据列表
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
			parameters[0].Value = "tb_users";
			parameters[1].Value = "user_id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/
        #endregion

        #region 查询商户编号
        /// <summary>
        /// 通过学生ID和实训模式（1,2）返回商户userID
        /// </summary>
        /// <param name="stuid">学生ID</param>
        /// <param name="trainingmode">实训模式（1,2）</param>
        /// <returns></returns>
        public QAMZN.Model.tb_users GetUserID1(int stuid, int trainingmode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 user_id,step from tb_users ");
            strSql.Append(" where stu_id=@stuid");
            strSql.Append(" and stu_training_mode=@trainingmode");

            SqlParameter[] parameters = {
					new SqlParameter("@stuid", SqlDbType.Int,4),
                    new SqlParameter("@trainingmode", SqlDbType.Int,4),
			};
            parameters[0].Value = stuid;
            parameters[1].Value = trainingmode;
            QAMZN.Model.tb_users model = new QAMZN.Model.tb_users();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetUserID_DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(QAMZN.Model.tb_users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_users set ");
            strSql.Append("sell_plan=@sell_plan,");
            strSql.Append("user_identity=@user_identity,");
            strSql.Append("name=@name,");
            strSql.Append("email=@email,");
            strSql.Append("password=@password,");
            strSql.Append("paypwd=@paypwd,");
            strSql.Append("legal_name=@legal_name,");
            strSql.Append("business_address=@business_address,");
            strSql.Append("registered_address=@registered_address,");
            strSql.Append("website=@website,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("chargemethod=@chargemethod,");
            strSql.Append("depositmethod=@depositmethod,");
            strSql.Append("is_product_upc=@is_product_upc,");
            strSql.Append("is_product_brand=@is_product_brand,");
            strSql.Append("product_list=@product_list,");
            strSql.Append("categories=@categories,");
            strSql.Append("category_name=@category_name,");
            strSql.Append("step=@step,");
            strSql.Append("createtime=@createtime,");
            strSql.Append("selling_state=@selling_state,");
            strSql.Append("selling_time=@selling_time,");
            strSql.Append("token=@token,");
            strSql.Append("is_prime=@is_prime,");
            strSql.Append("stu_id=@stu_id,");
            strSql.Append("stu_account=@stu_account,");
            strSql.Append("stu_training_mode=@stu_training_mode");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@sell_plan", SqlDbType.Int,4),
					new SqlParameter("@user_identity", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@password", SqlDbType.VarChar,50),
					new SqlParameter("@paypwd", SqlDbType.VarChar,50),
					new SqlParameter("@legal_name", SqlDbType.VarChar,200),
					new SqlParameter("@business_address", SqlDbType.Int,4),
					new SqlParameter("@registered_address", SqlDbType.Int,4),
					new SqlParameter("@website", SqlDbType.VarChar,500),
					new SqlParameter("@telephone", SqlDbType.VarChar,50),
					new SqlParameter("@chargemethod", SqlDbType.Int,4),
					new SqlParameter("@depositmethod", SqlDbType.Int,4),
					new SqlParameter("@is_product_upc", SqlDbType.Int,4),
					new SqlParameter("@is_product_brand", SqlDbType.Int,4),
					new SqlParameter("@product_list", SqlDbType.Int,4),
					new SqlParameter("@categories", SqlDbType.VarChar,2000),
					new SqlParameter("@category_name", SqlDbType.VarChar,50),
					new SqlParameter("@step", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@selling_state", SqlDbType.Int,4),
					new SqlParameter("@selling_time", SqlDbType.DateTime),
					new SqlParameter("@token", SqlDbType.VarChar,50),
					new SqlParameter("@is_prime", SqlDbType.Int,4),
					new SqlParameter("@stu_id", SqlDbType.Int,4),
					new SqlParameter("@stu_account", SqlDbType.VarChar,50),
					new SqlParameter("@stu_training_mode", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = model.sell_plan;
            parameters[1].Value = model.user_identity;
            parameters[2].Value = model.name;
            parameters[3].Value = model.email;
            parameters[4].Value = model.password;
            parameters[5].Value = model.paypwd;
            parameters[6].Value = model.legal_name;
            parameters[7].Value = model.business_address;
            parameters[8].Value = model.registered_address;
            parameters[9].Value = model.website;
            parameters[10].Value = model.telephone;
            parameters[11].Value = model.chargemethod;
            parameters[12].Value = model.depositmethod;
            parameters[13].Value = model.is_product_upc;
            parameters[14].Value = model.is_product_brand;
            parameters[15].Value = model.product_list;
            parameters[16].Value = model.categories;
            parameters[17].Value = model.category_name;
            parameters[18].Value = model.step;
            parameters[19].Value = model.createtime;
            parameters[20].Value = model.selling_state;
            parameters[21].Value = model.selling_time;
            parameters[22].Value = model.token;
            parameters[23].Value = model.is_prime;
            parameters[24].Value = model.stu_id;
            parameters[25].Value = model.stu_account;
            parameters[26].Value = model.stu_training_mode;
            parameters[27].Value = model.user_id;

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

        #region 更新用户表存款编号
        /// <summary>
        /// 更新用户表存款编号
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="method_id">存款编号</param>
        /// <returns></returns>
        public bool UpdateUserDepositId(int userid,int method_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_users set ");
            strSql.Append("depositmethod=@depositmethod");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@depositmethod", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = method_id;
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

        #region 更新用户表付款编号
        /// <summary>
        /// 更新用户表付款编号
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="method_id">付款编号</param>
        /// <returns></returns>
        public bool UpdateUserChargeId(int userid, int method_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_users set ");
            strSql.Append("chargemethod=@chargemethod");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@chargemethod", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = method_id;
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

        #region  更新用户表里的办公地址
        /// <summary>
        /// 更新用户表里的办公地址
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="addressId">地址编号</param>
        /// <returns></returns>
        public bool UpdateBusinessAddress(int userid, int addressId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_users set ");
            strSql.Append("business_address=@business_address");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@business_address", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = addressId;
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

        #region  更新用户表里的注册地址

        /// <summary>
        /// 更新用户表里的注册地址
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="addressId">注册地址编号</param>
        /// <returns></returns>
        public bool UpdateRegisteredAddress(int userid, int addressId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_users set ");
            strSql.Append("registered_address=@registered_address");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@registered_address", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = addressId;
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

        #region UpdateName

        public bool UpdateName(int userid,string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_users set ");
            strSql.Append("name=@name");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = name;
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

        #region UpdateEmail
        public bool UpdateEmail(int userid, string email, string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_users set ");
            strSql.Append("email=@email,");
            strSql.Append("password=@password");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@password", SqlDbType.VarChar,50),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = email;
            parameters[1].Value = pwd;
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

        #region UpdatePassword
        public bool UpdatePassword(int userid, string password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_users set ");
            strSql.Append("password=@password");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@password", SqlDbType.VarChar,50),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = password;
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

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

