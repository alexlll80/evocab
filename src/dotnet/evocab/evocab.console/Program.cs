using evocab.engine.Parsers;
using System;
using System.Collections.Generic;
using TextCopy;
using System.Linq;
using evocab.engine.Sentences;
using evocab.engine.Common.Extensions;

namespace evocab.console
{
    /// <summary>
    /// 
    /// </summary>
    internal static class Program
    {
        static void Main(string[] args)
        {
            var text = ClipboardService.GetText();
            //ExtactWords(text);
            //ExtractSentences(text);
            ExtractWordsInSentences(text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        private static void ExtractWordsInSentences(string text)
        {
            EngSentenceParser parser = new EngSentenceParser();
            EngWordParser wordParser = new EngWordParser();
            parser.Init(text);
            int counter = 1;
            while (!parser.IsEndOfText)
            {
                var border = parser.GetNextSentence();
                if (border != null)
                {
                    Console.WriteLine($"({counter++})");
                    wordParser.Init(text.GetSubstring(border.Value));
                    String word;
                    while (null != (word = wordParser.GetNext()))
                    {
                        Console.WriteLine(word.ToUpperInvariant());
                    }
                }
                else
                {
                    Console.WriteLine("we can't detect sentence border ");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        private static void ExtractSentences(string text)
        {
            EngSentenceParser parser = new EngSentenceParser();
            parser.Init(text);
            int counter = 1;
            while (!parser.IsEndOfText)
            {       
                var border = parser.GetNextSentence();
                if (border != null)
                {
                    Console.WriteLine($"({counter++}) {text.GetSubstring(border.Value)}");
                }
                else
                {
                    Console.WriteLine("we can't detect sentence border ");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        private static void ExtactWords(string text)
        {
            var uniqHashSet = new HashSet<string>();
            EngWordParser parser = new EngWordParser();
            parser.Init(text);
            String word;
            while (null != (word = parser.GetNext()))
            {
                uniqHashSet.Add(word.ToUpperInvariant());
            }

            _ = uniqHashSet
                .OrderBy(e => e)
                .Select(word =>
                {
                    Console.WriteLine(word);
                    return word;
                })
                .ToList();
        }
    }
}
