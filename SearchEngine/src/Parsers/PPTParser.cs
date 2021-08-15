using System;
using Spire.Presentation;
using System.IO;
using System.Text;
using Utilities;

namespace Parsers
{
    public static class PPTParser
    {
        /// <summary>
        /// Parses a Power Point file into string
        /// </summary>
        /// <param name="path">String: The file path of the ppt file</param>
        /// <returns>String: The text content of the ppt file</returns>
        public static string parsePPT(string path)
        {

            StringBuilder extractedText = new StringBuilder();

            // Open the file to read from.
            try
            {
                Presentation presentation = new Presentation(path, FileFormat.Pptx2010);

                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    for (int j = 0; j < presentation.Slides[i].Shapes.Count; j++)
                    {
                        if (presentation.Slides[i].Shapes[j] is IAutoShape)
                        {
                            IAutoShape shape = presentation.Slides[i].Shapes[j] as IAutoShape;
                            if (shape.TextFrame != null)
                            {
                                foreach (TextParagraph tp in shape.TextFrame.Paragraphs)
                                {
                                    extractedText.Append(tp.Text + Environment.NewLine);
                                }
                            }

                        }
                    }
                }

            }
            catch (FileNotFoundException)
            {
                Logger.Error(ErrorMessages.FileNotFound);
            }

            return extractedText.ToString();
        }

    }
}
