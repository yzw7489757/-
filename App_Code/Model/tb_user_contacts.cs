using System;
namespace QAMZN.Model
{
    /// <summary>
    /// tb_user_contacts:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_user_contacts
    {
        public tb_user_contacts()
        { }
        #region Model
        private int _contact_id;
        private string _name;
        private string _email;
        private string _phone;
        private int? _sms_mode;
        private DateTime? _start_hour;
        private DateTime? _end_hour;
        private string _timezone;
        private int? _user_id;
        private DateTime? _createtime;
        /// <summary>
        /// 联系人ID
        /// </summary>
        public int contact_id
        {
            set { _contact_id = value; }
            get { return _contact_id; }
        }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 短信发送方式（1 随机 2 区间）
        /// </summary>
        public int? sms_mode
        {
            set { _sms_mode = value; }
            get { return _sms_mode; }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? start_hour
        {
            set { _start_hour = value; }
            get { return _start_hour; }
        }
        /// <summary>
        /// 截止时间
        /// </summary>
        public DateTime? end_hour
        {
            set { _end_hour = value; }
            get { return _end_hour; }
        }
        /// <summary>
        /// 时区
        /// </summary>
        public string timezone
        {
            set { _timezone = value; }
            get { return _timezone; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? user_id
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? createtime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        #endregion Model

    }
}

