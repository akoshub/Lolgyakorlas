using Lolgyakorlas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Loltest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1()
        {
            Hos hos = new Hos("Parzival", "a mágányos Hős", "Fighter", "Fighter", 500, 45, 2.2);
            Assert.AreEqual(64.8, hos.ADLevel(10));
        }
        [TestMethod]
        public void Test2()
        {
            Hos hos = new Hos("Parzival", "a mágányos Hős", "Fighter", "Fighter", 500, 45, 2.2);
            Assert.AreEqual(45, hos.ADLevel(1));
        }
        [TestMethod]
        public void Test3()
        {
            Hos hos = new Hos("Parzival", "a mágányos Hős", "Fighter", "Fighter", 500, 45, 2.2);
            Assert.AreEqual(53.8, hos.ADLevel(5));
        }
        [TestMethod]
        public void Test4()
        {
            Hos hos = new Hos("Parzival", "a mágányos Hős", "Fighter", "Fighter", 500, 45, 2.2);
            Assert.AreEqual(82.4, hos.ADLevel(18));
        }
    }
}
