using MongoDB.Driver;
using MongoDB.Bson;
using Indexing;
using MongoDB.Driver.Linq;
using System.Collections.Generic;

namespace Database
{
    public static class DatabaseService
    {
        private static MongoClient _dbClient = null;
        public static MongoClient Connect()
        {
            if(_dbClient == null)
            {
                _dbClient = new MongoClient("mongodb+srv://pacesetter:pacesetter@cluster0.whodz.mongodb.net/test");
            }
            return _dbClient;
        }

        public static IMongoDatabase GetDatabase()
        {
            MongoClient mongoClient = Connect();
            return mongoClient.GetDatabase("test");

        }
        public static IMongoCollection<InvertedIndexEntry> GetInvertedIndexCollection()
        {
            return GetDatabase().GetCollection<InvertedIndexEntry>("inverted_index");
        }

        public static InvertedIndexEntry GetInvertedIndexEntry(string term)
        {
            var col = GetInvertedIndexCollection().AsQueryable<InvertedIndexEntry>();
            var list = col.Where(b => b.Term == term).Take(1).Select(c => new { c.Term, c.Postings }).ToList();
            if (list.Count > 0) return new InvertedIndexEntry { Term = list[0].Term, Postings = list[0].Postings };
            return null;
        }

        public static void AddNewInvertedIndexEntry(InvertedIndexEntry invertedIndexEntry) {
            GetInvertedIndexCollection().InsertOne(invertedIndexEntry);
        }

        public static void UpdatedInvertedIndexEntryPostings(string term, List<Posting> postings)
        {
            var invertedIndexEntry = GetInvertedIndexCollection().AsQueryable().Where(b => b.Term == term).FirstOrDefault();
            invertedIndexEntry.Postings = postings;
            GetInvertedIndexCollection().ReplaceOne(x => x.Term == term, invertedIndexEntry);
        }
    }
}
