using System;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace Parsers
{
    public static class PDFParser
    {
        public static string Parse(string pdfPath)
        {
            string text = "";
            using(var pdf = PdfDocument.Open(@pdfPath))
            {
                foreach(var page in pdf.GetPages())
                {
                    text += " " + page.Text;
                }
            }
            return text;
        }
    }
}
