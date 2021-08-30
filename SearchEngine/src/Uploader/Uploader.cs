using System;
using System.IO;
using System.Collections.Generic;
using Utilities;
using Tokenize;
using Parsers;


namespace SearchEngine.src.Uploader
{
    public class Uploader
    {
        private static string basePath = PathHandler.GetParentBasePath("");
        private static string newDocsPath = PathHandler.GetParentBasePath("\\newDocs");
        private static string uploadedDocs = PathHandler.GetParentBasePath("\\indexedDocs");

        public static void Upload()
        {
            Tokenizer tokenSource = new Tokenizer();
            
            string[] toUpload = Directory.GetFiles(newDocsPath);

            int docID = 1;

            foreach (string fileToUpload in toUpload)
            {
                FileInfo fileInfo = new FileInfo(fileToUpload);
                string extn = fileInfo.Extension;
                string fileName = Path.GetFileName(fileToUpload);
                string source = Path.Combine(newDocsPath, fileName);
                string destination = Path.Combine(uploadedDocs, fileName);

                if (File.Exists(destination))
                {
                    File.Delete(destination);
                }

                File.Move(source, destination, true);

                string extractedText = ParseDocument(extn, fileName);
                List<string> tokenizedWords;


                using (var reader = new StringReader(extractedText))
                {
                    tokenSource.SetReader(reader);
                    tokenizedWords = tokenSource.ReadAll();
                }

                if (File.Exists(source))
                {
                    File.Delete(source);
                }

                //Increment doID and call indexer with tokenized words and docID
            }

        }

        /// <summary>
        /// Handles document parsind based on the file type
        /// </summary>
        /// <param name="extn">String: The file extension</param>
        /// <param name="filePath">String: The file path</param>
        static string ParseDocument(string extn, string filePath)
            {
                string extractedText = "";
                switch (extn)
                {
                    case ".doc":
                    case ".docx":
                        // Copy the file into a destination directory
                        //string docsdest = PathHandler.GetParentBasePath("\\doc");
                        //Console.WriteLine(docsdest);
                        extractedText = DocParser.Parse(filePath);
                        Console.WriteLine("Successfully parsed doc");
                        break;
                    case ".ppts":
                    case ".ppt":
                        extractedText = PPTParser.Parse(filePath);
                        Console.WriteLine("Successfully parsed ppt");
                        break;
                    case ".xls":
                    case ".xlsx":
                    case ".csv":
                        extractedText = SpreadSheetParser.Parse(filePath);
                        break;
                    case ".html":
                        extractedText = HTMLParser.Parse(filePath);
                        break;
                    case ".pdf":
                        extractedText = PDFParser.Parse(filePath);
                        break;
                    default:
                        Logger.Error("The Document type doesnt fall withn this range pdf, doc, docx, ppt, ppts, xls, xlsx, txt, html");
                        break;
                }
            return extractedText;
                //if
            }
              //  if (fi.Exists){}
        
    }
}
