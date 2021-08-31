

using System;
using System.Diagnostics;
using System.Collections.Generic;
using Indexing;

namespace SearchEngine
{
    class MatchingFunction
    {
        /// <summary>
        /// A function to merge a list of postings for every terms.
        /// The list of postings are sorted.
        /// </summary>
        /// <param name="posting_list"></param>
        /// <returns>Sorted document IDs</returns>
        internal static List<int> Merge(List<List<Posting>> posting_list)
        {
            List<int> docIDs = new();

            // Create a min heap with k heap nodes. Every
            // heap node has first element of an array
            List<Tuple<long, Tuple<int, int>>> heap = new();
            //in is a hack here
            for (int i = 0; i < posting_list.Count; i++)
            {
                for (int j = 0; j < posting_list[i].Count; j++)
                {
                    heap.Add(new Tuple<long, Tuple<int, int>>(posting_list[i][j].Positions[0], new Tuple<int, int>(i, 0)));
                }
            }

            heap.Sort();

            while (heap.Count > 0)
            {
                Tuple<long, Tuple<int, int>> current = heap[0];
                heap.RemoveAt(0);
                int i = current.Item2.Item1;
                int j = current.Item2.Item2;
                docIDs.Add(current.Item2.Item1);
                if (j + 1 < posting_list[i].Count)
                {
                    for (int k = 0; k < heap.Count; k++)
                    {
                        heap.Add(new Tuple<long, Tuple<int, int>>(posting_list[i][k].Positions[j + 1], new Tuple<int, int>(i, 0)));
                    }
                }
                heap.Sort();
            }

            return docIDs;
        }
    }
 }


