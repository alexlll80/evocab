namespace evocab.engine.Common.Extensions
{
    public static class Punctuation
    {
        private const char Period = '.';
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static bool IsEllipsis(this string text, int position)
        {
            if (text.Length > position + 2
                && text[position] == Period
                && text[position + 1] == Period
                && text[position + 2] == Period)
            {
                return true;
            }

            return false;
        }
    }
}
