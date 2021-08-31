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
        public static List<int> Search(string query)
        {
            List<int> matchedDocs = new();
            using (var reader = new StringReader(query))    
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                //Get the tokenizer and tokenize the query
                var tokenSource = new Tokenizer();
                tokenSource.SetReader(reader);
                List<string> tokenizedWords = tokenSource.ReadAll();
                List<List<Posting>> posting_list = new();
                foreach (string re in tokenizedWords)
                {
                    Logger.Info("This is the current term--->" +  re);
                    if (DatabaseService.GetInvertedIndexEntry(re) != null)
                    {
                        var postList = DatabaseService.GetInvertedIndexEntry(re).Postings;
                        posting_list.Add(postList);
                        for (int i = 0; i < postList.Count; i++)
                        {
                            matchedDocs.Add(postList[i].DocumentID);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Terms as this exist in Database");
                    }
                }
                /*if (posting_list != null) 
                {
                    // Get the list, linear merge and then return the merged list
                    matchedDocs = MatchingFunction.Merge(posting_list);
                }
                else
                {
                    Logger.Info("No Documents contains the search query");
                }*/

               
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
