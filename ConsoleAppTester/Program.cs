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
            string filePath = Path.Combine(folderName, "..\\..\\..\\testDocx1.docx");

            Console.WriteLine(filePath);
            string text = DocParser.Parse(filePath);
            Console.WriteLine(text);
        }
    }
}
