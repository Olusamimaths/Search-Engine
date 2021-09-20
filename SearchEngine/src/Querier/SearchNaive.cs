using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Indexing;
using Utilities;
using Tokenize;
using Database;

namespace SearchEngine
{

    public class SearchNaive
    {
        public static string elapsedTime
        {
            get;
            private set;
        }

        private static List<List<Posting>> GetListOfPostingsForQuery(string query)
        {
            List<List<Posting>> posting_list = new();

            using (var reader = new StringReader(query))
            {
                //Get the tokenizer and tokenize the query
                var tokenSource = new Tokenizer();
                tokenSource.SetReader(reader);
                List<string> tokenizedWords = tokenSource.ReadAll();

                foreach (string re in tokenizedWords)
                {
                    Logger.Info("This is the current term--->" + re);
                    if (DatabaseService.GetInvertedIndexEntry(re) != null)
                    {
                        var postList = DatabaseService.GetInvertedIndexEntry(re).Postings;
                        posting_list.Add(postList);
                    }
                    else
                    {
                        Console.WriteLine("No Terms as this exist in Database");
                    }
                }
            }
            return posting_list;
        }
        public static List<string> Search(string query)
        {
            Logger.Error("Search initiated . . . with query " + query);
            List<int> matchedDocs = new();
            List<List<Posting>> listOfPostings = GetListOfPostingsForQuery(query);

            foreach(List<Posting> postings in listOfPostings)
            {
                foreach(Posting posting in postings)
                {
                    matchedDocs.Add(posting.DocumentID);
                }
            }
            List<string> docList = DatabaseService.GetDocumentsByIDs(matchedDocs);
            Logger.Error("Works: total no = " + docList.Count);
            return docList;
        }

    }
}