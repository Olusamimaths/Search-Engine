using System;
using System.IO;
using System.Collections.Generic;
using Tokenize;
using System.Linq;

namespace Indexing
{
    public class Indexer
    {
        public InvertedIndex CreateIndex(List<Document> documents)
        {
            InvertedIndex invertedIndex = new InvertedIndex();

            foreach(var document in documents)
            {
                int documentId = document.Id;
                string documentText = document.Text;

                using (var reader = new StringReader(documentText)) {
                    ProcessDocument(invertedIndex, documentText, documentId);
                }
            }

            return invertedIndex;
        }
        private void ProcessDocument(InvertedIndex invertedIndex, string document, int documentId)
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
                        invertedIndex.Append(term, documentId, position);
                    }
                }
            }
        }
    }
}
