using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;

namespace MediaProject
{
    public partial class Register : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["cs_UserDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{

        //}

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("Login.aspx");
        //}

        //protected void Button1_Click1(object sender, EventArgs e)
        //{
        //    Response.Redirect("Login.aspx");
        //}

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //password and confirm password validation is done first
            //once confirmation that the password and confirm password matches
            //the page will execute
            if (string.Compare(txtPassword.Text.Trim(), txtConfirmPassword.Text.Trim()) != 0)
            {
                lblMessage.Text = "Passwords do not match!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                //user will enter text, saved in variables
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                if (IsUserExists(username)) //this checks if the username already exists
                {
                    lblMessage.Text = "The username " + txtUsername.Text + " already exists! Please choose another name";
                    lblMessage.ForeColor = System.Drawing.Color.Red;

                }
                else
                {
                    string query2 = "Insert into [User] (FirstName,LastName,Email,Username,Password) values (@FirstName, @LastName, @Email, @Username, @Password);";

                    using (SqlConnection conn = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand(query2, conn);
                        cmd.Parameters.AddWithValue("@FirstName", txtFName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLName.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                        conn.Open(); 

                        int rowsInserted = cmd.ExecuteNonQuery();

                        if (rowsInserted > 0) //successfully inserted
                        {
                            Session["New"] = txtUsername.Text.Trim(); 
                            //save the user in a session
                            Response.Redirect("Member.aspx"); 
                            //direct the user to the member page
                        }
                        else
                        {
                            lblMessage.Text = "Registration Failed. Please try again!";
                            lblMessage.ForeColor = System.Drawing.Color.Red;

                        }

                    }

                }
            }

            //lblMessage.Text = "Congratulations " + txtUsername.Text + "!  You have successfully registered";  

           
        }

        //protected void btnLoginPage_Click(object sender, EventArgs e)
        //{
        //    //Response.Redirect("Login.aspx");
        //}

        protected void LinkLoginPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");   //direct the user to the login page
        }


        private bool IsUserExists(string username)
        {
            //The following code will check that database to see if the user exists
            string query = "Select Username from [User] where Username=@Username;";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username); //parameterized queries
                conn.Open(); //open the connection

                string user = (string)cmd.ExecuteScalar();
                if (user != null) 
                {
                    return true;  //username exists
                }
                else
                {
                    return false; //username doesn't exist
                }
            }
        }

        //protected void btnReset_Click(object sender, EventArgs e)
        //{

        //}


    }
        
}