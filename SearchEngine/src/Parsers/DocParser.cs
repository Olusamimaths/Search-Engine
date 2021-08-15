using System;
using Spire.Doc;
using Spire.Doc.Documents;
using System.Text;
using Utilities;

namespace Parsers
{
    /// <summary>
    /// Handles word document
    /// </summary>
    public static class DocParser
    {
        /// <summary>
        /// Parses a word document and extracts the text content from it 
        /// </summary>
        /// <param name="filePath">String: File Path to the word document</param>
        /// <returns>Text content of the word document</returns>
        public static string Parse(string filePath)
        {
            // Initialize String builder instance
            string text = "";
            try
            {
                text = GetTextFromDocx(filePath);
            } catch(SystemException ex) {
                Logger.Info(ErrorMessages.ErrorOccurred);
                Logger.Error(ex.Message);
            }

            return text;
        }

        private static string GetTextFromDocx(string filePath) {
            StringBuilder sb = new StringBuilder();

            Document document = new Document();
            document.LoadFromFile(filePath);

            //Extract Text from Word and Save to StringBuilder Instance
            foreach (Section section in document.Sections)
            {
                Console.WriteLine(section.ToString());
                foreach (Paragraph paragraph in section.Paragraphs)
                {
                    sb.AppendLine(paragraph.Text);
                }
            }

            return sb.ToString();
        }
    }
}
