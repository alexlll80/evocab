using evocab.engine.Common.Extensions;
using evocab.engine.Parsers;
using evocab.engine.Sentences.Models;
using System;
using System.Text;

namespace evocab.engine.Sentences
{
    public class EngSentenceParser : ISentenceParser
    {
        private const string EndSentenceMarks = ".?!…";
        private const char Period = '.';
        private const string ApostropheOpening = "`'\"‘“«";
        private const string ApostropheClosing = "’”\"'»";

        private string _text;
        private int _currentPos = 0;
 
        public bool IsEndOfText => _currentPos >= (_text?.Length ?? 0);

        public void Init(string text)
        {
            _text = text;
            _currentPos = 0;
        }

        public SentenceBorder? GetNextSentence()
        {
            SentenceBorder border = new SentenceBorder();
                                 
            // skip whitespaces
            while (!IsEndOfText 
                && (char.IsWhiteSpace(_text[_currentPos])
                    || char.IsControl(_text[_currentPos]))
                   )
            {
                _currentPos++;
            }

            bool hasCapitalLetterMet = false;

            border.StartPosition = _currentPos;

            while (!IsEndOfText)
            {
                var currentChar = _text[_currentPos];
                _currentPos++;

                //if (ApostropheOpening.IndexOf(currentChar) > -1)
                //{

                //}

                if (char.IsLetter(currentChar) 
                    && char.IsUpper(currentChar)
                    && !hasCapitalLetterMet)
                {
                    hasCapitalLetterMet = true;
                }

                if (EndSentenceMarks.IndexOf(currentChar) > -1)
                {
                    // skip ellipsis
                    if (_text.IsEllipsis(_currentPos - 1))
                    {
                        _currentPos += 2;                     
                    }

                    if (hasCapitalLetterMet)
                    {
                        border.EndPosition = _currentPos;
                        break;
                    }

                    // TODO:
                }
            }

            if (!border.IsEmpty())
                return border;

            return null;
        }
    }
}
