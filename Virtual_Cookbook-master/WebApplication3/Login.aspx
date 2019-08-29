<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication3.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            background-color: azure;
            width:100vw;
            height:100vw;
            display:flex;
            justify-content:center;
            <!--align-items:center;-->
        }
        .auto-style1 {
            text-align: justify;
        }
        p1{
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <p class="auto-style1">
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" Text="Login"></asp:Label>
        </p>

        <p>
            <asp:Label ID="Label3" runat="server" Text="Username:"></asp:Label>
            </p>
        <p>
            <asp:TextBox ID="usernameTextBox" runat="server" Height="35px" Width="300px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Password:"></asp:Label>
        </p>
        <p>
            &nbsp;<asp:TextBox ID="passwordTextBox" TextMode="Password" runat="server" Height="35px" Width="293px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="SubmitButton" runat="server" OnClick="SubmitButton_Click" Text="Login" BackColor="#66CCFF" BorderStyle="Outset" Font-Bold="True" Font-Size="Large" ForeColor="White" BorderColor="#66CCFF" Font-Names="Calibri" />
        </p>
        <p1>
            <asp:Label ID="Label1" runat="server" Text="Invalid Username or Password" Visible="False"></asp:Label>
        </p1>
        <p>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CreateAccount.aspx">Don&#39;t Have an Account? Register Now</asp:HyperLink>
        </p>
    </form>
</body>
</html>
