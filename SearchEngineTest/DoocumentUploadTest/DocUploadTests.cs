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

            string value = @"C:\Users\Public\template1.doc";
            FileInfo fi = new FileInfo(value);
            string extn = fi.Extension;
            string[] typeArray = { ".pdf", ".doc", ".docx", ".ppt", ".ppts", ".xls", ".xlsx", ".txt", ".html", ".xml" };
            if (typeArray.Any(extn.Contains))
            {
                Assert.AreEqual(extn, ".doc");
            }
        }
        [TestMethod]
                public void DocUploadTest()
                {

                    /* string value = @"C:\Users\Abubakar O A\Desktop\2nd Semester\CSC 322 c - sharp\Project\SearchEngine\uploads\doc\template.doc";
                    string[] filePaths = Directory.GetFiles(@"C:\Users\Abubakar O A\Desktop\2nd Semester\CSC 322 c-sharp\Project\SearchEngine\uploads\", "*.doc", SearchOption.AllDirectories);
                    if (filePaths.Any(filePaths.Contains))
                    {
                        Assert.AreEqual(value, @"\template.doc");
                    }*/
                }
            
    }
}