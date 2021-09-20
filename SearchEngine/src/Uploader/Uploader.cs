using System;
using System.IO;
using Utilities;
using Tokenize;
using Parsers;
using Database;
using Indexing;

namespace UploaderUtil
{
    public class Uploader
    {
        private static string basePath = PathHandler.GetParentBasePath("");
        private static string newDocsPath = PathHandler.GetParentBasePath("\\newDocs");
        private static string uploadedDocs = PathHandler.GetParentBasePath("\\indexedDocs");

        public static void Upload()
        {
            Tokenizer tokenSource = new Tokenizer();
            Indexer indexer = new Indexer();
            
            string[] toUpload = Directory.GetFiles(newDocsPath);

            int lastDocID = DatabaseService.GetLastDocumentID();
            //int lastDocID = 1;
            Logger.Info("Uploading in progress . . .");
            Logger.Info("Last document ID: " + lastDocID);
            foreach (string fileToUpload in toUpload)
            {
                FileInfo fileInfo = new FileInfo(fileToUpload);
                string extn = fileInfo.Extension;
                string fileName = Path.GetFileName(fileToUpload);
                string source = Path.Combine(newDocsPath, fileName);
                string destination = Path.Combine(uploadedDocs, fileName);

                if (File.Exists(destination))
                {
                    Logger.Info("File already exist " + fileName);
                    continue;
                }

                File.Move(source, destination, true);

                var document = new DocumentEntry { 
                    DocID = lastDocID + 1,
                    Path = fileName
                };
                DatabaseService.AddNewDocument(document);
                lastDocID++;

                string extractedText = ParseDocument(extn, destination);
                indexer.IndexDocument(extractedText, lastDocID + 1);

                if (File.Exists(source))
                {
                    File.Delete(source);
                }

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
            }
        
    }
}
