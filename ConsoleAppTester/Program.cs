using System;
using System.Collections.Generic;
using System.IO;
using Parsers;
using Tokenize;
using Utilities;
//using Uploader;
using Indexing;
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
            invertedIndex.Append("hello", 123, 5);
            invertedIndex.Append("hello", 123, 8);
            invertedIndex.Append("hello", 100, 1);
            invertedIndex.Append("hello", 55, 49);
            invertedIndex.Append("help", 21, 100);
            invertedIndex.Append("heo", 123, 100);
            invertedIndex.Append("llo", 100, 10);
            invertedIndex.Append("man", 5, 9);
            invertedIndex.Append("love", 10, 100);
            invertedIndex.Append("once", 21, 10);

            Logger.Error("" + invertedIndex.GetFrequencyAccrossDocuments("helledfdo"));
            Logger.Error("" + invertedIndex.GetFrequencyOfTermInDocument("hello", 123));
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
