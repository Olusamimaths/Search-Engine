using System.Collections.Generic;

namespace Indexing
{
    public class InvertedIndex
    {
        private readonly IDictionary<string, List<int>> _data = new Dictionary<string, List<int>>();
        internal void Append(string term, int documentId)
        {
            if (_data.ContainsKey(term))
            {
                _data[term].Add(documentId);
            }
            else
            {
                var postings = new List<int>(documentId);
                _data.Add(term, postings);
            }
        }

        public int GetFrequency(string term)
        {
            return _data[term].Count;
        }
    }
}
