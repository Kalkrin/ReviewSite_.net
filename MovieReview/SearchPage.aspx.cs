using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace ProjectSearch
{
    public partial class SearchPage : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["mediaReview"].ConnectionString;
        public static int rdo { get; set; }
        //making a public variable so I know what rdo button is selected through out the program.

        public static string name { get; set; }
        // setting a public variable so I know what name I am selecting with in the results page.
        public static string t1;
        public static string t2;
        public static string targetPage = "#";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTop.Text = "Top Rated Movies...";

                getTopMovies();
                lblTitle1.Text = "";
                lblTitle2.Text = "";

                Session["rdo"] = 1;
                // setting up the seath page so it's all default with searching for movies.
            }
        }

        protected void rdoMovie_CheckedChanged(object sender, EventArgs e)
        {
            lblTop.Text = "Top Rated Movies...";

            getTopMovies();
            lblTitle1.Text = "";
            lblTitle2.Text = "";
            Session["rdo"] = 1;
            // when the radio button for movie is selected, it will show top rated movies and the search will grab for movies.


        }

        protected void rdoBook_CheckedChanged(object sender, EventArgs e)
        {
            lblTop.Text = "Top Rated Books...";

            getTopBooks();
            lblTitle1.Text = "";
            lblTitle2.Text = "";
            Session["rdo"] = 2;
            // when this radio button is selected it will show the two top books and search from book database for the search.
        }

        protected void rdoSong_CheckedChanged(object sender, EventArgs e)
        {
            lblTop.Text = "Top Rated Songs...";

            getTopSongs();

            Session["rdo"] = 3;
            // When this radio is selected it will show the top rated songs and will search using the music database.
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            name = txtSearch.Text;

            Response.Redirect("~/Results.aspx");
            //grabs the text that is in the text box and redirects to the results page once the search button is pressed.
        }

        public void getTopMovies()
        {
            if (rdoMovie.Checked)
            {
                string query = "select top 2 rating, title from movie order by rating desc;";

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    ArrayList al = new ArrayList();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            al.Add(reader.GetInt32(0));
                            al.Add(reader.GetString(1));
                        }
                        img1.ImageUrl = "~/pictures/movies/" + al[1] + ".jpg";
                        img2.ImageUrl = "~/pictures/movies/" + al[3] + ".jpg";
                        lblRating1.Text = "Rating: " + al[0] + "/10";
                        lblRating2.Text = "Rating: " + al[2] + "/10";

                        t1 = al[1].ToString();
                        t2 = al[3].ToString();
                        targetPage = "MovieReview.aspx";
                        // this just pulls the top two values from the database and displays them at the bottom of the page.
                    }
                    else
                    {
                        Response.Write("No rows found");
                    }
                    reader.Close();
                }
            }
        }
        public void getTopBooks()
        {
            if (rdoBook.Checked)
            {
                string query = "select top 2 rating, title from book order by rating desc;";

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    ArrayList al = new ArrayList();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            al.Add(reader.GetInt32(0));
                            al.Add(reader.GetString(1));
                        }
                        img1.ImageUrl = "~/pictures/books/" + al[1] + ".jpg";
                        img2.ImageUrl = "~/pictures/books/" + al[3] + ".jpg";
                        lblRating1.Text = "Rating: " + al[0] + "/10";
                        lblRating2.Text = "Rating: " + al[2] + "/10";
                        // this just pulls the top two values from the database and displays them at the bottom of the page.
                        t1 = al[1].ToString();
                        t2 = al[3].ToString();
                        targetPage = "BookReview.aspx";
                    }
                    else
                    {
                        Response.Write("No rows found");
                    }
                    reader.Close();
                }
            }
        }
        public void getTopSongs()
        {
            if (rdoSong.Checked)
            {
                string query = "select top 2 rating, title from Song order by rating desc;";

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    ArrayList al = new ArrayList();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            al.Add(reader.GetInt32(0));
                            al.Add(reader.GetString(1));
                        }
                        lblTitle1.Text = "Song: " + al[1].ToString() + " -";
                        lblTitle2.Text = "Song: " + al[3].ToString() + " -";
                        img1.ImageUrl = "~/pictures/songs/" + al[1] + ".jpg";
                        img2.ImageUrl = "~/pictures/songs/" + al[3] + ".jpg";
                        lblRating1.Text = "Rating: " + al[0] + "/10";
                        lblRating2.Text = "Rating: " + al[2] + "/10";
                        // this just pulls the top two values from the database and displays them at the bottom of the page.
                        t1 = al[1].ToString();
                        t2 = al[3].ToString();
                        targetPage = "MusicReview.aspx";
                    }
                    else
                    {
                        Response.Write("No rows found");
                    }
                    reader.Close();
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            Response.Redirect(targetPage+"?title=" + t1);
        }

        protected void img2_Click(object sender, ImageClickEventArgs e)
        {

            Response.Redirect(targetPage+"?title=" + t2);
        }

    }
}