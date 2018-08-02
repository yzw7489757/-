using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
///tb_users 的摘要说明
/// </summary>
namespace QAMZN.BLL
{
	public partial class tb_users
    {
        private readonly QAMZN.DAL.tb_users dal = new QAMZN.DAL.tb_users();
        
        QAMZN.Model.tb_users model = new Model.tb_users();
		public tb_users()
		{}
        #region  商户登录
        /// <summary>
        /// 商户登录
        /// </summary>
        /// <param name="account">用户输入账号</param>
        /// <param name="pwd">密码</param>
        /// <param name="userID">用户编号</param>
        /// <param name="stuid">学生编号</param>
        /// <param name="trainingmode">实训模式（1 单项 2 综合）</param>
        /// <param name="userID">用户编号</param>
        /// <param name="step">注册步骤</param>
        /// <param name="error">错误信息</param>
        /// <returns></returns>
        public bool Login(string account, string pwd, int stuid, int trainingmode, ref int userID, ref int step, ref string error)
        {
            
            //检测账号类型（1 邮箱 2 手机）
            if (account.Contains("@"))
            {
                //邮箱，
                model = dal.GetModelEmail(account); 
            }
            else
            {
                //手机号
                model = dal.GetModelTelephone(account);
            }
            if (model == null)
            {
                error = "账号错误";
                return false;
            }
            else
            {
                if (pwd != model.password)
                {
                    error = "密码错误";
                    return false;
                }
                else if (stuid != model.stu_id)
                {
                    error = "卖家账号与学生账号不匹配";
                    return false;
                }
                else if (trainingmode != model.stu_training_mode)
                {
                    error = "卖家账号与实训类型不匹配";
                    return false;
                }
                userID = model.user_id;
                step = model.step.Value;
                return true;
            }
        }
        #endregion

        #region 商户找回密码之验证账号（通过邮箱地址或手机号码找回密码）
        /// <summary>
        /// 商户找回密码之验证账号（通过邮箱地址或手机号码找回密码）
        /// </summary>
        /// <param name="account">用户输入账号（邮箱或者手机号）</param>
        /// <param name="result">返回值</param>
        /// <param name="token">商家标识</param>
        /// <param name="email">电子邮件</param>
        /// <returns></returns>
        public bool GetUserInfo(string account, int stuid, int trainingmode, ref int result, ref string token, ref string email, ref string error)
        {
            //检查账号类型
            if (account.Contains("@")) 
            {
                //通过账号查询账户标志（token）和邮箱(email)
                 model = dal.AdoptEmail(account);
            }
            else
            {
                //通过手机号
                model = dal.AdoptTelephone(account);
            }
            if (model == null)
            {
                error = "账号不存在";
                return false;
            }
            else
            {
                if (stuid != model.stu_id)
                {
                    error = "卖家账号与学生账号不匹配";
                    return false;
                }
                else
                {
                    if (trainingmode != model.stu_training_mode)
                    {
                        error = "卖家账号与实训类型不匹配";
                        return false;
                    }
                }
                token = model.token;
                email = model.email;
                return true;
            }
        }
        #endregion

        #region 通过token 给密码赋值
        /// <summary>
        /// 通过token 给密码赋值
        /// </summary>
        /// <param name="token">商家标识</param>
        /// <param name="pwd">用户密码</param>
        /// <returns></returns>
        public bool UpdatePwd(string token,string pwd)
        {
            return dal.UpdatePwd(token, pwd);
        }
        #endregion

        #region 用户注册
        /// <summary>
        /// 验证邮箱是否存在
        /// </summary>
        /// <param name="account">邮箱</param>
        /// <returns></returns>
        public bool SelectEmail(string account)
        {
            return dal.AdoptEmail2(account);
        }

        /// <summary>
        /// 验证邮箱和学生编号是否存在
        /// </summary>
        /// <param name="account">邮箱</param>
        /// <param name="stu_id">学生编号</param>
        /// <returns></returns>
        public bool SelectEmail2(string account, int stuid)
        {
            return dal.AdoptEmail3(account, stuid);
        }

