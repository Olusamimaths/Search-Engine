using System;
using System.Text;
using IronXL;
using Utilities;

namespace Parsers
{
    /// <summary>
    //Handles spreadsheet. Supported formats include: XLSX, XLS, CSV and TSV
    /// </summary>
    public static class SpreadSheetParser
    {
        /// <summary>
        /// Parses a spreadsheet document and extracts the text content from it 
        /// </summary>
        /// <param name="filePath">String: File Path to the word document</param>
        /// <returns>Text content of the spreadsheet</returns>
        public static string parse(string filePath)
        {
            StringBuilder sb = new StringBuilder("");

            try
            {
                WorkBook workbook = WorkBook.Load(filePath);
                WorksheetsCollection worksheets = workbook.WorkSheets;

                // Initialize String builder instance
                foreach (var sheet in worksheets)
                {
                    foreach (var cell in sheet)
                    {
                        if (cell.Text.Length > 0)
                        {
                            sb.Append(cell.Text);
                            sb.Append(" ");
                        }
                    }
                }

            }
            catch (SystemException ex)
            {
                Logger.Info(ErrorMessages.ErrorOccurred);
                Logger.Error(ex.Message);
            }

            
            return sb.ToString();
        }
        

}
}
