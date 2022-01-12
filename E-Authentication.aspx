<%@ Page Language="C#" AutoEventWireup="true" CodeFile="E-Authentication.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body{
            background-image: url("cloud.jpeg");
            background-size: cover;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <h2>Welcome to the E-Authentication project</h2>
        <hr />
        <h3>Login Page</h3>
            <asp:Label ID="lblmsg" Visible="false" runat="server" Font-Bold="true"></asp:Label>
            <br />
            <table style= "width:450px">
                <tr>
                    <td>Username</td>
                    <td>
                        <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td>
                        <asp:TextBox ID="txtpassword" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnlogin" OnClick="btnlogin_Click" runat="server" Text="Login" />
                    </td>
                </tr>
            </table>
            <h4>New to this page? <asp:HyperLink runat="server" NavigateUrl="~/Register.aspx" Text="Register now"></asp:HyperLink></h4>
        </div>
    </form>
</body>
</html>