<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Support.aspx.cs" Inherits="WebApplication3.Support" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style>
         ul{
           list-style-type: none;
           margin: 0;
           padding: 0;
           overflow: hidden;
           background-color: #333;
       }
       li{
           float: left;
       }

       li a{
           display:block;
           color: white;
           text-align: center;
           padding: 14px 16px;
           text-decoration: none;
       }

       li a:hover{
           background-color: #111;
       }
       
       body {
            background-color: azure;
            width:100vw;
            height:100vw;
            justify-content:center;
            <!--align-items:center;-->
        }
        
            .auto-style1 {
                font-size: large;
            }
            .auto-style2 {
                font-size: medium;
            }
        
    </style>
</head>
<body>
    <ul>
        <li><a class="active" href= "RecipePage.aspx">Recipe Page</a></li>
        <li><a href="NewRecipe.aspx">New Recipe</a></li>
        <li><a href="Support.aspx">Feedback</a></li>
        <li><a href="Login.aspx">Logout</a></li>

    </ul>
        <form id="form1" runat="server">
            <p>
                &nbsp;</p>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Give Us Some Feedback:" Font-Size="Large" ></asp:Label>
            </p>
            <p>
                <asp:TextBox ID="TextBox1" runat="server" TextMode ="MultiLine"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" BackColor="#66CCFF" BorderStyle="Outset" Font-Bold="True" Font-Size="Medium" ForeColor="White" BorderColor="#66CCFF" Font-Names="Calibri" />
            </p>
            <p>
                <asp:Label ID="Label3" runat="server" Text="Thank you for your feedback." Font-Size="Large"></asp:Label>
            </p>
            <p class="auto-style1">
                &nbsp;</p>
            <p class="auto-style2">
                Your Feedback:</p>
            <p>
                <asp:ListBox ID="ListBox1" runat="server" Height="183px" Width="564px">
                    <asp:ListItem></asp:ListItem>
                </asp:ListBox>
            </p>
        </form>
    
</body>
</html>
