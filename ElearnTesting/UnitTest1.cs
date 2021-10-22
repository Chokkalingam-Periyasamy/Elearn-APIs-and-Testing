using Elearn.ElearnModel;
using NUnit.Framework;

namespace ElearnTesting
{
    public class Tests
    {
        public staff lg;
        [SetUp]
        public void Setup()
        {
            lg = new staff();
        }

        [Test]
        public void Test1()
        {
            string actualRes = lg.Email;
            string expectRes = "sri123@gmail.com";
            string actualRes1 = lg.Password;
            string expectRes1 = "sri";
            Assert.AreEqual(expectRes, actualRes);
            Assert.AreEqual(expectRes1, actualRes1);
            Assert.Pass();
        }
    }
}