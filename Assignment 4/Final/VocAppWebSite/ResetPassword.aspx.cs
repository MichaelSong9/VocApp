// Assignment 4
// Team Members: Lakshmi Bhanu Priya-Z1760588,Maheshbabu-Z1761140,Mounica-Z1763165,Saarika-Z1758461,Shalini-Z1729868
// Due Date:05/03/2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// EXTRA CREDIT (RESET PASSWORD)
/// This is for Extra Credit where user can update the password
/// The user has to give his username and new password
/// It will check if username exists and updates the hashed password and salt string in the data source for the new password
/// and redirects to login page upon successful update
/// else displays an error message
/// </summary>
public partial class ResetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// This is trigged when user clicks set button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btSubmit_Click(object sender, EventArgs e)
    {
        string salt = CreateSalt(10);
        string passwordHash = CreatePasswordHash(Password.Text, salt);
        UpdateCustomerDetails(UserName.Text,passwordHash, salt);
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
    ///  Create hashed password and append with salt
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
    /// Open the connection and Update the details into it
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="passwordHash"></param>
    /// <param name="salt"></param>
    private void UpdateCustomerDetails(string userName, string passwordHash, string salt)
    {
        //set the connection
        string connString = "Data Source=10.158.56.48;Initial Catalog=notebase2;Persist Security Info=True;User ID=net2;Password=dtbz2";
        // Open the connection and Update into the table with current contents
        using (SqlConnection conn = new SqlConnection(connString))
        {
            conn.Open();
            //Select the row with the Username
            string queryText1 = "select Username from \"Customers\" where Username = '" + userName + "'";
            SqlDataAdapter ada = new SqlDataAdapter(queryText1, conn);
            DataTable dt = new DataTable();
            //Fill the datatable
            ada.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //Update the values
                    DataRow dr1 = dt.Rows[i];
                    string usrname = dr1["Username"].ToString();//retrieve ID of the particular word
                    string queryText = "update \"Customers\" set HashedPassword=@HashedPasswordTxt, Saltstring = @SaltstringTxt where Username='" + usrname + "'";
                    SqlCommand cmd = new SqlCommand(queryText, conn);
                    cmd.Parameters.AddWithValue("@HashedPasswordTxt", passwordHash);
                    cmd.Parameters.AddWithValue("@SaltstringTxt", salt);
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                        Response.Redirect("Login.aspx");
                    else
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failure", "alert('Update Unsuccessfull.')", true);
                }
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failure", "alert('User doesnt exist.')", true);

            conn.Close();
        }
    }

}