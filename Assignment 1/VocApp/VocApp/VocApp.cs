// Assignment 1
// Team Members: Lakshmi Bhanu Priya-Z1760588,Maheshbabu-Z1761140,Mounica-Z1763165,Saarika-Z1758461,Shalini-Z1729868
// Due Date:02/09/2016
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

namespace VocApp
{
    /// <summary>
    /// This is the main form of the application which 
    /// displays the words from datasource and also adds a new word
    /// </summary>
    public partial class VocApp : Form
    {
        List<Word> WordList;
        string wordsFile = Directory.GetCurrentDirectory() + "\\" + "Words.txt";//the file name
        BindingSource CompleteViewBindingSource;
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
                bool found = false;
            
                foreach (Word word in WordList)
                {
                    //check if the spelling matches with the existing data and display meaning and sample sentence 
                    if (word.Spelling.Equals(tbSearchSpelling.Text, StringComparison.InvariantCultureIgnoreCase))
                    {
                        tbSpelling.Text = word.Spelling;
                        tbMeaning.Text = word.Meaning;
                        tbSampleSentence.Text = word.SampleSentence;
                        found = true;

                    }
                }
                //if the word is already present then alert a message
                if (!found)
                {
                    MessageBox.Show("Word searched is not on list", "Word Not Found");
                    ClearFields();
                }
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
    }
}
