using System;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using Utilities;

namespace Parsers
{
    /// <summary>
    /// Class for Parsing PDF files
    /// </summary>
    public static class PDFParser
    {
        /// <summary>
        /// Parses a pdf file into string
        /// </summary>
        /// <param name="pdfPath">String: The file path of the pdf file</param>
        /// <returns>String: The text content of the pdf file</returns>
        public static string Parse(string pdfPath)
        {
            // initial text
            string text = "";
            try {
                using (var pdf = PdfDocument.Open(@pdfPath))
                {
                    foreach (var page in pdf.GetPages())
                    {
                        text += " " + page.Text;
                    }
                }
            } catch(System.InvalidOperationException) {
                Logger.Error(ErrorMessages.FileNotFound);
            }

            return text.Trim();
        }
    }
}
