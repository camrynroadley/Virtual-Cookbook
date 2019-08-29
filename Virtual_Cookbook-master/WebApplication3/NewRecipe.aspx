<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewRecipe.aspx.cs" Inherits="WebApplication3.NewRecipe" %>

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
        <div>
            <div class ="container">
                <p>
                </p>
            </div>
            <div class ="row">
                <h2>
                <%--<h2>Add New Recipe:</h2>
                <asp:LinkButton runat="server" CssClass="btn btn-default" ID="btnRecipePage" Text="Recipe Page" OnClick="btnRecipePage_Click" BackColor="#66CCFF" BorderStyle="Outset" Font-Bold="True" Font-Size="Large" ForeColor="White" BorderColor="#66CCFF" Font-Names="Calibri"  />
                    <br />
                    <br />--%>
                    
                    Add New Recipe:</h2>
                    
            </div>
            Recipe <asp:Label runat="server" Text="Name" Font-Size="Large" />
            :&nbsp;<br />
            <br />
            <asp:TextBox runat="server" ID="nameTextBox" Height="35px" Width="301px" />
            <asp:Label ID="NameLabel" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
        <p>
            <asp:Label runat="server" Text="Ingredients" Font-Size="Large" />
            :</p>
        <p>
            &nbsp;<asp:TextBox runat="server" ID="ingredientsTextBox" Height="35px" Width="300px" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="IngredientButton" runat="server" OnClick="IngredientButton_Click" Text="Add Another Ingredient" BackColor="#66CCFF" BorderStyle="Outset" Font-Bold="True" Font-Size="Medium" ForeColor="White" BorderColor="#66CCFF" Font-Names="Calibri" />
            </p>
        <p>
            <asp:Label ID="EnteredIngredientsLabel" runat="server" Text="Label" Visible="False" Font-Size="Large"></asp:Label>
            </p>
        <p>
            <asp:Label runat="server" Text="Instructions" Font-Size="Large" />

            :</p>
        <p>
            &nbsp;<asp:TextBox runat="server" ID="instructionsTextBox" Height="35px" Width="300px" />

        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="InstructionButton" runat="server" OnClick="InstructionButton_Click" Text="Add Another Instruction" BackColor="#66CCFF" BorderStyle="Outset" Font-Bold="True" Font-Size="Medium" ForeColor="White" BorderColor="#66CCFF" Font-Names="Calibri" />

        </p>
        <asp:Label ID="EnteredInstructionsLabel" runat="server" Text="Label" Visible="False" Font-Size="Large"></asp:Label>
        <br />
        <br />
        <asp:Button ID="saveButton" runat="server" OnClick="saveButton_Click" Text="Save" BackColor="#66CCFF" BorderStyle="Outset" Font-Bold="True" Font-Size="Large" ForeColor="White" BorderColor="#66CCFF" Font-Names="Calibri"  />
    </form>
</body>
</html>
