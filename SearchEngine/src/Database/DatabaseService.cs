using MongoDB.Driver;
using Indexing;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database
{
    /// <summary>
    /// Handles Persisting data into the database
    /// </summary>
    public static class DatabaseService
    {
        private static MongoClient _dbClient = null;
        /// <summary>
        /// Connects to the Mongodb database
        /// </summary>
        /// <returns></returns>
        public static MongoClient Connect()
        {
            if(_dbClient == null)
            {
                _dbClient = new MongoClient("mongodb+srv://pacesetter:pacesetter@cluster0.whodz.mongodb.net/test");
            }
            return _dbClient;
        }

        /// <summary>
        /// Gets the database connection, an instance of `ImongoDatabase`
        /// </summary>
        /// <returns>IMongoDatabase: The Database</returns>
        public static IMongoDatabase GetDatabase()
        {
            MongoClient mongoClient = Connect();
            return mongoClient.GetDatabase("test");

        }
        /// <summary>
        /// Gets the InvertedIndex co
        /// </summary>
        /// <returns></returns>
        public static IMongoCollection<InvertedIndexEntry> GetInvertedIndexCollection()
        {
            return GetDatabase().GetCollection<InvertedIndexEntry>("inverted_index");
        }

        /// <summary>
        /// Gets the inverted index entry for a given term
        /// </summary>
        /// <param name="term">String: The term to get the inverted index for</param>
        /// <returns></returns>
        public static InvertedIndexEntry GetInvertedIndexEntry(string term)
        {
            var col = GetInvertedIndexCollection().AsQueryable<InvertedIndexEntry>();
            var list = col.Where(b => b.Term == term).Take(1).Select(c => new { c.Term, c.Postings }).ToList();
            if (list.Count > 0) return new InvertedIndexEntry { Term = list[0].Term, Postings = list[0].Postings };
            return null;
        }

        /// <summary>
        /// Gets all the inverted index entries in the database
        /// </summary>
        /// <returns></returns>
        public static List<InvertedIndexEntry> GetAllDocuments()
        {
            var col = GetInvertedIndexCollection().AsQueryable<InvertedIndexEntry>();
            return col.ToList();
        }

        /// <summary>
        /// Adds a new inverted index entry into the database
        /// </summary>
        /// <param name="invertedIndexEntry">The inverted index entry to add</param>
        public static void AddNewInvertedIndexEntry(InvertedIndexEntry invertedIndexEntry) {
            GetInvertedIndexCollection().InsertOne(invertedIndexEntry);
        }

        /// <summary>
        /// Updates the postings list for a givent term in the inverted index documents
        /// </summary>
        /// <param name="term">The term to update the postings for</param>
        /// <param name="postings">The new posting list</param>
        public static void UpdateInvertedIndexEntryPostings(string term, List<Posting> postings)
        {
            var invertedIndexEntry = GetInvertedIndexCollection().AsQueryable().Where(b => b.Term == term).FirstOrDefault();
            if(invertedIndexEntry != null)
            {
                invertedIndexEntry.Postings = postings;
                GetInvertedIndexCollection().ReplaceOne(x => x.Term == term, invertedIndexEntry);
            }
        }

        /// <summary>
        /// Gets the number of terms that have been indexed
        /// </summary>
        /// <returns></returns>
        public async static Task<int> GetNumberOfIndexedTerms()
        {
            var col = GetInvertedIndexCollection().AsQueryable<InvertedIndexEntry>();
            return await col.CountAsync();
        }
    }
}
