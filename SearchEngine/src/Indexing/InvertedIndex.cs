using System.Collections.Generic;

namespace Indexing
{

    /// <summary>
    /// Creates an inverted index for documents
    /// </summary>
    public class InvertedIndex
    {
        //
        private readonly IDictionary<string, Posting> _data = new SortedDictionary<string, Posting>();
        /// <summary>
        /// Adds a entry to the inverted index data structure
        /// </summary>
        /// <param name="term">String: Term that will be the key of the etry</param>
        /// <param name="documentId">int: Document unique Id</param>
        internal void Append(string term, int documentId, string documentContent)
        {
            int position = documentContent.IndexOf(term);

            if (_data.ContainsKey(term))
            {
                _data[term].Positions.Add(position);
            }
            else
            {
                var posting = new Posting(documentId, position);
                _data.Add(term, posting);
            }
        }

        /// <summary>
        /// Gets the number of times a term is present in the documents
        /// </summary>
        /// <param name="term">String: The term to compute the frequency for</param>
        /// <returns>Int: number of times the term is present</returns>
        public int GetFrequency(string term)
        {
            return _data[term].Positions.Count;
        }

        /// <summary>
        /// Get the posting list for a term
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public Posting GetPostingsFor(string term)
        {
            return _data[term];
        }
    }
}
