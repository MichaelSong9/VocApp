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
        string wordsFile = Directory.GetCurrentDirectory() + "\\" + "Words.txt";//the file name
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
            LoadData();//Calls the LoadData to retrieve words
            LoadDataFromDLL();
            BeginTimerControl();
            TimerCallback tb1 = new TimerCallback(this.sendData);
            System.Threading.Timer t1 = new System.Threading.Timer(tb1, DisplayWord, 2000, 2000);
        }
        /// <summary>
        /// This method loads data from dll and reads and rites into list
        /// </summary>
        public void LoadDataFromDLL()
        {
            //create a words object and store the words into list<word>
            words objDllData = new words();
             ltDllData = new List<word>();
            for (int i = 0; i < objDllData.Count; i++)
                 ltDllData.Add(objDllData[i]);
                       
        }
        /// <summary>
        /// This method LoadData loads all the words from the file and binds it to the datagridview
        /// </summary>
        public void LoadData()
        {
            WordList = new List<Word>();//object for the word class
            //Create an instance of streamReader to read from a file
            using (StreamReader reader = new StreamReader(wordsFile))
            {
                string line;
                //Read and display the lines untill it reaches EOF
                while ((line = reader.ReadLine()) != null)
                {
                    string[] Data = line.Split('*');
                    Word wordData = new Word();
                    wordData.Spelling = Data[0];
                    wordData.Meaning = Data[1];
                    wordData.SampleSentence = Data[2];
                    WordList.Add(wordData);

                }
                RefreshDataGridView();//calls to bind the data to datagridview
                reader.Close();//close the instance
            }
            ClearFields();//clears the already entered fields
        }
        /// <summary>
        /// This method is used to bind the data to the control
        /// </summary>
        private void RefreshDataGridView()
        {
            WordList = WordList.OrderBy(wOrder => wOrder.Spelling).ToList<Word>();
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
            checkWordObj = searchWordObj.checkWord(WordList, tbSpelling.Text);//calls the method in the library to check the word 
            //see if the text fields are not empty and alert the user to enter all the fields
            if (String.IsNullOrEmpty(tbSpelling.Text) || String.IsNullOrEmpty(tbMeaning.Text) || String.IsNullOrEmpty(tbSampleSentence.Text))
            {
                MessageBox.Show("Please enter value in all fields.", "Error in adding word");
            }
                //if the fields are not empty,stores into text file
            else
            {
                //checks if the word is already present in the text file
                if (!(checkWordObj == null))
                {
                    MessageBox.Show("The word is already existing.Please Enter an other word");
                    return;
                }
                //if it is new word,adds into text file by writing it
                //creates a instance of writer in write mode
                StreamWriter writer = new StreamWriter(wordsFile, true);

                string line = string.Concat(tbSpelling.Text, "*", tbMeaning.Text, "*",
                                   tbSampleSentence.Text);
                //append the word to file
                try
                {
                    writer.WriteLine(line);
                    writer.Close();
                    LoadData();//update datagridview with new word
                }
                    //let the user know what went wrong in appending the line
                catch (Exception ex)
                {

                    MessageBox.Show("There is some error caught. Err: " + ex.Message);
                }
            }
            ClearFields();//reset the fields
        }
        /// <summary>
        /// This event is called by Search button to search for a 
        /// spelling and enter the text fields with the information found
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSearch_Click(object sender, EventArgs e)
        {
           
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
                    //get the selected rows from gridview
                    DataGridViewRow selectedRow = dgvCompleteGridView.SelectedRows[0];
                    DeleteRowFromDataSource((Word)selectedRow.DataBoundItem);
                    int selectedIndex = selectedRow.Index;//get the index
                    CompleteViewBindingSource.RemoveAt(selectedIndex);//remove the selected one
                    RefreshDataGridView();
            }

        }
        /// <summary>
        /// Deletes the word from the dataSource and updates the list
        /// </summary>
        /// <param name="wordData"></param>
        private void DeleteRowFromDataSource(Word wordData)
        {
            //Delete the word from text file 
            //else throw an exception of error
            try
            {
                List<string> ltFileLines = new List<string>();
                ltFileLines = File.ReadAllLines(wordsFile).ToList();//Read the words from file
                //if the selected word exists in the read list from above ,delete it
                for (int i = 0; i < ltFileLines.Count; i++)
                {
                    if (ltFileLines[i] == string.Concat(wordData.Spelling, "*", wordData.Meaning, "*", wordData.SampleSentence))
                        ltFileLines.RemoveAt(i);
                }
                //write back to the text file
                StreamWriter writer = new StreamWriter(wordsFile, false);
                foreach (string line in ltFileLines)
                    writer.WriteLine(line);
                writer.Close();
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
            timerTick.Tick+=new EventHandler(timerTick_Tick);//Event to call the method tick and update every second
            timerTick.Start();
        }

        /// <summary>
        /// This method is invoked every 1 second .
        /// In this method,the value is incremetd by 1 sec
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timerTick_Tick(object sender, EventArgs e)
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
            WordEventObj.Meaning = ltDllData[dataIndex].Meaning;
            WordEventObj.SampleSentence = ltDllData[dataIndex].Example;
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
       void DisplayWordHandler(object sender,WordEventArgs e)
       {
           //This is to prevent InvalidOperationException
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new DisplayWordEventHandler(DisplayWordHandler), new object[] { sender, e });
                return;
 
           }
           //set the words to labels and display
            lbSpellingFromEvent.Text = "Spelling from WordEventArgs is "+ e.Spelling;
            lbMeaningFromEvent.Text = "Spelling from WordEventArgs is " + e.Meaning;
            lbSampleSentFromEvent.Text = "Spelling from WordEventArgs is " + e.SampleSentence;

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
               lbMeaningFromEvent.Text = string.Empty;
               lbSampleSentFromEvent.Text = string.Empty;
           }

       }
        /// <summary>
        /// This class inherits EventArgs.It contains properties of word information
        /// </summary>
        public class WordEventArgs : EventArgs
        {
            //properties for spelling,Meaning,Sample Sentence
            public String Spelling { get; set; }
            public String Meaning { get; set; }
            public String SampleSentence { get; set; }
        }

       
    }
}
