using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using SearchEngine.src.Uploader;
using System.Linq;
/*using System.IO;*/

namespace DoocumentUploadTest
{
    [TestClass]
    public class DocUploadTests
    {
        [TestMethod]
        public void DocTypeUploadTest()
        {
            string typecheck = ".pdf";
            string[] typeArray = { ".pdf", ".doc", ".docx", ".ppt", ".ppts", ".xls", ".xlsx", ".txt", ".html", ".xml" };
            Assert.AreEqual(typecheck, typeArray.Any(typecheck.Contains));
        }
        [TestMethod]
        public void DocUploadTest()
        {

            string value = @"C:\Users\Public\template1.doc";
            string[] filePaths = Directory.GetFiles(@"c:\MyDir\", "*.pdf", SearchOption.AllDirectories);
            Assert.AreEqual(value, filePaths.Any(filePaths.Contains));

        }
    }
}
