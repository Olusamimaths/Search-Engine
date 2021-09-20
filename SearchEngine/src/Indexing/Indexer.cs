using System;
using System.IO;
using System.Collections.Generic;
using Tokenize;
using System.Linq;

namespace Indexing
{
    public class Indexer
    {
        private InvertedIndex _invertedIndex; 

        /// <summary>
        /// Creates an inverted index for indexing the document
        /// </summary>
        public Indexer()
        {
            _invertedIndex = new InvertedIndex();
        }
        /// <summary>
        /// Processes documents given the document string and the document ID
        /// </summary>
        /// <param name="document">String: The document content</param>
        /// <param name="documentId">String: The document ID</param>
        public void IndexDocument(string document, int documentId)
        {
            ProcessDocument(document, documentId);
        }

        /// <summary>
        /// Processes each document, tokenizes it and creates inverted indexes
        /// </summary>
        /// <param name="document">String: The document content</param>
        /// <param name="documentId">String: The document ID</param>
        private void ProcessDocument(string document, int documentId)
        {
            // tokenize the document text
            using (var reader = new StringReader(document))
            {
                var tokenSource = new Tokenizer();

                tokenSource.SetReader(reader);
                List<string> tokenizedTerms = tokenSource.ReadAll();
                // remove the duplicate terms
                HashSet<string> uniqueTerms = new HashSet<string>(tokenizedTerms);
                
                // create inverted indexes for each term ( from the unique terms set )
                foreach (string term in uniqueTerms)
                {
                    var allIndicesOfTermInDocument = Enumerable.Range(0, tokenizedTerms.Count)
                                   .Where(i => tokenizedTerms[i] == term)
                                   .ToList();

                    allIndicesOfTermInDocument.Sort();

                    foreach(int position in allIndicesOfTermInDocument)
                    {
                        _invertedIndex.Append(term, documentId, position);
                    }
                }
            }
        }
    }
}