        /// <summary>
        /// 像数据库里插入一条用户数据
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">登录密码</param>
        /// <param name="email">电子邮件</param>
        /// <param name="token">商家标识</param>
        /// <returns></returns>
        public int AddUserInfo(string name, string pwd, string email, string token, int stuid, string stuaccount, int trainingmode)
        {
            return dal.AddUserInfo(name, pwd, email, token,stuid,stuaccount,trainingmode);
        }

        /// <summary>
        /// 根据邮箱获取用户编号
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <param name="user_id">用户编号</param>
        /// <returns></returns>
        //public bool SelectUserID(string email, ref int userID)
        //{
        //    model = dal.SelectUserID(email);
        //    if (model != null)
        //    {
        //        userID = model.user_id;
        //        return true;
        //    }
        //    return false;
        //}
        #endregion

        #region 初始化法人
        /// <summary>
        /// 初始化法人（返回法人）
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="legal_name">返回法人信息</param>
        /// <param name="result">接口状态</param>
        /// <param name="error">错误信息</param>
        public void GetUserLegal_Name(int userid, ref string legal_name, ref int result, ref string error,ref int? step)
        {
            model = dal.GetUserLegal_Name(userid);
            if (model.legal_name != null&&model.legal_name!="")
            {
                result = 1;
                legal_name = model.legal_name;
                step = model.step;
            }
            else 
            {
                error = "请先添加法人";
            }
        }
        #endregion
        
        #region 修改法人和注册状态
        /// <summary>
        /// 修改法人和注册状态
        /// </summary>
        /// <param name="userID">商户编号</param>
        /// <param name="legalname">法人</param>
        /// <param name="result">返回值（1,0）</param>
        /// <returns></returns>
        public bool Updatelegalname(int userID, string legalname)
        {
            if (dal.Updatelegalname(userID, legalname))
                return true;
            else
                return false;
        }
        #endregion

        #region 初始化网站地址和永久地址ID
        /// <summary>
        /// 初始化网站地址和永久地址ID
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="website">网站地址</param>
        /// <param name="addressId">永久地址ID</param>
        /// <param name="error">错误信息</param>
        public void GetWebsite(int userid, ref string website, ref int? addressId,ref int? step)
        {
            model = dal.GetWebsite(userid);
            if(model!=null)
            {
                website=model.website;
                addressId = model.registered_address;
                step = model.step;
            }
        }
        #endregion

        #region 修改注册ID和网站地址
        /// <summary>
        /// 修改注册ID和网站地址
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="id">注册地址ID/办公地址ID</param>
        /// <param name="website">商品网站</param>
        /// <param name="result">返回值（1，0）</param>
        public void UpdateUserWebsite(int userid, int id, string website)
        {
            dal.UpdateUserWebsite(userid, id, website);
        }
        #endregion

        #region 初始化商户注册之账单存款(获取存款，收款，永久地址ID)
        /// <summary>
        /// 初始化商户注册之账单存款(获取存款，收款，永久地址ID)
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="registered_address">永久地址ID</param>
        /// <param name="business_address">邮寄地址ID</param>
        public void GetMethonId(int userid, ref int? chargeId, ref int? depositId, ref string error, ref int? registered_address,ref int? step)
        {
          model=  dal.GetMethonId(userid);
          if (model != null)
          {
              chargeId = model.chargemethod;
              depositId = model.depositmethod;
              registered_address= model.registered_address;
              step = model.step;
          }
          else 
          {
              error = "账单存款无信息，请先添加";
          }
        }
        #endregion

