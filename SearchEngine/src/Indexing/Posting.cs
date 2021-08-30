using System.Collections.Generic;
using MongoDB.Bson;

namespace Indexing
{
    public class Posting
    {
        public int DocumentID { get; private set; }

        public ObjectId _id { get; private set; }
        public List<long> Positions { get; private set; } = new List<long>();

        public Posting(int docID, long position)
        {
            DocumentID = docID;
            Positions.Add(position);
        }
    }

}
