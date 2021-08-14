using System;
using System.IO;
using Parsers;

namespace ConsoleAppTester
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderName = AppDomain.CurrentDomain.BaseDirectory;
            string pdfFilePath = Path.Combine(folderName, "..\\..\\..\\testPdf1.pdf");

            Console.WriteLine(pdfFilePath);
            string text = PDFParser.Parse(pdfFilePath);
            Console.WriteLine(text);
        }
    }
}