        #region 重载方法(获取用户表里的存款和付款ID)
        /// <summary>
        /// 重载方法(获取用户表里的存款和付款ID)
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="chargeId">付款编号</param>
        /// <param name="depositiId">存款编号</param>
        public void GetMethonId(int userid, ref int? chargeId, ref int? depositiId)
        {
            model = dal.GetMethonId(userid);
            if (model != null)
            {
                chargeId = model.chargemethod;
                depositiId = model.depositmethod;
               
            }
        }
        #endregion 

        #region 更新商户注册之卖家信息（获取永用户表里久地址ID）
        /// <summary>
        /// 更新商户注册之卖家信息（获取永用户表里久地址ID）
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="registered_address">永久地址ID</param>
        /// <param name="business_address">邮寄地址ID</param>
        public bool GetUserInfo4(int userid, ref int? registered_address, ref int? business_address)
        {
           model= dal.GetUserInfo4(userid);
           if (model.registered_address != null)
           {
               registered_address = model.registered_address;
               business_address = model.business_address;
               return true;
           }
           else { return false; }
        }
        #endregion

        #region 更新用户税务信息
        /// <summary>
        /// 更新用户税务信息
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="result"></param>
        public bool UpadteUser_tax(int userid) 
        {
            if (dal.UpadteUser_tax(userid) == true)
                return true;
            else 
                return false;    
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
            return dal.UpdateCommodityInfo(userid, is_product_upc, is_product_brand, product_list);
        }
        #endregion

        #region  初始化商品信息 GetCommodityInfo
        /// <summary>
        /// 初始化商品信息
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="is_product_upc"></param>
        /// <param name="is_product_brand"></param>
        /// <param name="product_list"></param>
        public void GetCommodityInfo(int userid, ref int? is_product_upc, ref int? is_product_brand, ref int? product_list,ref int? step)
        {
          model=  dal.GetModel(userid);
          if (model != null)
          {
              is_product_upc = model.is_product_upc;
              is_product_brand = model.is_product_brand;
              product_list = model.product_list;
              step = model.step;
          }
        }
        #endregion 

        #region  商户注册之提交完成
        /// <summary>
        /// 商户注册之提交完成（返回信息{result:1 成功 0 失败}）
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="categories">选择的分类ID（用英文逗号分隔开）</param>
        /// <param name="categoryname">自定义分类名称</param>
        /// <param name="result">返回值（1,0）</param>
        public bool UpdateCategory(int userid, string categories, string categoryname) 
        {
            if (dal.UpdateCategory(userid, categories, categoryname))
                return true;
            else
                return false;
        }
        #endregion

        #region 查询商户编号
        /// <summary>
        /// 通过学生ID和实训模式（1,2）返回商户userID
        /// </summary>
        /// <param name="stuid">学生ID</param>
        /// <param name="trainingmode">实训模式（0,1）</param>
        /// <param name="userid">商户编号</param>
        /// <param name="isfinished">是否完成（1是 0否）</param>
        /// <param name="error">返回信息</param>
        public bool GetUserID1(int stuid, int trainingmode, ref int userid, ref int isfinished, ref string error,ref int step)
        {
            model = dal.GetUserID1(stuid, trainingmode);
            if (model != null)
            { 
                userid = model.user_id;
                isfinished = (model.step.Value == 6) ? 1 : 0;
                step = model.step.Value;
                return true;
            }
            else { 
                return false; 
            }
        }

        #endregion

        #region 公用方法 获取公司名称办公地址等 GetCompanyInfo
        /// <summary>
        /// 获取办公地址ID,正式注册ID,公司名称,商家标志
        /// </summary>
        /// <param name="userid">用户编号</param>
        public void GetCompanyInfo(int userid, ref int? business_address, ref int? registered_address,ref string name,ref string token)
        {
            model = dal.GetModel(userid);
            if (model != null)
            {
                business_address = model.business_address;
                registered_address = model.registered_address;
                name = model.name;
                token = model.token;
            }
        }
        #endregion

