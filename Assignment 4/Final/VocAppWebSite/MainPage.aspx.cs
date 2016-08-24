// Assignment 4
// Team Members: Lakshmi Bhanu Priya-Z1760588,Maheshbabu-Z1761140,Mounica-Z1763165,Saarika-Z1758461,Shalini-Z1729868
// Due Date:05/03/2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VocAppLibrary;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page 
{
    List<Word> WordList;
    //Property to save the data with multiple hits on page
    private string EditSpelling
    {
        get
        {
            return ViewState["EditSpelling"] as string;
        }

        set
        {
            ViewState["EditSpelling"] = value;
        }
    }
     /// <summary>
     /// This is the main entry into this page
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
 
    protected void Page_Load(object sender, EventArgs e)
    {
        WordList = new List<Word>();
        dgvCompleteGridView.DataBind();
        string field1 = (string)(Session["field1"]);
        Label1.Text = "Welcome "+field1;
    }
    /// <summary>
    /// This event is invoked when save button is clicked
    /// It adds the words into text file only if the word doesnt exists
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btSave_Click(object sender, EventArgs e)
    {
        Word checkWordObj = new Word();
        SearchWord searchWordObj = new SearchWord();
        checkWordObj = searchWordObj.checkWord(WordList, tbSpelling.Text);
        if (String.IsNullOrEmpty(tbSpelling.Text) || String.IsNullOrEmpty(tbMeaning.Text) || String.IsNullOrEmpty(tbSampleSentence.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed", "alert('Please enter value in all fields.')", true);
        }
        //if the fields are not empty,stores into text file
        else
        {
                    //Check for word if it already exists
                    if (!(checkWordObj == null))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed", "alert('The word is already existing.Please Enter an other word')", true);
                        return;
                    }
                    else
                    {
                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WordsDBConnStr"].ConnectionString))
                        {
                            conn.Open();
                            //Insert into the table with current contents
                            string queryText = "insert into \"all-word-table\" values(@SpellingTxt, @MeaningTxt, @ExampleTxt, @TimeCreatedTxt,@TimeUpdatedTxt)";
                            SqlCommand cmd = new SqlCommand(queryText, conn);
                            cmd.Parameters.AddWithValue("@SpellingTxt", tbSpelling.Text);
                            cmd.Parameters.AddWithValue("@MeaningTxt", tbMeaning.Text);
                            cmd.Parameters.AddWithValue("@ExampleTxt", tbSampleSentence.Text);
                            cmd.Parameters.AddWithValue("@TimeCreatedTxt", DateTime.Now);
                            cmd.Parameters.AddWithValue("@TimeUpdatedTxt", DBNull.Value);

                            int rows = cmd.ExecuteNonQuery();
                            if (rows > 0)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Success", "alert('Word has been Added Successfully')", true);
                                dgvCompleteGridView.DataBind();
                            }
                            else
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed", "alert('Word has not been added.')", true);                                
                        }
                    }

                    //LoadData();
            }
        ClearFields();
    }
    /// <summary>
    /// This event is triggered by button "cancel" which is used to clear all the textfields on the form
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btCancel_Click(object sender, EventArgs e)
    {
        ClearFields();
    }
    /// <summary>
    /// This event is called by Search button to search for a 
    /// spelling and enter the text fields with the information found
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btSearch_Click(object sender, EventArgs e)
    {
        EditSpelling = string.Empty;
        //check to see if the text field is not empty
        if (!String.IsNullOrEmpty(tbSearchSpelling.Text))
        {
            Word checkWordObj = new Word();
            SearchWord searchWordObj = new SearchWord();
            checkWordObj = searchWordObj.checkWord(WordList, tbSearchSpelling.Text);
            if (!(checkWordObj == null))
            {
                tbSpelling.Text = checkWordObj.Spelling;
                tbMeaning.Text = checkWordObj.Meaning;
                tbSampleSentence.Text = checkWordObj.SampleSentence;
                EditSpelling = checkWordObj.Spelling;
            }
            //if the word is already present then alert a message
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed", "alert('Word searched is not on list,Word Not Found')", true);
                ClearFields();
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed", "alert('Search Field is empty,Please enter the word to search')", true);
            ClearFields();
        }       
    }
    /// <summary>
    /// This is triggered by User to edit the word and save it back to the database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btEdit_Click(object sender, EventArgs e)
    {
        //Open the connection and update the table if user is OK
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WordsDBConnStr"].ConnectionString))
        {
            conn.Open();
            //Select the row with the spelling to get ID
            string queryText1 = "select ID from \"all-word-table\" where Spelling = '" + EditSpelling + "'";
            SqlDataAdapter ada = new SqlDataAdapter(queryText1, conn);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr1 = dt.Rows[i];
                int id = Int32.Parse(dr1["ID"].ToString());//retrieve ID of the particular word
                string queryText = "update \"all-word-table\" set Spelling=@SpellingTxt, Meaning = @MeaningTxt, Example = @UsageTxt,TimeUpdated=@TimeUpdatedTxt where ID='" + id + "'";
                    SqlCommand cmd = new SqlCommand(queryText, conn);
                    cmd.Parameters.AddWithValue("@SpellingTxt", tbSpelling.Text);
                    cmd.Parameters.AddWithValue("@MeaningTxt", tbMeaning.Text);
                    cmd.Parameters.AddWithValue("@UsageTxt", tbSampleSentence.Text);
                    cmd.Parameters.AddWithValue("@TimeUpdatedTxt", DateTime.Now);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Success", "alert('Word has been edited Successfully')", true);
                        dgvCompleteGridView.DataBind();
                    }
                    else
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed", "alert('Word has not been edited.')", true);  
            }
            //ClearFields();
        }
    }
    /// <summary>
    /// This method is invoked when DeleteRow button is invoked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btDeleteRow_Click(object sender, EventArgs e)
    {
        //perform delete operation in the data source,by open the connection to db
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WordsDBConnStr"].ConnectionString))
            {
                conn.Open();
                string query = "delete from \"all-word-table\" where Spelling='" + dgvCompleteGridView.SelectedRow.Cells[1].Text + "'";//delete row in the table with spelling
                SqlCommand cmd = new SqlCommand(query, conn);

                int rows = cmd.ExecuteNonQuery();
                //Show message if the deletion is success or failed
                if (rows > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Success", "alert('Deletion Success')", true);
                    dgvCompleteGridView.DataBind();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed", "alert('Deletion Failure')", true);
                }
                ClearFields();
        }
    }
    /// <summary>
    ///  Selection changed when user selects or changes the selection of gridview
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dgvCompleteGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
           
            tbSpelling.Text = dgvCompleteGridView.SelectedRow.Cells[1].Text;
            tbMeaning.Text = dgvCompleteGridView.SelectedRow.Cells[2].Text;
            tbSampleSentence.Text = dgvCompleteGridView.SelectedRow.Cells[3].Text;
            EditSpelling = dgvCompleteGridView.SelectedRow.Cells[1].Text;

    }
    /// <summary>
    /// This method is used to clear all the textfields on the form
    /// </summary>
    private void ClearFields()
    {
        tbSpelling.Text = String.Empty;
        tbMeaning.Text = String.Empty;
        tbSampleSentence.Text = String.Empty;
        tbSearchSpelling.Text = String.Empty;
    }
    /// <summary>
    /// This method LoadData loads all the words from the file and binds it to the datagridview
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dgvCompleteGridView_DataBound(object sender, EventArgs e)
    {
        using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["WordsDBConnStr"].ConnectionString))
        {
            //Open the connection and do the operations
            sqlcon.Open();
            SqlDataAdapter dataadap = new SqlDataAdapter();
            //select table all-word-table
            dataadap.SelectCommand = new SqlCommand("Select * from \"all-word-table\"", sqlcon);
            DataSet ds = new DataSet();
            dataadap.Fill(ds);
            WordList.Clear();
            //retriew the words and display
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                WordList.Add(new Word()
                {
                    Spelling = dr["Spelling"].ToString(),
                    Meaning = dr["Meaning"].ToString(),
                    SampleSentence = dr["Example"].ToString(),
                    TimeCreated = Convert.ToDateTime(dr["TimeCreated"]),
                    TimeUpdated = (dr["TimeUpdated"] == DBNull.Value) ? (DateTime?)null : ((DateTime)dr["TimeUpdated"])
                });
            }
        }
    }
}