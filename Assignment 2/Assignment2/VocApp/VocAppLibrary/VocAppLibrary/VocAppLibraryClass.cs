using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VocAppLibrary
{
    public class Word
    {
        public String Spelling { get; set; }
        public String Meaning { get; set; }
        public String SampleSentence { get; set; }
    }
    public class SearchWord
    {
        public Word checkWord(List<Word> wordList, string toBeSearched)
        {
            foreach (Word word in wordList)
            {
                if (word.Spelling.Equals(toBeSearched, StringComparison.InvariantCultureIgnoreCase))
                    return word;
            }
            return null;
        }
    }
}
