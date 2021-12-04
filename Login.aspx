<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>Login to your Account</h2>
        <hr />
        <asp:Label ID="lblmsg" Visible="false" runat="server" Font-Bold="true" ></asp:Label>
        <br />
        <table style="width:450px">
            <tr>
                <td>Username</td>
                <td>
                    <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="txtpassword" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
<td></td>
                <td>
                    <asp:Button ID="btnlogin" OnClick="btnlogin_Click" runat="server" Text="Login" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
