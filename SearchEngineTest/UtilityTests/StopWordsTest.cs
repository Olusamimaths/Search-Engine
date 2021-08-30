using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;
using System.Collections.Generic;
using System;

namespace SearchEngineTest
{
    [TestClass]
    public class StopWordsTest
    {

        [TestMethod]
        public void RemoveStopWordsTest()
        {
            string text = "THIS IS CAPITAL";
            //string actual_text = RemoveStopWords(new HashSet<string> { "a", "is", "the" }, text);
            string result_text = "this capital";
            Assert.AreEqual(result_text, StopWords.RemoveStopWords(new HashSet<string> { "a", "is", "the" }, text));
        }

        [TestMethod]
        public void CheckStripTextTest()
        {
            string text = "THIS,... IS CAPITAL... , singerafamlm;, capital, lower...";
            //string result_text = ;
        }

    }
}