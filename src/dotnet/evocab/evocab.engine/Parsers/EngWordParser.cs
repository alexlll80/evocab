using System.Text;

namespace evocab.engine.Parsers
{
    public class EngWordParser : ISentenceParser
    {
        private string _text;
        private int _currentPos = 0;

        /// <summary>
        /// They are the period (.), question mark (?), exclamation point (!), 
        /// comma, semicolon, colon, dash (--), hyphen (-), parentheses (), brackets [], 
        /// braces {}, apostrophe ('), quotation marks  (" "), and ellipsis (...)
        /// </summary>
        private const string PunctuationMarks = ".?!,;:-()[]{}'\"…";

        private readonly StringBuilder _buffer = new StringBuilder(64);

        public bool IsEndOfText => _currentPos >= (_text?.Length ?? 0);

        public void Init(string text)
        {
            _text = text;
            _currentPos = 0;
        }

        public string GetNext()
        {
            while (!IsEndOfText 
                && !char.IsLetter(_text[_currentPos]))
            {
                _currentPos++;
            }

            _buffer.Clear();

            while (true)
            {
                if (IsEndOfText)
                {
                    break;
                }

                if (!char.IsLetter(_text[_currentPos]))
                {
                    break;
                }

                if (char.IsLetter(_text[_currentPos]))
                {
                    _buffer.Append(_text[_currentPos]);
                }

                _currentPos++;
            }

            if (_buffer.Length > 0)
            {
                return _buffer.ToString();
            }

            return null;
        }
    }
}
