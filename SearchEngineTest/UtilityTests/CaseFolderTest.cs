using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;
using System;

namespace SearchEngineTest
{
    [TestClass]
    public class CaseFolderTest
    {
        [TestMethod]
        public void FoldAllCasesToLower()
        {
            string text = "THIS IS CAPITAL";
            Assert.AreEqual(CaseFolder.CaseFold(text), text.ToLower());
        }
    }
}