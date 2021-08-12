using CsQuery;
using System;
using System.IO;

namespace SearchEngine.src.Parsers
{
    public static class HTMLParser
    {
        public static string parseHtml(string path)
        {

            if (!File.Exists(path))
            {
                Console.WriteLine("File not found");
                throw new FileNotFoundException("This file was not found.");
            }

            // Open the file to read from.
            string rawHTML = File.ReadAllText(path);
            string extractedText = CQ.CreateDocument(rawHTML).Text();
            return extractedText;
        }

    }
}
