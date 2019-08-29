using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Script;



namespace WebApplication3
{
    public partial class Login : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {

            UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            CookbookDatabaseEntities dbcon = new CookbookDatabaseEntities();

            if (IsPostBack)
            {
                Validate();
                if (IsValid)
                {
                    string username = usernameTextBox.Text;
                    string password = passwordTextBox.Text;
                    
                    dbcon.CookbookUsers.SqlQuery($"SELECT * FROM CookbookUsers WHERE Username = {username} AND Password = {password}");

                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CookbookDatabase.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");

                    // SDA contains how many usernames and passwords are the same.
                    SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From CookbookUsers where Username = '" + usernameTextBox.Text + "' and Password = '" + passwordTextBox.Text + "'", con);
                   
                    // usertable contains a row of information from cookbook users
                    SqlDataAdapter usertableadapter = new SqlDataAdapter("Select * From CookbookUsers where Username = '" + usernameTextBox.Text + "' and Password = '" + passwordTextBox.Text + "'", con);
                    
                    //puts the whole row into this table
                    DataTable userTable = new DataTable();
                    DataTable dt = new DataTable();
                    usertableadapter.Fill(userTable);
                    sda.Fill(dt);

                    // if the user exists in the database then log them in
                    if (dt.Rows[0][0].ToString() == "1" )
                    {
                       // save sessions of the currently logged in user
                        Session["Username"] = usernameTextBox.Text;
                        Session["Password"] = passwordTextBox.Text;
                        Session["UserID"] = userTable.Rows[0][0];
                        
                        dbcon.SaveChanges();
                        Response.Redirect("Recipepage.aspx");
                    }
                     
                    // if the user doesn't exist in database, show error message
                    else
                    {
                        Label1.Visible = true;
                    }
                }
            }
        }
    }
}