using System;
using Parsers;
using SearchEngine.src.Parsers;

namespace ConsoleAppTester
{
    class Program
    {
        static void Main(string[] args)
        {
            ////string text = PDFParser.Parse("C:/Users/Visitor/Desktop/Project/SearchEngine/uploads/pdf/CSC322_final_project.pdf");
            //Console.WriteLine(text);

            string path = @"C:/Users/Simeon/Desktop/home.html";
            string result = HTMLParser.parseHtml(path);
            Console.WriteLine(result);
        }
    }
}
