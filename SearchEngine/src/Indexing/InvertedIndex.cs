using System.Collections.Generic;

namespace Indexing
{

    /// <summary>
    /// Creates an inverted index for documents
    /// </summary>
    public class InvertedIndex
    {
        private readonly IDictionary<string, List<int>> _data = new Dictionary<string, List<int>>();
        /// <summary>
        /// Adds a entry to the inverted index data structure
        /// </summary>
        /// <param name="term">String: Term that will be the key of the etry</param>
        /// <param name="documentId">int: Document unique Id</param>
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

        /// <summary>
        /// Gets the number of times a term is present in the documents
        /// </summary>
        /// <param name="term">String: The term to compute the frequency for</param>
        /// <returns>Int: number of times the term is present</returns>
        public int GetFrequency(string term)
        {
            return _data[term].Count;
        }
    }
}
