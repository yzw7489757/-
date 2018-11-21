using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace QAMZN.BLL
{
    /// <summary>
    /// tb_user_contacts
    /// </summary>
    public partial class tb_user_contacts
    {
        private readonly QAMZN.DAL.tb_user_contacts dal = new QAMZN.DAL.tb_user_contacts();
        QAMZN.Model.tb_user_contacts model = new Model.tb_user_contacts();
        public tb_user_contacts()
        { }
        #region  BasicMethod

        #region 获取联系人信息详情
        /// <summary>
        /// 获取联系人信息详情
        /// </summary>
        /// <param name="userid">用户编号</param>
        public string GetContactsInfo(int contact_id)
        {
            model = dal.GetModel(contact_id);
           if (model != null)
           {
               return "\"contact_id\":\"" + model.contact_id 
                   + "\",\"name\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.name )
                   + "\",\"email\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.email)
                   + "\",\"phone\":\"" + model.phone
                   + "\",\"sms_mode\":\"" + model.sms_mode
                   + "\",\"start_hour\":\"" + model.start_hour
                   + "\",\"end_hour\":\"" + model.end_hour
                   + "\",\"timezone\":\"" + QGYHelper.FormatCode.FormatUrlEncode(model.timezone)
                   + "\"";
           }
           else
               return "";

        }
        #endregion

        #region UpdateUserContacts 更新用户联系人信息（编辑按钮）
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
        public bool UpdateUserContacts(int contact_id, string name, string email, string phone, int sms_mode, DateTime start_hour, DateTime end_hour, string timezone)
        {
            model.contact_id = contact_id;
            model.name = name;
            model.email = email;
            model.phone = phone;
            model.sms_mode = sms_mode;
            model.start_hour = start_hour;
            model.end_hour = end_hour;
            model.timezone = timezone;
           return dal.Update(model);
        }
        #endregion

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int contact_id)
        {
            return dal.Exists(contact_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(QAMZN.Model.tb_user_contacts model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 初始化表数据（用户编号，名称，登录邮箱）
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="name">名称</param>
        /// <param name="email">登录邮箱</param>
        /// <returns></returns>
        public int AddUserContacts(int userid,string name,string email)
        {
            return dal.AddUserContacts(userid, name, email);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(QAMZN.Model.tb_user_contacts model)
        {
            return dal.Update(model);
        }



        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateContacts(QAMZN.Model.tb_user_contacts model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int contact_id)
        {

            return dal.Delete(contact_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string contact_idlist)
        {
            return dal.DeleteList(contact_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public QAMZN.Model.tb_user_contacts GetModel(int contact_id)
        {
            return dal.GetModel(contact_id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<QAMZN.Model.tb_user_contacts> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<QAMZN.Model.tb_user_contacts> DataTableToList(DataTable dt)
        {
            List<QAMZN.Model.tb_user_contacts> modelList = new List<QAMZN.Model.tb_user_contacts>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                QAMZN.Model.tb_user_contacts model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

