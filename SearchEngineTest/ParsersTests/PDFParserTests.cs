using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;
using System;
using System.IO;
using Parsers;

namespace SearchEngineTest
{
    [TestClass]
    public class PDFParserTests
    {
        [TestMethod]
        public void ParsesTextFromAPDFFile()
        {
            string folderName = AppDomain.CurrentDomain.BaseDirectory;
            string pdfFilePath = Path.Combine(folderName, "..\\..\\..\\ParsersTests\\testPdf1.pdf");
            
            string text = PDFParser.Parse(pdfFilePath);
            Assert.AreEqual(text, "This is a pdf file, yay! It is.");
        }
    }
}
