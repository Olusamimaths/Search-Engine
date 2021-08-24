using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchEngine;
using System.IO;
using System.Linq;

namespace SearchEngineTest
{
    [TestClass]
    public class TokenizerTests
    {
        [TestMethod]
        public void TokenizationWorks()
        {
            string input = "job open. that, word";
            var expected = new [] { "job", "open", "that", "word" };
            using (var reader = new StringReader(input))
            {
                var tokenSource = new Tokenizer();
                tokenSource.SetReader(reader);
                var result = tokenSource.ReadAll().ToArray();
                CollectionAssert.AreEqual(expected, result);
            }
        }
    }
}
