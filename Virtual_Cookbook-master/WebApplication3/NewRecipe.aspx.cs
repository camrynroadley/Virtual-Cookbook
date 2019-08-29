using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebApplication3
{
    public partial class NewRecipe : System.Web.UI.Page
    {
        static string ingredients = "";
        static string instructions = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /* For when user wants to save a recipe */
        protected void saveButton_Click(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            CookbookDatabaseEntities dbcon = new CookbookDatabaseEntities();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CookbookDatabase.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From CookbookRecipes where RecipeName = '" + nameTextBox.Text + "' and Ingredients = '" + ingredientsTextBox.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            // save the recipe as long as it doesn't already exist in the database
            if (!(dt.Rows[0][0].ToString() == "1"))
            {
                string recipeName = "";

                // Get remaining ingredients from the text box
                if(ingredientsTextBox.Text != "")
                {
                    ingredients += ingredientsTextBox.Text;
                }

                // Get remaining instructions from the text box
                if (instructionsTextBox.Text != "")
                {
                    instructions += instructionsTextBox.Text;
                }

                // If the user doesn't enter a recipe name
                if (nameTextBox.Text.Equals(""))
                {
                    NameLabel.Text = "*Enter a recipe name";
                    NameLabel.Visible = true;
                }
                else
                {
                    
                    recipeName = nameTextBox.Text;
                    CookbookRecipe newRecipe = new CookbookRecipe
                    {
                        RecipeId = (int)DateTime.Now.ToFileTime(),
                        RecipeName = recipeName,
                        Ingredients = ingredients,
                        Instructions = instructions,
                        UserId = (int)Session["UserID"]
                    };

                    // add new recipe to database
                    dbcon.CookbookRecipes.Add(newRecipe);
                    dbcon.SaveChanges();
                    Response.Redirect("Recipepage.aspx");
                }
            }
        }

        /* User wants to add additonal ingredients */
        protected void IngredientButton_Click(object sender, EventArgs e)
        {
            string ingredient = ingredientsTextBox.Text;
            ingredients += ingredient + ", ";
            EnteredIngredientsLabel.Visible = true; 
            EnteredIngredientsLabel.Text = ingredients; // show user the ingredients they have already entered
            ingredientsTextBox.Text = ""; // reset the value of the text box so that it's empty
        }

        /* User wants to add additonal instructions */
        protected void InstructionButton_Click(object sender, EventArgs e)
        {
            string instruction = instructionsTextBox.Text;
            instructions += instruction + ", ";
            EnteredInstructionsLabel.Visible = true;
            EnteredInstructionsLabel.Text = instructions; // show user the instructions they have already entered
            instructionsTextBox.Text = ""; // reset the value of the text box so that it's empty
        }
    }
}