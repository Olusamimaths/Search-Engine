using System;
using System.Collections.Generic;
using System.IO;
using Parsers;
using SearchEngine;
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


            // Console.WriteLine(pdfFilePath);
            string text = PDFParser.Parse(pdfFilePath);


            //            using (var reader = new StringReader(text))
            //            {
            //                var tokenSource = new Tokenizer();
            //                tokenSource.SetReader(reader);
            //                List<string> tokenizedWords = tokenSource.ReadAll();
            //                foreach (string re in tokenizedWords)
            //                {
            //                    Logger.Info(re);
            //                }
            //            }

            ///*
            InvertedIndex invertedIndex = new InvertedIndex();

            invertedIndex.Append("hello", 123, 5);
            invertedIndex.Append("hello", 100, 1);
            invertedIndex.Append("hello", 55, 49);
            invertedIndex.Append("help", 21, 100);
            invertedIndex.Append("heo", 123, 100);
            invertedIndex.Append("llo", 100, 10);
            invertedIndex.Append("man", 5, 9);
            invertedIndex.Append("love", 10, 100);
            invertedIndex.Append("once", 21, 10);

            Querier.Search("hell", invertedIndex);
            Querier.Search("love", invertedIndex);
            Querier.Search("once", invertedIndex);


            Console.WriteLine(pdfFilePath);
            string text2 = PDFParser.Parse(pdfFilePath);
            InvertedIndex invertedIndex2 = new InvertedIndex();

            using (var reader = new StringReader(text))
            {
                int pos = 0;
                var tokenSource = new Tokenizer();
                tokenSource.SetReader(reader);
                List<string> tokenizedWords = tokenSource.ReadAll();
                foreach (string re in tokenizedWords)
                {
                    pos += 1;
                    Logger.Info(re);
                    invertedIndex2.Append(re, 1, pos);
                }
            }

            Console.WriteLine("The number of terms is --->" + invertedIndex2.GetNumberOfTerms());

            Querier.Search("hell is a place of torment", invertedIndex2);
            Querier.Search("computer science's assignment is tough", invertedIndex2);
            Querier.Search("search engine by dr. odumuyiwa's long term project", invertedIndex2);
            Querier.Search("love conquers all things", invertedIndex2);
            Querier.Search("a function is a method", invertedIndex2);
            Querier.Search("calculate all in 1 seconds", invertedIndex2);




            //using (var reader = new StringReader(text))
            //{
            //    var tokenSource = new Tokenizer();
            //    tokenSource.SetReader(reader);
            //    List<string> tokenizedWords = tokenSource.ReadAll();
            //    foreach (string re in tokenizedWords)
            //    {
            //        Logger.Info(re);
            //    }
            //}

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
            Logger.Info("Initializing database connection... ");
            var connection = DBConnect.Connect();
            Logger.Info("Database connection established ");

            var dbList = connection.ListDatabases().ToList();

            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                Logger.Info(db.ToString());
            }

        }
    }
}

