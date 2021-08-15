using System;
using CsQuery;
using System.IO;
using Utilities;


namespace Parsers
{
    /// <summary>
    /// Class for Parsing HTML files
    /// </summary>
    public static class HTMLParser
    {
        /// <summary>
        /// Parses a HTML file into string
        /// </summary>
        /// <param name="path">String: The file path of the HTML file</param>
        /// <returns>String: The text content of the HTML file</returns>
        public static string parseHtml(string path)
        {

            string extractedText = "";

            // Open the file to read from.
            try
            {
             string rawHTML = File.ReadAllText(path);
             extractedText = CQ.CreateDocument(rawHTML).Text();
            }
            catch (FileNotFoundException)
            {
             Logger.Error(ErrorMessages.FileNotFound);
            }
            
            return extractedText;
        }

    }
}
