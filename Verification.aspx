<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Verification.aspx.cs" Inherits="Verification" %>

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
    <h2>Verify your identity</h2>
        <hr />
         <asp:Label ID="lblmsg" Visible="false" runat="server" Font-Bold="true" ></asp:Label>
        <br />
        <table style="width:550px">
            <tr>
                <th colspan="2">Enter OTP received on your phone/email or scan the QRCODE</th>
               
            </tr>
           <tr>
               <td>Enter OTP</td>
 <td>
                    <asp:TextBox ID="txtOTP" runat="server"></asp:TextBox>
                </td>
               <td>
                   <asp:Image ID="imgQRCODE" Width="120px" Height="120px" runat="server" />
               </td>
           </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnverify" OnClick="btnverify_Click" runat="server" Text="Verify" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>