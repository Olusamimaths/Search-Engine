using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace SearchEngineTest
{
    [TestClass]
    public class StopWordsTest
    {

        [TestMethod]
        public void RemoveStopWordsTest()
        {
            string text = "THIS IS CAPITAL";
            string result_text = "this capital";
            Assert.AreEqual(result_text, StopWords.RemoveStopWords(new HashSet<string> { "a", "is", "the" }, text));
        }

        [TestMethod]
        public void RemoveStopWordsTest2()
        {
            string text = "a, an, and, are, as, at, be, but, by, for, if, in, into, is, it, no, not, of, on, or, such, that, the, their, then, there, these, they, this, to, was, will, with";
            string result_text = "";
            Assert.AreEqual(result_text, StopWords.RemoveStopWords(
                new HashSet<string> { "a", "an", "and", "are", "as", "at", "be", "but", "by", "for",
        "if", "in", "into", "is", "it", "no", "not", "of", "on", "or", "such", "that", "the",
        "their", "then", "there", "these", "they", "this", "to", "was", "will", "with"}, 
                text));
        }

        [TestMethod]
        public void CheckStripTextTest()
        {
            string text = "THis is a simple, test, of ... strip,ping";
            string result = "THis is a simple  test  of     strip ping";
            result = result.Trim();
            var result_list = Regex.Split(result, "\\s+").ToList();
            CollectionAssert.AreEqual(result_list, StopWords.Strip(text));
        }

        [TestMethod]
        public void CheckStripTextTest2()
        {
            string text = "......";
            string result = "      ";
            result = result.Trim();
            var result_list = Regex.Split(result, "\\s+").ToList();
            CollectionAssert.AreEqual(result_list, StopWords.Strip(text));
        }

    }
}