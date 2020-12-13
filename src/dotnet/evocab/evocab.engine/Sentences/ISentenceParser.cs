using evocab.engine.Sentences.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace evocab.engine.Sentences
{
    public interface ISentenceParser
    {
        /// <summary>
        /// 
        /// </summary>
        bool IsEndOfText { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        void Init(string text);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        SentenceBorder? GetNextSentence();
    }
}
