﻿using System;
using System.IO;
using Parsers;
using SearchEngine;
using SearchEngine.src.Uploader;
using System.Diagnostics;


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

            //string path = @"C:/Users/Simeon/Desktop/textppt.pptx";
            //string result = PPTParser.parsePPT(path);
            //Console.WriteLine(result);

            //string path = @"C:/Users/Simeon/Desktop/the.xls";
            //string result = SpreadSheetParser.parse(path);
            //Console.WriteLine(result);

            string input = "job open. that . . . 'word'";
            var expected = new[] { "job", "open", "that", "word" };
            using (var reader = new StringReader(input))
            {
                var tokenSource = new Tokenizer();
                tokenSource.SetReader(reader);
                while (tokenSource.Next()) {
                    Console.WriteLine(tokenSource.ToString());
                }
                //CollectionAssert.AreEqual(expected, result);
            }

        }
    }
}

