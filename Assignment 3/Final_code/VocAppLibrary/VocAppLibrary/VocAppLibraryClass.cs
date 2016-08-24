// Assignment 2
// Team Members: Lakshmi Bhanu Priya-Z1760588,Maheshbabu-Z1761140,Mounica-Z1763165,Saarika-Z1758461,Shalini-Z1729868
// Due Date:02/29/2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VocAppLibrary
{
    /// <summary>
    ///  Word class holds the properties such as Spelling, Meaning and SampleSentence.
    /// </summary>
    public class Word
    {
        //Properties for word
        public String Spelling { get; set; }
        public String Meaning { get; set; }
        public String SampleSentence { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeUpdated
        {
            get;
            set;
        }
    }
    /// <summary>
    /// SearchWord class holds method Checkword that implements it. 
    /// </summary>
    public class SearchWord
    {
        /// <summary>
        /// This Method checks if the "toBeSearched"word already exists in the given datasource.
        /// </summary>
        /// <param name="wordList"></param>
        /// <param name="toBeSearched"></param>
        /// <returns>Returns word object if the "toBeSearched" exists else returns null</returns>
        public Word checkWord(List<Word> wordList, string toBeSearched)
        {
            //iterate through each object
            foreach (Word word in wordList)
            {
                //checks if the spelling of the word object exists and returns object 
                if (word.Spelling.Equals(toBeSearched, StringComparison.InvariantCultureIgnoreCase))
                    return word;
            }
            return null;
        }
    }
}
