using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Indexing;
using Utilities;
using Tokenize;

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
            List<int> matchedDocs = new();
            using (var reader = new StringReader(query))
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                //Get the tokenizer and tokenize the query
                var tokenSource = new Tokenizer()   ;
                tokenSource.SetReader(reader);
                List<string> tokenizedWords = tokenSource.ReadAll();
                List<List<Posting>> posting_list = new List<List<Posting>>();
                foreach (string re in tokenizedWords)
                {
                    Logger.Info(re);
                    var postList = invertedIndex.GetPostingsFor(re);
                    posting_list.Add(postList);

                    
                    //get term
                    //Check every query (term) in the invertedIndex, if they exist, then get the corresponding DocId and Postings 
                    //so you can get the docs in which they exist and their positions in the docs
                    /*if (words.GetFrequencyAccrossDocuments(re) != 0) 
                    {

                        //Just get the doc ID of the containing document
                        //We're supposed to rank here but later, get something that works first
                        int docID = words.GetPostingsFor(re).DocumentID;
                        matchedDocs.Add(docID);
                        s.Append(docID + "-->");
                    }*/

                }
                // Get the list, linear merge and then return the merged list
                matchedDocs = MatchingFunction.Merge(posting_list);
                watch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = watch.Elapsed;
                elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.TotalMilliseconds);
                watch.Reset();
                Console.WriteLine($"Search Runtime is -> { ts.TotalMilliseconds} milliseconds");
            }
            
            foreach (var variable in matchedDocs)
            {
                Console.WriteLine("DocIDs returned are ==>" + variable.ToString());
            }
            return matchedDocs;
        }

    }
}