// Assignment 2
// Team Members: Lakshmi Bhanu Priya-Z1760588,Maheshbabu-Z1761140,Mounica-Z1763165,Saarika-Z1758461,Shalini-Z1729868
// Due Date:02/29/2016
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using VocAppLibrary;
using wordContainer;
using System.Threading;
using System.Data.SqlClient;

namespace VocApp
{
    /// <summary>
    /// This is the main form of the application which 
    /// displays the words from datasource and also adds a new word
    /// </summary>
    public partial class VocApp : Form
    {
        List<Word> WordList;
        List<word> ltDllData;
        List<WordEventArgs> ltFlashWords;
        string wordsFile = Directory.GetCurrentDirectory() + "\\" + "Words.txt";//the file name
        string connString = "Data Source=10.158.56.48;Initial Catalog=notebase2;Persist Security Info=True;User ID=net2;Password=dtbz2";
        string EditSpelling = String.Empty;
        BindingSource CompleteViewBindingSource;
        //Event Handler and its event
        public delegate void DisplayWordEventHandler(object sender, WordEventArgs e);
        public event DisplayWordEventHandler DisplayWord;
        /// <summary>
        /// Default parameterless constructor that intializes the components.
        /// </summary>
        public VocApp()
        {
            InitializeComponent();
            WordList = new List<Word>();
            ltFlashWords = new List<WordEventArgs>();
            ResizeRedraw = true;
            CompleteViewBindingSource = new BindingSource();
        }
        /// <summary>
        /// VocApp_Load is the the event of form load that will occur when the form is being loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VocApp_Load(object sender, EventArgs e)
        {
            LoadDataFromTables();
            cbSortCompleteView.DataSource = new List<String>() { "Spelling", "Time Created" ,"Time Updated"};
            LoadData();//Calls the LoadData to retrieve words
            LoadFlashTable();
            BeginTimerControl();
            TimerCallback tb1 = new TimerCallback(this.sendData);
            System.Threading.Timer t1 = new System.Threading.Timer(tb1, DisplayWord, 2000, 2000);
        }
        /// <summary>
        /// 
        /// </summary>
        private void ReadFlashTable()
        {      //Open the connection to retrieve the details
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlDataAdapter adap = new SqlDataAdapter();
                adap.SelectCommand = new SqlCommand("Select Spelling from  \"flash-word-table\"", conn);//select the flash-word-table
                DataSet ds = new DataSet();
                adap.Fill(ds);
                //add the words to list
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ltFlashWords.Add(new WordEventArgs()
                    {
                        Spelling = row["Spelling"].ToString()
                    });
                }
            }
        }
        /// <summary>
        /// Load the Table with the details from wordContainer.dll
        /// </summary>
        private void LoadFlashTable()
        {
            words objDllData = new words();
            ltDllData = new List<word>();
            for (int i = 0; i < objDllData.Count; i++)
                ltDllData.Add(objDllData[i]);
            //Open the connection and insert the words into flash-word-table by checking if the word already exists or not
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    foreach (WordEventArgs word in ltFlashWords)
                    {
                        //check if the word already exists else discard it
                        string checkquery = "select Spelling from \"flash-word-table\" where Spelling='" + word.Spelling + "'";
                        SqlCommand sqlcmd = new SqlCommand(checkquery, conn);
                        Object spelling = sqlcmd.ExecuteScalar();
                        if (spelling == null)
                        {
                            string queryText = "insert into \"flash-word-table\" values('" + word.Spelling + "')";
                            SqlCommand cmd = new SqlCommand(queryText, conn);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("There is some error caught. Err: " + ex.Message);
            }
            ReadFlashTable();
        }
        /// <summary>
        /// This method LoadData loads all the words from the file and binds it to the datagridview
        /// </summary>
        public void LoadData()
        {          
            string connString = "Data Source=10.158.56.48;Initial Catalog=notebase2;Persist Security Info=True;User ID=net2;Password=dtbz2";
            //create the connection
            using (SqlConnection sqlcon = new SqlConnection(connString))
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
                        TimeUpdated = (dr["TimeUpdated"]==DBNull.Value)?(DateTime?)null:((DateTime)dr["TimeUpdated"])
                    });
                }
                RefreshDataGridView();

            }
            ClearFields();//clears the already entered fields
        }
        /// <summary>
        /// This method is used to bind the data to the control
        /// </summary>
        private void RefreshDataGridView()
        {
            //sort and display with Spelling,Time Created,Time Updated
            if (cbSortCompleteView.SelectedValue != null && cbSortCompleteView.SelectedValue.ToString() == "Spelling")
                WordList = WordList.OrderBy(w => w.Spelling).ToList<Word>();
            else if (cbSortCompleteView.SelectedValue != null && cbSortCompleteView.SelectedValue.ToString() == "Time Created")
                WordList = WordList.OrderBy(w => w.TimeCreated).ToList<Word>();
            else if (cbSortCompleteView.SelectedValue != null && cbSortCompleteView.SelectedValue.ToString() == "Time Updated")
                WordList = WordList.OrderBy(w => w.TimeUpdated).ToList<Word>();

            CompleteViewBindingSource.DataSource = WordList;
            dgvCompleteGridView.DataSource = CompleteViewBindingSource;//binding into the control

        }
        /// <summary>
        /// This event is triggered by button "cancel" which is used to clear all the textfields on the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
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
        /// This event is invoked when save button is clicked
        /// It adds the words into text file only if the word doesnt exists
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSave_Click(object sender, EventArgs e)
        {           
            Word checkWordObj = new Word();
            SearchWord searchWordObj = new SearchWord();
            checkWordObj = searchWordObj.checkWord(WordList, tbSpelling.Text);
            if (String.IsNullOrEmpty(tbSpelling.Text) || String.IsNullOrEmpty(tbMeaning.Text) || String.IsNullOrEmpty(tbSampleSentence.Text))
            {
                MessageBox.Show("Please enter value in all fields.", "Error in adding word");
            }
            //if the fields are not empty,stores into text file
            else
            {
                //MessageBox to confirm addition
                DialogResult dr = MessageBox.Show("Do you want to add this word to database?", "Word Addition", MessageBoxButtons.YesNo);
                //if the user wants to save the add ,add it to database
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        //Check for word if it already exists
                        if (!(checkWordObj == null))
                        {
                            MessageBox.Show("The word is already existing.Please Enter an other word");
                            return;
                        }
                        else
                        {
                            using (SqlConnection conn = new SqlConnection(connString))
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
                                    MessageBox.Show("Word has been added successfully.", "Success");
                                else
                                    MessageBox.Show("Word has not been added.", "Fail");
                            }
                        }

                        LoadData();
                    }

                   // If Inner Exception occurs, the message for tht exception is displyed
                    // else normal exception is displayed.
                    catch (Exception ex)
                    {

                        MessageBox.Show("There is some error caught. Err: " + ex.Message);
                    }
                }
            }
            ClearFields();
        }
        /// <summary>
        /// This event is called by Search button to search for a 
        /// spelling and enter the text fields with the information found
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSearch_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Word searched is not on list", "Word Not Found");
                    ClearFields();
                }
            }
            else
            {
                MessageBox.Show("Search Field is empty", "Please enter the word to search");
                ClearFields();
            }

        }
        /// <summary>
        /// this is invoked by paint event of form to draw the borders around the clientarea
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VocApp_Paint(object sender, PaintEventArgs e)
        {
            var borderColorCadetBlue = Color.CadetBlue;
            var borderColorLightGray = Color.LightGray;
            var borderStyle = ButtonBorderStyle.Solid;
            var borderWidth = 10;

            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, borderColorCadetBlue, borderWidth,
                                borderStyle, borderColorCadetBlue, borderWidth, borderStyle, borderColorLightGray,
                                borderWidth, borderStyle, borderColorLightGray, borderWidth, borderStyle);
        }
        /// <summary>
        /// This method is invoked when DeleteRow button is invoked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDeleteRow_Click(object sender, EventArgs e)
        {
            //Delete the word only if any word is selected
            if (dgvCompleteGridView.SelectedRows.Count > 0)
            {
                //Messagebox to get the user confirmation
                DialogResult dr = MessageBox.Show("Do you really want to delete the file?", "Confirm Delete", MessageBoxButtons.OKCancel);

                //delete operation if user selection is OK, else the selection must be cleared.
                if (dr == DialogResult.OK)
                {
                    //get the selected rows from gridview
                    DataGridViewRow selectedRow = dgvCompleteGridView.SelectedRows[0];
                    DeleteRowFromDataSource((Word)selectedRow.DataBoundItem);
                    int selectedIndex = selectedRow.Index;//get the index
                    CompleteViewBindingSource.RemoveAt(selectedIndex);//remove the selected one
                    RefreshDataGridView();
                }
                else
                {
                    dgvCompleteGridView.ClearSelection();
                }
            }
            ClearFields();

        }
        /// <summary>
        /// Deletes the word from the dataSource and updates the list
        /// </summary>
        /// <param name="wordData"></param>
        private void DeleteRowFromDataSource(Word wordData)
        {
            //perform delete operation in the data source,by open the connection to db
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = "delete from \"all-word-table\" where Spelling='" + wordData.Spelling + "'";//delete row in the table with spelling
                    SqlCommand cmd = new SqlCommand(query, conn);

                    int rows = cmd.ExecuteNonQuery();
                    //Show message if the deletion is success or failed
                    if (rows > 0)
                    {
                        MessageBox.Show("Deletion Success", "Success");
                    }
                    else
                    {
                        MessageBox.Show("Deletion Failure", "Failure");
                    }
                }
            }
            catch (Exception ex)
              {
                  MessageBox.Show("Error in deleting the selected line. Err: " + ex.Message);
              }

        }
        /// <summary>
        /// This is invoked to show the current time
        /// </summary>
        private void BeginTimerControl()
        {      //current time is assigned to label    
            lbTimer.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            //An object to create timer
            System.Windows.Forms.Timer timerTick = new System.Windows.Forms.Timer();
            timerTick.Interval = 1000;
            timerTick.Tick += delegate(object sender, EventArgs e)
            {
                String[] curVal = lbTimer.Text.Split(':');//get the current time and split

                int Second = Convert.ToInt32(curVal[2]);
                int Minute = Convert.ToInt32(curVal[1]);
                int Hour = Convert.ToInt32(curVal[0]);
                Second++;
                //Logic to check secs and mins raech 60 and set to 0.
                if (Second == 60)
                {
                    Second = 0;
                    Minute++;
                    if (Minute == 60)
                    {
                        Minute = 0;
                        Hour++;

                        if (Hour == 24)
                            Hour = 0;
                    }
                }
                lbTimer.Text = Hour.ToString() + ":" + Minute.ToString() + ":" + Second.ToString();
            };
            // timerTick.Tick+=new EventHandler(timerTick_Tick);//Event to call the method tick and update every second
            timerTick.Start();
        }
        /// <summary>
        /// This method is invoked every few seconds and sends a random word from the list
        /// </summary>
        /// <param name="state"></param>
        public void sendData(object state)
        {
            //Random class to get a index
            Random randNum = new Random();
            WordEventArgs WordEventObj = new WordEventArgs();
            //get the index and bind it to wordeventags
            int dataIndex = randNum.Next(0, ltDllData.Count);
            WordEventObj.Spelling = ltDllData[dataIndex].Spelling;
            if (DisplayWord != null)
            {
                DisplayWord.Invoke(this, WordEventObj);
            }

        }
        /// <summary>
        /// This method is invoked every 2 seconds and gets the word and displays it on window
        /// </summary>
        /// <param name="sender">sender of this event</param>
        /// <param name="e">properties of word to display</param>
        void DisplayWordHandler(object sender, WordEventArgs e)
        {
            //This is to prevent InvalidOperationException
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new DisplayWordEventHandler(DisplayWordHandler), new object[] { sender, e });
                return;

            }
            //set the words to labels and display
             lbSpellingFromEvent.Text = "Spelling from WordEventArgs is "+ e.Spelling;

        }
        /// <summary>
        /// This is invoke when the button "Turns Words On" is clicked
        /// It adds or removes the event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         private void btTurnWordsOn_Click(object sender, EventArgs e)
         {
             //Check the text of button and register the event and unregister it
             if (btTurnWordsOn.Text == "Turn Words On")
             {
                 DisplayWord += new DisplayWordEventHandler(DisplayWordHandler);//Register it
                 btTurnWordsOn.Text = "Turn Words Off";
             }
             else if (btTurnWordsOn.Text == "Turn Words Off")
             {
                 DisplayWord -= new DisplayWordEventHandler(DisplayWordHandler);//Unregister it
                 btTurnWordsOn.Text = "Turn Words On";
                 lbSpellingFromEvent.Text = string.Empty;                
             }

         }
        /// <summary>
        /// This class inherits EventArgs.It contains properties of word information
        /// </summary>
        public class WordEventArgs : EventArgs
        {
            //properties for spelling,Meaning,Sample Sentence
            public String Spelling { get; set; }
        }
        /// <summary>
        /// This class loads lable if there is no table 
        /// </summary>
        private void LoadDataFromTables()
        {
            CreateTableIfNotExists("all-word-table", "Create Table \"all-word-table\"(ID INT identity(1,1) PRIMARY KEY,Spelling VARCHAR(100) , Meaning VARCHAR(500), Example VARCHAR(500), TimeCreated DateTime NOT NULL DEFAULT(GETDATE()),TimeUpdated DateTime DEFAULT NULL)");//Create Table all-word-table
            CreateTableIfNotExists("flash-word-table", "Create Table \"flash-word-table\"(Spelling VARCHAR(100) PRIMARY KEY)");//creates Flash-word-Table
        }
        /// <summary>
        /// CreatetableIfNotExists is called when there is a need to create table
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="createquery"></param>
        private void CreateTableIfNotExists(string tablename, string createquery)
        {
            using (SqlConnection sqlcon = new SqlConnection(connString))
            {
                //Open the connection
                sqlcon.Open();
                string text = "Select Count(*) from sysObjects WHERE name = '" + tablename + "'";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;//set the connection to sqlcommand
                cmd.CommandText = text;
                int res = (int)cmd.ExecuteScalar();//check the result of command
                if (res == 0)
                {
                    SqlCommand SqlCmd = new SqlCommand(createquery, sqlcon);
                    SqlCmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// This method is called when there is a selection with sorting order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSortCompleteView_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }
        /// <summary>
        /// This is triggered by User to edit the word and save it back to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btEdit_Click(object sender, EventArgs e)
        {          
            //Open the connection and update the table if user is OK
               using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                   //Select the row with the spelling to get ID
                    string queryText1 = "select ID from \"all-word-table\" where Spelling = '"+EditSpelling+"'";
                    SqlDataAdapter ada = new SqlDataAdapter(queryText1, conn);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    for(int i=0;i<dt.Rows.Count;i++)
                    {
                        DataRow dr1=dt.Rows[i];
                        int id=Int32.Parse(dr1["ID"].ToString());//retrieve ID of the particular word
                        string queryText = "update \"all-word-table\" set Spelling=@SpellingTxt, Meaning = @MeaningTxt, Example = @UsageTxt,TimeUpdated=@TimeUpdatedTxt where ID='" + id + "'";
                        DialogResult dr = MessageBox.Show("Do you want to edit this word to database?", "Word Edit", MessageBoxButtons.YesNo);
                        //Update the entries if OK,
                        //else ignore it.
                        if (dr == System.Windows.Forms.DialogResult.Yes)
                        {
                            SqlCommand cmd = new SqlCommand(queryText, conn);
                            cmd.Parameters.AddWithValue("@SpellingTxt", tbSpelling.Text);
                            cmd.Parameters.AddWithValue("@MeaningTxt", tbMeaning.Text);
                            cmd.Parameters.AddWithValue("@UsageTxt", tbSampleSentence.Text);
                            cmd.Parameters.AddWithValue("@TimeUpdatedTxt", DateTime.Now);
                            int rows = cmd.ExecuteNonQuery();
                            if (rows > 0)
                            //Show Message box on success.
                                MessageBox.Show("Word has been edited successfully.", "Success");
                            else
                             MessageBox.Show("Word has not been edited.", "Fail");
                        }
                        LoadData();
                    }
                    //ClearFields();
                }
            }
        /// <summary>
        /// Selection changed when user selects or changes the selection of gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCompleteGridView_SelectionChanged(object sender, EventArgs e)
        {
            //Retrieve the spelling from the selected word
            EditSpelling = string.Empty;
            if (dgvCompleteGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCompleteGridView.SelectedRows[0];
                Word editWord = (Word)selectedRow.DataBoundItem;
                tbSpelling.Text = editWord.Spelling;
                tbMeaning.Text = editWord.Meaning;
                tbSampleSentence.Text = editWord.SampleSentence;
                EditSpelling = editWord.Spelling;

            }
        }
        /// <summary>
        /// This EventHandler is used to Add a new flash word from CompleteView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAddFlashWord_Click(object sender, EventArgs e)
        {
            //Select a word and add it to the table
            if (dgvCompleteGridView.SelectedRows.Count > 0)
            {               
                DataGridViewRow selectedRow = dgvCompleteGridView.SelectedRows[0];
                Word editWord = (Word)selectedRow.DataBoundItem;
                if (!ltFlashWords.Any(Word => Word.Spelling == editWord.Spelling))
                {
                    ltFlashWords.Add(new WordEventArgs() { Spelling = editWord.Spelling });
                    
                }
                dgvCompleteGridView.ClearSelection();
                MessageBox.Show("Word has been added successfully to flash list", "Add word to flash");
            }
        }
        /// <summary>
        /// This EventHandler is used to save the flashword to the Flash-word-table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSaveFlashWord_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                foreach (WordEventArgs word in ltFlashWords)
                {
                    string checkquery = "select Spelling from \"flash-word-table\" where Spelling='" + word.Spelling + "'";
                    SqlCommand sqlcmd = new SqlCommand(checkquery, conn);
                    Object spelling = sqlcmd.ExecuteScalar();


                    if (spelling == null)
                    {
                        string queryText = "insert into \"flash-word-table\" values('" + word.Spelling + "')";
                        SqlCommand cmd = new SqlCommand(queryText, conn);
                        cmd.ExecuteNonQuery();

                    }
                }
            }
        }
        /// <summary>
        /// This EventHandler is used to remove the flash word
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btRemoveFlashWord_Click(object sender, EventArgs e)
        {
            //get the word to delete from UI and delete that word
            if (!String.IsNullOrEmpty(tbFlashSpellingDelete.Text))
            {
                int index = -1;
                index = ltFlashWords.FindIndex(word => word.Spelling == tbFlashSpellingDelete.Text);
                if (index != -1)
                    ltFlashWords.RemoveAt(index);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    //Open the connection and delete the word
                    conn.Open();
                    string query = "delete from \"flash-word-table\" where Spelling='" + tbFlashSpellingDelete.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Deletion Success", "Success");
                    }
                    else
                    {
                        MessageBox.Show("Deletion Failure due to some error", "Failure");
                    }
                }
                tbFlashSpellingDelete.Text = String.Empty;
                
            }
        }
    }
}