        #region  UpdateUserDepositId 更新用户表存款编号
        /// <summary>
        /// 更新用户表存款编号
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="method_id">存款方式编号</param>
        public bool UpdateUserDepositId(int userid, int method_id)
        {
            return dal.UpdateUserDepositId(userid, method_id);
        }
        #endregion

        #region  UpdateUserChargeId 更新用户表付款编号 
        /// <summary>
        /// 更新用户表付款编号
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="method_id">付款方式编号</param>
        public bool UpdateUserChargeId(int userid, int method_id)
        {
            return dal.UpdateUserChargeId(userid, method_id);
        }
        #endregion

        #region  UpdateBusinessAddress 更新用户表里的办公地址ID
        /// <summary>
        /// 更新用户表里的办公地址
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="addressId">地址编号</param>
        /// <returns></returns>
        public bool UpdateBusinessAddress(int userid, int addressId)
        {
            return dal.UpdateBusinessAddress(userid, addressId);
        }
        #endregion

        #region  UpdateRegisteredAddress 更新用户表里的注册地址ID
        /// <summary>
        /// 更新用户表里的注册地址
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="addressId">注册地址编号</param>
        /// <returns></returns>
        public bool UpdateRegisteredAddress(int userid, int addressId)
        {
            return dal.UpdateRegisteredAddress(userid, addressId);
        }

        #endregion

        #region  初始化通知首选项(获取用户登录邮箱）
        /// <summary>
        /// 初始化通知首选项(获取用户登录邮箱）
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="email">用户登录邮箱</param>
        public void GetEmail(int userid, ref string email,ref string name)
        {
            model = dal.GetModel(userid);
            if (model != null)
            {
                email = model.email;
                name = model.name;
            }
        }
        #endregion

        #region 获取用户登录邮箱和密码 LoginEmail
        /// <summary>
        /// 获取用户登录邮箱和密码
        /// </summary>
        /// <param name="account">邮箱或者手机号</param>
        /// <param name="password">密码</param>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void LoginEmail(string account, string password, ref int result, ref string error)
        {
            if (account.Contains("@"))
            {
                model = dal.GetModelEmail(account);
                if (model != null)
                {
                    if (password == model.password)
                        result = 1;
                    else
                        error = "密码错误";
                }
                else
                    error = "邮箱不存在";
            }
            else
            {
                model = dal.GetModelTelephone(account);
                if (model != null)
                {
                    if (password == model.password)
                        result = 1;
                    else
                        error = "密码错误";
                }
                else
                    error = "手机号不存在";
            }
        }
        #endregion

        #region  获取用户表信息 GetUserLoginSetting
        /// <summary>
        /// 获取用户表信息（name,email,pwd,telephone）
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        public string GetUserLoginSetting(int userid)
        {
            model = dal.GetModel(userid);
            if (model != null)
            {
                return "\"name\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.name) + "\",\"email\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.email) + "\",\"password\":\"" + model.password + "\",\"telephone\":\"" + model.telephone + "\"";
            }
            else
                return "";
        }
        #endregion 

        #region UpdateName
        /// <summary>
        /// 更新姓名
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="name">姓名</param>
        /// <returns></returns>
        public bool UpdateName(int userid,string name)
        {
           return dal.UpdateName(userid, name);
        }
        #endregion 

        #region UpdateEmail
        /// <summary>
        /// 更新邮箱
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="name">邮箱</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public bool UpdateEmail(int userid, string email, string pwd)
        {
            return dal.UpdateEmail(userid, email, pwd);
        }
        #endregion 

        #region 获取密码
        /// <summary>
        /// 根据用户编号查询密码
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="pwd">密码</param>
        public void GetPassword(int userid, ref string pwd)
        {
            model = dal.GetModel(userid);
            if (model != null)
                pwd = model.password;
        }
        #endregion

        #region UpdatePassword 更改密码
        /// <summary>
        /// 更新邮箱
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public bool UpdatePassword(int userid, string password)
        {
            return dal.UpdatePassword(userid, password);
        }
        #endregion 

    }
}