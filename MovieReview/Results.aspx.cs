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
    public partial class Results : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["mediaReview"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string test = SearchPage.name;
            string name = SearchPage.name;
            int rdo = Convert.ToInt32(Session["rdo"]);
            doSearch(name, rdo);
        }
        public void doSearch(string name, int rdo)
        {
            string query;
            string source;
            string targetPage ="";
            if(rdo == 1)
            {
            query = "select rating, title from movie where title like '%" + name + "%';";
            source = "movies";
            targetPage = "MovieReview.aspx";
               

                // if the radio button movie was selected in the search page, rdo value will be 1 so it will grab from movies in this page.
            }
            else if (rdo == 2)
            {
                query = "select rating, title from book where title like '%" + name + "%';";
                source = "books";
                // if the radio button book was selected in the search page, rdo value will be 2 so it will grab from book in this page.
                targetPage = "BookReview.aspx";
            }
            else
            {
                query = "select rating, title from song where title like '%" + name + "%';";
                source = "songs";
                targetPage = "MusicReview.aspx";
                // if the radio button song was selected in the search page, rdo value will be 3 so it will grab from songs in this page.
            }

            using (SqlConnection conn = new SqlConnection(cs))
            {
                int i = 0;
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                ArrayList al = new ArrayList();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        al.Add(reader.GetInt32(0));
                        // this is grabbing the rating and adding it to an array list
                        al.Add(reader.GetString(1));
                        // this is grabbing the title and adding it to an array list
                    }
                    while(i < al.Count)
                    {
                        if (i == 0)
                        {
                            Response.Write("<div id=\"banner\" align=\"center\" style=\"font-size: 26px; font-style: normal; font-family: Arial; font-weight: bold\"><br />The Ultimate<br />Review Website</div><br />");
                        }
                        // this is just html for the banner of the page/

                        Response.Write("<div id=\"resDiv\" align=\"center\">"+"Rating: " + al[i] + "/10 "+
                            " <img src=\"../../pictures/" + source + "/" + al[i + 1] + ".jpg\" width=\"150\" height=\"200\"> <br />Title: <a href=\"" + targetPage + "?title=" + al[i + 1] + "\">" + al[i + 1] + "</a><br /><br />" + "<div>");
                        // here I am using html to display the reults of the page. al[i] is the rating for the movie and al[i+1] is the title. I am using a query string to pass the title of the selected movie to the next page so it pulls reviews for that title.
                        
                        i = i + 2;
                        // I have to increment by two here because the way the values for the movies are being put into the array list, if i is 0, 0 = rating, 1 = title. so to get the next values I need to increment by two so 3 will be the next raiting and 4 will be the next title.
                    }
                }
                else
                {
                     Response.Write("<div id=\"banner\" align=\"center\" style=\"font-size: 26px; font-style: normal; font-family: Arial; font-weight: bold\"><br />The Ultimate<br />Review Website</div><br />");
                        
                    Response.Write("Sorry, there were not matches for your search");
                    // just displaying a simple message if there are no results for the users search.
                }
            }
        }
    }
}