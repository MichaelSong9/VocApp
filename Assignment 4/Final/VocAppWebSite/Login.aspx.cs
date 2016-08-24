// Assignment 4
// Team Members: Lakshmi Bhanu Priya-Z1760588,Maheshbabu-Z1761140,Mounica-Z1763165,Saarika-Z1758461,Shalini-Z1729868
// Due Date:05/03/2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    string salt;
    string hashedPassword;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Login Button was clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btLogin_Click(object sender, EventArgs e)
    {
        //Check if the username is existing and then redirect to main page
        //Else
        //Send the new user to registration page
        if (VerifyPassword(UserName.Text, Password.Text))
        {
            FormsAuthentication.RedirectFromLoginPage(UserName.Text, true);// direct to mainpage
            Session["field1"] = UserName.Text;
            
        }
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed", "alert('An Error with the hashed password')", true);
    }
    /// <summary>
    /// Check to see if Username exists and the password matches with the entered password
    /// </summary>
    /// <param name="UserNameProvided"></param>
    /// <param name="PasswordProvided"></param>
    /// <returns></returns>
    public bool VerifyPassword(string UserNameProvided,string PasswordProvided)
    {
            bool passwordMatch = false;
        //set the connection
            string connString = "Data Source=10.158.56.48;Initial Catalog=notebase2;Persist Security Info=True;User ID=net2;Password=dtbz2";
            SqlConnection conn = new SqlConnection(connString);
        //open the connection
            conn.Open();
            //Select the row with the Username 
            string queryText1 = "select * from \"Customers\" where Username = '" + UserNameProvided + "'";
            SqlDataAdapter ada = new SqlDataAdapter(queryText1, conn);
            DataTable dt = new DataTable();
        //Fill the data table
            ada.Fill(dt);
        //Check if user exists 
        //else
        //redirect to registration page
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //get the saltstring and hashed password 
                    DataRow dr1 = dt.Rows[i];
                    salt = dr1["Saltstring"].ToString();
                    hashedPassword = dr1["HashedPassword"].ToString();
                }
                //create the password with retrieved salt
                string HashPwdCreated = CreatePasswordHash(Password.Text, salt);
                //check if the two passwords matches
                passwordMatch = HashPwdCreated.Equals(hashedPassword); 
            }
            else
              Response.Redirect("Register.aspx");
           conn.Close();
                return passwordMatch;
       
    }
    /// <summary>
    /// This method is used to create password
    /// </summary>
    /// <param name="pwd"></param>
    /// <param name="salt"></param>
    /// <returns></returns>
    public static string CreatePasswordHash(string pwd, string salt)
    {
        //Concat the password with salt
        string saltAndPwd = String.Concat(pwd, salt);
        //get the hashpassword with forms authentication
        string hashedPwd =
              FormsAuthentication.HashPasswordForStoringInConfigFile(
                                                   saltAndPwd, "MD5");
        hashedPwd = String.Concat(hashedPwd, salt);
        return hashedPwd;
    }
}