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
        private readonly IDictionary<string, List<Posting>> _data;

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
                // term is already in _data, add the new position
                {
                    foundPosting.Positions.Add(position);
                    // sort the positions list after insertion
                    foundPosting.Positions.Sort();
                }
                DatabaseService.UpdatedInvertedIndexEntryPostings(term, postings);

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
        /// Gets the term present at a given index in the InvertedIndex documents
        /// </summary>
        /// <param name="i">int: index of term to find</param>
        /// <returns>String: term present at the index</returns>
        public string GetTermAtIndex(int i)
        {
            List<string> keyList = new List<string>(_data.Keys);
            return keyList[i];
        }


        /// <summary>
        /// Gets the number of times a term is present in the documents
        /// </summary>
        /// <param name="term">String: The term to compute the frequency for</param>
        /// <returns>Int: number of times the term is present</returns>
        public int GetFrequencyAccrossDocuments(string term)
        {
            int result = 0;
            if (_data.TryGetValue(term, out var postings))
            {
                foreach (Posting posting in postings)
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
            if (_data.TryGetValue(term, out var postings))
            {
                return postings;
            }
            return null;
        }

        /// <summary>
        /// Gets the frequency of a term in a document
        /// </summary>
        /// <param name="term">String: The term</param>
        /// <param name="documentId">Int: Document ID</param>
        /// <returns></returns>
        public int GetFrequencyOfTermInDocument(string term, int documentId)
        {
            //check if the term is alredy in the _data
            if (_data.TryGetValue(term, out var postings))
            {
                // if the term is not in _data for a given document ID, create a new posting for it
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
            return _data.Count;
        }
    }
}
