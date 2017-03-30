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
    public partial class BookReview : System.Web.UI.Page
    {

           private string cs = ConfigurationManager.ConnectionStrings["mediaReview"].ConnectionString;

           string ur = ConfigurationManager.ConnectionStrings["cs_UserReviews"].ConnectionString;

           private static string mediaTitle { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {

            string book = Request.QueryString["title"]; //  using query string to save book title from result page
            Session["mediaTitle"] = book;// using session to store media type

            string selectData = "Select * from book where title ='" + book + "'"; // getting data according to the book title from database
            string userReview = "Select Title, Username, Rating, Review from ReviewList where MediaTitle = '" + book + "';";


            using (SqlConnection conn = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand(selectData, conn);

                conn.Open();


                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows && reader.Read()) // if data exists in database and until reader reads all the rows
                {

                    psummary.Text = reader["psummary"].ToString();
                    title.Text = reader["title"].ToString();
                    author.Text = reader["author"].ToString();
                    publisher.Text = reader["publisher"].ToString();
                    genre.Text = reader["genre"].ToString();
                    released.Text = reader["dor"].ToString();
                    rating.Text = reader["rating"].ToString();
                    Image1.ImageUrl = "~/pictures/books/" + title.Text + ".jpg";

                }

                else
                {
                    lblMessage.Text = "Book " + book + " doesn't exist.";

                }
            }

            using (SqlConnection conn = new SqlConnection(ur))
            {
                SqlDataAdapter da = new SqlDataAdapter(userReview, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gvBook.DataSource = ds;
                gvBook.DataBind();
            }
 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}
