using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
///tb_user_depositmethod 的摘要说明
/// </summary>
namespace QAMZN.BLL
{
    public partial class tb_user_depositmethod
    {
        public tb_user_depositmethod()
        {
        }
        private readonly QAMZN.DAL.tb_user_depositmethod dal = new QAMZN.DAL.tb_user_depositmethod();
        QAMZN.Model.tb_user_depositmethod model = new Model.tb_user_depositmethod();

        #region 获取存款信息
        /// <summary>
        /// 获取存款信息
        /// </summary>
        /// <param name="depositId">存款编号</param>
        /// <returns></returns>
        public string GetDepositInfo(int? depositId)
        {
            string method_id = string.Empty;
            model = dal.GetModel((int)depositId);
            if (model != null)
            {
                return "\"depositId\":\"" + model.method_id
                    + "\",\"bank_location\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.bank_location)
                    + "\",\"account_name\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.account_name)
                    + "\",\"routing_number\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.routing_number)
                    + "\",\"account_number\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.account_number) + "\"";
            }
            else { return ""; }
        }
        #endregion

        #region 获取存款方式列表
        /// <summary>
        /// 获取存款方式列表
        /// </summary>
        /// <param name="userid">商户编号</param>
        public string GetDepositInfoList(int userid)
        {
            string strWhere = "" + userid + "";
            DataSet ds = dal.GetDepositInfoList(strWhere);
            int Row = ds.Tables[0].Rows.Count;//行数
            int Col = ds.Tables[0].Columns.Count;//列数
            string[,] strarr = new string[Row, Col];
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    strarr[i, j] = ds.Tables[0].Rows[i][j].ToString();
                }
            }
            string Str = string.Empty;
            string strROW = "[";
            for (int i = 0; i < Row; i++)
			{
                Str = "{\"method_id\":\"" + QGYHelper.FormatCode.FormatUrlEncode(strarr[i, 0].ToString())
                    + "\",\"bank_location\":\"" + QGYHelper.FormatCode.FormatUrlEncode(strarr[i, 1].ToString())
                    + "\",\"account_name\":\"" + QGYHelper.FormatCode.FormatUrlEncode(strarr[i, 2].ToString())
                    + "\",\"account_number\":\"" + QGYHelper.FormatCode.FormatUrlEncode(strarr[i, 4].ToString())
                    + "\"}";
                strROW = strROW + Str+",";
			}
            strROW = strROW.Remove(strROW.Length - 1);
            return strROW= strROW + "]";
        }
        #endregion

        #region 设置存款方式(获取银行卡号)
        /// <summary>
        /// 设置存款方式(获取银行卡号)
        /// </summary>
        /// <param name="method_id">存款方式ID</param>
        /// <param name="number">银行卡号</param>
        public void GetModel(int method_id, ref string number)
        {
          model=  dal.GetModel(method_id);
          if (model != null)
          {
              number = model.account_number;
          }
        }
        #endregion

        #region 新增付款方式
        /// <summary>
        /// 新增付款方式
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="bank_location">银行所在地</param>
        /// <param name="account_name">账户持有人姓名</param>
        /// <param name="routing_number">银行识别代码</param>
        /// <param name="account_number">银行账号</param>
        public int AddDepositMethod(int userid, string bank_location, string account_name, string routing_number, string account_number)
        {
            return dal.AddDepositMethod(userid, bank_location, account_name, routing_number, account_number);
        }
        #endregion 
    }
}
