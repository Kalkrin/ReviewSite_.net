using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace MediaProject
{
    public partial class Member : System.Web.UI.Page
    {
        //connectionstring for database
        string cs = ConfigurationManager.ConnectionStrings["cs_UserReviews"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //checks if session is exising from login or register page
            if(Session["New"] != null)
            {
                //"Welcome username" msg
                lblMessage.Text = "Welcome " + Session["New"].ToString() + "!";
                tbUsername.Text = Session["New"].ToString();
            }
            //retrieves session from review page to check media type
            if (Convert.ToInt32(Session["rdo"]) == 1) {
                //radiobox for movie will be preselected if rdo = 1
                rbMovie.Checked = true;
            }
            else if (Convert.ToInt32(Session["rdo"]) == 2)
            {
                //radiobox for book will be preselected if rdo = 2
                rbBook.Checked = true;
            }
            else if (Convert.ToInt32(Session["rdo"]) == 3)
            {
                //radiobox for song will be preselected if rdo = 3
                rbSong.Checked = true;
            }

            //insert a placeholder at index 0 with value -1
            ddlRating.Items.Insert(0, new ListItem("Your Rating", "-1"));
            for (int i = 1; i <= 10; i++)
            {
                if (i == 1)
                {
                    //if i is 1, just append the text with "(terrible)"
                    ddlRating.Items.Insert(i, new ListItem(i + " (terrible)", "" + i + ""));
                }
                else if (i == 10)
                {
                    //if i is 10, just append the text with "(amazing)"
                    ddlRating.Items.Insert(i, new ListItem(i + " (amazing)", "" + i + ""));
                }
                else
                {
                    //append numbers 2 - 9 into ddl
                    ddlRating.Items.Insert(i, new ListItem("" + i + "", "" + i + ""));
                }
            }
            
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            //if the button text is "Go back to home page"
            if (btnLogout.Text.Equals("Go Back to Home Page"))
            {
                //kills the session and redirects to home page
                Session["New"] = null;
                Response.Redirect("SearchPage.aspx");
            }
            else
            {
                /*
                 * kills the session and redirects to login because the button text
                 * will be Log Out
                */
                Session["New"] = null;
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
                //sets user entered values into respective string variables
                string rating = ddlRating.SelectedItem.Text.Trim();
                string title = tbSummaryTitle.Text.Trim();
                string review = tbReview.Text.Trim();
                
                //inserts username, rating, title, review and mediatype (via session) to database
                string query = "insert into ReviewList (Username, Rating, Title, Review, MediaTitle) values ('" + Session["New"].ToString() + "','" + rating + "','" + title + "','" + review + "', '" + Session["mediaTitle"].ToString() + "');";

                //connects to database
                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                
                //displays msg that the review was successfully posted 
                lblMessage.Text = "Your review has been successfully posted!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                
                //change button to "Go backe to home page"
                btnLogout.Text = "Go Back to Home Page";
        }
        
    

        protected void btnReset_Click(object sender, EventArgs e)
        {
            //resets everything to default 
            tbSummaryTitle.Text = "";
            tbReview.Text = "";
            ddlRating.SelectedIndex = ddlRating.Items.IndexOf(ddlRating.Items.FindByText("Your Rating"));
        }
    }
}