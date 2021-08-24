using System.Collections.Generic;


namespace Indexing
{
    public class Posting
    {
        public int DocumentId { get; private set;  }

        //public IList<long> Locations { get; } = new List<long>();

        public Posting(int docID)
        {
            DocumentId = docID;
        }
    }
}
