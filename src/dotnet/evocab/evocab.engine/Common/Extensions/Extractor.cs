using evocab.engine.Sentences.Models;

namespace evocab.engine.Common.Extensions
{
    public static class Extractor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="border"></param>
        /// <returns></returns>
        public static string GetSubstring(this string text, SentenceBorder border)
        {
            return text.Substring(border.StartPosition, border.EndPosition - border.StartPosition);
        }
    }
}
