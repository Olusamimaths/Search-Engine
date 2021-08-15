using System;
using System.IO;
using Parsers;

namespace ConsoleAppTester
{
    class Program
    {
        static void Main(string[] args)
        {
            //string folderName = AppDomain.CurrentDomain.BaseDirectory;
            //string pdfFilePath = Path.Combine(folderName, "..\\..\\..\\testPdf1.pdf");

            //Console.WriteLine(pdfFilePath);
            //string text = PDFParser.Parse(pdfFilePath);
            //Console.WriteLine(text);

            //string path = @"C:/Users/Simeon/Desktop/index.html";
            //string result = HTMLParser.parseHtml(path);
            //Console.WriteLine(result);

            //string path = @"C:/Users/Simeon/Desktop/QLAS proposal.docx";
            //string result = DOCParser.parseDoc(path);
            //Console.WriteLine(result);\

            string path = @"C:/Users/Simeon/Desktop/textppt.pptx";
            string result = PPTParser.parsePPT(path);
            Console.WriteLine(result);
        }
    }
}

