<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

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
        <h2>User Registration</h2>
        <hr />
            <asp:Label ID="lblmsg" Visible="false" runat="server" Font-Bold="true"></asp:Label>
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
                    <td>Email</td>
                    <td>
                        <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Phone No</td>
                    <td>
                        <asp:TextBox ID="txtphoneNo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnregister" OnClick="btnregister_Click1" runat="server" Text="Register" />
                    </td>
                </tr>
            </table>
        <h4>Already a user? <asp:HyperLink runat="server" NavigateUrl="~/E-Authentication.aspx" Text="Login"></asp:HyperLink></h4>
        
        </div>
    </form>
</body>
</html>