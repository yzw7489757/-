<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TrainLoginTest.aspx.cs" Inherits="TrainLoginTest" %>


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
        <asp:Button ID="Button1" runat="server" Text="进入卖家实训任务" onclick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="进入买家实训任务" 
            onclick="Button2_Click"  />
        <asp:Button ID="Button3" runat="server" Text="进入商城后台" 
            onclick="Button3_Click"   /> 
    </div>
    </form>
</body>
</html>

