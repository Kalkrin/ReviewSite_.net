using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MovieReview
{
    public partial class MovieReview : System.Web.UI.Page
    {
        private string cs = ConfigurationManager.ConnectionStrings["mediaReview"].ConnectionString;

        string ur = ConfigurationManager.ConnectionStrings["cs_UserReviews"].ConnectionString;
        private static string mediaTitle { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {


            string movie = Request.QueryString["title"];  //  using query string to save movie name from result page
            Session["mediaTitle"] = movie;  // using session to store media type


            string selectData = "Select * from movie where title ='" + movie + "'";   // getting data according to the movie name from database
            string userReview = "Select Title, Username, Rating, Review from ReviewList where MediaTitle = '"+movie+"';";

            using (SqlConnection conn = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand(selectData, conn);

                conn.Open();


                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows && reader.Read()) {      // if data exists in database and until reader reads all the rows
                movieName.Text = reader["title"].ToString();
                plot.Text = reader["psummary"].ToString();
                directors.Text = reader["director"].ToString();
                stars.Text = reader["actors"].ToString();
                rating.Text = reader["rating"].ToString();
                Image1.ImageUrl = "~/pictures/movies/" + movieName.Text + ".jpg";
               

            }

                else
                {
                    lblMessage.Text = "Movie " + movie + " doesn't exist.";

                }
            }

            using (SqlConnection conn = new SqlConnection(ur))
            {
                SqlDataAdapter da = new SqlDataAdapter(userReview, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gvMovie.DataSource = ds;
                gvMovie.DataBind();
            }
                
        }



        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
                Response.Redirect("Login.aspx");
            
        }


    }
}