using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Indexing;

namespace IndexingTests
{
    [TestClass]
    public class InvertedIndextTest
    {
        [TestMethod]
        public void InvertedIndexWorks()
        {
            InvertedIndex invertedIndex = new InvertedIndex();
            Assert.AreEqual(0, invertedIndex.GetNumberOfTerms());
        }

        [TestMethod]
        public void AddsInvertedIndexForATerm()
        {
            InvertedIndex invertedIndex = new InvertedIndex();
            invertedIndex.Append("hello", 123, 5);

            var posting = invertedIndex.GetPostingsFor("hello");

            Assert.AreEqual(1, invertedIndex.GetNumberOfTerms());
            Assert.AreEqual(123, posting[0].DocumentID);
            Assert.AreEqual(5, posting[0].Positions[0]);
        }

        [TestMethod]
        public void AddsInvertedIndexForTerms()
        {
            InvertedIndex invertedIndex = new InvertedIndex();

            invertedIndex.Append("cccc", 123, 5);
            invertedIndex.Append("bbbb", 123, 1);
            invertedIndex.Append("aaaa", 123, 49);
            invertedIndex.Append("zzzz", 123, 100);

            var posting = invertedIndex.GetPostingsFor("hello");

            Assert.AreEqual(4, invertedIndex.GetNumberOfTerms());
        }

        [TestMethod]
        public void PositionsAreAlwaysSorted()
        {
            InvertedIndex invertedIndex = new InvertedIndex();
            invertedIndex.Append("hello", 123, 5);
            invertedIndex.Append("hello", 123, 1);
            invertedIndex.Append("hello", 123, 49);
            invertedIndex.Append("hello", 123, 100);

            var postings = invertedIndex.GetPostingsFor("hello");

            Assert.AreEqual(1, postings[0].Positions[0]);
            Assert.AreEqual(5, postings[0].Positions[1]);
            Assert.AreEqual(49, postings[0].Positions[2]);
            Assert.AreEqual(100, postings[0].Positions[3]);
        }

        [TestMethod]
        public void Returns0ForFrequencyOfTermAbsentInIndexes()
        {
            InvertedIndex invertedIndex = new InvertedIndex();
            invertedIndex.Append("today", 123, 5);

            var freq = invertedIndex.GetFrequencyOfTermInDocument("hello", 123);

            Assert.AreEqual(0, freq);
        }

        [TestMethod]
        public void GetsTheFrequencyOfATermInADocument()
        {
            InvertedIndex invertedIndex = new InvertedIndex();
            invertedIndex.Append("hello", 123, 5);
            invertedIndex.Append("hello", 123, 1);
            invertedIndex.Append("hello", 123, 49);
            invertedIndex.Append("hello", 123, 100);

            var freq = invertedIndex.GetFrequencyOfTermInDocument("hello", 123);

            Assert.AreEqual(4, freq);
        }

        [TestMethod]
        public void GetsTheFrequencyOfATermAccrossDocuments()
        {
            InvertedIndex invertedIndex = new InvertedIndex();

            invertedIndex.Append("hello", 123, 5);
            invertedIndex.Append("hello", 100, 1);
            invertedIndex.Append("hello", 55, 49);
            invertedIndex.Append("hello", 21, 100);

            invertedIndex.Append("once", 21, 100);

            var freq = invertedIndex.GetFrequencyAccrossDocuments("hello");
            var freq2 = invertedIndex.GetFrequencyAccrossDocuments("once");
            var freq3 = invertedIndex.GetFrequencyAccrossDocuments("absent");

            Assert.AreEqual(4, freq);
            Assert.AreEqual(1, freq2);
            Assert.AreEqual(0, freq3);
        }

        [TestMethod]
        public void InvertedIndexesAreAlwaysSortedByTerm()
        {
            InvertedIndex invertedIndex = new InvertedIndex();
            invertedIndex.Append("cccc", 123, 5);
            invertedIndex.Append("bbbb", 123, 1);
            invertedIndex.Append("aaaa", 123, 49);
            invertedIndex.Append("zzzz", 123, 100);


            Assert.AreEqual("aaaa", invertedIndex.GetTermAtIndex(0));
            Assert.AreEqual("bbbb", invertedIndex.GetTermAtIndex(1));
            Assert.AreEqual("cccc", invertedIndex.GetTermAtIndex(2));
            Assert.AreEqual("zzzz", invertedIndex.GetTermAtIndex(3));
        }

        [TestMethod]
        public void PostingsAreAlwaysSortedByDocumentId()
        {
            InvertedIndex invertedIndex = new InvertedIndex();
            invertedIndex.Append("hello", 123, 5);
            invertedIndex.Append("hello", 100, 1);
            invertedIndex.Append("hello", 55, 49);
            invertedIndex.Append("hello", 21, 100);

            var postings = invertedIndex.GetPostingsFor("hello");

            Assert.AreEqual(21, postings[0].DocumentID);
            Assert.AreEqual(55, postings[1].DocumentID);
            Assert.AreEqual(100, postings[2].DocumentID);
            Assert.AreEqual(123, postings[3].DocumentID);
        }
    }
}
