using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace evocab.tests.Parsers.TestCases
{
    class SentenceFactory
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData("Kill'em all").Returns("");
                yield return new TestCaseData("Kill'em all").Returns("");
                yield return new TestCaseData("Kill'em all").Returns("");
            }
        }
    } 
}
