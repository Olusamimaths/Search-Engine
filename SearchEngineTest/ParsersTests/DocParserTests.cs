using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Parsers;

namespace SearchEngineTest
{
    [TestClass]
    public class DocParserTests
    {
        [TestMethod]
        public void ParsesTextFromADocxFile()
        {
            string folderName = AppDomain.CurrentDomain.BaseDirectory;
            string pdfFilePath = Path.Combine(folderName, "..\\..\\..\\ParsersTests\\testDocx1.docx");

            string text = PDFParser.Parse(@pdfFilePath);
            Assert.AreEqual(text, "This is a docx file, yay! It is.");
        }
    }
}
