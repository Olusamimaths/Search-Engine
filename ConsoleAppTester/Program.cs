using System;
using System.Collections.Generic;
using System.IO;
using Parsers;
using Tokenize;
using Utilities;
using Indexing;
using MongoDB.Driver;

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

            using (var reader = new StringReader(text))
            {
                var tokenSource = new Tokenizer();
                tokenSource.SetReader(reader);
                List<string> tokenizedWords = tokenSource.ReadAll();
                foreach (string re in tokenizedWords)
                {
                    Logger.Info(re);
                }
            }
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
        }
    }
}
