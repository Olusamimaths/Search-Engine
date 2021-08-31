using System;
using System.Collections.Generic;
using System.IO;
using Parsers;
using Tokenize;
using Utilities;
//using Uploader;
using Indexing;
using SearchEngine;
using MongoDB.Driver;
using SearchEngine.src.Uploader;

namespace ConsoleAppTester
{
    class Program
    {
        static void Main(string[] args)
        {
            //string folderName = AppDomain.CurrentDomain.BaseDirectory;
            //string pdfFilePath = Path.Combine(folderName, "..\\..\\..\\testPdf1.pdf");

            List<int> docs = Querier.Search("We have been taugth in computer science how to create a earch engine");
            Console.WriteLine("Here are the Search results:");
            foreach (var doc in docs)
            {
                Console.WriteLine(doc);
            }


            //var text = PDFParser.Parse(pdfFilePath);
            //Indexer indexer = new Indexer();

            //indexer.IndexDocument(text, 122);

            //Uploader.Upload();
            //Logger.Error("Successfully upload documents");

            //Logger.Error("Just trying some stuff");
            //Logger.Error(Path.GetFileName(@"C:\Users\Public\template1.doc"));
            //Logger.Error(PathHandler.GetParentBasePath(""));

            //string basePath = PathHandler.GetParentBasePath("");
            //string newDocsPath = PathHandler.GetParentBasePath("\\newDocs");
            //string uploadedDocs = PathHandler.GetParentBasePath("\\indexedDocs");

            //string value = @"C:\Users\Public\template1.doc";

            //Console.WriteLine("File Extension: {0}", extn);

            //----------------------------------------------

            //string sourceDir = @"C:\Users\Jano\Documents\";
            //string backupDir = @"C:\Users\Jano\Documents\backup\";

            //string[] toUpload = Directory.GetFiles(newDocsPath);

            //foreach (string fileToUpload in toUpload)
            //{
            //    FileInfo fileInfo = new FileInfo(fileToUpload);
            //    //Logger.Error(fileInfo.ToString());
            //    string extn = fileInfo.Extension;
            //    string fileName = fileToUpload.Substring(newDocsPath.Length);
            //    Logger.Error("FIle name: " + fileName);
            //}
            // Console.WriteLine(pdfFilePath);

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
            InvertedIndex invertedIndex = new InvertedIndex();
            invertedIndex.Append("hello", 111, 5);
            invertedIndex.Append("hello", 111, 8);
            invertedIndex.Append("hello", 134, 1);
            invertedIndex.Append("hello", 4565, 49);
            invertedIndex.Append("help", 445, 100);
            invertedIndex.Append("heo", 14, 100);
            invertedIndex.Append("llo", 10450, 10);
            invertedIndex.Append("man", 45, 9);
            invertedIndex.Append("love", 445, 100);
            invertedIndex.Append("once", 45, 10);

            Logger.Error("" + invertedIndex.GetFrequencyAccrossDocuments("helledfdo"));
            Logger.Error("" + invertedIndex.GetFrequencyOfTermInDocument("hello", 111));
            Logger.Error("" + invertedIndex.GetNumberOfTerms());

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
