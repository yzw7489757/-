using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///tb_user_shippingsettings 的摘要说明
/// </summary>
namespace QAMZN.BLL
{
    public partial class tb_user_shippingsettings
    {
        public tb_user_shippingsettings()
        {
        }
        private readonly QAMZN.DAL.tb_user_shippingsettings dal = new QAMZN.DAL.tb_user_shippingsettings();
        QAMZN.Model.tb_user_shippingsettings model = new Model.tb_user_shippingsettings();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="userID">用户编号</param>
        /// <returns></returns>
        public int AddShipping(int userID) 
        {
           return dal.AddShipping(userID);
        }


        #region GetShippingSetAddressId 获取配送地址ID
        /// <summary>
        /// 获取配送地址ID
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="address_id">配送地址ID</param>
        public void GetShippingSetAddressId(int userid, ref int? address_id)
        {
           model= dal.GetModel(userid);
           if (model != null)
               address_id = model.address_id;
        }
        #endregion

        #region GetShippingSettingsInfo 获取配送信息详情
        /// <summary>
        /// 获取配送信息详情
        /// </summary>
        /// <param name="userid">用户编号</param>
        public  string GetShippingSettingsInfo(int userid)
        {
            model = dal.GetModel(userid);
            if (model != null)
                return "\"standard_one\":\"" + model.standard_one 
                    + "\",\"standard_two\":\"" + model.standard_two 
                    + "\",\"expedited_one\":\"" + model.expedited_one 
                    + "\",\"expedited_two\":\"" + model.expedited_two 
                    + "\",\"twoday\":\"" + model.twoday 
                    + "\",\"oneday\":\"" + model.oneday 
                    + "\",\"international\":\"" + model.international 
                    + "\",\"expedited\":\"" + model.expedited + "\"";
            else
                return "";

        }
        #endregion

        #region UpdateShippingSetting 更新配送信息详情
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
            return dal.UpdateShippingSetting(userid, standard_one, standard_two, expedited_one, expedited_two, twoday, oneday, international, expedited);
        }
        #endregion

        #region SetAddressDefault 设置配送地址为默认值
        /// <summary>
        /// 设置配送地址为默认值
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="addressId">地址编号</param>
        /// <returns></returns>
        public bool SetAddressDefault(int userid,int addressId)
        {
            model.user_id = userid;
            model.address_id = addressId;
            return dal.SetAddressDefault(model);
        }
        #endregion

    }
}