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
            // https://en.wikipedia.org/wiki/Wikipedia:List_of_English_contractions
            Words.Init(new List<string>() { 
                "ll",
                "re",
                "m",
                "aight",
                "ve",
                "cause",
                "er",
                "ye",
                "em" ,
                "day",
                "n",
                "clock"
            });
            var text = ClipboardService.GetText();
            //ExtactWords(text);
            //ExtractSentences(text);
            //ExtractWordsInSentences(text);
            CalcWordFrequency(text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        private static void CalcWordFrequency(string text)
        {
            EngSentenceParser parser = new EngSentenceParser();
            EngWordParser wordParser = new EngWordParser();
            Dictionary<string, int> frequency = new Dictionary<string, int>();

            parser.Init(text);
            while (!parser.IsEndOfText)
            {
                var border = parser.GetNextSentence();
                if (border != null)
                {
                    wordParser.Init(text.GetSubstring(border.Value));
                    String word;
                    while (null != (word = wordParser.GetNext()))
                    {
                        var wordUpper = word.ToUpperInvariant();
                        if (!frequency.ContainsKey(wordUpper))
                        {
                            frequency.Add(wordUpper, 1);
                        }
                        else
                        {
                            frequency[wordUpper] = frequency[wordUpper] + 1;
                        }
                    }
                }
            }
            _ = frequency
                .OrderByDescending(e => e.Value)
                .Select(e => { Console.WriteLine($"{e.Key} ({e.Value})"); return e.Key; })
                .ToList();
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
