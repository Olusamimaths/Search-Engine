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
        public Indexer()
        {
            _invertedIndex = new InvertedIndex();
        }
        public void IndexDocument(string document, int documentId)
        {
            ProcessDocument(document, documentId);
        }

        private void ProcessDocument(string document, int documentId)
        {
            using (var reader = new StringReader(document))
            {
                var tokenSource = new Tokenizer();

                tokenSource.SetReader(reader);
                List<string> tokenizedTerms = tokenSource.ReadAll();
                HashSet<string> uniqueTerms = new HashSet<string>(tokenizedTerms);

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
