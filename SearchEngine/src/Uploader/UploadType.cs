using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using Utilities;
namespace SearchEngine.src.Uploader
{
    public class UploadType
    {
        public static void Upload()
        {

            string value = @"C:\Users\Public\template1.doc";
            FileInfo fi = new FileInfo(value);
            string extn = fi.Extension;
            Console.WriteLine("File Extension: {0}", extn);

            RelativeFolder(extn);
            void RelativeFolder(string extn)
            {
                switch (extn)
                {
                    case ".doc":
                        // Copy the file into a destination directory
                        string docsdest = PathHandler.GetParentBasePath("\\doc");
                        Console.WriteLine(docsdest);
                        File.Copy(value, Path.Combine(docsdest, Path.GetFileName(value)));
                        Console.WriteLine("Successfully copied docs");
                        break;
                    case ".ppts":
                        string pptsdest = PathHandler.GetParentBasePath("\\ppts");
                        File.Copy(value, Path.Combine(pptsdest, Path.GetFileName(value)));
                        Console.WriteLine("Successfully copied ppts");
                        break;
                    case ".docx":
                        string docxdest = PathHandler.GetParentBasePath("\\docx");
                        File.Copy(value, Path.Combine(docxdest, Path.GetFileName(value)));
                        Console.WriteLine("Successfully copied docx");
                        break;
                    case ".ppt":
                        string pptdest = PathHandler.GetParentBasePath("\\ppt");
                        File.Copy(value, Path.Combine(pptdest, Path.GetFileName(value)));
                        Console.WriteLine("Successfully copied ppt");
                        break;
                    case ".xls":
                        string xlsdest = PathHandler.GetParentBasePath("\\xls");
                        File.Copy(value, Path.Combine(xlsdest, Path.GetFileName(value)));
                        Console.WriteLine("Successfully copied xls");
                        break;
                    case ".html":
                        string htmldest = PathHandler.GetParentBasePath("\\html");
                        File.Copy(value, Path.Combine(htmldest, Path.GetFileName(value)));
                        Console.WriteLine("Successfully copied html");
                        break;
                    case ".xml":
                        string xmldest = PathHandler.GetParentBasePath("\\xml");
                        File.Copy(value, Path.Combine(xmldest, Path.GetFileName(value)));
                        Console.WriteLine("Successfully copied xml");
                        break;
                    case ".pdf":
                        string pdfdest = PathHandler.GetParentBasePath("\\pdf");
                        File.Copy(value, Path.Combine(pdfdest, Path.GetFileName(value)));
                        Console.WriteLine("Successfully copied pdf");
                        break;
                    case ".xlsx":
                        string xlsxdest = PathHandler.GetParentBasePath("\\xlsx");
                        File.Copy(value, Path.Combine(xlsxdest, Path.GetFileName(value)));
                        Console.WriteLine("Successfully copied xlsx");
                        break;
                    default:
                        Console.WriteLine("The Document type doesnt fall withn this range pdf, doc, docx, ppt, ppts, xls, xlsx, txt, html and xml");
                        break;
                }
            }
              //  if (fi.Exists){}
        }
    }
}
