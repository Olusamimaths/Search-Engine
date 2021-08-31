using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace Indexing
{
    public class InvertedIndexEntry
    {
        public ObjectId _id { get; set; }
        public string Term { get; set; }
        public List<Posting> Postings { get; set; }
    }
}
