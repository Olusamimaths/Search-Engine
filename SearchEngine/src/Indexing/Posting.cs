using System.Collections.Generic;

namespace Indexing
{
    public class Posting
    {
        public int DocumentID { get; private set; }
        public List<long> Positions { get; private set; } = new List<long>();

        public Posting(int docID, long position)
        {
            DocumentID = docID;
            Positions.Add(position);
        }
    }

}
