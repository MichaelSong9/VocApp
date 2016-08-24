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

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Submit Button was clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btSubmit_Click(object sender, EventArgs e)
    {
        string salt = CreateSalt(10);
        string passwordHash = CreatePasswordHash(Password.Text, salt);
        StoreCustomerDetails(UserName.Text, passwordHash,salt);
        
    }
    /// <summary>
    /// This method is used to create a salt string randomly 
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    public string CreateSalt(int size)
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buff = new byte[size];
        rng.GetBytes(buff);
        return Convert.ToBase64String(buff);
    }
    /// <summary>
    /// Create hashed password and append with salt
    /// </summary>
    /// <param name="pwd"></param>
    /// <param name="salt"></param>
    /// <returns></returns>
    public static string CreatePasswordHash(string pwd, string salt)
    {
        string saltAndPwd = String.Concat(pwd, salt);
        string hashedPwd =
              FormsAuthentication.HashPasswordForStoringInConfigFile(
                                                   saltAndPwd, "MD5");
        hashedPwd = String.Concat(hashedPwd, salt);
        int n = hashedPwd.Length;
        return hashedPwd;
    }
    /// <summary>
    /// Open the connection and store the details into it
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="passwordHash"></param>
    /// <param name="salt"></param>
    private void StoreCustomerDetails(string userName,string passwordHash,string salt)
    {
        //set the connection
         string connString = "Data Source=10.158.56.48;Initial Catalog=notebase2;Persist Security Info=True;User ID=net2;Password=dtbz2";
         SqlConnection conn = new SqlConnection(connString);                           
         //Insert into the table with current contents
         string queryText = "insert into \"Customers\" (Username,HashedPassword,Saltstring)" + "values(@UsernameTxt, @HashedPasswordTxt, @SaltstringTxt)";
         SqlCommand cmd = new SqlCommand(queryText, conn);
        //Enter the values
         cmd.Parameters.AddWithValue("@UsernameTxt", userName);
         cmd.Parameters.AddWithValue("@HashedPasswordTxt", passwordHash);
         cmd.Parameters.AddWithValue("@SaltstringTxt", salt);
        //if successful in updation ,redirect the user to login page
         try
         {
             conn.Open();
             int x=cmd.ExecuteNonQuery();
             Response.Redirect("Login.aspx");
         }
             //else throw an error
         catch( SqlException ex )
         {
            string g = ex.Message;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Success", "alert(g)", true);
             
         }
             //Close the connection
         finally
         {
              conn.Close();
         } 
      }
    }