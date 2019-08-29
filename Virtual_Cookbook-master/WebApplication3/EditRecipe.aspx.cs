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
    public partial class EditRecipe : System.Web.UI.Page
    {
        static string recipeName = "";
        static string ingredients = "";
        static string instructions = "";
        static int recipeId = 0;
        static int count = 0;
        static CookbookRecipe originalRecipe;

        protected void Page_Load(object sender, EventArgs e)
        {
            // only set the values when count = 0 (it's the first page load)
            if(count == 0)
            {
                // set the values of the text boxes to be the values that already existed for that recipe
                recipeNameTextBox.Text = Session["recipeName"].ToString();
                ingredientsLabel.Text = Session["ingredients"].ToString();
                ingredients += Session["ingredients"].ToString();
                instructionsLabel.Text = Session["instructions"].ToString();
                instructions += Session["instructions"].ToString();
                recipeId = (int)Session["recipeId"];

                // show existing ingredients and instructions
                ingredientsLabel.Visible = true;
                instructionsLabel.Visible = true;

                // make an original recipe, this will be deleted and replaced by new recipe with the same id
                originalRecipe = new CookbookRecipe
                {
                    RecipeId = (int)Session["recipeId"],
                    RecipeName = Session["recipeName"].ToString(),
                    Ingredients = Session["ingredients"].ToString(),
                    Instructions = Session["instructions"].ToString(),
                    UserId = (int)Session["UserID"]
                };
                count++;
            }
        }
        
        protected void saveButton_Click(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            CookbookDatabaseEntities dbcon = new CookbookDatabaseEntities();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CookbookDatabase.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From CookbookRecipes where RecipeName = '" + recipeName + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            
            if ((dt.Rows[0][0].ToString() == "0") || (dt.Rows[0][0].ToString() == "1"))
            {
                // Get remaining ingredients from text box
                if (ingredientsTextBox.Text != "")
                {
                    ingredients += ingredientsTextBox.Text;
                }

                // Get remaining instructions from text box
                if (instructionsTextBox.Text != "")
                {
                    instructions += instructionsTextBox.Text;
                }

                // If the user doesn't enter a recipe name
                if (recipeNameTextBox.Text.Equals(""))
                {
                    NameLabel.Text = "*Enter a recipe name";
                    NameLabel.Visible = true;

                }
                else
                {
                    recipeName = recipeNameTextBox.Text;
                    
                    CookbookRecipe newRecipe = new CookbookRecipe
                    {
                        RecipeId = recipeId,
                        RecipeName = recipeName,
                        Ingredients = ingredients,
                        Instructions = instructions,
                        UserId = (int)Session["UserID"]
                    };

                    // remove the old recipe
                    dbcon.CookbookRecipes.Attach(originalRecipe);
                    dbcon.CookbookRecipes.Remove(originalRecipe);

                    // replace the old recipe with the newly edited recipe (with the same id as before)
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
            ingredientsLabel.Visible = true;
            ingredientsLabel.Text = ingredients; // show user the ingredients they have already entered
            ingredientsTextBox.Text = ""; // reset the value of the text box so that it's empty
        }

        /* User wants to add additonal instructions */
        protected void InstructionButton_Click(object sender, EventArgs e)
        {
            string instruction = instructionsTextBox.Text;
            instructions += instruction + ", ";
            instructionsLabel.Visible = true;
            instructionsLabel.Text = instructions; // show user the instructions they have already entered
            instructionsTextBox.Text = ""; // reset the value of the text box so that it's empty
        }
    }
}