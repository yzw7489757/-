using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TrainLoginTest : System.Web.UI.Page
{
    public int _userID = 0, _courseID = 0, _trainType = 0;
    public string _account = string.Empty, _taskID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        //QGYHelper.PageHelper.CheckQuerystring("userid", ref this._userID);
        //QGYHelper.PageHelper.CheckQuerystring("courseid", ref this._courseID);
        //QGYHelper.PageHelper.CheckQuerystring("traintype", ref this._trainType); 
        //this._account = Request.QueryString["account"];
        //this._taskID = Request.QueryString["taskid"];
        //if (this._trainType == 1)
        //    Response.Redirect("/wish/Default.aspx?userid=" + this._userID + "&courseid=" + this._courseID + "&account=" + this._account + "&traintype=" + this._trainType + "&taskid=" + this._taskID, false);
        //else
        //    Response.Redirect("/seller/centerpage.html?userid=" + this._userID + "&account=" + this._account + "&trainingid=" + this._courseID + "&traintype=" + this._trainType + "&taskid=" + this._taskID);
        if (!Page.IsPostBack)
        {
            string strSql = "select task_number,'['+convert(varchar(4),task_number)+']'+task_name as task_name from TB_Training_Task where training_id = 3 and len(task_number)=4 order by task_number";
            DataTable dt = QGYHelper.SKYSQLHelper.Query(strSql).Tables[0];
            QGYHelper.ControlBind.comDataBind.DropDownListBind(this.ddl_task, dt, "task_number", "task_name");

            strSql = "select user_id,user_user from TB_User where class_id = 1 order by user_user";
            dt = QGYHelper.SKYSQLHelper.Query(strSql).Tables[0];
            QGYHelper.ControlBind.comDataBind.DropDownListBind(this.ddl_user, dt, "user_id", "user_user");
            this.ddl_user.SelectedValue = "95";
            //this.ddl_user.Enabled = false;
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this._userID = int.Parse(this.ddl_user.SelectedValue);
        this._account = this.ddl_user.SelectedItem.Text.Trim();
        this._taskID = this.ddl_task.SelectedValue.Trim();
        this._courseID = 3;
        this._trainType = 0;
        Response.Redirect("/seller/centerpage.html?orgid=1&classid=1&classname=" + QGYHelper.FormatCode.FormatUrlEncode("电商181") + "&userid=" + this._userID + "&account=" + QGYHelper.FormatCode.FormatUrlEncode(this._account) + "&courseid=" + this._courseID + "&traintype=" + this._trainType + "&taskno=" + this._taskID);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this._userID = int.Parse(this.ddl_user.SelectedValue);
        this._account = this.ddl_user.SelectedItem.Text.Trim();
        this._taskID = this.ddl_task.SelectedValue.Trim();
        this._courseID = 3;
        this._trainType = 0;
        Response.Redirect("/buyer/centerpage.html?orgid=1&classid=1&classname=" + QGYHelper.FormatCode.FormatUrlEncode("电商181") + "&userid=" + this._userID + "&account=" + QGYHelper.FormatCode.FormatUrlEncode(this._account) + "&courseid=" + this._courseID + "&traintype=" + this._trainType + "&taskno=" + this._taskID);
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //QGYHelper.LoginHelper.MallManageIDCookie = 1;
        //QGYHelper.LoginHelper.MallManageRoleCookie = 1;
        //QGYHelper.LoginHelper.MallManageAccountCookie = "运营人员";
        //Response.Redirect("manage/Default.aspx");
    }
}