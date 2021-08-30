using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Indexing;

namespace IndexingTests
{
    [TestClass]
    public class IndexerTests
    {
        [TestMethod]
        public void IndexerWorks()
        {
            Indexer ind = new Indexer();
            var doc1 = new Document(123, "Hello World");

            List<Document> list = new List<Document>();
            list.Add(doc1);

            InvertedIndex invertedIndex = ind.CreateIndex(list);
            Assert.IsNotNull(invertedIndex);
        }

        [TestMethod]
        public void ItAddsEachTermToTheIndex()
        {
            Indexer ind = new Indexer();

            var doc1 = new Document(123, "Hello World Hello World");
            var doc2 = new Document(124, "key value key key key");
            var doc3 = new Document(125, "kopoke");

            List<Document> list = new List<Document>();

            list.Add(doc1);
            list.Add(doc2);
            list.Add(doc3);

            InvertedIndex invertedIndex = ind.CreateIndex(list);

            int numberOfTerms = invertedIndex.GetNumberOfTerms();

            Assert.AreEqual(5, numberOfTerms);
        }

        [TestMethod]
        public void IndexesForEachTermAreCorrectly()
        {
            Indexer ind = new Indexer();

            var doc1 = new Document(111, "today World today World");
            var doc2 = new Document(124, "key value key key key");
            var doc3 = new Document(125, "kopoke");

            List<Document> list = new List<Document>();

            list.Add(doc1);
            list.Add(doc2);
            list.Add(doc3);

            InvertedIndex invertedIndex = ind.CreateIndex(list);
            Console.WriteLine(invertedIndex.GetPostingsFor("key").Count);

            int freq1 = invertedIndex.GetFrequencyOfTermInDocument("World", 111);
            int freq4 = invertedIndex.GetFrequencyOfTermInDocument("today", 111);
            int freq2 = invertedIndex.GetFrequencyOfTermInDocument("key", 124);
            int freq5 = invertedIndex.GetFrequencyOfTermInDocument("value", 124);
            int freq3 = invertedIndex.GetFrequencyOfTermInDocument("kopoke", 125);

            Assert.AreEqual(2, freq1);
            Assert.AreEqual(4, freq2);
            Assert.AreEqual(1, freq3);
            Assert.AreEqual(1, freq5);
            Assert.AreEqual(2, freq4);
        }

    }
}
