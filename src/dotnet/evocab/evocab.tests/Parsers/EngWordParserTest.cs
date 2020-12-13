using evocab.engine.Parsers;
using evocab.tests.Parsers.TestCases;
using NUnit.Framework;
using System.Text;

namespace evocab.tests.Parsers
{
    public class EngWordParserTest
    {
        private EngWordParser _parser = new EngWordParser();

        [SetUp]
        public void Setup()
        {
            // Method intentionally left empty.
        }

        [Test]
        public void Test_IsEndOfText_ExpectedSuccessCase()
        {
            _parser.Init(null);
            Assert.IsTrue(_parser.IsEndOfText);

            _parser.Init(string.Empty);
            Assert.IsTrue(_parser.IsEndOfText);

            _parser.Init("I love this game");

            var word = _parser.GetNext();
            Assert.AreEqual(word, "I");

            word = _parser.GetNext();
            Assert.AreEqual(word, "love");

            word = _parser.GetNext();
            Assert.AreEqual(word, "this");

            word = _parser.GetNext();
            Assert.AreEqual(word, "game");

            word = _parser.GetNext();
            Assert.IsNull(word);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [Test]
        [TestCaseSource(typeof(SentenceFactory),"TestCases")]
        public string Test_GetNextWord_ExpectedSuccessCase(string text)
        {
            string word = string.Empty;

            _parser.Init(text);

            var stringBuilder = new StringBuilder();
            while(null != (word = _parser.GetNext()))
            {
                stringBuilder.AppendLine(word);
            }

            return stringBuilder.ToString();
        }
    }
}
