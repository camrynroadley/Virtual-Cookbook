using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication3
{
    public partial class Support : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["data"]==null)
            {
                DataTable dataTable = new DataTable();//create table if not exist
                dataTable.Columns.Add("Comment");//add column
                ViewState["data"] = dataTable;// add in viewstate
            }
            if (!Page.IsPostBack)
            {
                Label3.Visible = false;

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //before add value get viewstate to datatable
            dt = (DataTable)ViewState["data"];
            string comment = TextBox1.Text.Trim();
            dt.Rows.Add(comment);//add the text box value to datatable

            ListBox1.DataSource = dt;
            ListBox1.DataTextField = "Comment";
            ListBox1.DataBind();

            Label3.Visible = true;

            

            TextBox1.Text = string.Empty;
        }
    }
}