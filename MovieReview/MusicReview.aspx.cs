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
    public partial class MusicReview : System.Web.UI.Page
    {

        private string cs = ConfigurationManager.ConnectionStrings["mediaReview"].ConnectionString;

        string ur = ConfigurationManager.ConnectionStrings["cs_UserReviews"].ConnectionString;

        private static string mediaTitle { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            string music = Request.QueryString["title"]; //  using query string to save music title from result page
            Session["mediaTitle"] = music; // using session to store media type

            string selectData = "Select * from Song where title ='" + music + "'"; // getting data according to the music title from database
            string userReview = "Select Title, Username, Rating, Review from ReviewList where MediaTitle = '" + music + "';";

            using (SqlConnection conn = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand(selectData, conn);

                conn.Open();


                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows && reader.Read())  // if data exists in database and until reader reads all the rows
                {

                    
                    album.Text = reader["album"].ToString();
                    title.Text = reader["title"].ToString();
                    artist.Text = reader["artist"].ToString();
                    genre.Text = reader["genre"].ToString();
                    length.Text = reader["slength"].ToString();
                    released.Text = reader["dor"].ToString();
                    rating.Text = reader["rating"].ToString();
                    Image1.ImageUrl = "~/pictures/songs/" + title.Text + ".jpg";

                }

                else
                {
                    lblMessage.Text = "Music " + music + " doesn't exist.";

                }
            }

            using (SqlConnection conn = new SqlConnection(ur))
            {
                SqlDataAdapter da = new SqlDataAdapter(userReview, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gvMusic.DataSource = ds;
                gvMusic.DataBind();
            }
 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}