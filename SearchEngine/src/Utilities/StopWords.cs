using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Utilities
{
    /// <summary>
    /// Class for StopWords Processing
    /// </summary>
    public static class StopWords
    {
        /// <summary>
        /// A data structure to hold all the stopwords
        /// </summary>
        private static HashSet<string> _stopWords;
        private static string _text;

        /*_stopWords = new HashSet<string> { "a", "an", "and", "are", "as", "at", "be", "but", "by", "for",
        "if", "in", "into", "is", "it", "no", "not", "of", "on", "or", "such", "that", "the",
        "their", "then", "there", "these", "they", "this", "to", "was", "will", "with"};*/

        /// <summary>
        /// A method that removes all the stopwords in a text
        /// </summary>
        /// <param name="text">A string of words that needs to be tokenized</param>
        /// <returns>A new text with all stopwords removed</returns>
        public static string RemoveStopWords(HashSet<string> stopWords, string text)
        {
            foreach (string word in stopWords)
            {
                CaseFolder.CaseFold(word);
            }
            _stopWords = stopWords;
            _text = text;

            StringBuilder sb = new();
            List<string> splitted_text = Strip(_text);
            string last_word = splitted_text[splitted_text.Count-1];
            foreach (string txt in splitted_text)
            {
                if (!_stopWords.Contains(CaseFolder.CaseFold(txt)))
                {
                    sb.Append(CaseFolder.CaseFold(txt));
                    if (!txt.Equals(last_word))
                    {
                        sb.Append(CaseFolder.CaseFold(" "));
                    }
                }

            }
            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// Method to strip off all unimportant tokens 
        /// such as whitespace and other non Alpha-Numeric characters
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static List<string> Strip(string text)
        {
            return Regex.Split(Regex.Replace(text,
                                      "[^a-zA-Z0-9']", //to Remove non Alpha-Numeric characters
                                      " "
                                      ).Trim(), "\\s+").ToList();
        }
    }

}