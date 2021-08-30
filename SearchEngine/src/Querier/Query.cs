using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indexing;
using Utilities;

namespace SearchEngine
{
  
    public class Querier
    {
        public static string elapsedTime
        {
            get;
            private set;
        }
        public static List<int> Search(string query, InvertedIndex invertedIndex)
        {
            InvertedIndex words = invertedIndex;
            List<int> matchedDocs = new List<int>();
            Console.WriteLine("Here is the InvertedIndex" + invertedIndex.ToString());
            StringBuilder s = new StringBuilder();
            using (var reader = new StringReader(query))
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                //Get the tokenizer and tokenize the query
                var tokenSource = new Tokenizer();
                tokenSource.SetReader(reader);
                List<string> tokenizedWords = tokenSource.ReadAll();
                foreach (string re in tokenizedWords)
                {
                    Logger.Info(re);
                    //Check every query (term) in the invertedIndex, if they exist, then get the corresponding DocId and Postings 
                    //so you can get the docs in which they exist and their positions in the docs
                    if (words.GetFrequencyAccrossDocuments(re) != 0) 
                    {
                        //Just get the doc ID of the containing document
                        //We're supposed to rank here but later, get something that works first
                        int docID = words.GetPostingsFor(re).First().DocumentID;
                        matchedDocs.Add(docID);
                        s.Append(docID + "-->");
                    }

                }
                watch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = watch.Elapsed;
                elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.TotalMilliseconds);
                watch.Reset();
                Console.WriteLine($"Search Runtime is -> { ts.TotalMilliseconds} milliseconds");
            }
            
            Console.WriteLine("Search Runtime is -=-=->>>" + elapsedTime);
            Console.WriteLine("Documents containing terms are ==>" +s.ToString());

            return matchedDocs;
        }

    }
}
