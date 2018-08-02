using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using QGYHelper.DataBase;
using System.Text;
using System.Data.SqlClient;

/// <summary>
///SMSCodeHelper 的摘要说明
/// </summary>
namespace QGYHelper
{
    /// <summary>
    /// QGY_SMSCode:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TB_SMSCode
    {
        public TB_SMSCode()
        { }
        #region Model
        private int _fld_id;
        private string _fld_type;
        private string _fld_phone;
        private string _fld_code;
        private int? _fld_state;
        private DateTime? _fld_time;
        /// <summary>
        ///  ID
        /// </summary>
        public int fld_id
        {
            set { _fld_id = value; }
            get { return _fld_id; }
        }
        /// <summary>
        ///  验证类型
        /// </summary>
        public string fld_type
        {
            set { _fld_type = value; }
            get { return _fld_type; }
        }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string fld_phone
        {
            set { _fld_phone = value; }
            get { return _fld_phone; }
        }
        /// <summary>
        /// 验证码
        /// </summary>
        public string fld_code
        {
            set { _fld_code = value; }
            get { return _fld_code; }
        }
        /// <summary>
        /// 状态（1 未使用 2 已使用）
        /// </summary>
        public int? fld_state
        {
            set { _fld_state = value; }
            get { return _fld_state; }
        }
        /// <summary>
        /// 截止日期
        /// </summary>
        public DateTime? fld_time
        {
            set { _fld_time = value; }
            get { return _fld_time; }
        }
        #endregion Model

    }
    public class SMSHelper
    {
        public SMSHelper()
        {
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        private static int Add(TB_SMSCode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TB_SMSCode(");
            strSql.Append("fld_type,fld_phone,fld_code,fld_state,fld_time)");
            strSql.Append(" values (");
            strSql.Append("@fld_type,@fld_phone,@fld_code,@fld_state,@fld_time)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@fld_type", SqlDbType.VarChar,50),
					new SqlParameter("@fld_phone", SqlDbType.VarChar,20),
					new SqlParameter("@fld_code", SqlDbType.VarChar,10),
					new SqlParameter("@fld_state", SqlDbType.Int,4),
					new SqlParameter("@fld_time", SqlDbType.DateTime)};
            parameters[0].Value = model.fld_type;
            parameters[1].Value = model.fld_phone;
            parameters[2].Value = model.fld_code;
            parameters[3].Value = model.fld_state;
            parameters[4].Value = model.fld_time;

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
        /// 发送手机验证码
        /// </summary>
        /// <param name="type">验证类型（1）</param>
        /// <param name="phone">电话号码</param>
        /// <param name="vcode">验证码</param>
        /// <param name="error">错误信息</param>
        /// <returns></returns>
        public static bool Send(string type, string phone, ref string vcode, ref string error)
        {
            TB_SMSCode model = new TB_SMSCode();
            model.fld_type = type;
            model.fld_phone = phone;
            #region 产生6位随机代码

            Random rNum = new Random();//随机生成类
            int num1 = rNum.Next(0, 9);//返回指定范围内的随机数
            int num2 = rNum.Next(0, 9);
            int num3 = rNum.Next(0, 9);
            int num4 = rNum.Next(0, 9);
            int num5 = rNum.Next(0, 9);
            int num6 = rNum.Next(0, 9);
            vcode = num1.ToString() + num2.ToString() + num3.ToString() + num4.ToString() + num5.ToString() + num6.ToString();
            #endregion
            model.fld_code = vcode;
            model.fld_state = 1;//未使用
            model.fld_time = DateTime.Now;
            if (Add(model) <= 0)
            {
                error = "错误信息:操作异常,请联系管理员";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 验证手机验证码
        /// </summary>
        /// <param name="type">验证类型（1）</param>
        /// <param name="phone">电话号码</param>
        /// <param name="vcode">验证码</param>
        /// <param name="error">错误信息</param>
        /// <returns></returns>
        public static bool Verify(string type, string phone, string vcode, ref string error)
        {
            string strSql = "select fld_id,fld_code from TB_SMSCode where fld_type='" + type + "' and fld_state=1 and fld_phone='" + phone + "' order by fld_time desc";
            DataTable dt = DbHelperSQL.Query(strSql).Tables[0];
            if (dt.Rows.Count <= 0)
            {
                error = "验证码输入错误";
                return false;
            }
            int id = Convert.ToInt32(dt.Rows[0]["fld_id"]);
            string code = dt.Rows[0]["fld_code"].ToString();
            if (vcode != code)
            {
                error = "验证码输入错误";
                return false;
            }

            strSql = "update TB_SMSCode set fld_state = 2 where fld_id = " + id;
            QGYHelper.DataBase.DbHelperSQL.ExecuteSql(strSql); 
            return true;
        }
    }
}