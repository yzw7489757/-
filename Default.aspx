<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
    <tbody>
        <tr>
            <td>
                <a href="https://www.ups.com/WebTracking/track" target="_blank">UPS</a>
            </td>
            <td>
                Phone: 1-800-742-5877
            </td>
        </tr>
        <tr>
            <td>
                <a href="https://www.usps.com/shipping/trackandconfirm.htm" target="_blank">U.S. Postal
                    Service</a>
            </td>
            <td>
                Phone: 1-800-222-1811
            </td>
        </tr>
        <tr>
            <td>
                Amazon Logistics (AMZL_US)
            </td>
            <td>
                <a href="/gp/help/customer/display.html?nodeId=201821690">About Deliveries by Amazon
                    Logistics</a>
            </td>
        </tr>
        <tr>
            <td>
                <a href="https://www.fedex.com/en-us/customer-support.html" target="_blank">FedEx</a>
            </td>
            <td>
                Phone: 1-800-463-3339
            </td>
        </tr>
        <tr>
            <td>
                <a href="https://www.dhl-usa.com/en/express/tracking.html" target="_blank">DHL Express</a>
            </td>
            <td>
                Phone: 1-800-225-5345
            </td>
        </tr>
    </tbody>
    </form>
</body>
</html>
