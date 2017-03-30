using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MediaProject
{
    public partial class Login : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["cs_UserDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //add code to connect to user table in the database

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            string query = "Select Username from [User] where Username=@Username and Password=@Password;";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                conn.Open();

                string user = (string)cmd.ExecuteScalar();

                if (user != null)  //if user is found in the database
                {
                    Session["New"] = txtUsername.Text.Trim();    //store the username in a session
                    Response.Redirect("Member.aspx"); //direct the user to the homepage
                }
                else
                {
                    lblMessage.Text = "Username or Password is incorrect. Please try again!";  //show error message if user doen't exist in database
                }
            }
        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx"); 
            //new users will be directed to this page too create an account
        }
    }
}