using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;

namespace WebApplication3
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {

        }

        protected void createAccountButton_Click(object sender, EventArgs e)
        {
            //makes all error labels not visible each time it runs through the method
            invalidPasswordLabel.Visible = false;
            invalidEmailLabel.Visible = false;
            UsernameLabel.Visible = false;

            UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            CookbookDatabaseEntities dbcon = new CookbookDatabaseEntities();

            //connects to database
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CookbookDatabase.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            //paste this code in the line above ^^^^^^ SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CookbookDatabase.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");

            //Counts username and email in database
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From CookbookUsers where Username = '" + usernameTextBox.Text + "' or Email = '" + emailTextBox.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            //checks if username or email is already in database
            if (dt.Rows[0][0].ToString() == "1")
            {
                UsernameLabel.Visible = true;
               
            }
            else if (dt.Rows[0][0].ToString() == "2")
            {
                UsernameLabel.Visible = true;

            }
            else
            {
                //verifies email format
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                string email = emailTextBox.Text;
                Match match = regex.Match(email);

                if (match.Success)
                {
                    //verifies password is not blank
                    if (passwordTextBox.Text != "")
                    {
                        // verifies passwrd is at least 8 characters in length
                        if(!(passwordTextBox.Text.Length < 8))
                        {
                            string username = usernameTextBox.Text;
                            string password = passwordTextBox.Text;

                            CookbookUser newUser = new CookbookUser
                            {

                                //User newUser = new User();
                                UserId = (int)DateTime.Now.ToFileTime(),
                                Email = email,
                                Username = username,
                                Password = password
                            };

                            //adds user to database
                            dbcon.CookbookUsers.Add(newUser);
                            dbcon.SaveChanges();
                            Response.Redirect("Recipepage.aspx");
                        }
                        else
                        {
                            //error message if password is left blank
                            passwordLengthLabel.Visible = true;
                        }
                           
                    } else
                    {
                        //error message if password is left blank
                        invalidPasswordLabel.Visible = true;
                    }
                } else
                {
                    //error message if email is in invalid format
                    invalidEmailLabel.Visible = true;
                }
            }
        }

        protected void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}