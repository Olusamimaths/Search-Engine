using Database;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System;
using MongoDB.Driver.Linq;

namespace Indexing
{

    /// <summary>
    /// Creates an inverted index for documents
    /// </summary>
    public class InvertedIndex
    {
        /// <summary>
        /// Adds a entry to the inverted index data structure
        /// </summary>
        /// <param name="term">String: Term that will be the key of the entry</param>
        /// <param name="documentId">int: Document unique Id</param>
        public void Append(string term, int documentId, long position)
        {
            //check if the term is alredy in the _data
            InvertedIndexEntry entry = DatabaseService.GetInvertedIndexEntry(term);

            if (entry != null)
            {
                // if the term is not in database for a given document ID, create a new posting for it
                var postings = entry.Postings;

                Posting foundPosting = FindPosting(postings, documentId);

                if (foundPosting == null)
                {
                    postings.Add(new Posting(documentId, position));
                    // sort the posting list by document ID
                    postings.Sort(new PostingComparer());
                }
                else
                // term is already in database for the same document ID, just add the new position
                {
                    foundPosting.Positions.Add(position);
                    // sort the positions list after insertion
                    foundPosting.Positions.Sort();
                }
                DatabaseService.UpdateInvertedIndexEntryPostings(term, postings);
            }
            else
            // no entry for the term yet
            {
                InvertedIndexEntry invertedIndexEntry = new InvertedIndexEntry {
                    Term = term,
                    Postings = new List<Posting> { new Posting(documentId, position) }

                };
                DatabaseService.AddNewInvertedIndexEntry(invertedIndexEntry);
            }
        }

        private Posting FindPosting(List<Posting> postings, int documentId)
        {
            Posting foundPosting = null;
            foreach (Posting posting in postings)
            {
                if (posting.DocumentID == documentId)
                {
                    foundPosting = posting;
                    break;
                }
            }
            return foundPosting;
        }

        /// <summary>
        /// Gets the number of times a term is present in the documents
        /// </summary>
        /// <param name="term">String: The term to compute the frequency for</param>
        /// <returns>Int: number of times the term is present</returns>
        public int GetFrequencyAccrossDocuments(string term)
        {
            int result = 0;
            var documents = DatabaseService.GetAllDocuments();
            var invertedIndexEntry = documents.Find(x => x.Term == term);
            if(invertedIndexEntry != null)
            {
                foreach (Posting posting in invertedIndexEntry.Postings)
                {
                    result += posting.Positions.Count;
                }
            }
            
            return result;
        }

        /// <summary>
        /// Get the posting list for a term
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public List<Posting> GetPostingsFor(string term)
        {
            var invertedIndexEntry = DatabaseService.GetInvertedIndexEntry(term);
            return invertedIndexEntry?.Postings;
        }

        /// <summary>
        /// Gets the frequency of a term in a document
        /// </summary>
        /// <param name="term">String: The term</param>
        /// <param name="documentId">Int: Document ID</param>
        /// <returns></returns>
        public int GetFrequencyOfTermInDocument(string term, int documentId)
        {
            InvertedIndexEntry entry = DatabaseService.GetInvertedIndexEntry(term);
            if (entry != null)
            {
                // if the term is not in database for a given document ID, create a new posting for it
                var postings = entry.Postings;

                Posting foundPosting = FindPosting(postings, documentId);
                if (foundPosting != null)
                {
                    return foundPosting.Positions.Count;
                }
            }
            return 0;
        }

        /// <summary>
        /// Gets the number of terms that have been indexed
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfTerms()
        {
            return DatabaseService.GetNumberOfIndexedTerms().Result;
        }
    }
}
