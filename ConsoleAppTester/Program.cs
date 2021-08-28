using System;
using System.Collections.Generic;
using System.IO;
using Parsers;
using SearchEngine;
using Utilities;
using Indexing;

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
            //string word = "THIS IS CAPITAL...THIS IS CAPITAL...GOLD IS CAPITAL...THIS IS CAPITAL";
            //Console.WriteLine(CaseFolder.CaseFold(word));
            //Console.WriteLine(StopWords.RemoveStopWords(new HashSet<string> { "a", "is", "the" }, word));
          

            //Console.WriteLine(pdfFilePath);
            //string text = PDFParser.Parse(pdfFilePath);
            //Console.WriteLine(text);

            //string path = @"C:/Users/Simeon/Desktop/index.html";
            //string result = HTMLParser.parseHtml(path);
            //Console.WriteLine(result);

            //string path = @"C:/Users/Simeon/Desktop/QLAS proposal.docx";
            //string result = DOCParser.parseDoc(path);
            //Console.WriteLine(result);\

            //string path = @"C:/Users/Simeon/Desktop/textppt.pptx";
            //string result = PPTParser.parsePPT(path);
            //Console.WriteLine(result);

            //string path = @"C:/Users/Simeon/Desktop/the.xls";
            //string result = SpreadSheetParser.parse(path);
            //Console.WriteLine(result);

            string input = "The Job open. that . . . 'word's";
            var expected = new[] { "job", "open", "that", "word" };
            using (var reader = new StringReader(input))
            {
                var tokenSource = new Tokenizer();
                tokenSource.SetReader(reader);
                List<string> rrr = tokenSource.ReadAll();
                foreach(string re in rrr)
                {
                    Logger.Info(re);
                }
            }
        }
    }
}

