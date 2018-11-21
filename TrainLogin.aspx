<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TrainLogin.aspx.cs" Inherits="TrainLogin" %>
 <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    学生：<asp:DropDownList ID="ddl_user" runat="server">
    </asp:DropDownList><br />

    任务：<asp:DropDownList ID="ddl_task" runat="server">
    </asp:DropDownList>
    <div>
        <asp:Button ID="Button1" runat="server" Text="进入实训任务" onclick="Button1_Click" />
    </div>
    </form>
</body>
</html>
