using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using System.Data;
using System.Transactions;
using System.IO;
/// <summary>
///亚马逊接口
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class QAMZNAPI : System.Web.Services.WebService, IRequiresSessionState
{
    #region 商户注册实例
    QAMZN.BLL.tb_users userBLL = new QAMZN.BLL.tb_users();

    QAMZN.BLL.tb_virtual_shop shopBLL = new QAMZN.BLL.tb_virtual_shop();

    QAMZN.BLL.tb_user_notificationoptions noticeBLL = new QAMZN.BLL.tb_user_notificationoptions();

    QAMZN.BLL.tb_user_shippingsettings shippingBLL = new QAMZN.BLL.tb_user_shippingsettings();

    QAMZN.BLL.tb_user_returnsettings returnBLL = new QAMZN.BLL.tb_user_returnsettings();

    QAMZN.BLL.tb_user_address addressBLL = new QAMZN.BLL.tb_user_address();

    QAMZN.BLL.tb_user_chargemethods chargeBLL = new QAMZN.BLL.tb_user_chargemethods();

    QAMZN.BLL.tb_user_depositmethod depositBLL = new QAMZN.BLL.tb_user_depositmethod();

    QAMZN.BLL.tb_user_tax user_taxBLL = new QAMZN.BLL.tb_user_tax();

    QAMZN.BLL.tb_user_authentication authentication_BLL = new QAMZN.BLL.tb_user_authentication();

    QAMZN.BLL.tb_user_contacts contacts_BLL = new QAMZN.BLL.tb_user_contacts();
    #endregion 

    #region 基础

    public QAMZNAPI()
    {
    }
    /// <summary>
    /// 回调函数
    /// </summary>
    /// <param name="result"></param>
    [WebMethod(EnableSession = true)]
    private void Callback(string result)
    {
        Context.Response.Write(result);
        Context.Response.End();
    }
    #endregion
      
    #region 上传文件

    /// <summary>
    /// 上传文件(如果是图片文件生成缩略图)
    /// </summary>
    [WebMethod(EnableSession = true)]
    public void UploadFile()
    {
        bool isSuccess = false;
        string error = "";
        string path = "";
        string thumb_path = "";

        string file = "file";

        try
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;
            //string strFileName = HttpContext.Current.Request["filename"];
            string strFileName = files[0].FileName;
            string file_format = System.IO.Path.GetExtension(strFileName);
            //读文件
            byte[] b = new byte[files[0].ContentLength];
            System.IO.Stream fs = (System.IO.Stream)files[0].InputStream;
            fs.Read(b, 0, files[0].ContentLength);
            fs.Close();
            //如果是图片需要生成缩略图
            if (file_format.ToLower() == ".bmp" || file_format.ToLower() == ".jpg" || file_format.ToLower() == ".jpeg" || file_format.ToLower() == ".png" || file_format.ToLower() == ".gif")
            {
                System.IO.MemoryStream m = new System.IO.MemoryStream(b);
                System.Drawing.Image img_img = System.Drawing.Image.FromStream(m);
                isSuccess = QGYHelper.Util.ImageHelper.SaveImg(img_img, ref path, ref thumb_path, file_format, file);
                if (!isSuccess)
                {
                    error = "图片上传失败";
                }
            }
            else
            {
                path = "/uploads/file/";
                string FullPath = HttpContext.Current.Request.MapPath(path);
                if (!System.IO.Directory.Exists(FullPath))
                {
                    System.IO.Directory.CreateDirectory(FullPath);
                }
                //文件新名称
                string newName = "file_" + DateTime.Now.ToString("yyyyMMddHHmmss") + file_format;
                //写文件
                FileStream fs_creat = new FileStream(FullPath + newName, FileMode.Append);//初始化文件流
                fs_creat.Write(b, 0, b.Length);//将字节数组写入文件流
                fs_creat.Close();//关闭流
                path = path + newName;
            }
        }
        catch
        {
            isSuccess = false;
            error = "文件上传失败";
        }

        path = QGYHelper.Config._ApiUrl + path;
        thumb_path = QGYHelper.Config._ApiUrl + thumb_path;
        Callback("{\"result\":\"" + (isSuccess ? 1 : 0) + "\",\"error\":\"" + error + "\",\"path\":\"" + path + "\",\"thumb_path\":\"" + thumb_path + "\"}");
    }
    #endregion

    #region 注册功能实现-------------------------------------

    #region 短信验证码

    /// <summary>
    /// 发送短信验证码
    /// </summary>
    /// <param name="type">类型（1注册卖家信息验证）</param>
    /// <param name="mobile">手机号码</param>
    [WebMethod(EnableSession = true)]
    public void SMSSend(string type,string mobile)
    {
        string vcode = string.Empty;
        string error = "验证码已发送";
        bool result= QGYHelper.SMSHelper.Send(type, mobile, ref vcode, ref error);
        Callback("{\"result\":" + (result ? 1 : 0) + ",\"vcode\":\"" + vcode + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }
    /// <summary>
    /// 短信验证码验证
    /// </summary>
    /// <param name="type">类型（1注册卖家信息验证2）</param>
    /// <param name="mobile">手机号码</param>
    /// <param name="vcode">验证码</param>
    [WebMethod(EnableSession = true)]
    public void SMSVerify(string type, string mobile,string vcode)
    {
        string error = "验证成功";
        bool result = QGYHelper.SMSHelper.Verify(type, mobile, vcode, ref error); 
        Callback("{\"result\":" + (result ? 1 : 0) + ",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }
    #endregion

    #region 国家列表

    /// <summary>
    /// 国家列表
    /// </summary>  
    /// <param name="lang">语言</param>
    [WebMethod(EnableSession = true)]
    public void GetCountry(string lang)
    {
        string strSql = "select short_zh,name_en from tb_country";
        if (lang == "zh")
            strSql += " order by short_zh";
        else if (lang == "en")
            strSql += " order by name_en";
        DataTable dt = QGYHelper.DataBase.DbHelperSQL.Query(strSql).Tables[0];
        System.Text.StringBuilder sbHtml = new System.Text.StringBuilder();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string value = string.Empty;
            if (lang == "zh")
                value = dt.Rows[i]["short_zh"].ToString();
            else if (lang == "en")
                value = dt.Rows[i]["name_en"].ToString();
            sbHtml.AppendLine("<option value=\"" + value + "\">" + value + "</option>");
        }
        Context.Response.Write(sbHtml.ToString());
        Context.Response.End();
    }


    #endregion

    #region 短信语言

    /// <summary>
    /// 短信语言
    /// </summary>  
    /// <param name="lang">语言</param>
    [WebMethod(EnableSession = true)]
    public void GetLang(string lang)
    {
        string[] zh = new string[] { "中文" };
        string[] en = new string[] { "Chinese" };
        System.Text.StringBuilder sbHtml = new System.Text.StringBuilder();
        if (lang == "zh")
        {
            for (int i = 0; i < zh.Length; i++)
            {
                string value = zh[i];
                sbHtml.AppendLine("<option value=\"" + value + "\">" + value + "</option>");
            }
        }
        else if (lang == "en")
        {
            for (int i = 0; i < en.Length; i++)
            {
                string value = en[i];
                sbHtml.AppendLine("<option value=\"" + value + "\">" + value + "</option>");
            }
        }
        Context.Response.Write(sbHtml.ToString());
        Context.Response.End();
    }


    #endregion

    #region 商品类目

    /// <summary>
    /// 短信语言
    /// </summary>  
    /// <param name="lang">语言</param>
    [WebMethod(EnableSession = true)]
    public void GetCategory(string lang, string port, int pid)
    {
        string name = "";
        if (lang == "zh")
        {
            if (port == "pc")
                name = "name";
            else
                name = "mobile_name";
        }
        else if (lang == "en")
        {
            if (port == "pc")
                name = "name_en";
            else
                name = "mobile_name_en";
        }
        else
        {
            return;
        }
        string strSql = "select id," + name + " from tb_goods_category where parent_id = " + pid + " order by " + name;
        DataTable dt = QGYHelper.DataBase.DbHelperSQL.Query(strSql).Tables[0];
        System.Text.StringBuilder sbHtml = new System.Text.StringBuilder();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string id = dt.Rows[i]["id"].ToString();
            string value = dt.Rows[i][name].ToString();
            sbHtml.Append("{\"id\":\"" + id + "\",\"name\":\"" + QGYHelper.FormatCode.FormatUrlEncode(value) + "\",\"state\":\"1\"}");
            if (i < dt.Rows.Count - 1)
                sbHtml.Append(",");
        }
        Callback("[" + sbHtml.ToString() + "]");
    }

    #endregion

    #region 商户登录（通过邮箱地址或手机号码登录）         

    /// <summary>
    /// 商户登录（返回信息{result:1 成功 0 失败,userid:登录成功用户ID,step:注册步骤（1 卖家协议 2 卖家信息 3 账单/存款 4 税务信息 5 商品信息 6 完成注册）}）
    /// </summary>
    /// <param name="account">邮箱地址或手机号码</param>
    /// <param name="pwd">密码</param>
    /// <param name="stu_account">学生账号</param>
    /// <param name="trainingmode">实训模式（1 单项 2 综合）</param>
    [WebMethod(EnableSession = true)]
    public void SellerLogin(string account, string pwd, int stuid, int trainingmode)
    {
        int result = 0, userID = 0, step = 0;
        //返回错误信息
        string error = string.Empty;
        if (userBLL.Login(account, pwd, stuid, trainingmode, ref userID, ref step, ref error))
        {
            result = 1;
        }
        Callback("{\"result\":\"" + result + "\",\"userid\":\"" + userID + "\",\"step\":\"" + step + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }

    #endregion 

    #region 商户找回密码之验证账号（通过邮箱地址或手机号码找回密码）

    /// <summary>
    /// 找回密码之验证账号（返回信息{result:1 存在 0 不存在,token:账户标志}）
    /// </summary>
    /// <param name="account">邮箱地址或手机号码</param>
    /// <param name="stuid">学生账号</param>
    /// <param name="trainingmode">实训模式（1 单项 2 综合）</param>
    [WebMethod(EnableSession = true)]
    public void SellerForgotPassword1(string account, int stuid, int trainingmode)
    {
        int result = 0;
        string token = string.Empty;
        string email = string.Empty;
        string error = string.Empty;

        //通过账号查询账户标志和邮箱
        if (userBLL.GetUserInfo(account, stuid, trainingmode, ref result, ref token, ref email, ref error))
        {
            //201801@qgy.com
            //发送找回密码链接地址给用户邮箱 携带用户id
            if (QGYHelper.EmailHelper.FindPassword(token, email, ref error))
                result = 1;
            else
                token = string.Empty;
        }
        Callback("{\"result\":\"" + result + "\",\"token\":\"" + token + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }
    #endregion

    #region 商户找回密码之修改密码（通过token修改密码）

    /// <summary>
    /// 找回密码之修改密码（返回信息{result:1 成功 0 失败}）
    /// </summary>
    /// <param name="token">账户标志</param>
    /// <param name="pwd">密码</param>
    [WebMethod(EnableSession = true)]
    public void SellerForgotPassword2(string token, string pwd)
    {
        int result = 0;
        string error = string.Empty;
        //通过token修改密码    根据传来的token 给pwd 赋值
        if (userBLL.UpdatePwd(token, pwd))
            result = 1;
        else
            error = "修改密码失败";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }

    #endregion

    #region 商户注册（通过邮箱注册）

    /// <summary>
    /// 商户注册（返回信息{result:1 成功 0 失败}）
    /// </summary>
    /// <param name="name">姓名</param>
    /// <param name="email">邮箱地址</param>
    /// <param name="pwd">密码</param>
    /// <param name="stuid">学生ID</param>
    /// <param name="stuaccount">学生账号</param>
    /// <param name="trainingmode">实训模式（1 单项 2 综合）</param>
    [WebMethod(EnableSession = true)]
    public void SellerRegister(string name, string email, string pwd, int stuid, string stuaccount, int trainingmode)
    {
        int result = 0;
        string token = string.Empty;
        string error = string.Empty;
        using (TransactionScope trans = new TransactionScope())
        {
            try
            {
                if (QGYHelper.EmailHelper.IsExist(email, ref error))
                {
                    //判断邮箱是否存在 
                    if (userBLL.SelectEmail2(email, stuid))
                    {
                        //获得新用户标志（token）
                        token = System.Guid.NewGuid().ToString("N").ToUpper();
                        //初始化相关表数据（店铺表tb_virtual_shop，用户通知选项 tb_user_notificationoptions，用户配送设置 tb_user_shippingsettings，用户退货设置 tb_user_returnsettings）
                        if (shopBLL.Pro_initial_shop(name, pwd, email, token, stuid, stuaccount, trainingmode) == 0)
                        {
                            result = 1;
                            trans.Complete();
                        }
                        else
                        {
                            trans.Dispose();
                            token = string.Empty;
                            error = "初始化失败,请重新注册";
                        }
                    }
                    else
                    {
                        error = "注册失败，邮箱已存在或学生账号已存在";
                        token = string.Empty;
                    }
                }
                else
                    error = "注册失败，邮箱账号不存在";

            }
            catch (Exception e)
            {
                error = e.Message;
                token = string.Empty;
            }
        }
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",\"token\":\"" + QGYHelper.FormatCode.FormatUrlEncode(token) + "\"}");
    }

    #endregion

    #region 查询商户编号
    /// <summary>
    /// 查询商户编号
    /// <param name="stuid">学生编号</param>
    /// <param name="trainingmode">实训模式（0 单项 1 综合）</param>
    /// <summary>
    [WebMethod(EnableSession = true)]
    public void GetUserID(int stuid, int trainingmode)
    {
        string error=string.Empty;
        int result = 0, userid = 0, isfinished = 0;
        int step = 0;
        if (userBLL.GetUserID1(stuid, trainingmode, ref userid, ref isfinished, ref error,ref step) == false)
        {
            error = "请输入正确的学生编号与实训类型";
        }
        else
        {
            result = 1; 
        }
        Callback("{\"result\":\"" + result + "\",\"user_id\":\"" + userid + "\",\"isfinished\":\"" + isfinished + "\",\"step\":\"" + step + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }
    #endregion

    #region 商户注册之卖家协议

    /// <summary>
    /// 商户注册之卖家协议（返回信息{result:1 成功 0 失败}）
    /// </summary>
    /// <param name="userid">用户ID</param>
    /// <param name="legalname">法人</param>
    [WebMethod(EnableSession = true)]
    public void SellerRegister1(int userid, string legalname)
    {
        int result = 0;
        string error = string.Empty;
        //修改用户法人信息
        if (userBLL.Updatelegalname(userid, legalname))
            //修改注册步骤为1
            result = 1;
        else
            error = "修改失败，请正确填写法人信息。";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }

    #endregion

    #region 初始化卖家协议
    /// <summary>
    /// 初始化卖家协议（返回法人）
    /// </summary>
    /// <param name="userid">用户编号</param>
    [WebMethod(EnableSession = true)]
    public void GetSellerRegister1(int userid)
    {
        int result = 0;
        string error = string.Empty;
        string legal_name = string.Empty;//法人信息
        int? step = 0;
        //根据用户编号获取法人信息
        userBLL.GetUserLegal_Name(userid, ref  legal_name, ref  result, ref  error,ref step);
        Callback("{\"result\":\"" + result + "\",\"legal_name\":\"" + QGYHelper.FormatCode.FormatUrlEncode(legal_name) + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",\"step\":\""+step+"\"}");
    }
    #endregion

    #region 商户注册之卖家信息

    /// <summary>
    /// 商户注册之卖家信息（返回信息{result:1 成功 0 失败}）
    /// </summary>
    /// <param name="userid">用户ID</param>
    /// <param name="address">街道地址</param>
    /// <param name="city">市/镇</param>
    /// <param name="province">州/地区/省</param>
    /// <param name="country">国家/地区</param>
    /// <param name="zipcode">邮编</param>
    /// <param name="storename">店铺名称</param>
    /// <param name="website">商品网址</param>
    /// <param name="mobile">电话号码</param>
    /// <param name="id">判断操作状态（0注册，1修改）</param>
    /// <param name="address_id">初始化返回的地址编号（注册填写0）</param>
    [WebMethod(EnableSession = true)]
    public void SellerRegister2(int userid, string address, string city, string province, string country, string zipcode, string storename, string website, string mobile, int id, int address_id)
    {
        int result = 0;
        string error = string.Empty;

            if (id == 0) //注册卖家信息
            {
                addressBLL.Pro_initial_address(userid, address, city, province, country, zipcode, storename, website, mobile, ref result, ref error);
                Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
            }
            else //修改卖家信息
            {
                if (address_id > 0)
                {
                    addressBLL.Proc_Update_user_address(userid, address, city, province, country, zipcode, storename, website, mobile, ref result, ref error, address_id);
                    Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
                }
                else
                {
                    error = "address_id为初始化返回的地址编号";
                    Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
                }
            }
    }
    #endregion

    #region  初始化商户注册之卖家信息
    /// <summary>
    /// 初始化商户注册之卖家信息
    /// </summary>
    /// <param name="userid">用户编号</param>
    [WebMethod(EnableSession = true)]
    public void GetSellerRegister2(int userid)
    {
        int result = 0;
        string error = string.Empty;
        string website = string.Empty;
        string storename = string.Empty;
        //1,获取 website 永久地址ID
        int? addressId = 0;
        int? step = 0;
            userBLL.GetWebsite(userid, ref  website, ref  addressId,ref step);
            if (addressId != 0 && addressId != null)
            {
                //2,获取shopname
                shopBLL.GetStorename(userid, ref storename);
                int address_id = (int)addressId;
                if (address_id != 0)
                {
                    //3,获取地址详情
                    string str = addressBLL.GetAddress(address_id);
                    result = 1;
                    Callback("{\"result\":\"" + result + "\",\"step\":\""+step+"\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",\"website\":\"" + QGYHelper.FormatCode.FormatUrlEncode(website) + "\",\"storename\":\"" + QGYHelper.FormatCode.FormatUrlEncode(storename) + "\"," + str + "}");
                }
                else
                {
                    Callback("{\"result\":\"" + result + "\",\"step\":\"" + step + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
                }
            }
            else
            {
                error = "用户表里缺少永久地址";
                Callback("{\"result\":\"" + result + "\",\"step\":\"" + step + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",\"address_id\":\"0\"}");
            }
    }

    #endregion

    #region 初始化商户注册之账单存款
    /// <summary>
    /// 初始化商户注册之账单存款
    /// </summary>
    /// <param name="userid">用户编号</param>
    [WebMethod(EnableSession = true)]
    public void GetSellerRegister3(int userid)
    {
        int result = 0;
        string error = string.Empty;
        //根据userid  去用户表查询  收款id和付款id 永久地址ID
        int? chargeId = 0;//收款方式ID
        int? depositId = 0;//付款方式ID
        int? registered_address = 0;
        string Str = string.Empty;
        int? step = 0;
        userBLL.GetMethonId(userid, ref chargeId, ref depositId, ref error, ref registered_address, ref step);
        string strAddress = string.Empty;
        string strCharge = string.Empty;
        string strDeposit = string.Empty;

        if (step >= 3)
        {
            if (chargeId != null && chargeId != 0)
            {
                result = 1;
                string addrID = string.Empty;
                strCharge = chargeBLL.GetChargeInfo(chargeId, ref addrID);
                registered_address = int.Parse(addrID);
                strDeposit = depositBLL.GetDepositInfo(depositId);
            }
        }
        strAddress = GetAddressId(Convert.ToInt32(registered_address)); 
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",\"data\":{\"step\":\"" + step + "\",\"address\":{" + strAddress + "},\"charge\":{" + strCharge + "},\"deposit\":{" + strDeposit + "}}}");
    }

    #endregion

    #region 商户注册之账单存款
    /// <summary>
    /// 商户注册之账单存款（返回信息{result:1 成功 0 失败}）
    /// </summary>
    /// <param name="userid">用户ID</param>
    /// <param name="card_number">信用卡号</param>
    /// <param name="card_month">有效期限（月）</param>
    /// <param name="card_year">有效期限（年）</param>
    /// <param name="card_holder">持卡人姓名</param>
    /// <param name="addressid">账单地址ID</param>
    /// <param name="address">街道地址</param>
    /// <param name="city">市/镇</param>
    /// <param name="province">州/地区/省</param>
    /// <param name="country">国家/地区</param>
    /// <param name="zipcode">邮编</param>
    /// <param name="bank_location">银行地址</param>
    /// <param name="account_holder">账户持有人姓名</param>
    /// <param name="routing_number">9 位数的汇款路径号码</param>
    /// <param name="account_number">银行账号</param>
    /// <param name="id">区分注册还是更新（0注册，1更新）</param>
    [WebMethod(EnableSession = true)]
    public void SellerRegister3(int userid, string card_number, int card_month, int card_year, string card_holder, int addressid, string address, string city, string province, string country, string zipcode, string bank_location, string account_holder, string routing_number, string account_number,int id)
    {
        if (id == 0)
        {
            int result = 0;
            
            string error = "操作失败";
            if (addressBLL.Pro_initial_Charge_deposit(userid, card_number, card_month, card_year, card_holder, addressid, address, city, province, country, zipcode, bank_location, account_holder, routing_number, account_number) == 0)
            {
                result = 1;
                error = "";
            }
            Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
        }
        else
        {
            int result = 0;
            string error = "操作失败";
            int? chargeId = 0;//收款方式ID
            int? depositId = 0;//付款方式ID
            int? registered_address = 0;
            int? step = 0;
            if (addressid > 0)
            {
                userBLL.GetMethonId(userid, ref chargeId, ref depositId, ref error, ref registered_address, ref step);
                if (addressBLL.Proc_update_Charge_deposit(userid, card_number, card_month, card_year, card_holder, addressid, address, city, province, country, zipcode, bank_location, account_holder, routing_number, account_number, chargeId, depositId) == 0)
                {
                    result = 1;
                    error = "";
                }
                Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
            }
            else 
            {
                error = "addressid为初始化返回的地址编号address_id";
                Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
            }
        }
    }
    #endregion

    #region 商户注册之税务信息
    /// <summary>
    /// 商户注册之税务信息（返回信息{result:1 成功 0 失败}）
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
    /// <param name="id">区分注册还是更新（0注册，1更新）</param>
    [WebMethod(EnableSession = true)]
    public void SellerRegister4(int userid, int receive_income, int is_usperson, string company_name, string nationality, int owner_type, int address_id, int mailing_address_id, int is_esignature,int tax_id,int id,string signature)
    {
        int result = 0;
        string error = string.Empty;

            if (id == 0)//注册
            {
                using (TransactionScope trans = new TransactionScope())
                {
                    try
                    {
                        //新增税务信息
                        if (user_taxBLL.AddUser_tax(userid, receive_income, is_usperson, company_name, nationality, owner_type, address_id, mailing_address_id, is_esignature) != 0)
                        {
                            //修改注册步骤为4
                            if (userBLL.UpadteUser_tax(userid))
                            {
                                result = 1;
                                trans.Complete();
                            }
                            else
                            {
                                trans.Dispose();
                                error = "修改步骤失败";
                            }
                        }
                        else
                        {
                            trans.Dispose();
                            error = "新增失败";
                        }
                    }
                    catch (Exception e)
                    {
                        error = e.Message;
                    }
                }
                Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
            }
            else  //更新税务信息
            {
                error = "更新税务信息失败";
                if (tax_id > 0)
                {
                    if (user_taxBLL.Updatetax(tax_id, receive_income, is_usperson, company_name, nationality, owner_type, address_id, mailing_address_id, is_esignature, userid, signature))
                    {
                        result = 1;
                        error = "";
                    }
                    Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
                }
                else
                {
                    error = "税务信息编号必须大于零，为初始化返回税务tax_id";
                    Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
                }
            }
    }

    #endregion

    #region 初始化商户注册之税务信息
    /// <summary>
    /// 初始化商户注册之税务信息
    /// </summary>
    /// <param name="userid">用户编号</param>
    [WebMethod(EnableSession = true)]
    public void GetSellerRegister4(int userid)
    {
        string strTax = string.Empty;
        int result = 0;
        string error = string.Empty;
        int? address_id = 0;//税务永久地址ID
        int? mailing_address_id = 0;//税务邮寄地址ID
        int? chargeId =0, depositId = 0,registered_address = 0,step = 0;
        userBLL.GetMethonId(userid, ref chargeId, ref depositId, ref error, ref registered_address, ref step);
            //根据用户ID 查询 税务详情和永久地址ID和邮寄地址ID
            user_taxBLL.GetTaxInfo(userid, ref strTax, ref address_id, ref mailing_address_id);
            int address_id1 = (int)address_id;
            int mailing_address_id1 = (int)mailing_address_id;
            if (address_id1 != 0)
            {
                if (strTax == "")
                {
                    error = "没有查到相应数据,请先添加税务信息";
                    Callback("{\"result\":\"" + result + "\",\"step\":\"" + step + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
                }
                else if (address_id == mailing_address_id)
                {
                    result = 1;
                    //永久地址ID与邮寄地址ID相同
                    string str = GetAddressId(address_id1);
                    strTax = "{" + "\"result\":\"" + result + "\",\"step\":\""+step+"\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"," + strTax + "," + "\"List\":[{" + str + "}]" + "," + "\"List2\":[{" + str + "}]}";
                }
                else
                {
                    result = 1;
                    string str = GetAddressId(address_id1);
                    string str2 = GetAddressId(mailing_address_id1);
                    strTax = "{" + "\"result\":\"" + result + "\",\"step\":\""+step+"\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"," + strTax + "," + "\"List\":[{" + str + "}]" + "," + "\"List2\":[{" + str2 + "}]}";
                }
                Callback(strTax);
            }
            else
            {
                error = "没有查询到相应的数据，请先注册税务信息";
                Callback("{\"result\":\"" + result + "\",\"step\":\"" + step + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
            }
    }
    #endregion

    #region 商户注册之商品信息

    /// <summary>
    /// 商户注册之商品信息（返回信息{result:1 成功 0 失败}）
    /// </summary>
    /// <param name="userid">用户ID</param>
    /// <param name="is_product_upc">是否都有产品编码（1 是 0 否）</param>
    /// <param name="is_product_brand">是否所销售商品的制造商或品牌商（1 是 0 否）</param>
    /// <param name="product_list">预计发布产品数量（1 1~10 2 11~100 3 101~500 4 500以上）</param>
    [WebMethod(EnableSession = true)]
    public void SellerRegister5(int userid, int is_product_upc, int is_product_brand, int product_list)
    {
        int result = 0;
        string error = string.Empty;
            //修改相关信息  5
            if (userBLL.UpdateCommodityInfo(userid, is_product_upc, is_product_brand, product_list))
            {
                result = 1;
            }
            else
                error = "商品信息修改失败";
            Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }

    #endregion

    #region 初始化商品信息
    /// <summary>
    /// 初始化商品信息
    /// </summary>
    /// <param name="userid">用户编号</param>
    [WebMethod(EnableSession = true)]
    public void GetSellerRegister5(int userid)
    {
        int result = 0;
        string error = string.Empty;
        int? is_product_upc = 0, is_product_brand = 0, product_list = 0, step = 0;
        userBLL.GetCommodityInfo(userid,ref is_product_upc,ref is_product_brand, ref product_list,ref step);
        if (is_product_upc != null && is_product_brand != null && product_list != null)
        {
            result = 1;
        }
        else
            error = "请先填写商品信息";
        Callback("{\"result\":\"" + result + "\",\"step\":\"" + step + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }
    #endregion

    #region 商户注册之提交完成

    /// <summary>
    /// 商户注册之提交完成（返回信息{result:1 成功 0 失败}）
    /// </summary>
    /// <param name="userid">用户ID</param>
    /// <param name="categories">选择的分类ID（用英文逗号分隔开）</param>
    /// <param name="categoryname">自定义分类名称</param>
    [WebMethod(EnableSession = true)]
    public void SellerRegister6(int userid, string categories, string categoryname)
    {
        int result = 0;
        string error = string.Empty;
            //修改相关信息 修改注册步骤为6
        if (userBLL.UpdateCategory(userid, categories, categoryname))
        {
            result = 1;
        }
        else
            error = "修改步骤失败";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }

    #endregion

    #region 卖家身份验证

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
    [WebMethod(EnableSession = true)]
    public void SellerIdentityVerification(int userid, string country, int identity, string identity_file, int doc_type, string doc_file, string email, string phone, int sign)
    {
        int result = 0;
        string error = string.Empty;
  
            //保存验证信息 
            if (authentication_BLL.Add_authentication(userid, country, identity, identity_file, doc_type, doc_file, email, phone, sign) == 1)
            {
                result = 1;
                error = "";
            }
            else
                error = "保存验证信息失败";
        
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }

    #endregion

    #region 新增地址

    /// <summary>
    /// 新增地址（返回信息{result:1 成功 0 失败,addressid:地址ID}）
    /// </summary>
    /// <param name="userid">用户ID</param>
    /// <param name="address">街道地址</param>
    /// <param name="address2">公寓、楼层</param>
    /// <param name="city">市/镇</param>
    /// <param name="province">州/地区/省</param>
    /// <param name="country">国家/地区</param>
    /// <param name="zipcode">邮编</param> 
    /// <param name="type">地址类型（1,一般地址2，收货地址3，邮寄地址）</param>
    /// <param name="name">地址名称</param>
    /// <param name="email">邮箱地址</param>
    /// <param name="phone">手机号</param>
    /// <param name="full_name">联系人姓名</param>
    [WebMethod(EnableSession = true)]
    public void AddAddress(int userid, string address, string address2, string city, string province, string country, string zipcode, int type)
    {
        int result = 0, addressid = 0;
        string error = string.Empty;
        //新增地址并获取地址ID 
        addressid = addressBLL.AddAddress2(userid, address, address2, city, province, country, zipcode, ref addressid, type);
        if (addressid > 0)
        {
            result = 1;
        }
        else
            error = "新增地址失败";
        Callback("{\"result\":\"" + result + "\",\"addressid\":\"" + addressid + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }

    #endregion

    #region 新增地址 最新

    /// <summary>
    /// 新增地址（返回信息{result:1 成功 0 失败,addressid:地址ID}）
    /// </summary>
    /// <param name="userid">用户ID</param>
    /// <param name="address">街道地址</param>
    /// <param name="address2">公寓、楼层</param>
    /// <param name="city">市/镇</param>
    /// <param name="province">州/地区/省</param>
    /// <param name="country">国家/地区</param>
    /// <param name="zipcode">邮编</param> 
    /// <param name="type">地址类型（1,一般地址2，收货地址3，邮寄地址）</param>
    /// <param name="name">地址名称</param>
    /// <param name="email">邮箱</param>
    /// <param name="phone">手机号</param>
    /// <param name="full_name">联系人姓名</param>
    [WebMethod(EnableSession = true)]
    public void AddAddressNew(int userid, string address, string address2, string city, string province, string country, string zipcode, int type, string name, string email, string phone, string full_name)
    {
        int result = 0, addressid = 0;
        string error = string.Empty;
        //新增地址并获取地址ID 
        addressid = addressBLL.AddAddressNew(userid, address, address2, city, province, country, zipcode, ref addressid, type, name, email, phone, full_name);
        if (addressid > 0)
        {
            result = 1;
        }
        else
            error = "新增地址失败";
        Callback("{\"result\":\"" + result + "\",\"addressid\":\"" + addressid + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }

    #endregion

    #region 获得用户地址列表

    /// <summary>
    /// 获得用户地址列表（返回信息[{name:地址名称,country:国家,address:街道地址,address2:公寓,city:城市,province:省份,zipcode:邮编,fullname:联系人姓名,phone:联系电话,email:电子邮件地址}]）
    /// </summary>
    /// <param name="userid">用户ID</param>
    /// <param name="sign">标识（0 所有地址 1 一般地址 2 退货地址 3 配送地址）</param>
    [WebMethod(EnableSession = true)]
    public void GetAddressList(int userid, int sign)
    {
        string str = addressBLL.GetList(userid, sign);
        Callback(str);
    }

    #endregion

    #region 检查商店名称是否重复
    /// <summary>
    /// 检查商铺名称是否重复
    /// </summary>
    /// <param name="user_id">用户编号</param>
    /// <param name="shopname">商铺名称</param>

    [WebMethod(EnableSession = true)]
    public void GetShopName(int userid,string shopname)
    {
        int result = 1;
        string error=string.Empty;
        if (shopBLL.GetShopName(userid, shopname))
        {
            result = 0;
            error = "商铺名称重复";
        }
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }
    #endregion

    #region 初始化商户永久地址
    /// <summary>
    /// 初始化商户永久地址（返回详细地址数据）
    /// </summary>
    /// <param name="address_id">地址编号</param>
    [WebMethod(EnableSession = true)]
    public string GetAddressId(int address_id)
    {
        return addressBLL.GetAddress(address_id);
    }
    #endregion

    #endregion

    #region 卖家账户信息-------------------------------------

    #region ------------------------------------------------------------------卖家信息
    #endregion 

    #region  获取卖家详细信息
    /// <summary>
    /// 获取卖家详细信息
    /// </summary>
    /// <param name="userid">用户编号</param>
    [WebMethod(EnableSession = true)]
    public void GetShopInfo(int userid)
    {
        int result = 1;
        string error = string.Empty;
        string Str = string.Empty;
        Str = shopBLL.GetShopInfo(userid, ref Str);
        if (Str == string.Empty)
        {
            result = 0;
            error = "获取卖家信息出错，请输入商户编号";
        }
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",\"data\":{" + Str + "}}");
    }
    #endregion

    #region 修改店铺详情
    /// <summary>
    /// 修改店铺名称和店铺链接
    /// </summary>
    /// <param name="userid">商户编号</param>
    /// <param name="shop_name">店铺名称</param>
    /// <param name="shop_link">店铺链接</param>
    [WebMethod(EnableSession = true)]
    public void UpdateStoreDetails(int userid, string shop_name, string shop_link)
    {
        int result = 0;
        string error = "请重新输入店铺名称和店铺链接";
        if (shopBLL.UpdateStoreDetails(userid, shop_name, shop_link))
        {
            result = 1;
            error = string.Empty; ;
        }
        Callback("{\"result\":\""+result+"\",\"error\":\""+QGYHelper.FormatCode.FormatUrlEncode(error)+"\"}");
    }

    #endregion

    #region 修改客户服务详细信息
    /// <summary>
    /// 修改客户服务详细信息
    /// </summary>
    /// <param name="userid">商户编号</param>
    /// <param name="service_email">客户服务电子邮件</param>
    /// <param name="service_phone">客服电话</param>
    /// <param name="service_reply_email">客服回复电子邮件</param>
    [WebMethod(EnableSession = true)]
    public void UpdateServiceDetails(int userid, string service_email, string service_phone, string service_reply_email)
    {
        int result = 0;
        string error = string.Empty;

        if (shopBLL.ServiceDetails(userid, service_email, service_phone, service_reply_email))
            result = 1;
        else
            error = "请重新输入客服邮件";
        Callback("{\"resut\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }
    #endregion

    #region ------------------------------------------------------------------存款信息
    #endregion

    #region 初始化存款方式
    /// <summary>
    /// 初始化存款方式
    /// </summary>
    /// <param name="userid">用户编号</param>
    [WebMethod(EnableSession = true)]
    public void InitializaDeposit(int userid)
    {
        int result = 1;
        string error = string.Empty;
        //获取用户表里的存款ID
         int? depositId = 0, chargeId = 0;
        userBLL.GetMethonId(userid, ref chargeId, ref depositId);
        //根据存款ID查询信息
        string strDeposit = depositBLL.GetDepositInfo(depositId);
        if (strDeposit == "")
        {
            result = 0;
            error = "请先添加存款方式";
        }
        Callback("{\"result\":\""+result+"\",\"error\":\""+QGYHelper.FormatCode.FormatUrlEncode(error)+"\",\"data\":{"+strDeposit+"}}");
    }
    #endregion

    #region 初始化全部存款方式

    /// <summary>
    /// 初始化全部存款方式
    /// </summary>
    /// <param name="userid">商户编号</param>
    [WebMethod(EnableSession = true)]
    public void InitializaDeposit2(int userid)
    {
        int result = 0;
        string error = string.Empty;
        int? chargeId = 0, depositId = 0;
        string strDeposit = string.Empty;
        //获取用户表里的存款ID
        userBLL.GetMethonId(userid, ref chargeId, ref depositId);
        if (depositId != null && depositId != 0)
        {
            result = 1;
            //获取存款表里对应数据
            strDeposit = depositBLL.GetDepositInfoList(userid);
        }
        else
            error = "初始化信息失败。请稍后重试";

       Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",\"SelectMethod_id\":\"" + depositId + "\",\"strDeposit\":" + strDeposit + "}");
    }
    #endregion

    #region 设置存款方式
    /// <summary>
    /// 设置存款方式
    /// </summary>
    /// <param name="userid">用户编号</param>
    /// <param name="method_id">存款方式编号</param>
    /// <param name="account_number">银行卡号</param>
    [WebMethod(EnableSession = true)]
    public void SetDepositMade(int userid, int method_id, string account_number)
    {
        int result = 0;
        string error = string.Empty;
        string number = string.Empty;
        //查询相应银行卡号是否存在，
        depositBLL.GetModel(method_id, ref number);
        if (number == string.Empty && number == "0")
        {
            error = "请重新选址要分配的存款方式";
        }
        else if (account_number != number)
        {
            error = "请检查银行卡号是否正确";
        }
        else
        {
            //更新用户表存款编号
            if (userBLL.UpdateUserDepositId(userid, method_id))
                result = 1;
        }
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }

    #endregion

    #region 新增存款方式
    /// <summary>
    /// 新增付款方式
    /// </summary>
    /// <param name="userid">用户编号</param>
    /// <param name="bank_location">银行所在地</param>
    /// <param name="account_name">账户持有人姓名</param>
    /// <param name="routing_number">银行识别代码</param>
    /// <param name="account_number">银行账号</param>
    [WebMethod(EnableSession = true)]
    public void AddDepositMethod(int userid, string bank_location, string account_name, string routing_number, string account_number)
    {
        int result = 0;
        string error = string.Empty;
        int mathod_id = 0;
        //新增一条数据
        mathod_id = depositBLL.AddDepositMethod(userid, bank_location, account_name, routing_number, account_number);
        if (mathod_id > 0)
            result = 1;
        else
            error = "服务器请求失败，请稍后提交";
        Callback("{\"result\":\"" + result + "\",\"mathod_id\":\"" + mathod_id + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }
    #endregion

    #region ------------------------------------------------------------------付费信息
    #endregion

    #region 初始化付费信息
    /// <summary>
    /// 初始化付费信息
    /// </summary>
    /// <param name="userid">用户编号</param>
    [WebMethod(EnableSession = true)]
    public void InitializaChargeInfo(int userid)
    {
        int result = 0;
        string error = string.Empty;
        //获取付款ID 和 邮寄地址ID
        int? depositId = 0, chargeId = 0;
        string billing_address_id = string.Empty;
        userBLL.GetMethonId(userid, ref chargeId, ref depositId);
        //根据chargeId查询详细信息和邮寄地址
        string strChargeInfo = chargeBLL.GetChargeMethod_id(chargeId, ref billing_address_id);
        //根据 billing_address_id查询账单详情地址
        string strAddressInfo = addressBLL.GetAddress2(int.Parse(billing_address_id));
        if (chargeId != 0 && billing_address_id != string.Empty && billing_address_id != "")
            result = 1;
        else
            error = "请填写正确的用户编号";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",\"data\":{\"strChargeInfo\":{" + strChargeInfo + "},\"strAddressInfo\":\"" + QGYHelper.FormatCode.FormatUrlEncode(strAddressInfo) + "\"}}");
    }
    #endregion

    #region  初始化信用卡列表
    /// <summary>
    /// 初始化付费方式(初始化信用卡列表)
    /// </summary>
    /// <param name="userid">用户编号</param>
    [WebMethod(EnableSession = true)]
    public void InitializaCharge(int userid)    
    {
        int result = 0;
        string error = string.Empty;
        //用户表里选中的ID
        int? depositId = 0, chargeId = 0;
        userBLL.GetMethonId(userid, ref chargeId, ref depositId);
        //获取信用卡列表
        string str = string.Empty;
        try
        {
            str = chargeBLL.GetChargeInfoList(userid);
            if (str != "" && str != string.Empty)
                result = 1;
            else
                error = "系统出错，请稍后重试";
        }
        catch (Exception e)
        {
            error = e.Message;
        }
        Callback("{\"result\":\"" + result + "\",\"chargeId\":\"" + chargeId + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",\"data\":[" + str + "]}");
    }
    #endregion

    #region 设置付款方式1
    /// <summary>
    /// 设置付款方式1
    /// </summary>
    /// <param name="userid">用户编号</param>
    /// <param name="method_id">付款方式ID</param>
    [WebMethod(EnableSession = true)]
    public void SetChargeMade(int userid, int method_id)  
    {
        int result = 0;
        string error = string.Empty;
        if (userBLL.UpdateUserChargeId(userid, method_id))
            result = 1;
        else
            error = "设置信用卡失败";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }
    #endregion

    #region 初始化账单寄送地址  GetAddressList
    #endregion

    #region 新增信用卡
    /// <summary>
    /// 新增信用卡
    /// </summary>
    /// <param name="userid">用户信息编号</param>
    /// <param name="card_number">信用卡号</param>
    /// <param name="valid_through_month">有效期限（月）</param>
    /// <param name="valid_through_year">有效期限（年）</param>
    /// <param name="card_holder_name">持卡人姓名</param>
    /// <param name="billing_address_id">邮寄地址ID</param>
    [WebMethod(EnableSession = true)]
    public void AddChargeMethod(int userid, string card_number, int valid_through_month, int valid_through_year, string card_holder_name, int billing_address_id)
    {
        int result = 0;
        string error = string.Empty;
        if (chargeBLL.AddChargeMethod(userid, card_number, valid_through_month, valid_through_year, card_holder_name, billing_address_id) != 0)
            result = 1;
        else
            error = "新增信用卡失败";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",}");

    }
    #endregion 

    #region 新增地址返回地址ID  AddAddressNew
    #endregion

    #region 初始化用户所有信用卡（管理付款方式）  InitializaCharge
    #endregion

    #region 编辑付款方式（初始化信息）
    /// <summary>
    /// 编辑付款方式（初始化信息）
    /// </summary>
    /// <param name="method_id">存款编号</param>
    [WebMethod(EnableSession = true)] 
    public void GetChargeInfo(int method_id)
    {
        int result = 0;
        string error = string.Empty;
        string billing_address_id = string.Empty;
        string str = chargeBLL.GetChargeMethod_id(method_id, ref billing_address_id);
        if (str != string.Empty)
            result = 1;
        else
            error = "初始化信用卡信息错误";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",\"data\":{" + str + "}}");
    }
    #endregion

    #region  更新编辑付款方式信息 
    /// <summary>
    /// 更新编辑付款方式信息
    /// </summary>
    /// <param name="method_id">存款编号</param>
    /// <param name="userid">用户编号</param>
    /// <param name="card_number">信用卡号</param>
    /// <param name="valid_through_month">有效期限（月）</param>
    /// <param name="valid_through_year">有效期限（年）</param>
    /// <param name="card_holder_name">持卡人姓名</param>
    /// <param name="billing_address_id">邮寄地址ID</param>
    [WebMethod(EnableSession = true)]
    public void UpdateChargeInfo(int method_id, int userid, string card_number, int valid_through_month, int valid_through_year, string card_holder_name, int billing_address_id)
    {
        int result=0;
        string error=string.Empty;
        if (chargeBLL.UpdateChargeInfo(method_id, userid, card_number, valid_through_month, valid_through_year, card_holder_name, billing_address_id))
            result = 1;
        else
            error = "修改信用卡信息失败，请正确填写信用卡信息";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",}");
    }
    #endregion 

    #region ------------------------------------------------------------------业务信息
    #endregion
    
    #region 办公地址
    /// <summary>
    /// 办公地址
    /// </summary>
    /// <param name="userid">用户编号</param>
    [WebMethod(EnableSession = true)]
    public void GetBusinessInfo(int userid)
    {
        int result = 0;
        string name = string.Empty, token = string.Empty, error = string.Empty;
        int? business_address = 0, registered_address = 0;
        userBLL.GetCompanyInfo(userid, ref business_address, ref registered_address, ref name, ref token);
        //根据办公地址 获取地址详情
        string strAddress = GetAddressId((int)business_address);
        if (strAddress != "")
            result = 1;
        else
            error = "获取地址失败。请检查用户编号是否输入错误";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",\"strAddress\":{" + strAddress + "}}");
    }

    #endregion

    #region  选择办公地址(初始化办公地址)  GetAddressList
    #endregion

    #region 添加新地址   AddAddressNew
    #endregion

    #region 提交操作  (更新用户表里的办公地址ID)
    /// <summary>
    /// 更新用户表里的办公地址
    /// </summary>
    /// <param name="userid">用户编号</param>
    /// <param name="addressId">办公地址编号</param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public void UpdateBusinessAddress(int userid, int addressId)
    {
        int result = 0;
        string error = string.Empty;
        if (userBLL.UpdateBusinessAddress(userid, addressId))
            result = 1;
        else
            error = "修改失败，请输入正确的地址编号";
        Callback("{\"result\":\""+result+"\",\"error\":\""+QGYHelper.FormatCode.FormatUrlEncode(error)+"\"}");
    }
    #endregion 

    #region 公司名称和注册地址     GetUserTax(userid)
    /// <summary>
    /// 公司名称和注册地址
    /// </summary>
    /// <param name="userid">用户编号</param>
    //[WebMethod(EnableSession = true)]
    public void GetShopNameRegister(int userid)
    {
        int result = 0;
        string name = string.Empty, token = string.Empty, error = string.Empty;
        int? business_address = 0, registered_address = 0;
        userBLL.GetCompanyInfo(userid, ref business_address, ref registered_address, ref name, ref token);
        //根据办公地址 获取地址详情
        string strAddress = GetAddressId((int)registered_address);
        if (strAddress != "")
            result = 1;
        else
            error = "获取地址失败。请检查用户编号是否输入错误";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",\"strAddress\":{" + strAddress + "}}");
    }

    #endregion

    #region  正确注册地址(初始化正式注册地址)  GetAddressList
    #endregion

    #region 添加新地址   AddAddressNew
    #endregion

    #region 更新用户表里注册地址(保存)

    /// <summary>
    /// 更新用户表里注册地址(保存)
    /// </summary>
    /// <param name="userid">用户编号</param>
    /// <param name="addressId">注册地址编号</param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public void UpdateRegisteredAddress(int userid, int addressId)
    {
        int result = 0;
        string error = string.Empty;
        if (userBLL.UpdateRegisteredAddress(userid, addressId))
            result = 1;
        else
            error = "修改失败，请输入正确的地址编号";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }

    #endregion 

    #region 取消操作
    /// <summary>
    /// 取消操作
    /// </summary>
    /// <param name="userid">用户编号</param>
    [WebMethod(EnableSession = true)]
    public void CancelOperation(int userid)
    {
        int result = 0;
        string name = string.Empty, token = string.Empty, error = string.Empty;
        int? business_address = 0, registered_address = 0;
        userBLL.GetCompanyInfo(userid, ref business_address, ref registered_address, ref name, ref token);
        //根据办公地址 获取地址详情
        string strAddress = GetAddressId((int)registered_address);
        if (strAddress != "")
            result = 1;
        else
            error = "获取地址失败。请检查用户编号是否输入错误";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",\"strAddress\":{" + strAddress + "}}");
    }

    #endregion

    #region 您的卖家标志
    /// <summary>
    /// 您的卖家标志
    /// </summary>
    /// <param name="userid">用户编号</param>
    [WebMethod(EnableSession = true)]
    public void GetToken(int userid)
    {
        int result = 0;
        string name = string.Empty, token = string.Empty, error = string.Empty;
        int? business_address = 0, registered_address = 0;
        userBLL.GetCompanyInfo(userid, ref business_address, ref registered_address, ref name, ref token);
        if (token != string.Empty)
            result = 1;
        else
            error = "获取商家标志出错，请检查后重新提交";
        Callback("{\"result\":\"" + result + "\",\"token\":\"" + token + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }
    #endregion

    #region ------------------------------------------------------------------退货设置
    #endregion

    #region  初始化常规设置(点击退货设置进来初始化的页面）
    /// <summary>
    /// 初始化常规设置
    /// </summary>
    /// <param name="usesrid">用户编号</param>
    [WebMethod(EnableSession = true)]
    public void GetReturnSettings(int userid)
    {
        int result = 0;
        string error = string.Empty, strReturnSettingInfo = string.Empty;
        if (returnBLL.GetReturnSetting(userid, ref strReturnSettingInfo) != "")
            result = 1;
        else
            error = "初始化退货设置失败";
        Callback("{\"result\":\""+result+"\",\"error\":\""+QGYHelper.FormatCode.FormatUrlEncode(error)+"\",\"data\":{"+strReturnSettingInfo+"}}");
    }


    #endregion

    #region 常规设置（更新常规设置）
    /// <summary>
    /// 常规设置（更新常规设置）
    /// </summary>
    /// <param name="userid">用户ID</param>
    /// <param name="email_format">是否接收退货申请电子邮件（1 是 0 否）</param>
    /// <param name="return_rule">退货规则（1 用户自动批准 2 平台自动批准符合条件 3 平台批准所有申请）</param>
    /// <param name="return_window">退货期限（天）</param>
    /// <param name="setting_number">商品退货批准编号设置（1 自动生成 2 自定义）</param>
    [WebMethod(EnableSession = true)]
    public void UpdateReturnsettings(int userid, int email_format, int return_rule, int return_window, int setting_number)
    {
        int result=0;
        string error=string.Empty;
        int? addressId = 0;
        //根据用户编号查询 tb_user_returnsettings.cs  默认地址是否为空 为空添加不成功
        returnBLL.SelectAddressId(userid, ref addressId);
        if (addressId != 0 && addressId != null)
        {
            //更新退货设置表
            returnBLL.UpdateReturnsettings(userid, email_format, return_rule, return_window,setting_number);
            result = 1;
        }
        else
            error = "设置退货设置时需提供退货地址。请转到退货地址设置以设置退货地址。";
        Callback("{\"result\":\""+result+"\",\"error\":\""+QGYHelper.FormatCode.FormatUrlEncode(error)+"\"}");
    }
    #endregion

    #region 常规设置(初始化默认退货地址)
    /// <summary>
    /// 常规设置(初始化默认退货地址)
    /// </summary>
    /// <param name="userid">用户编号</param>
    [WebMethod(EnableSession = true)]
    public void ReturnAddress(int userid)
    {
        int result = 0;
        string error = string.Empty, strAddress = string.Empty;
        int? addressId = 0;
        returnBLL.SelectAddressId(userid, ref addressId);
        if (addressId==0 || addressId == null)
            error = "请先添加退货地址";
        else
        {
            result = 1;
            strAddress = GetAddressId((int)addressId);
        }
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",\"strAddress\":{"+strAddress+"}}");
    }

    #endregion 

    #region 常规设置(初始化退货地址)  GetAddressList
    #endregion

    #region 常规设置(新增退货地址返回地址ID  AddAddressNew)
    #endregion

    #region 常规设置(设置默认地址）
    /// <summary>
    /// 常规设置(设置默认地址）
    /// </summary>
    /// <param name="userid">用户编号</param>
    /// <param name="addressId">地址编号</param>
    [WebMethod(EnableSession = true)]
    public void SettingDefaultAddress(int userid, int addressId)
    {
        int result=0;
        string error=string.Empty;
        if (returnBLL.SetDefaultAddress(userid, addressId))
            result = 1;
        else
            error = "设置默认地址失败，请重试";
        Callback("{\"result\":\""+result+"\",\"error\":\""+QGYHelper.FormatCode.FormatUrlEncode(error)+"\"}");
    }
    #endregion

    #region ------------------------------------------------------------------配送设置
    #endregion

    #region 配送设置（初始化详细信息）
    /// <summary>
    /// 配送设置（初始化详细信息）
    /// </summary>
    /// <param name="userid"></param>
    [WebMethod(EnableSession = true)]
    public void InitialShippingSettings(int userid)
    {
        int result = 0;
        string error = string.Empty, strSetting = string.Empty, strAddress = string.Empty;
        int? address_id = 0;
        //根据配送表里的配送ID获取地址数据
        shippingBLL.GetShippingSetAddressId(userid, ref address_id);
        if (address_id == null)
        {
            error = "请先填写配送地址";
            //获取配送信息详情
            strSetting = shippingBLL.GetShippingSettingsInfo(userid);
        }
        else
        {
            //获取配送信息详情
            strSetting = shippingBLL.GetShippingSettingsInfo(userid);
            //配送地址
            strAddress = GetAddressId((int)address_id);
            result = 1;
        }
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",\"data\":{\"strSetting\":{" + strSetting + "},\"strAddress\":{" + strAddress + "}}}");
    }
    #endregion 

    #region 配送设置（更新配送设置）
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
    [WebMethod(EnableSession = true)]
    public void UpdateShippingSetting(int userid, int standard_one, int standard_two, int expedited_one, int expedited_two, int twoday, int oneday, int international, int expedited)
    {
        int result = 0;
        string error = string.Empty;
        if (shippingBLL.UpdateShippingSetting(userid, standard_one, standard_two, expedited_one, expedited_two, twoday, oneday, international, expedited))
            result = 1;
        else
            error = "更新配送信息失败，请重试";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }

    #endregion

    #region 配送设置（初始化配送地址）  GetAddressList
    #endregion

    #region 配送设置（新增地址）  AddAddressNew
    #endregion

    #region 配送设置（设置配送地址为默认地址）  SetAddressDefault
    /// <summary>
    /// 设置配送地址为默认地址
    /// </summary>
    /// <param name="userid">用户编号</param>
    /// <param name="addressId">地址编号</param>
    [WebMethod(EnableSession = true)]
    public void SetAddressDefault(int userid,int addressId)
    {
        int result=0;
        string error=string.Empty;
        if (shippingBLL.SetAddressDefault(userid, addressId))
            result = 1;
        else
            error = "服务器出现错误,请重试";
        Callback("{\"result\":\""+result+"\",\"error\":\""+QGYHelper.FormatCode.FormatUrlEncode(error)+"\"}");
    }
    
    #endregion

    #region 配送设置（购买配送偏好设置）
    #endregion

    #region ------------------------------------------------------------------税务信息
    #endregion

    #region 法人实体(初始化税务信息)
    /// <summary>
    /// 法人实体(初始化税务信息)
    /// </summary>
    /// <param name="userid"></param>
    [WebMethod(EnableSession = true)]
    public void GetUserTax(int userid)
    {
        int result = 0, address_id = 0, tax_id = 0;
        string company_name = string.Empty, error = string.Empty;
        //获取address_id  和法定公司名称
        user_taxBLL.GetUerTaxInfo(userid, ref address_id, ref company_name, ref tax_id);
        //根据address_id获取地址详情
        string strAddress = string.Empty;
        if (address_id != 0)
        {
            strAddress = GetAddressId(address_id);
            result = 1;
        }
        else
            error = "初始化税务信息失败,请先添加税务信息";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",\"tax_id\":\"" + tax_id + "\",\"company_name\":\"" + QGYHelper.FormatCode.FormatUrlEncode(company_name) + "\",\"data\":{" + strAddress + "}}");
    }

    #endregion

    #region 更新税务信息（tax_id不变）
    #endregion

    #region ------------------------------------------------------------------通知首选项
    #endregion

    #region 初始化通知首选项（左上角第一个选项卡）
    /// <summary>
    /// 初始化通知首选项
    /// </summary>
    /// <param name="userid">用户编号</param>
    [WebMethod(EnableSession = true)]
    public void InitialPreference(int userid)
    {
        int result = 0;
        string email = string.Empty, strInfo = string.Empty, error = string.Empty, name = string.Empty;
        //获取用户登录邮箱
        userBLL.GetEmail(userid, ref email,ref name);
        //初始化 notificationoptions
       string str= noticeBLL.GetNotification(userid, ref strInfo);
       if (str != "")
           result = 1;
       else
           error = "初始化数据失败，请重试";
       Callback("{\"result\":\"" + result + "\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",\"data\":" + str + "}");
    }
    #endregion  

    #region 向用户联系人表里插入一条数据（订单通知栏里编辑按钮里的添加）
    /// <summary>
    /// 初始化用户联系人表
    /// </summary>
    /// <param name="userid">用户编号</param>
    [WebMethod(EnableSession = true)]
    public void InsertUserContacts(int userid)
    {
        int result = 0, contact_id = 0;
        string email = string.Empty, name = string.Empty, error = string.Empty;
        //从数据库里获取用户的 用户编号（user_id) 卖家默认联系人（name) 登录邮件（email) 
        userBLL.GetEmail(userid, ref email, ref name);
        //插入一条数据到用户联系人表里  
        contact_id = contacts_BLL.AddUserContacts(userid, name, email);
        //返回用户联系人ID  把用户联系人ID初始化到通知表里
        if (noticeBLL.UpdateContacts(userid, contact_id))
            result = 1;
        else
            error = "初始化用户联系人失败";
        Callback("{\"result\":\"" + result + "\",\"contact_id\":\"" + contact_id + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }

    #endregion

    #region 更新订单通知
    /// <summary>
    /// 更新订单通知
    /// </summary>
    /// <param name="userid">用户编号</param>
    /// <param name="order_sms_isopen">卖家订单通知之短信通知</param>
    /// <param name="order_sms_contact">短信联系人ID</param>
    /// <param name="order_isopen">卖家订单通知之邮箱通知</param>
    /// <param name="order_email">电子邮件</param>
    /// <param name="shipping_isopen">亚马逊物流订单通知</param>
    /// <param name="shipping_email">电子邮件</param>
    /// <param name="multichannel_isopen">多渠道配送通知</param>
    /// <param name="multichannel_email">电子邮件</param>
    /// <param name="shipment_isopen">货件已到达通知</param>
    /// <param name="shipment_email">电子邮件</param>
    /// <param name="problem_isopen">入库货件问题通知</param>
    /// <param name="problem_email">电子邮件</param>
    [WebMethod(EnableSession = true)]
    public void UpdateOrderNotification(int userid, int order_sms_isopen, int order_sms_contact, int order_isopen, string order_email, int shipping_isopen, string shipping_email, int multichannel_isopen, string multichannel_email, int shipment_isopen, string shipment_email, int problem_isopen, string problem_email)
    {
        int result = 0;
        string error = string.Empty;
        if (noticeBLL.UpdateOrderNotification(userid, order_sms_isopen, order_sms_contact, order_isopen, order_email, shipping_isopen, shipping_email, multichannel_isopen, multichannel_email, shipment_isopen, shipment_email, problem_isopen, problem_email))
            result = 1;
        else
            error = "更新订单通知失败。请注意邮件格式。";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }
    #endregion

    #region 更新订货和索赔通知
    /// <summary>
    /// 更新订货和索赔通知
    /// </summary>
    /// <param name="userid">用户ID</param>
    /// <param name="returns_isopen">待处理的退货</param>
    /// <param name="refund_email">电子邮件</param>
    /// <param name="claims_isopen">索赔通知</param>
    /// <param name="claims_email">电子邮件</param>
    /// <param name="refund_isopen">退款通知</param>
    /// <param name="returns_email">电子邮件</param>
    [WebMethod(EnableSession = true)]
    public void UpdateOrderNotification2(int userid,int returns_isopen, string refund_email, int claims_isopen, string claims_email, int refund_isopen, string returns_email)
    {
        int result=0;
        string error=string.Empty;
        if (noticeBLL.UpdateOrderNotification2(userid, returns_isopen, refund_email, claims_isopen, claims_email, refund_isopen, returns_email))
            result = 1;
        else
            error = "更新订单通知失败。请注意邮件格式。";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }
    #endregion

    #region 更新商品通知
    /// <summary>
    /// 更新商品通知
    /// </summary>
    /// <param name="userid">用户ID</param>
    /// <param name="listing_created_isopen">已创建“我的商品”</param>
    /// <param name="listing_created_email">电子邮件</param>
    /// <param name="listing_closed_isopen">已关闭“我的商品”</param>
    /// <param name="listing_closed_email">电子邮件</param>
    [WebMethod(EnableSession = true)]
    public void UpdateOrderNotification3(int userid,int listing_created_isopen, string listing_created_email, int listing_closed_isopen, string listing_closed_email)
    {
        int result = 0;
        string error = string.Empty;
        if (noticeBLL.UpdateOrderNotification3(userid, listing_created_isopen,  listing_created_email,  listing_closed_isopen,  listing_closed_email))
            result = 1;
        else
            error = "更新订单通知失败。请注意邮件格式。";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }
    #endregion

    #region 更新报告
    /// <summary>
    /// 更新报告
    /// </summary>
    /// <param name="userid">用户编号</param>
    /// <param name="open_listings_isopen">可售商品报告</param>
    /// <param name="open_listings_email">电子邮件</param>
    /// <param name="order_fulfillment_isopen">订单履行报告</param>
    /// <param name="order_fulfillment_email">电子邮件</param>
    /// <param name="sold_listings_isopen">已售出商品报告</param>
    /// <param name="sold_listings_email">电子邮件</param>
    /// <param name="cancelled_listings_isopen">已取消的商品报告</param>
    /// <param name="cancelled_listings_email">电子邮件</param>
    [WebMethod(EnableSession = true)]
    public void UpdateOrderNotification4(int userid,int open_listings_isopen, string open_listings_email, int order_fulfillment_isopen, string order_fulfillment_email, int sold_listings_isopen, string sold_listings_email, int cancelled_listings_isopen, string cancelled_listings_email)
    {
        int result = 0;
        string error = string.Empty;
        if (noticeBLL.UpdateOrderNotification4(userid,open_listings_isopen, open_listings_email, order_fulfillment_isopen, order_fulfillment_email, sold_listings_isopen, sold_listings_email, cancelled_listings_isopen, cancelled_listings_email))
            result = 1;
        else
            error = "更新订单通知失败。请注意邮件格式。";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }
    #endregion

    #region 更新出价通知
    /// <summary>
    /// 更新出价通知
    /// </summary>
    /// <param name="userid">用户编号</param>
    /// <param name="makeoffer_isopen">出价通知</param>
    /// <param name="makeoffer_email">电子邮件</param>
    [WebMethod(EnableSession = true)]
    public void UpdateOrderNotification5(int userid, int makeoffer_isopen, string makeoffer_email)
    {
        int result = 0;
        string error = string.Empty;
        if (noticeBLL.UpdateOrderNotification5(userid, makeoffer_isopen, makeoffer_email))
            result = 1;
        else
            error = "更新订单通知失败。请注意邮件格式。";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }
    #endregion

    #region 更新账户通知 
    /// <summary>
    /// 更新账户通知
    /// </summary>
    /// <param name="userid">用户编号</param>
    /// <param name="business_isopen">公司最新信息</param>
    /// <param name="business_email">电子邮件</param>
    /// <param name="technical_isopen">技术通知</param>
    /// <param name="technical_email">电子邮件</param>
    [WebMethod(EnableSession = true)]
    public void UpdateOrderNotification6(int userid, int business_isopen, string business_email, int technical_isopen, string technical_email)
    {
        int result = 0;
        string error = string.Empty;
        if (noticeBLL.UpdateOrderNotification6(userid, business_isopen, business_email, technical_isopen, technical_email))
            result = 1;
        else
            error = "更新订单通知失败。请注意邮件格式。";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }
    #endregion

    #region 更新紧急通知 
    /// <summary>
    /// 更新紧急通知
    /// </summary>
    /// <param name="userid">用户编号</param>
    /// <param name="emergency_isopen">紧急通知</param>
    /// <param name="emergency_phone">紧急电话</param>
    [WebMethod(EnableSession = true)]
    public void UpdateOrderNotification7(int userid, int emergency_isopen, string emergency_phone)
    {
        int result = 0;
        string error = string.Empty;
        if (noticeBLL.UpdateOrderNotification7(userid, emergency_isopen, emergency_phone))
            result = 1;
        else
            error = "更新订单通知失败。请注意邮件格式。";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }

    #endregion

    #region 更新消息通知  
    /// <summary>
    /// 更新消息通知
    /// </summary>
    /// <param name="userid">用户编号</param>
    /// <param name="buyer_messages_isopen">买家消息</param>
    /// <param name="buyer_messages_email">电子邮件</param>
    /// <param name="confirmation_isopen">确认通知</param>
    /// <param name="confirmation_email">电子邮件</param>
    /// <param name="delivery_failures_isopen">配送失败</param>
    /// <param name="delivery_failures_email">电子邮件</param>
    /// <param name="buyer_optout_isopen">买家退出</param>
    /// <param name="buyer_optout_email">电子邮件</param>
    [WebMethod(EnableSession = true)]
    public void UpdateOrderNotification8(int userid,int buyer_messages_isopen, string buyer_messages_email, int confirmation_isopen, string confirmation_email, int delivery_failures_isopen, string delivery_failures_email, int buyer_optout_isopen, string buyer_optout_email)
    {
        int result = 0;
        string error = string.Empty;
       if(noticeBLL.UpdateOrderNotification8(userid,buyer_messages_isopen, buyer_messages_email, confirmation_isopen, confirmation_email, delivery_failures_isopen, delivery_failures_email, buyer_optout_isopen, buyer_optout_email))
           result = 1;
       else
           error = "更新订单通知失败。请注意邮件格式。";
       Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }
    #endregion

    #region 初始化联系人
    /// <summary>
    /// 联系人（卖家默认联系人)
    /// </summary>
    /// <param name="userid">用户编号</param>
    /// <param name="contact_id">用户联系人编号</param>
    [WebMethod(EnableSession = true)]
    public void InitialContactsInfo(int userid, int contact_id)
    {
        int result = 1;
        string error = string.Empty, strContacts = string.Empty;
        string email = string.Empty, name = string.Empty;
        //用户编号获取 name email phone pwd
        string strUserInfo = userBLL.GetUserLoginSetting(userid);
        if (contact_id == 0)
        {
            userBLL.GetEmail(userid, ref email, ref name);
            //插入一条数据到用户联系人表里  
            contact_id = contacts_BLL.AddUserContacts(userid, name, email);
            noticeBLL.UpdateContacts(userid, contact_id);
            strContacts = contacts_BLL.GetContactsInfo(contact_id);
        }
        else
            strContacts = contacts_BLL.GetContactsInfo(contact_id);
        //联系人表 name email phone 

        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\",\"data\":{\"strUserInfo\":{" + strUserInfo + "},\"strContacts\":{" + strContacts + "}}}");
    }
    #endregion

    #region 更新用户联系人信息（编辑按钮）
    /// <summary>
    /// 更新用户联系人信息（编辑按钮）
    /// </summary>
    /// <param name="contact_id">联系人ID</param>
    /// <param name="name">联系人姓名</param>
    /// <param name="email">电子邮箱</param>
    /// <param name="phone">电话号码</param>
    /// <param name="sms_mode">短信发送方式（1 随机 2 区间）</param>
    /// <param name="start_hour">开始时间</param>
    /// <param name="end_hour">截止时间</param>
    /// <param name="timezone">时区</param>
    [WebMethod(EnableSession = true)]
    public void UpdateUserContacts(int contact_id, string name, string email, string phone, int sms_mode, DateTime start_hour, DateTime end_hour, string timezone)
    {
        int result = 0;
        string error = string.Empty;
        if (contacts_BLL.UpdateUserContacts(contact_id, name, email, phone, sms_mode, start_hour, end_hour, timezone))
            result = 1;
        else
            error = "更新数据失败，注意用户联系人编号的填写";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }
    #endregion

    #region 登录
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="account">邮箱或者手机号</param>
    /// <param name="password">密码</param>
    [WebMethod(EnableSession = true)]
    public void LoginEmail(string account, string password)
    {
        int result=0;
        string error=string.Empty;
        userBLL.LoginEmail(account, password, ref result, ref  error);
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }
    #endregion

    #region 注册新用户
    public void InsertNewUser()
    {
 
    }
    #endregion

    #region  更新姓名
    /// <summary>
    /// 更新name
    /// </summary>
    /// <param name="userid">用户编号</param>
    /// <param name="name">姓名</param>
    [WebMethod(EnableSession = true)]
    public void UpdateName(int userid, string name)
    {
        int result = 0;
        string error = string.Empty;
        if (userBLL.UpdateName(userid, name))
            result = 1;
        else
            error = "更新名字失败";
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }
     
    #endregion

    #region  更新email
    /// <summary>
    ///  更新email
    /// </summary>
    /// <param name="userid">用户编号</param>
    /// <param name="email">邮箱</param>
    /// <param name="pwd">密码</param>
    [WebMethod(EnableSession = true)]
    public void UpdateEmail(int userid, string email, string pwd)
    {
        int result = 0;
        string error = string.Empty;
        if (userBLL.SelectEmail(email))
        {
            if (userBLL.UpdateEmail(userid, email, pwd))
                result = 1;
            else
                error = "更新邮箱失败";
        }
        else
            error = "邮箱已存在"; 

        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }

    #endregion

    #region  更新password
    /// <summary>
    /// 更新password
    /// </summary>
    /// <param name="userid">用户编号</param>
    /// <param name="oldPassword">当前密码</param>
    /// <param name="newPassword">新密码</param>
    [WebMethod(EnableSession = true)]
    public void UpdatePassword(int userid, string oldPassword,string newPassword)
    {
        int result = 0;
        string error = string.Empty, pwd = string.Empty;
        //根据用户编号查询密码
        userBLL.GetPassword(userid, ref pwd);
        if (oldPassword != pwd)
            error = "请正确输入当前密码";
        else
        {
            if (newPassword == pwd)
                error = "新密码不能是去年用过的密码";
            else
            {
                if (userBLL.UpdatePassword(userid, newPassword))
                    result = 1;
            }
        }
        Callback("{\"result\":\"" + result + "\",\"error\":\"" + QGYHelper.FormatCode.FormatUrlEncode(error) + "\"}");
    }
    #endregion

    #endregion
}
